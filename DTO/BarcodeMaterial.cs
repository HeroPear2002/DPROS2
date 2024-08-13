using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BarcodeMaterial
    {
        public BarcodeMaterial(string MaterialCode, string MaterialName, float Count, string Name,string DateInput,string Employess,string Nature)
        {
            this.MaterialCode = MaterialCode;
            this.MaterialName = MaterialName;
            this.Count = Count;
            this.Name = Name;
            this.DateInput = DateInput;
            this.Employess = Employess;
            this.Nature = Nature;
        }
        public BarcodeMaterial(DataRow row)
        {
            this.MaterialCode = row["MaterialCode"].ToString();
            this.MaterialName = row["MaterialName"].ToString();
            this.Count = (float)Convert.ToDouble(row["Count"].ToString());
            this.Name = row["Name"].ToString(); 
            this.DateInput = row["DateInput"].ToString(); 
            this.Employess = row["Employess"].ToString();
            this.Nature = row["Nature"].ToString();
        }
        private string materialCode;
        private string materialName;
        private float count;
        private string name;
        private string dateInput;
        private string employess;
        private string nature;

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
        public string DateInput
        {
            get
            {
                return dateInput;
            }

            set
            {
                dateInput = value;
            }
        }

        public string Employess
        {
            get
            {
                return employess;
            }

            set
            {
                employess = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
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
    }
}
