using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OnlyMachineDTO
    {
        public OnlyMachineDTO(string MachineCode)
        {
            this.MachineCode = MachineCode;
        }
        public OnlyMachineDTO(DataRow row)
        {
            this.MachineCode = row["MachineCode"].ToString();
        }
        private string machineCode;

        public string MachineCode { get => machineCode; set => machineCode = value; }
    }
}
