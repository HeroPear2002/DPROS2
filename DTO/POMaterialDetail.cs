using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class POMaterialDetail
    {
        public POMaterialDetail(long Id,long IdPO,string MaterCode,string MaterialName, string ColorCode,long IdBy,int QuantityBy,string Price,string UnitPrice,int statusDetail)
        {
            this.Id = Id;
            this.IdPO = IdPO;
            this.MaterCode = MaterCode;
            this.MaterialName = MaterialName;
            this.ColorCode = ColorCode;
            this.IdBy = IdBy;
            this.QuantityBy = QuantityBy;
            this.Price = Price;
            this.UnitPrice = UnitPrice;
            this.StatusDetail = StatusDetail;
        }
        public POMaterialDetail(DataRow row)
        {
            this.Id = (long)row["Id"];
            this.IdPO = (long)row["IdPO"];
            this.MaterCode = row["MaterCode"].ToString();
            this.MaterialName = row["MaterialName"].ToString();
            this.ColorCode = row["ColorCode"].ToString();
            this.IdBy = (long)row["IdBy"];
            this.QuantityBy = (int)row["QuantityBy"];
            this.Price = row["Price"].ToString();
            this.UnitPrice = row["UnitPrice"].ToString();
            this.StatusDetail = (int)row["StatusDetail"];
        }
        private long id;
        private long idPO;
        private string materCode;
        private string materialName;
        private string colorCode;
        private long idBy;
        private int quantityBy;
        private string price;
        private string unitPrice;
        private int statusDetail;

        public int StatusDetail { get => statusDetail; set => statusDetail = value; }
        public string UnitPrice { get => unitPrice; set => unitPrice = value; }
        public string Price { get => price; set => price = value; }
        public int QuantityBy { get => quantityBy; set => quantityBy = value; }
        public long IdBy { get => idBy; set => idBy = value; }
        public string MaterCode { get => materCode; set => materCode = value; }
        public long IdPO { get => idPO; set => idPO = value; }
        public long Id { get => id; set => id = value; }
        public string ColorCode { get => colorCode; set => colorCode = value; }
        public string MaterialName { get => materialName; set => materialName = value; }
    }
}
