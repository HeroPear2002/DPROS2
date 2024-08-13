using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CheckDeviceDTO
    {
        public CheckDeviceDTO(long IdRelationShip, long IdCategory, string Employess, string MachineCode, string Note, string NameCategory, string Detail, string Method, string Limit, string Result, int TimeTT, int Timer, string Reality)
        {
            this.IdRelationShip = IdRelationShip;
            this.IdCategory = IdCategory;
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
            this.Reality = Reality;
        }
        public CheckDeviceDTO(DataRow row)
        {
            this.IdRelationShip = (long)row["IdRelationShip"];
            this.IdCategory = (long)row["IdCategory"];
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
            this.Reality = row["Reality"].ToString();
        }
        private long idRelationShip;
        private string machineCode;
        private long idCategory;
        private string nameCategory;
        private string detail;
        private string method;
        private string limit;
        private int timeTT;
        private int timer;
        private string reality;
        private string employess;
        private string result;
        private string note;

        public long IdRelationShip { get => idRelationShip; set => idRelationShip = value; }
        public string MachineCode { get => machineCode; set => machineCode = value; }
        public long IdCategory { get => idCategory; set => idCategory = value; }
        public string NameCategory { get => nameCategory; set => nameCategory = value; }
        public string Detail { get => detail; set => detail = value; }
        public string Method { get => method; set => method = value; }
        public string Limit { get => limit; set => limit = value; }
        public int TimeTT { get => timeTT; set => timeTT = value; }
        public int Timer { get => timer; set => timer = value; }
        public string Reality { get => reality; set => reality = value; }
        public string Employess { get => employess; set => employess = value; }
        public string Result { get => result; set => result = value; }
        public string Note { get => note; set => note = value; }
    }
}
