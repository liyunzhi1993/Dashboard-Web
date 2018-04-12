using System;
using System.Collections.Generic;

namespace MoFang.MobileSite.Domain.Entity
{
    public partial class Maintain
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Type { get; set; }
        public DateTime MarkTime { get; set; }
        public string Desc { get; set; }
        public string Photos { get; set; }
        public DateTime? SeriviceTime { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
