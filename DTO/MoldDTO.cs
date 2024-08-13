using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MoldDTO
    {
        public MoldDTO(string MoldCode, string MoldName, string MoldNumber,string MoldModel,string Maker,string InputWhere,string Employess,string Note,DateTime? DateSX,DateTime? DateInput,int ShotCount)
        {
            this.MoldCode = MoldCode;
            this.MoldName = MoldName;
            this.MoldNumber = MoldNumber;
            this.MoldModel = MoldModel;
            this.Maker = Maker;
            this.InputWhere = InputWhere;
            this.Employess = Employess;
            this.Note = Note;
            this.DateSX = DateSX;
            this.DateInput = DateInput;
            this.ShotCount = ShotCount;
        }
        public MoldDTO(DataRow row)
        {
            this.MoldCode = row["MoldCode"].ToString();
            this.MoldName = row["MoldName"].ToString();
            this.MoldNumber = row["MoldNumber"].ToString();
            this.MoldModel = row["MoldModel"].ToString();
            this.Maker = row["Maker"].ToString();
            this.InputWhere = row["InputWhere"].ToString();
            this.Employess = row["Employess"].ToString();
            this.Note = row["Note"].ToString();
            this.ShotCount = (int)row["ShotCount"];
            var checkDateSX = row["DateSX"];
            if (checkDateSX.ToString() != "")
            {
                this.DateSX = (DateTime)checkDateSX;
            }
            var checkDateInput = row["DateInput"];
            if(checkDateInput.ToString() !="")
            {
                this.DateInput = (DateTime)checkDateInput;
            }
           
        }
        private string moldCode;
        private string moldName;
        private string moldNumber;
        private string moldModel;
        private string maker;
        private string inputWhere;
        private string employess;
        private string note;
        private DateTime? dateSX;
        private DateTime? dateInput;
        private int shotCount;
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

        public string MoldName
        {
            get
            {
                return moldName;
            }

            set
            {
                moldName = value;
            }
        }

        public string MoldNumber
        {
            get
            {
                return moldNumber;
            }

            set
            {
                moldNumber = value;
            }
        }

        public string MoldModel
        {
            get
            {
                return moldModel;
            }

            set
            {
                moldModel = value;
            }
        }

        public string Maker
        {
            get
            {
                return maker;
            }

            set
            {
                maker = value;
            }
        }

        public string InputWhere
        {
            get
            {
                return inputWhere;
            }

            set
            {
                inputWhere = value;
            }
        }

        public string Employess
        {
            get
            {
                return employess;
            }

            set
            {
                employess = value;
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

      

        public DateTime? DateSX
        {
            get
            {
                return dateSX;
            }

            set
            {
                dateSX = value;
            }
        }

        public DateTime? DateInput
        {
            get
            {
                return dateInput;
            }

            set
            {
                dateInput = value;
            }
        }

        public int ShotCount
        {
            get
            {
                return shotCount;
            }

            set
            {
                shotCount = value;
            }
        }
    }
}
