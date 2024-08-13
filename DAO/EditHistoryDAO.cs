using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class EditHistoryDAO
    {
        private static EditHistoryDAO instance;

        public static EditHistoryDAO Instance
        {
            get
            {
                if (instance == null) instance = new EditHistoryDAO();
                return instance;
            }
            set => instance = value;
        }
        public object GetListData()
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.EditHistory");
        }
        public bool Insert(DateTime DateInput,string Employess,string Detail,string note)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format("INSERT dbo.EditHistory ( DateInput, Employess, Detail, Note ) VALUES  ( '{0}',  N'{1}', N'{2}', N'{3}')", DateInput, Employess, Detail,note);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

    }
}
