using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ReIventoryMaterialHH
    {
        public ReIventoryMaterialHH(long Id, long IdInput, string MaterialCode, string MaterialName, float QuantityInputHH, DateTime DateInputHH)
        {
            this.Id = Id;
            this.IdInput = IdInput;
            this.MaterialCode = MaterialCode;
            this.MaterialName = MaterialName;
            this.QuantityInputHH = QuantityInputHH;
            this.DateInputHH = DateInputHH;
        }
        public ReIventoryMaterialHH(DataRow row)
        {
            this.Id = (long)row["Id"];
            this.IdInput = (long)row["IdInput"];
            this.MaterialCode = row["MaterialCode"].ToString();
            this.MaterialName = row["MaterialName"].ToString();
            this.QuantityInputHH = (float)Convert.ToDouble(row["QuantityInputHH"].ToString());
            this.DateInputHH = (DateTime)row["DateInputHH"];
        }
        private long id;
        private long idInput;
        private string materialCode;
        private string materialName;
        private float quantityInputHH;
        private DateTime dateInputHH;

        public long Id { get => id; set => id = value; }
        public long IdInput { get => idInput; set => idInput = value; }
        public string MaterialCode { get => materialCode; set => materialCode = value; }
        public string MaterialName { get => materialName; set => materialName = value; }
        public float QuantityInputHH { get => quantityInputHH; set => quantityInputHH = value; }
        public DateTime DateInputHH { get => dateInputHH; set => dateInputHH = value; }
    }
}
