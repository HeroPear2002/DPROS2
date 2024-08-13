using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HistoryDeviceDTO
    {
        public HistoryDeviceDTO(long Id, long IdRelationShip, long IdCategory, string DataCount, int StatusHD, DateTime DateCheck, string Employess, string MachineCode, string Note, string NameCategory, string Detail, string Method, string Limit, string Result, int TimeTT, int Timer)
        {
            this.Id = Id;
            this.IdRelationShip = IdRelationShip;
            this.IdCategory = IdCategory;
            this.DataCount = DataCount;
            this.StatusHD = StatusHD;
            this.DateCheck = DateCheck;
            this.Employess = Employess;
            this.MachineCode = MachineCode;
            this.Note = Note;
            this.NameCategory = NameCategory;
            this.Detail = Detail;
            this.Method = Method;
            this.Limit = Limit;
            this.Result = Result;
            this.TimeTT = TimeTT;
            this.Timer = Timer;
        }
        public HistoryDeviceDTO(DataRow row)
        {
            this.Id = (long)row["Id"];
            this.IdRelationShip = (long)row["IdRelationShip"];
            this.IdCategory = (long)row["IdCategory"];
            this.DataCount = row["DataCount"].ToString();
            this.StatusHD = (int)row["StatusHD"];
            this.DateCheck = (DateTime)row["DateCheck"];
            this.Employess = row["Employess"].ToString();
            this.MachineCode = row["MachineCode"].ToString();
            this.Note = row["Note"].ToString();
            this.NameCategory = row["NameCategory"].ToString();
            this.Detail = row["Detail"].ToString();
            this.Method = row["Method"].ToString();
            this.Limit = row["Limit"].ToString();
            this.Result = row["Result"].ToString();
            this.TimeTT = (int)row["TimeTT"];
            this.Timer = (int)row["Timer"];
        }
        private long id;
        private long idRelationShip;
        private long idCategory;
        private string dataCount;
        private int statusHD;
        private DateTime dateCheck;
        private string employess;
        private string machineCode;
        private string nameCategory;
        private string detail;
        private string method;
        private string limit;
        private string result;
        private string note;
        private int timeTT;
        private int timer;
        //,TimeTT,Timer

        public long Id { get => id; set => id = value; }
        public long IdRelationShip { get => idRelationShip; set => idRelationShip = value; }
        public long IdCategory { get => idCategory; set => idCategory = value; }
        public string DataCount { get => dataCount; set => dataCount = value; }
        public int StatusHD { get => statusHD; set => statusHD = value; }
        public DateTime DateCheck { get => dateCheck; set => dateCheck = value; }
        public string Employess { get => employess; set => employess = value; }
        public string MachineCode { get => machineCode; set => machineCode = value; }
        public string Note { get => note; set => note = value; }
        public string NameCategory { get => nameCategory; set => nameCategory = value; }
        public string Detail { get => detail; set => detail = value; }
        public string Method { get => method; set => method = value; }
        public string Limit { get => limit; set => limit = value; }
        public string Result { get => result; set => result = value; }
        public int TimeTT { get => timeTT; set => timeTT = value; }
        public int Timer { get => timer; set => timer = value; }
    }
}
