using System;
using System.Collections.Generic;
using System.Configuration;
using System.ServiceModel;
using System.Text;

namespace Core.Utilities.Common
{
    public class WcfProxy<T>
    {
        // Burayı oluşturma amacımız normalde WCF servisini tanımladıktan sonra Service Reference'dan 
        // ekleme durumunda bulunuyoruz. Channel yapısını yaparak dinamik bir yapı oluşturmak istiyoruz.
        public static T CreateChannel()
        {
            // isimlendirmeyi dinamik hale getirdik.Bizim verdiğimiz class isimleri artık dinamil olarak url haline gelicek.
            string baseAddress = ConfigurationManager.AppSettings["ServiceAddress"]; // ServiceAddress'in UI config dosyasına yazılması gerekmektedir.
            // config dosyasına eklenmesi gereken satır : <add key="ServiceAddress" value="http://localhost:35259/{0}.svc"/>
            // Bu UI confige yazıldıktan sonra herhangi bir etkileşime gerek yok burası güncellendikçe diğer taraf güncellenicek.
            string address = string.Format(baseAddress, typeof(T).Name.Substring(1));
            EndpointAddress end = new EndpointAddress(address);

            var binding = new BasicHttpBinding();
            var channel = new ChannelFactory<T>(binding,end);

            return channel.CreateChannel();
        }
    }
}
