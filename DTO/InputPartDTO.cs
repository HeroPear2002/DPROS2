using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class InputPartDTO
    {
        public InputPartDTO(string PartCode, DateTime DateInput, DateTime DateManufacturi, int CountInput, string Name, string MoldNumber, string MachineCode, string Employess, string NameStatus, string StyleInput, string Lot, long Id,string FactoryCode)
        {
            this.PartCode = PartCode;
            this.DateInput = DateInput;
            this.DateManufacturi = DateManufacturi;
            this.CountInput = CountInput;
            this.Name = Name;
            this.MoldNumber = MoldNumber;
            this.MachineCode = MachineCode;
            this.Employess = Employess;
            this.NameStatus = NameStatus;
            this.StyleInput = StyleInput;
            this.Lot = Lot;
            this.Id = Id;
            this.FactoryCode = FactoryCode;
        }
        public InputPartDTO(DataRow row)
        {
            this.PartCode = row["PartCode"].ToString();
            this.DateInput = (DateTime)row["DateInput"];
            this.DateManufacturi = (DateTime)row["DateManufacturi"];
            this.CountInput = (int)row["CountInput"];
            this.Name = row["Name"].ToString();
            this.MoldNumber = row["MoldNumber"].ToString();
            this.MachineCode = row["MachineCode"].ToString();
            this.Employess = row["Employess"].ToString();
            this.NameStatus = row["NameStatus"].ToString();
            this.StyleInput = row["StyleInput"].ToString();
            this.Lot = row["Lot"].ToString();
            this.Id = (long)row["Id"];
            this.FactoryCode = row["FactoryCode"].ToString();
        }
        private string partCode;
        private DateTime dateInput;
        private DateTime dateManufacturi;
        private int countInput;
        private string name;
        private string moldNumber;
        private string machineCode;
        private string employess;
        private string nameStatus;
        private string styleInput;
        private string lot;
        private long id;
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

        public string StyleInput
        {
            get
            {
                return styleInput;
            }

            set
            {
                styleInput = value;
            }
        }

        public string Lot { get => lot; set => lot = value; }
        public long Id { get => id; set => id = value; }
        public string FactoryCode { get => factoryCode; set => factoryCode = value; }
    }
}
