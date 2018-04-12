using System;
using System.Collections.Generic;

namespace MoFang.MobileSite.Domain.Entity
{
    public partial class Collect
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public int? RoomTypeId { get; set; }
        public int? StoreId { get; set; }
        public int Status { get; set; }
        public int? Type { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTimeOffset ModifiedTime { get; set; }
    }
}
