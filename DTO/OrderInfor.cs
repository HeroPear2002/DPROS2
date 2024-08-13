using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class OrderInfor
    {
        public OrderInfor(long Id ,string OrderCode,string MaterialCode,string MaterialName,int CountBy,decimal Price,DateTime DateDK,string VendorCode,int StatusOrder)
        {
            this.Id = Id;
            this.OrderCode = OrderCode;
            this.MaterialCode = MaterialCode;
            this.MaterialName = MaterialName;
            this.CountBy = CountBy;
            this.Price = Price;
            this.DateDK = DateDK;
            this.VendorCode = VendorCode;
            this.StatusOrder = StatusOrder;
        }
        public OrderInfor(DataRow row)
        {
            this.Id = (long)row["Id"];
            this.OrderCode = row["OrderCode"].ToString();
            this.MaterialCode = row["MaterialCode"].ToString();
            this.MaterialName = row["MaterialName"].ToString();
            this.CountBy = (int)row["CountBy"];
            this.Price = (decimal)row["Price"];
            this.DateDK = (DateTime)row["DateDK"];
            this.VendorCode = row["VendorCode"].ToString();
            this.StatusOrder = (int)row["StatusOrder"];
        }
        private long id;
        private string orderCode;
        private string materialCode;
        private string materialName;
        private int countBy;
        private decimal price;
        private DateTime dateDK;
        private string vendorCode;
        private int statusOrder;

        public string OrderCode { get => orderCode; set => orderCode = value; }
        public string MaterialCode { get => materialCode; set => materialCode = value; }
        public int CountBy { get => countBy; set => countBy = value; }
        public decimal Price { get => price; set => price = value; }
        public DateTime DateDK { get => dateDK; set => dateDK = value; }
        public string MaterialName { get => materialName; set => materialName = value; }
        public string VendorCode { get => vendorCode; set => vendorCode = value; }
        public long Id { get => id; set => id = value; }
        public int StatusOrder { get => statusOrder; set => statusOrder = value; }
    }
}
