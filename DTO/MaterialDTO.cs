using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MaterialDTO
    {
        public MaterialDTO(string MaterialCode, string MaterialName, int CountYellow, int CountRed,string VenderCode,string Nature,string RohsFile,string ColorCode)
        {
            this.MaterialCode = MaterialCode;
            this.MaterialName = MaterialName;
            this.CountYellow = CountYellow;
            this.CountRed = CountRed;
            this.VenderCode = VenderCode;
            this.Nature = Nature;
            this.RohsFile = RohsFile;
            this.ColorCode = ColorCode;
        }
        public MaterialDTO(DataRow row)
        {
            this.MaterialCode = row["MaterialCode"].ToString();
            this.MaterialName = row["MaterialName"].ToString();
            this.CountYellow =(int) row["CountYellow"];
            this.CountRed = (int) row["CountRed"];
            this.VenderCode = row["VenderCode"].ToString();
            this.Nature = row["Nature"].ToString();
            this.RohsFile = row["RohsFile"].ToString();
            this.ColorCode = row["ColorCode"].ToString();
        }
        private string materialCode;
        private string materialName;
        private int countYellow;
        private int countRed;
        private string venderCode;
        private string nature;
        private string rohsFile;
        private string colorCode;
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

        public int CountYellow
        {
            get
            {
                return countYellow;
            }

            set
            {
                countYellow = value;
            }
        }

        public int CountRed
        {
            get
            {
                return countRed;
            }

            set
            {
                countRed = value;
            }
        }

        public string VenderCode
        {
            get
            {
                return venderCode;
            }

            set
            {
                venderCode = value;
            }
        }

        public string Nature
        {
            get
            {
                return nature;
            }

            set
            {
                nature = value;
            }
        }

        public string RohsFile
        {
            get
            {
                return rohsFile;
            }

            set
            {
                rohsFile = value;
            }
        }

        public string ColorCode { get => colorCode; set => colorCode = value; }
    }
}
