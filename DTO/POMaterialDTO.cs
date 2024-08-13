using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class POMaterialDTO
    {
        public POMaterialDTO(long Id,string POCode,DateTime DateCreate,string EmployessCreate,string Location,string Payment,DateTime DateInput,string Declaction,string Bill,int StatusPO, string SupplierCode,DateTime DatePO)
        {
            this.Id = Id;
            this.POCode = POCode;
            this.DateCreate = DateCreate;
            this.EmployessCreate = EmployessCreate;
            this.Location = Location;
            this.Payment = Payment;
            this.DateInput = DateInput;
            this.Declaration = Declaration;
            this.Bill = Bill;
            this.StatusPO = StatusPO;
            this.SupplierCode = SupplierCode;
            this.DatePO = DatePO;
        }
        public POMaterialDTO(DataRow row)
        {
            this.Id = (long)row["Id"];
            this.POCode = row["POCode"].ToString();
            this.DateCreate = (DateTime)row["DateCreate"];
            this.EmployessCreate = row["EmployessCreate"].ToString();
            this.Location = row["Location"].ToString();
            this.Payment = row["Payment"].ToString();
            this.DateInput = (DateTime)row["DateInput"];
            this.Declaration = row["Declaration"].ToString();
            this.Bill = row["Bill"].ToString();
            this.StatusPO = (int)row["StatusPO"];
            this.SupplierCode = row["SupplierCode"].ToString();
            this.DatePO = (DateTime)row["DatePO"];
        }
        private long id;
        private string pOCode;
        private DateTime dateCreate;
        private string employessCreate;
        private string location;
        private string payment;
        private DateTime dateInput;
        private string declaration;
        private string bill;
        private int statusPO;
        private string supplierCode;
        private DateTime datePO;

        public string SupplierCode { get => supplierCode; set => supplierCode = value; }
        public int StatusPO { get => statusPO; set => statusPO = value; }
        public string Bill { get => bill; set => bill = value; }
        public string Declaration { get => declaration; set => declaration = value; }
        public DateTime DateInput { get => dateInput; set => dateInput = value; }
        public string Payment { get => payment; set => payment = value; }
        public string Location { get => location; set => location = value; }
        public string EmployessCreate { get => employessCreate; set => employessCreate = value; }
        public DateTime DateCreate { get => dateCreate; set => dateCreate = value; }
        public string POCode { get => pOCode; set => pOCode = value; }
        public long Id { get => id; set => id = value; }
        public DateTime DatePO { get => datePO; set => datePO = value; }
    }
}
