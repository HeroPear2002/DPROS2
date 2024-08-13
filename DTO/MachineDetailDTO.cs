using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MachineDetailDTO
    {
        public MachineDetailDTO(long Id, string MachineCode, string Col1, string Col2, string Col3)
        {
            this.Id = Id;
            this.MachineCode = MachineCode;
            this.Col1 = Col1;
            this.Col2 = Col2;
            this.Col3 = Col3;
        }
        public MachineDetailDTO(DataRow row)
        {
            this.Id = (long)row["Id"];
            this.MachineCode = row["MachineCode"].ToString();
            this.Col1 = row["Col1"].ToString();
            this.Col2 = row["Col2"].ToString();
            this.Col3 = row["Col3"].ToString();
        }
        private long id;
        private string machineCode;
        private string col1;
        private string col2;
        private string col3;

        public long Id { get => id; set => id = value; }
        public string MachineCode { get => machineCode; set => machineCode = value; }
        public string Col1 { get => col1; set => col1 = value; }
        public string Col2 { get => col2; set => col2 = value; }
        public string Col3 { get => col3; set => col3 = value; }
    }
}
