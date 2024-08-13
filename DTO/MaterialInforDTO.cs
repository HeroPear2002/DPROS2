using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class MaterialInforDTO
    {
        public MaterialInforDTO(int Id,string MaterialInfor,string MaterialCode, float Count)
        {
            this.Id = Id;
            this.MaterialInfor = MaterialInfor;
            this.MaterialCode = MaterialCode;
            this.Count = Count;
        }
        public MaterialInforDTO(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.MaterialInfor = row["MaterialInfor"].ToString();
            this.MaterialCode = row["MaterialCode"].ToString();
            this.Count = (float)Convert.ToDouble(row["Count"].ToString());
        }
        private int id;
        private string materialInfor;
        private string materialCode;
        private float count;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string MaterialInfor
        {
            get
            {
                return materialInfor;
            }

            set
            {
                materialInfor = value;
            }
        }

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

        public float Count
        {
            get
            {
                return count;
            }

            set
            {
                count = value;
            }
        }
    }
}
