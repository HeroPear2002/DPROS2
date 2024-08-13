using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ReportCTSX
    {
        public ReportCTSX(string PartCode, string PartName, string MaterialCode, string MaterialName, string MoldNumber, string MachineCode, int Quantity, int QuantityPart, int QuantityBox, float Hour, DateTime Date, float TotalWeight, string Employess, string BarCode, string NoteSX, string NoteNL, string Customer, string StatusMold, string TimeMin, string WeightMin)
        {
            this.PartCode = PartCode;
            this.PartName = PartName;
            this.MaterialCode = MaterialCode;
            this.MaterialName = MaterialName;
            this.MoldNumber = MoldNumber;
            this.MachineCode = MachineCode;
            this.Quantity = Quantity;
            this.QuantityPart = QuantityPart;
            this.Hour = Hour;
            this.Date = Date;
            this.TotalWeight = TotalWeight;
            this.QuantityBox = QuantityBox;
            this.Employess = Employess;
            this.BarCode = BarCode;
            this.NoteSX = NoteSX;
            this.NoteNL = NoteNL;
            this.Customer = Customer;
            this.StatusMold = StatusMold;
            this.TimeMin = TimeMin;
            this.WeightMin = WeightMin;
        }
        public ReportCTSX(DataRow row)
        {
            this.PartCode = row["PartCode"].ToString();
            this.PartName = row["PartName"].ToString();
            this.MaterialCode = row["MaterialCode"].ToString();
            this.MaterialName = row["MaterialName"].ToString();
            this.MoldNumber = row["MoldNumber"].ToString();
            this.MachineCode = row["MachineCode"].ToString();
            this.Quantity = (int)row["Quantity"];
            this.QuantityPart = (int)row["QuantityPart"];
            this.Hour = (float)Convert.ToDouble(row["Hour"].ToString());
            this.Date = (DateTime)row["Date"];
            this.TotalWeight = (float)Convert.ToDouble(row["TotalWeight"].ToString());
            this.QuantityBox = (int)row["QuantityBox"];
            this.Employess = row["Employess"].ToString();
            this.BarCode = row["BarCode"].ToString();
            this.NoteSX = row["NoteSX"].ToString();
            this.NoteNL = row["NoteNL"].ToString();
            this.Customer = row["Customer"].ToString();
            this.StatusMold = row["StatusMold"].ToString();
            this.TimeMin = row["TimeMin"].ToString();
            this.WeightMin = row["WeightMin"].ToString();
        }
        private string partCode;
        private string partName;
        private string materialCode;
        private string materialName;
        private string moldNumber;
        private string machineCode;
        private int quantity;
        private int quantityPart;
        private int quantityBox;
        private float hour;
        private DateTime date;
        private float totalWeight;
        private string employess;
        private string barCode;
        private string noteSX;
        private string noteNL;
        private string customer;
        private string statusMold;
        private string timeMin;
        private string weightMin;
        public string PartCode
        {
            get
            {
                return partCode;
            }

            set
            {
                partCode = value;
            }
        }

        public string PartName
        {
            get
            {
                return partName;
            }

            set
            {
                partName = value;
            }
        }

        public string MaterialCode
        {
            get
            {
                return materialCode;
            }

            set
            {
                materialCode = value;
            }
        }

        public string MaterialName
        {
            get
            {
                return materialName;
            }

            set
            {
                materialName = value;
            }
        }



        public string MachineCode
        {
            get
            {
                return machineCode;
            }

            set
            {
                machineCode = value;
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

        public int QuantityPart
        {
            get
            {
                return quantityPart;
            }

            set
            {
                quantityPart = value;
            }
        }

        public float Hour
        {
            get
            {
                return hour;
            }

            set
            {
                hour = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        public float TotalWeight
        {
            get
            {
                return totalWeight;
            }

            set
            {
                totalWeight = value;
            }
        }

        public int QuantityBox
        {
            get
            {
                return quantityBox;
            }

            set
            {
                quantityBox = value;
            }
        }

        public string MoldNumber
        {
            get
            {
                return moldNumber;
            }

            set
            {
                moldNumber = value;
            }
        }

        public string Employess
        {
            get
            {
                return employess;
            }

            set
            {
                employess = value;
            }
        }

        public string BarCode
        {
            get
            {
                return barCode;
            }

            set
            {
                barCode = value;
            }
        }

        public string NoteSX { get => noteSX; set => noteSX = value; }
        public string NoteNL { get => noteNL; set => noteNL = value; }
        public string Customer { get => customer; set => customer = value; }
        public string StatusMold { get => statusMold; set => statusMold = value; }
        public string TimeMin { get => timeMin; set => timeMin = value; }
        public string WeightMin { get => weightMin; set => weightMin = value; }
    }
}
