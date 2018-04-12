using System;
using System.Collections.Generic;

namespace MoFang.MobileSite.Domain.Entity
{
    public partial class Brand
    {
        public string BrandId { get; set; }
        public string BrandName { get; set; }
        public string BrandAddr { get; set; }
        public string Introduction { get; set; }
        public string Thumb { get; set; }
        public string Photo { get; set; }
        public string Background { get; set; }
        public string Brandword { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTimeOffset ModifiedTime { get; set; }
    }
}
