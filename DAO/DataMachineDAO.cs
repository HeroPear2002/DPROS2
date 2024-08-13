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
    public class DataMachineDAO
    {
        private static DataMachineDAO instance;

        public static DataMachineDAO Instance
        {
            get
            {
                if (instance == null) instance = new DataMachineDAO();
                return instance;
            }

            set
            {
                instance = value;
            }
        }
        public object GetALl()
        {

            return DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.DataMachine");

        }
        public List<DataMachineDTO> GetlistDataMachine()
        {
            List<DataMachineDTO> listD = new List<DataMachineDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT Id,MoldCode,MachineCode,DateInput,(CycleTime - CycleTimeStan) AS DifCycleTime,(TimeLM-TimeLMStan) AS DifTimeLM,(TimeGA-TimeGAStan) AS DifTimeGA,(TimeIJ - TimeIJStan) AS DifTimeIJ,(Cushpos-CushposStan) AS DifCushpos,(H4-H4Stan) AS DifH4,(Core-CoreStan) AS DifCore,(Cavity - CavityStan) AS DifCavity FROM dbo.DataMachine ");
            foreach (DataRow item in data.Rows)
            {
                DataMachineDTO d = new DataMachineDTO(item);
                listD.Add(d);
            }
            return listD;
        }
        public List<DataMachineDTO> GetlistDataMachineChart(string MoldCode, string MachineCode, DateTime Date1, DateTime Date2)
        {
            List<DataMachineDTO> listD = new List<DataMachineDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT Id,MoldCode,MachineCode,DateInput,(CycleTime ) AS DifCycleTime,(TimeLM) AS DifTimeLM,(TimeGA) AS DifTimeGA,(TimeIJ ) AS DifTimeIJ,(Cushpos) AS DifCushpos,(H4) AS DifH4,(Core) AS DifCore,(Cavity ) AS DifCavity FROM dbo.DataMachine WHERE MoldCode = N'" + MoldCode + "' AND MachineCode = N'" + MachineCode + "' AND DateInput >= '" + Date1 + "' AND DateInput <= '" + Date2 + "'");
            foreach (DataRow item in data.Rows)
            {
                DataMachineDTO d = new DataMachineDTO(item);
                listD.Add(d);
            }
            return listD;
        }
        public object MoldCode()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT DISTINCT(MoldCode) FROM dbo.DataMachine");
        }
        public object MachineCode(string MoldCode)
        {
            return DataProvider.Instance.ExecuteQuery("SELECT DISTINCT(MachineCode) FROM dbo.DataMachine WHERE MoldCode = N'" + MoldCode + "'");
        }
        public bool DeleteDataMachine(long Id)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("DELETE dbo.DataMachine WHERE Id = " + Id);
            return result > 0;
        }
        public bool InsertDataMachine(string MoldCode, string MachineCode, DateTime DateInput, float CycleTime, float CycleTimeStan, float TimeLM, float TimeLMStan, float TimeGA, float TimeGAStan, float TimeIJ, float TimeIJStan, float Cushpos, float CushposStan, float H4, float H4Stan, float Core, float CoreStan, float Cavity, float CavityStan, string Note)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("EXEC dbo.USP_InsertDataMachine @MoldCode , @MachineCode , @DateInput , @CycleTime , @CycleTimeStan , @TimeLM , @TimeLMStan , @TimeGA , @TimeGAStan , @TimeIJ , @TimeIJStan , @Cushpos , @CushposStan , @H4 , @H4Stan , @Core , @CoreStan , @Cavity , @CavityStan , @Note ", new object[] {
                MoldCode, MachineCode, DateInput, CycleTime, CycleTimeStan, TimeLM, TimeLMStan, TimeGA, TimeGAStan, TimeIJ, TimeIJStan, Cushpos, CushposStan, H4, H4Stan, Core, CoreStan, Cavity, CavityStan,Note });
            return result > 0;
        }
        public bool UpdateDataMachine(long Id, string MoldCode, string MachineCode, DateTime DateInput, float CycleTime, float TimeLM, float TimeGA, float TimeIJ, float Cushpos, float H4, float Core, float Cavity, string Note)
        {
            string query = string.Format("UPDATE [dbo].[DataMachine] SET [MoldCode] = N'{1}',[MachineCode] = N'{2}',[DateInput] = '{3}',[CycleTime] = {4},[TimeLM] = {5} ,[TimeGA] = {6},[TimeIJ] = {7},[Cushpos] = {8} ,[H4] = {9} ,[Core] = {10},[Cavity] = {11},[Note] = N'{12}' WHERE Id = {0}", Id, MoldCode, MachineCode, DateInput, CycleTime, TimeLM, TimeGA, TimeIJ, Cushpos, H4, Core, Cavity, Note);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public int TestDataMachine(string mold, string machine, DateTime date)
        {

            string query = string.Format("SELECT Id FROM dbo.DataMachine WHERE MoldCode = N'{0}' AND MachineCode = N'{1}' AND DateInput = '{2}'", mold, machine, date);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            if (data.Rows.Count > 0)
            {
                return 1;
            }
            return -1;
        }
        #region Lấy Giá trị tiêu chuẩn 
        public float CycleTimeStandard(string mold, string machine)
        {
            try
            {
                return (float)Convert.ToDouble(DataProvider.Instance.ExecuteScalar("SELECT DISTINCT(CycleTimeStan) FROM dbo.DataMachine WHERE MoldCode = N'" + mold + "' AND MachineCode = N'" + machine + "'").ToString());
            }
            catch
            {
                return 0;
            }
        }
        public float TimeLMStandard(string mold, string machine)
        {
            try
            {
                return (float)Convert.ToDouble(DataProvider.Instance.ExecuteScalar("SELECT DISTINCT(TimeLMStan) FROM dbo.DataMachine WHERE MoldCode = N'" + mold + "' AND MachineCode = N'" + machine + "'").ToString());
            }
            catch
            {
                return 0;
            }
        }
        public float TimeGAStandard(string mold, string machine)
        {
            try
            {
                return (float)Convert.ToDouble(DataProvider.Instance.ExecuteScalar("SELECT DISTINCT(TimeGAStan) FROM dbo.DataMachine WHERE MoldCode = N'" + mold + "' AND MachineCode = N'" + machine + "'").ToString());
            }
            catch
            {
                return 0;
            }
        }
        public float TimeIJStandard(string mold, string machine)
        {
            try
            {
                return (float)Convert.ToDouble(DataProvider.Instance.ExecuteScalar("SELECT DISTINCT(TimeIJStan) FROM dbo.DataMachine WHERE MoldCode = N'" + mold + "' AND MachineCode = N'" + machine + "'").ToString());
            }
            catch
            {
                return 0;
            }
        }
        public float CushposStandard(string mold, string machine)
        {
            try
            {
                return (float)Convert.ToDouble(DataProvider.Instance.ExecuteScalar("SELECT DISTINCT(CushposStan) FROM dbo.DataMachine WHERE MoldCode = N'" + mold + "' AND MachineCode = N'" + machine + "'").ToString());
            }
            catch
            {
                return 0;
            }
        }
        public float H4Standard(string mold, string machine)
        {
            try
            {
                return (float)Convert.ToDouble(DataProvider.Instance.ExecuteScalar("SELECT DISTINCT(H4Stan) FROM dbo.DataMachine WHERE MoldCode = N'" + mold + "' AND MachineCode = N'" + machine + "'").ToString());
            }
            catch
            {
                return 0;
            }
        }
        public float CoreStandard(string mold, string machine)
        {
            try
            {
                return (float)Convert.ToDouble(DataProvider.Instance.ExecuteScalar("SELECT DISTINCT(CoreStan) FROM dbo.DataMachine WHERE MoldCode = N'" + mold + "' AND MachineCode = N'" + machine + "'").ToString());
            }
            catch
            {
                return 0;
            }
        }
        public float CavityStandard(string mold, string machine)
        {
            try
            {
                return (float)Convert.ToDouble(DataProvider.Instance.ExecuteScalar("SELECT DISTINCT(CavityStan) FROM dbo.DataMachine WHERE MoldCode = N'" + mold + "' AND MachineCode = N'" + machine + "'").ToString());
            }
            catch
            {
                return 0;
            }
        }
        #endregion
        #region DataMachine Infor
        public List<DataMachineInforDTO> GetListDataMachineInfor()
        {
            List<DataMachineInforDTO> listD = new List<DataMachineInforDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.DataMachineInfor");
            foreach (DataRow item in data.Rows)
            {
                DataMachineInforDTO d = new DataMachineInforDTO(item);
                listD.Add(d);
            }
            return listD;
        }
        public float UpData(string name, string mold, string machine)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.DataMachineInfor WHERE NameCate = N'" + name + "' AND MoldCode = N'" + mold + "' AND MachineCode = N'" + machine + "'");
            if (data.Rows.Count > 0)
            {

                DataMachineInforDTO d = new DataMachineInforDTO(data.Rows[0]);
                return d.UpData;
            }
            return 0;
        }
        public float DownData(string name, string mold, string machine)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.DataMachineInfor WHERE NameCate = N'" + name + "' AND MoldCode = N'" + mold + "' AND MachineCode = N'" + machine + "'");
            if (data.Rows.Count > 0)
            {

                DataMachineInforDTO d = new DataMachineInforDTO(data.Rows[0]);
                return d.DownData;
            }
            return 0;
        }
        public bool InsertDataMachineInfor(DataMachineInforDTO di)
        {
            string query = string.Format("INSERT dbo.DataMachineInfor ( NameCate , MoldCode , MachineCode , UpData , DownData ) VALUES  ( N'{0}' ,  N'{1}' ,  N'{2}' ,  {3} ,  {4} )", di.NameCate, di.MoldCode, di.MachineCode, di.UpData, di.DownData);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateDataMachineInfor(DataMachineInforDTO di)
        {
            string query = string.Format("UPDATE dbo.DataMachineInfor SET NameCate = N'{1}',MoldCode = N'{2}' ,MachineCode = N'{3}' , UpData = {4} , DownData = {5} WHERE Id = {0}", di.Id, di.NameCate, di.MoldCode, di.MachineCode, di.UpData, di.DownData);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteDataMachineInfor(int id)
        {
            string query = string.Format("DELETE dbo.DataMachineInfor WHERE Id = {0}", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }


        #endregion
        #region Category Default
        public object GetListCategoryDefault()
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.CategoryDefault");
        }
        public bool InsertCategory(string Name, float UpperLimit, float LowerLimit)
        {
            string query = string.Format("INSERT dbo.CategoryDefault ( Name, UpperLimit, LowerLimit ) VALUES  ( N'{0}', {1}, {2} )", Name, UpperLimit, LowerLimit);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateCategory(int Id, string Name, float UpperLimit, float LowerLimit)
        {
            string query = string.Format("UPDATE dbo.CategoryDefault SET Name = N'{1}', UpperLimit = {2} ,LowerLimit = {3} WHERE Id = {0}", Id, Name, UpperLimit, LowerLimit);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteCategory(int Id)
        {
            string query = string.Format("DELETE dbo.CategoryDefault WHERE Id = {0}", Id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        #endregion
        #region Setup Default
        public object GetListSetupDefault()
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT SetupDefault.Id,MoldCode,MachineCode,ValueDefault,Name FROM dbo.SetupDefault,dbo.CategoryDefault WHERE IdCategory = CategoryDefault.Id");
        }
        public List<CategoryDataMachineDTO> GetListCategoryBySetup(string moldCode, string machineCode)
        {
            List<CategoryDataMachineDTO> listD = new List<CategoryDataMachineDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT Id,Name,UpperLimit,LowerLimit,N'DD' AS Value FROM dbo.CategoryDefault WHERE Id IN (SELECT IdCategory FROM dbo.SetupDefault WHERE MoldCode = N'" + moldCode + "' AND MachineCode = N'" + machineCode + "')");
            foreach (DataRow item in data.Rows)
            {
                CategoryDataMachineDTO c = new CategoryDataMachineDTO(item);
                listD.Add(c);
            }
            return listD;
        }
        public object GetListValueSetupDefault(string moldCode, string machineCode)
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT SetupDefault.Id,MoldCode,MachineCode,ValueDefault,Name FROM dbo.SetupDefault,dbo.CategoryDefault WHERE IdCategory = CategoryDefault.Id AND MoldCode = N'" + moldCode + "' AND MachineCode = N'" + machineCode + "'");
        }
        public object GetListMoldBySetup()
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT DISTINCT(MoldCode) FROM dbo.SetupDefault");
        }
        public object GetListMachineBySetup(string moldCode)
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT DISTINCT(MachineCode) FROM dbo.SetupDefault WHERE MoldCode = N'" + moldCode + "'");
        }
        public long IdSetupdefault(int idCategory, string moldCode, string machineCode)
        {
            try
            {
                return (long)DataProvider.Instance.ExecuteScalar("SELECT Id FROM dbo.SetupDefault WHERE IdCategory = " + idCategory + " AND MoldCode = N'" + moldCode + "' AND MachineCode = N'" + machineCode + "'");
            }
            catch
            {
                return -1;
            }
        }
        public bool InsertSetupDefault(int IdCategory, string MoldCode, string MachineCode, float ValueDefault)
        {
            string query = string.Format("INSERT dbo.SetupDefault ( IdCategory ,MoldCode , MachineCode ,ValueDefault) VALUES  ( {0} ,  N'{1}' ,  N'{2}' ,  {3} )", IdCategory, MoldCode, MachineCode, ValueDefault);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateSetupdefault(long id, float value)
        {
            string query = string.Format("UPDATE dbo.SetupDefault SET ValueDefault = {1} WHERE Id = {0}", id, value);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteSetupdefault(long id)
        {
            string query = string.Format("DELETE dbo.SetupDefault WHERE Id = {0}", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public float ValueUpperLimitCate(int id)
        {
            return (float)Convert.ToDouble(DataProvider.Instance.ExecuteScalar("select UpperLimit from CategoryDefault Where Id = " + id).ToString());

        }
        public float ValueLowerLimitCate(int id)
        {
            return (float)Convert.ToDouble(DataProvider.Instance.ExecuteScalar("select LowerLimit from CategoryDefault Where Id = " + id).ToString());
        }
        public float ValuSetupDefault(long id)
        {
            return (float)Convert.ToDouble(DataProvider.Instance.ExecuteScalar("Select ValueDefault from SetupDefault Where Id = " + id).ToString());
        }
        #endregion
        #region Data Check
        public List<DataCheckDTO> GetListALLDataCheck()
        {
            List<DataCheckDTO> listD = new List<DataCheckDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT DataCheck.Id ,MoldCode,MachineCode,ValueDefault,ValueReal,DateCheck,Name,Note,EmployessCode FROM dbo.DataCheck,dbo.SetupDefault,dbo.CategoryDefault WHERE CategoryDefault.Id = IdCategory AND IdSetup = SetupDefault.Id");
            foreach (DataRow item in data.Rows)
            {
                DataCheckDTO d = new DataCheckDTO(item);
                listD.Add(d);
            }
            return listD;
        }
        public bool InsertDataCheck(long IdSetup, DateTime DateCheck, float ValueReal, string Note, string EmployessCode)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format("INSERT dbo.DataCheck ( IdSetup, DateCheck, ValueReal, Note, EmployessCode ) VALUES  ( {0}, '{1}', {2}, N'{3}',N'{4}' )", IdSetup, DateCheck, ValueReal, Note, EmployessCode);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateDataCheck(long Id, DateTime DateCheck, float ValueReal, string Note, string EmployessCode)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format("UPDATE dbo.DataCheck SET DateCheck = '{1}' , ValueReal = {2} , Note = N'{3}' , N'{4}' WHERE Id = {0}", Id, DateCheck, ValueReal, Note, EmployessCode);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateHisDataCheck(long Id, float ValueReal, string Note)
        {

            string query = string.Format("UPDATE dbo.DataCheck SET ValueReal = {1} , Note = N'{2}' WHERE Id = {0}", Id, ValueReal, Note);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteDataCheck(long Id)
        {
            string query = string.Format("DELETE dbo.DataCheck WHERE Id = {0}", Id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
      
        #endregion
    }
}
