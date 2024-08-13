using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class PartCodeDTO
    {
        public PartCodeDTO(string PartCode)
        {
            this.PartCode = PartCode;
        }
        public PartCodeDTO(DataRow row)
        {
            this.PartCode = row["PartCode"].ToString();
        }
        private string partCode;

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
    }
}
