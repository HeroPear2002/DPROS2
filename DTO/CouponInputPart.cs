using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class CouponInputPart
    {
        public CouponInputPart(string PartCode,DateTime DateInput,DateTime DateManufacturi,string Name,string FactoryCode,string QrCode)
        {
            this.PartCode = PartCode;
            this.DateInput = DateInput;
            this.DateManufacturi = DateManufacturi;
            this.Name = Name;
            this.FactoryCode = FactoryCode;
            this.QrCode = QrCode;
        }
        public CouponInputPart(DataRow row)
        {
            this.PartCode = row["PartCode"].ToString();
            this.DateInput = (DateTime)row["DateInput"];
            this.DateManufacturi = (DateTime)row["DateManufacturi"];
            this.Name = row["Name"].ToString();
            this.FactoryCode = row["FactoryCode"].ToString();
            this.QrCode = row["QrCode"].ToString();
        }
        private string partCode;
        private DateTime dateInput;
        private DateTime dateManufacturi;
        private string name;
        private string factoryCode;
        private string qrCode;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public DateTime DateManufacturi
        {
            get
            {
                return dateManufacturi;
            }

            set
            {
                dateManufacturi = value;
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

        public string FactoryCode { get => factoryCode; set => factoryCode = value; }
        public string QrCode { get => qrCode; set => qrCode = value; }
    }
}
