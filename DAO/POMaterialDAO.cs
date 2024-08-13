using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class POMaterialDAO
    {
        private static POMaterialDAO instance;

        public static POMaterialDAO Instance
        {
            get
            {
                if (instance == null) instance = new POMaterialDAO();
                return instance;
            }
            set => instance = value;
        }
        #region POMaterial
        public List<POMaterialDTO> GetPOMaterialDTOs()
        {
            List<POMaterialDTO> listPO = new List<POMaterialDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM POMaterial");
            foreach (DataRow item in data.Rows)
            {
                POMaterialDTO p = new POMaterialDTO(item);
                listPO.Add(p);
            }
            return listPO;
        }
        public POMaterialDTO GetItemPOMaterialDTO(long Id)
        {
            return GetPOMaterialDTOs().SingleOrDefault(x => x.Id == Id);
        }
        public POMaterialDTO GetItemPOMaterialDTO(string POCode)
        {
            return GetPOMaterialDTOs().SingleOrDefault(x => x.POCode == POCode);
        }
        public POMaterialDTO GetItemPOMaterialDTO(DateTime date, string Supplier)
        {
            return GetPOMaterialDTOs().OrderByDescending(x => x.Id).FirstOrDefault(x => x.DatePO >= date && x.DatePO <= date.AddMonths(1).AddSeconds(-10) && x.SupplierCode == Supplier);
        }
        public bool InsertPOMAterial(string POCode, DateTime DateCreate, string EmployessCreate, string Location, string Payment, DateTime DateInput, string Declaration, string Bill, int StatusPO, string SupplierCode, DateTime DatePO)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format("INSERT INTO [dbo].[POMaterial] ([POCode],[DateCreate],[EmployessCreate],[Location],[Payment],[DateInput],[Declaration],[Bill],[StatusPO],[SupplierCode],[DatePO])" +
                " VALUES (N'{0}','{1}',N'{2}',N'{3}',N'{4}','{5}',N'{6}',N'{7}',{8},N'{9}','{10}')", POCode, DateCreate, EmployessCreate, Location, Payment, DateInput, Declaration, Bill, StatusPO, SupplierCode, DatePO);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdatePOMAterial(long Id, string POCode, DateTime DateCreate, string EmployessCreate, string Location, string Payment, DateTime DateInput, string Declaration, string Bill, int StatusPO, string SupplierCode, DateTime DatePO)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format("UPDATE [dbo].[POMaterial] SET [POCode] = N'{1}',[DateCreate] = '{2}',[EmployessCreate] = N'{3}',[Location] = N'{4}',[Payment] = N'{5}',[DateInput] = '{6}',[Declaration] = N'{7}',[Bill] = N'{8}',[StatusPO] = {9},[SupplierCode] = N'{10}',[DatePO]  = '{11}' WHERE Id = {0}", Id, POCode, DateCreate, EmployessCreate, Location, Payment, DateInput, Declaration, Bill, StatusPO, SupplierCode, DatePO);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdatePOMAterial(long Id, int StatusPO)
        {
            string query = string.Format("UPDATE [dbo].[POMaterial] SET [StatusPO] = {1} WHERE Id = {0}", Id, StatusPO);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdatePOMaterial(long Id, string Declaration, string Bill, int StatusPO)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format("UPDATE [dbo].[POMaterial] SET [Declaration] = N'{1}',[Bill] = N'{2}',[StatusPO] = {3} WHERE Id = {0}", Id, Declaration, Bill, StatusPO);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeletePOMAterial(long Id)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format("DELETE [dbo].[POMaterial] WHERE Id = {0}", Id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public long MaxIdPOMaterial()
        {
            try
            {
                return long.Parse(DataProvider.Instance.ExecuteScalar("SELECT MAX(Id) FROM POMaterial").ToString());
            }
            catch
            {
                return 0;
            }
        }
        #endregion
        #region POMaterial Detail
        public List<POMaterialDetail> GetPOMaterialDetails()
        {
            List<POMaterialDetail> listPO = new List<POMaterialDetail>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT Id,IdPO,MaterCode,MaterialName,ColorCode,IdBy,QuantityBy,Price,UnitPrice,StatusDetail,VenderCode FROM POMaterialDetail,Material WHERE MaterCode = Material.MaterialCode");
            foreach (DataRow item in data.Rows)
            {
                POMaterialDetail p = new POMaterialDetail(item);
                listPO.Add(p);
            }
            return listPO;
        }
        public List<POMaterialDetail> GetPOMaterialDetails(long IdPO)
        {
            List<POMaterialDetail> listPO = new List<POMaterialDetail>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT Id,IdPO,MaterCode,MaterialName,ColorCode,IdBy,QuantityBy,Price,UnitPrice,StatusDetail,VenderCode FROM POMaterialDetail,Material WHERE MaterCode = Material.MaterialCode AND IdPO = " + IdPO);
            foreach (DataRow item in data.Rows)
            {
                POMaterialDetail p = new POMaterialDetail(item);
                listPO.Add(p);
            }
            return listPO;
        }
        public POMaterialDetail GetItemPOMaterialDetail(long IdPO, long Id)
        {
            return GetPOMaterialDetails(IdPO).SingleOrDefault(x => x.Id == Id);
        }
        public POMaterialDetail GetItemPOMaterialDetail(long IdPO, string MaterialCode)
        {
            return GetPOMaterialDetails(IdPO).SingleOrDefault(x => x.MaterCode == MaterialCode);
        }
        public bool InsertPOMaterialDetail(long IdPO, string MaterCode, long IdBy, int QuantityBy, string Price, string UnitPrice, int StatusDetail)
        {
            string query = string.Format("INSERT INTO [dbo].[POMaterialDetail] ([IdPO],[MaterCode],[IdBy],[QuantityBy],[Price],[UnitPrice],[StatusDetail]) VALUES ({0},N'{1}',{2},{3},N'{4}',N'{5}',{6})", IdPO, MaterCode, IdBy, QuantityBy, Price, UnitPrice, StatusDetail);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdatePOMaterialDetail(long Id, long IdPO, string MaterCode, long IdBy, int QuantityBy, string Price, string UnitPrice, int StatusDetail)
        {
            string query = string.Format("UPDATE [dbo].[POMaterialDetail] SET [IdPO] = {1},[MaterCode] = N'{2}',[IdBy] = {3},[QuantityBy] = {4},[Price] = N'{5}',[UnitPrice] = N'{6}',[StatusDetail] = {7} WHERE Id = {0}", Id, IdPO, MaterCode, IdBy, QuantityBy, Price, UnitPrice, StatusDetail);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeletePOMaterialDetail(long Id)
        {
            string query = string.Format("DELETE [dbo].[POMaterialDetail] WHERE Id = {0}", Id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeletePO(long IdPO)
        {
            string query = string.Format("DELETE [dbo].[POMaterialDetail] WHERE IdPO = {0}", IdPO);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        #endregion
        #region Progress Detail
        public List<ProgressDetailDTO> GetProgressDetailDTOs(long IdPO)
        {
            List<ProgressDetailDTO> listP = new List<ProgressDetailDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT ProgressDetail.Id,IdDetail,QuantityPlan,DatePlan,QuantityReality,DateReality,Employess,MaterCode,MaterialName,ColorCode,IdPO,StatusProDetail FROM ProgressDetail,POMaterialDetail,Material Where IdDetail = POMaterialDetail.Id AND MaterCode = MaterialCode AND IdPO = " + IdPO);
            foreach (DataRow item in data.Rows)
            {
                ProgressDetailDTO p = new ProgressDetailDTO(item);
                listP.Add(p);
            }
            return listP;
        }
        public ProgressDetailDTO GetItemProgress(long IdPO, long Id)
        {
            return GetProgressDetailDTOs(IdPO).SingleOrDefault(x => x.Id == Id);
        }
        public DateTime? MinDatePlan(long idPO)
        {
               List<ProgressDetailDTO> listP = GetProgressDetailDTOs(idPO).OrderBy(x => x.DatePlan).ToList();
                if(listP.Count > 0)
                {
                    DateTime? date = listP.First().DatePlan;
                    return date;
                }
               return null;

        }
        public DateTime? MaxDatePlan(long idPO)
        {
            List<ProgressDetailDTO> listP = GetProgressDetailDTOs(idPO).OrderByDescending(x => x.DateReality).ToList();
            if (listP.Count > 0)
            {
                DateTime? date = listP.First().DateReality;
                return date;
            }
                return null;
        }
        public int SumQuantityPlanProgress(long IdPO, long IdDetail)
        {
            List<ProgressDetailDTO> listP = GetProgressDetailDTOs(IdPO).Where(x => x.IdDetail == IdDetail).ToList();
            int sum = 0;
            foreach (ProgressDetailDTO item in listP)
            {
                sum += item.QuantityPlan;
            }
            return sum;
        }
        public int SumQuantityPlanProgress(long IdPO, long IdDetail, long Id)
        {
            List<ProgressDetailDTO> listP = GetProgressDetailDTOs(IdPO).Where(x => x.IdDetail == IdDetail && x.Id != Id).ToList();
            int sum = 0;
            foreach (ProgressDetailDTO item in listP)
            {
                sum += item.QuantityPlan;
            }
            return sum;
        }
        public bool InsertProgress(long IdDetail, int QuantityPlan, int QuantityReality, string Employess, int StatusProDetail)
        {
            string query = string.Format("INSERT INTO [dbo].[ProgressDetail] ([IdDetail],[QuantityPlan],[QuantityReality],[Employess],[StatusProDetail]) VALUES ({0},{1},{2},N'{3}',{4})", IdDetail, QuantityPlan, QuantityReality, Employess, StatusProDetail);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateProgressPlan(long Id, int QuantityPlan, DateTime DatePlan)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format("UPDATE [dbo].[ProgressDetail] SET [QuantityPlan] = {1},[DatePlan] = '{2}' WHERE Id = {0}", Id, QuantityPlan, DatePlan);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateProgressReality(long Id, int QuantityReal, DateTime DateReal)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format("UPDATE [dbo].[ProgressDetail] SET [QuantityReality] = {1},[DateReality] = '{2}' WHERE Id = {0}", Id, QuantityReal, DateReal);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateProgress(long Id, int StatusProDetail)
        {
            string query = string.Format("UPDATE [dbo].[ProgressDetail] SET [StatusProDetail] = {1} WHERE Id = {0}", Id, StatusProDetail);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteProgress(long Id)
        {
            string query = string.Format("DELETE [dbo].[ProgressDetail] WHERE Id = {0}", Id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeletePODetail(long Id)
        {
            string query = string.Format("DELETE [dbo].[ProgressDetail] WHERE IdDetail = {0}", Id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        #endregion
    }
}
