using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class ListMailPOMaterial
    {
        public ListMailPOMaterial(int StatusMail,string PoCode)
        {
            this.StatusMail = StatusMail;
            this.PoCode = PoCode;
        }
        private int statusMail;
        private string poCode;

        public int StatusMail { get => statusMail; set => statusMail = value; }
        public string PoCode { get => poCode; set => poCode = value; }
    }
}
