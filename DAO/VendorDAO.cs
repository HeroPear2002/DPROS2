using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace DAO
{
   public class VendorDAO
    {
        private static VendorDAO instance;

        public static VendorDAO Instance
        {
            get
            {
                if (instance == null) instance = new VendorDAO();
                return instance;
            }

            set
            {
                instance = value;
            }
        }
        public List<SupplierDTO> GetListVender()
        {
            List<SupplierDTO> listS = new List<SupplierDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Vender");
            foreach (DataRow item in data.Rows)
            {
                SupplierDTO s = new SupplierDTO(item);
                listS.Add(s);
            }
            return listS;
        }
        public SupplierDTO GetItemSupplierDTO(string Sup)
        {
            return GetListVender().SingleOrDefault(x => x.VenderCode == Sup);
        }
        public bool InsertVendor(string VenderCode, string VenderName, string Address, string Phone,string ContactPerson ,string FaxNumber)
        {
            string query = string.Format("INSERT dbo.Vender ( VenderCode , VenderName , Address ,Phone ,ContactPerson , FaxNumber) VALUES  ( N'{0}' , N'{1}' ,  N'{2}' , N'{3}' ,N'{4}' , N'{5}')", VenderCode, VenderName, Address, Phone, ContactPerson, FaxNumber);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateVendor(string VenderCode, string VenderName, string Address, string Phone,string ContactPerson ,string FaxNumber)
        {
            string query = string.Format("UPDATE [dbo].[Vender] SET  [VenderName] = N'{1}',[Address] = N'{2}',[Phone] = N'{3}',[ContactPerson] = N'{4}' , [FaxNumber] = N'{5}' WHERE [VenderCode] = N'{0}'", VenderCode, VenderName, Address, Phone, ContactPerson, FaxNumber);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteVendor(string VenderCode)
        {
            string query = string.Format("DELETE dbo.Vender WHERE VenderCode = N'{0}'", VenderCode);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
