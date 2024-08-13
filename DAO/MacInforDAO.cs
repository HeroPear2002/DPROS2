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
    public class MacInforDAO
    {
        private static MacInforDAO instance;

        public static MacInforDAO Instance
        {
            get
            {
                if (instance == null) instance = new MacInforDAO();
                return instance;
            }

            set
            {
                instance = value;
            }
        }
        public List<MacInforDTO> GetListMac()
        {
            List<MacInforDTO> listM = new List<MacInforDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT Id,PartCode,MachineCode,MacInfor.MoldCode,MoldNumber,Important,Rev,FactoryCode,Standard,StatusM FROM dbo.MacInfor,dbo.Mold WHERE MacInfor.MoldCode = Mold.MoldCode");
            foreach (DataRow item in data.Rows)
            {
                MacInforDTO m = new MacInforDTO(item);
                listM.Add(m);
            }
            return listM;
        }
        public List<MacInforDTO> GetListMacPrint(string PartCode, string MachineCode, string MoldCode)
        {
            List<MacInforDTO> listM = new List<MacInforDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT Id,PartCode,MachineCode,MacInfor.MoldCode,MoldNumber,Important, Rev,FactoryCode,Standard,StatusM FROM dbo.MacInfor,dbo.Mold WHERE MacInfor.MoldCode = Mold.MoldCode AND PartCode = N'" + PartCode + "' AND MachineCode = N'" + MachineCode + "' AND MacInfor.MoldCode = N'" + MoldCode + "'");
            foreach (DataRow item in data.Rows)
            {
                MacInforDTO m = new MacInforDTO(item);
                listM.Add(m);
            }
            return listM;
        }
        public int ImportantMac(string PartCode)
        {
            try
            {
                return int.Parse(DataProvider.Instance.ExecuteScalar("select Distinct(Important) from MacInfor where PartCode = N'" + PartCode + "'").ToString());
            }
            catch
            {
                return 0;
            }
        }
        public string RevMac(string PartCode, string MachineCode, string MoldNumber)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT Id,PartCode,MachineCode,MacInfor.MoldCode,MoldNumber,Important,Rev,FactoryCode,Standard,StatusM FROM dbo.MacInfor,dbo.Mold WHERE MacInfor.MoldCode = Mold.MoldCode AND PartCode = N'" + PartCode + "' AND MachineCode = N'" + MachineCode + "' AND MoldNumber = N'" + MoldNumber + "'");
            if (data.Rows.Count > 0)
            {
                MacInforDTO m = new MacInforDTO(data.Rows[0]);
                return m.Rev;
            }
            return null;
        }
        public object GetListPart()
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT DISTINCT(MacInfor.PartCode),PartName,MaterialCode FROM dbo.MacInfor , dbo.Part WHERE MacInfor.PartCode = Part.PartCode ORDER BY MacInfor.PartCode");
        }
        public object GetListMoldByPart(string PartCode)
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT DISTINCT(MacInfor.MoldCode),MoldNumber FROM dbo.MacInfor,dbo.Mold WHERE MacInfor.MoldCode = Mold.MoldCode AND PartCode = N'" + PartCode + "'");
        }
        public object GetListMachineByPartMold(string PartCode, string MoldCode)
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT DISTINCT(MachineCode) FROM dbo.MacInfor,dbo.Mold WHERE MacInfor.MoldCode = Mold.MoldCode AND PartCode = N'" + PartCode + "' AND MacInfor.MoldCode = N'" + MoldCode + "'");
        }
        public object GetListFactoryCodeByAll(string PartCode, string MoldCode, string MachineCode)
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT DISTINCT(FactoryCode) FROM dbo.MacInfor,dbo.Mold WHERE MacInfor.MoldCode = Mold.MoldCode AND PartCode = N'" + PartCode + "' AND MacInfor.MoldCode = N'" + MoldCode + "' AND MacInfor.MachineCode = N'" + MachineCode + "'");
        }
        public string StandardCodeByAll(string PartCode, string MoldCode, string MachineCode, string FactoryCode)
        {
            try
            {
                return DataProvider.Instance.ExecuteScalar("SELECT Standard FROM dbo.MacInfor,dbo.Mold WHERE MacInfor.MoldCode = Mold.MoldCode AND PartCode = N'" + PartCode + "' AND MacInfor.MoldCode = N'" + MoldCode + "' AND MacInfor.MachineCode = N'" + MachineCode + "' AND MacInfor.FactoryCode = N'" + FactoryCode + "'").ToString();
            }
            catch 
            {
                return "";
            }
        }
        public int StatusMById(int Id)
        {
            return int.Parse(DataProvider.Instance.ExecuteScalar("SELECT StatusM FROM dbo.MacInfor,dbo.Mold WHERE MacInfor.MoldCode = Mold.MoldCode AND Id = " + Id).ToString());
        }
        public bool InsertMac(string PartCode, string MachineCode, string MoldCode, string Rev, string FactoryCode, string Standard)
        {
            string query = string.Format("INSERT dbo.MacInfor( PartCode, MachineCode, MoldCode, Rev, FactoryCode, Standard ) VALUES  ( N'{0}', N'{1}', N'{2}', N'{3}', N'{4}',N'{5}')", PartCode, MachineCode, MoldCode, Rev, FactoryCode, Standard);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateMac(int Id, string PartCode, string MachineCode, string MoldCode, string Rev, string FactoryCode, string Standard)
        {
            string query = string.Format("UPDATE [dbo].[MacInfor] SET  [PartCode] = N'{1}', [MachineCode] = N'{2}',[MoldCode] = N'{3}', Rev = N'{4}', FactoryCode = N'{5}', Standard = N'{6}' WHERE Id = {0}", Id, PartCode, MachineCode, MoldCode, Rev, FactoryCode, Standard);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateMacInportant(string PartCode, int Important)
        {
            string query = string.Format("UPDATE [dbo].[MacInfor] SET  [Important] = N'{1}' WHERE PartCode = N'{0}'", PartCode, Important);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateMacStatusM(int Id, int status)
        {
            string query = string.Format("UPDATE [dbo].[MacInfor] SET  [StatusM] = N'{1}' WHERE Id = {0}", Id, status);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteMac(int Id)
        {
            string query = string.Format("DELETE dbo.MacInfor WHERE Id = {0}", Id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public int TestMacByAll(string PartCode, string MachineCode, string MoldCode)
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT Id FROM dbo.MacInfor WHERE PartCode = N'" + PartCode + "' AND MachineCode = N'" + MachineCode + "' AND MoldCode = N'" + MoldCode + "'");
            }
            catch
            {
                return -1;
            }
        }
        public string MoldCodeByMac(string PartCode, string MachineCode, string MoldNumber)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT Id,PartCode,MachineCode,MacInfor.MoldCode,MoldNumber,Important,Rev,FactoryCode,Standard,StatusM FROM dbo.MacInfor,dbo.Mold WHERE MacInfor.MoldCode = Mold.MoldCode AND PartCode = N'" + PartCode + "' AND MachineCode = N'" + MachineCode + "' AND MoldNumber = N'" + MoldNumber + "'");
            if (data.Rows.Count > 0)
            {
                MacInforDTO m = new MacInforDTO(data.Rows[0]);
                return m.MoldCode;
            }
            return null;
        }
        #region NOT 4M

        #endregion
        #region KHSX
        public string GetMachineByPart(string partcode, int num)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT DISTINCT(MachineCode),Important FROM dbo.MacInfor WHERE PartCode = N'" + partcode + "' ORDER BY Important DESC");
            if (data.Rows.Count > 0)
            {
                MachineInportantDTO m = new MachineInportantDTO(data.Rows[num]);
                return m.MachineCode;
            }
            return null;
        }
        public string GetMoldByPart(string partcode, string MachineCode, int num)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT DISTINCT(MoldCode),Important FROM dbo.MacInfor WHERE PartCode = N'" + partcode + "' AND MachineCode = N'" + MachineCode + "' ORDER BY Important DESC");
            if (data.Rows.Count > 0)
            {
                MoldImportantDTO m = new MoldImportantDTO(data.Rows[num]);
                return m.MoldCode;
            }
            return null;
        }
        public int NumberMachine(string partcode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT DISTINCT(MachineCode),Important FROM dbo.MacInfor WHERE PartCode = N'" + partcode + "' ORDER BY Important DESC");
            return data.Rows.Count;
        }
        public int NumberMold(string partcode, string MachineCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT DISTINCT(MoldCode), Important FROM dbo.MacInfor WHERE PartCode = N'" + partcode + "' AND MachineCode = N'" + MachineCode + "' ORDER BY Important DESC");
            return data.Rows.Count;
        }
        #endregion
        #region History Mac 
        public List<HistoryMacDTO> GetListMacbyDate(DateTime Date1, DateTime Date2)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format("Select * from HistoryMac Where Lot >= '{0}' AND Lot <= '{1}'", Date1, Date2);
            List<HistoryMacDTO> listH = new List<HistoryMacDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                HistoryMacDTO h = new HistoryMacDTO(item);
                listH.Add(h);
            }
            return listH;
        }
        public bool InsertHistoryMac(string PartCode, DateTime DateIn, string Employess, int NumberTo, int NumberFrom, DateTime Lot)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format("INSERT INTO dbo.HistoryMac (PartCode,DateIn,Employess,NumberTo,NumberFrom,Lot) VALUES (N'{0}','{1}',N'{2}',{3}, {4},'{5}')", PartCode, DateIn, Employess, NumberTo, NumberFrom, Lot);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        #endregion
    }
}
