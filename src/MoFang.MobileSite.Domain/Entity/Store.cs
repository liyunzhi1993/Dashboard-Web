using System;
using System.Collections.Generic;

namespace MoFang.MobileSite.Domain.Entity
{
    public partial class Store
    {
        public int StoreId { get; set; }
        public string ApiStoreId { get; set; }
        public string BrandId { get; set; }
        public string StoreName { get; set; }
        public string Description { get; set; }
        public string Contact { get; set; }
        public string Receive { get; set; }
        public string Phone { get; set; }
        public string Full360Url { get; set; }
        public string Traffic { get; set; }
        public string Services { get; set; }
        public int Status { get; set; }
        public double Lng { get; set; }
        public double Lat { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public string Photo { get; set; }
        public string Background { get; set; }
        public string Thumb { get; set; }
        public string Address { get; set; }
        public string AvgPrice { get; set; }
        public decimal StartPrice { get; set; }
        public string OpenTime { get; set; }
        public string CloseTime { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTimeOffset ModifiedTime { get; set; }
    }
}
