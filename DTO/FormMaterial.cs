using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class FormMaterial
    {
        public FormMaterial(string MaterialCode,string MaterialName,string Category,int IdCate,int Month1, int Month2, int Month3, int Month4, int Month5, int Month6)
        {
            this.MaterialCode = MaterialCode;
            this.MaterialName = MaterialName;
            this.Category = Category;
            this.IdCate = IdCate;
            this.Month1 = Month1;
            this.Month2 = Month2;
            this.Month3 = Month3;
            this.Month4 = Month4;
            this.Month5 = Month5;
            this.Month6 = Month6;
        }
        private string materialCode;
        private string materialName;
        private string category;
        private int idCate;
        private int month1;
        private int month2;
        private int month3;
        private int month4;
        private int month5;
        private int month6;

        public string MaterialCode { get => materialCode; set => materialCode = value; }
        public string MaterialName { get => materialName; set => materialName = value; }
        public string Category { get => category; set => category = value; }
        public int Month1 { get => month1; set => month1 = value; }
        public int Month2 { get => month2; set => month2 = value; }
        public int Month3 { get => month3; set => month3 = value; }
        public int Month4 { get => month4; set => month4 = value; }
        public int Month5 { get => month5; set => month5 = value; }
        public int Month6 { get => month6; set => month6 = value; }
        public int IdCate { get => idCate; set => idCate = value; }
    }
}
