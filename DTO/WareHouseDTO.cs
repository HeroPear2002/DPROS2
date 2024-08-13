using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class WareHouseDTO
    {
        public WareHouseDTO(int Id,string Name,int Status,int Height,string Style)
        {
            this.Id = Id;
            this.Name = Name;
            this.Status = Status;
            this.Height = Height;
            this.Style = Style;
        }
        public WareHouseDTO(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.Name = row["Name"].ToString();
            this.Status = (int)row["Status"];
            this.Height = (int)row["Height"];
            this.Style = row["Style"].ToString();
        }
        private int id;
        private string name;
        private int status;
        private int height;
        private string style;

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

        public int Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }

            set
            {
                height = value;
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
    }
}
