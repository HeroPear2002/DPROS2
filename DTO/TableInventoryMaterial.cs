using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class TableInventoryMaterial
    {
        public TableInventoryMaterial(string MaterialCode,string MaterialName,int QuantityInventory,string Note)
        {
            this.MaterialCode = MaterialCode;
            this.MaterialName = MaterialName;
            this.QuantityInventory = QuantityInventory;
            this.Note = Note;
        }
        public TableInventoryMaterial(DataRow row)
        {
            this.MaterialCode = row["MaterialCode"].ToString();
            this.MaterialName = row["MaterialName"].ToString();
            this.QuantityInventory = (int)row["QuantityInventory"];
            this.Note = row["Note"].ToString();
        }
        private string materialCode;
        private string materialName;
        private int quantityInventory;
        private string note;

        public string Note { get => note; set => note = value; }
        public int QuantityInventory { get => quantityInventory; set => quantityInventory = value; }
        public string MaterialName { get => materialName; set => materialName = value; }
        public string MaterialCode { get => materialCode; set => materialCode = value; }
    }
}
