
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
   public class MoldDAO
    {
        private static MoldDAO instance;

        public static MoldDAO Instance
        {
            get
            {
                if (instance == null) instance = new MoldDAO();
                return instance;
            }
            set
            {
                instance = value;
            }
        }
        #region Mold List
        public List<MoldDTO> GetListMold()
        {
            List<MoldDTO> listM = new List<MoldDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Mold");
            foreach (DataRow item in data.Rows)
            {
                MoldDTO m = new MoldDTO(item);
                listM.Add(m);
            }
            return listM;
        }
        public string MoldNumber(string MoldCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Mold WHERE MoldCode = N'"+MoldCode+"'");
            if(data.Rows.Count >0)
            {
                MoldDTO m = new MoldDTO(data.Rows[0]);
                return m.MoldNumber;
            }
            return null;
        }
        public bool InsertMold(string MoldCode, string MoldName, string MoldNumber,string MoldModel ,string Maker ,DateTime DateInput ,string InputWhere ,DateTime DateSX ,int ShotCount ,string Employess ,string Note )
        {
            string query = string.Format("INSERT dbo.Mold ( MoldCode , MoldName , MoldNumber , MoldModel , Maker , DateInput , InputWhere , DateSX , ShotCount , Employess , Note ) VALUES  ( N'{0}' , N'{1}' , N'{2}' , N'{3}' , N'{4}' , '{5}' , N'{6}' , '{7}' , {8} , N'{9}' , N'{10}' )", MoldCode, MoldName, MoldNumber, MoldModel, Maker, DateInput, InputWhere, DateSX, ShotCount, Employess, Note);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdatetMold(string MoldCode, string MoldName, string MoldNumber, string MoldModel, string Maker, DateTime DateInput, string InputWhere, DateTime DateSX, int ShotCount, string Employess, string Note)
        {
            string query = string.Format("UPDATE [dbo].[Mold] SET [MoldName] = N'{1}' ,[MoldNumber] = N'{2}'  ,[MoldModel] = N'{3}' ,[Maker] = N'{4}',[DateInput] = '{5}',[InputWhere] = N'{6}' ,[DateSX] = '{7}' ,[ShotCount] = {8} ,[Employess] = N'{9}' ,[Note] = N'{10}' WHERE [MoldCode] = N'{0}'", MoldCode, MoldName, MoldNumber, MoldModel, Maker, DateInput, InputWhere, DateSX, ShotCount, Employess, Note);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteMold(string MoldCode)
        {
            string query = string.Format("DELETE dbo.Mold WHERE MoldCode = N'{0}'", MoldCode);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public int TestMoldByCode(string MoldCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Mold WHERE MoldCode = N'" + MoldCode + "'");
            if(data.Rows.Count >0)
            {
                return 1;
            }
            return -1;
        }
        #endregion
        #region Mold Infor
        public List<MoldInforDTO> GetListMoldInfor()
        {
            List<MoldInforDTO> listM = new List<MoldInforDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.MoldInfor");
            foreach (DataRow item in data.Rows)
            {
                MoldInforDTO m = new MoldInforDTO(item);
                listM.Add(m);
            }
            return listM;
        }
        public MoldInforDTO GetItem(string MoldCode)
        {
            return GetListMoldInfor().Find(x => x.MoldCode == MoldCode);
        }
        public List<MoldInforDTO> GetListMoldInforNotNull()
        {
            List<MoldInforDTO> listM = new List<MoldInforDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.MoldInfor WHERE DateCheck <> N''");
            foreach (DataRow item in data.Rows)
            {
                MoldInforDTO m = new MoldInforDTO(item);
                listM.Add(m);
            }
            return listM;
        }
        public bool UpdateMoldInforByQRCode(string MoldCode, int ShotTC, int ShotTT, int TotalShot, string Category, string Cav, int confirm)
        {
            string query = string.Format("UPDATE [dbo].[MoldInfor] SET [ShotTC] = {1},[ShotTT] = {2},[TotalShot] = {3},[Category] = N'{4}',[Cav] = N'{5}', [Confirm] = {6} WHERE [MoldCode] = N'{0}'", MoldCode, ShotTC, ShotTT, TotalShot, Category, Cav, confirm);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool InsertMoldInfor(string MoldCode, int ShotTC, int ShotTT, int TotalShot, int Confirm, string Category, string Note, string StatusMold, string Cav, string CavNG, string PlanMold, DateTime DateCheck, int Warn)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format("INSERT dbo.MoldInfor ( MoldCode , ShotTC , ShotTT ,TotalShot , Confirm , Category , Note , StatusMold , Cav , CavNG , PlanMold , DateCheck , Warn ) VALUES  ( N'{0}' , {1} , {2} , {3} , {4} , N'{5}' , N'{6}' , N'{7}' , N'{8}' , N'{9}' , N'{10}' , '{11}' , {12} )", MoldCode, ShotTC, ShotTT, TotalShot, Confirm, Category, Note, StatusMold, Cav, CavNG, PlanMold, DateCheck, Warn);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateMoldInfor(string MoldCode, int ShotTC, int ShotTT, int TotalShot, string Category, string Note, string StatusMold, string Cav, string CavNG, string PlanMold)
        {
            string query = string.Format("UPDATE [dbo].[MoldInfor] SET [ShotTC] = {1},[ShotTT] = {2},[TotalShot] = {3},[Category] = N'{4}',[Note] = N'{5}',[StatusMold] = N'{6}',[Cav] = N'{7}' ,[CavNG] = N'{8}' , [PlanMold] = N'{9}' WHERE [MoldCode] = N'{0}'", MoldCode, ShotTC, ShotTT, TotalShot, Category, Note, StatusMold, Cav, CavNG, PlanMold);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateNoteMoldInfor(string MoldCode, string Note)
        {
            string query = string.Format("UPDATE dbo.MoldInfor SET Note = N'{1}' WHERE MoldCode = N'{0}'", MoldCode, Note);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateDateCheckMoldInfor(string MoldCode, DateTime date, int warn)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format("UPDATE dbo.MoldInfor SET DateCheck = '{1}', Warn = {2} WHERE MoldCode = N'{0}'", MoldCode, date, warn);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateWainMoldInfor(string MoldCode, int warn)
        {
            string query = string.Format("UPDATE dbo.MoldInfor SET Warn = {1} WHERE MoldCode = N'{0}'", MoldCode, warn);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateConfirmMoldInfor(string MoldCode, int Confirm)
        {
            string query = string.Format("UPDATE dbo.MoldInfor SET Confirm = {1} WHERE MoldCode = N'{0}'", MoldCode, Confirm);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateShotTTMoldInfor(string MoldCode, int ShotTT)
        {
            string query = string.Format("UPDATE dbo.MoldInfor SET ShotTT = {1} WHERE MoldCode = N'{0}'", MoldCode, ShotTT);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdatePlanMoldInfor(string MoldCode, string PlanMold)
        {
            string query = string.Format("UPDATE dbo.MoldInfor SET PlanMold = N'{1}' WHERE MoldCode = N'{0}'", MoldCode, PlanMold);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteMoldInfor(string MoldCode)
        {
            string query = string.Format("DELETE dbo.MoldInfor WHERE MoldCode = N'{0}'", MoldCode);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateShotByCode(string MoldCode,int ShotTT,int TotalShot)
        {
            string query = string.Format("UPDATE dbo.MoldInfor SET ShotTT = {1} , TotalShot = {2} WHERE MoldCode = N'{0}'", MoldCode,ShotTT,TotalShot);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public int ShoTTByCode(string MoldCode)
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT ShotTT FROM dbo.MoldInfor WHERE MoldCode = N'" + MoldCode + "'");
            }
            catch 
            {
                return 0;
            }
        }
        public int ShoTTCByCode(string MoldCode)
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT ShotTC FROM dbo.MoldInfor WHERE MoldCode = N'" + MoldCode + "'");
            }
            catch
            {
                return 0;
            }
        }
        public int ConfirmMold(string MoldCode)
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT Confirm FROM dbo.MoldInfor WHERE MoldCode = N'" + MoldCode + "'");
            }
            catch 
            {
                return 0;
            }
        
        }
        public string NoteMold(string MoldCode)
        {
            return (string)DataProvider.Instance.ExecuteScalar("SELECT Note FROM dbo.MoldInfor WHERE MoldCode = N'" + MoldCode + "'");
        }
        public int TotalShotByCode(string MoldCode)
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT TotalShot FROM dbo.MoldInfor WHERE MoldCode = N'" + MoldCode + "'");
            }
            catch 
            {
                return 0;
            }
          
        }
        public int TestMoldInforByCode(string MoldCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.MoldInfor WHERE MoldCode = N'" + MoldCode + "'");
            if (data.Rows.Count > 0)
            {
                return 1;
            }
            return -1;
        }
        public int WarnMoldInforByCode(string MoldCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.MoldInfor WHERE MoldCode = N'" + MoldCode + "'");
            if (data.Rows.Count > 0)
            {
                MoldInforDTO m = new MoldInforDTO(data.Rows[0]);
               return m.Warn;
            }
            return 0;
        }
        public bool UpdateCategoryMold(string MoldCode, string Category)
        {
            string query = string.Format("UPDATE dbo.MoldInfor SET Category = N'{1}' WHERE MoldCode = N'{0}'", MoldCode, Category);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        #endregion
        #region Mold Confirm
        public bool InsertMoldConfirm(string MoldCode,int TypeUser)
        {
            string query = string.Format("INSERT dbo.MoldConfirm ( MoldCode, TypeUser ) VALUES  ( N'{0}',  {1} )",MoldCode,TypeUser);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteMoldConfirm(string MoldCode)
        {
            string query = string.Format("DELETE dbo.MoldConfirm WHERE MoldCode = N'{0}'", MoldCode);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public int TestMoldConfirm(string Moldcode,int TypeUser)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.MoldConfirm WHERE MoldCode = N'"+Moldcode+"' AND TypeUser = "+TypeUser);
            if(data.Rows.Count>0)
            {
                return 1;
            }
            return -1;
        }
        public int TestConfirm(string Moldcode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.MoldConfirm WHERE MoldCode = N'" + Moldcode + "'");
            if (data.Rows.Count == 3)
            {
                return 1;
            }
            return -1;
        }
        
        #endregion
        #region Mold History
        public object GetListMoldHistory(string MoldCode)
        {
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.MoldHistory WHERE MoldCode = N'"+MoldCode+"'");
        }
        public object GetListErrorMold()
        {
           
           return  DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.ErrorMold WHERE StatusError = 1");
        }
        public object GetListTribeMold()
        {
           return  DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.ErrorMold WHERE StatusError = 2");
        
        }
        public object GetListCategoryMold()
        {
          return DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.ErrorMold WHERE StatusError = 3");
        }
        public bool DeleteMoldHistory(int Id)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("DELETE dbo.MoldHistory WHERE Id = " + Id);
            return result > 0;
        }
        public bool UpdateHistoryMold(int Id, string MachineCode, DateTime DateError, string Category, string Error, string TribeError, string Detail, DateTime DateStart, DateTime DateEnd, float TotalTime, string Detail1, string Detail2, string Detail3, string Detail4, string Detail5, string Detail6)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("EXEC dbo.USP_UpdateMoldHistory @Id , @MachineCode , @DateError , @Category , @Error , @TribeError , @Detail , @DateStart , @DateEnd , @TotalTime , @Detail1 , @Detail2 , @Detail3 , @Detail4 , @Detail5 , @Detail6 ", new object[] { Id, MachineCode, DateError, Category, Error, TribeError, Detail, DateStart, DateEnd, TotalTime, Detail1, Detail2, Detail3, Detail4, Detail5, Detail6 });
            return result > 0;
        }
        public bool UpdateHistoryCountMold(int Id, int countShort, int totalShort)
        {
            string query = string.Format("UPDATE MoldHistory SET CountShort = {1} , TotalShort = {2} WHERE Id = {0}", Id, countShort, totalShort);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public int MaxId(string MoldCode)
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(Id) FROM dbo.MoldHistory WHERE MoldCode = N'" + MoldCode + "'");
            }
            catch
            {
                return 0;
            }
        }
        public string CategoryById(int Id)
        {
            try
            {
                return DataProvider.Instance.ExecuteScalar("SELECT  Category FROM dbo.MoldHistory WHERE Id = " + Id).ToString();
            }
            catch 
            {
                return null;
            }
           
        }
        #endregion
        #region Mold Error
        public object GetErrorMold(int StatusError)
        {
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.ErrorMold WHERE StatusError = "+StatusError);
        }
        public int IdErrorMold(string name)
        {
            try
            {
                return int.Parse(DataProvider.Instance.ExecuteScalar("SELECT Id FROM dbo.ErrorMold WHERE StatusError = 3 AND NameError = N'" + name + "'").ToString());
            }
            catch
            {
                return -1;
            }

        }
        public string NameErrorMold(int id)
        {
            try
            {
                return DataProvider.Instance.ExecuteScalar("SELECT NameError FROM dbo.ErrorMold WHERE Id = " + id).ToString();
            }
            catch
            {
                return "";
            }
        }
        public string NoteErrorMold(int id)
        {
            try
            {
                return DataProvider.Instance.ExecuteScalar("SELECT Note FROM dbo.ErrorMold WHERE Id = " + id).ToString();
            }
            catch
            {
                return "";
            }

        }
        public bool InsertErrorMold(string NameError, int StatusError, string Note)
        {
            string query = string.Format("INSERT dbo.ErrorMold ( NameError, StatusError, Note ) VALUES ( N'{0}', {1} , N'{2}')", NameError, StatusError, Note);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateErrorMold(int Id, string NameError, int StatusError,string Note)
        {
            string query = string.Format("UPDATE [dbo].[ErrorMold] SET [NameError] = N'{1}' ,[StatusError] = {2}, [Note] = N'{3}' WHERE Id = {0}", Id, NameError, StatusError,Note);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteErrorMold(int Id)
        {
            string query = string.Format("DELETE dbo.ErrorMold WHERE Id = {0}", Id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        #endregion

    }
}
