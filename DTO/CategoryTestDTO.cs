using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CategoryTestDTO
    {
        public CategoryTestDTO(long Id, string NameCategory, string Detail, int Timer, string Method, int ConfirmCategory, string Device, string Limit)
        {
            this.Id = Id;
            this.NameCategory = NameCategory;
            this.Detail = Detail;
            this.Timer = Timer;
            this.Method = Method;
            this.ConfirmCategory = ConfirmCategory;
            this.Device = Device;
            this.Limit = Limit;
        }
        public CategoryTestDTO(DataRow row)
        {
            this.Id = (long)row["Id"];
            this.NameCategory = row["NameCategory"].ToString();
            this.Detail = row["Detail"].ToString();
            this.Timer = (int)row["Timer"];
            this.Method = row["Method"].ToString();
            this.ConfirmCategory = (int)row["ConfirmCategory"];
            this.Device = row["Device"].ToString();
            this.Limit = row["Limit"].ToString();
        }
        private long id;
        private string nameCategory;
        private string detail;
        private int timer;
        private string method;
        private int confirmCategory;
        private string device;
        private string limit;

        public long Id
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

        public string NameCategory
        {
            get
            {
                return nameCategory;
            }

            set
            {
                nameCategory = value;
            }
        }

        public string Detail
        {
            get
            {
                return detail;
            }

            set
            {
                detail = value;
            }
        }

        public int Timer
        {
            get
            {
                return timer;
            }

            set
            {
                timer = value;
            }
        }

        public string Method
        {
            get
            {
                return method;
            }

            set
            {
                method = value;
            }
        }

        public int ConfirmCategory
        {
            get
            {
                return confirmCategory;
            }

            set
            {
                confirmCategory = value;
            }
        }

        public string Device { get => device; set => device = value; }
        public string Limit { get => limit; set => limit = value; }
    }
}
