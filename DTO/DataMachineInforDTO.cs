using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class DataMachineInforDTO
    {
        public DataMachineInforDTO(int Id,string NameCate,string MoldCode,string MachineCode,float UpData,float DownData)
        {
            this.Id = Id;
            this.NameCate = NameCate;
            this.MoldCode = MoldCode;
            this.MachineCode = MachineCode;
            this.UpData = UpData;
            this.DownData = DownData;
        }
        public DataMachineInforDTO(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.NameCate = row["NameCate"].ToString();
            this.MoldCode = row["MoldCode"].ToString();
            this.MachineCode = row["MachineCode"].ToString();
            this.UpData = (float)Convert.ToDouble(row["UpData"].ToString());
            this.DownData = (float)Convert.ToDouble(row["DownData"].ToString());
        }
        private int id;
        private string nameCate;
        private string moldCode;
        private string machineCode;
        private float upData;
        private float downData;

        public int Id { get => id; set => id = value; }
        public string NameCate { get => nameCate; set => nameCate = value; }
        public string MoldCode { get => moldCode; set => moldCode = value; }
        public string MachineCode { get => machineCode; set => machineCode = value; }
        public float UpData { get => upData; set => upData = value; }
        public float DownData { get => downData; set => downData = value; }
    }
}
