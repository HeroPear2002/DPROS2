using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class MaterialByDTO
    {
        public MaterialByDTO(long Id,string MaterialCode,string MaterialName,string ColorCode,DateTime DateBy,int QuantityBy,int QuantityOrder,string Note,string VenderCode)
        {
            this.Id = Id;
            this.MaterialCode = MaterialCode;
            this.MaterialName = MaterialName;
            this.ColorCode = ColorCode;
            this.DateBy = DateBy;
            this.QuantityBy = QuantityBy;
            this.QuantityOrder = QuantityOrder;
            this.Note = Note;
            this.VenderCode = VenderCode;
        }
        public MaterialByDTO(DataRow row)
        {
            this.Id = (long)row["Id"];
            this.MaterialCode = row["MaterialCode"].ToString();
            this.MaterialName = row["MaterialName"].ToString();
            this.ColorCode = row["ColorCode"].ToString();
            this.DateBy = (DateTime)row["DateBy"];
            this.QuantityBy = (int)row["QuantityBy"];
            this.QuantityOrder =(int)row["QuantityOrder"];
            this.Note = row["Note"].ToString();
            this.VenderCode = row["VenderCode"].ToString();
        }
        private long id;
        private string materialCode;
        private string materialName;
        private string colorCode;
        private DateTime dateBy;
        private int quantityBy;
        private int quantityOrder;
        private string note;
        private string venderCode;

        public string Note { get => note; set => note = value; }
        public int QuantityBy { get => quantityBy; set => quantityBy = value; }
        public DateTime DateBy { get => dateBy; set => dateBy = value; }
        public string ColorCode { get => colorCode; set => colorCode = value; }
        public string MaterialName { get => materialName; set => materialName = value; }
        public string MaterialCode { get => materialCode; set => materialCode = value; }
        public long Id { get => id; set => id = value; }
        public int QuantityOrder { get => quantityOrder; set => quantityOrder = value; }
        public string VenderCode { get => venderCode; set => venderCode = value; }
    }
}
