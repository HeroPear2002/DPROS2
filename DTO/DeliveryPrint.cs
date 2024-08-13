using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class DeliveryPrint
    {
        public DeliveryPrint(int Id,string DeCode,string POCode,string PartCode,string PartName,int Quantity,int CountPart,int CountBox,string Factory,string DateOut,string Time,string CarNumber)
        {
            this.Id = Id;
            this.DeCode = DeCode;
            this.POCode = POCode;
            this.PartCode = PartCode;
            this.PartName = PartName;
            this.Quantity = Quantity;
            this.CountPart = CountPart;
            this.CountBox = CountBox;
            this.Factory = Factory;
            this.DateOut = DateOut;
            this.Time = Time;
            this.CarNumber = CarNumber;
        }
        private int id;
        private string deCode;
        private string pOCode;
        private string partCode;
        private string partName;
        private int quantity;
        private int countPart;
        private int countBox;
        private string factory;
        private string dateOut;
        private string time;
        private string carNumber;

        public int Id { get => id; set => id = value; }
        public string DeCode { get => deCode; set => deCode = value; }
        public string POCode { get => pOCode; set => pOCode = value; }
        public string PartCode { get => partCode; set => partCode = value; }
        public string PartName { get => partName; set => partName = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public int CountPart { get => countPart; set => countPart = value; }
        public int CountBox { get => countBox; set => countBox = value; }
        public string Factory { get => factory; set => factory = value; }
        public string DateOut { get => dateOut; set => dateOut = value; }
        public string Time { get => time; set => time = value; }
        public string CarNumber { get => carNumber; set => carNumber = value; }
    }
}
