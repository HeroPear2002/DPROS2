using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class POCodeDTO
    {
        public POCodeDTO(string POCode,string PartCode, string PartName,string BarCode)
        {
            this.POCode = POCode;
            this.PartCode = PartCode;
            this.PartName = PartName;
            this.BarCode = BarCode;
        }
        public POCodeDTO(DataRow row)
        {
            this.POCode = row["POCode"].ToString();
            this.PartCode = row["PartCode"].ToString();
            this.PartName = row["PartName"].ToString();
            this.BarCode = row["BarCode"].ToString();
        }
        private string pOCode;
        private string partCode;
        private string partName;
        private string barCode;
      

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

        public string PartName
        {
            get
            {
                return partName;
            }

            set
            {
                partName = value;
            }
        }

        public string BarCode
        {
            get
            {
                return barCode;
            }

            set
            {
                barCode = value;
            }
        }
    }
}
