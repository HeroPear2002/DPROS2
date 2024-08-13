using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TableEmployess
    {
        public TableEmployess(string EmployessCode, string EmployessName, float PointDefault, int PointPl, int PointEr, float PointNow, string RoomCode, int CountError, int CountPlus, int CountMonth, int Months, string Super)
        {
            this.EmployessCode = EmployessCode;
            this.EmployessName = EmployessName;
            this.PointDefault = PointDefault;
            this.PointEr = PointEr;
            this.PointPl = PointPl;
            this.PointNow = PointNow;
            this.RoomCode = RoomCode;
            this.CountError = CountError;
            this.CountPlus = CountPlus;
            this.CountMonth = CountMonth;
            this.Months = Months;
            this.Super = Super;
        }
        public TableEmployess(DataRow row)
        {
            this.EmployessCode = row["EmployessCode"].ToString();
            this.EmployessName = row["EmployessName"].ToString();
            this.PointDefault = (float)Convert.ToDouble(row["PointDefault"].ToString());
            this.PointEr = (int)row["PointEr"];
            this.PointPl = (int)row["PointPl"];
            this.PointNow = (float)Convert.ToDouble(row["PointNow"].ToString());
            this.RoomCode = row["RoomCode"].ToString();
            this.CountError = (int)row["CountError"];
            this.CountPlus = (int)row["CountPlus"];
            this.CountMonth = (int)row["CountMonth"];
            this.Months = (int)row["Months"];
            this.Super = row["Super"].ToString();
        }
        private string employessCode;
        private string employessName;
        private float pointDefault;
        private int pointPl;
        private int pointEr;
        private float pointNow;
        private string roomCode;
        private int countError;
        private int countPlus;
        private int countMonth;
        private int months;
        private string super;

        public string EmployessCode { get => employessCode; set => employessCode = value; }
        public string EmployessName { get => employessName; set => employessName = value; }
        public float PointDefault { get => pointDefault; set => pointDefault = value; }
        public int PointPl { get => pointPl; set => pointPl = value; }
        public int PointEr { get => pointEr; set => pointEr = value; }
        public float PointNow { get => pointNow; set => pointNow = value; }
        public string RoomCode { get => roomCode; set => roomCode = value; }
        public int CountError { get => countError; set => countError = value; }
        public int CountPlus { get => countPlus; set => countPlus = value; }
        public int CountMonth { get => countMonth; set => countMonth = value; }
        public int Months { get => months; set => months = value; }
        public string Super { get => super; set => super = value; }
    }
}
