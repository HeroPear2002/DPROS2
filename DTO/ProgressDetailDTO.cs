using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProgressDetailDTO
    {
        public ProgressDetailDTO(long Id,long IdDetail,string MaterCode, string MaterialName,string ColorCode,int QuantityPlan,DateTime? DatePlan,int QuantityReality,DateTime? DateReality, string Employess,long IdPO,int StatusProDetail)
        {
            this.Id = Id;
            this.IdDetail = IdDetail;
            this.MaterCode = MaterCode;
            this.MaterialName = MaterialName;
            this.ColorCode = ColorCode;
            this.QuantityPlan = QuantityPlan;
            this.DatePlan = DatePlan;
            this.QuantityReality = QuantityReality;
            this.DateReality = DateReality;
            this.Employess = Employess;
            this.IdPO = IdPO;
            this.StatusProDetail = StatusProDetail;
        }
        public ProgressDetailDTO(DataRow row)
        {
            this.Id = (long)row["Id"];
            this.IdDetail = (long)row["IdDetail"];
            this.MaterCode = row["MaterCode"].ToString();
            this.MaterialName = row["MaterialName"].ToString();
            this.ColorCode = row["ColorCode"].ToString();
            this.QuantityPlan = (int)row["QuantityPlan"];
            var checkDatePlan = row["DatePlan"];
            if(checkDatePlan.ToString() != "")
                this.DatePlan = (DateTime)checkDatePlan;
            this.QuantityReality = (int)row["QuantityReality"];
            var checkDateReal = row["DateReality"];
            if(checkDateReal.ToString() != "")
            this.DateReality = (DateTime)checkDateReal;
            this.Employess = row["Employess"].ToString();
            this.IdPO = (long)row["IdPO"];
            this.StatusProDetail = (int)row["StatusProDetail"];
        }
        private long id;
        private long idDetail;
        private string materCode;
        private string materialName;
        private string colorCode;
        private int quantityPlan;
        private DateTime? datePlan;
        private int quantityReality;
        private DateTime? dateReality;
        private string employess;
        private long idPO;
        private int statusProDetail;

        public long Id { get => id; set => id = value; }
        public long IdDetail { get => idDetail; set => idDetail = value; }
        public int QuantityPlan { get => quantityPlan; set => quantityPlan = value; }
        public DateTime? DatePlan { get => datePlan; set => datePlan = value; }
        public int QuantityReality { get => quantityReality; set => quantityReality = value; }
        public DateTime? DateReality { get => dateReality; set => dateReality = value; }
        public string Employess { get => employess; set => employess = value; }
        public string MaterCode { get => materCode; set => materCode = value; }
        public string MaterialName { get => materialName; set => materialName = value; }
        public string ColorCode { get => colorCode; set => colorCode = value; }
        public long IdPO { get => idPO; set => idPO = value; }
        public int StatusProDetail { get => statusProDetail; set => statusProDetail = value; }
    }
}
