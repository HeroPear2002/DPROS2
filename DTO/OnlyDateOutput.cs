using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class OnlyDateOutput
    {
        public OnlyDateOutput(DateTime DateOutput)
        {
            this.DateOutput = DateOutput;
        }
        public OnlyDateOutput(DataRow row)
        {
            this.DateOutput = DateTime.Parse(row["DateOutput"].ToString());
        }
        private DateTime dateOutput;

        public DateTime DateOutput { get => dateOutput; set => dateOutput = value; }
    }
}
