using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class StatusWarehouseDTO
    {
        public StatusWarehouseDTO(int Id,string NameStatus)
        {
            this.Id = Id;
            this.NameStatus = NameStatus;
        }
        public StatusWarehouseDTO(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.NameStatus = row["NameStatus"].ToString();
        }
        private int id;
        private string nameStatus;

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

        public string NameStatus
        {
            get
            {
                return nameStatus;
            }

            set
            {
                nameStatus = value;
            }
        }
    }
}
