using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class DeliveryDetail
    {
        public DeliveryDetail(long Id,long IdPOFix,string POCode,string PartCode,int Quantity,DateTime DateOut,string DeCode,string FactoryCustomer,string CarNumber,string FactoryCode,int StatusDetail,int QuantityOut)
        {
            this.Id = Id;
            this.IdPOFix = IdPOFix;
            this.POCode = POCode;
            this.PartCode = PartCode;
            this.Quantity = Quantity;
            this.DateOut = DateOut;
            this.DeCode = DeCode;
            this.FactoryCustomer = FactoryCustomer;
            this.CarNumber = CarNumber;
            this.FactoryCode = FactoryCode;
            this.StatusDetail = StatusDetail;
            this.QuantityOut = QuantityOut;
        }
        public DeliveryDetail(DataRow row)
        {
            this.Id = (long)row["Id"];
            this.IdPOFix = (long)row["IdPOFix"];
            this.POCode = row["POCode"].ToString();
            this.PartCode = row["PartCode"].ToString();
            this.Quantity = (int)row["Quantity"];
            this.DateOut = (DateTime)row["DateOut"];
            this.DeCode = row["DeCode"].ToString();
            this.FactoryCustomer = row["FactoryCustomer"].ToString();
            this.CarNumber = row["CarNumber"].ToString();
            this.FactoryCode = row["FactoryCode"].ToString();
            this.StatusDetail = (int)row["StatusDetail"];
            this.QuantityOut = (int)row["QuantityOut"];
        }
        private long id;
        private long idPOFix;
        private string pOCode;
        private string partCode;
        private int quantity;
        private DateTime dateOut;
        private string deCode;
        private string factoryCustomer;
        private string carNumber;
        private string factoryCode;
        private int statusDetail;
        private int quantityOut;

        public long Id { get => id; set => id = value; }
        public long IdPOFix { get => idPOFix; set => idPOFix = value; }
        public string POCode { get => pOCode; set => pOCode = value; }
        public string PartCode { get => partCode; set => partCode = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public DateTime DateOut { get => dateOut; set => dateOut = value; }
        public string DeCode { get => deCode; set => deCode = value; }
        public string FactoryCustomer { get => factoryCustomer; set => factoryCustomer = value; }
        public string CarNumber { get => carNumber; set => carNumber = value; }
        public string FactoryCode { get => factoryCode; set => factoryCode = value; }
        public int StatusDetail { get => statusDetail; set => statusDetail = value; }
        public int QuantityOut { get => quantityOut; set => quantityOut = value; }
    }
}
