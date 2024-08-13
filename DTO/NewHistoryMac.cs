using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NewHistoryMac
    {
        public NewHistoryMac(HistoryMacDTO HistoryMac, string MachineCode, string MoldNumber)
        {
            this.HistoryMac = HistoryMac;
            this.MachineCode = MachineCode;
            this.MoldNumber = MoldNumber;
        }
        private HistoryMacDTO historyMac;
        private string machineCode;
        private string moldNumber;

        public HistoryMacDTO HistoryMac { get => historyMac; set => historyMac = value; }
        public string MachineCode { get => machineCode; set => machineCode = value; }
        public string MoldNumber { get => moldNumber; set => moldNumber = value; }
    }
}
