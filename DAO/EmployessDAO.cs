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
    public class EmployessDAO
    {
        private static EmployessDAO instance;

        public static EmployessDAO Instance
        {
            get
            {
                if (instance == null) instance = new EmployessDAO();
                return instance;
            }

            set
            {
                instance = value;
            }
        }
        public List<EmployessDTO> GetlistAllEmployess()
        {
            List<EmployessDTO> listE = new List<EmployessDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Employess ");
            foreach (DataRow item in data.Rows)
            {
                EmployessDTO e = new EmployessDTO(item);
                listE.Add(e);
            }
            return listE;
        }
        public EmployessDTO GetThefirtEmployess(string code)
        {
            return GetlistAllEmployess().Where(x => x.EmployessCode == code).FirstOrDefault();
        }
        public List<EmployessDTO> GetlistEmployess()
        {
            List<EmployessDTO> listE = new List<EmployessDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Employess WHERE Status = 0");
            foreach (DataRow item in data.Rows)
            {
                EmployessDTO e = new EmployessDTO(item);
                listE.Add(e);
            }
            return listE;
        }
        public bool InsertEmployess(string EmployessCode, string EmployessName, DateTime DateInput, string RoomCode, string Super, int status)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format("INSERT dbo.Employess ( EmployessCode , EmployessName , DateInput , RoomCode , Super , Status) VALUES  ( N'{0}' ,  N'{1}' , '{2}', N'{3}' , N'{4}' , {5} )", EmployessCode, EmployessName, DateInput, RoomCode, Super, status);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateEmployess(string EmployessCode, string EmployessName, DateTime DateInput, string RoomCode, string Super, int status)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format("UPDATE dbo.Employess SET EmployessName = N'{1}',DateInput = '{2}',RoomCode = N'{3}' ,Super = N'{4}', Status = {5} WHERE EmployessCode = N'{0}'", EmployessCode, EmployessName, DateInput, RoomCode, Super, status);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateEmployess(string EmployessCode, int status)
        {
            string query = string.Format("UPDATE dbo.Employess SET  Status = {1} WHERE EmployessCode = N'{0}'", EmployessCode, status);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteEmployess(string EmployessCode)
        {
            string query = string.Format("DELETE dbo.Employess WHERE EmployessCode = N'{0}'", EmployessCode);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public int TestEmployessByCode(String EmployessCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Employess WHERE EmployessCode = N'" + EmployessCode + "'");
            if (data.Rows.Count > 0)
            {
                return 1;
            }
            return -1;
        }
        public int StatusByCode(String EmployessCode)
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT Status FROM dbo.Employess WHERE EmployessCode = N'" + EmployessCode + "'");
            }
            catch
            {
                return 0;
            }

        }
        public string RoomByCode(string code)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Employess WHERE EmployessCode = N'" + code + "'");
            if (data.Rows.Count > 0)
            {
                EmployessDTO e = new EmployessDTO(data.Rows[0]);
                return e.RoomCode;
            }
            return "";
        }
        public string NameEmployess(string code)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Employess WHERE EmployessCode = N'" + code + "'");
            if (data.Rows.Count > 0)
            {
                EmployessDTO e = new EmployessDTO(data.Rows[0]);
                return e.EmployessName;
            }
            return "";
        }
        #region Room
        public object GetListRoom()
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Room");
        }
        public bool InsertRoom(string Code, string Name)
        {
            string query = string.Format("INSERT dbo.Room ( CodeRo, NameRo )VALUES  ( N'{0}',  N'{1}')", Code, Name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateRoom(int Id, string Code, string Name)
        {
            string query = string.Format("UPDATE dbo.Room SET CodeRo = N'{1}' ,NameRo = N'{2}'  WHERE Id = {0}", Id, Code, Name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteRoom(int Id)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("DELETE dbo.Room WHERE Id = " + Id);
            return result > 0;
        }
        public int TestRoom(string code)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Room WHERE CodeRo = N'" + code + "'");
            if (data.Rows.Count > 0)
            {
                return 1;
            }
            return -1;
        }
        #endregion

        #region Error
        public object GetListError(string room)
        {
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Error WHERE RoomCode = N'ALL' OR RoomCode = N'" + room + "'");
        }
        public object GetListErrorByRoom(string room)
        {
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Error WHERE RoomCode = N'ALL' OR RoomCode = N'" + room + "'");
        }
        public bool InsertError(string name, int point, string roomcode)
        {
            string query = string.Format("INSERT dbo.Error ( NameEr, PointEr , RoomCode) VALUES  ( N'{0}', {1}, N'{2}')", name, point, roomcode);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateError(long id, string name, int point, string roomCode)
        {
            string query = string.Format("UPDATE dbo.Error SET NameEr = N'{1}', PointEr = {2} , RoomCode = N'{3}' WHERE Id = {0}", id, name, point, roomCode);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteError(long id)
        {
            string query = string.Format("DELETE dbo.Error WHERE Id = {0}", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public int TestNameEr(string name)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Error WHERE NameEr = N'" + name + "'");
            if (data.Rows.Count > 0)
            {
                return 1;
            }
            return -1;
        }
        public string NumberEr(string name)
        {
            try
            {
                return DataProvider.Instance.ExecuteScalar("SELECT Id FROM dbo.Error WHERE NameEr = N'" + name + "'").ToString();
            }
            catch
            {

                return "";
            }

        }
        #endregion

        #region Plus
        public object GetListPlus(string room)
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Plus WHERE RoomCode = N'ALL' OR RoomCode = N'" + room + "'");
        }
        public object GetListPlusByRoom(string room)
        {
            try
            {
                return (object)DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Plus WHERE RoomCode = N'ALL' OR RoomCode = N'" + room + "'");
            }
            catch
            {
                return null;
            }

        }
        public bool InsertPlus(string name, int point, string roomCode)
        {
            string query = string.Format("INSERT dbo.Plus ( NamePl, PointPl, RoomCode ) VALUES  ( N'{0}', {1} , N'{2}')", name, point, roomCode);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdatePlus(long id, string name, int point, string roomCode)
        {
            string query = string.Format("UPDATE dbo.Plus SET NamePl = N'{1}' , PointPl = {2} , RoomCode = N'{3}' WHERE Id = {0}", id, name, point, roomCode);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeletePlus(long id)
        {
            string query = string.Format("DELETE dbo.Plus WHERE Id = {0}", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public int TestNamePl(string name)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Plus WHERE NamePl = N'" + name + "'");
            if (data.Rows.Count > 0)
            {
                return 1;
            }
            return -1;
        }
        public string NumberPl(string name)
        {
            try
            {
                return DataProvider.Instance.ExecuteScalar("SELECT Id FROM dbo.Plus WHERE NamePl = N'" + name + "'").ToString();
            }
            catch
            {
                return "";
            }

        }
        #endregion

        #region Số ghi chép
        public object GetlistWriteEmployess()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.InforEmployess");
        }
        public object GetlistWriteEmployessByDate(DateTime date1, DateTime date2)
        {
            string query = string.Format("SELECT * FROM dbo.InforEmployess,dbo.Employess WHERE EmployessCode = CodeEm AND DateHis >= '{0}' AND DateHis <= '{1}' ORDER BY StatusInforEm DESC", date1, date2);
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public object GetlistWriteEmployessByRoomCode(DateTime date1, DateTime date2, string RoomCode)
        {
            string query = string.Format("SELECT * FROM dbo.InforEmployess,dbo.Employess WHERE EmployessCode = CodeEm AND RoomCode = N'{2}' AND DateHis >= '{0}' AND DateHis <= '{1}' ORDER BY StatusInforEm DESC", date1, date2, RoomCode);
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public object GetlistWriteEmployessByRoomCode(DateTime date1, DateTime date2)
        {
            string query = string.Format("SELECT * FROM dbo.InforEmployess,dbo.Employess WHERE EmployessCode = CodeEm  AND DateHis >= '{0}' AND DateHis <= '{1}' AND (RoomCode = N'Des' OR RoomCode = N'M.Pro') ORDER BY StatusInforEm DESC", date1, date2);
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public object GetlistWriteEmployessByRoomCodeQCPRO(DateTime date1, DateTime date2)
        {
            string query = string.Format("SELECT * FROM dbo.InforEmployess,dbo.Employess WHERE EmployessCode = CodeEm  AND DateHis >= '{0}' AND DateHis <= '{1}' AND (RoomCode = N'QC' OR RoomCode = N'Pro') ORDER BY StatusInforEm DESC", date1, date2);
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public bool InsertWriteEmployess(string CodeEm, DateTime DateHis, string NameEr, string NamePl, int PointEr, int PointPl, DateTime DateInput, string Note, int StatusInforEm)
        {
            string query = string.Format("INSERT dbo.InforEmployess ( CodeEm ,DateHis ,NameEr ,NamePl , PointEr , PointPl , DateInput , Note , StatusInforEm) VALUES  ( N'{0}' , '{1}' , N'{2}' ,  N'{3}' , {4} , {5} , '{6}' , N'{7}', {8})", CodeEm, DateHis, NameEr, NamePl, PointEr, PointPl, DateInput, Note, StatusInforEm);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateWriteEmployess(long id, string CodeEm, DateTime DateHis, string NameEr, string NamePl, int PointEr, int PointPl, string Note, int StatusInforEm)
        {
            string query = string.Format("UPDATE dbo.InforEmployess SET CodeEm = N'{1}' , DateHis = '{2}' , NameEr = N'{3}' , NamePl = N'{4}' , PointEr = {5} , PointPl = {6} , Note = N'{7}', StatusInforEm = {8} WHERE Id = {0}", id, CodeEm, DateHis, NameEr, NamePl, PointEr, PointPl, Note, StatusInforEm);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool ApproEmployess(long id, int StatusEm)
        {
            string query = string.Format("UPDATE dbo.InforEmployess SET StatusInforEm = N'{1}'  WHERE Id = {0}", id, StatusEm);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteWriteEmployess(long id)
        {
            string query = string.Format("DELETE dbo.InforEmployess WHERE Id = {0}", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public string EmCodeById(long id)
        {
            try
            {
                return DataProvider.Instance.ExecuteScalar("Select CodeEm FROM dbo.InforEmployess WHERE Id = " + id).ToString();
            }
            catch
            {
                return null;
            }
        }
        public int PoitEr(string nameEr, string room)
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT PointEr FROM dbo.Error WHERE NameEr = N'" + nameEr + "' AND (RoomCode = N'" + room + "' OR RoomCode = N'ALL')");
            }
            catch
            {
                return 0;
            }
        }
        public int PoitPl(string namePl, string room)
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT PointPl FROM dbo.Plus WHERE NamePl = N'" + namePl + "' AND (RoomCode = N'" + room + "' OR RoomCode = N'ALL')");
            }
            catch
            {
                return 0;
            }
        }
        public int TotalPoitEr(string codeEm, DateTime date1, DateTime date2)
        {
            try
            {
                string query = string.Format("SELECT SUM(PointEr) FROM dbo.InforEmployess WHERE CodeEm = N'{0}' AND StatusInforEm = 0 AND DateHis >= '{1}' AND DateHis <= '{2}'", codeEm, date1, date2);
                return (int)DataProvider.Instance.ExecuteScalar(query);
            }
            catch
            {
                return 0;
            }
        }
        public int CountEr(string codeEm, DateTime date1, DateTime date2)
        {
            try
            {
                string query = string.Format("SELECT COUNT(PointEr) FROM dbo.InforEmployess WHERE CodeEm = N'{0}' AND StatusInforEm = 0 AND PointEr <> 0 AND DateHis >= '{1}' AND DateHis <= '{2}'", codeEm, date1, date2);
                return (int)DataProvider.Instance.ExecuteScalar(query);
            }
            catch
            {
                return 0;
            }
        }
        public int TotalPoitPl(string codeEm, DateTime date1, DateTime date2)
        {
            try
            {
                string query = string.Format("SELECT SUM(PointPl) FROM dbo.InforEmployess WHERE CodeEm = N'{0}' AND StatusInforEm = 0 AND DateHis >= '{1}' AND DateHis <= '{2}'", codeEm, date1, date2);
                return (int)DataProvider.Instance.ExecuteScalar(query);
            }
            catch
            {
                return 0;
            }
        }
        public int CountPl(string codeEm, DateTime date1, DateTime date2)
        {
            try
            {
                string query = string.Format("SELECT COUNT(PointPl) FROM dbo.InforEmployess WHERE CodeEm = N'{0}' AND StatusInforEm = 0 AND PointPl <> 0 AND DateHis >= '{1}' AND DateHis <= '{2}'", codeEm, date1, date2);
                return (int)DataProvider.Instance.ExecuteScalar(query);
            }
            catch
            {
                return 0;
            }
        }
        #endregion
        #region Positon
        public Object GetListPosition()
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT * FROM Position");
        }
        public bool InsertPosition(string code, string name)
        {
            string query = string.Format("INSERT INTO [dbo].[Position] ([PositionCode],[PositionName]) VALUES (N'{0}',N'{1}')", code, name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool EditPosition(string code, string name)
        {
            string query = string.Format("UPDATE [dbo].[Position] SET [PositionName] = N'{1}' WHERE [PositionCode] = N'{0}'", code, name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeletePosition(string code)
        {
            string query = string.Format("DELETE [dbo].[Position] WHERE PositionCode = N'{0}'", code);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public int TestPosition(string name)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Position WHERE PositionName = N'" + name + "'");
            if (data.Rows.Count > 0)
            {
                return 1;
            }
            return -1;
        }
        #endregion
        #region Employess Card
        public List<EmployessCard> GetListEmployessCard()
        {
            List<EmployessCard> listE = new List<EmployessCard>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT EmployessCard.EmployessCode,EmployessName,PositionName,LinkImage FROM EmployessCard,Employess WHERE EmployessCard.EmployessCode = Employess.EmployessCode");
            foreach (DataRow item in data.Rows)
            {
                EmployessCard e = new EmployessCard(item);
                listE.Add(e);
            }
            return listE;
        }
        public bool InsertEmployessCard(string code, string name, string link)
        {
            string query = string.Format("INSERT INTO [dbo].[EmployessCard] ([EmployessCode] ,[PositionName] ,[LinkImage]) VALUES (N'{0}',N'{1}',N'{2}')", code, name, link);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateEmployessCard(string code, string name, string link)
        {
            string query = string.Format("UPDATE [dbo].[EmployessCard] SET [PositionName] = N'{1}' ,[LinkImage] = N'{2}' WHERE [EmployessCode] = N'{0}'", code, name, link);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteEmployessCard(string code)
        {
            string query = string.Format("DELETE [dbo].[EmployessCard] WHERE [EmployessCode] = N'{0}", code);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        #endregion
    }
}
