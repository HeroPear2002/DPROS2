using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EmployessCard
    {
        public EmployessCard(string EmployessCode, string EmployessName, string PositionName, string LinkImage)
        {
            this.EmployessCode = EmployessCode;
            this.EmployessName = EmployessName;
            this.PositionName = PositionName;
            this.LinkImage = LinkImage;
        }
        public EmployessCard(DataRow row)
        {
            this.EmployessCode = row["EmployessCode"].ToString();
            this.EmployessName = row["EmployessName"].ToString();
            this.PositionName = row["PositionName"].ToString();
            this.LinkImage = row["LinkImage"].ToString();
        }
        private string employessCode;
        private string employessName;
        private string positionName;
        private string linkImage;

        public string EmployessCode { get => employessCode; set => employessCode = value; }
        public string EmployessName { get => employessName; set => employessName = value; }
        public string PositionName { get => positionName; set => positionName = value; }
        public string LinkImage { get => linkImage; set => linkImage = value; }
    }
}
