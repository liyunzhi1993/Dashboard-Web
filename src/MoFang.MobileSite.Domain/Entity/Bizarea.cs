using System;
using System.Collections.Generic;

namespace MoFang.MobileSite.Domain.Entity
{
    public partial class Bizarea
    {
        public string Code { get; set; }
        public string ParentCode { get; set; }
        public string Name { get; set; }
        public int Seq { get; set; }
        public double Lng { get; set; }
        public double Lat { get; set; }
        public string District { get; set; }
        public sbyte IsValid { get; set; }
        public sbyte HasStore { get; set; }
    }
}
