using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class OnlyDate
    {
        public OnlyDate(DateTime? DateMax)
        {
            this.DateMax = DateMax;
        }
        public OnlyDate(DataRow row)
        {
            var checkNgay = row["DateMax"];
            if (checkNgay.ToString() != "")
                this.DateMax = (DateTime)checkNgay;

        }
        private DateTime? dateMax;


        public DateTime? DateMax
        {
            get
            {
                return dateMax;
            }

            set
            {
                dateMax = value;
            }
        }
    }
}
