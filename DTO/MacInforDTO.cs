using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MacInforDTO
    {
        public MacInforDTO(int Id, string PartCode, string MachineCode, string MoldCode, string MoldNumber, int Important, string Rev, string FactoryCode, string Standard, int StatusM)
        {
            this.Id = Id;
            this.PartCode = PartCode;
            this.MachineCode = MachineCode;
            this.MoldCode = MoldCode;
            this.MoldNumber = MoldNumber;
            this.Important = Important;
            this.Rev = Rev;
            this.FactoryCode = FactoryCode;
            this.Standard = Standard;
            this.StatusM = StatusM;
        }
        public MacInforDTO(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.PartCode = row["PartCode"].ToString();
            this.MachineCode = row["MachineCode"].ToString();
            this.MoldCode = row["MoldCode"].ToString();
            this.MoldNumber = row["MoldNumber"].ToString();
            this.Important = (int)row["Important"];
            this.Rev = row["Rev"].ToString();
            this.FactoryCode = row["FactoryCode"].ToString();
            this.Standard = row["Standard"].ToString();
            this.StatusM = (int)row["StatusM"];
        }
        private int id;
        private string partCode;
        private string machineCode;
        private string moldCode;
        private string moldNumber;
        private int important;
        private string rev;
        private string factoryCode;
        private string standard;
        private int statusM;
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

        public string PartCode
        {
            get
            {
                return partCode;
            }

            set
            {
                partCode = value;
            }
        }

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

        public string MoldCode
        {
            get
            {
                return moldCode;
            }

            set
            {
                moldCode = value;
            }
        }

        public string MoldNumber
        {
            get
            {
                return moldNumber;
            }

            set
            {
                moldNumber = value;
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

        public string Rev { get => rev; set => rev = value; }
        public string FactoryCode { get => factoryCode; set => factoryCode = value; }
        public string Standard { get => standard; set => standard = value; }
        public int StatusM { get => statusM; set => statusM = value; }
    }
}
