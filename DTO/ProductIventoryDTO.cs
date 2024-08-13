using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class ProductIventoryDTO
    {
        public ProductIventoryDTO(long Id, string ProductCode, string Name, DateTime DateInput, float CountInput, float Iventory, string Rohs)
        {
            this.Id = Id;
            this.ProductCode = ProductCode;
            this.Name = Name;
            this.DateInput = DateInput;
            this.CountInput = CountInput;
            this.Iventory = Iventory;
            this.Rohs = Rohs;
        }
        public ProductIventoryDTO(DataRow row)
        {
            this.Id = (long)row["Id"];
            this.ProductCode = row["ProductCode"].ToString();
            this.Name = row["Name"].ToString();
            this.DateInput = (DateTime)row["DateInput"];
            this.CountInput = (float)Convert.ToDouble(row["CountInput"].ToString());
            this.Iventory = (float)Convert.ToDouble(row["Iventory"].ToString());
            this.Rohs = row["Rohs"].ToString();
        }
        private long id;
        private string productCode;
        private string name;
        private DateTime dateInput;
        private float countInput;
        private float iventory;
        private string rohs;


        public long Id { get => id; set => id = value; }
        public string ProductCode { get => productCode; set => productCode = value; }
        public string Name { get => name; set => name = value; }
        public DateTime DateInput { get => dateInput; set => dateInput = value; }
        public float CountInput { get => countInput; set => countInput = value; }
        public float Iventory { get => iventory; set => iventory = value; }

        public string Rohs { get => rohs; set => rohs = value; }
    }
}
