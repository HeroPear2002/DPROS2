using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ReIventoryMaterial
    {
        public ReIventoryMaterial(long Id, long IdInput, string MaterialCode, string MaterialName, float Quantity)
        {
            this.Id = Id;
            this.IdInput = IdInput;
            this.MaterialCode = MaterialCode;
            this.MaterialName = MaterialName;
            this.Quantity = Quantity;
        }
        public ReIventoryMaterial(DataRow row)
        {
            this.Id = (long)row["Id"];
            this.IdInput = (long)row["IdInput"];
            this.MaterialCode = row["MaterialCode"].ToString();
            this.MaterialName = row["MaterialName"].ToString();
            this.Quantity = (float)Convert.ToDouble(row["Quantity"].ToString());
        }
        private long id;
        private long idInput;
        private string materialCode;
        private string materialName;
        private float quantity;

        public long Id { get => id; set => id = value; }
        public string MaterialCode { get => materialCode; set => materialCode = value; }
        public string MaterialName { get => materialName; set => materialName = value; }
        public float Quantity { get => quantity; set => quantity = value; }
        public long IdInput { get => idInput; set => idInput = value; }
    }
}
