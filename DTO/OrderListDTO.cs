using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class OrderListDTO
    {
        public OrderListDTO(string OrderCode,DateTime DateOrder,string Employess,string Room,string DVT,string NumberHQ,string Bill)
        {
            this.OrderCode = OrderCode;
            this.DateOrder = DateOrder;
            this.Employess = Employess;
            this.Room = Room;
            this.DVT = DVT;
            this.NumberHQ = NumberHQ;
            this.Bill = Bill;
        }
        public OrderListDTO(DataRow row)
        {
            this.OrderCode = row["OrderCode"].ToString();
            this.DateOrder = (DateTime)row["DateOrder"];
            this.Employess = row["Employess"].ToString();
            this.Room = row["Room"].ToString();
            this.DVT = row["DVT"].ToString();
            this.NumberHQ = row["NumberHQ"].ToString();
            this.Bill = row["Bill"].ToString();
        }
        private string orderCode;
        private DateTime dateOrder;
        private string employess;
        private string room;
        private string dVT;
        private string numberHQ;
        private string bill;

        public string OrderCode { get => orderCode; set => orderCode = value; }
        public DateTime DateOrder { get => dateOrder; set => dateOrder = value; }
        public string Employess { get => employess; set => employess = value; }
        public string Room { get => room; set => room = value; }
        public string DVT { get => dVT; set => dVT = value; }
        public string NumberHQ { get => numberHQ; set => numberHQ = value; }
        public string Bill { get => bill; set => bill = value; }
    }
}
