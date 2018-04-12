using System;
using System.Collections.Generic;

namespace MoFang.MobileSite.Domain.Entity
{
    public partial class Roomtypedevice
    {
        public int Id { get; set; }
        public int RoomTypeId { get; set; }
        public string DeviceId { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTimeOffset ModifiedTime { get; set; }
    }
}
