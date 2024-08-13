using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class IventoryMaterialDTO
    {
        public IventoryMaterialDTO(long Id,long IdWH,string MaterialCode,DateTime DateInput, string MaterialName, float QuantityInput,string Name,string StyleInput, string Lot,string Rosh)
        {
            this.Id = Id;
            this.IdWH = IdWH;
            this.MaterialCode = MaterialCode;
            this.MaterialName = MaterialName;
            this.DateInput = DateInput;
            this.QuantityInput = QuantityInput;
            this.Name = Name;
            this.Lot = Lot;
            this.Rosh = Rosh;
            this.StyleInput = StyleInput;
        }
        public IventoryMaterialDTO(DataRow row)
        {
            this.Id = (long)row["Id"];
            this.IdWH = (long)row["IdWH"];
            this.MaterialCode = row["MaterialCode"].ToString();
            this.MaterialName = row["MaterialName"].ToString();
            this.DateInput = (DateTime)row["DateInput"];
            this.QuantityInput = (float)Convert.ToDouble(row["QuantityInput"].ToString());
            this.Name = row["Name"].ToString();
            this.Lot = row["Lot"].ToString();
            this.StyleInput = row["StyleInput"].ToString();
            this.Rosh = row["Rosh"].ToString();
        }
        private long id;
        private long idWH;
        private string materialCode;
        private DateTime dateInput;
        private string materialName;
        private float quantityInput;
        private string styleInput;
        private string name;
        private string lot;
        private string rosh;

        public long Id
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

        public long IdWH
        {
            get
            {
                return idWH;
            }

            set
            {
                idWH = value;
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

        public DateTime DateInput
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

        public float QuantityInput
        {
            get
            {
                return quantityInput;
            }

            set
            {
                quantityInput = value;
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

        public string Lot
        {
            get
            {
                return lot;
            }

            set
            {
                lot = value;
            }
        }

        public string Rosh
        {
            get
            {
                return rosh;
            }

            set
            {
                rosh = value;
            }
        }

        public string StyleInput { get => styleInput; set => styleInput = value; }
    }
}
