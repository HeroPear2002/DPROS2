using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class OutputWarnProduct
    {
        public OutputWarnProduct(long Id,string ProductCode,DateTime DateOutput,string Employess,float CountOut,string Detail,string Note)
        {
            this.id = Id;
            this.ProductCode = ProductCode;
            this.DateOutput = DateOutput;
            this.Employess = Employess;
            this.CountOut = CountOut;
            this.Detail = Detail;
            this.Note = Note;
        }
        public OutputWarnProduct(DataRow row)
        {
            this.id = (long)row["Id"];
            this.ProductCode = row["ProductCode"].ToString();
            this.DateOutput = (DateTime)row["DateOutput"];
            this.Employess = row["Employess"].ToString();
            this.CountOut = (float)Convert.ToDouble(row["CountOut"].ToString());
            this.Detail = row["Detail"].ToString();
            this.Note = row["Note"].ToString();
        }
        private long id;
        private string productCode;
        private DateTime dateOutput;
        private string employess;
        private float countOut;
        private string detail;
        private string note;

        public long Id { get => id; set => id = value; }
        public string ProductCode { get => productCode; set => productCode = value; }
        public DateTime DateOutput { get => dateOutput; set => dateOutput = value; }
        public string Employess { get => employess; set => employess = value; }
        public float CountOut { get => countOut; set => countOut = value; }
        public string Detail { get => detail; set => detail = value; }
        public string Note { get => note; set => note = value; }
    }
}
