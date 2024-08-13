using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class FixPODTO
    {
        public FixPODTO(string PartCode,DateTime Date,int CountOutput)
        {
            this.PartCode = PartCode;
            this.Date = Date;
            this.CountOutput = CountOutput;
        }
        public FixPODTO(DataRow row)
        {
            this.PartCode = row["PartCode"].ToString();
            this.Date = (DateTime)row["Date"];
            this.CountOutput = (int)row["CountOutput"];
        }
        private string partCode;
        private DateTime date;
        private int countOutput;

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

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        public int CountOutput
        {
            get
            {
                return countOutput;
            }

            set
            {
                countOutput = value;
            }
        }
    }
}
