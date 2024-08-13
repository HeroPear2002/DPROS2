using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class MoldImportantDTO
    {
        public MoldImportantDTO(string MoldCode,int Important)
        {
            this.MoldCode = MoldCode;
            this.Important = Important;
        }
        public MoldImportantDTO(DataRow row)
        {
            this.MoldCode = row["MoldCode"].ToString();
            this.Important = (int)row["Important"];
        }
        private string moldCode;
        private int important;

        public string MoldCode
        {
            get
            {
                return moldCode;
            }

            set
            {
                moldCode = value;
            }
        }

        public int Important
        {
            get
            {
                return important;
            }

            set
            {
                important = value;
            }
        }
    }
}
