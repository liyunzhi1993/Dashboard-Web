using System;
using System.Collections.Generic;

namespace MoFang.MobileSite.Domain.Entity
{
    public partial class Usermenus
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string NullPopMessage { get; set; }
        public string TagIcon { get; set; }
        public int Type { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
