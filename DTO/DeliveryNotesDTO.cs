using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DeliveryNotesDTO
    {
        public DeliveryNotesDTO(long Id,string DeCode,DateTime DateInput,DateTime? DateOutput,string EmployessCreate,string EmployessChange,int StatusDe,string Note,string EmployessOut,DateTime? DateChange,DateTime DateDelivery)
        {
            this.Id = Id;
            this.DeCode = DeCode;
            this.DateInput = DateInput;
            this.DateOutput = DateOutput;
            this.EmployessCreate = EmployessCreate;
            this.EmployessChange = EmployessChange;
            this.StatusDe = StatusDe;
            this.Note = Note;
            this.EmployessOut = EmployessOut;
            this.DateChange = DateChange;
            this.DateDelivery = DateDelivery;
        }
        public DeliveryNotesDTO(DataRow row)
        {
            this.Id = (long)row["Id"];
            this.DeCode = row["DeCode"].ToString();
            this.DateInput = (DateTime)row["DateInput"];
            var checkDateOut = row["DateOutput"];
            if (checkDateOut.ToString() != "")
                this.DateOutput = (DateTime)checkDateOut;
            this.EmployessCreate = row["EmployessCreate"].ToString();
            this.EmployessChange = row["EmployessChange"].ToString();
            this.StatusDe = (int)row["StatusDe"];
            this.Note = row["Note"].ToString();
            this.EmployessOut = row["EmployessOut"].ToString();
            var checkDateChange = row["DateChange"];
            if(checkDateChange.ToString() != "")
            this.DateChange = (DateTime)checkDateChange;
            this.DateDelivery = (DateTime)row["DateDelivery"];
        }
        private long id;
        private string deCode;
        private DateTime dateInput;
        private DateTime? dateOutput;
        private string employessCreate;
        private string employessChange;
        private int statusDe;
        private string note;
        private string employessOut;
        private DateTime? dateChange;
        private DateTime dateDelivery;

        public long Id { get => id; set => id = value; }
        public string DeCode { get => deCode; set => deCode = value; }
        public DateTime DateInput { get => dateInput; set => dateInput = value; }
        public DateTime? DateOutput { get => dateOutput; set => dateOutput = value; }
        public string EmployessCreate { get => employessCreate; set => employessCreate = value; }
        public string EmployessChange { get => employessChange; set => employessChange = value; }
        public int StatusDe { get => statusDe; set => statusDe = value; }
        public string Note { get => note; set => note = value; }
        public string EmployessOut { get => employessOut; set => employessOut = value; }
        public DateTime? DateChange { get => dateChange; set => dateChange = value; }
        public DateTime DateDelivery { get => dateDelivery; set => dateDelivery = value; }
    }
}
