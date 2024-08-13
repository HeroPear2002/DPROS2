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
   public class PODAO
    {
        private static PODAO instance;

        public static PODAO Instance
        {
            get
            {
                if (instance == null) instance = new PODAO();
                return instance;
            }

            set
            {
                instance = value;
            }
        }
        #region PO Input
        public List<PODTO> GetListPOInput()
        {
            List<PODTO> listP = new List<PODTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT Id,POCode,PartCode,QuantityIn,DateInput,StatusPO,FactoryCode,Price,DateOut,Customer,QuantityOut, (QuantityIn - QuantityOut) AS Quantity ,ROUND(((((QuantityOut)*100)/(NULLIF(QuantityIn,0)))),0,1)AS Ratio FROM dbo.USP_POInput WHERE StatusPO <> 1  ORDER BY DateOut");
            foreach (DataRow item in data.Rows)
            {
                PODTO p = new PODTO(item);
                listP.Add(p);
            }
            return listP;
        }
        public List<PODTO> GetListAllPOInput()
        {
            List<PODTO> listP = new List<PODTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT Id,POCode,PartCode,QuantityIn,DateInput,StatusPO,FactoryCode,Price,DateOut,Customer,QuantityOut, (QuantityIn - QuantityOut) AS Quantity ,ROUND(((((QuantityOut)*100)/(NULLIF(QuantityIn,0)))),0,1)AS Ratio FROM dbo.USP_POInput ");
            foreach (DataRow item in data.Rows)
            {
                PODTO p = new PODTO(item);
                listP.Add(p);
            }
            return listP;
        }
        public List<PODTO> GetListAllPOInput(DateTime date1,DateTime date2)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            List<PODTO> listP = new List<PODTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT Id,POCode,PartCode,QuantityIn,DateInput,StatusPO,FactoryCode,Price,DateOut,Customer,QuantityOut, (QuantityIn - QuantityOut) AS Quantity ,ROUND(((((QuantityOut)*100)/(NULLIF(QuantityIn,0)))),0,1)AS Ratio FROM dbo.USP_POInput WHERE DateOut >= '" + date1+"' AND DateOut <= '"+date2+"'");
            foreach (DataRow item in data.Rows)
            {
                PODTO p = new PODTO(item);
                listP.Add(p);
            }
            return listP;
        }
        public PODTO GetItemPOInput(long Id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT Id,POCode,PartCode,QuantityIn,DateInput,StatusPO,FactoryCode,Price,DateOut,Customer,QuantityOut, (QuantityIn - QuantityOut) AS Quantity ,ROUND(((((QuantityOut)*100)/(NULLIF(QuantityIn,0)))),0,1)AS Ratio FROM dbo.USP_POInput WHERE Id = " + Id);
            if (data.Rows.Count > 0)
            {
                PODTO p = new PODTO(data.Rows[0]);
                return p;
            }
            return null;
        }
        public bool InsertPO(string POCode, string PartCode, int QuantityIn, DateTime DateInput, int StatusPO, string FactoryCode,string Price ,DateTime DateOut ,string Customer)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("EXEC dbo.USP_InsertPOInput @POCode , @PartCode , @QuantityIn , @DateInput , @StatusPO , @FactoryCode , @Price , @DateOut , @Customer ", new object[] {POCode,PartCode,QuantityIn,DateInput,StatusPO,FactoryCode,Price,DateOut,Customer});
            return result > 0;
        }
        public bool UpdatePO(long Id,string POCode, string PartCode, int QuantityIn, DateTime DateInput, int StatusPO, string FactoryCode, string Price, DateTime DateOut, string Customer)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("EXEC dbo.USP_UpdatePOInput @Id , @POCode , @PartCode , @QuantityIn , @DateInput , @StatusPO , @FactoryCode , @Price , @DateOut , @Customer", new object[] {Id,POCode,PartCode,QuantityIn,DateInput,StatusPO,FactoryCode,Price,DateOut,Customer });
            return result > 0;
        }
        public bool DeletePO(string POCode)
        {
            string query = string.Format("DELETE dbo.USP_POInput WHERE POCode = N'{0}'", POCode);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeletePO(long Id)
        {
            string query = string.Format("DELETE dbo.USP_POInput WHERE Id = "+Id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateStatusPO(long Id,int status)
        {
            string query = string.Format("UPDATE dbo.USP_POInput SET StatusPO = {1} WHERE Id = {0}", Id,status);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateQuantityOut(long Id, int QuantityOut)
        {
            string query = string.Format("UPDATE dbo.USP_POInput SET QuantityOut = {1} WHERE Id = {0}", Id,QuantityOut);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public long TestPO(long Id)
        {
            try
            {
              return  GetItemPOInput(Id).Id;
            }
            catch 
            {
                return -1;
            }
        }
        public long TestPO(string POCode,string PartCode, string Price)
        {
            string query = string.Format("SELECT Id,POCode,PartCode,QuantityIn,DateInput,StatusPO,FactoryCode,Price,DateOut,Customer,QuantityOut, (QuantityIn - QuantityOut) AS Quantity ,ROUND(((((QuantityOut)*100)/(NULLIF(QuantityIn,0)))),0,1)AS Ratio FROM dbo.USP_POInput WHERE POCode = N'{0}' AND PartCode = N'{1}' AND Price = N'{2}'", POCode, PartCode, Price);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            if (data.Rows.Count > 0)
            {
                PODTO p = new PODTO(data.Rows[0]);
                return p.Id;
            }
            return -1;
        }
        public int StatusPO(long Id)
        {
            try
            {
                return GetItemPOInput(Id).StatusPO;
            }
            catch
            {
                return -1;
            }
        }
        //public int StatusPO(long Id)
        //{
        //    DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.USP_POInput WHERE Id = "+Id);
        //    if (data.Rows.Count > 0)
        //    {
        //        PODTO p = new PODTO(data.Rows[0]);
        //        return p.StatusPO;
        //    }
        //    return -1;
        //}
        public string Customer(long Id)
        {
            try
            {
                return GetItemPOInput(Id).Customer;
            }
            catch
            {
                return "";
            }
        }
        public string FactoryPO(long Id)
        {
            try
            {
                return GetItemPOInput(Id).FactoryCode;
            }
            catch
            {
                return "";
            }
        }
        public int QuantityInputPO(long Id)
        {
            try
            {
                return GetItemPOInput(Id).QuantityIn;
            }
            catch
            {
                return 0;
            }
        }
        public int QuantityOutPO(long Id)
        {
            try
            {
                return GetItemPOInput(Id).QuantityOut;
            }
            catch
            {
                return 0;
            }
        }

        public string TOTAL()
        {
            List<PODTO> listP = GetListPOInput();
            foreach (PODTO item in listP)
            {
                UpdateQuantityOut(item.Id,SumQuantityOut(item.Id));
            }
            return "a";
        }
        #endregion
        #region PO Output
        public object GetListOutput(DateTime date1, DateTime date2)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            return DataProvider.Instance.ExecuteQuery("SELECT USP_POOutput.POCode,USP_POInput.PartCode,InputPart.DateManufacturi,DateOutput,USP_POOutput.QuantityOut,MachineCode,MoldNumber,Name,Lot,IdDe FROM dbo.USP_POInput,dbo.USP_POOutput,dbo.InputPart,dbo.WareHouse WHERE USP_POInput.POCode = USP_POOutput.POCode AND InputPart.Id = IdInput AND IdWareHouse = WareHouse.Id AND DateOutput >='" +date1+"' AND DateOutput <='" +date2+"'");
        }
        public int SumQuantityOut(string POCode)
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT SUM(QuantityOut) FROM dbo.USP_POOutput WHERE POCode = N'"+POCode+"'");
            }
            catch 
            {
                return 0;
            }
        }
        public int SumQuantityOut(long IdPOInput)
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT SUM(QuantityOut) FROM dbo.USP_POOutput WHERE IdPOInput = "+IdPOInput);
            }
            catch
            {
                return 0;
            }
        }
        public int SumQuantityOut(long IdPOInput,DateTime Date1,DateTime Date2)
        {
            try
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
                string query = string.Format("SELECT SUM(QuantityOut) FROM dbo.USP_POOutput WHERE DateOutput >= '{1}' AND DateOutput <= '{2}' AND IdPOInput = {0}", IdPOInput,Date1,Date2);
                return (int)DataProvider.Instance.ExecuteScalar(query);
            }
            catch
            {
                return 0;
            }
        }
        public bool InsertPOOutput(string POCode , DateTime DateOut , int QuantityOut,long IdInput, string Note , long IdPOInput, long IdDe)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("EXEC dbo.USP_InsertPOOutput @POCode ,  @DateOut ,  @QuantityOut , @IdInput , @Note , @IdPOInput , @IdDe", new object[]{ POCode, DateOut , QuantityOut, IdInput, Note,IdPOInput, IdDe });
            return result > 0;
        }
        public bool UpdatePOOutputByDate(string POCode, long IdPOInput)
        {
            string query = string.Format("UPDATE dbo.USP_POOutput SET IdPOInput = {1} WHERE POCode = N'{0}'", POCode,IdPOInput);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeletePOOutputByDate(DateTime date)
        {
            string query = string.Format("DELETE dbo.USP_POOutput WHERE DateOutput <= '{0}'",date);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public List<OnlyDateOutput> GetListOnlyDateOut(long IdPOInput)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            List<OnlyDateOutput> listDt = new List<OnlyDateOutput>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT Distinct(DateOutput) FROM USP_POOutput WHERE IdPOInput = "+IdPOInput+" ORDER BY DateOutput");
            foreach (DataRow item in data.Rows)
            {
                OnlyDateOutput o = new OnlyDateOutput(item);
                listDt.Add(o);
            }
            return listDt;
        }
        #endregion
    }
}
