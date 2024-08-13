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
    public class DeliveryDAO
    {
        private static DeliveryDAO instance;

        public static DeliveryDAO Instance
        {
            get
            {
                if (instance == null) instance = new DeliveryDAO();
                return instance;
            }
            set => instance = value;
        }
        #region DELIVERY NOTES
        public List<DeliveryNotesDTO> GetListALLDelivery()
        {
            List<DeliveryNotesDTO> listDe = new List<DeliveryNotesDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM DeliveryNotes");
            foreach (DataRow item in data.Rows)
            {
                DeliveryNotesDTO de = new DeliveryNotesDTO(item);
                listDe.Add(de);
            }
            return listDe;
        }
        public List<DeliveryNotesDTO> GetListALLDelivery(DateTime date1,DateTime date2)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            List<DeliveryNotesDTO> listDe = new List<DeliveryNotesDTO>();
            string query = string.Format("SELECT * FROM DeliveryNotes WHERE DateInput >= '{0}' AND DateInput <= '{1}'",date1,date2);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                DeliveryNotesDTO de = new DeliveryNotesDTO(item);
                listDe.Add(de);
            }
            return listDe;
        }
        public List<DeliveryNotesDTO> GetListDelivery()
        {
            List<DeliveryNotesDTO> listDe = new List<DeliveryNotesDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM DeliveryNotes WHERE StatusDe = 0");
            foreach (DataRow item in data.Rows)
            {
                DeliveryNotesDTO de = new DeliveryNotesDTO(item);
                listDe.Add(de);
            }
            return listDe;
        }
        public int StatusDe(long id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM DeliveryNotes WHERE Id = "+id);
            if(data.Rows.Count>0)
            {
                DeliveryNotesDTO de = new DeliveryNotesDTO(data.Rows[0]);
                return de.StatusDe;
            }
            return -1;
        }
        public long IdDelivery(long id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM DeliveryNotes WHERE Id = " + id);
            if (data.Rows.Count > 0)
            {
                DeliveryNotesDTO de = new DeliveryNotesDTO(data.Rows[0]);
                return de.Id;
            }
            return -1;
        }
        public DeliveryNotesDTO GetItemDelivery(long Id)
        {
            return GetListALLDelivery().SingleOrDefault(x => x.Id == Id);
        }
        public long MaxIdDelivery()
        {
            return long.Parse(DataProvider.Instance.ExecuteScalar("SELECT MAX(Id) FROM DeliveryNotes").ToString());
        }
        public bool InsertDelivery( string DeCode, DateTime DateInput, string EmployessCreate, string EmployessChange, int StatusDe, string Note, DateTime DateDelivery)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format("INSERT INTO [dbo].[DeliveryNotes] ([DeCode],[DateInput],[EmployessCreate],[EmployessChange],[StatusDe],[Note],[DateDelivery])VALUES(N'{0}','{1}',N'{2}',N'{3}',{4},N'{5}','{6}')", DeCode,DateInput,EmployessCreate,EmployessChange,StatusDe,Note, DateDelivery);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateDelivery(long Id, string DeCode, DateTime DateInput, string EmployessCreate, string EmployessChange, int StatusDe, string Note)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format("UPDATE [dbo].[DeliveryNotes] SET [DeCode] = N'{1}',[DateInput] = '{2}',[EmployessCreate] = N'{3}',[EmployessChange] = N'{4}',[StatusDe] = {5},[Note] = N'{6}' WHERE Id = {0}", Id,DeCode, DateInput, EmployessCreate, EmployessChange, StatusDe, Note);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateDeliveryOUT(long Id, DateTime DateOutput, string EmployessOut)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format("UPDATE [dbo].[DeliveryNotes] SET [DateOutput] = '{1}', [EmployessOut] = N'{2}' WHERE Id = {0}", Id, DateOutput,EmployessOut);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateDeliveryChange(long Id, DateTime DateChange, string EmployessChange)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format("UPDATE [dbo].[DeliveryNotes] SET [DateChange] = '{1}', [EmployessChange] = N'{2}' WHERE Id = {0}", Id, DateChange, EmployessChange);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateDelivery(long Id, int StatusDe, string Note)
        {
            string query = string.Format("UPDATE [dbo].[DeliveryNotes] SET [StatusDe] = {1}, [Note] = N'{2}' WHERE Id = {0}", Id, StatusDe,Note);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteDelivery(long Id)
        {
            string query = string.Format("DELETE [dbo].[DeliveryNotes] WHERE Id = {0}",Id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        #endregion
        #region DELIVERY DETAIL
        public List<DeliveryDetail> GetListDeliveryDetail(long idDe)
        {
            List<DeliveryDetail> listDe = new List<DeliveryDetail>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT DeliveryDetail.Id,IdPOFix,POFix.POCode,POFix.PartCode,Quantity,POFix.DateOut,DeCode,FactoryCustomer,CarNumber,FactoryCode,StatusDetail,DeliveryDetail.QuantityOut FROM DeliveryDetail,DeliveryNotes,POFix,USP_POInput WHERE DeliveryDetail.IdDe = DeliveryNotes.Id AND IdPOFix = POFix.Id AND IdPOInput = USP_POInput.Id AND DeliveryDetail.IdDe = " + idDe);
            foreach (DataRow item in data.Rows)
            {
                DeliveryDetail de = new DeliveryDetail(item);
                listDe.Add(de);
            }
            return listDe;
        }
        public List<PartCodeDTO> GetPartCodeDTOs(long idDe)
        {
            List<PartCodeDTO> listDe = new List<PartCodeDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT DISTINCT(POFix.PartCode) FROM DeliveryDetail,DeliveryNotes,POFix,USP_POInput WHERE DeliveryDetail.IdDe = DeliveryNotes.Id AND IdPOFix = POFix.Id AND IdPOInput = USP_POInput.Id AND DeliveryDetail.IdDe = " + idDe);
            foreach (DataRow item in data.Rows)
            {
                PartCodeDTO de = new PartCodeDTO(item);
                listDe.Add(de);
            }
            return listDe;
        }
        public List<DeliveryDetail> GetListDeliveryDetailByIdPOInput(long IdPOInput)
        {
            List<DeliveryDetail> listDe = new List<DeliveryDetail>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT DeliveryDetail.Id,IdPOFix,POFix.POCode,POFix.PartCode,Quantity,POFix.DateOut,DeCode,FactoryCustomer,CarNumber,FactoryCode,StatusDetail,DeliveryDetail.QuantityOut FROM DeliveryDetail,DeliveryNotes,POFix,USP_POInput WHERE DeliveryDetail.IdDe = DeliveryNotes.Id AND IdPOFix = POFix.Id AND IdPOInput = USP_POInput.Id AND IdPOInput = " + IdPOInput);
            foreach (DataRow item in data.Rows)
            {
                DeliveryDetail de = new DeliveryDetail(item);
                listDe.Add(de);
            }
            return listDe;
        }
        public DeliveryDetail GetItemDeliveryDtail(long idDe)
        {
           return GetListDeliveryDetail(idDe).FirstOrDefault();
        }
        public int CheckStatus(long idDe)
        {
            List<DeliveryDetail> listDe = GetListDeliveryDetail(idDe);
            foreach (DeliveryDetail item in listDe)
            {
                item.StatusDetail = 0;
                return 0;
            }
            return 1;
        }
        public int SumQuantityDetail(string partCode,string factCode, string deCode)
        {
            try
            {
                return int.Parse(DataProvider.Instance.ExecuteScalar("SELECT SUM(Quantity) FROM DeliveryDetail,DeliveryNotes,POFix,USP_POInput WHERE DeliveryDetail.IdDe = DeliveryNotes.Id AND IdPOFix = POFix.Id AND IdPOInput = USP_POInput.Id AND POFix.PartCode = N'"+partCode+"' AND FactoryCode = N'"+factCode+ "' AND DeCode = N'"+deCode+"'").ToString());
            }
            catch 
            {
               return 0;
            }
        }
        public int SumQuantityDetail(string partCode, string factCode, long IdDe)
        {
            try
            {
                string query = "SELECT SUM(Quantity) FROM DeliveryDetail,DeliveryNotes,POFix,USP_POInput WHERE DeliveryDetail.IdDe = DeliveryNotes.Id AND IdPOFix = POFix.Id AND IdPOInput = USP_POInput.Id AND POFix.PartCode = N'" + partCode + "' AND FactoryCode = N'" + factCode + "' AND DeliveryDetail.IdDe = " + IdDe;
                return int.Parse(DataProvider.Instance.ExecuteScalar(query).ToString());
            }
            catch
            {
                return 0;
            }
        }
        public int TestDeliveryDetail(long IdPOFix)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM DeliveryDetail WHERE IdPOFix = " + IdPOFix);
            if(data.Rows.Count > 0)
            {
                return 1;
            }
            return -1;
        }
        public bool InsertDeliveryDetail(long IdPOFix, long IdDe,string Note,int StatusDetail,int QuantityOut)
        {
            string query = string.Format("INSERT INTO [dbo].[DeliveryDetail] ([IdPOFix],[IdDe],[Note],[StatusDetail],[QuantityOut]) VALUES({0},{1},N'{2}',{3},{4})", IdPOFix,IdDe,Note,StatusDetail,QuantityOut);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateDeliveryDetail(long Id,long IdPOFix, long IdDe, string Note)
        {
            string query = string.Format("UPDATE [dbo].[DeliveryDetail] SET [IdPOFix] = {1},[IdDe] = {2},[Note] = N'{3}' WHERE Id = {0}", Id,IdPOFix, IdDe, Note);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateDeliveryDetail(long Id, int StatusDetail,int QuantityOut)
        {
            string query = string.Format("UPDATE [dbo].[DeliveryDetail] SET [StatusDetail] = {1},[QuantityOut] = {2} WHERE Id = {0}", Id, StatusDetail, QuantityOut);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteDeliveryDetail(long Id)
        {
            string query = string.Format("DELETE [dbo].[DeliveryDetail] WHERE Id = {0}",Id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteDeliveryDetailIdDe(long IdDe)
        {
            string query = string.Format("DELETE [dbo].[DeliveryDetail] WHERE IdDe = {0}", IdDe);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        #endregion
    }
}
