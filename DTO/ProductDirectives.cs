using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class ProductDirectives
    {

        private long id;
        private string partCode;
        private string machineCode;
        private int quantity;
        private DateTime dateInput;
        private string moldCode;
        private string moldNumber;
        private string noteSX;
        private string noteNL;
        private string factoryCode;
        private string materialCode;
        private string materialName;
        private float weightUse;
        private float weightOut;
        private int status;
        private string note;

        public ProductDirectives(long id, string partCode, string machineCode, int quantity, DateTime dateInput,
            string moldCode, string moldNumber, string noteSX, string noteNL, string factoryCode, string materialCode, 
            string materialName, float weightUse, float weightOut, int status,string note)
        {
            Id = id;
            PartCode = partCode;
            MachineCode = machineCode;
            Quantity = quantity;
            DateInput = dateInput;
            MoldCode = moldCode;
            MoldNumber = moldNumber;
            NoteSX = noteSX;
            NoteNL = noteNL;
            FactoryCode = factoryCode;
            MaterialCode = materialCode;
            MaterialName = materialName;
            WeightUse = weightUse;
            WeightOut = weightOut;
            Status = status;
            Note = note;
        }
        public ProductDirectives(DataRow row)
        {
            Id = (long)row["Id"];
            PartCode = row["PartCode"].ToString();
            MachineCode = row["MachineCode"].ToString();
            Quantity = (int)row["Quantity"];
            DateInput = (DateTime)row["DateInput"];
            MoldCode = row["MoldCode"].ToString();
            MoldNumber = row["MoldNumber"].ToString();
            NoteSX = row["NoteSX"].ToString();
            NoteNL = row["NoteNL"].ToString();
            FactoryCode = row["FactoryCode"].ToString();
            MaterialCode = row["MaterialCode"].ToString();
            MaterialName = row["MaterialName"].ToString();
            WeightUse = (float)Convert.ToDouble(row["WeightUse"]);
            WeightOut = (float)Convert.ToDouble(row["WeightOut"]);
            Status = (int)row["Status"];
            Note = row["Note"].ToString();
        }
        public long Id { get => id; set => id = value; }
        public string PartCode { get => partCode; set => partCode = value; }
        public string MachineCode { get => machineCode; set => machineCode = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public DateTime DateInput { get => dateInput; set => dateInput = value; }
        public string MoldCode { get => moldCode; set => moldCode = value; }
        public string MoldNumber { get => moldNumber; set => moldNumber = value; }
        public string NoteSX { get => noteSX; set => noteSX = value; }
        public string NoteNL { get => noteNL; set => noteNL = value; }
        public string FactoryCode { get => factoryCode; set => factoryCode = value; }
        public string MaterialCode { get => materialCode; set => materialCode = value; }
        public string MaterialName { get => materialName; set => materialName = value; }
        public float WeightUse { get => weightUse; set => weightUse = value; }
        public float WeightOut { get => weightOut; set => weightOut = value; }
        public int Status { get => status; set => status = value; }
        public string Note { get => note; set => note = value; }
    }
}
