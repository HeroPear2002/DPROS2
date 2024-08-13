using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CheckDeliveryDTO
    {
        public CheckDeliveryDTO(long Id,string CheckCode,long IdDe,string Employess,string PartCode,int QuantityCheck,int QuantityOut,string FactoryCode,string Note,int StatusCheck,string POCode)
        {
            this.Id = Id;
            this.CheckCode = CheckCode;
            this.IdDe = IdDe;
            this.Employess = Employess;
            this.PartCode = PartCode;
            this.QuantityCheck = QuantityCheck;
            this.QuantityOut = QuantityOut;
            this.FactoryCode = FactoryCode;
            this.Note = Note;
            this.StatusCheck = StatusCheck;
            this.POCode = POCode;
        }
        public CheckDeliveryDTO(DataRow row)
        {
            this.Id = (long)row["Id"];
            this.CheckCode = row["CheckCode"].ToString();
            this.IdDe = (long)row["IdDe"];
            this.Employess = row["Employess"].ToString();
            this.PartCode = row["PartCode"].ToString();
            this.QuantityCheck = (int)row["QuantityCheck"];
            this.QuantityOut = (int)row["QuantityOut"];
            this.FactoryCode = row["FactoryCode"].ToString();
            this.Note = row["Note"].ToString();
            this.StatusCheck = (int)row["StatusCheck"];
            this.POCode = row["POCode"].ToString();
        }
        private long id;
        private string checkCode;
        private long idDe;
        private string employess;
        private string partCode;
        private int quantityCheck;
        private int quantityOut;
        private string factoryCode;
        private string note;
        private int statusCheck;
        private string pOCode;

        public long Id { get => id; set => id = value; }
        public string CheckCode { get => checkCode; set => checkCode = value; }
        public long IdDe { get => idDe; set => idDe = value; }
        public string Employess { get => employess; set => employess = value; }
        public string PartCode { get => partCode; set => partCode = value; }
        public int QuantityCheck { get => quantityCheck; set => quantityCheck = value; }
        public int QuantityOut { get => quantityOut; set => quantityOut = value; }
        public string FactoryCode { get => factoryCode; set => factoryCode = value; }
        public string Note { get => note; set => note = value; }
        public int StatusCheck { get => statusCheck; set => statusCheck = value; }
        public string POCode { get => pOCode; set => pOCode = value; }
    }
}
