using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ReportMacPart
    {
        public ReportMacPart(string PartCode, string PartName, string MoldNumber, string MachineCode, int CountPart, string BarCode, string QrCode, string Count, string LotNo, string DateTimeSTR, string Color, string BoxName, string FactoryCode, string FactoryName, string NameVN)
        {
            this.PartCode = PartCode;
            this.PartName = PartName;
            this.MoldNumber = MoldNumber;
            this.MachineCode = MachineCode;
            this.CountPart = CountPart;
            this.BarCode = BarCode;
            this.QrCode = QrCode;
            this.Count = Count;
            this.LotNo = LotNo;
            this.DateTimeSTR = DateTimeSTR;
            this.Color = Color;
            this.BoxName = BoxName;
            this.FactoryCode = FactoryCode;
            this.FactoryName = FactoryName;
            this.NameVN = NameVN;
        }
        public ReportMacPart(DataRow row)
        {
            this.PartCode = row["PartCode"].ToString();
            this.PartName = row["PartName"].ToString();
            this.MoldNumber = row["MoldNumber"].ToString();
            this.MachineCode = row["MachineCode"].ToString();
            this.CountPart = (int)row["CountPart"];
            this.BarCode = row["BarCode"].ToString();
            this.QrCode = row["QrCode"].ToString();
            this.Count = row["Count"].ToString();
            this.LotNo = row["LotNo"].ToString();
            this.DateTimeSTR = row["DateTimeSTR"].ToString();
            this.Color = row["Color"].ToString();
            this.BoxName = row["BoxName"].ToString();
            this.FactoryCode = row["FactoryCode"].ToString();
            this.FactoryName = row["FactoryName"].ToString();
            this.NameVN = row["NameVN"].ToString();
        }
        private string partCode;
        private string partName;
        private string moldNumber;
        private string machineCode;
        private int countPart;
        private string barCode;
        private string qrCode;
        private string count;
        private string lotNo;
        private string dateTimeSTR;
        private string color;
        private string boxName;
        private string factoryCode;
        private string factoryName;
        private string nameVN;
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

        public int CountPart
        {
            get
            {
                return countPart;
            }

            set
            {
                countPart = value;
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

        public string QrCode
        {
            get
            {
                return qrCode;
            }

            set
            {
                qrCode = value;
            }
        }

        public string Count
        {
            get
            {
                return count;
            }

            set
            {
                count = value;
            }
        }

        public string LotNo
        {
            get
            {
                return lotNo;
            }

            set
            {
                lotNo = value;
            }
        }

        public string DateTimeSTR
        {
            get
            {
                return dateTimeSTR;
            }

            set
            {
                dateTimeSTR = value;
            }
        }

        public string Color
        {
            get
            {
                return color;
            }

            set
            {
                color = value;
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

        public string FactoryCode { get => factoryCode; set => factoryCode = value; }
        public string FactoryName { get => factoryName; set => factoryName = value; }
        public string NameVN { get => nameVN; set => nameVN = value; }
    }
}
