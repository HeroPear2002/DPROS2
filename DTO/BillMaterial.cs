using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class BillMaterial
    {
       
        private string barCode;
        private string materialName;
        private string materialCode;
        private string name;
        private string partCode;
        private string machineCode;
        private string quantityHH;
        private string quantity;
        private string quantityTC;
        private string dateOutput;
        private string employess;

        public BillMaterial(string barCode, string materialName, string materialCode, string name, string partCode, string machineCode, string quantityHH, string quantity, string quantityTC, string dateOutput, string employess)
        {
            BarCode = barCode;
            MaterialName = materialName;
            MaterialCode = materialCode;
            Name = name;
            PartCode = partCode;
            MachineCode = machineCode;
            QuantityHH = quantityHH;
            Quantity = quantity;
            QuantityTC = quantityTC;
            DateOutput = dateOutput;
            Employess = employess;
        }

        public string BarCode { get => barCode; set => barCode = value; }
        public string MaterialName { get => materialName; set => materialName = value; }
        public string MaterialCode { get => materialCode; set => materialCode = value; }
        public string Name { get => name; set => name = value; }
        public string PartCode { get => partCode; set => partCode = value; }
        public string MachineCode { get => machineCode; set => machineCode = value; }
        public string QuantityHH { get => quantityHH; set => quantityHH = value; }
        public string Quantity { get => quantity; set => quantity = value; }
        public string QuantityTC { get => quantityTC; set => quantityTC = value; }
        public string DateOutput { get => dateOutput; set => dateOutput = value; }
        public string Employess { get => employess; set => employess = value; }
    }
}
