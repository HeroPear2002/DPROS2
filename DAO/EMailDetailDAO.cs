using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class EMailDetailDAO
    {
        private static EMailDetailDAO instance;

        public static EMailDetailDAO Instance
        {
            get
            {
                if (instance == null) instance = new EMailDetailDAO();
                return instance;
            }
            set => instance = value;
        }
        public List<EMailDetail> GetList()
        {
            List<EMailDetail> listE = new List<EMailDetail>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM EMailDetail");
            foreach (DataRow item in data.Rows)
            {
                EMailDetail e = new EMailDetail(item);
                listE.Add(e);
            }
            return listE;
        }
        public EMailDetail GetItem()
        {
            return GetList().First();
        }
    }
}
