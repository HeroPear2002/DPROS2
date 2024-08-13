using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class TableTT
    {
        public TableTT(long Id,int IdResource,long IdSX,DateTime StartTime,DateTime EndTime,int Quantity,int ColorTT,int ConfirmTT,DateTime MaxTime,string Note)
        {
            this.Id = Id;
            this.IdResource = IdResource;
            this.IdSX = IdSX;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            this.Quantity = Quantity;
            this.ColorTT = ColorTT;
            this.ConfirmTT = ConfirmTT;
            this.MaxTime = MaxTime;
            this.Note = Note;
        }
        public TableTT(DataRow row)
        {
            this.Id = (long)row["Id"];
            this.IdResource = (int)row["IdResource"];
            this.IdSX = (long)row["IdSX"];
            this.StartTime = (DateTime)row["StartTime"];
            this.EndTime = (DateTime)row["EndTime"];
            this.Quantity = (int)row["Quantity"];
            this.ColorTT = (int)row["ColorTT"];
            this.ConfirmTT = (int)row["ConfirmTT"];
            this.MaxTime = (DateTime)row["MaxTime"];
            this.Note = row["Note"].ToString();
        }
        private long id;
        private int idResource;
        private long idSX;
        private DateTime startTime;
        private DateTime endTime;
        private int quantity;
        private int colorTT;
        private int confirmTT;
        private DateTime maxTime;
        private string note;
        public long Id { get => id; set => id = value; }
        public int IdResource { get => idResource; set => idResource = value; }
        public long IdSX { get => idSX; set => idSX = value; }
        public DateTime StartTime { get => startTime; set => startTime = value; }
        public DateTime EndTime { get => endTime; set => endTime = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public int ColorTT { get => colorTT; set => colorTT = value; }
        public int ConfirmTT { get => confirmTT; set => confirmTT = value; }
        public DateTime MaxTime { get => maxTime; set => maxTime = value; }
        public string Note { get => note; set => note = value; }
    }
}
