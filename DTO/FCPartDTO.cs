using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class FCPartDTO
    {
        public FCPartDTO(long Id,string PartCode,int Quantity,DateTime DateFCPart,string Employess)
        {
            this.Id = Id;
            this.PartCode = PartCode;
            this.Quantity = Quantity;
            this.DateFCPart = DateFCPart;
            this.Employess = Employess;
        }
        public FCPartDTO(DataRow row)
        {
            this.Id = (long)row["Id"];
            this.PartCode = row["PartCode"].ToString();
            this.Quantity = (int)row["Quantity"];
            this.DateFCPart = (DateTime)row["DateFCPart"];
            this.Employess = row["Employess"].ToString();
        }
        private long id;
        private string partCode;
        private int quantity;
        private DateTime dateFCPart;
        private string employess;

        public long Id { get => id; set => id = value; }
        public string PartCode { get => partCode; set => partCode = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public DateTime DateFCPart { get => dateFCPart; set => dateFCPart = value; }
        public string Employess { get => employess; set => employess = value; }
    }
}
