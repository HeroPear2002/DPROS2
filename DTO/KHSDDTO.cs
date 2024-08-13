using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class KHSDDTO
    {
        public KHSDDTO(long Id,long IdBD,string MachineCode,string PartCode,string MoldCode,DateTime StartTime,DateTime EndTime,int CountSD, int ConfirmSD)
        {
            this.Id = Id;
            this.IdBD = IdBD;
            this.MachineCode = MachineCode;
            this.PartCode = PartCode;
            this.MoldCode = MoldCode;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            this.CountSD = CountSD;
            this.ConfirmSD = ConfirmSD;
        }
        public KHSDDTO(DataRow row)
        {
            this.Id = (long)row["Id"];
            this.IdBD = (long)row["IdBD"];
            this.MachineCode = row["MachineCode"].ToString();
            this.PartCode = row["PartCode"].ToString();
            this.MoldCode = row["MoldCode"].ToString();
            this.StartTime = (DateTime)row["StartTime"];
            this.EndTime = (DateTime)row["EndTime"];
            this.CountSD = (int)row["CountSD"];
            this.ConfirmSD = (int)row["ConfirmSD"];
        }
        private long id;
        private long idBD;
        private string machineCode;
        private string partCode;
        private string moldCode;
        private DateTime startTime;
        private DateTime endTime;
        private int countSD;
        private int confirmSD;

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

        public long IdBD
        {
            get
            {
                return idBD;
            }

            set
            {
                idBD = value;
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

        public int CountSD
        {
            get
            {
                return countSD;
            }

            set
            {
                countSD = value;
            }
        }

        public int ConfirmSD
        {
            get
            {
                return confirmSD;
            }

            set
            {
                confirmSD = value;
            }
        }
    }
}
