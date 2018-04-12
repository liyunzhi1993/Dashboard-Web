using System;
using System.Collections.Generic;

namespace MoFang.MobileSite.Domain.Entity
{
    public partial class Advertise
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Photo { get; set; }
        public string Link { get; set; }
        public DateTime Created { get; set; }
        public int Seq { get; set; }
        public string CategoryId { get; set; }
        public int Type { get; set; }
        public sbyte IsValid { get; set; }
    }
}
