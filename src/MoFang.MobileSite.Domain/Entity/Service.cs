using System;
using System.Collections.Generic;

namespace MoFang.MobileSite.Domain.Entity
{
    public partial class Service
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public int ServiceType { get; set; }
        public string IconUrl { get; set; }
        public string LinkUrl { get; set; }
        public string NullPopMessage { get; set; }
        public string Badge { get; set; }
        public string Description { get; set; }
        public int OperationType { get; set; }
        public string OperationTag { get; set; }
        public bool? IsShowIndex { get; set; }
        public int IndexSeq { get; set; }
        public int Seq { get; set; }
        public bool? IsApponly { get; set; }
        public bool? IsEnabled { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTimeOffset ModifiedTime { get; set; }
    }
}
