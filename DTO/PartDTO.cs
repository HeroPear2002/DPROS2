using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PartDTO
    {
        public PartDTO(string PartCode, string PartName, string MaterialCode, string MaterialName, string CustomerCode, int CountBox, int CountPart, float WeightRunner, float WeightPart, float CycleTime, int Cavity, int Height, float Note, string NameVN)
        {
            this.PartCode = PartCode;
            this.PartName = PartName;
            this.MaterialCode = MaterialCode;
            this.MaterialName = MaterialName;
            this.CustomerCode = CustomerCode;
            this.CountBox = CountBox;
            this.CountPart = CountPart;
            this.WeightRunner = WeightRunner;
            this.WeightPart = WeightPart;
            this.CycleTime = CycleTime;
            this.Cavity = Cavity;
            this.Height = Height;
            this.Note = Note;
            this.NameVN = NameVN;
        }
        public PartDTO(DataRow row)
        {
            this.PartCode = row["PartCode"].ToString();
            this.PartName = row["PartName"].ToString();
            this.MaterialCode = row["MaterialCode"].ToString();
            this.MaterialName = row["MaterialName"].ToString();
            this.CustomerCode = row["CustomerCode"].ToString();
            this.CountBox = (int)row["CountBox"];
            this.CountPart = (int)row["CountPart"];
            this.WeightRunner = (float)Convert.ToDouble(row["WeightRunner"].ToString());
            this.WeightPart = (float)Convert.ToDouble(row["WeightPart"].ToString());
            this.CycleTime = (float)Convert.ToDouble(row["CycleTime"].ToString());
            this.Cavity = (int)row["Cavity"];
            this.Height = (int)row["Height"];
            this.Note = (float)Convert.ToDouble(row["Note"].ToString());
            this.NameVN = row["NameVN"].ToString();
        }
        private string partCode;
        private string partName;
        private string materialCode;
        private string materialName;
        private string customerCode;
        private int countBox;
        private int countPart;
        private float weightRunner;
        private float weightPart;
        private float cycleTime;
        private int cavity;
        private int height;
        private float note;
        private string nameVN;
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

        public string CustomerCode
        {
            get
            {
                return customerCode;
            }

            set
            {
                customerCode = value;
            }
        }

        public int CountBox
        {
            get
            {
                return countBox;
            }

            set
            {
                countBox = value;
            }
        }

        public int CountPart
        {
            get
            {
                return countPart;
            }

            set
            {
                countPart = value;
            }
        }

        public float WeightPart
        {
            get
            {
                return weightPart;
            }

            set
            {
                weightPart = value;
            }
        }

        public float CycleTime
        {
            get
            {
                return cycleTime;
            }

            set
            {
                cycleTime = value;
            }
        }

        public int Cavity
        {
            get
            {
                return cavity;
            }

            set
            {
                cavity = value;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }

            set
            {
                height = value;
            }
        }

        public float WeightRunner
        {
            get
            {
                return weightRunner;
            }

            set
            {
                weightRunner = value;
            }
        }

        public float Note
        {
            get
            {
                return note;
            }

            set
            {
                note = value;
            }
        }

        public string NameVN { get => nameVN; set => nameVN = value; }
    }
}
