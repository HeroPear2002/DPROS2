using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class POFixDTO
    {
        public POFixDTO(long Id,long IdPOInput, string POCode,string PartCode,int Quantity,DateTime DateOut,string Note,int Status,DateTime? DateInput,string FactoryCustomer,string CarNumber,long? IdDe,string FactoryCode)
        {
            this.Id = Id;
            this.IdPOInput = IdPOInput;
            this.POCode = POCode;
            this.PartCode = PartCode;
            this.Quantity = Quantity;
            this.DateOut = DateOut;
            this.Note = Note;
            this.Status = Status;
            this.DateInput = DateInput;
            this.FactoryCustomer = FactoryCustomer;
            this.CarNumber = CarNumber;
            this.IdDe = IdDe;
            this.FactoryCode = FactoryCode;
        }
        public POFixDTO(DataRow row)
        {
            this.Id = (long)row["Id"];
            this.IdPOInput = (long)row["IdPOInput"];
            this.POCode = row["POCode"].ToString();
            this.PartCode = row["PartCode"].ToString();
            this.Quantity = (int)row["Quantity"];
            this.DateOut = (DateTime)row["DateOut"];
            this.Note = row["Note"].ToString();
            this.Status = (int)row["Status"];
            var checkNgayXuat = row["DateInput"];
            if (checkNgayXuat.ToString() != "")
                this.DateInput = (DateTime)checkNgayXuat;
            this.FactoryCustomer = row["FactoryCustomer"].ToString();
            this.CarNumber = row["CarNumber"].ToString();
            var checkId = row["IdDe"];
            if (checkId.ToString() != "")
                this.IdDe = long.Parse(checkId.ToString());
            this.FactoryCode = row["FactoryCode"].ToString();
        }
        private string pOCode;
        private string partCode;
        private int quantity;
        private DateTime dateOut;
        private string note;
        private int status;
        private DateTime? dateInput;
        private long id;
        private long idPOInput;
        private string factoryCustomer;
        private string carNumber;
        private long? idDe;
        private string factoryCode;

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

        public int Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                quantity = value;
            }
        }

        public DateTime DateOut
        {
            get
            {
                return dateOut;
            }

            set
            {
                dateOut = value;
            }
        }

        public string Note
        {
            get
            {
                return note;
            }

            set
            {
                note = value;
            }
        }

        public int Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public DateTime? DateInput { get => dateInput; set => dateInput = value; }
        public long Id { get => id; set => id = value; }
        public long IdPOInput { get => idPOInput; set => idPOInput = value; }
        public string FactoryCustomer { get => factoryCustomer; set => factoryCustomer = value; }
        public string CarNumber { get => carNumber; set => carNumber = value; }
        public long? IdDe { get => idDe; set => idDe = value; }
        public string FactoryCode { get => factoryCode; set => factoryCode = value; }
    }
}
