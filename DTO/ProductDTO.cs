using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class ProductDTO
    {
        public ProductDTO(string Code, string Name, float CountConstan, string Note, string Vendor, string Rohs)
        {
            this.Code = Code;
            this.Name = Name;
            this.CountConstan = CountConstan;
            this.Note = Note;
            this.Vendor = Vendor;
            this.Rohs = Rohs;
        }
        public ProductDTO(DataRow row)
        {
            this.Code = row["Code"].ToString();
            this.Name = row["Name"].ToString();
            this.CountConstan = (float)Convert.ToDouble(row["CountConstan"].ToString());
            this.Note = row["Note"].ToString();
            this.Vendor = row["Vendor"].ToString();
            this.Rohs = row["Rohs"].ToString();
        }
        private string code;
        private string name;
        private float countConstan;
        private string note;
        private string vendor;
        private string rohs;

        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public float CountConstan { get => countConstan; set => countConstan = value; }
        public string Note { get => note; set => note = value; }
        public string Vendor { get => vendor; set => vendor = value; }
        public string Rohs { get => rohs; set => rohs = value; }
    }
}
