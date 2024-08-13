using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class MachineInportantDTO
    {
        public MachineInportantDTO(string MachineCode,int Important)
        {
            this.MachineCode = MachineCode;
            this.Important = Important;
        }
        public MachineInportantDTO(DataRow row)
        {
            this.MachineCode = row["MachineCode"].ToString();
            this.Important = (int)row["Important"];
        }
        private string machineCode;
        private int important;

        public string MachineCode
        {
            get
            {
                return machineCode;
            }

            set
            {
                machineCode = value;
            }
        }

        public int Important
        {
            get
            {
                return important;
            }

            set
            {
                important = value;
            }
        }
    }
}
