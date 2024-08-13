using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class KHBDDTO
    {
        public KHBDDTO(long Id,string MachineCode,string PartCode,string MoldCode,DateTime StartTime,DateTime EndTime,int CountBD,int ConfirmBD)
        {
            this.Id = Id;
            this.MachineCode = MachineCode;
            this.PartCode = PartCode;
            this.MoldCode = MoldCode;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            this.CountBD = CountBD;
            this.ConfirmBD = ConfirmBD;
        }
        public KHBDDTO(DataRow row)
        {
            this.Id = (long)row["Id"];
            this.MachineCode = row["MachineCode"].ToString();
            this.PartCode = row["PartCode"].ToString();
            this.MoldCode = row["MoldCode"].ToString();
            this.StartTime = (DateTime)row["StartTime"];
            this.EndTime = (DateTime)row["EndTime"];
            this.CountBD = (int)row["CountBD"];
            this.ConfirmBD = (int)row["ConfirmBD"];
        }
        private long id;
        private string machineCode;
        private string partCode;
        private string moldCode;
        private DateTime startTime;
        private DateTime endTime;
        private int countBD;
        private int confirmBD;

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

        public DateTime StartTime
        {
            get
            {
                return startTime;
            }

            set
            {
                startTime = value;
            }
        }

        public DateTime EndTime
        {
            get
            {
                return endTime;
            }

            set
            {
                endTime = value;
            }
        }

        public int CountBD
        {
            get
            {
                return countBD;
            }

            set
            {
                countBD = value;
            }
        }

        public int ConfirmBD
        {
            get
            {
                return confirmBD;
            }

            set
            {
                confirmBD = value;
            }
        }
    }
}
