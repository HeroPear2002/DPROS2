using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class SupplierDTO
    {
        public SupplierDTO(string VenderCode, string VenderName, string Address, string Phone,string ContactPerson, string FaxNumber)
        {
            this.VenderCode = VenderCode;
            this.VenderName = VenderName;
            this.Address = Address;
            this.Phone = Phone;
            this.ContactPerson = ContactPerson;
            this.FaxNumber = FaxNumber;
        }
        public SupplierDTO(DataRow row)
        {
            this.VenderCode = row["VenderCode"].ToString();
            this.VenderName = row["VenderName"].ToString();
            this.Address = row["Address"].ToString();
            this.Phone = row["Phone"].ToString();
            this.ContactPerson = row["ContactPerson"].ToString();
            this.FaxNumber = row["FaxNumber"].ToString();
        }
        private string venderCode;
        private string venderName;
        private string address;
        private string phone;
        private string contactPerson;
        private string faxNumber;

        public string VenderCode
        {
            get
            {
                return venderCode;
            }

            set
            {
                venderCode = value;
            }
        }

        public string VenderName
        {
            get
            {
                return venderName;
            }

            set
            {
                venderName = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                phone = value;
            }
        }

        public string ContactPerson { get => contactPerson; set => contactPerson = value; }
        public string FaxNumber { get => faxNumber; set => faxNumber = value; }
    }
}
