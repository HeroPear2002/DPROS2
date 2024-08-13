using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class CoupontEmployess
    {
        public CoupontEmployess(string EmployessCode,string EmployessName,DateTime DateInput,DateTime DateHis,int PointEr,int PointNow,string Note,string Number)
        {
            this.EmployessCode = EmployessCode;
            this.EmployessName = EmployessName;
            this.DateInput = DateInput;
            this.DateHis = DateHis;
            this.PointEr = PointEr;
            this.PointNow = PointNow;
            this.Note = Note;
            this.Number = Number;
        }
        private string employessCode;
        private string employessName;
        private DateTime dateInput;
        private DateTime dateHis;
        private int pointEr;
        private int pointNow;
        private string note;
        private string number;

        public string EmployessCode { get => employessCode; set => employessCode = value; }
        public string EmployessName { get => employessName; set => employessName = value; }
        public DateTime DateInput { get => dateInput; set => dateInput = value; }
        public DateTime DateHis { get => dateHis; set => dateHis = value; }
        public int PointEr { get => pointEr; set => pointEr = value; }
        public int PointNow { get => pointNow; set => pointNow = value; }
        public string Note { get => note; set => note = value; }
        public string Number { get => number; set => number = value; }
    }
}
