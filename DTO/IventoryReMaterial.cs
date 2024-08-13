using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class IventoryReMaterial
    {
        public IventoryReMaterial(long Id,long IdInput,string MaterialCode, string MaterialName, float CountXuat,float Quantity, DateTime DateReInput)
        {
            this.Id = Id;
            this.IdInput = IdInput;
            this.MaterialCode = MaterialCode;
            this.MaterialName = MaterialName;
            this.CountXuat = countXuat;
            this.Quantity = Quantity;
            this.DateReInput = DateReInput;
        }
        public IventoryReMaterial(DataRow row)
        {
            this.Id = (long)row["Id"];
            this.IdInput = (long)row["IdInput"];
            this.MaterialCode = row["MaterialCode"].ToString();
            this.MaterialName = row["MaterialName"].ToString();
            this.CountXuat = (float)Convert.ToDouble(row["countXuat"].ToString());
            this.Quantity = (float)Convert.ToDouble(row["Quantity"].ToString());
            this.DateReInput = (DateTime)row["DateReInput"];
        }
        private long id;
        private long idInput;
        private string materialCode;
        private string materialName;
        private float countXuat;
        private float quantity;
        private DateTime dateReInput;

        public long Id { get => id; set => id = value; }
        public long IdInput { get => idInput; set => idInput = value; }
        public string MaterialCode { get => materialCode; set => materialCode = value; }
        public string MaterialName { get => materialName; set => materialName = value; }
        public float CountXuat { get => countXuat; set => countXuat = value; }
        public float Quantity { get => quantity; set => quantity = value; }
        public DateTime DateReInput { get => dateReInput; set => dateReInput = value; }
    }
}
