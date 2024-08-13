using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class TableXH
    {
        public TableXH(long Id,int IdResource,long IdSX,DateTime StartTime,DateTime EndTime,int ColorXH, int ConfirmXH, DateTime WarnTime)
        {
            this.Id = Id;
            this.IdResource = IdResource;
            this.IdSX = IdSX;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            this.ColorXH = ColorXH;
            this.ConfirmXH = ConfirmXH;
            this.WarnTime = WarnTime;
            this.Note = Note;
        }
        public TableXH(DataRow row)
        {
            this.Id = (long)row["Id"];
            this.IdResource = (int)row["IdResource"];
            this.IdSX = (long)row["IdSX"];
            this.StartTime = (DateTime)row["StartTime"];
            this.EndTime = (DateTime)row["EndTime"];
            this.ColorXH = (int)row["ColorXH"];
            this.ConfirmXH = (int)row["ConfirmXH"];
            this.WarnTime = (DateTime)row["WarnTime"];
            this.Note = row["Note"].ToString();
        }
        private long id;
        private int idResource;
        private long idSX;
        private DateTime startTime;
        private DateTime endTime;
        private int colorXH;
        private int confirmXH;
        private DateTime warnTime;
        private string note;
        public long Id { get => id; set => id = value; }
        public int IdResource { get => idResource; set => idResource = value; }
        public long IdSX { get => idSX; set => idSX = value; }
        public DateTime StartTime { get => startTime; set => startTime = value; }
        public DateTime EndTime { get => endTime; set => endTime = value; }
        public int ColorXH { get => colorXH; set => colorXH = value; }
        public int ConfirmXH { get => confirmXH; set => confirmXH = value; }
        public DateTime WarnTime { get => warnTime; set => warnTime = value; }
        public string Note { get => note; set => note = value; }
    }
}
