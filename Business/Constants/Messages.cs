using Business.Services;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        public static string pictureIsAlreadyExist = "Picture data is already exist in database";
        public static string textDataIsAlreadyExist = "Picture JSON is already exist in database";
        public static string pictureAdded = "Picture is added to database";
        public static string pictureUpdated = "Picture is updated to database";
        public static string pictureDeleted = "Picture is deleted from database";
        public static string thereIsNoPicture = "There is no picture data to get from database";
        public static string pictureLimitIsFull = "There are 30 picture in database. Limit is over";
        public static string PhotoIsSendingToMLServer = "Photo is sending for evaluating prediction";
        public static string Unknown = "Unknown";

        public static string Added { get; internal set; }
        public static string NameAlreadyExist { get; internal set; }
        public static string Deleted { get; internal set; }
        public static string Updated { get; internal set; }
        public static string WrongCitizenId { get; internal set; }
        public static string SendPassword { get; internal set; }
        public static string NewPassword { get; internal set; }
        public static string TrueButCellPhone { get; internal set; }
        public static DArchToken InvalidCode { get; internal set; }
        public static string TokenProviderException { get; internal set; }
        public static string SuccessfulLogin { get; internal set; }
        public static string SmsServiceNotFound { get; internal set; }
        public static string SendMobileCode { get; internal set; }
    }
}
