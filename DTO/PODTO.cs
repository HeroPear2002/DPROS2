using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class PODTO
    {
        public PODTO(long Id,string POCode,string PartCode,int QuantityIn,DateTime DateInput, int StatusPO, string FactoryCode, string Price, DateTime DateOut, string Customer,int QuantityOut, int Quantity, float Ratio)
        {
            this.Id = Id;
            this.POCode = POCode;
            this.PartCode = PartCode;
            this.QuantityIn = QuantityIn;
            this.DateInput = DateInput;
            this.StatusPO = StatusPO;
            this.FactoryCode = FactoryCode;
            this.Price = Price;
            this.DateOut = DateOut;
            this.Customer = Customer;
            this.QuantityOut = QuantityOut;
            this.Quantity = Quantity;
            this.Ratio = Ratio;
        }
        public PODTO(DataRow row)
        {
            this.Id = (long)row["Id"];
            this.POCode = row["POCode"].ToString();
            this.PartCode = row["PartCode"].ToString();
            this.QuantityIn = (int)row["QuantityIn"];
            this.DateInput = (DateTime)row["DateInput"];
            this.StatusPO = (int)row["StatusPO"];
            this.FactoryCode = row["FactoryCode"].ToString();
            this.Price = row["Price"].ToString();
            this.DateOut = (DateTime)row["DateOut"];
            this.Customer = row["Customer"].ToString();
            this.QuantityOut = (int)row["QuantityOut"];
            this.Quantity = (int)row["Quantity"];
            var checkRatio = row["Ratio"].ToString();
            if(checkRatio != "")
            this.Ratio = (float)Convert.ToDouble(checkRatio);
        }
        private string pOCode;
        private string partCode;
        private int quantityIn;
        private DateTime dateInput;
        private int statusPO;
        private string factoryCode;
        private long id;
        private string price;
        private DateTime dateOut;
        private string customer;
        private int quantityOut;
        private int quantity;
        private float ratio;

        public int QuantityOut { get => quantityOut; set => quantityOut = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public float Ratio { get => ratio; set => ratio = value; }

        public string POCode
        {
            get
            {
                return pOCode;
            }

            set
            {
                pOCode = value;
            }
        }

        public string PartCode
        {
            get
            {
                return partCode;
            }

            set
            {
                partCode = value;
            }
        }

        public int QuantityIn
        {
            get
            {
                return quantityIn;
            }

            set
            {
                quantityIn = value;
            }
        }

        public DateTime DateInput
        {
            get
            {
                return dateInput;
            }

            set
            {
                dateInput = value;
            }
        }

        public int StatusPO
        {
            get
            {
                return statusPO;
            }

            set
            {
                statusPO = value;
            }
        }

        public string FactoryCode { get => factoryCode; set => factoryCode = value; }
        public long Id { get => id; set => id = value; }
        public string Price { get => price; set => price = value; }
        public DateTime DateOut { get => dateOut; set => dateOut = value; }
        public string Customer { get => customer; set => customer = value; }
    }
}
