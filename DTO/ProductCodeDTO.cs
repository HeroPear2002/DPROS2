using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProductCodeDTO
    {

        public ProductCodeDTO(string ProductCode, string Name)
        {
            this.ProductCode = ProductCode;
            this.Name = Name;
        }
        public ProductCodeDTO(DataRow row)
        {
            this.ProductCode = row["ProductCode"].ToString();
            this.Name = row["Name"].ToString();
        }
        private string productCode;
        private string name;

        public string ProductCode { get => productCode; set => productCode = value; }
        public string Name { get => name; set => name = value; }
    }
}

