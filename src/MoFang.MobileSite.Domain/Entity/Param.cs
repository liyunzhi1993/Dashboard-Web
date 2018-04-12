using System;
using System.Collections.Generic;

namespace MoFang.MobileSite.Domain.Entity
{
    public partial class Param
    {
        public string ParamCode { get; set; }
        public string ParamName { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTimeOffset ModifiedTime { get; set; }
    }
}
