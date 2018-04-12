using System;
using System.Collections.Generic;

namespace MoFang.MobileSite.Domain.Entity
{
    public partial class Feedback
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Content { get; set; }
        public string Photos { get; set; }
        public int Type { get; set; }
        public DateTime Created { get; set; }
        public int? StoreId { get; set; }
    }
}
