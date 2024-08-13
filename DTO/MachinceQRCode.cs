using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MachinceQRCode
    {
        public MachinceQRCode(string MachineCode, string MachineName, string Name, string MachineInfor, string CodeTSCD, string QrCode)
        {
            this.MachineCode = MachineCode;
            this.MachineName = MachineName;
            this.Name = Name;
            this.MachineInfor = MachineInfor;
            this.CodeTSCD = CodeTSCD;
            this.QrCode = QrCode;
      
        }
        public MachinceQRCode(DataRow row)
        {
            this.MachineCode = row["MachineCode"].ToString();
            this.MachineName = row["MachineName"].ToString();
            this.Name = row["Name"].ToString();
            this.MachineInfor = row["MachineInfor"].ToString();
            this.CodeTSCD = row["CodeTSCD"].ToString();
            this.QrCode = row["QrCode"].ToString();
      
        }
        private string qrCode;
        private string machineCode;
        private string machineName;
        private string name;
        private string machineInfor;
        private string codeTSCD;


        public string QrCode { get => qrCode; set => qrCode = value; }
        public string MachineCode { get => machineCode; set => machineCode = value; }
        public string MachineName { get => machineName; set => machineName = value; }
        public string Name { get => name; set => name = value; }
        public string MachineInfor { get => machineInfor; set => machineInfor = value; }
        public string CodeTSCD { get => codeTSCD; set => codeTSCD = value; }

    }
}
