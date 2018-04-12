using System;
using System.Collections.Generic;

namespace MoFang.MobileSite.Domain.Entity
{
    public partial class Cooperation
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Content { get; set; }
        public DateTime? LastModified { get; set; }
        public int? Type { get; set; }
    }
}
