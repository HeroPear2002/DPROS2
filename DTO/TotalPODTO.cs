using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class TotalPODTO
    {
        public TotalPODTO(string ProductCode, DateTime Date)
        {
            this.ProductCode = ProductCode;
            this.Date = Date;
        }
        public TotalPODTO(DataRow row)
        {
            this.ProductCode = row["ProductCode"].ToString();
            this.Date = (DateTime)row["Date"];
        }
        private string productCode;
        private DateTime date;

        public string ProductCode
        {
            get
            {
                return productCode;
            }

            set
            {
                productCode = value;
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
    }
}
