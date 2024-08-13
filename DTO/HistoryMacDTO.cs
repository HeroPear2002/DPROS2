using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HistoryMacDTO
    {
        public HistoryMacDTO(string PartCode, DateTime DateIn, string Employess, int NumberTo, int NumberFrom, DateTime Lot)
        {
            this.PartCode = PartCode;
            this.DateIn = DateIn;
            this.Employess = Employess;
            this.NumberTo = NumberTo;
            this.NumberFrom = NumberFrom;
            this.Lot = Lot;
        }
        public HistoryMacDTO(DataRow row)
        {
            this.PartCode = row["PartCode"].ToString();
            this.DateIn = (DateTime)row["DateIn"];
            this.Employess = row["Employess"].ToString();
            this.NumberTo = (int)row["NumberTo"];
            this.NumberFrom = (int)row["NumberFrom"];
            this.Lot = (DateTime)row["Lot"];
        }
        private string partCode;
        private DateTime dateIn;
        private string employess;
        private int numberTo;
        private int numberFrom;
        private DateTime lot;

        public string PartCode { get => partCode; set => partCode = value; }
        public DateTime DateIn { get => dateIn; set => dateIn = value; }
        public string Employess { get => employess; set => employess = value; }
        public int NumberTo { get => numberTo; set => numberTo = value; }
        public int NumberFrom { get => numberFrom; set => numberFrom = value; }
        public DateTime Lot { get => lot; set => lot = value; }
    }
}
