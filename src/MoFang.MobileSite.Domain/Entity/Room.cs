using System;
using System.Collections.Generic;

namespace MoFang.MobileSite.Domain.Entity
{
    public partial class Room
    {
        public int RoomId { get; set; }
        public string BrandId { get; set; }
        public string RoomNo { get; set; }
        public int RoomTypeId { get; set; }
        public string RoomTypeName { get; set; }
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public decimal Price { get; set; }
        public int Area { get; set; }
        public bool? IsShowIndex { get; set; }
        public int Weight { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTimeOffset ModifiedTime { get; set; }
        public sbyte IsValid { get; set; }
    }
}
