using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class ChartDeviceDTO
    {
        public ChartDeviceDTO(string NameCategory,string MachineCode,string DataCount,DateTime DateCheck)
        {
            this.NameCategory = NameCategory;
            this.MachineCode = MachineCode;
            this.DataCount = DataCount;
            this.DateCheck = DateCheck;
        }
        public ChartDeviceDTO(DataRow row)
        {
            this.NameCategory = row["NameCategory"].ToString();
            this.MachineCode = row["MachineCode"].ToString();
            this.DataCount = row["DataCount"].ToString();
            this.DateCheck = (DateTime)row["DateCheck"];
        }
        private string nameCategory;
        private string machineCode;
        private string dataCount;
        private DateTime dateCheck;

        public string NameCategory { get => nameCategory; set => nameCategory = value; }
        public string MachineCode { get => machineCode; set => machineCode = value; }
        public string DataCount { get => dataCount; set => dataCount = value; }
        public DateTime DateCheck { get => dateCheck; set => dateCheck = value; }
    }
}
