using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class MachineEfficChart
    {
        public MachineEfficChart(string MachineCode, int Ngay, double Percent, int Thang)
        {
            this.MachineCode = MachineCode;
            this.Ngay = Ngay;
            this.Percent = Percent;
            this.Thang = Thang;
        }
        public MachineEfficChart(DataRow row)
        {
            this.MachineCode = row["MachineCode"].ToString();
            this.Ngay = (int)row["Ngay"];
            this.Percent = Convert.ToDouble(row["Percent"].ToString());
            this.Thang = (int)row["Thang"];
        }
        private string machineCode;
        private int ngay;
        private double percent;
        private int thang;

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

        public int Ngay
        {
            get
            {
                return ngay;
            }

            set
            {
                ngay = value;
            }
        }

        public double Percent
        {
            get
            {
                return percent;
            }

            set
            {
                percent = value;
            }
        }

        public int Thang
        {
            get
            {
                return thang;
            }

            set
            {
                thang = value;
            }
        }
    }
}
