using System;
using System.Collections.Generic;

namespace MoFang.MobileSite.Domain.Entity
{
    public partial class Cityarea
    {
        public string Code { get; set; }
        public string ParentCode { get; set; }
        public string Name { get; set; }
        public sbyte IsValid { get; set; }
        public int Seq { get; set; }
        public string Location { get; set; }
    }
}
