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
    public class TDSXDAO
    {
        private static TDSXDAO instance;

        public static TDSXDAO Instance
        {
            get
            {
                if (instance == null) instance = new TDSXDAO();
                return instance;
            }

            set
            {
                instance = value;
            }
        }
        #region Số tấn của máy đúc
        public string InforMachine(string MachineCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Machine");
            if (data.Rows.Count > 0)
            {
                MachineDTO m = new MachineDTO(data.Rows[0]);
                return m.MachineInfor;
            }
            return "";
        }
        public int WeightMachine(string str)
        {
            if (str.Length > 6)
            {
                int result = int.Parse(str.Substring(1, 3));
                return result;
            }
            else
            {
                int result = int.Parse(str.Substring(2, 3));
                return result;
            }
        }
        #endregion
        #region EndTime
        public int TestMaxEndTtime(string MachineCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.KHBD WHERE MachineCode = N'" + MachineCode + "' AND ConfirmBD = 0 ORDER BY EndTime DESC");
            if (data.Rows.Count > 0)
            {

                return 1;
            }
            return -1;
        }
        public DateTime GetMaxEndTtime(string MachineCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.KHBD WHERE MachineCode = N'" + MachineCode + "' ORDER BY EndTime DESC");
            KHBDDTO t = new KHBDDTO(data.Rows[0]);
            return t.EndTime;
        }
        #endregion
        #region KHBD
        public List<KHBDDTO> GetListKHBD()
        {
            List<KHBDDTO> listK = new List<KHBDDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.KHBD WHERE ConfirmBD = 0 ORDER BY StartTime DESC");
            foreach (DataRow item in data.Rows)
            {
                KHBDDTO k = new KHBDDTO(item);
                listK.Add(k);
            }
            return listK;
        }
        public List<KHBDDTO> GetKHBDByDate(DateTime Date)
        {
            List<KHBDDTO> listK = new List<KHBDDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC dbo.USP_GetListKHBDByDate @date", new object[] { Date });
            foreach (DataRow item in data.Rows)
            {
                KHBDDTO k = new KHBDDTO(item);
                listK.Add(k);
            }
            return listK;
        }
        public bool InsertKHBD(string MachineCode, string PartCode, string MoldCode, DateTime StartTime, DateTime EndTime, int CountBD, int ConfirmBD)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("EXEC dbo.USP_InsertKHBD @MachineCode , @PartCode , @MoldCode , @StartTime , @EndTime , @CountBD , @ConfirmBD ", new object[] { MachineCode, PartCode, MoldCode, StartTime, EndTime, CountBD, ConfirmBD });
            return true;
        }
        public bool DeleteKHBDbyId(long Id)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("DELETE dbo.KHBD WHERE Id = " + Id);
            return result > 0;
        }
        public List<KHBDDTO> GetlistKHBDbyDate(string MachineCode, DateTime Date1, DateTime Date2)
        {

            List<KHBDDTO> listK = new List<KHBDDTO>();
            string query = string.Format("SELECT * FROM dbo.KHBD WHERE MachineCode = N'{0}' AND StartTime >='{1}' AND EndTime <= '{2}'", MachineCode, Date1, Date2);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                KHBDDTO k = new KHBDDTO(item);
                listK.Add(k);
            }
            return listK;
        }
        public string MoldCodeKHBD(long Id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.KHBD WHERE Id = " + Id);
            if (data.Rows.Count > 0)
            {
                KHBDDTO k = new KHBDDTO(data.Rows[0]);
                return k.MoldCode;
            }
            return "";
        }

        #endregion
        #region KHSĐ
        public List<KHSDDTO> GetListKHSD()
        {
            List<KHSDDTO> listK = new List<KHSDDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.KHSD WHERE ConfirmSD = 0 ORDER BY StartTime DESC");
            foreach (DataRow item in data.Rows)
            {
                KHSDDTO k = new KHSDDTO(item);
                listK.Add(k);
            }
            return listK;
        }
        public List<KHSDDTO> GetlistKHSDbyDate(string Machine, DateTime Date1, DateTime Date2)
        {
            List<KHSDDTO> listK = new List<KHSDDTO>();
            string query = string.Format("SELECT * FROM dbo.KHSD WHERE MachineCode = N'{0}' AND StartTime >= '{1}' AND EndTime <= '{2}'", Machine, Date1, Date2);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                KHSDDTO k = new KHSDDTO(item);
                listK.Add(k);
            }
            return listK;
        }
        public bool InsertKHSD(long IdBD, string MachineCode, string PartCode, string MoldCode, DateTime StartTime, DateTime EndTime, int CountSD, int ConfirmSD)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("EXEC dbo.USP_InsertKHSD @IdBD , @MachineCode , @PartCode , @MoldCode , @StartTime , @EndTime , @CountSD , @ConfirmSD ", new object[] { IdBD, MachineCode, PartCode, MoldCode, StartTime, EndTime, CountSD, ConfirmSD });
            return result > 0;
        }
        public bool DeleteKHSD(long Id)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("DELETE dbo.KHSD WHERE Id = " + Id);
            return result > 0;
        }
        public int TestMaxEndtimeKHSD(string Machine)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.KHSD WHERE MachineCode = N'" + Machine + "'");
            if (data.Rows.Count > 0)
            {
                return 1;
            }
            return -1;
        }
        public DateTime GetMaxEndTimeKHSD(string Machine)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.KHSD WHERE MachineCode = N'" + Machine + "' ORDER BY EndTime DESC");
            KHSDDTO k = new KHSDDTO(data.Rows[0]);
            return k.EndTime;
        }
        public int QuantitySD(long Id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.KHSD WHERE Id = " + Id);
            if (data.Rows.Count > 0)
            {
                KHSDDTO k = new KHSDDTO(data.Rows[0]);
                return k.CountSD;
            }
            return 1;
        }
        public long IdKHSD(string Machine, string PartCode, DateTime Date)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC dbo.USP_SelectIDSD @MachineCode , @PartCode , @Date ", new object[] { Machine, PartCode, Date });
            if (data.Rows.Count > 0)
            {
                KHSDDTO k = new KHSDDTO(data.Rows[0]);
                return k.Id;
            }
            return -1;
        }
        public int TestKHSDbyKHBD(long IdBD)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.KHSD WHERE IdBD = " + IdBD);
            if (data.Rows.Count > 0)
            {
                return 1;
            }
            return -1;
        }
        public long MaxIdKHBD()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.KHSD WHERE ConfirmSD = 0 ORDER BY StartTime DESC");
            if (data.Rows.Count > 0)
            {
                KHSDDTO k = new KHSDDTO(data.Rows[0]);
                return k.Id;
            }
            return -1;
        }
        public DateTime StartTimeKHSD(long Id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.KHSD WHERE Id =" + Id);
            KHSDDTO k = new KHSDDTO(data.Rows[0]);
            return k.StartTime;
        }
        #endregion
        #region TTSX
        public List<TTSXDTO> GetListTTSX()
        {
            List<TTSXDTO> listT = new List<TTSXDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TTSX WHERE ConfirmTT = 0 ORDER BY StartTime DESC ");
            foreach (DataRow item in data.Rows)
            {
                TTSXDTO t = new TTSXDTO(item);
                listT.Add(t);
            }
            return listT;
        }
        public List<TTSXDTO> GetListTTSXbyDate(string Machine, DateTime Date1, DateTime Date2)
        {
            List<TTSXDTO> listT = new List<TTSXDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TTSX WHERE MachineCode = N'" + Machine + "' AND StartTime >= '" + Date1 + "' AND EndTime <='" + Date2 + "'");
            foreach (DataRow item in data.Rows)
            {
                TTSXDTO t = new TTSXDTO(item);
                listT.Add(t);
            }
            return listT;
        }
        public bool InsertTTSX(long IdSD, string MachineCode, string PartCode, string MoldCode, DateTime StartTime, DateTime EndTime, int CountTT, int ConfirmTT)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("EXEC dbo.USP_InsertTTSX @IdSD , @MachineCode , @PartCode , @MoldCode , @StartTime , @EndTime , @CountTT , @ConfirmTT ", new object[] { IdSD, MachineCode, PartCode, MoldCode, StartTime, EndTime, CountTT, ConfirmTT });
            return result > 0;
        }
        public bool UpdateTTSX(long Id, long IdSD, DateTime StartTime, DateTime EndTime, int CountTT)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("EXEC dbo.USP_UpdateTTSX @Id , @IdSD , @StartTime , @EndTime , @CountTT ", new object[] { Id, IdSD, StartTime, EndTime, CountTT });
            return result > 0;
        }
        public bool DeleteTTSX(long Id)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("DELETE dbo.TTSX WHERE Id = " + Id);
            return result > 0;
        }
        public int TestMaxEndTimeTTSX(string Machine)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TTSX WHERE MachineCode = N'" + Machine + "' ORDER BY EndTime DESC");
            if (data.Rows.Count > 0)
            {
                return 1;
            }
            return -1;
        }
        public DateTime MaxEndTimeTTSX(string Machine)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TTSX WHERE MachineCode = N'" + Machine + "' ORDER BY EndTime DESC");
            TTSXDTO t = new TTSXDTO(data.Rows[0]);
            return t.EndTime;
        }
        public long IdTTSX(long IdSD)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TTSX WHERE IdSD = " + IdSD);
            if (data.Rows.Count > 0)
            {
                TTSXDTO t = new TTSXDTO(data.Rows[0]);
                return t.Id;
            }
            return -1;
        }
        public int QuantityTTSX(long Id)
        {
            return (int)DataProvider.Instance.ExecuteScalar("SELECT CountTT FROM dbo.TTSX WHERE Id =" + Id);
        }
        public DateTime StartTimeTT(long Id)
        {
            return (DateTime)DataProvider.Instance.ExecuteScalar("SELECT StartTime FROM dbo.TTSX WHERE Id =" + Id);
        }
        public DateTime EndTimeTT(long Id)
        {
            return (DateTime)DataProvider.Instance.ExecuteScalar("SELECT EndTime FROM dbo.TTSX WHERE Id =" + Id);
        }
        #endregion
        #region KHNL
        public List<KHNLDTO> GetListKHNL()
        {
            List<KHNLDTO> listK = new List<KHNLDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.KHNL WHERE Confirm = 0 ORDER BY StartTime DESC");
            foreach (DataRow item in data.Rows)
            {
                KHNLDTO k = new KHNLDTO(item);
                listK.Add(k);
            }
            return listK;
        }
        public List<KHNLDTO> GetListKHNLbyDate(string Machine, DateTime Date1, DateTime Date2)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            List<KHNLDTO> listK = new List<KHNLDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.KHNL WHERE MachineCode = N'" + Machine + "' AND StartTime >= '" + Date1 + "' AND EndTime <= '" + Date2 + "'");
            foreach (DataRow item in data.Rows)
            {
                KHNLDTO k = new KHNLDTO(item);
                listK.Add(k);
            }
            return listK;
        }
        public long IdKHNLByIDSD(long IdSD)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.KHNL WHERE IdSD = " + IdSD);
            if (data.Rows.Count > 0)
            {
                KHNLDTO k = new KHNLDTO(data.Rows[0]);
                return k.Id;
            }
            return -1;
        }
        public bool InsertKHNL(long IdSD, string MaterialCode, string MaterialName, string MachineCode, DateTime StartTime, DateTime EndTime, int CountNL, int Confirm)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("EXEC dbo.USP_InsertKHNL @IdSD , @MaterialCode , @MaterialName , @MachineCode , @StartTime , @EndTime , @CountNL , @Confirm ", new object[] { IdSD, MaterialCode, MaterialName, MachineCode, StartTime, EndTime, CountNL, Confirm });
            return result > 0;
        }
        public bool DeleteKHNL(long Id)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("DELETE dbo.KHNL WHERE Id = " + Id);
            return result > 0;
        }
        public bool DeleteKHNLByIdSD(long IdSD)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("DELETE dbo.KHNL WHERE IdSD = " + IdSD);
            return result > 0;
        }

        #endregion
        #region Lable
        public object GetListLable()
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.LabelColor");
        }
        #endregion
        #region TableSX
        public List<TableSX> GetListTableSX()
        {
            List<TableSX> listT = new List<TableSX>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableSX");
            foreach (DataRow item in data.Rows)
            {
                TableSX t = new TableSX(item);
                listT.Add(t);
            }
            return listT;
        }
        public List<TableSX> GetListTableSX(DateTime date1 ,DateTime date2)
        {
            List<TableSX> listT = new List<TableSX>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableSX WHERE (EndTime >= '"+date1+"' AND EndTime <= '"+date2+"') OR (StartTime >='"+date1+"' AND StartTime <= '"+date2+"')");
            foreach (DataRow item in data.Rows)
            {
                TableSX t = new TableSX(item);
                listT.Add(t);
            }
            return listT;
        }
        public long MaxIdTableSX()
        {
            return (long)DataProvider.Instance.ExecuteScalar("SELECT MAX(Id) FROM dbo.TableSX");
        }
        public bool InsertTableSX(int IdResource, string MachineCode, string MoldNumber, string PartCode, DateTime StartTime, DateTime EndTime, int Quantity, int ColorSX, int ConfirmSX, string Employess)
        {
            string query = string.Format("INSERT dbo.TableSX( IdResource , MachineCode , MoldNumber , PartCode , StartTime , EndTime , Quantity , ColorSX , ConfirmSX , Employess) VALUES  ( {0} , N'{1}' , N'{2}' , N'{3}' ,'{4}' , '{5}' , {6} , {7} , {8} , N'{9}')", IdResource, MachineCode, MoldNumber, PartCode, StartTime, EndTime, Quantity, ColorSX, ConfirmSX, Employess);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateTableSX(long Id, int Quantity, DateTime EndTime, int ColorSX, int ConfirmSX)
        {
            string query = string.Format("UPDATE dbo.TableSX SET Quantity = {1} , EndTime = '{2}', ColorSX = {3} , ConfirmSX = {4}  WHERE Id = {0}", Id, Quantity, EndTime, ColorSX, ConfirmSX);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteTableSX(long id)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("DELETE dbo.TableSX WHERE Id = " + id);
            return result > 0;
        }
        public string PartCodeByID(long id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableSX WHERE Id = " + id);
            if (data.Rows.Count > 0)
            {
                TableSX t = new TableSX(data.Rows[0]);
                return t.PartCode;
            }
            return "";
        }
        public string MoldNumberByID(long id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableSX WHERE Id = " + id);
            if (data.Rows.Count > 0)
            {
                TableSX t = new TableSX(data.Rows[0]);
                return t.MoldNumber;
            }
            return "";
        }
        public string MachineByID(long id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableSX WHERE Id = " + id);
            if (data.Rows.Count > 0)
            {
                TableSX t = new TableSX(data.Rows[0]);
                return t.MachineCode;
            }
            return "";
        }
        public int QuantitySXByID(long id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableSX WHERE Id = " + id);
            if (data.Rows.Count > 0)
            {
                TableSX t = new TableSX(data.Rows[0]);
                return t.Quantity;
            }
            return 1;
        }
        public long IdSXByALL(string machine, string part, string mold)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableSX WHERE MachineCode = N'" + machine + "' AND PartCode = N'" + part + "' AND MoldNumber = N'" + mold + "' ORDER BY Id DESC ");
            if (data.Rows.Count > 0)
            {
                TableSX t = new TableSX(data.Rows[0]);
                return t.Id;
            }
            return -1;
        }
        public DateTime MaxEndTimeSX(string machineCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableSX WHERE MachineCode = N'" + machineCode + "' ORDER BY EndTime DESC");
            if (data.Rows.Count > 0)
            {
                TableSX t = new TableSX(data.Rows[0]);
                return t.EndTime;
            }
            return DateTime.Now.AddMinutes(-60);
        }
        public long MaxIdSX(string machineCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableSX WHERE MachineCode = N'" + machineCode + "' ORDER BY EndTime DESC");
            if (data.Rows.Count > 0)
            {
                TableSX t = new TableSX(data.Rows[0]);
                return t.Id;
            }
            return -1;
        }
        public DateTime EndTimeSX(long Id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableSX WHERE Id = " + Id);
            if (data.Rows.Count > 0)
            {
                TableSX t = new TableSX(data.Rows[0]);
                return t.EndTime;
            }
            return DateTime.Now.AddMinutes(-10);
        }
        public DateTime MaxStartTimeSX(string MachineCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableSX WHERE MachineCode = N'"+ MachineCode + "' Order by StartTime DESC");
            if (data.Rows.Count > 0)
            {
                TableSX t = new TableSX(data.Rows[0]);
                return t.StartTime;
            }
            return DateTime.Now.AddMinutes(-10);
        }
        public DateTime MinStartTimeSX(long id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableSX WHERE Id > " + id + " Order by StartTime DESC");
            if (data.Rows.Count > 0)
            {
                TableSX t = new TableSX(data.Rows[0]);
                return t.StartTime;
            }
            return DateTime.Now.AddMinutes(-10);
        }
        public int ConfirmSX(string machineCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableSX WHERE MachineCode = N'" + machineCode + "' AND ConfirmSX = 1 ORDER BY EndTime DESC");
            if (data.Rows.Count > 0)
            {
                TableSX t = new TableSX(data.Rows[0]);
                return t.ConfirmSX;
            }
            return -1;
        }
        public int ConfirmSXById(long id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableSX WHERE Id = " +id);
            if (data.Rows.Count > 0)
            {
                TableSX t = new TableSX(data.Rows[0]);
                return t.ConfirmSX;
            }
            return -1;
        }
        public int ColorSXById(long id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableSX WHERE Id = " + id);
            if (data.Rows.Count > 0)
            {
                TableSX t = new TableSX(data.Rows[0]);
                return t.ColorSX;
            }
            return -1;
        }
        public object GetPartCode()
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT DISTINCT(PartCode) FROM dbo.TableSX");
        }
        public object GetMolnumber(string partCode)
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT DISTINCT(MoldNumber) FROM dbo.TableSX WHERE PartCode = N'" + partCode + "'");
        }
        public object GetMachineCode(string partcode, string moldnumber)
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT DISTINCT(MachineCode) FROM dbo.TableSX WHERE PartCode = N'" + partcode + "' AND MoldNumber = N'" + moldnumber + "'");
        }
        #endregion
        #region TableTT
        public List<TableTT> GetListTableTT()
        {
            List<TableTT> listT = new List<TableTT>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableTT");
            foreach (DataRow item in data.Rows)
            {
                TableTT t = new TableTT(item);
                listT.Add(t);
            }
            return listT;
        }
        public List<TableTT> GetListTableTT(long idSX)
        {
            List<TableTT> listT = new List<TableTT>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableTT WHERE IdSX = "+idSX);
            foreach (DataRow item in data.Rows)
            {
                TableTT t = new TableTT(item);
                listT.Add(t);
            }
            return listT;
        }
        public bool InsertTableTT(int IdResource, long IdSX, DateTime StartTime, DateTime EndTime, int Quantity, int ColorTT, int ConfirmTT, DateTime MaxTime, string Note)
        {
            string query = string.Format(" INSERT dbo.TableTT( IdResource , IdSX , StartTime , EndTime , Quantity , ColorTT , ConfirmTT , MaxTime , Note) VALUES  ( {0} , {1} , '{2}' , '{3}' , {4} , {5} , {6} ,'{7}' , N'{8}')", IdResource, IdSX, StartTime, EndTime, Quantity, ColorTT, ConfirmTT, MaxTime, Note);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteTableTT(long id)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("DELETE dbo.TableT WHERE Id = " + id);
            return result > 0;
        }
        public bool UpdateTableTT(long id, DateTime endTime, int quantity)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format("UPDATE dbo.TableTT SET EndTime = '{1}',Quantity = {2} WHERE Id = {0}", id, endTime, quantity);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateMaxTimeTableTT(long id, DateTime maxTime)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format("UPDATE dbo.TableTT SET MaxTime = '{1}' WHERE Id = {0}", id, maxTime);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public long IDTableTT(long idsx)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableTT WHERE ConfirmTT = 1 AND IdSX = " + idsx + " ORDER BY Id DESC");
            if (data.Rows.Count > 0)
            {
                TableTT t = new TableTT(data.Rows[0]);
                return t.Id;
            }
            return -1;
        }
        public long IDTableTTByDate(long idsx, DateTime today)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableTT WHERE ConfirmTT = 1 AND IdSX = " + idsx + " AND StartTime <= '" + today + "'  ORDER BY Id DESC");
            if (data.Rows.Count > 0)
            {
                TableTT t = new TableTT(data.Rows[0]);
                return t.Id;
            }
            return -1;
        }
        public long IDTableTTConfirm2(long idsx)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableTT WHERE ConfirmTT = 2 AND IdSX = " + idsx + " ORDER BY Id DESC");
            if (data.Rows.Count > 0)
            {
                TableTT t = new TableTT(data.Rows[0]);
                return t.Id;
            }
            return -1;
        }
        public int IDResourceTableTT(long idsx)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableTT WHERE ConfirmTT = 1 AND IdSX = " + idsx + " ORDER BY Id DESC");
            if (data.Rows.Count > 0)
            {
                TableTT t = new TableTT(data.Rows[0]);
                return t.IdResource;
            }
            return -1;
        }
        public int QuantityTT(long id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableTT WHERE Id = " + id);
            if (data.Rows.Count > 0)
            {
                TableTT t = new TableTT(data.Rows[0]);
                return t.Quantity;
            }
            return 0;
        }
        public DateTime MaxTimeTT(long id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableTT WHERE Id = " + id);
            TableTT t = new TableTT(data.Rows[0]);
            return t.MaxTime;
        }
        public DateTime MaxEndTimeTTByIdSX(long idSX)
        {
            return  (DateTime)DataProvider.Instance.ExecuteScalar("SELECT Max(EndTime) FROM dbo.TableTT WHERE IdSX = " + idSX);
        }
        public DateTime EndTimeTableTT(long id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableTT WHERE Id = " + id);
            TableTT t = new TableTT(data.Rows[0]);
            return t.EndTime;
        }
        public bool DeleteTableTTByIDSX(long id)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("DELETE dbo.TableTT WHERE IdSX = " + id);
            return result > 0;
        }
        #endregion
        #region TableDK
        public List<TableDK> GetListTableDK()
        {
            List<TableDK> listT = new List<TableDK>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableDK");
            foreach (DataRow item in data.Rows)
            {
                TableDK t = new TableDK(item);
                listT.Add(t);
            }
            return listT;
        }
        public List<TableDK> GetListTableDK(long idSX)
        {
            List<TableDK> listT = new List<TableDK>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableDK WHERE IdSX = "+idSX);
            foreach (DataRow item in data.Rows)
            {
                TableDK t = new TableDK(item);
                listT.Add(t);
            }
            return listT;
        }
        public bool InsertTableDK(int IdResource, long IdSX, DateTime StartTime, DateTime EndTime, int ColorDK, int ConfirmDK, DateTime WarnTime, string Employess)
        {
            string query = string.Format("INSERT dbo.TableDK ( IdResource , IdSX , StartTime , EndTime , ColorDK , ConfirmDK , WarnTime , Employess) VALUES  ( {0} ,  {1} , '{2}' , '{3}' , {4} , {5} ,'{6}' ,N'{7}')", IdResource, IdSX, StartTime, EndTime, ColorDK, ConfirmDK, WarnTime, Employess);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteTableDKX(long id)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("DELETE dbo.TableDK WHERE Id = " + id);
            return result > 0;
        }
        public bool DeleteTableDKByDate(DateTime date, long idsx)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("DELETE dbo.TableDK WHERE StartTime >= ' " + date + "' AND IdSX = " + idsx);
            return result > 0;
        }
        public bool UpdateTableDK(long Iddk, DateTime EndTime, DateTime WarnTime)
        {
            string query = string.Format(" UPDATE dbo.TableDK SET EndTime = '{1}', WarnTime = '{2}' WHERE Id = {0}", Iddk, EndTime, WarnTime);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateConfirmTableDK(long Iddk, DateTime EndTime, int confirm, int color, string Note, string Employess)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format(" UPDATE dbo.TableDK SET EndTime = '{1}', ConfirmDK = {2} , ColorDK = {3} , Note = N'{4}' , Employess = N'{5}' WHERE Id = {0}", Iddk, EndTime, confirm, color, Note, Employess);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateColorTableDK(long Id, int color, int confirm)
        {
            string query = string.Format(" UPDATE dbo.TableDK SET ColorDK = {1} , ConfirmDK = {2} WHERE Id = {0}", Id, color, confirm);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public object GetTableDKByCode(long idsx)
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT TableDK.Id,MachineCode,MoldNumber,PartCode,TableDK.StartTime,TableDK.EndTime FROM dbo.TableDK,dbo.TableSX WHERE IdSX = TableSX.Id AND IdSX = " + idsx + " AND TableDK.Id = (SELECT MIN(Id) FROM dbo.TableDK WHERE  IdSX = " + idsx + ")");
        }
        public object GetTableDKByDate(DateTime date)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            return (object)DataProvider.Instance.ExecuteQuery("SELECT MachineCode,MoldNumber,PartCode,dbo.TableDK.StartTime FROM dbo.TableDK,dbo.TableSX WHERE IdSX = TableSX.Id AND ConfirmDK = 1 AND TableDK.StartTime <='" + date + "'");
        }
        public DateTime EndTime(long id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableDK WHERE Id = " + id);
            TableDK t = new TableDK(data.Rows[0]);
            return t.EndTime;
        }
        public DateTime StartTime(long id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableDK WHERE Id = " + id);
            TableDK t = new TableDK(data.Rows[0]);
            return t.StartTime;
        }
        public DateTime WarnTime(long id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableDK WHERE Id = " + id);
            TableDK t = new TableDK(data.Rows[0]);
            return t.WarnTime;
        }
        public DateTime MaxEndTimeDK(long idSx)
        {
            return (DateTime)DataProvider.Instance.ExecuteScalar("SELECT MAX(EndTime) FROM dbo.TableDK WHERE IdSX  = " + idSx);
        }
        public int IdResourceDK(long idSx)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableDK WHERE IdSX = " + idSx);
            if (data.Rows.Count > 0)
            {
                TableDK t = new TableDK(data.Rows[0]);
                return t.IdResource;
            }
            return -1;
        }
        public int ConfirmDK(long id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableDK WHERE Id = " + id);
            TableDK t = new TableDK(data.Rows[0]);
            return t.ConfirmDK;
        }
        public int ColorDK(long id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableDK WHERE Id = " + id);
            TableDK t = new TableDK(data.Rows[0]);
            return t.ColorDK;
        }
        public long MinIdByConfirm(int confirm, int idRe)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableDK WHERE ConfirmDK = " + confirm + " AND IdResource = " + idRe + " ORDER BY StartTime");
            if (data.Rows.Count > 0)
            {
                TableDK t = new TableDK(data.Rows[0]);
                return t.Id;
            }
            return -1;
        }
        public long IdDKById(long id, int IdRe)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableDK WHERE Id < " + id + " AND IdResource = " + IdRe + " ORDER BY Id DESC");
            if (data.Rows.Count > 0)
            {
                TableDK t = new TableDK(data.Rows[0]);
                return t.Id;
            }
            return -1;
        }
        public bool DeleteTableXHByIDSX(long idsx)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("DELETE dbo.TableXH WHERE IdSX = " + idsx);
            return result > 0;
        }
        #endregion
        #region TableXH
        public List<TableXH> GetListTableXH()
        {
            List<TableXH> listT = new List<TableXH>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableXH");
            foreach (DataRow item in data.Rows)
            {
                TableXH t = new TableXH(item);
                listT.Add(t);
            }
            return listT;
        }
        public List<TableXH> GetListTableXH(long idSx)
        {
            List<TableXH> listT = new List<TableXH>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableXH WHERE IdSX = "+idSx);
            foreach (DataRow item in data.Rows)
            {
                TableXH t = new TableXH(item);
                listT.Add(t);
            }
            return listT;
        }
        public object GetTableXHByCode(long idsx)
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT TableXH.Id,MachineCode,MoldNumber,PartCode,TableXH.StartTime,TableXH.EndTime FROM dbo.TableXH,dbo.TableSX WHERE IdSX = TableSX.Id AND IdSX = " + idsx + " AND TableXH.Id = (SELECT MAX(Id) FROM dbo.TableXH WHERE  IdSX = " + idsx + " AND ColorXH = 7)");
        }
        public object GetListWarnTimeTableXH(DateTime today)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            return (object)DataProvider.Instance.ExecuteQuery("SELECT TableXH.Id,PartCode,MoldNumber,MachineCode,WarnTime,dbo.TableXH.StartTime FROM dbo.TableXH,dbo.TableSX WHERE ConfirmXH = 1 AND IdSX = TableSX.Id AND WarnTime <='" + today + "'");
        }
        public int IdResourceXH(long idSx)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableXH WHERE IdSX = " + idSx);
            if (data.Rows.Count > 0)
            {
                TableXH t = new TableXH(data.Rows[0]);
                return t.IdResource;
            }
            return -1;
        }
        public int ConfirmXH(long id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableXH WHERE Id = " + id);
            TableXH t = new TableXH(data.Rows[0]);
            return t.ConfirmXH;
        }
        public int ColorXH(long id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableXH WHERE Id = " + id);
            TableXH t = new TableXH(data.Rows[0]);
            return t.ColorXH;
        }
        public long MinIdXHByConfirm(int confirm, int idRe)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableXH WHERE ConfirmXH = " + confirm + " AND IdResource = " + idRe+" ORDER BY StartTime");
            if (data.Rows.Count > 0)
            {
                TableXH t = new TableXH(data.Rows[0]);
                return t.Id;
            }
            return -1;
        }
        public DateTime DateStartTimeXH(long id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableXH WHERE Id = " + id);
            TableXH t = new TableXH(data.Rows[0]);
            return t.StartTime;
        }
        public bool InsertTableXH(int IdResource, long IdSX, DateTime StartTime, DateTime EndTime, int ColorXH, int ConfirmXH, DateTime WarnTime, string Employess)
        {
            string query = string.Format("INSERT dbo.TableXH ( IdResource ,IdSX , StartTime , EndTime , ColorXH , ConfirmXH , WarnTime ,Employess) VALUES  ( {0} , {1} , '{2}' , '{3}' , {4} , {5} ,'{6}',N'{7}')", IdResource, IdSX, StartTime, EndTime, ColorXH, ConfirmXH, WarnTime, Employess);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteTableXH(long id)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("DELETE dbo.TableXH WHERE Id = " + id);
            return result > 0;
        }
        public bool DeleteTableXHByDate(DateTime date , long idsx)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("DELETE dbo.TableXH WHERE StartTime >= ' " + date + "' AND IdSX = " + idsx);
            return result > 0;
        }
        public bool UpdateConfirmTableXH(long id, int confirm)
        {
            string query = string.Format("UPDATE dbo.TableXH SET ConfirmXH = {1} WHERE Id = {0}", id, confirm);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateEndTimeTableXH(long id, DateTime EndTime)
        {
            string query = string.Format("UPDATE dbo.TableXH SET EndTime = '{1}' WHERE Id = {0}", id, EndTime);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateColorTableXH(long id, int color, int ConfirmXH)
        {
            string query = string.Format("UPDATE dbo.TableXH SET ColorXH = {1},ConfirmXH = {2} WHERE Id = {0}", id, color, ConfirmXH);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public long IdXHById(long id, int IdRe)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableXH WHERE Id < " + id + " AND IdResource = " + IdRe + " ORDER BY Id DESC");
            if (data.Rows.Count > 0)
            {
                TableXH t = new TableXH(data.Rows[0]);
                return t.Id;
            }
            return -1;
        }
        public bool UpdateConfirmTableXH(long Iddk, DateTime EndTime, int confirm, int color, string Note, string Employess)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format(" UPDATE dbo.TableXH SET EndTime = '{1}', ConfirmXH = {2} , ColorXH = {3} , Note = N'{4}', Employess = N'{5}' WHERE Id = {0}", Iddk, EndTime, confirm, color, Note, Employess);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public DateTime MaxEndTimeXH(long idSx)
        {
            return (DateTime)DataProvider.Instance.ExecuteScalar("SELECT MAX(EndTime) FROM dbo.TableXH WHERE IdSX  = " + idSx + " AND (ConfirmXH = 2 OR ColorXH = 10)");
        }
        public bool DeleteTableDKByIDSX(long idSX)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("DELETE dbo.TableDK WHERE IdSX = " + idSX);
            return result > 0;
        }
        #endregion
    }
}
