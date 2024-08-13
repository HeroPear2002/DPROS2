using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class ReceiptSlipDTO
    {
        public ReceiptSlipDTO(long Id,long IdDetail,string ReceiptCode, string MaterCode,
            string MaterialName,int QuantityPlan, DateTime DatePrinter,string Employess,string Note)
        {
            this.Id = Id;
            this.IdDetail = IdDetail;
            this.ReceiptCode = ReceiptCode;
            this.MaterCode = MaterCode;
            this.MaterialName = MaterialName;
            this.QuantityPlan = QuantityPlan;
            this.DatePrinter = DatePrinter;
            this.Employess = Employess;
            this.Note = Note;
        }
        public ReceiptSlipDTO(DataRow row)
        {
            this.Id = (long)row["Id"];
            this.IdDetail = (long)row["IdDetail"];
            this.ReceiptCode = row["ReceiptCode"].ToString();
            this.MaterCode = row["MaterCode"].ToString();
            this.MaterialName = row["MaterialName"].ToString();
            this.QuantityPlan = (int)row["QuantityPlan"];
            this.DatePrinter = (DateTime)row["DatePrinter"];
            this.Employess = row["Employess"].ToString();
            this.Note = row["Note"].ToString();
        }
        private long id;
        private long idDetail;
        private string receiptCode;
        private string materCode;
        private string materialName;
        private DateTime datePrinter;
        private string employess;
        private string note;
        private int quantityPlan;

        public long Id { get => id; set => id = value; }
        public long IdDetail { get => idDetail; set => idDetail = value; }
        public string ReceiptCode { get => receiptCode; set => receiptCode = value; }
    
        public string MaterialName { get => materialName; set => materialName = value; }
        public DateTime DatePrinter { get => datePrinter; set => datePrinter = value; }
        public string Employess { get => employess; set => employess = value; }
        public string Note { get => note; set => note = value; }
        public string MaterCode { get => materCode; set => materCode = value; }
        public int QuantityPlan { get => quantityPlan; set => quantityPlan = value; }
    }
}
