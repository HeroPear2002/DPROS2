using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
   public class MaterialDAO
    {
        private static MaterialDAO instance;

        #region MATERIAL 
        public static MaterialDAO Instance
        {
            get
            {
                if (instance == null) instance = new MaterialDAO();
                return instance;
            }

            set
            {
                instance = value;
            }
        }
        public List<MaterialDTO> GetListMaterial()
        {
            List<MaterialDTO> listM = new List<MaterialDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Material");
            foreach (DataRow item in data.Rows)
            {
                MaterialDTO m = new MaterialDTO(item);
                listM.Add(m);
            }
            return listM;
        }
        public MaterialDTO GetItemMaterial(string MaterialCode)
        {
            return GetListMaterial().SingleOrDefault(x => x.MaterialCode == MaterialCode);
        }
        public MaterialDTO GetItem(string Code)
        {
            return GetListMaterial().SingleOrDefault(x=>x.MaterialCode == Code);
        }
        public List<MaterialDTO> GetListMaterialByVendor(string Code)
        {
            List<MaterialDTO> listM = new List<MaterialDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Material WHERE VenderCode = N'"+Code+"'");
            foreach (DataRow item in data.Rows)
            {
                MaterialDTO m = new MaterialDTO(item);
                listM.Add(m);
            }
            return listM;
        }
        public object GetListMaterialByVendorInput(string Code)
        {
            
           return (object) DataProvider.Instance.ExecuteQuery("SELECT MaterialCode,MaterialName, 0 AS Count, 0 AS Price,N'dd/MM/yyy' AS Date FROM dbo.Material WHERE VenderCode = N'" + Code + "'");
       
        }
        public bool InsertMaterial(string MaterialCode, string MaterialName, int CountYellow, int CountRed, string VenderCode, string Nature ,string RohsFile, string ColorCode)
        {
            string query = string.Format("INSERT dbo.Material ( MaterialCode , MaterialName , CountYellow , CountRed , VenderCode , Nature , RohsFile , ColorCode ) VALUES  ( N'{0}' ,  N'{1}' ,  {2} , {3} , N'{4}', N'{5}' , N'{6}' , N'{7}')", MaterialCode, MaterialName, CountYellow, CountRed, VenderCode, Nature , RohsFile,ColorCode);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateMaterial(string MaterialCode, string MaterialName, int CountYellow, int CountRed, string VenderCode,string Nature,string RohsFile, string ColorCode)
        {
            string query = string.Format("UPDATE [dbo].[Material] SET [MaterialName] = N'{1}' ,[CountYellow] = {2} ,[CountRed] = {3} ,[VenderCode] = N'{4}' , [Nature] = N'{5}' , [RohsFile] = N'{6}' , [ColorCode] = N'{7}' WHERE [MaterialCode] = N'{0}'", MaterialCode, MaterialName, CountYellow, CountRed, VenderCode, Nature, RohsFile, ColorCode);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateMaterial(string MaterialCode, string RohsFile)
        {
            string query = string.Format("UPDATE [dbo].[Material] SET  [RohsFile] = N'{1}' WHERE [MaterialCode] = N'{0}'", MaterialCode,  RohsFile);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteMaterial(string MaterialCode)
        {
            string query = string.Format("DELETE dbo.Material WHERE MaterialCode = N'{0}'", MaterialCode);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public int TestMaterialByCode(string MaterialCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Material WHERE MaterialCode = N'"+MaterialCode+"'");
            if(data.Rows.Count>0)
            {
                return 1;
            }
            return -1;
        }
        public string GetNameMaterialByCode(string MaterialCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Material WHERE MaterialCode = N'" + MaterialCode + "'");
            if (data.Rows.Count > 0)
            {
                MaterialDTO m = new MaterialDTO(data.Rows[0]);
                return m.MaterialName;
            }
            return null;
        }
        public int WarningRed(string MaterialCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Material WHERE MaterialCode = N'" + MaterialCode + "'");
            if (data.Rows.Count > 0)
            {
                MaterialDTO m = new MaterialDTO(data.Rows[0]);
                return m.CountRed;
            }
            return 0;
        }
        public string NatureMaterial(string MaterialCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Material WHERE MaterialCode = N'" + MaterialCode + "'");
            if (data.Rows.Count > 0)
            {
                MaterialDTO m = new MaterialDTO(data.Rows[0]);
                return m.Nature;
            }
            return null;
        }
        public int WarningYellow(string MaterialCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Material WHERE MaterialCode = N'" + MaterialCode + "'");
            if (data.Rows.Count > 0)
            {
                MaterialDTO m = new MaterialDTO(data.Rows[0]);
                return m.CountYellow;
            }
            return 0;
        }
        public string RohsFile(string MaterialCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Material WHERE MaterialCode = N'" + MaterialCode + "'");
            if (data.Rows.Count > 0)
            {
                MaterialDTO m = new MaterialDTO(data.Rows[0]);
                return m.RohsFile;
            }
            return "";
        }

        #endregion
        #region RATIO MATERIAL
        public object GetListRatio()
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT RatioMaterial.MaterialCode,MaterialName,Ratio,Note,RatioInput FROM dbo.RatioMaterial,Material WHERE RatioMaterial.MaterialCode = Material.MaterialCode ");
        }
        public bool InsertRatio(string MaterialCode,int Ratio,string Note,int RatioInput)
        {
            string query = string.Format("INSERT dbo.RatioMaterial ( MaterialCode, Ratio, Note,RatioInput ) VALUES  ( N'{0}', {1}, N'{2}',{3})", MaterialCode, Ratio, Note, RatioInput);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool EditRatio(string MaterialCode, int Ratio, string Note,int RatioInput)
        {
            string query = string.Format("UPDATE dbo.RatioMaterial SET Ratio = {1} , Note = N'{2}' , RatioInput = {3} WHERE MaterialCode = N'{0}'", MaterialCode, Ratio, Note, RatioInput);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteRatio(string MaterialCode)
        {
            string query = string.Format("DELETE dbo.RatioMaterial WHERE MaterialCode = N'{0}'", MaterialCode);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public int RatioByCode(string code)
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT Ratio FROM dbo.RatioMaterial WHERE MaterialCode = N'" + code+"'");
            }
            catch 
            {
                return 0;
            }
        }
        public int RatioInputByCode(string code)
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT RatioInput FROM dbo.RatioMaterial WHERE MaterialCode = N'" + code + "'");
            }
            catch
            {
                return 25;
            }
        }
        #endregion
        #region MATERIAL BEGIN
        public object GetListMaterialBegin()
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT MaterialBegin.MaterialCode,MaterialName,WeightMin,TimeMin FROM MaterialBegin, Material WHERE MaterialBegin.MaterialCode = Material.MaterialCode");
        }
        public string WeightMinByCode(string Code)
        {
            try
            {
                return DataProvider.Instance.ExecuteScalar("SELECT WeightMin FROM MaterialBegin WHERE MaterialCode = N'" + Code + "'").ToString();
            }
            catch
            {
                return "";
            }
        }
        public int TestMaterialBegin(string MaterialCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.MaterialBegin WHERE MaterialCode = N'" + MaterialCode + "'");
            if (data.Rows.Count > 0)
            {
                return 1;
            }
            return -1;
        }
        public string TimeMinByCode(string Code)
        {
            try
            {
                return DataProvider.Instance.ExecuteScalar("SELECT TimeMin FROM MaterialBegin WHERE MaterialCode = N'" + Code + "'").ToString();
            }
            catch
            {
                return "";
            }
        }
        public bool InsertMaterialBegin(string Code, string weight, string timemin)
        {
            string query = string.Format("INSERT INTO [dbo].[MaterialBegin] ([MaterialCode],[WeightMin],[TimeMin]) VALUES (N'{0}',N'{1}',N'{2}')", Code, weight, timemin);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateMaterialBegin(string Code, string weight, string timemin)
        {
            string query = string.Format("UPDATE [dbo].[MaterialBegin] SET [WeightMin] = N'{1}' ,[TimeMin] = N'{2}' WHERE [MaterialCode] = N'{0}'", Code, weight, timemin);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteMaterialBegin(string Code)
        {
            string query = string.Format("DELTE MaterialBegin WHERE MaterialCode = N'" + Code + "'");
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        #endregion
        #region MATERIAL PRICE
        public List<MaterialPriceDTO> GetListAllMaterPrice()
        {
            List<MaterialPriceDTO> listM = new List<MaterialPriceDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT Id,DateInput,MaterialPrice.MaterialCode,MaterialName,PriceVND,PriceUSD,StatusPrice,VenderCode,Note FROM MaterialPrice,Material WHERE Material.MaterialCode = MaterialPrice.MaterialCode");
            foreach (DataRow item in data.Rows)
            {
                MaterialPriceDTO m = new MaterialPriceDTO(item);
                listM.Add(m);
            }
            return listM;
        }
        public List<MaterialPriceDTO> GetListMaterPrice(int status)
        {
            List<MaterialPriceDTO> listM = new List<MaterialPriceDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT Id,DateInput,MaterialPrice.MaterialCode,MaterialName,PriceVND,PriceUSD,StatusPrice,VenderCode,Note FROM MaterialPrice,Material WHERE Material.MaterialCode = MaterialPrice.MaterialCode AND StatusProce = " + status);
            foreach (DataRow item in data.Rows)
            {
                MaterialPriceDTO m = new MaterialPriceDTO(item);
                listM.Add(m);
            }
            return listM;
        }
        public MaterialPriceDTO GetItemMaterPrice(long id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT Id,DateInput,MaterialPrice.MaterialCode,MaterialName,PriceVND,PriceUSD,StatusPrice,VenderCode,Note FROM MaterialPrice,Material WHERE Material.MaterialCode = MaterialPrice.MaterialCode AND Id = " + id);
            if(data.Rows.Count >0)
            {
                MaterialPriceDTO ma = new MaterialPriceDTO(data.Rows[0]);
                return ma;
            }
            return null;

        }
        public MaterialPriceDTO GetItemMaterPrice(string MaterialCode,DateTime DateInput)
        {
            return GetListAllMaterPrice().OrderByDescending(x=>x.DateInput).FirstOrDefault(x => x.MaterialCode == MaterialCode && x.DateInput == DateInput);
        }
        public MaterialPriceDTO GetItemMaterPrice(string MaterialCode, DateTime Date1 ,DateTime Date2)
        {
            return GetListAllMaterPrice().OrderByDescending(x => x.DateInput).FirstOrDefault(x => x.MaterialCode == MaterialCode && x.StatusPrice == 1 && x.DateInput >= Date1 && x.DateInput <= Date2);
        }
        public bool InsertMaPrice(string MaterialCode, DateTime DateInput, Decimal PriceVND, string PriceUSD, int StatusPrice, string Note)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture  = new CultureInfo("en-CA");
            string query = string.Format("INSERT INTO [dbo].[MaterialPrice] ([DateInput],[MaterialCode],[PriceVND],[PriceUSD],[StatusPrice],[Note]) VALUES ('{0}',N'{1}',{2},N'{3}',{4},N'{5}')",DateInput,MaterialCode,PriceVND,PriceUSD,StatusPrice,Note);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateMaPrice(long Id, string MaterialCode, DateTime DateInput, Decimal PriceVND, string PriceUSD, int StatusPrice, string Note)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format("UPDATE [dbo].[MaterialPrice] SET [DateInput] = '{1}',[MaterialCode] = N'{2}',[PriceVND] = '{3}',[PriceUSD] = N'{4}',[StatusPrice] = {5},[Note] = N'{6}' WHERE Id = {0}",Id, DateInput, MaterialCode, PriceVND, PriceUSD, StatusPrice, Note);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateMaPrice(long Id, int StatusPrice)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format("UPDATE [dbo].[MaterialPrice] SET [StatusPrice] = {1} WHERE Id = {0}", Id, StatusPrice);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteMaPrice(long Id)
        {
            string query = string.Format("DELETE [dbo].[MaterialPrice] WHERE Id = {0}",Id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        #endregion
        #region MATERIAL BY
        public List<MaterialByDTO> GetMaterialBy()
        {
            List<MaterialByDTO> listM = new List<MaterialByDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT Id,MaterialBy.MaterialCode,MaterialName,ColorCode,DateBy,QuantityBy,QuantityOrder,Note,VenderCode FROM MaterialBy,Material WHERE Material.MaterialCode = MaterialBy.MaterialCode");
            foreach (DataRow item in data.Rows)
            {
                MaterialByDTO m = new MaterialByDTO(item);
                listM.Add(m);
            }
            return listM;
        }
        public MaterialByDTO GetItemMaterialBy(long id)
        {
            return GetMaterialBy().SingleOrDefault(x => x.Id == id);
        }
        public MaterialByDTO GetItemMaterialBy(string MaterialCode,DateTime DateBy)
        {
            return GetMaterialBy().FirstOrDefault(x => x.MaterialCode == MaterialCode && x.DateBy == DateBy);
        }
        public bool InsertMaterialBy(string MaterialCode,int QuantityBy,int QuantityOrder, DateTime DateBy,string Note)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format("INSERT INTO [dbo].[MaterialBy]([MaterialCode],[QuantityBy],[QuantityOrder],[DateBy],[Note]) VALUES (N'{0}',{1},{2},'{3}',N'{4}')", MaterialCode,QuantityBy, QuantityOrder, DateBy,Note);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateMaterialBy(long Id,string MaterialCode, int QuantityBy, int QuantityOrder, DateTime DateBy, string Note)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format("UPDATE [dbo].[MaterialBy] SET [MaterialCode] = N'{1}',[QuantityBy] = {2},[DateBy] = '{3}',[Note] = N'{4}' ,[QuantityOrder] = {5} WHERE Id = {0}", Id, MaterialCode, QuantityBy, DateBy, Note,QuantityOrder);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateMaterialBy(long Id ,int QuantityBy, string Note)
        {

            string query = string.Format("UPDATE [dbo].[MaterialBy] SET [QuantityBy] = {1},[Note] = N'{2}' WHERE Id = {0}", Id, QuantityBy, Note);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateMaterialBy(long Id,  int QuantityOrder)
        {

            string query = string.Format("UPDATE [dbo].[MaterialBy] SET [QuantityOrder] = {1} WHERE Id = {0}", Id, QuantityOrder);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteMaterialBy(long Id)
        {
            string query = string.Format("DELETE [dbo].[MaterialBy] WHERE Id = {0}", Id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        #endregion
        #region REASON
        public Object GetReason(string note)
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT * FROM Reason WHERE Note = N'"+note+"'");
        }
        public Object GetReason()
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT * FROM Reason");
        }
        public bool InsertReason(string ReasonDetail,string Note)
        {
            string query = string.Format("INSERT INTO [dbo].[Reason] ([ReasonDetail],[Note]) VALUES (N'{0}',N'{1}')",ReasonDetail,Note);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateReason(string ReasonDetail, string Note,int id)
        {
            string query = string.Format("UPDATE [dbo].[Reason] [ReasonDetail] = N'{0}',[Note] = N'{1}' WHERE Id = {2}", ReasonDetail, Note,id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteReason(int id)
        {
            string query = string.Format("DELETE [dbo].[Reason] WHERE Id = {0}",id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        #endregion
    }
}
