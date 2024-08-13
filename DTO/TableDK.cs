using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class TableDK
    {
        public TableDK(long Id,int IdResource,long IdSX,DateTime StartTime,DateTime EndTime,int ColorDK,int ConfirmDK, DateTime WarnTime, string Note)
        {
            this.Id = Id;
            this.IdResource = IdResource;
            this.IdSX = IdSX;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            this.ColorDK = ColorDK;
            this.ConfirmDK = ConfirmDK;
            this.WarnTime = WarnTime;
            this.Note = Note;
        }
        public TableDK(DataRow row)
        {
            this.Id = (long)row["Id"];
            this.IdResource = (int)row["IdResource"];
            this.IdSX = (long)row["IdSX"];
            this.StartTime = (DateTime)row["StartTime"];
            this.EndTime = (DateTime)row["EndTime"];
            this.ColorDK = (int)row["ColorDK"];
            this.ConfirmDK = (int)row["ConfirmDK"];
            this.WarnTime = (DateTime)row["WarnTime"];
            this.Note = row["Note"].ToString();
        }
        private long id;
        private int idResource;
        private long idSX;
        private DateTime startTime;
        private DateTime endTime;
        private int colorDK;
        private int confirmDK;
        private DateTime warnTime;
        private string note;
        public long Id { get => id; set => id = value; }
        public int IdResource { get => idResource; set => idResource = value; }
        public long IdSX { get => idSX; set => idSX = value; }
        public DateTime StartTime { get => startTime; set => startTime = value; }
        public DateTime EndTime { get => endTime; set => endTime = value; }
        public int ColorDK { get => colorDK; set => colorDK = value; }
        public int ConfirmDK { get => confirmDK; set => confirmDK = value; }
        public DateTime WarnTime { get => warnTime; set => warnTime = value; }
        public string Note { get => note; set => note = value; }
    }
}
