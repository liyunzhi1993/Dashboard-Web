using System;
using System.Collections.Generic;

namespace MoFang.MobileSite.Domain.Entity
{
    public partial class Banner:BaseEntity
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Photo { get; set; }
        public string Link { get; set; }
        public int Seq { get; set; }
        public sbyte IsPushTop { get; set; }
        public sbyte IsValid { get; set; }
    }
}
