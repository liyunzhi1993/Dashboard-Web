using System;
using System.Collections.Generic;

namespace MoFang.MobileSite.Domain.Entity
{
    public partial class Device
    {
        public string DeviceId { get; set; }
        public int DeviceType { get; set; }
        public string DeviceName { get; set; }
        public string IconUrl { get; set; }
        public string BrandId { get; set; }
        public int Seq { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTimeOffset ModifiedTime { get; set; }
        public int? ProId { get; set; }
    }
}
