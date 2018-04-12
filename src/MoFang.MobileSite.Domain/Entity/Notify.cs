using System;
using System.Collections.Generic;

namespace MoFang.MobileSite.Domain.Entity
{
    public partial class Notify
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Thumb { get; set; }
        public string PhoneNumber { get; set; }
        public string Content { get; set; }
        public DateTime ActualTime { get; set; }
        public int Seq { get; set; }
        public int Type { get; set; }
        public sbyte IsSys { get; set; }
        public sbyte IsPushTop { get; set; }
        public DateTime Created { get; set; }
    }
}
