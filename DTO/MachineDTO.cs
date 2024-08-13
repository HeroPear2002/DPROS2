using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class MachineDTO
    {
        public MachineDTO(string MachineCode,string MachineName,string MachineInfor,string MachineMake,DateTime? DateInput,string CodeTSCD,string Vendor,DateTime? DateSX,int Device,int StatusMachine,string NoteMachine, string DateMaker)
        {
            this.MachineCode = MachineCode;
            this.MachineName = MachineName;
            this.MachineInfor = MachineInfor;
            this.MachineMake = MachineMake;
            this.DateInput = DateInput;
            this.CodeTSCD = CodeTSCD;
            this.Vendor = Vendor;
            this.DateSX = DateSX;
            this.Device = Device;
            this.StatusMachine = StatusMachine;
            this.DateMaker = DateMaker;
            this.NoteMachine = NoteMachine;
        }
        public MachineDTO( DataRow row)
        {
            this.MachineCode = row["MachineCode"].ToString();
            this.MachineName = row["MachineName"].ToString();
            this.MachineInfor = row["MachineInfor"].ToString();
            this.MachineMake = row["MachineMake"].ToString();
            var CheckDateIn = row["DateInput"];
            if (CheckDateIn.ToString().Length != 0)
            { this.DateInput = (DateTime)CheckDateIn; }
            this.CodeTSCD = row["CodeTSCD"].ToString();
            this.Vendor = row["Vendor"].ToString();
            var CheckDateSX = row["DateSX"];
            if (CheckDateSX.ToString().Length != 0)
            { this.DateSX = (DateTime)CheckDateSX; }
            this.Device = (int)row["Device"];
            this.StatusMachine = (int)row["StatusMachine"];
            this.NoteMachine = row["NoteMachine"].ToString();
            this.DateMaker = row["DateMaker"].ToString();
        }
        private string machineCode;
        private string machineName;
        private string machineInfor;
        private string machineMake;
        private DateTime? dateInput;
        private string codeTSCD;
        private string vendor;
        private DateTime? dateSX;
        private int device;
        private int statusMachine;
        private string noteMachine;
        private string dateMaker;
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

        public string MachineName
        {
            get
            {
                return machineName;
            }

            set
            {
                machineName = value;
            }
        }

        public string MachineInfor
        {
            get
            {
                return machineInfor;
            }

            set
            {
                machineInfor = value;
            }
        }

        public string MachineMake
        {
            get
            {
                return machineMake;
            }

            set
            {
                machineMake = value;
            }
        }

        public DateTime? DateInput
        {
            get
            {
                return dateInput;
            }

            set
            {
                dateInput = value;
            }
        }

        public string CodeTSCD
        {
            get
            {
                return codeTSCD;
            }

            set
            {
                codeTSCD = value;
            }
        }

        public string Vendor
        {
            get
            {
                return vendor;
            }

            set
            {
                vendor = value;
            }
        }

        public DateTime? DateSX
        {
            get
            {
                return dateSX;
            }

            set
            {
                dateSX = value;
            }
        }

        public int Device
        {
            get
            {
                return device;
            }

            set
            {
                device = value;
            }
        }

        public int StatusMachine
        {
            get
            {
                return statusMachine;
            }

            set
            {
                statusMachine = value;
            }
        }

        public string NoteMachine
        {
            get
            {
                return noteMachine;
            }

            set
            {
                noteMachine = value;
            }
        }

        public string DateMaker { get => dateMaker; set => dateMaker = value; }
    }
}
