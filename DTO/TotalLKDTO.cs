using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class TotalLKDTO
    {
        public TotalLKDTO(long Id, string PartCode, DateTime Date, int Output, int Input, int Total, int CountDate, string MachineCode, string MoldCode, int TotalNow, int InputNow, int CountDateNow)
        {
            this.Id = Id;
            this.PartCode = PartCode;
            this.Date = Date;
            this.Input = Input;
            this.Output = Output;
            this.Total = Total;
            this.CountDate = CountDate;
            this.MachineCode = MachineCode;
            this.MoldCode = MoldCode;
            this.TotalNow = TotalNow;
            this.InputNow = InputNow;
            this.CountDateNow = CountDateNow;
        }
        public TotalLKDTO(DataRow row)
        {
            this.Id = (long)row["Id"];
            this.PartCode = row["PartCode"].ToString();
            this.Date = (DateTime)row["Date"];
            this.Input = (int)row["Input"];
            this.Output = (int)row["Output"];
            this.Total = (int)row["Total"];
            this.CountDate = (int)row["CountDate"];
            this.MachineCode = row["MachineCode"].ToString();
            this.MoldCode = row["MoldCode"].ToString();
            this.TotalNow = (int)row["TotalNow"];
            this.InputNow = (int)row["InputNow"];
            this.CountDateNow = (int)row["CountDateNow"];
        }
        private long id;
        private string partCode;
        private DateTime date;
        private int total;
        private int input;
        private int output;
        private int countDate;
        private string machineCode;
        private string moldCode;
        private int totalNow;
        private int inputNow;
        private int countDateNow;
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
        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
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

        public int Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
            }
        }

        public int Input
        {
            get
            {
                return input;
            }

            set
            {
                input = value;
            }
        }

        public int Output
        {
            get
            {
                return output;
            }

            set
            {
                output = value;
            }
        }

        public int CountDate
        {
            get
            {
                return countDate;
            }

            set
            {
                countDate = value;
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

        public int TotalNow
        {
            get
            {
                return totalNow;
            }

            set
            {
                totalNow = value;
            }
        }

        public int InputNow
        {
            get
            {
                return inputNow;
            }

            set
            {
                inputNow = value;
            }
        }

        public int CountDateNow
        {
            get
            {
                return countDateNow;
            }

            set
            {
                countDateNow = value;
            }
        }
    }
}
