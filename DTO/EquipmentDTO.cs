using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EquipmentDTO
    {
        public EquipmentDTO(string EquipmentCode,string EquipmentName,string Model,string Serial,string Maker,string Status,int Cycle, DateTime? DateCheck, int StatusMail,int StatusCheck, DateTime? DateInput)
        {
            this.EquipmentCode = EquipmentCode;
            this.EquipmentName = EquipmentName;
            this.Model = Model;
            this.Serial = Serial;
            this.Maker = Maker;
            this.Status = Status;
            this.Cycle = Cycle;
            this.DateCheck = DateCheck;
            this.StatusMail = StatusMail;
            this.StatusCheck = StatusCheck;
            this.DateInput = DateInput;
        }
        public EquipmentDTO(DataRow row)
        {
            this.EquipmentCode = row["EquipmentCode"].ToString();
            this.EquipmentName = row["EquipmentName"].ToString(); 
            this.Model = row["Model"].ToString();
            this.Serial = row["Serial"].ToString();
            this.Maker = row["Maker"].ToString();
            this.Status = row["Status"].ToString();
            this.Cycle = (int)row["Cycle"];
            var checkNgayXuat = row["DateCheck"];
            if (checkNgayXuat.ToString() != "")
                this.DateCheck = (DateTime)checkNgayXuat;
            this.StatusMail = (int)row["StatusMail"];
            this.StatusCheck = (int)row["StatusCheck"];

            var checkDateInput = row["DateInput"];
            if (checkDateInput.ToString() != "")
                this.DateInput = (DateTime)checkDateInput;
        }
        private string equipmentCode;
        private string equipmentName;
        private string model;
        private string serial;
        private string maker;
        private string status;
        private int cycle;
        private DateTime? dateCheck;
        private int statusMail;
        private int statusCheck;
        private DateTime? dateInput;
        public string EquipmentCode
        {
            get
            {
                return equipmentCode;
            }

            set
            {
                equipmentCode = value;
            }
        }

        public string EquipmentName
        {
            get
            {
                return equipmentName;
            }

            set
            {
                equipmentName = value;
            }
        }

        public string Model
        {
            get
            {
                return model;
            }

            set
            {
                model = value;
            }
        }

        public string Serial
        {
            get
            {
                return serial;
            }

            set
            {
                serial = value;
            }
        }

        public string Maker
        {
            get
            {
                return maker;
            }

            set
            {
                maker = value;
            }
        }

        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public int Cycle
        {
            get
            {
                return cycle;
            }

            set
            {
                cycle = value;
            }
        }

        public DateTime? DateCheck
        {
            get
            {
                return dateCheck;
            }

            set
            {
                dateCheck = value;
            }
        }

        public int StatusMail
        {
            get
            {
                return statusMail;
            }

            set
            {
                statusMail = value;
            }
        }

        public int StatusCheck
        {
            get
            {
                return statusCheck;
            }

            set
            {
                statusCheck = value;
            }
        }

        public DateTime? DateInput { get => dateInput; set => dateInput = value; }
    }
}
