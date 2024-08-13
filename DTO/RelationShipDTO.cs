using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RelationShipDTO
    {
        public RelationShipDTO(long Id, string MachineCode, long IdCategory, int TimeTT, int StatusRe,int TimerKH)
        {
            this.Id = Id;
            this.MachineCode = MachineCode;
            this.IdCategory = IdCategory;
            this.TimeTT = TimeTT;
            this.StatusRe = StatusRe;
            this.TimerKH = TimerKH;
        }
        public RelationShipDTO(DataRow row)
        {
            this.Id = (long)row["Id"];
            this.MachineCode = row["MachineCode"].ToString();
            this.IdCategory = (long)row["IdCategory"];
            this.TimeTT = (int)row["TimeTT"];
            this.StatusRe = (int)row["StatusRe"];
            this.TimerKH = (int)row["TimerKH"];
        }
        private long id;
        private string machineCode;
        private long idCategory;
        private int timeTT;
        private int statusRe;
        private int timerKH;

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

        public long IdCategory
        {
            get
            {
                return idCategory;
            }

            set
            {
                idCategory = value;
            }
        }

        public int TimeTT
        {
            get
            {
                return timeTT;
            }

            set
            {
                timeTT = value;
            }
        }

        public int StatusRe
        {
            get
            {
                return statusRe;
            }

            set
            {
                statusRe = value;
            }
        }

        public int TimerKH { get => timerKH; set => timerKH = value; }
    }
}
