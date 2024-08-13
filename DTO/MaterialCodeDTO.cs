using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class MaterialCodeDTO
    {
        public MaterialCodeDTO(string MaterialCode,string MaterialName)
        {
            this.MaterialCode = MaterialCode;
            this.MaterialName = MaterialName;
        }
        public MaterialCodeDTO(DataRow row)
        {
            this.MaterialCode = row["MaterialCode"].ToString();
            this.MaterialName = row["MaterialName"].ToString();
        }
        private string materialCode;
        private string materialName;

        public string MaterialCode
        {
            get
            {
                return materialCode;
            }

            set
            {
                materialCode = value;
            }
        }

        public string MaterialName
        {
            get
            {
                return materialName;
            }

            set
            {
                materialName = value;
            }
        }
    }
}
