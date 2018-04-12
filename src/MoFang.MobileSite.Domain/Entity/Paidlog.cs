using System;
using System.Collections.Generic;

namespace MoFang.MobileSite.Domain.Entity
{
    public partial class Paidlog
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public string TradeNo { get; set; }
        public decimal Payment { get; set; }
        public DateTime Paytime { get; set; }
        public string PayMethod { get; set; }
        public string PaySource { get; set; }
        public int Status { get; set; }
        public int Omsstatus { get; set; }
        public int OmscreditCount { get; set; }
        public string PhoneNumber { get; set; }
        public int ContractMonthCount { get; set; }
        public int PayMonthCount { get; set; }
        public string ContractId { get; set; }
        public string OrgName { get; set; }
        public string RoomTypeName { get; set; }
        public string RoomName { get; set; }
        public string Contact { get; set; }
        public string Message { get; set; }
        public int OrderType { get; set; }
        public string StoreId { get; set; }
        public int BillType { get; set; }
        public string OmsAccountSubjectCode { get; set; }
        public string BillNo { get; set; }
        public int CouponStatus { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime LastModified { get; set; }
    }
}
