using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DataMachineCheckDTO
    {
        public DataMachineCheckDTO(int Id, string NameCategory, float ValueDefault, float ValueUp, float ValueDown, string ValueCheck)
        {
            this.Id = Id;
            this.NameCategory = NameCategory;
            this.ValueDefault = ValueDefault;
            this.ValueUp = ValueUp;
            this.ValueDown = ValueDown;
            this.ValueCheck = ValueCheck;
        }
        public DataMachineCheckDTO(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.NameCategory = row["NameCategory"].ToString();
            this.ValueDefault = (float)Convert.ToDouble(row["ValueDefault"].ToString());
            this.ValueUp = (float)Convert.ToDouble(row["ValueUp"].ToString());
            this.ValueDown = (float)Convert.ToDouble(row["ValueDown"].ToString());
            this.ValueCheck = row["ValueCheck"].ToString();
        }
        private int id;
        private string nameCategory;
        private float valueDefault;
        private float valueUp;
        private float valueDown;
        private string valueCheck;


        public string NameCategory { get => nameCategory; set => nameCategory = value; }
        public float ValueDefault { get => valueDefault; set => valueDefault = value; }
        public float ValueUp { get => valueUp; set => valueUp = value; }
        public float ValueDown { get => valueDown; set => valueDown = value; }
        public string ValueCheck { get => valueCheck; set => valueCheck = value; }
        public int Id { get => id; set => id = value; }
    }
}
