using System;
using System.Collections.Generic;

namespace MoFang.MobileSite.Domain.Entity
{
    public partial class Notice
    {
        public int NoticeId { get; set; }
        public string Title { get; set; }
        public string LinkUrl { get; set; }
        public int Seq { get; set; }
        public bool? IsEnabled { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTimeOffset ModifiedTime { get; set; }
    }
}
