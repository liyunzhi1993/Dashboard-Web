using System;
using System.Collections.Generic;

namespace MoFang.MobileSite.Domain.Entity
{
    public partial class Roomtype
    {
        public int RoomTypeId { get; set; }
        public int StoreId { get; set; }
        public string RoomTypeName { get; set; }
        public decimal Price { get; set; }
        public string Desc { get; set; }
        public string ApiRoomTypeId { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTimeOffset ModifiedTime { get; set; }
        public sbyte IsValid { get; set; }
        public bool? IsShowIndex { get; set; }
    }
}
