using System;
using System.Collections.Generic;

namespace MoFang.MobileSite.Domain.Entity
{
    public partial class Comment
    {
        public int Id { get; set; }
        public string ApiStoreId { get; set; }
        public string StoreName { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserPhone { get; set; }
        public int RoomScore { get; set; }
        public int ApartmenEnvironmentScore { get; set; }
        public int CommunityActivityScore { get; set; }
        public int NetWorkScore { get; set; }
        public float HouseKeepingScore { get; set; }
        public float AverageScore { get; set; }
        public string Content { get; set; }
        public sbyte IsPushTop { get; set; }
        public sbyte IsReplied { get; set; }
        public DateTime CommentTime { get; set; }
        public sbyte IsValid { get; set; }
        public string ContractId { get; set; }
        public string ReplyId { get; set; }
        public string ReplyContent { get; set; }
        public DateTime? ReplyTime { get; set; }
    }
}
