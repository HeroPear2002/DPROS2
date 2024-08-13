using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class KHNLDTO
    {
        public KHNLDTO(long Id, long IdSD,string MaterialCode,string MaterialName,string MachineCode,DateTime StartTime,DateTime EndTime,int CountNL,int Confirm)
        {
            this.Id = Id;
            this.IdSD = IdSD;
            this.MaterialCode = MaterialCode;
            this.MaterialName = MaterialName;
            this.MachineCode = MachineCode;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            this.CountNL = CountNL;
            this.Confirm = Confirm;
        }
        public KHNLDTO(DataRow row)
        {
            this.Id = (long)row["Id"];
            this.IdSD = (long)row["IdSD"];
            this.MaterialCode = row["MaterialCode"].ToString();
            this.MaterialName = row["MaterialName"].ToString();
            this.MachineCode = row["MachineCode"].ToString();
            this.StartTime = (DateTime)row["StartTime"];
            this.EndTime = (DateTime)row["EndTime"];
            this.CountNL = (int)row["CountNL"];
            this.Confirm = (int)row["Confirm"];
        }
        private long id;
        private long idSD;
        private string materialCode;
        private string materialName;
        private string machineCode;
        private DateTime startTime;
        private DateTime endTime;
        private int countNL;
        private int confirm;

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

        public string MaterialCode
        {
            get
            {
                return materialCode;
            }

            set
            {
                materialCode = value;
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

        public int CountNL
        {
            get
            {
                return countNL;
            }

            set
            {
                countNL = value;
            }
        }

        public int Confirm
        {
            get
            {
                return confirm;
            }

            set
            {
                confirm = value;
            }
        }

        public string MaterialName
        {
            get
            {
                return materialName;
            }

            set
            {
                materialName = value;
            }
        }
    }
}
