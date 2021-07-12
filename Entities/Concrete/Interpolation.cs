using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Interpolation : IEntity
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public string Picture { get; set; }
    }
}
