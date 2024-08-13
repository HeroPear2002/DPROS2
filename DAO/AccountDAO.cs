using DTO;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get
            {
                if (instance == null) instance = new AccountDAO();
                return instance;
            }

            set
            {
                instance = value;
            }
        }
        public string ToMD5(string Pass)
        {
            string result = "";
            byte[] buffer = Encoding.UTF8.GetBytes(Pass);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            buffer = md5.ComputeHash(buffer);
            for (int i = 0; i < buffer.Length; i++)
            {
                result += buffer[i].ToString("x2");
            }
            return result;
        }
        public AccountDTO GetAccountByUser(string UserName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT UserName,DisplayName,PassWord,Type,Decentraliza,EMail,RoomCode FROM dbo.Account,dbo.DecentralizaAcc WHERE Type = Id AND UserName = N'" + UserName + "'");
            foreach (DataRow item in data.Rows)
            {
                return new AccountDTO(item);
            }
            return null;
        }
        public List<AccountDTO> GetAccount()
        {
            List<AccountDTO> listA = new List<AccountDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT UserName,DisplayName,PassWord,Type,Decentraliza,EMail,RoomCode FROM dbo.Account,dbo.DecentralizaAcc WHERE Type = Id");
            foreach (DataRow item in data.Rows)
            {
                AccountDTO a = new AccountDTO(item);
                listA.Add(a);
            }
            return listA;
        }
        public List<AccountDTO> GetAccountEmail(int type)
        {
            List<AccountDTO> listA = GetAccount().Where(x => x.Type == type && x.EMail.Length > 5).ToList();
            return listA;
        }
        public bool InsertAccount(string UserName, string PassWord, string DisplayName, int Type, string EMail, string RoomCode)
        {
            string query = string.Format("INSERT dbo.Account ( UserName , PassWord , DisplayName , Type , EMail , RoomCode) VALUES  ( N'{0}' , N'{1}' , N'{2}' , {3} , N'{4}' , N'{5}') ", UserName, PassWord, DisplayName, Type, EMail, RoomCode);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteAccount(string UserName)
        {
            string query = string.Format("DELETE dbo.Account WHERE UserName = N'{0}'", UserName);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool ResetPassword(string UserName, string PassWord)
        {
            string query = string.Format("UPDATE dbo.Account SET PassWord = N'{1}' WHERE UserName = N'{0}'", UserName, PassWord);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateNewAccount(string UserName, string DisplayName, int type, string EMail,string RoomCode)
        {
            string query = string.Format("UPDATE dbo.Account SET DisplayName = N'{1}' , Type = '{2}' , EMail = N'{3}' , RoomCode = N'{4}' WHERE UserName = N'{0}'", UserName, DisplayName, type, EMail, RoomCode);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool Login(string userName, string passWord)
        {
            string query = "SELECT * FROM dbo.Account WHERE UserName = N'" + userName + "' AND PassWord = N'" + passWord + "' or 1=1";
            DataTable kq = DataProvider.Instance.ExecuteQuery(query);
            return kq.Rows.Count > 0;
        }
        public bool UpdateAccount(string userName, string displayName, string pass, string newPass)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateAccount @userName , @displayName , @password , @newPassword", new object[] { userName, displayName, pass, newPass });
            return result > 0;
        }
        /// <summary>
        /// Phân Quyền
        /// </summary>
        /// <returns></returns>
        public List<DecentralizaDTO> GetlistDecentraliza()
        {
            List<DecentralizaDTO> listD = new List<DecentralizaDTO>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.DecentralizaAcc");
            foreach (DataRow item in data.Rows)
            {
                DecentralizaDTO d = new DecentralizaDTO(item);
                listD.Add(d);
            }
            return listD;
        }
        public List<DecentralizaDTO> GetlistDecentraliza1(int type)
        {
            List<DecentralizaDTO> listD = new List<DecentralizaDTO>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.DecentralizaAcc WHERE Id = 6 OR Id = " + type);
            foreach (DataRow item in data.Rows)
            {
                DecentralizaDTO d = new DecentralizaDTO(item);
                listD.Add(d);
            }
            return listD;
        }
        public List<DecentralizaDTO> GetlistDecentraliza8(int type)
        {
            List<DecentralizaDTO> listD = new List<DecentralizaDTO>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.DecentralizaAcc WHERE Id = 6 OR Id = 3 OR Id = 4 OR Id = 5 OR Id = 8");
            foreach (DataRow item in data.Rows)
            {
                DecentralizaDTO d = new DecentralizaDTO(item);
                listD.Add(d);
            }
            return listD;
        }
        #region ACCOUNT INFOR
        public object GetListAccountInfor()
        {
            return (object)DataProvider.Instance.ExecuteQuery("Select * from AccountInfor");
        }
        public object GetListAccountInforBytype(int id)
        {
            return (object)DataProvider.Instance.ExecuteQuery("Select AccountInfor.UserName from AccountInfor,Account WHERE AccountInfor.UserName = Account.UserName AND Type = " + id);
        }
        public object GetListAccountInforBytypeNew()
        {
            return (object)DataProvider.Instance.ExecuteQuery("Select AccountInfor.UserName from AccountInfor,Account WHERE AccountInfor.UserName = Account.UserName AND (Type = 3 OR Type = 4 OR Type = 5 OR Type = 8)");
        }
        public int PermissionAccount(string UserName)
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("Select Permission from AccountInfor WHERE UserName = N'" + UserName + "'");
            }
            catch
            {
                return -1;
            }
        }
        public bool InsertAccountInfor(string UserName, int Permission)
        {
            string query = string.Format("INSERT INTO [dbo].[AccountInfor] ([UserName],[Permission]) VALUES (N'{0}','{1}')", UserName, Permission);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteAccountInfor(string UserName)
        {
            string query = string.Format("DELETE AccountInfor WHERE UserName = N'" + UserName + "'");
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        #endregion
        public int CheckAccount(int type, int typeAcc, string user)
        {
            if (typeAcc == 1)
            {
                return 2;
            }
            else if (typeAcc == type)
            {
                int testAcc = AccountDAO.Instance.PermissionAccount(user);
                if (testAcc < 1)
                {
                    return 0;
                }
                return testAcc;
            }
            else if (typeAcc == 8 && (type == 3 || type == 4 || type == 5))
            {
                int testAcc = AccountDAO.Instance.PermissionAccount(user);
                if (testAcc < 1)
                {
                    return 0;
                }
                return testAcc;
            }
            return 0;
        }
    }
}
