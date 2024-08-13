using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class TableSX
    {
        public TableSX(long Id,int IdResource,string MachineCode,string MoldNumber,string PartCode,DateTime StartTime,DateTime EndTime,int Quantity,int ColorSX,int ConfirmSX)
        {
            this.Id = Id;
            this.IdResource = IdResource;
            this.MachineCode = MachineCode;
            this.MoldNumber = MoldNumber;
            this.PartCode = PartCode;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            this.Quantity = Quantity;
            this.ColorSX = ColorSX;
            this.ConfirmSX = ConfirmSX;
          
        }
        public TableSX(DataRow row)
        {
            this.Id = (long)row["Id"];
            this.IdResource = (int)row["IdResource"];
            this.MachineCode = row["MachineCode"].ToString();
            this.MoldNumber = row["MoldNumber"].ToString();
            this.PartCode = row["PartCode"].ToString();
            this.StartTime = (DateTime)row["StartTime"];
            this.EndTime = (DateTime)row["EndTime"];
            this.Quantity = (int)row["Quantity"];
            this.ColorSX = (int)row["ColorSX"];
            this.ConfirmSX = (int)row["ConfirmSX"];
           
        }
        private long id;
        private int idResource;
        private string machineCode;
        private string moldNumber;
        private string partCode;
        private DateTime startTime;
        private DateTime endTime;
        private int quantity;
        private int colorSX;
        private int confirmSX;
     

        public long Id { get => id; set => id = value; }
        public int IdResource { get => idResource; set => idResource = value; }
        public string MachineCode { get => machineCode; set => machineCode = value; }
        public string MoldNumber { get => moldNumber; set => moldNumber = value; }
        public string PartCode { get => partCode; set => partCode = value; }
        public DateTime StartTime { get => startTime; set => startTime = value; }
        public DateTime EndTime { get => endTime; set => endTime = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public int ColorSX { get => colorSX; set => colorSX = value; }
        public int ConfirmSX { get => confirmSX; set => confirmSX = value; }
       
    }
}
