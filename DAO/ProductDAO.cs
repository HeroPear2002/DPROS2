using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class ProductDAO
    {
        private static ProductDAO instance;

        public static ProductDAO Instance
        {
            get
            {
                if (instance == null) instance = new ProductDAO();
                return instance;
            }

            set => instance = value;
        }
        #region Product List
        public List<ProductDTO> ListProduct()
        {
            List<ProductDTO> listP = new List<ProductDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Products");
            foreach (DataRow item in data.Rows)
            {
                ProductDTO p = new ProductDTO(item);
                listP.Add(p);
            }
            return listP;
        }
        public int TestProduct(string code)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Products WHERE Code = N'"+code+"'");
            if(data.Rows.Count >0)
            {
                return 1;
            }
            return -1;
        }
        public string NoteProduct(string code)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Products WHERE Code = N'"+code+"'");
            if(data.Rows.Count >0)
            {
                ProductDTO p = new ProductDTO(data.Rows[0]);
                return p.Note;
            }
            return "";
        }
        public bool InsertProduct(ProductDTO pr)
        {
            string query = string.Format("INSERT dbo.Products ( Code, Name, CountConstan, Note, Vendor ) VALUES  ( N'{0}', N'{1}', {2}, N'{3}',N'{4}')",pr.Code,pr.Name,pr.CountConstan,pr.Note,pr.Vendor);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateProduct(ProductDTO pr)
        {
            string query = string.Format("UPDATE dbo.Products SET Name = N'{1}',CountConstan = {2} , Note = N'{3}' , Vendor = N'{4}' WHERE Code = N'{0}'", pr.Code, pr.Name, pr.CountConstan, pr.Note,pr.Vendor);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteProduct(string code)
        {
            string query = string.Format("DELETE dbo.Products WHERE Code = N'{0}'", code);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateRohsProduct(string code, string rohs)
        {
            string query = string.Format("UPDATE dbo.Products SET Rohs = N'{1}' WHERE Code = N'{0}'", code, rohs);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public float CountConstan(string code)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Products WHERE Code = N'"+code+"'");
            if(data.Rows.Count >0)
            {
                ProductDTO p = new ProductDTO(data.Rows[0]);
                return p.CountConstan;
            }
            return 0;
        }
        #endregion
        #region Input
        public object ListInputProductByDate(DateTime date1 , DateTime date2)
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.InputProduct WHERE DateInput >= '"+date1+"' AND DateInput <= '"+date2+"'");
        }
        public object ListInputProduct()
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT TOP(10) * FROM dbo.InputProduct ORDER BY DateInput DESC");
        }
        public bool InsertIputProduct(string ProductCode ,DateTime DateInput ,string Employess ,int StatusInput ,string Note ,float CountInput)
        {
            string query = string.Format("INSERT dbo.InputProduct ( ProductCode , DateInput , Employess , StatusInput , Note , CountInput) VALUES  ( N'{0}' , '{1}',  N'{2}' , {3} ,  N'{4}' , {5} )", ProductCode, DateInput, Employess, StatusInput, Note, CountInput);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateStatusInput(long Id,int status)
        {
            string query = string.Format("UPDATE dbo.InputProduct SET StatusInput = {1} WHERE Id = {0}", Id,status);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        #endregion
        #region Output Warn
        public List<OutputWarnProduct> ListOutputDetail()
        {
            List<OutputWarnProduct> listO = new List<OutputWarnProduct>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.OutputProductWarn ORDER BY Note ASC");
            foreach (DataRow item in data.Rows)
            {
                OutputWarnProduct o = new OutputWarnProduct(item);
                listO.Add(o);
            }
            return listO;
        }
        public string NoteOutputDetail(long id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.OutputProductWarn WHERE Id = " +id);
            if(data.Rows.Count >0)
            {
                OutputWarnProduct o = new OutputWarnProduct(data.Rows[0]);
                return o.Note;
            }
            return "";
        }
        public bool InsertOutputDetail(OutputWarnProduct ou)
        {
            string query = string.Format("INSERT dbo.OutputProductWarn ( ProductCode , DateOutput , Employess , CountOut , Detail , Note ) VALUES  ( N'{0}' , '{1}' , N'{2}' , {3} , N'{4}' , N'{5}')", ou.ProductCode, ou.DateOutput, ou.Employess, ou.CountOut, ou.Detail, ou.Note);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateOutputDetail(OutputWarnProduct ou)
        {
            string query = string.Format("UPDATE dbo.OutputProductWarn SET ProductCode = N'{1}' ,DateOutput = '{2}' , Employess = N'{3}' ,CountOut = {4}, Detail = N'{5}' ,Note = N'{6}' WHERE Id = {0}", ou.Id,ou.ProductCode, ou.DateOutput, ou.Employess, ou.CountOut, ou.Detail, ou.Note);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateOutputDetailNote(long id , string note)
        {
            string query = string.Format("UPDATE dbo.OutputProductWarn SET Note = N'{1}' WHERE Id = {0}", id,note);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteOutputDetail(long id)
        {
            string query = string.Format("DELETE dbo.OutputProductWarn WHERE Id = {0}",id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        #endregion
        #region Output Product
        public object DistinctProduct()
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT DISTINCT(ProductCode) FROM dbo.InputProduct WHERE StatusInput = 0");
        }
        public object ListOutputProduct(DateTime date1,DateTime date2)
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT ProductCode,DateInput,DateOutput,CountOut,OutputProduct.Employess FROM dbo.OutputProduct,dbo.InputProduct WHERE InputProduct.Id = IdInput AND DateOutput <= '"+date2+"' AND DateOutput >= '"+date1+"'");
        }
        public object ListOutputProduct()
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT TOP(15) ProductCode,DateInput,DateOutput,CountOut,OutputProduct.Employess FROM dbo.OutputProduct,dbo.InputProduct WHERE InputProduct.Id = IdInput ORDER BY DateOutput DESC");
        }
        public bool InsertOutputPro(long IdInput ,DateTime DateOutput ,string Employess ,float CountOut ,string Detail ,string Note)
        {
            string query = string.Format("INSERT dbo.OutputProduct ( IdInput ,DateOutput , Employess , CountOut , Detail , Note ) VALUES  ( {0} , '{1}' , N'{2}' , {3} , N'{4}' , N'{5}')", IdInput, DateOutput, Employess, CountOut, Detail, Note);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        #endregion
        #region Inventory Product
        public List<ProductIventoryDTO> ListIventoryProduct()
        {
            List<ProductIventoryDTO> listI = new List<ProductIventoryDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT InputProduct.Id, ProductCode,Name,DateInput, CountInput,(CountInput - ISNULL(SUM(CountOut),0)) AS Iventory,Products.Rohs FROM dbo.InputProduct LEFT JOIN dbo.OutputProduct ON InputProduct.Id = IdInput LEFT JOIN dbo.Products ON Code = ProductCode WHERE  StatusInput = 0 GROUP BY InputProduct.Id, ProductCode, Name, DateInput, CountInput,Products.Rohs  ");
            foreach (DataRow item in data.Rows)
            {
                ProductIventoryDTO p = new ProductIventoryDTO(item);
                listI.Add(p);
            }
            return listI;
        }
        public List<ProductCodeDTO> GetListCodeProduct()
        {
            List<ProductCodeDTO> listP = new List<ProductCodeDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT Distinct(Code) AS ProductCode,Name from  Products");
            foreach (DataRow item in data.Rows)
            {
                ProductCodeDTO p = new ProductCodeDTO(item);
                listP.Add(p);
            }
            return listP;
        }
        public List<ProductIventoryDTO> ListIventoryProduct(string product)
        {
            List<ProductIventoryDTO> listI = new List<ProductIventoryDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT InputProduct.Id, ProductCode,Name,DateInput, CountInput,(CountInput - ISNULL(SUM(CountOut),0)) AS Iventory,Products.Rohs FROM dbo.InputProduct LEFT JOIN dbo.OutputProduct ON InputProduct.Id = IdInput LEFT JOIN dbo.Products ON Code = ProductCode WHERE  StatusInput = 0 AND ProductCode = N'" + product + "' GROUP BY InputProduct.Id, ProductCode, Name, DateInput, CountInput,Products.Rohs  ");
            foreach (DataRow item in data.Rows)
            {
                ProductIventoryDTO p = new ProductIventoryDTO(item);
                listI.Add(p);
            }
            return listI;
        }
        public float TotalIventory(string code)
        {
            float sum = 0;
            List<ProductIventoryDTO> listP = ProductDAO.Instance.ListIventoryProduct(code);
            foreach (ProductIventoryDTO item in listP)
            {
                sum = sum + item.Iventory;
            }
            return sum;
        }
        #endregion

    }
}
