
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class WarehouseMaterial
    {
        public WarehouseMaterial(int Id, string Name, int StatusWH, string Style, int WeightWH)
        {
            this.Id = Id;
            this.Name = Name;
            this.StatusWH = StatusWH;
            this.Style = Style;
            this.WeightWH = WeightWH;
        }
        public WarehouseMaterial(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.Name = row["Name"].ToString();
            this.StatusWH = (int)row["StatusWH"];
            this.Style = row["Style"].ToString();
            this.WeightWH = (int)row["WeightWH"];
        }
        private int id;
        private string name;
        private int statusWH;
        private string style;
        private int weightWH;
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public int StatusWH
        {
            get
            {
                return statusWH;
            }

            set
            {
                statusWH = value;
            }
        }

        public string Style
        {
            get
            {
                return style;
            }

            set
            {
                style = value;
            }
        }

        public int WeightWH { get => weightWH; set => weightWH = value; }
    }
}
