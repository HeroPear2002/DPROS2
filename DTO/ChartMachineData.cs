using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChartMachineData
    {
        public ChartMachineData(string Name, string HourMachine, string Count)
        {
            this.Name = Name;
            this.HourMachine = HourMachine;
            this.Count = Count;
        }
        public ChartMachineData(DataRow row)
        {
            this.Name = row["Name"].ToString();
            this.HourMachine = row["HourMachine"].ToString();
            this.Count = row["Count"].ToString();
        }
        private string name;
        private string hourMachine;
        private string count;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string HourMachine
        {
            get
            {
                return hourMachine;
            }

            set
            {
                hourMachine = value;
            }
        }

        public string Count
        {
            get
            {
                return count;
            }

            set
            {
                count = value;
            }
        }
    }
}
