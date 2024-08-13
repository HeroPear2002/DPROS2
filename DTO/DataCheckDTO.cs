using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DataCheckDTO
    {
        public DataCheckDTO(long Id, string MoldCode, string MachineCode, float ValueDefault, float ValueReal, DateTime DateCheck, string Name, string Note, string EmployessCode)
        {
            this.Id = Id;
            this.MoldCode = MoldCode;
            this.MachineCode = MachineCode;
            this.ValueDefault = ValueDefault;
            this.ValueReal = ValueReal;
            this.DateCheck = DateCheck;
            this.Name = Name;
            this.Note = Note;
            this.EmployessCode = EmployessCode;
        }
        public DataCheckDTO(DataRow row)
        {
            this.Id = (long)row["Id"];
            this.MoldCode = row["MoldCode"].ToString();
            this.MachineCode = row["MachineCode"].ToString();
            this.ValueDefault = (float)Convert.ToDouble(row["ValueDefault"].ToString());
            this.ValueReal = (float)Convert.ToDouble(row["ValueReal"].ToString());
            this.DateCheck = (DateTime)row["DateCheck"];
            this.Name = row["Name"].ToString();
            this.Note = row["Note"].ToString();
            this.EmployessCode = row["EmployessCode"].ToString();
        }
        private long id;
        private string moldCode;
        private string machineCode;
        private float valueDefault;
        private float valueReal;
        private DateTime dateCheck;
        private string name;
        private string note;
        private string employessCode;

        public long Id { get => id; set => id = value; }
        public string MoldCode { get => moldCode; set => moldCode = value; }
        public string MachineCode { get => machineCode; set => machineCode = value; }
        public float ValueDefault { get => valueDefault; set => valueDefault = value; }
        public float ValueReal { get => valueReal; set => valueReal = value; }
        public DateTime DateCheck { get => dateCheck; set => dateCheck = value; }
        public string Name { get => name; set => name = value; }
        public string Note { get => note; set => note = value; }
        public string EmployessCode { get => employessCode; set => employessCode = value; }
    }
}
