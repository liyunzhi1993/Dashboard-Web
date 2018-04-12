using System;
using System.Collections.Generic;

namespace MoFang.MobileSite.Domain.Entity
{
    public partial class Station
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Parent { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public sbyte IsValid { get; set; }
        public int Type { get; set; }
        public int Seq { get; set; }
        public double Lng { get; set; }
        public double Lat { get; set; }
        public sbyte HasStore { get; set; }
    }
}
