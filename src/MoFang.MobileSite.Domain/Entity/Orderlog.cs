using System;
using System.Collections.Generic;

namespace MoFang.MobileSite.Domain.Entity
{
    public partial class Orderlog
    {
        public int Id { get; set; }
        public string Contact { get; set; }
        public string ContactPhone { get; set; }
        public string Guest { get; set; }
        public string Phone { get; set; }
        public string PapersType { get; set; }
        public string PapersNo { get; set; }
        public string UserId { get; set; }
        public int RoomId { get; set; }
        public string RoomNo { get; set; }
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public DateTime CheckIn { get; set; }
        public int Lease { get; set; }
        public DateTime? SeeRoomDate { get; set; }
        public string SeeAlterRoom { get; set; }
        public sbyte IsSeeRoom { get; set; }
        public string Message { get; set; }
        public int PayType { get; set; }
        public sbyte IsPayDeposit { get; set; }
        public decimal Price { get; set; }
        public decimal RawPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Payment { get; set; }
        public string PayMethod { get; set; }
        public int Status { get; set; }
        public string CloseReason { get; set; }
        public int RefundStatus { get; set; }
        public DateTime Created { get; set; }
        public decimal CouponPaid { get; set; }
        public decimal PointPaid { get; set; }
        public int Type { get; set; }
        public string Remark { get; set; }
        public int? CouponStatus { get; set; }
        public string CaseCode { get; set; }
    }
}
