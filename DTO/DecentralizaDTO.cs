using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class DecentralizaDTO
    {
        public DecentralizaDTO(int Id, string Decentraliza)
        {
            this.Id = Id;
            this.Decentraliza = Decentraliza;
        }
        public DecentralizaDTO(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.Decentraliza = row["Decentraliza"].ToString();
        }
        private int id;
        private string decentraliza;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
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
    }
}
