using System;
using System.Data;

namespace DTO
{
    public class TTSXDTO
    {
        public TTSXDTO(long Id,long IdSD, string MachineCode,string PartCode,string MoldCode,DateTime StartTime,DateTime EndTime,int CountTT,int ConfirmTT)
        {
            this.Id = Id;
            this.IdSD = IdSD;
            this.MachineCode = MachineCode;
            this.PartCode = PartCode;
            this.MoldCode = MoldCode;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            this.CountTT = CountTT;
            this.ConfirmTT = ConfirmTT;
        }
        public TTSXDTO(DataRow row)
        {
            this.Id = (long)row["Id"];
            this.IdSD = (long)row["IdSD"];
            this.MachineCode = row["MachineCode"].ToString();
            this.PartCode = row["PartCode"].ToString();
            this.MoldCode = row["MoldCode"].ToString();
            this.StartTime = (DateTime)row["StartTime"];
            this.EndTime = (DateTime)row["EndTime"];
            this.CountTT = (int)row["CountTT"];
            this.ConfirmTT = (int)row["ConfirmTT"];
        }
        private long id;
        private long idSD;
        private string machineCode;
        private string partCode;
        private string moldCode;
        private DateTime startTime;
        private DateTime endTime;
        private int countTT;
        private int confirmTT;

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

        public long IdSD
        {
            get
            {
                return idSD;
            }

            set
            {
                idSD = value;
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

        public int CountTT
        {
            get
            {
                return countTT;
            }

            set
            {
                countTT = value;
            }
        }

        public int ConfirmTT
        {
            get
            {
                return confirmTT;
            }

            set
            {
                confirmTT = value;
            }
        }
    }
}
