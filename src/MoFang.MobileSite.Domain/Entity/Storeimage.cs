using System;
using System.Collections.Generic;

namespace MoFang.MobileSite.Domain.Entity
{
    public partial class Storeimage
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int ImgType { get; set; }
        public string ImgUrl { get; set; }
        public int DeviceType { get; set; }
        public bool? IsEnabled { get; set; }
        public int Seq { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTimeOffset ModifiedTime { get; set; }
    }
}
