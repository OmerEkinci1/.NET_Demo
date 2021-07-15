using System;
using System.Collections.Generic;
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
    }
}
