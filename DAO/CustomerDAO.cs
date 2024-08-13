using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
   public class CustomerDAO
    {
        private static CustomerDAO instance;

        public static CustomerDAO Instance
        {
            get
            {
                if (instance == null) instance = new CustomerDAO();
                return instance;
            }

            set
            {
                instance = value;
            }
        }
        public List<CustomerDTO> GetListCustomerDTO()
        {
            List<CustomerDTO> ListC = new List<CustomerDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Customer");
            foreach (DataRow item in data.Rows)
            {
                CustomerDTO c = new CustomerDTO(item);
                ListC.Add(c);
            }
            return ListC;
        }
        public CustomerDTO GetItemCustomerDTO(string CustomerCode)
        {
            return GetListCustomerDTO().SingleOrDefault(x => x.CustomerCode == CustomerCode);
        }
        public int TestCustomerDTO(string CustomerCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Customer WHERE CustomerCode = N'"+ CustomerCode + "'"); 
            if(data.Rows.Count > 0)
            {
                return 1;
            }
            return -1;
        }
        public int WarnPOInput(string CustomerCode)
        {
            try
            {
               return  int.Parse(DataProvider.Instance.ExecuteScalar("SELECT WarnPOInput FROM dbo.Customer WHERE CustomerCode = N'" + CustomerCode + "'").ToString());
            }
            catch 
            {
                return 0;
            }
        }
        public int WarnPOFix(string CustomerCode)
        {
            try
            {
                return int.Parse(DataProvider.Instance.ExecuteScalar("SELECT WarnPOFix FROM dbo.Customer WHERE CustomerCode = N'" + CustomerCode + "'").ToString());
            }
            catch
            {
                return 0;
            }
        }
        public int WarnOther(string CustomerCode)
        {
            try
            {
                return int.Parse(DataProvider.Instance.ExecuteScalar("SELECT Other FROM dbo.Customer WHERE CustomerCode = N'" + CustomerCode + "'").ToString());
            }
            catch
            {
                return 0;
            }
        }
        //thêm
        public bool InsertCustomer(string CustomerCode, string CustomerName, string Address, string Phone,int WarnPOInput,int WarnPOFix,int Other)
        {
            string query = string.Format("INSERT dbo.Customer ( CustomerCode , CustomerName , Address , Phone , WarnPOInput , WarnPOFix , Other) VALUES  ( N'{0}' , N'{1}' , N'{2}' , N'{3}',{4} ,{5} ,{6} )", CustomerCode, CustomerName, Address, Phone, WarnPOInput, WarnPOFix, Other);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateCustomer(string CustomerCode, string CustomerName, string Address, string Phone, int WarnPOInput, int WarnPOFix, int Other)
        {
            string query = string.Format("UPDATE [dbo].[Customer] SET [CustomerName] = N'{1}' ,[Address] = N'{2}' ,[Phone] = N'{3}', WarnPOInput = N'{4}', WarnPOFix = N'{5}', Other = N'{6}' WHERE  [CustomerCode] = N'{0}'", CustomerCode, CustomerName, Address, Phone, WarnPOInput, WarnPOFix, Other);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteCustomer(string CustomerCode)
        {
            string query = string.Format("DELETE dbo.Customer WHERE CustomerCode = N'{0}'", CustomerCode);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

    }
}
