using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class BoxCheckDTO
    {
        public BoxCheckDTO(long Id,string CheckCode,string PartCode, DateTime DateCheck,string EmployessCheck,int CountCheck,
            string LotNo, string QrCode,int StatusCheck,string Note,string MoldNumber,string MachineCode,string POCode)
        {
            this.Id = Id;
            this.CheckCode = CheckCode;
            this.PartCode = PartCode;
            this.DateCheck = DateCheck;
            this.EmployessCheck = EmployessCheck;
            this.CountCheck = CountCheck;
            this.LotNo = LotNo;
            this.QrCode = QrCode;
            this.StatusCheck = StatusCheck;
            this.Note = Note;
            this.MoldNumber = MoldNumber;
            this.MachineCode = MachineCode;
            this.POCode = POCode;
        }
        public BoxCheckDTO(DataRow row)
        {
            this.Id = (long)row["Id"];
            this.CheckCode = row["CheckCode"].ToString();
            this.PartCode = row["PartCode"].ToString();
            var checkDate = row["DateCheck"];
            if(checkDate.ToString() != "")
            this.DateCheck = (DateTime)checkDate;
            this.EmployessCheck = row["EmployessCheck"].ToString();
            this.CountCheck = (int)row["CountCheck"];
            this.LotNo = row["LotNo"].ToString();
            this.QrCode = row["QrCode"].ToString();
            this.StatusCheck = (int)row["StatusCheck"];
            this.Note = row["Note"].ToString();
            this.MoldNumber = row["MoldNumber"].ToString();
            this.MachineCode = row["MachineCode"].ToString();
            this.POCode = row["POCode"].ToString();
        }
        private long id;
        private string checkCode;
        private string partCode;
        private DateTime dateCheck;
        private string employessCheck;
        private int countCheck;
        private string lotNo;
        private string qrCode;
        private int statusCheck;
        private string moldNumber;
        private string machineCode;
        private string note;
        private string pOCode;
   
        public long Id { get => id; set => id = value; }
     
        public string PartCode { get => partCode; set => partCode = value; }
        public DateTime DateCheck { get => dateCheck; set => dateCheck = value; }
        public string EmployessCheck { get => employessCheck; set => employessCheck = value; }
        public int CountCheck { get => countCheck; set => countCheck = value; }
        public string LotNo { get => lotNo; set => lotNo = value; }
        public string QrCode { get => qrCode; set => qrCode = value; }
        public int StatusCheck { get => statusCheck; set => statusCheck = value; }
        public string Note { get => note; set => note = value; }
        public string CheckCode { get => checkCode; set => checkCode = value; }
        public string MoldNumber { get => moldNumber; set => moldNumber = value; }
        public string MachineCode { get => machineCode; set => machineCode = value; }
        public string POCode { get => pOCode; set => pOCode = value; }
    }
}
