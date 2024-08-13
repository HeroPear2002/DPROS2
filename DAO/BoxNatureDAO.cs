using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
   public class BoxNatureDAO
    {
        private static BoxNatureDAO instance;

        public static BoxNatureDAO Instance
        {
            get
            {if (instance == null) instance = new BoxNatureDAO();
                return instance;
            }

            set
            {
                instance = value;
            }
        }
        public List<BoxNatureDTO> GetlistBox()
        {
            List<BoxNatureDTO> listB = new List<BoxNatureDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * from dbo.BoxNature");
            foreach (DataRow item in data.Rows)
            {
                BoxNatureDTO b = new BoxNatureDTO(item);
                listB.Add(b);
            }
            return listB;
        }
        public List<BoxNatureDTO> GetlistBoxbyNote(string code)
        {
            List<BoxNatureDTO> listB = new List<BoxNatureDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * from dbo.BoxNature WHERE Note = N'"+code+"'");
            foreach (DataRow item in data.Rows)
            {
                BoxNatureDTO b = new BoxNatureDTO(item);
                listB.Add(b);
            }
            return listB;
        }
        public int QuantityBoxByName(string BoxName,string Code)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * from dbo.BoxNature WHERE BoxName = N'" + BoxName + "' AND Note = N'"+ Code + "'");
            if(data.Rows.Count>0)
            {
                BoxNatureDTO b = new BoxNatureDTO(data.Rows[0]);
                return b.Quantity;
            }
            return 0;
        }
        public bool Insert(string BoxName, int Quantity,string Note)
        {
            string query = string.Format("INSERT dbo.BoxNature ( BoxName, Quantity, Note ) VALUES  ( N'{0}', {1}, N'{2}')", BoxName, Quantity, Note);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool Update(int Id,string BoxName, int Quantity, string Note)
        {
            string query = string.Format("UPDATE dbo.BoxNature SET BoxName = N'{1}', Quantity = {2} , Note = N'{3}' WHERE Id = {0}", Id,BoxName, Quantity, Note);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool Delete(int Id)
        {
            string query = string.Format("DELETE dbo.BoxNature WHERE Id = {0}",Id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
