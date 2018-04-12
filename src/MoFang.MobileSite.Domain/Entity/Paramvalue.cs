using System;
using System.Collections.Generic;

namespace MoFang.MobileSite.Domain.Entity
{
    public partial class Paramvalue
    {
        public int Id { get; set; }
        public string ParamCode { get; set; }
        public string ParamValueCode { get; set; }
        public string ParamValueName { get; set; }
        public int Seq { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTimeOffset ModifiedTime { get; set; }
    }
}
