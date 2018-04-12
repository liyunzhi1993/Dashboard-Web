using System;
using System.Collections.Generic;

namespace MoFang.MobileSite.Domain.Entity
{
    public partial class Recommend
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public int Type { get; set; }
        public sbyte IsValid { get; set; }
    }
}
