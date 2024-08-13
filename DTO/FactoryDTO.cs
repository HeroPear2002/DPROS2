using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class FactoryDTO
    {
        public FactoryDTO(int Id,string FactoryCode,string FactoryName,string CodeCustomer,string NameCustomer,string NameBillVN,string NameBillENG,string Address,string Phone,string FaxNumber,string MST)
        {
            this.Id = Id;
            this.FactoryCode = FactoryCode;
            this.FactoryName = FactoryName;
            this.FactoryCode = FactoryCode;
            this.CodeCustomer = CodeCustomer;
            this.NameCustomer = NameCustomer;
            this.NameBillVN = NameBillVN;
            this.NameBillENG = NameBillENG;
            this.Address = Address;
            this.Phone = Phone;
            this.FaxNumber = FaxNumber;
            this.MST = MST;
        }
        public FactoryDTO(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.FactoryCode = row["FactoryCode"].ToString();
            this.FactoryName = row["FactoryName"].ToString();
            this.FactoryCode = row["FactoryCode"].ToString();
            this.CodeCustomer = row["CodeCustomer"].ToString();
            this.NameCustomer = row["NameCustomer"].ToString();
            this.NameBillVN = row["NameBillVN"].ToString();
            this.NameBillENG = row["NameBillENG"].ToString();
            this.Address = row["Address"].ToString();
            this.Phone = row["Phone"].ToString();
            this.FaxNumber = row["FaxNumber"].ToString();
            this.MST = row["MST"].ToString();
        }
        private int id;
        private string factoryCode;
        private string factoryName;
        private string codeCustomer;
        private string nameCustomer;
        private string nameBillVN;
        private string nameBillENG;
        private string address;
        private string phone;
        private string faxNumber;
        private string mST;

        public int Id { get => id; set => id = value; }
        public string FactoryCode { get => factoryCode; set => factoryCode = value; }
        public string FactoryName { get => factoryName; set => factoryName = value; }
        public string CodeCustomer { get => codeCustomer; set => codeCustomer = value; }
        public string NameCustomer { get => nameCustomer; set => nameCustomer = value; }
        public string NameBillVN { get => nameBillVN; set => nameBillVN = value; }
        public string NameBillENG { get => nameBillENG; set => nameBillENG = value; }
        public string Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }
        public string FaxNumber { get => faxNumber; set => faxNumber = value; }
        public string MST { get => mST; set => mST = value; }
    }
}
