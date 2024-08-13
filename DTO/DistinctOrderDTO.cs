using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class DistinctOrderDTO
    {
        public DistinctOrderDTO(string OrderCode)
        {
            this.OrderCode = OrderCode;
        }
        public DistinctOrderDTO(DataRow row)
        {
            this.OrderCode = row["OrderCode"].ToString();
        }
        private string orderCode;

        public string OrderCode
        {
            get
            {
                return orderCode;
            }

            set
            {
                orderCode = value;
            }
        }
    }
}
