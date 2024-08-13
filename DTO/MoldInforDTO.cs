using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MoldInforDTO
    {
        public MoldInforDTO(string MoldCode, string Category, string Note, string StatusMold, string Cav, string CavNG, string PlanMold, int ShotTT, int ShotTC, int TotalShot, int Confirm, DateTime DateCheck, int Warn)
        {
            this.MoldCode = MoldCode;
            this.Category = Category;
            this.Note = Note;
            this.StatusMold = StatusMold;
            this.Cav = Cav;
            this.CavNG = CavNG;
            this.PlanMold = PlanMold;
            this.ShotTT = ShotTT;
            this.ShotTC = ShotTC;
            this.TotalShot = TotalShot;
            this.Confirm = Confirm;
            this.DateCheck = DateCheck;
            this.Warn = Warn;
        }
        public MoldInforDTO(DataRow row)
        {
            this.MoldCode = row["MoldCode"].ToString();
            this.Category = row["Category"].ToString();
            this.Note = row["Note"].ToString();
            this.StatusMold = row["StatusMold"].ToString();
            this.Cav = row["Cav"].ToString();
            this.CavNG = row["CavNG"].ToString();
            this.PlanMold = row["PlanMold"].ToString();
            this.ShotTT = (int)row["ShotTT"];
            this.ShotTC = (int)row["ShotTC"];
            this.TotalShot = (int)row["TotalShot"];
            this.Confirm = (int)row["Confirm"];
            this.DateCheck = (DateTime)row["DateCheck"];
            this.Warn = (int)row["Warn"];
        }
        private string moldCode;
        private string category;
        private string note;
        private string statusMold;
        private string cav;
        private string cavNG;
        private string planMold;
        private int shotTC;
        private int shotTT;
        private int totalShot;
        private int confirm;
        private DateTime dateCheck;
        private int warn;

        public string MoldCode
        {
            get
            {
                return moldCode;
            }

            set
            {
                moldCode = value;
            }
        }

        public string Category
        {
            get
            {
                return category;
            }

            set
            {
                category = value;
            }
        }

        public string Note
        {
            get
            {
                return note;
            }

            set
            {
                note = value;
            }
        }

        public string StatusMold
        {
            get
            {
                return statusMold;
            }

            set
            {
                statusMold = value;
            }
        }

        public string Cav
        {
            get
            {
                return cav;
            }

            set
            {
                cav = value;
            }
        }

        public string CavNG
        {
            get
            {
                return cavNG;
            }

            set
            {
                cavNG = value;
            }
        }

        public string PlanMold
        {
            get
            {
                return planMold;
            }

            set
            {
                planMold = value;
            }
        }

        public int ShotTC
        {
            get
            {
                return shotTC;
            }

            set
            {
                shotTC = value;
            }
        }

        public int ShotTT
        {
            get
            {
                return shotTT;
            }

            set
            {
                shotTT = value;
            }
        }

        public int TotalShot
        {
            get
            {
                return totalShot;
            }

            set
            {
                totalShot = value;
            }
        }

        public int Confirm
        {
            get
            {
                return confirm;
            }

            set
            {
                confirm = value;
            }
        }

        public DateTime DateCheck { get => dateCheck; set => dateCheck = value; }
        public int Warn { get => warn; set => warn = value; }
    }
}
