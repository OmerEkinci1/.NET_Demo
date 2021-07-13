using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Interpolation : IEntity
    {
        public int ID { get; set; }
        public string ImagePath { get; set; }
        public string ClassName { get; set; }
    }
}
