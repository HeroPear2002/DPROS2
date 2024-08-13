using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class BoxNatureDTO
    {
        public BoxNatureDTO(int Id,string BoxName,int Quantity, string Note)
        {
            this.Id = Id;
            this.BoxName = BoxName;
            this.Quantity = Quantity;
            this.Note = Note;
        }
        public BoxNatureDTO(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.BoxName = row["BoxName"].ToString();
            this.Quantity = (int)row["Quantity"];
            this.Note = row["Note"].ToString();
        }
        private int id;
        private string boxName;
        private int quantity;
        private string note;

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

        public string BoxName
        {
            get
            {
                return boxName;
            }

            set
            {
                boxName = value;
            }
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                quantity = value;
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
    }
}
