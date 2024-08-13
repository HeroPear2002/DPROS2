using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChartCategoryDTO
    {
        public ChartCategoryDTO(long Id, float DataCount, DateTime DateCheck, string NameCategory, string Detail, string Limit, long IdCategory)
        {
            this.Id = Id;
            this.DataCount = DataCount;
            this.DateCheck = DateCheck;
            this.NameCategory = NameCategory;
            this.Detail = Detail;
            this.Limit = Limit;
            this.IdCategory = IdCategory;
        }
        public ChartCategoryDTO(DataRow row)
        {
            this.Id = (long)row["Id"];
            this.DataCount = (float)Convert.ToDouble(row["DataCount"]);
            this.DateCheck = (DateTime)row["DateCheck"];
            this.NameCategory = row["NameCategory"].ToString();
            this.Detail = row["Detail"].ToString();
            this.Limit = row["Limit"].ToString();
            this.IdCategory = (long)row["IdCategory"];
        }
        private long id;
        private float dataCount;
        private DateTime dateCheck;
        private string nameCategory;
        private string detail;
        private string limit;
        private long idCategory;

        public long Id { get => id; set => id = value; }
        public float DataCount { get => dataCount; set => dataCount = value; }
        public DateTime DateCheck { get => dateCheck; set => dateCheck = value; }
        public string NameCategory { get => nameCategory; set => nameCategory = value; }
        public string Detail { get => detail; set => detail = value; }
        public string Limit { get => limit; set => limit = value; }
        public long IdCategory { get => idCategory; set => idCategory = value; }
    }
}
