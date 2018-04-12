using System;
using System.Collections.Generic;

namespace MoFang.MobileSite.Domain.Entity
{
    public partial class Storedevice
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public string DeviceId { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTimeOffset ModifiedTime { get; set; }
    }
}
