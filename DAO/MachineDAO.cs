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
    public class MachineDAO
    {
        private static MachineDAO instance;

        public static MachineDAO Instance
        {
            get
            {
                if (instance == null) instance = new MachineDAO();
                return instance;
            }

            set
            {
                instance = value;
            }
        }
        #region MachineDry
        public object GetMachineDry()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM MachineDry");
        }
        public float WeightTray(string code)
        {
            return (float)Convert.ToDouble(DataProvider.Instance.ExecuteScalar("SELECT WeightTray FROM MachineDry WHERE DryCode = N'"+code+"'").ToString());
        }
        public bool InsertDry(string DryCode,string DryName,float WeightTray,string Note)
        {
            string query = string.Format("INSERT INTO [dbo].[MachineDry] ([DryCode],[DryName],[WeightTray],[Note]) VALUES (N'{0}',N'{1}',{2},N'{3}')",DryCode,DryName,WeightTray,Note);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateDry(string DryCode, string DryName, float WeightTray, string Note)
        {
            string query = string.Format("UPDATE [dbo].[MachineDry] SET [DryName] = N'{1}',[WeightTray] = {2},[Note] = {3} WHERE DryCode = N'{0}'", DryCode, DryName, WeightTray, Note);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteDry(string DryCode)
        {
            string query = string.Format("DELETE [dbo].[MachineDry] WHERE DryCode = N'{0}'", DryCode );
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        #endregion
        #region Machine 
        public List<MachineDTO> GetListMachine()
        {
            List<MachineDTO> listM = new List<MachineDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Machine Where Device = 1");
            foreach (DataRow item in data.Rows)
            {
                MachineDTO m = new MachineDTO(item);
                listM.Add(m);
            }
            return listM;
        } 
        public MachineDTO GetItemMachine(string machineCode)
        {
            List<MachineDTO> listM = new List<MachineDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Machine WHERE MachineCode = N'" + machineCode + "'");
            if (data.Rows.Count > 0)
            {
                MachineDTO m = new MachineDTO(data.Rows[0]);
                return m;
            }
            return null;
        }
        public MachineDTO GetMachine(string machineCode)
        {
            List<MachineDTO> listM = new List<MachineDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Machine WHERE MachineCode = N'" + machineCode + "'");
            if (data.Rows.Count > 0)
            {
                MachineDTO m = new MachineDTO(data.Rows[0]);
                return m;
            }
            return null;
        }
        public List<MachineDTO> GetListMachineByDevice(int Device)
        {
            List<MachineDTO> listM = new List<MachineDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Machine Where Device = " + Device);
            foreach (DataRow item in data.Rows)
            {
                MachineDTO m = new MachineDTO(item);
                listM.Add(m);
            }
            return listM;
        }
        public Object GetListDataMachineByDevice(int Device)
        {
            return (Object)DataProvider.Instance.ExecuteQuery("SELECT MachineCode,MachineName,MachineInfor,MachineMake,DateInput,CodeTSCD,Vendor,DateSX,Device,StatusMachine,NoteMachine,DATEDIFF(MONTH,DateSX,GETDATE()) as MonthUse,DateMaker FROM Machine Where Device = " + Device);
        }
        public List<MachineDTO> GetListAllMachine()
        {
            List<MachineDTO> listM = new List<MachineDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Machine");
            foreach (DataRow item in data.Rows)
            {
                MachineDTO m = new MachineDTO(item);
                listM.Add(m);
            }
            return listM;
        }
        public List<MachineDTO> GetListAllMachine0()
        {
            List<MachineDTO> listM = new List<MachineDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Machine WHERE Device = 0");
            foreach (DataRow item in data.Rows)
            {
                MachineDTO m = new MachineDTO(item);
                listM.Add(m);
            }
            return listM;
        }
        public bool InsertMachine(string MachineCode, string MachineName, string MachineInfor, string MachineMake, DateTime DateInput, string CodeTSCD, string Vendor, DateTime DateSX, int Device, int StatusMachine, string DateMaker)
        {
            string query = string.Format("INSERT dbo.Machine ( MachineCode , MachineName , MachineInfor , MachineMake, DateInput ,CodeTSCD , Vendor ,DateSX , Device ,StatusMachine,DateMaker )VALUES  ( N'{0}' , N'{1}' , N'{2}' , N'{3}','{4}',N'{5}',N'{6}','{7}',{8},{9},N'{10}')", MachineCode, MachineName, MachineInfor, MachineMake, DateInput, CodeTSCD, Vendor, DateSX, Device, StatusMachine, DateMaker);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateMachine(string MachineCode, string MachineName, string MachineInfor, string MachineMake, DateTime DateInput, string CodeTSCD, string Vendor, DateTime DateSX, int Device, int StatusMachine, string DateMaker)
        {
            string query = string.Format("UPDATE [dbo].[Machine] SET [MachineName] = N'{1}',[MachineInfor] = N'{2}',[MachineMake] = N'{3}' , DateInput = '{4}',CodeTSCD = N'{5}', Vendor = N'{6}', DateSX = '{7}', Device = {8},StatusMachine = {9}, DateMaker = N'{10}' WHERE [MachineCode] = N'{0}'", MachineCode, MachineName, MachineInfor, MachineMake, DateInput, CodeTSCD, Vendor, DateSX, Device, StatusMachine, DateMaker);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteMachine(string MachineCode)
        {
            string query = string.Format("DELETE dbo.Machine WHERE MachineCode = N'{0}'", MachineCode);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteMachine(int Device)
        {
            string query = string.Format("DELETE dbo.Machine WHERE Device = {0}", Device);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public int TestMachineByCode(string MachineCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Machine WHERE MachineCode = N'" + MachineCode + "'");
            if (data.Rows.Count > 0)
            {
                return 1;
            }
            return -1;
        }
        public int DeviceMachine(string MachineCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Machine WHERE MachineCode = N'" + MachineCode + "'");
            if (data.Rows.Count > 0)
            {
                MachineDTO m = new MachineDTO(data.Rows[0]);
                return m.Device;
            }
            return -1;
        }
        public bool UpdateStatusMay(string MachineCode, int statusMachine, string note)
        {
            string query = string.Format("UPDATE dbo.Machine SET StatusMachine = {1}, NoteMachine = N'{2}' WHERE MachineCode = N'{0}'", MachineCode, statusMachine, note);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public int StatusMachineByCode(string MachineCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Machine WHERE MachineCode = N'" + MachineCode + "'");
            if (data.Rows.Count > 0)
            {
                MachineDTO m = new MachineDTO(data.Rows[0]);
                return m.StatusMachine;
            }
            return 0;
        }
        public bool UpdateStatusMay1(string MaMay, int StatusMachine)
        {
            string query = string.Format("UPDATE dbo.Machine SET StatusMachine = {1} WHERE MachineCode = N'{0}'", MaMay, StatusMachine);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateMachine(string machineOld, string MachineNew)
        {
            string query = string.Format("UPDATE dbo.Machine SET MachineCode = N'{1}' WHERE MachineCode = N'{0}'", machineOld, MachineNew);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateMachinInfor(string machineOld, string MachineNew)
        {
            string query = string.Format("UPDATE dbo.MachineInfor SET MachineCode = N'{1}' WHERE MachineCode = N'{0}'", machineOld, MachineNew);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateRelationShip(string machineOld, string MachineNew)
        {
            string query = string.Format("UPDATE dbo.RelationShip SET MachineCode = N'{1}' WHERE MachineCode = N'{0}'", machineOld, MachineNew);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateHistoryEdit(string machineOld, string MachineNew)
        {
            string query = string.Format("UPDATE dbo.HistoryEdit SET MachineCode = N'{1}' WHERE MachineCode = N'{0}'", machineOld, MachineNew);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateMachineDetail(string machineOld, string MachineNew)
        {
            string query = string.Format("UPDATE dbo.MachineDetail SET MachineCode = N'{1}' WHERE MachineCode = N'{0}'", machineOld, MachineNew);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        #endregion
        #region Machine Infor
        public Object GetListMachineInfor()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM MachineInfor Order by Id DESC");
        }
        public int TestMachineInfor(string MachineCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM MachineInfor WHERE MachineCode = N'" + MachineCode + "'");
            if (data.Rows.Count > 0)
            {
                return 1;
            }
            return -1;
        }
        public string NameFile(string MachineCode)
        {
            return DataProvider.Instance.ExecuteScalar("SELECT Link FROM MachineInfor WHERE MachineCode = N'" + MachineCode + "'").ToString();
        }
        public bool InsertMachineInfor(string code, string link)
        {
            int reslt = DataProvider.Instance.ExecuteNonQuery("INSERT INTO [dbo].[MachineInfor] ([MachineCode] ,[Link]) VALUES (N'" + code + "',N'" + link + "')");
            return reslt > 0;
        }
        public bool UpdateMachineInfor(string code, string link)
        {
            int reslt = DataProvider.Instance.ExecuteNonQuery("UPDATE [dbo].[MachineInfor] SET [Link] = N'" + link + "'  WHERE MachineCode = N'" + code + "'");
            return reslt > 0;
        }
        public bool DeleteMachineInfor(long Id)
        {
            int reslt = DataProvider.Instance.ExecuteNonQuery("DELETE MachineInfor WHERE Id = " + Id);
            return reslt > 0;
        }
        #endregion
        #region List Device
        public List<ListDeviceDTO> GetListDevice()
        {
            List<ListDeviceDTO> listL = new List<ListDeviceDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.ListDevice");
            foreach (DataRow item in data.Rows)
            {
                ListDeviceDTO l = new ListDeviceDTO(item);
                listL.Add(l);
            }
            return listL;
        }
        public ListDeviceDTO GetItemDevice(int Id)
        {
            return GetListDevice().SingleOrDefault(x => x.Id == Id);
        }
        public int GetIdDeviceByName(string name)
        {
            try
            {
                return GetListDevice().Where(x => x.Name == name).SingleOrDefault().Id;
            }
            catch
            {

                return -1;
            }

        }
        public string UrlImageDevice(int Id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.ListDevice WHERE Id = " + Id);
            if (data.Rows.Count > 0)
            {
                ListDeviceDTO l = new ListDeviceDTO(data.Rows[0]);
                return l.UrlImage;
            }
            return null;
        }
        public byte[] GetAvataById(int Id)
        {
            //DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.ListDevice WHERE Id = " + Id);
            //if (data.Rows.Count > 0)
            //{
            //    ListDeviceDTO l = new ListDeviceDTO(data.Rows[0]);
            //    return l.Avata;
            //}
            return null;
        }
        public int StatusDevice(int Id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.ListDevice WHERE Id = " + Id);
            if (data.Rows.Count > 0)
            {
                ListDeviceDTO l = new ListDeviceDTO(data.Rows[0]);
                return l.StatusDevice;
            }
            return -1;
        }
        public bool InsertDevice(string Name, int status, string urlImage, string FormCode, string UrlEveryDay, string UrlEveryMainten)
        {
            string query = string.Format("INSERT INTO [dbo].[ListDevice] ([Name],[StatusDevice],[UrlImage],[FormCode],[UrlEveryDay],[UrlEveryMainten]) VALUES( N'{0}',{1} ,N'{2}',N'{3}',N'{4}',N'{5}')", Name, status, urlImage, FormCode, UrlEveryDay, UrlEveryMainten);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateDevice(int Id, string Name, int status, string urlImage, string FormCode, string UrlEveryDay, string UrlEveryMainten)
        {
            string query = string.Format("UPDATE [dbo].[ListDevice] SET [Name] = N'{1}',[StatusDevice] = {2},[UrlImage] = N'{3}' , [FormCode] = N'{4}',[UrlEveryDay] = N'{5}',[UrlEveryMainten] = N'{6}' WHERE Id = {0}", Id, Name, status, urlImage, FormCode, UrlEveryDay, UrlEveryMainten);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateStatusDevice(int Id, int status)
        {
            string query = string.Format("UPDATE dbo.ListDevice SET StatusDevice = {1} WHERE Id = {0}", Id, status);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteDevice(int Id)
        {
            string query = string.Format("DELETE dbo.ListDevice WHERE Id = {0}", Id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public string NameListDevice(int Id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.ListDevice WHERE Id = " + Id);
            if (data.Rows.Count > 0)
            {
                ListDeviceDTO l = new ListDeviceDTO(data.Rows[0]);
                return l.Name;
            }
            return null;
        }
        #endregion
        #region Category
        public List<CategoryTestDTO> GetListCategoryAll()
        {
            List<CategoryTestDTO> listC = new List<CategoryTestDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.CategoryTest");
            foreach (DataRow item in data.Rows)
            {
                CategoryTestDTO c = new CategoryTestDTO(item);
                listC.Add(c);
            }
            return listC;
        }
        public CategoryTestDTO GetListCategory(long id)
        {
            List<CategoryTestDTO> listC = new List<CategoryTestDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.CategoryTest WHERE Id = " + id);
            foreach (DataRow item in data.Rows)
            {
                CategoryTestDTO c = new CategoryTestDTO(item);
                listC.Add(c);
            }
            return listC.SingleOrDefault();
        }
        public List<CategoryTestDTO> GetListCategory1()
        {
            List<CategoryTestDTO> listC = new List<CategoryTestDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.CategoryTest WHERE ConfirmCategory = 1");
            foreach (DataRow item in data.Rows)
            {
                CategoryTestDTO c = new CategoryTestDTO(item);
                listC.Add(c);
            }
            return listC;
        }
        public List<CategoryTestDTO> GetListCategoryShort()
        {
            List<CategoryTestDTO> listC = new List<CategoryTestDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.CategoryTest WHERE Timer = 24");
            foreach (DataRow item in data.Rows)
            {
                CategoryTestDTO c = new CategoryTestDTO(item);
                listC.Add(c);
            }
            return listC;
        }
        public List<CategoryTestDTO> GetListCategoryShortBydevice(string device)
        {
            List<CategoryTestDTO> listC = new List<CategoryTestDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.CategoryTest WHERE Timer = 24 AND Device = N'" + device + "'");
            foreach (DataRow item in data.Rows)
            {
                CategoryTestDTO c = new CategoryTestDTO(item);
                listC.Add(c);
            }
            return listC;
        }
        public List<CategoryTestDTO> GetListCategoryLong()
        {
            List<CategoryTestDTO> listC = new List<CategoryTestDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.CategoryTest WHERE Timer <> 24");
            foreach (DataRow item in data.Rows)
            {
                CategoryTestDTO c = new CategoryTestDTO(item);
                listC.Add(c);
            }
            return listC;
        }
        public List<CategoryTestDTO> GetListCategoryLongBydevice(string device)
        {
            List<CategoryTestDTO> listC = new List<CategoryTestDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.CategoryTest WHERE Timer <> 24 AND Device = N'" + device + "'");
            foreach (DataRow item in data.Rows)
            {
                CategoryTestDTO c = new CategoryTestDTO(item);
                listC.Add(c);
            }
            return listC;
        }
        public bool InsertCategoryTest(string NameCategory, string Detail, int Timer, string Method, int ConfirmCategory, string device, string Limit)
        {
            string query = string.Format("INSERT dbo.CategoryTest ( NameCategory , Detail ,Timer , Method , ConfirmCategory , Device ,Limit ) VALUES  ( N'{0}' ,  N'{1}' ,  {2} ,  N'{3}' , {4} , N'{5}' , N'{6}' )", NameCategory, Detail, Timer, Method, ConfirmCategory, device, Limit);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateCategoryTest(long Id, string NameCategory, string Detail, int Timer, string Method, int ConfirmCategory, string device, string Limit)
        {
            string query = string.Format("UPDATE dbo.CategoryTest SET NameCategory = N'{1}' , Detail = N'{2}',Timer = {3}, Method = N'{4}', ConfirmCategory = {5} , Device = N'{6}' , Limit = N'{7}' WHERE Id = {0}", Id, NameCategory, Detail, Timer, Method, ConfirmCategory, device, Limit);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteCategoryTest(long Id)
        {
            string query = string.Format("DELETE dbo.CategoryTest WHERE Id = {0}", Id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public int ConfirmCategory(long Id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.CategoryTest WHERE Id = " + Id);
            if (data.Rows.Count > 0)
            {
                CategoryTestDTO c = new CategoryTestDTO(data.Rows[0]);
                return c.ConfirmCategory;
            }
            return -1;
        }
        public long IdCategory(string name)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.CategoryTest WHERE NameCategory = N'" + name + "'");
            if (data.Rows.Count > 0)
            {
                CategoryTestDTO c = new CategoryTestDTO(data.Rows[0]);
                return c.Id;
            }
            return -1;
        }
        public int TimeKHCategory(long id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.CategoryTest WHERE Id = " + id);
            if (data.Rows.Count > 0)
            {
                CategoryTestDTO c = new CategoryTestDTO(data.Rows[0]);
                return c.Timer;
            }
            return -1;
        }
        public int TimeCategoryBuId(long IdCategory)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.CategoryTest WHERE Id = " + IdCategory);
            if (data.Rows.Count > 0)
            {
                CategoryTestDTO c = new CategoryTestDTO(data.Rows[0]);
                return c.Timer;
            }
            return 0;
        }
        #endregion
        #region Relation Ship
        public List<OnlyMachineDTO> GetListDisMachineCode()
        {
            List<OnlyMachineDTO> listO = new List<OnlyMachineDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT DISTINCT(MachineCode) FROM RelationShip Order by MachineCode");
            foreach (DataRow item in data.Rows)
            {
                OnlyMachineDTO o = new OnlyMachineDTO(item);
                listO.Add(o);
            }
            return listO;
        }
        public long IdRelationShipByMachine(string MachineCode, long IdCategory)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.RelationShip WHERE MachineCode = N'" + MachineCode + "' AND IdCategory =" + IdCategory);
            if (data.Rows.Count > 0)
            {
                RelationShipDTO r = new RelationShipDTO(data.Rows[0]);
                return r.Id;
            }
            return -1;
        }
        public bool InsertRelationShip(string MachineCode, long IdCategory, float TimeTT, int StatusRe, int TimerKH)
        {
            string query = string.Format("INSERT dbo.RelationShip ( MachineCode, IdCategory, TimeTT , StatusRe , TimerKH ) VALUES  ( N'{0}', {1} , {2} , {3} , {4})", MachineCode, IdCategory, TimeTT, StatusRe, TimerKH);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateTimeRelationShip(long Id, float TimeTT)
        {
            string query = string.Format("UPDATE dbo.RelationShip SET TimeTT = {1} WHERE Id = {0} ", Id, TimeTT);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateTimeRelationShipByMachine(string MachineCode, float TimeTT)
        {
            string query = string.Format("UPDATE dbo.RelationShip SET TimeTT = {1} WHERE MachineCode = N'{0}' ", MachineCode, TimeTT);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateTimeKHRelationShip(long Id, int TimeKH)
        {
            string query = string.Format("UPDATE dbo.RelationShip SET TimerKH = {1} WHERE Id = {0} ", Id, TimeKH);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateStatusRelationShip(long Id, int StatusRe)
        {
            string query = string.Format("UPDATE dbo.RelationShip SET StatusRe = {1} WHERE Id = {0} ", Id, StatusRe);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteRelationShip(long Id)
        {

            int result = DataProvider.Instance.ExecuteNonQuery("DELETE dbo.RelationShip WHERE Id = " + Id);
            return result > 0;
        }
        public bool DeleteRelationIdCategory(long IdCategory)
        {
            string query = string.Format("DELETE dbo.RelationShip WHERE IdCategory = {0}", IdCategory);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public object GetListRelationShort(int Device)
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT RelationShip.Id,RelationShip.MachineCode,NameCategory,Detail,Method,IdCategory FROM dbo.RelationShip,dbo.CategoryTest,dbo.Machine WHERE Timer = 24 AND CategoryTest.Id = IdCategory AND Machine.MachineCode = RelationShip.MachineCode AND Machine.Device  = " + Device);
        }
        public object GetListRelationLong(int Device)
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT RelationShip.Id,RelationShip.MachineCode,NameCategory,Detail,Method,IdCategory FROM dbo.RelationShip,dbo.CategoryTest,dbo.Machine WHERE Timer <> 24 AND CategoryTest.Id = IdCategory AND Machine.MachineCode = RelationShip.MachineCode AND Machine.Device  = " + Device);
        }
        public object GetListMachineByIdCategory(long idCategory)
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.RelationShip WHERE IdCategory = " + idCategory);
        }
        public List<RelationShipDTO> GetListRelationShipAll(string MachineCode)
        {
            List<RelationShipDTO> listC = new List<RelationShipDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT RelationShip.Id,IdCategory,MachineCode,TimeTT,StatusRe,TimerKH FROM dbo.RelationShip , dbo.CategoryTest WHERE CategoryTest.Id = IdCategory AND MachineCode = N'" + MachineCode + "'");
            foreach (DataRow item in data.Rows)
            {
                RelationShipDTO c = new RelationShipDTO(item);
                listC.Add(c);
            }
            return listC;
        }
        public List<RelationShipDTO> GetListRelationShipAllNot()
        {
            List<RelationShipDTO> listC = new List<RelationShipDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT RelationShip.Id,IdCategory,MachineCode,TimeTT,StatusRe,TimerKH FROM dbo.RelationShip , dbo.CategoryTest WHERE CategoryTest.Id = IdCategory");
            foreach (DataRow item in data.Rows)
            {
                RelationShipDTO c = new RelationShipDTO(item);
                listC.Add(c);
            }
            return listC;
        }
        public List<RelationShipDTO> GetListRelationShip()
        {
            List<RelationShipDTO> listC = new List<RelationShipDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.RelationShip ");
            foreach (DataRow item in data.Rows)
            {
                RelationShipDTO c = new RelationShipDTO(item);
                listC.Add(c);
            }
            return listC;
        }
        public int TimeTTByID(long Id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.RelationShip WHERE Id = " + Id);
            if (data.Rows.Count > 0)
            {
                RelationShipDTO r = new RelationShipDTO(data.Rows[0]);
                return r.TimeTT;
            }
            return 0;
        }
        public int StatusRelationShip(long Id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.RelationShip WHERE Id = " + Id);
            if (data.Rows.Count > 0)
            {
                RelationShipDTO r = new RelationShipDTO(data.Rows[0]);
                return r.StatusRe;
            }
            return 0;
        }
        public List<RelationShipDTO> GetListRelationShipLong(string MachineCode)
        {
            List<RelationShipDTO> listC = new List<RelationShipDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT RelationShip.Id,IdCategory,MachineCode,TimeTT,StatusRe,TimerKH FROM dbo.RelationShip , dbo.CategoryTest WHERE CategoryTest.Id = IdCategory AND Timer <> 24 AND MachineCode = N'" + MachineCode + "'");
            foreach (DataRow item in data.Rows)
            {
                RelationShipDTO c = new RelationShipDTO(item);
                listC.Add(c);
            }
            return listC;
        }
        #endregion
        #region History Machine
        public List<HistoryDeviceDTO> GetListHistoryDeviceALL()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            List<HistoryDeviceDTO> listH = new List<HistoryDeviceDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT HistoryDevice.Id,IdRelationShip,IdCategory,DateCheck,DataCount,StatusHD,Employess,MachineCode,HistoryDevice.Note,NameCategory,Detail,Method,Limit,Result,TimeTT,Timer FROM dbo.HistoryDevice,dbo.CategoryTest,dbo.RelationShip WHERE IdRelationShip = RelationShip.Id AND IdCategory = CategoryTest.Id");
            foreach (DataRow item in data.Rows)
            {
                HistoryDeviceDTO h = new HistoryDeviceDTO(item);
                listH.Add(h);
            }
            return listH;
        }
        public List<HistoryDeviceDTO> GetListHistoryDeviceALL(DateTime date1, DateTime date2)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            List<HistoryDeviceDTO> listH = new List<HistoryDeviceDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT HistoryDevice.Id,IdRelationShip,IdCategory,DateCheck,DataCount,StatusHD,Employess,MachineCode,HistoryDevice.Note,NameCategory,Detail,Method,Limit,Result,TimeTT,Timer FROM dbo.HistoryDevice,dbo.CategoryTest,dbo.RelationShip WHERE IdRelationShip = RelationShip.Id AND IdCategory = CategoryTest.Id AND DateCheck >= '" + date1 + "' AND DateCheck <='" + date2 + "'");
            foreach (DataRow item in data.Rows)
            {
                HistoryDeviceDTO h = new HistoryDeviceDTO(item);
                listH.Add(h);
            }
            return listH;
        }
        public List<HistoryDeviceDTO> GetListHistoryDeviceALL(long IdRelationShip)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            List<HistoryDeviceDTO> listH = new List<HistoryDeviceDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT HistoryDevice.Id,IdRelationShip,IdCategory,DateCheck,DataCount,StatusHD,Employess,MachineCode,HistoryDevice.Note,NameCategory,Detail,Method,Limit,Result,TimeTT,Timer FROM dbo.HistoryDevice,dbo.CategoryTest,dbo.RelationShip WHERE IdRelationShip = RelationShip.Id AND IdCategory = CategoryTest.Id AND IdRelationShip = " + IdRelationShip);
            foreach (DataRow item in data.Rows)
            {
                HistoryDeviceDTO h = new HistoryDeviceDTO(item);
                listH.Add(h);
            }
            return listH;
        }
        public List<HistoryDeviceDTO> GetListHistoryDeviceALL(DateTime date1, DateTime date2, string MachineCode)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            List<HistoryDeviceDTO> listH = new List<HistoryDeviceDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT HistoryDevice.Id,IdRelationShip,IdCategory,DateCheck,DataCount,StatusHD,Employess,MachineCode,HistoryDevice.Note,NameCategory,Detail,Method,Limit,Result,TimeTT,Timer FROM dbo.HistoryDevice,dbo.CategoryTest,dbo.RelationShip WHERE IdRelationShip = RelationShip.Id AND IdCategory = CategoryTest.Id AND MachineCode = N'" + MachineCode + "' AND DateCheck >= '" + date1 + "' AND DateCheck <='" + date2 + "'");
            foreach (DataRow item in data.Rows)
            {
                HistoryDeviceDTO h = new HistoryDeviceDTO(item);
                listH.Add(h);
            }
            return listH;
        }
        public List<HistoryDeviceDTO> GetListHistoryDeviceALL(DateTime date1, DateTime date2, string MachineCode, long idCategory)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            List<HistoryDeviceDTO> listH = new List<HistoryDeviceDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT HistoryDevice.Id,IdRelationShip,IdCategory,DateCheck,DataCount,StatusHD,Employess,MachineCode,HistoryDevice.Note,NameCategory,Detail,Method,Limit,Result,TimeTT,Timer FROM dbo.HistoryDevice,dbo.CategoryTest,dbo.RelationShip WHERE IdRelationShip = RelationShip.Id AND IdCategory = CategoryTest.Id AND IdCategory = " + idCategory + " AND MachineCode = N'" + MachineCode + "' AND DateCheck >= '" + date1 + "' AND DateCheck <='" + date2 + "'");
            foreach (DataRow item in data.Rows)
            {
                HistoryDeviceDTO h = new HistoryDeviceDTO(item);
                listH.Add(h);
            }
            return listH;
        }
        public List<HistoryDeviceDTO> GetListHistoryRelaytionShip(DateTime date1, DateTime date2, string MachineCode, long IdRelationShip)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            List<HistoryDeviceDTO> listH = new List<HistoryDeviceDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT HistoryDevice.Id,IdRelationShip,IdCategory,DateCheck,DataCount,StatusHD,Employess,MachineCode,HistoryDevice.Note,NameCategory,Detail,Method,Limit,Result,TimeTT,Timer FROM dbo.HistoryDevice,dbo.CategoryTest,dbo.RelationShip WHERE IdRelationShip = RelationShip.Id AND IdCategory = CategoryTest.Id AND IdRelationShip = " + IdRelationShip + " AND MachineCode = N'" + MachineCode + "' AND DateCheck >= '" + date1 + "' AND DateCheck <='" + date2 + "'");
            foreach (DataRow item in data.Rows)
            {
                HistoryDeviceDTO h = new HistoryDeviceDTO(item);
                listH.Add(h);
            }
            return listH;
        }
        public HistoryDeviceDTO GetItemHistory(DateTime date1, DateTime date2, string MachineCode, long idCategory)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            return GetListHistoryDeviceALL(date1, date2, MachineCode, idCategory).FirstOrDefault();
        }
        public List<HistoryDeviceDTO> GetListHistoryDeviceShort(DateTime date1, DateTime date2, string MachineCode)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            List<HistoryDeviceDTO> listH = new List<HistoryDeviceDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT HistoryDevice.Id,IdRelationShip ,IdCategory,DateCheck,DataCount,StatusHD,Employess,MachineCode,HistoryDevice.Note,NameCategory,Detail,Method,Limit,Result,TimeTT,Timer FROM dbo.HistoryDevice,dbo.CategoryTest,dbo.RelationShip WHERE IdRelationShip = RelationShip.Id AND IdCategory = CategoryTest.Id AND Timer = 24 AND MachineCode = N'" + MachineCode + "' AND DateCheck >= '" + date1 + "' AND DateCheck <='" + date2 + "'");
            foreach (DataRow item in data.Rows)
            {
                HistoryDeviceDTO h = new HistoryDeviceDTO(item);
                listH.Add(h);
            }
            return listH;
        }
        public List<HistoryDeviceDTO> GetListHistoryDeviceLong(DateTime date1, DateTime date2, string MachineCode)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            List<HistoryDeviceDTO> listH = new List<HistoryDeviceDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT HistoryDevice.Id,IdRelationShip,IdCategory,DateCheck,DataCount,StatusHD,Employess,MachineCode,HistoryDevice.Note,NameCategory,Detail,Method,Limit,Result,TimeTT,Timer FROM dbo.HistoryDevice,dbo.CategoryTest,dbo.RelationShip WHERE IdRelationShip = RelationShip.Id AND IdCategory = CategoryTest.Id AND Timer <> 24 AND MachineCode = N'" + MachineCode + "' AND DateCheck >= '" + date1 + "' AND DateCheck <='" + date2 + "'");
            foreach (DataRow item in data.Rows)
            {
                HistoryDeviceDTO h = new HistoryDeviceDTO(item);
                listH.Add(h);
            }
            return listH;
        }
        public int StatusHistoryById(int Id)
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT StatusHD FROM dbo.HistoryDevice WHERE Id = " + Id);
            }
            catch
            {
                return 0;
            }
        }
        public bool InsertHistoryDevice(long IdRelationShip, string DataCount, int StatusHD, DateTime DateCheck, string Employees, string Note, string Result)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format("INSERT dbo.HistoryDevice ( IdRelationShip , DataCount , StatusHD , DateCheck , Employess , Note,Result) VALUES  ( {0} , N'{1}' , {2} ,  '{3}' ,  N'{4}' ,  N'{5}',N'{6}')", IdRelationShip, DataCount, StatusHD, DateCheck, Employees, Note, Result);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateHistoryDevice(long Id, string DataCount, int StatusHD, string Note, DateTime DateCheck, string Result, string Employess)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format("UPDATE dbo.HistoryDevice SET StatusHD = {1} , Note = N'{2}',DataCount = N'{3}', DateCheck = '{4}' , Result = N'{5}' ,  Employess = N'{6}' WHERE Id = {0}", Id, StatusHD, Note, DataCount, DateCheck, Result, Employess);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateHistoryDevice(long Id, string DataCount, int StatusHD, string Note, DateTime DateCheck, string Result)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format("UPDATE dbo.HistoryDevice SET StatusHD = {1} , Note = N'{2}',DataCount = N'{3}', DateCheck = '{4}' , Result = N'{5}'  WHERE Id = {0}", Id, StatusHD, Note, DataCount, DateCheck, Result);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public DateTime? MaxDateByIdRelation(long IdRelationShip)
        {
            try
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
                return DateTime.Parse(DataProvider.Instance.ExecuteScalar("SELECT MAX(DateCheck) AS DateMax FROM dbo.HistoryDevice,dbo.CategoryTest,dbo.RelationShip WHERE IdRelationShip = RelationShip.Id AND IdCategory = CategoryTest.Id AND IdRelationShip = " + IdRelationShip).ToString());
            }
            catch
            {
                return null;
            }

        }
        public object GetListHistoryDevice(DateTime date1, DateTime date2)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            return (object)DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.HistoryDevice,dbo.CategoryTest,dbo.RelationShip WHERE IdRelationShip = RelationShip.Id AND IdCategory = CategoryTest.Id AND  Timer = 24 AND DateCheck >= '" + date1 + "' AND DateCheck <='" + date2 + "' ORDER BY DateCheck DESC");
        }
        public object GetListHistoryDeviceLong(DateTime date1, DateTime date2)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            return (object)DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.HistoryDevice,dbo.CategoryTest,dbo.RelationShip WHERE IdRelationShip = RelationShip.Id AND IdCategory = CategoryTest.Id AND  Timer <> 24 AND DateCheck >= '" + date1 + "' AND DateCheck <='" + date2 + "' ORDER BY DateCheck DESC");
        }
        public int StatusHDById(int Id)
        {
            return (int)DataProvider.Instance.ExecuteScalar("SELECT StatusHD FROM dbo.HistoryDevice,dbo.CategoryTest,dbo.RelationShip WHERE IdRelationShip = RelationShip.Id AND IdCategory = CategoryTest.Id AND HistoryDevice.Id = " + Id);
        }
        #endregion
        #region Check
        public List<CheckDeviceDTO> GetListEveryDay(string MachineCode)
        {
            List<CheckDeviceDTO> listC = new List<CheckDeviceDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT RelationShip.Id AS IdRelationShip,IdCategory,RelationShip.MachineCode,NameCategory,Detail,Method,Limit,TimeTT,Timer,NoteCate AS Reality,NoteCate as Result,NoteCate as Note,NoteCate as Employess FROM dbo.RelationShip,dbo.CategoryTest,dbo.Machine WHERE Timer = 24 AND CategoryTest.Id = IdCategory AND Machine.MachineCode = RelationShip.MachineCode AND RelationShip.MachineCode = N'" + MachineCode + "'");
            foreach (DataRow item in data.Rows)
            {
                CheckDeviceDTO c = new CheckDeviceDTO(item);
                listC.Add(c);
            }
            return listC;
        }

        public List<CheckDeviceDTO> GetListEveryMainten(string MachineCode)
        {
            List<CheckDeviceDTO> listC = new List<CheckDeviceDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT RelationShip.Id AS IdRelationShip,IdCategory,RelationShip.MachineCode,NameCategory,Detail,Method,Limit,TimeTT,Timer,NoteCate AS Reality,NoteCate as Result,NoteCate as Note,NoteCate as Employess FROM dbo.RelationShip,dbo.CategoryTest,dbo.Machine WHERE Timer <> 24 AND CategoryTest.Id = IdCategory AND Machine.MachineCode = RelationShip.MachineCode AND RelationShip.MachineCode = N'" + MachineCode + "'");
            foreach (DataRow item in data.Rows)
            {
                CheckDeviceDTO c = new CheckDeviceDTO(item);
                listC.Add(c);
            }
            return listC;
        }
        public List<CheckDeviceDTO> GetListEveryMaintenBy(string MachineCode)
        {
            List<CheckDeviceDTO> listC = new List<CheckDeviceDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT RelationShip.Id AS IdRelationShip,IdCategory,RelationShip.MachineCode,NameCategory,Detail,Method,Limit,TimeTT,Timer,NoteCate AS Reality,NoteCate as Result,NoteCate as Note,NoteCate as Employess FROM dbo.RelationShip,dbo.CategoryTest,dbo.Machine WHERE Timer <> 24 AND CategoryTest.Id = IdCategory AND Machine.MachineCode = RelationShip.MachineCode AND RelationShip.MachineCode = N'" + MachineCode + "' AND TimeTT >= (Timer*0.85)");
            foreach (DataRow item in data.Rows)
            {
                CheckDeviceDTO c = new CheckDeviceDTO(item);
                listC.Add(c);
            }
            return listC;
        }
        public object GetListEveryDay(string MachineCode, int ConfirmCategory)
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT RelationShip.Id,RelationShip.MachineCode,NameCategory,Detail,Method,IdCategory FROM dbo.RelationShip,dbo.CategoryTest,dbo.Machine WHERE Timer = 24 AND CategoryTest.Id = IdCategory AND Machine.MachineCode = RelationShip.MachineCode AND ConfirmCategory = " + ConfirmCategory + " AND RelationShip.MachineCode = N'" + MachineCode + "'");
        }

        public object GetListEveryMainten(string MachineCode, int ConfirmCategory)
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT RelationShip.Id,RelationShip.MachineCode,NameCategory,Detail,Method,IdCategory,TimeTT,Timer FROM dbo.RelationShip,dbo.CategoryTest,dbo.Machine WHERE Timer <> 24 AND CategoryTest.Id = IdCategory AND Machine.MachineCode = RelationShip.MachineCode AND ConfirmCategory = " + ConfirmCategory + " AND RelationShip.MachineCode = N'" + MachineCode + "'");
        }
        public int TestCheckHistory(int IdRelationShip, DateTime Date1, DateTime Date2)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.HistoryDevice WHERE IdRelationShip = " + IdRelationShip + " AND DateCheck > = '" + Date1 + "' AND DateCheck <= '" + Date2 + "'");
            if (data.Rows.Count > 0)
            {
                return 1;
            }
            return -1;
        }
        #endregion
        #region Edit History Machine
        public List<MachineDTO> GetListMachineAll()
        {
            List<MachineDTO> listM = new List<MachineDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Machine ORDER BY Device");
            foreach (DataRow item in data.Rows)
            {
                MachineDTO m = new MachineDTO(item);
                listM.Add(m);
            }
            return listM;
        }
        public object GetListEdit()
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.HistoryEdit ORDER BY DateMachine DESC");
        }
        public object GetListEdit(string machineCode)
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT Id,DateMachine,TimeMachine,UPPER(HistoryEdit.MachineCode) AS MachineCode,LOWER(MachineName) AS MachineName,LOWER(ErrorName) AS ErrorName," +
" LOWER(Reason) AS Reason, LOWER(Detail) AS Detail, LOWER(Employess) AS Employess, LOWER(Note) AS Note, DateError, LOWER(TimeStart) AS TimeStart, LOWER(TimeMain) AS TimeMain" +
" FROM dbo.HistoryEdit, Machine WHERE HistoryEdit.MachineCode = Machine.MachineCode  AND HistoryEdit.MachineCode = N'" + machineCode + "'");
        }
        public bool InsertEdit(DateTime DateMachine, int TimeMachine, string MachineCode, string ErrorName, string Reason, string Detail, string Employess, string Note, DateTime DateError, string TimeStart, string TimeMain)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format("INSERT dbo.HistoryEdit ( DateMachine ,TimeMachine , MachineCode ,ErrorName ,Reason , Detail ,Employess , Note , DateError , TimeStart , TimeMain) VALUES  ( '{0}' , {1} ,N'{2}' ,N'{3}' , N'{4}' , N'{5}' , N'{6}' , N'{7}' , '{8}', N'{9}', N'{10}')", DateMachine, TimeMachine, MachineCode, ErrorName, Reason, Detail, Employess, Note, DateError, TimeStart, TimeMain);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateEdit(long Id, DateTime DateMachine, int TimeMachine, string MachineCode, string ErrorName, string Reason, string Detail, string Employess, string Note, DateTime DateError, string TimeStart, string TimeMain)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format("UPDATE [dbo].[HistoryEdit] SET [DateMachine] = '{1}',[TimeMachine] = {2} ,[MachineCode] = N'{3}',[ErrorName] = N'{4}',[Reason] = N'{5}',[Detail] = N'{6}',[Employess] = N'{7}',[Note] = N'{8}' , [DateError] = '{9}', TimeStart = N'{10}', TimeMain = N'{11}' WHERE Id = {0}", Id, DateMachine, TimeMachine, MachineCode, ErrorName, Reason, Detail, Employess, Note, DateError, TimeStart, TimeMain);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteEdit(long Id)
        {
            string query = string.Format("DELETE dbo.HistoryEdit WHERE Id = {0}", Id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        #endregion
        #region All Device an Machine
        public object GetListMachineByListDevice()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT MachineCode,MachineName,Device,Name FROM dbo.Machine,dbo.ListDevice WHERE Id = Device");

        }
        public bool UpdateDeviceMachine(string code, int device)
        {
            string query = string.Format("UPDATE dbo.Machine SET Device = {1} WHERE MachineCode = N'{0}'", code, device);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        #endregion
        #region Chart Device
        public object GetlistNameCategory()
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT DISTINCT(NameCategory) FROM dbo.HistoryDevice,dbo.RelationShip,dbo.CategoryTest WHERE CategoryTest.Id = IdCategory AND IdRelationShip = RelationShip.Id AND ConfirmCategory = 1");
        }
        public object GetlistMachineByCategory(string name)
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT DISTINCT(MachineCode) FROM dbo.HistoryDevice,dbo.RelationShip,dbo.CategoryTest WHERE CategoryTest.Id = IdCategory AND IdRelationShip = RelationShip.Id AND ConfirmCategory = 1 AND NameCategory = N'" + name + "'");
        }
        public List<ChartDeviceDTO> GetlistChartDevice(string name, string code, DateTime date1, DateTime date2)
        {
            List<ChartDeviceDTO> listC = new List<ChartDeviceDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT NameCategory , MachineCode ,DataCount ,DateCheck, CategoryTest.Id FROM dbo.HistoryDevice,dbo.RelationShip,dbo.CategoryTest WHERE CategoryTest.Id = IdCategory AND IdRelationShip = RelationShip.Id AND ConfirmCategory = 1 AND DateCheck >= '" + date1 + "' AND DateCheck <= '" + date2 + "' AND NameCategory = N'" + name + "' AND MachineCode = N'" + code + "'");
            foreach (DataRow item in data.Rows)
            {
                ChartDeviceDTO c = new ChartDeviceDTO(item);
                listC.Add(c);
            }
            return listC;
        }
        #endregion
        #region CategoryInfor
        public object GetlistCategoryInfor()
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.CategotyInfor");
        }
        public bool InsertCategoryInfor(string CategoryName, float CountUp, float CountDown, string Note, string MachineCode)
        {
            string query = string.Format("INSERT dbo.CategotyInfor ( CategoryName , CountUp , CountDown , Note , MachineCode ) VALUES  ( N'{0}' , {1} , {2} , N'{3}' ,N'{4}' )", CategoryName, CountUp, CountDown, Note, MachineCode);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateCategoryInfor(int id, string CategoryName, float CountUp, float CountDown, string Note, string MachineCode)
        {
            string query = string.Format("UPDATE dbo.CategotyInfor SET CategoryName = N'{1}',CountUp = {2} , CountDown = {3} , Note = N'{4}', MachineCode = N'{5}' WHERE Id = {0}", id, CategoryName, CountUp, CountDown, Note, MachineCode);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteCategoryInfor(int id)
        {
            string query = string.Format("DELETE dbo.CategotyInfor WHERE Id = {0}", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public float CountUp(string name, string code)
        {
            try
            {
                return (float)Convert.ToDouble(DataProvider.Instance.ExecuteScalar("SELECT CountUp FROM dbo.CategotyInfor WHERE CategoryName = N'" + name + "' AND MachineCode = N'" + code + "'").ToString());
            }
            catch
            {
                return 0;
            }

        }
        public float CountDown(string name, string code)
        {
            try
            {
                return (float)Convert.ToDouble(DataProvider.Instance.ExecuteScalar("SELECT CountDown FROM dbo.CategotyInfor WHERE CategoryName = N'" + name + "' AND MachineCode = N'" + code + "'").ToString());
            }
            catch
            {
                return 0;
            }

        }
        #endregion
    }
}
