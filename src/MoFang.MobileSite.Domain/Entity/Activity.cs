using System;
using System.Collections.Generic;

namespace MoFang.MobileSite.Domain.Entity
{
    public partial class Activity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ArticleId { get; set; }
        public decimal Progress { get; set; }
        public int Type { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Amount { get; set; }
        public int Status { get; set; }
        public int Players { get; set; }
        public string City { get; set; }
    }
}
