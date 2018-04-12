using System;
using System.Collections.Generic;

namespace MoFang.MobileSite.Domain.Entity
{
    public partial class Helpinfo
    {
        public int HelpId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Seq { get; set; }
        public bool? IsEnabled { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTimeOffset ModifiedTime { get; set; }
    }
}
