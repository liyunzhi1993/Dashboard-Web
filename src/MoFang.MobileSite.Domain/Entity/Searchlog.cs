using System;
using System.Collections.Generic;

namespace MoFang.MobileSite.Domain.Entity
{
    public partial class Searchlog
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string CityName { get; set; }
        public string BizAreaName { get; set; }
        public DateTimeOffset ModifiedTime { get; set; }
    }
}
