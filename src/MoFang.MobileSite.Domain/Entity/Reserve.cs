using System;
using System.Collections.Generic;

namespace MoFang.MobileSite.Domain.Entity
{
    public partial class Reserve
    {
        public string Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Contact { get; set; }
        public string ContactPhone { get; set; }
        public string RoomId { get; set; }
        public string RoomName { get; set; }
        public string OrgId { get; set; }
        public string OrgName { get; set; }
        public DateTime? SeeRoomDate { get; set; }
        public string Message { get; set; }
        public decimal? Price { get; set; }
        public int? Status { get; set; }
        public string Reason { get; set; }
        public string CaseCode { get; set; }
        public DateTime Created { get; set; }
    }
}
