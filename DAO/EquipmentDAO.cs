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
    public class EquipmentDAO
    {
        private static EquipmentDAO instance;

        public static EquipmentDAO Instance
        {
            get
            {
                if (instance == null) instance = new EquipmentDAO();
                return instance;
            }

            set
            {
                instance = value;
            }
        }
        #region Equipment
        public List<EquipmentDTO> GetListEquipment()
        {
            List<EquipmentDTO> listE = new List<EquipmentDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Equipment");
            foreach (DataRow item in data.Rows)
            {
                EquipmentDTO e = new EquipmentDTO(item);
                listE.Add(e);
            }
            return listE;
        }
        public List<EquipmentDTO> GetListEquipmentByStatusCheck()
        {
            List<EquipmentDTO> listE = new List<EquipmentDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Equipment WHERE StatusCheck > 0");
            foreach (DataRow item in data.Rows)
            {
                EquipmentDTO e = new EquipmentDTO(item);
                listE.Add(e);
            }
            return listE;
        }
        public bool InsertEquipment(string EquipmentCode, string EquipmentName, string Model, string Serial, string Maker, string Status, int Cycle, int StatusMail, DateTime DateInput)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format("INSERT dbo.Equipment ( EquipmentCode , EquipmentName , Model , Serial , Maker , Status , Cycle  ,StatusMail , DateInput ) VALUES  ( N'{0}' , N'{1}' , N'{2}' , N'{3}' , N'{4}' , N'{5}' , {6} , {7} ,'{8}' )", EquipmentCode, EquipmentName, Model, Serial, Maker, Status, Cycle, StatusMail, DateInput);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateEquipment(string EquipmentCode, string EquipmentName, string Model, string Serial, string Maker, string Status, int Cycle, DateTime DateInput)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format("UPDATE [dbo].[Equipment] SET [EquipmentName] = N'{1}',[Model] = N'{2}',[Serial] = N'{3}',[Maker] = N'{4}',[Status] = N'{5}',[Cycle] = {6} , [DateInput] = '{7}' WHERE [EquipmentCode] = N'{0}'", EquipmentCode, EquipmentName, Model, Serial, Maker, Status, Cycle, DateInput);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteEquipment(string EquipmentCode)
        {
            string query = string.Format("DELETE dbo.Equipment WHERE EquipmentCode = N'{0}'", EquipmentCode);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateDatecheckEquipment(string EquipmentCode, DateTime DateCheck)
        {
            string query = string.Format("UPDATE dbo.Equipment SET DateCheck = '{1}' WHERE EquipmentCode = N'{0}' ", EquipmentCode, DateCheck);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateStatusMailEquipment(string EquipmentCode, int statusMail)
        {
            string query = string.Format("UPDATE dbo.Equipment SET StatusMail = {1} WHERE EquipmentCode = N'{0}' ", EquipmentCode, statusMail);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateStatusCheckEquipment(string EquipmentCode, int statusMail)
        {
            string query = string.Format("UPDATE dbo.Equipment SET StatusCheck = {1} WHERE EquipmentCode = N'{0}' ", EquipmentCode, statusMail);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public int TestEquipmentByCode(string Code)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Equipment WHERE EquipmentCode = N'" + Code + "'");
            if (data.Rows.Count > 0)
            {
                return 1;
            }
            return -1;
        }
        public int StatusCheck(string Code)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Equipment WHERE EquipmentCode = N'" + Code + "'");
            if (data.Rows.Count > 0)
            {
                EquipmentDTO e = new EquipmentDTO(data.Rows[0]);
                return e.StatusCheck;
            }
            return -1;
        }
        public int StatusMail(string Code)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Equipment WHERE EquipmentCode = N'" + Code + "'");
            if (data.Rows.Count > 0)
            {
                EquipmentDTO e = new EquipmentDTO(data.Rows[0]);
                return e.StatusMail;
            }
            return -1;
        }
        public int Cycle(string Code)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Equipment WHERE EquipmentCode = N'" + Code + "'");
            if (data.Rows.Count > 0)
            {
                EquipmentDTO e = new EquipmentDTO(data.Rows[0]);
                return e.Cycle;
            }
            return -1;
        }
        #endregion
        #region History 
        public object GetListHistory()
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT Id,HistoryEquipment.EquipmentCode,EquipmentName,Model,DateIn,People,Employess FROM dbo.HistoryEquipment, dbo.Equipment WHERE Equipment.EquipmentCode = HistoryEquipment.EquipmentCode");
        }
        public bool InsertHistoryEquipment(string EquipmentCode, DateTime DateIn, string People, string Employess)
        {
            int resrult = DataProvider.Instance.ExecuteNonQuery("EXEC dbo.USP_InsertEquipment @EquipmentCode , @DateIn , @People ,  @Employess ", new object[] { EquipmentCode, DateIn, People, Employess });
            return resrult > 0;
        }
        public bool UpdateHistoryEquipment(long Id, string EquipmentCode, DateTime DateIn, string People, string Employess)
        {
            int resrult = DataProvider.Instance.ExecuteNonQuery("EXEC dbo.USP_UpdateHistoryEquipment @Id , @EquipmentCode , @DateIn , @People , @Employess ", new object[] { Id, EquipmentCode, DateIn, People, Employess });
            return resrult > 0;
        }
        public bool DeleteHistoryEquipment(long Id)
        {
            int resrult = DataProvider.Instance.ExecuteNonQuery("DELETE dbo.HistoryEquipment WHERE Id = " + Id);
            return resrult > 0;
        }
        public bool DeleteEquipmentBycode(string EquipmentCode)
        {
            int resrult = DataProvider.Instance.ExecuteNonQuery("DELETE dbo.HistoryEquipment WHERE EquipmentCode = " + EquipmentCode);
            return resrult > 0;
        }
        #endregion
    }
}
