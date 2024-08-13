using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AccountDTO
    {
        public AccountDTO(string UserName, string DisplayName, string PassWord, int Type, string Decentraliza, string EMail,string RoomCode)
        {
            this.UserName = UserName;
            this.DisplayName = DisplayName;
            this.PassWord = PassWord;
            this.Type = Type;
            this.Decentraliza = Decentraliza;
            this.EMail = EMail;
            this.RoomCode = RoomCode;
        }
        public AccountDTO(DataRow row)
        {
            this.UserName = row["UserName"].ToString();
            this.DisplayName = row["DisplayName"].ToString();
            this.PassWord = row["PassWord"].ToString();
            this.Type = (int)row["Type"];
            this.Decentraliza = row["Decentraliza"].ToString();
            this.EMail = row["EMail"].ToString();
            this.RoomCode = row["RoomCode"].ToString();
        }
        private string userName;
        private string displayName;
        private string passWord;
        private int type;
        private string decentraliza;
        private string eMail;
        private string roomCode;

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }

        public string DisplayName
        {
            get
            {
                return displayName;
            }

            set
            {
                displayName = value;
            }
        }

        public string PassWord
        {
            get
            {
                return passWord;
            }

            set
            {
                passWord = value;
            }
        }

        public int Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public string Decentraliza
        {
            get
            {
                return decentraliza;
            }

            set
            {
                decentraliza = value;
            }
        }

        public string EMail { get => eMail; set => eMail = value; }
        public string RoomCode { get => roomCode; set => roomCode = value; }
    }
}
