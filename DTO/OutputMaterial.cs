using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OutputMaterial
    {
        private long idInput;
        private string materialCode;
        private int idWh;
        private float quantityPlan;
        private float quantityMixPlan;
        private float quantityCyclePlan;
        private float quantityMax;
        private float quantityMixMax;
        private float quantityCycleMax;
        private string machineCode;
        private string partCode;
        private long id;

        public OutputMaterial(long id, long idInput, string materialCode, int idWh, float quantityPlan, float quantityMixPlan, float quantityCyclePlan, float quantityMax, float quantityMixMax, float quantityCycleMax, string partCode, string machineCode)
        {
            Id = id;
            IdInput = idInput;
            MaterialCode = materialCode;
            IdWh = idWh;
            QuantityPlan = quantityPlan;
            QuantityMixPlan = quantityMixPlan;
            QuantityCyclePlan = quantityCyclePlan;
            QuantityMax = quantityMax;
            QuantityMixMax = quantityMixMax;
            QuantityCycleMax = quantityCycleMax;
            PartCode = partCode;
            MachineCode = machineCode;
        }

        public string MaterialCode { get => materialCode; set => materialCode = value; }
        public int IdWh { get => idWh; set => idWh = value; }
        public float QuantityPlan { get => quantityPlan; set => quantityPlan = value; }
        public float QuantityMixPlan { get => quantityMixPlan; set => quantityMixPlan = value; }
        public float QuantityCyclePlan { get => quantityCyclePlan; set => quantityCyclePlan = value; }
        public float QuantityMax { get => quantityMax; set => quantityMax = value; }
        public float QuantityMixMax { get => quantityMixMax; set => quantityMixMax = value; }
        public float QuantityCycleMax { get => quantityCycleMax; set => quantityCycleMax = value; }
        public long IdInput { get => idInput; set => idInput = value; }
        public string MachineCode { get => machineCode; set => machineCode = value; }
        public string PartCode { get => partCode; set => partCode = value; }
        public long Id { get => id; set => id = value; }
    }
}
