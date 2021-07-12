using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketConn.Connection
{
    public class StateObject
    { 
        public Socket workSocket = null; 
        public const int BufferSize = 1024;
        public byte[] buffer = new byte[BufferSize]; 
        public StringBuilder sb = new StringBuilder();
    }

    public class AsynchronousClient
    {
        private const int port = 11000;
 
        private static ManualResetEvent connectDone =
            new ManualResetEvent(false);
        private static ManualResetEvent sendDone =
            new ManualResetEvent(false);
        private static ManualResetEvent receiveDone =
            new ManualResetEvent(false);

        private static String response = String.Empty; // pythondan gelecek response

        private static void StartClient()
        {
            // Pythona bağlanma 
            try
            {
                // sokette remote endpoint oluşturup isim koyuldu  
                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = ipHostInfo.AddressList[1];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

                // UDP soket oluşumu
                Socket client = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Udp);

                // Python'da response gönderilecek son noktaya bakma 
                client.BeginConnect(remoteEP,
                    new AsyncCallback(ConnectCallback), client);
                connectDone.WaitOne();

                // Resim buradan gönderilecek.
                Send(client, "This is a test<EOF>");
                sendDone.WaitOne();

                // Pythondan response alma 
                Receive(client);
                receiveDone.WaitOne();

                // Gelen response u konsola yazma, bu sonucu Devexpresse göndericez. 
                Console.WriteLine("Response received : {0}", response);

                // Soketi kapatma
                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // soketi geri alma  
                Socket client = (Socket)ar.AsyncState;

                // bağlantıyı tamamlama 
                client.EndConnect(ar);

                Console.WriteLine("Socket connected to {0}",
                    client.RemoteEndPoint.ToString());

                // bağlantı oluştuğuna dair sinyal.
                connectDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void Receive(Socket client)
        {
            try
            {
                // Sabit obje oluşturma. 
                StateObject state = new StateObject();
                state.workSocket = client;

                // Pythondan data almaya başlama.
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the state object and the client socket   
                // from the asynchronous state object.  
                StateObject state = (StateObject)ar.AsyncState;
                Socket client = state.workSocket;

                // Pythondan veriyi okuma.
                int bytesRead = client.EndReceive(ar);

                if (bytesRead > 0)
                {
                    // There might be more data, so store the data received so far.  
                    state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));

                    // Datanın kalanını alma.
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReceiveCallback), state);
                }
                else
                {
                    // Tüm datalar geldi, response a bak.
                    if (state.sb.Length > 1)
                    {
                        response = state.sb.ToString();
                    }
                    // Tüm bytelerın geldiğine dair sinyal.
                    receiveDone.Set();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void Send(Socket client, String data)
        {
            // stringi byte a çevirme.
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            // datayı pythona göndermeye başlama. 
            client.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), client);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // soketi stateden geri alma.
                Socket client = (Socket)ar.AsyncState;

                // datayı pythona göndermeyi bitirme. 
                int bytesSent = client.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to server.", bytesSent);

                // işlemin bittiğine dair sinyal. 
                sendDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static int Main(String[] args)
        {
            StartClient();
            return 0;
        }
    }
}
