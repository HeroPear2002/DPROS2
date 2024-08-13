using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class IvenstoryDTO
    {
        public IvenstoryDTO(long Id , string PartCode, DateTime DateInput, DateTime DateManufacturi, int CountInput, int Iventory,string MoldNumber,string MachineCode,int CountXuat,string Name, int IdWareHouse,string NameStatus,string Yellow,string Lot,string Note2,string Note,string FactoryCode)
        {
            this.Id = Id;
            this.PartCode = PartCode;
            this.DateInput = DateInput;
            this.DateManufacturi = DateManufacturi;
            this.CountInput = CountInput;
            this.Iventory = Iventory;
            this.MoldNumber = MoldNumber;
            this.MachineCode = MachineCode;
            this.CountXuat = CountXuat;
            this.Name = Name;
            this.IdWareHouse = IdWareHouse;
            this.NameStatus = NameStatus;
            this.Yellow = Yellow;
            this.Lot = Lot;
            this.Note2 = Note2;
            this.Note = Note;
            this.FactoryCode = FactoryCode;
        }
        public IvenstoryDTO(DataRow row)
        {
            this.Id =(long)row["Id"];
            this.PartCode = row["PartCode"].ToString();
            this.DateInput = (DateTime)row["DateInput"];
            this.DateManufacturi = (DateTime)row["DateManufacturi"];
            this.CountInput =(int) row["CountInput"];
            this.Iventory = (int)row["Iventory"];
            this.MoldNumber = row["MoldNumber"].ToString();
            this.MachineCode = row["MachineCode"].ToString();
            this.CountXuat = (int)row["CountXuat"];
            this.Name = row["Name"].ToString();
            this.IdWareHouse = (int)row["IdWareHouse"];
            this.NameStatus = row["NameStatus"].ToString();
            this.Yellow = row["Yellow"].ToString();
            this.Lot = row["Lot"].ToString();
            this.Note2 = row["Note2"].ToString();
            this.Note = row["Note"].ToString();
            this.FactoryCode = row["FactoryCode"].ToString();
        }
        private long id;
        private string partCode;
        private DateTime dateInput;
        private DateTime dateManufacturi;
        private int countInput;
        private int iventory;
        private string moldNumber;
        private string machineCode;
        private int countXuat;
        private string name;
        private int idWareHouse;
        private string nameStatus;
        private string yellow;
        private string lot;
        private string note2;
        private string note;
        private string factoryCode;
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

        public DateTime DateInput
        {
            get
            {
                return dateInput;
            }

            set
            {
                dateInput = value;
            }
        }

        public int CountInput
        {
            get
            {
                return countInput;
            }

            set
            {
                countInput = value;
            }
        }

        public int Iventory
        {
            get
            {
                return iventory;
            }

            set
            {
                iventory = value;
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

        public int CountXuat
        {
            get
            {
                return countXuat;
            }

            set
            {
                countXuat = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public DateTime DateManufacturi
        {
            get
            {
                return dateManufacturi;
            }

            set
            {
                dateManufacturi = value;
            }
        }

        public long Id
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

        public int IdWareHouse
        {
            get
            {
                return idWareHouse;
            }

            set
            {
                idWareHouse = value;
            }
        }

        public string NameStatus
        {
            get
            {
                return nameStatus;
            }

            set
            {
                nameStatus = value;
            }
        }

        public string Yellow
        {
            get
            {
                return yellow;
            }

            set
            {
                yellow = value;
            }
        }

        public string Lot
        {
            get
            {
                return lot;
            }

            set
            {
                lot = value;
            }
        }

        public string Note2 { get => note2; set => note2 = value; }
        public string Note { get => note; set => note = value; }
        public string FactoryCode { get => factoryCode; set => factoryCode = value; }
    }
}
