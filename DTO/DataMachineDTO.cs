using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class DataMachineDTO
    {
        public DataMachineDTO(long Id, string MoldCode, string MachineCode, DateTime DateInput, float DifCycleTime, float DifTimeLM, float DifTimeGA, float DifTimeIJ, float DifCushpos, float DifH4, float DifCore, float DifCavity)
        {
            this.DateInput = DateInput;
            this.DifCycleTime = DifCycleTime;
            this.DifTimeLM = DifTimeLM;
            this.DifTimeGA = DifTimeGA;
            this.DifTimeIJ = DifTimeIJ;
            this.DifCushpos = DifCushpos;
            this.DifH4 = DifH4;
            this.DifCore = DifCore;
            this.DifCavity = DifCavity;
        }
        public DataMachineDTO(DataRow row)
        {
            this.DateInput = (DateTime)row["DateInput"];
            this.DifCycleTime = (float)Convert.ToDouble(row["DifCycleTime"].ToString());
            this.DifTimeLM = (float)Convert.ToDouble(row["DifTimeLM"].ToString());
            this.DifTimeGA = (float)Convert.ToDouble(row["DifTimeGA"].ToString());
            this.DifTimeIJ = (float)Convert.ToDouble(row["DifTimeIJ"].ToString());
            this.DifCushpos = (float)Convert.ToDouble(row["DifCushpos"].ToString());
            this.DifH4 = (float)Convert.ToDouble(row["DifH4"].ToString());
            this.DifCore = (float)Convert.ToDouble(row["DifCore"].ToString());
            this.DifCavity = (float)Convert.ToDouble(row["DifCavity"].ToString());
        }
        private long id;
        private string moldCode;
        private string machineCode;
        private DateTime dateInput;
        private float difCycleTime;
        private float difTimeLM;
        private float difTimeGA;
        private float difTimeIJ;
        private float difCushpos;
        private float difH4;
        private float difCore;
        private float difCavity;

        public DateTime DateInput
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

        public float DifCycleTime
        {
            get
            {
                return difCycleTime;
            }

            set
            {
                difCycleTime = value;
            }
        }

        public float DifTimeLM
        {
            get
            {
                return difTimeLM;
            }

            set
            {
                difTimeLM = value;
            }
        }

        public float DifTimeGA
        {
            get
            {
                return difTimeGA;
            }

            set
            {
                difTimeGA = value;
            }
        }

        public float DifTimeIJ
        {
            get
            {
                return difTimeIJ;
            }

            set
            {
                difTimeIJ = value;
            }
        }

        public float DifCushpos
        {
            get
            {
                return difCushpos;
            }

            set
            {
                difCushpos = value;
            }
        }

        public float DifH4
        {
            get
            {
                return difH4;
            }

            set
            {
                difH4 = value;
            }
        }

        public float DifCore
        {
            get
            {
                return difCore;
            }

            set
            {
                difCore = value;
            }
        }

        public float DifCavity
        {
            get
            {
                return difCavity;
            }

            set
            {
                difCavity = value;
            }
        }

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
    }
}
