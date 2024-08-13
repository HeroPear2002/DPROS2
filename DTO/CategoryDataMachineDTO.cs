using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CategoryDataMachineDTO
    {
        public CategoryDataMachineDTO(int Id, string Name, float UpperLimit, float LowerLimit, string Value)
        {
            this.Id = Id;
            this.Name = Name;
            this.Value = Value;
            this.UpperLimit = UpperLimit;
            this.LowerLimit = LowerLimit;
        }
        public CategoryDataMachineDTO(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.Name = row["Name"].ToString();
            this.Value = row["Value"].ToString();
            this.UpperLimit = (float)Convert.ToDouble(row["UpperLimit"].ToString());
            this.LowerLimit = (float)Convert.ToDouble(row["LowerLimit"].ToString());
        }
        private int id;
        private string name;
        private string value;
        private float upperLimit;
        private float lowerLimit;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Value { get => value; set => this.value = value; }
        public float LowerLimit { get => lowerLimit; set => lowerLimit = value; }
        public float UpperLimit { get => upperLimit; set => upperLimit = value; }
    }
}
