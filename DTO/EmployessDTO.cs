using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EmployessDTO
    {
        public EmployessDTO(string EmployessCode, string EmployessName, DateTime DateInput, string RoomCode, string Super, int Status)
        {
            this.EmployessCode = EmployessCode;
            this.EmployessName = EmployessName;
            this.DateInput = DateInput;
            this.RoomCode = RoomCode;
            this.Super = Super;
            this.Status = Status;
        }
        public EmployessDTO(DataRow row)
        {
            this.EmployessCode = row["EmployessCode"].ToString().ToUpper();
            this.EmployessName = row["EmployessName"].ToString().ToUpper();
            this.DateInput = (DateTime)row["DateInput"];
            this.RoomCode = row["RoomCode"].ToString();
            this.Super = row["Super"].ToString();
            this.Status = (int)row["Status"];

        }
        private string employessCode;
        private string employessName;
        private DateTime dateInput;
        private string roomCode;
        private string super;
        private int status;


        public string EmployessCode
        {
            get
            {
                return employessCode;
            }

            set
            {
                employessCode = value;
            }
        }

        public string EmployessName
        {
            get
            {
                return employessName;
            }

            set
            {
                employessName = value;
            }
        }

        public DateTime DateInput { get => dateInput; set => dateInput = value; }
        public string RoomCode { get => roomCode; set => roomCode = value; }
        public string Super { get => super; set => super = value; }
        public int Status { get => status; set => status = value; }
    }
}
