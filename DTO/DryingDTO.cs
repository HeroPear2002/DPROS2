using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class DryingDTO
    {
        private long id;
        private string materialCode;
        private string materialName;
        private string machineDry;
        private float quantityDry;
        private DateTime dateDrying;
        private DateTime? datePour;
        private string employess;
        private string partCode;
        private string machineCode;
        private int statusDry;
        private string note;
        public DryingDTO(long id, string materialCode, string materialName, string machineDry, 
            float quantityDry, DateTime dateDrying, DateTime? datePour, string employess, 
            string partCode, string machineCode, int statusDry, string note)
        {
            Id = id;
            MaterialCode = materialCode;
            MaterialName = materialName;
            MachineDry = machineDry;
            QuantityDry = quantityDry;
            DateDrying = dateDrying;
            DatePour = datePour;
            Employess = employess;
            PartCode = partCode;
            MachineCode = machineCode;
            StatusDry = statusDry;
            Note = note;
        }
        public DryingDTO(DataRow row)
        {
            Id = (long)row["Id"];
            MaterialCode = row["MaterialCode"].ToString();
            MaterialName = row["MaterialName"].ToString();
            MachineDry = row["MachineDry"].ToString();
            QuantityDry = (float)Convert.ToDouble(row["QuantityDry"].ToString());
            DateDrying = (DateTime)row["DateDrying"];
            var checkDate = row["DatePour"];
            if (checkDate.ToString() != "")
                DatePour = (DateTime)checkDate; 
            Employess = row["Employess"].ToString();
            PartCode = row["PartCode"].ToString();
            MachineCode = row["MachineCode"].ToString();
            StatusDry = (int)row["StatusDry"];
            Note = row["Note"].ToString();
        }

        public long Id { get => id; set => id = value; }
        public string MaterialCode { get => materialCode; set => materialCode = value; }
        public string MaterialName { get => materialName; set => materialName = value; }
        public string MachineDry { get => machineDry; set => machineDry = value; }
        public float QuantityDry { get => quantityDry; set => quantityDry = value; }
        public DateTime DateDrying { get => dateDrying; set => dateDrying = value; }
        public DateTime? DatePour { get => datePour; set => datePour = value; }
        public string Employess { get => employess; set => employess = value; }
        public string PartCode { get => partCode; set => partCode = value; }
        public string MachineCode { get => machineCode; set => machineCode = value; }
        public int StatusDry { get => statusDry; set => statusDry = value; }
        public string Note { get => note; set => note = value; }
    }
}
