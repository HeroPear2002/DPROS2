using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class MaterialPriceDTO
    {
        public MaterialPriceDTO(long Id,string MaterialCode,string MaterialName,DateTime DateInput,Decimal PriceVND,string PriceUSD,int StatusPrice,string VenderCode, string Note)
        {
            this.Id = Id;
            this.MaterialCode = MaterialCode;
            this.MaterialName = MaterialName;
            this.DateInput = DateInput;
            this.PriceVND = PriceVND;
            this.PriceUSD = PriceUSD;
            this.StatusPrice = StatusPrice;
            this.VenderCode = VenderCode;
            this.Note = Note;
        }
        public MaterialPriceDTO(DataRow row)
        {
            this.Id = (long)row["Id"];
            this.MaterialCode = row["MaterialCode"].ToString();
            this.MaterialName = row["MaterialName"].ToString();
            this.DateInput = (DateTime)row["DateInput"];
            this.PriceVND = (decimal)row["PriceVND"];
            this.PriceUSD = row["PriceUSD"].ToString();
            this.StatusPrice = (int)row["StatusPrice"];
            this.VenderCode = row["VenderCode"].ToString();
            this.Note = row["Note"].ToString();
        }
        private long id;
        private DateTime dateInput;
        private string materialCode;
        private Decimal priceVND;
        private string priceUSD;
        private int statusPrice;
        private string note;
        private string venderCode;
        private string materialName;

        public long Id { get => id; set => id = value; }
        public DateTime DateInput { get => dateInput; set => dateInput = value; }
        public string MaterialCode { get => materialCode; set => materialCode = value; }
        public decimal PriceVND { get => priceVND; set => priceVND = value; }
        public string PriceUSD { get => priceUSD; set => priceUSD = value; }
        public int StatusPrice { get => statusPrice; set => statusPrice = value; }
        public string Note { get => note; set => note = value; }
        public string MaterialName { get => materialName; set => materialName = value; }
        public string VenderCode { get => venderCode; set => venderCode = value; }
    }
}
