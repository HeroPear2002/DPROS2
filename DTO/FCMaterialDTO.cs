using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class FCMaterialDTO
    {
        public FCMaterialDTO(long Id,string MaterialCode,string MaterialName,int Quantity,DateTime DateFC)
        {
            this.Id = Id;
            this.MaterialCode = MaterialCode;
            this.MaterialName = MaterialName;
            this.Quantity = Quantity;
            this.DateFC = DateFC;
        }
        public FCMaterialDTO(DataRow row)
        {
            this.Id = (long)row["Id"];
            this.MaterialCode = row["MaterialCode"].ToString();
            this.MaterialName = row["MaterialName"].ToString();
            this.Quantity = (int)row["Quantity"];
            this.DateFC = (DateTime)row["DateFC"];
        }
        private long id;
        private string materialCode;
        private string materialName;
        private int quantity;
        private DateTime dateFC;

        public long Id { get => id; set => id = value; }
        public string MaterialCode { get => materialCode; set => materialCode = value; }
        public string MaterialName { get => materialName; set => materialName = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public DateTime DateFC { get => dateFC; set => dateFC = value; }
    }
}
