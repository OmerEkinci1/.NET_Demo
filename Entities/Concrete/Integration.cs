using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Integration : IEntity
    {
        public int ID { get; set; }
        public string JSON_TEXT { get; set; }
        public DateTime INS_DT { get; set; }
        public string IS_PROCESSED { get; set; }
        public byte[] PICTURE { get; set; }
        public DateTime PROCESSED_DT { get; set; }
        public int PRODUCT_TYPE { get; set; }
    }
}
