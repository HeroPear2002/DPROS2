using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class Resources
    {
        public Resources(int Id, int IdSort, int ParentId,string Description,int Color,string CustomField1)
        {
            this.Id = Id;
            this.IdSort = IdSort;
            this.ParentId = ParentId;
            this.Description = Description;
            this.Color = Color;
            this.CustomField1 = CustomField1;
        }
        public Resources(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.IdSort = (int)row["IdSort"];
            this.ParentId = (int)row["ParentId"];
            this.Description = row["Description"].ToString();
            this.Color = (int)row["Color"];
           
            this.CustomField1 = row["CustomField1"].ToString();
        }
        private int id;
        private int idSort;
        private int parentId;
        private string description;
        private int color;
    
        private string customField1;

        public int Id { get => id; set => id = value; }
        public int IdSort { get => idSort; set => idSort = value; }
        public int ParentId { get => parentId; set => parentId = value; }
        public string Description { get => description; set => description = value; }
        public int Color { get => color; set => color = value; }
  
        public string CustomField1 { get => customField1; set => customField1 = value; }
    }
}
