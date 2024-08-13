using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CustomerDTO
    {
        public CustomerDTO(string CustomerCode,string CustomerName, string Address,string Phone,int WarnPOInput,int WarnPOFix,int Other)
        {
            this.CustomerCode = CustomerCode;
            this.CustomerName = CustomerName;
            this.Address = Address;
            this.Phone = Phone;
            this.WarnPOInput = WarnPOInput;
            this.WarnPOFix = WarnPOFix;
            this.Other = Other;
        }
        public CustomerDTO (DataRow row)
        {
            this.CustomerCode = row["CustomerCode"].ToString();
            this.CustomerName = row["CustomerName"].ToString();
            this.Address = row["Address"].ToString();
            this.Phone = row["Phone"].ToString();
            this.WarnPOInput = (int)row["WarnPOInput"];
            this.WarnPOFix = (int)row["WarnPOFix"];
            this.Other = (int)row["Other"];
        }
        private string customerCode;
        private string customerName;
        private string address;
        private string phone;
        private int warnPOInput;
        private int warnPOFix;
        private int other;

        public string CustomerCode
        {
            get
            {
                return customerCode;
            }

            set
            {
                customerCode = value;
            }
        }

        public string CustomerName
        {
            get
            {
                return customerName;
            }

            set
            {
                customerName = value;
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

        public int WarnPOInput { get => warnPOInput; set => warnPOInput = value; }
        public int WarnPOFix { get => warnPOFix; set => warnPOFix = value; }
        public int Other { get => other; set => other = value; }
    }
}
