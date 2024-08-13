using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class ResoucesDAO
    {
        private static ResoucesDAO instance;

        public static ResoucesDAO Instance
        {
            get
            {
                if (instance == null) instance = new ResoucesDAO();
                return instance;
            }
            set => instance = value;
        }
        public int IdResouces(string description, int parId)
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT Id FROM dbo.Resources WHERE Description = N'" + description + "' AND ParentId = " + parId);

            }
            catch
            {
                return -1;
            }

        }
        public List<Resources> GetListResource()
        {
            List<Resources> listR = new List<Resources>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT Id,IdSort,ParentId,Description,Color,CustomField1 FROM dbo.Resources ");
            foreach (DataRow item in data.Rows)
            {
                Resources r = new Resources(item);
                listR.Add(r);
            }
            return listR;
        }
        public int IdResourceByDES(int parent, string des)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT Id,IdSort,ParentId,Description,Color,CustomField1 FROM dbo.Resources WHERE ParentId = " + parent + " AND Description = N'" + des + "'");
            if (data.Rows.Count > 0)
            {
                Resources r = new Resources(data.Rows[0]);
                return r.Id;
            }
            return -1;
        }
        public string DescriptionRe(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT Id,IdSort,ParentId,Description,Color,CustomField1 FROM dbo.Resources WHERE Id = "+id);
            if (data.Rows.Count > 0)
            {
                Resources r = new Resources(data.Rows[0]);
                return r.Description;
            }
            return "";
        }
        public int TestResource(int parent, string des)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT Id,IdSort,ParentId,Description,Color,CustomField1 FROM dbo.Resources WHERE ParentId = " + parent + " AND Description = N'" + des + "'");
            if (data.Rows.Count > 0)
            {
                return 1;
            }
            return -1;
        }
        public int MaxIdsort()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(IdSort) FROM dbo.Resources");
            }
            catch
            {
                return -1;
            }
        }
        public bool InsertResource(int IdSort, int ParentId, string Description, int Color, string CustomField1)
        {
            string query = string.Format("INSERT dbo.Resources( IdSort , ParentId , Description , Color , Image , CustomField1) VALUES  ( {0} , {1} , N'{2}' , {3} , NULL , N'{4}')", IdSort, ParentId, Description, Color, CustomField1);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateResource(int Id, int IdSort, int ParentId, string Description, string CustomField1)
        {
            string query = string.Format("UPDATE dbo.Resources SET IdSort = {1},ParentId = {2} , Description = N'{3}',CustomField1 = N'{4}' WHERE Id = {0}", Id, IdSort, ParentId, Description, CustomField1);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteResource(int Id)
        {
            string query = string.Format("DELETE dbo.Resources WHERE Id = {0}", Id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteResourceALL()
        {
            string query = string.Format("DELETE dbo.Resources ");
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
