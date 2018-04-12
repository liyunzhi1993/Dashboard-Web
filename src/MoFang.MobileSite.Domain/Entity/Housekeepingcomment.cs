using System;
using System.Collections.Generic;

namespace MoFang.MobileSite.Domain.Entity
{
    public partial class Housekeepingcomment
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public string StoreName { get; set; }
        public string UserPhone { get; set; }
        public string StoreManagerName { get; set; }
        public string StoreManagerPhone { get; set; }
        public int Score { get; set; }
        public DateTime CommentTime { get; set; }
        public string ContractId { get; set; }
        public sbyte IsValid { get; set; }
    }
}
