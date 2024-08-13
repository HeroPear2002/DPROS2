using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OnlyCategoryTest
    {
        public OnlyCategoryTest(long Id, string NameCategoryTest)
        {
            this.Id = Id;
            this.NameCategory = NameCategory;
        }
        public OnlyCategoryTest(DataRow row)
        {
            this.Id = (long)row["Id"];
            this.NameCategory = row["NameCategory"].ToString();
        }
        private long id;
        private string nameCategory;

        public long Id { get => id; set => id = value; }
        public string NameCategory { get => nameCategory; set => nameCategory = value; }
    }
}
