using System;
using System.Collections.Generic;

namespace MoFang.MobileSite.Domain.Entity
{
    public partial class Notifylog
    {
        public int Id { get; set; }
        public string NotifyId { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime ReadTime { get; set; }
    }
}
