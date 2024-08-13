using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class FactoryDAO
    {
        private static FactoryDAO instance;

        public static FactoryDAO Instance
        {
            get
            {
                if (instance == null) instance = new FactoryDAO();
                return instance;
            }
            set => instance = value;
        }
        public List<FactoryDTO> GetListAllFactory()
        {
            List<FactoryDTO> listF = new List<FactoryDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Factory");
            foreach (DataRow item in data.Rows)
            {
                FactoryDTO f = new FactoryDTO(item);
                listF.Add(f);
            }
            return listF;
        }
        public FactoryDTO GetItemFactory(string FactoryCode)
        {
            return GetListAllFactory().FirstOrDefault(x=>x.FactoryCode == FactoryCode);
        }
        public FactoryDTO GetItemFactory(string FactoryCode,string cusCode)
        {
            return GetListAllFactory().FirstOrDefault(x => x.FactoryCode == FactoryCode && x.NameCustomer == cusCode);
        }
        public Object GetListDistinctAllFactory()
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT DISTINCT(FactoryCode) FROM Factory");
        }
        public string FactoryCodeByCode(string CusCode)
        {
            try
            {
                return DataProvider.Instance.ExecuteScalar("SELECT DISTINCT(FactoryCode) FROM Factory WHERE CodeCustomer = N'"+CusCode+"'").ToString();
            }
            catch 
            {
                return "";
            }
        }
        public string GetFactoryNameByCode(string Code)
        {
            try
            {
                return DataProvider.Instance.ExecuteScalar("SELECT DISTINCT(FactoryName) FROM Factory WHERE FactoryCode = N'"+Code+"'").ToString();
            }
            catch 
            {
                return "";
            }
        }
        public int TestFactory(string codeFac,string CodeCus)
        {
            string query = "SELECT * FROM Factory WHERE FactoryCode = N'" + codeFac + "' AND NameCustomer = N'" + CodeCus + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            if(data.Rows.Count >0)
            {
                return 1;
            }
            return -1;
        }
        public int TestFactoryByFacCode(string codeFac)
        {
            string query = "SELECT * FROM Factory WHERE FactoryCode = N'" + codeFac +"'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            if (data.Rows.Count > 0)
            {
                return 1;
            }
            return -1;
        }
        public bool InsertFactory(string FactoryCode , string FactoryName , string CodeCustomer, string NameCustomer,string NameBillVN,string NameBillENG,string Address,string Phone, string FaxNumber,string MST)
        {
            string query = string.Format("INSERT INTO [dbo].[Factory] (FactoryCode ,FactoryName ,CodeCustomer,NameCustomer,NameBillVN,NameBillENG,Address,Phone,FaxNumber,MST) VALUES (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',N'{7}',N'{8}',N'{9}')", FactoryCode, FactoryName, CodeCustomer, NameCustomer, NameBillVN, NameBillENG, Address, Phone, FaxNumber, MST);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateFactory(int Id,string FactoryCode, string FactoryName, string CodeCustomer, string NameCustomer,string NameBillVN, string NameBillENG, string Address, string Phone, string FaxNumber,string MST)
        {
            string query = string.Format("UPDATE [dbo].[Factory] SET [FactoryCode] = N'{1}',[FactoryName] = N'{2}',[CodeCustomer] = N'{3}',[NameCustomer] = N'{4}', [NameBillVN] = N'{5}' ,NameBillENG = N'{6}',Address = N'{7}',Phone = N'{8}',FaxNumber = N'{9}' , [MST] = N'{10}' WHERE Id = {0}", Id, FactoryCode, FactoryName, CodeCustomer, NameCustomer, NameBillVN, NameBillENG, Address, Phone, FaxNumber, MST);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteFactory(int Id)
        {
            string query = string.Format("DELETE Factory Where Id = {0}", Id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
