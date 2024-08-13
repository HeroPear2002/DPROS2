using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class PartDAO
    {
        private static PartDAO instance;

        public static PartDAO Instance
        {
            get
            {
                if (instance == null) instance = new PartDAO();
                return instance;
            }

            set
            {
                instance = value;
            }
        }
        public List<PartDTO> GetListPart()
        {
            List<PartDTO> listP = new List<PartDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT PartCode,PartName,Material.MaterialCode,MaterialName,CustomerCode,CountBox,CountPart,WeightRunner,WeightPart,CycleTime,Cavity,Height,Note,NameVN FROM dbo.Part, dbo.Material WHERE Material.MaterialCode = Part.MaterialCode");
            foreach (DataRow item in data.Rows)
            {
                PartDTO p = new PartDTO(item);
                listP.Add(p);
            }
            return listP;
        }
        public List<PartDTO> GetListPart(string materialCode)
        {
            List<PartDTO> listP = new List<PartDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT PartCode,PartName,Material.MaterialCode,MaterialName," +
                "CustomerCode,CountBox,CountPart,WeightRunner,WeightPart,CycleTime,Cavity,Height,Note,NameVN FROM dbo.Part, " +
                "dbo.Material WHERE Material.MaterialCode = Part.MaterialCode AND Part.MaterialCode = N'"+materialCode+"'");
            foreach (DataRow item in data.Rows)
            {
                PartDTO p = new PartDTO(item);
                listP.Add(p);
            }
            return listP;
        }
        public PartDTO GetItemPart(string partCode)
        {
            return GetListPart().FirstOrDefault(x => x.PartCode == partCode);
        }
        public bool InsertPart(string PartCode, string PartName, string MaterialCode, string CustomerCode, int CountBox, int CountPart, float WeightRunne, float WeightPart, float CycleTime, int Cavity, int Height, float Note, string NameVN)
        {
            string query = string.Format("INSERT dbo.Part ( PartCode , PartName , MaterialCode , CustomerCode , CountBox , CountPart , WeightRunner , WeightPart , CycleTime ,Cavity , Height, Note, NameVN ) VALUES  ( N'{0}' ,  N'{1}' ,  N'{2}' ,  N'{3}' ,  {4} , {5} , {6} , {7} ,  {8} , {9} , {10},{11},N'{12}')", PartCode, PartName, MaterialCode, CustomerCode, CountBox, CountPart, WeightRunne, WeightPart, CycleTime, Cavity, Height, Note, NameVN);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdatePart(string PartCode, string PartName, string MaterialCode, string CustomerCode, int CountBox, int CountPart, float WeightRunne, float WeightPart, float CycleTime, int Cavity, int Height, float Note, string NameVN, string StylePart )
        {
            string query = string.Format("UPDATE [dbo].[Part] SET [PartName] = N'{1}',[MaterialCode] = N'{2}' ,[CustomerCode] =N'{3}',[CountBox] = {4} ,[CountPart] = {5} ,[WeightRunner] = {6} ,[WeightPart] = {7} ,[CycleTime] = {8} ,[Cavity] = {9} ,[Height] = {10} , Note = {11} , NameVN = N'{12}' , [StylePart] = N'{13}' WHERE [PartCode] = N'{0}'", PartCode, PartName, MaterialCode, CustomerCode, CountBox, CountPart, WeightRunne, WeightPart, CycleTime, Cavity, Height, Note, NameVN,StylePart);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeletetPart(string PartCode)
        {
            string query = string.Format("DELETE dbo.Part WHERE PartCode = N'{0}'", PartCode);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool ConfirmPart(string PartCode, string Style)
        {
            string query = string.Format("UPDATE [dbo].[Part] SET [StylePart] = N'{1}' WHERE [PartCode] = N'{0}'", PartCode, Style);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public int TestPartByCode(string PartCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Part WHERE PartCode = N'" + PartCode + "'");
            if (data.Rows.Count > 0)
            {
                return 1;
            }
            return -1;
        }
        public int HeightPartByCode(string PartCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT PartCode,PartName,Material.MaterialCode,MaterialName,CustomerCode,CountBox,CountPart,WeightRunner,WeightPart,CycleTime,Cavity,Height,Note,NameVN FROM dbo.Part, dbo.Material WHERE Material.MaterialCode = Part.MaterialCode AND PartCode = N'" + PartCode + "'");
            if (data.Rows.Count > 0)
            {
                PartDTO p = new PartDTO(data.Rows[0]);
                return p.Height;
            }
            return 5000;
        }
        public int CountPartByCode(string PartCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT PartCode,PartName,Material.MaterialCode,MaterialName,CustomerCode,CountBox,CountPart,WeightRunner,WeightPart,CycleTime,Cavity,Height,Note,NameVN FROM dbo.Part, dbo.Material WHERE Material.MaterialCode = Part.MaterialCode AND PartCode = N'" + PartCode + "'");
            if (data.Rows.Count > 0)
            {
                PartDTO p = new PartDTO(data.Rows[0]);
                return p.CountPart;
            }
            return 0;
        }
        public int CountBoxByCode(string PartCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT PartCode,PartName,Material.MaterialCode,MaterialName,CustomerCode,CountBox,CountPart,WeightRunner,WeightPart,CycleTime,Cavity,Height,Note,NameVN FROM dbo.Part, dbo.Material WHERE Material.MaterialCode = Part.MaterialCode AND PartCode = N'" + PartCode + "'");
            if (data.Rows.Count > 0)
            {
                PartDTO p = new PartDTO(data.Rows[0]);
                return p.CountBox;
            }
            return 0;
        }
        public string NamePartByCode(string PartCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT PartCode,PartName,Material.MaterialCode,MaterialName,CustomerCode,CountBox,CountPart,WeightRunner,WeightPart,CycleTime,Cavity,Height,Note,NameVN FROM dbo.Part, dbo.Material WHERE Material.MaterialCode = Part.MaterialCode AND PartCode = N'" + PartCode + "'");
            if (data.Rows.Count > 0)
            {
                PartDTO p = new PartDTO(data.Rows[0]);
                return p.PartName;
            }
            return null;
        }
        public string CustomerByCode(string PartCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT PartCode,PartName,Material.MaterialCode,MaterialName,CustomerCode,CountBox,CountPart,WeightRunner,WeightPart,CycleTime,Cavity,Height,Note,NameVN FROM dbo.Part, dbo.Material WHERE Material.MaterialCode = Part.MaterialCode AND PartCode = N'" + PartCode + "'");
            if (data.Rows.Count > 0)
            {
                PartDTO p = new PartDTO(data.Rows[0]);
                return p.CustomerCode;
            }
            return null;
        }
        public string MaterialCodeByCode(string PartCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT PartCode,PartName,Material.MaterialCode,MaterialName,CustomerCode,CountBox,CountPart,WeightRunner,WeightPart,CycleTime,Cavity,Height,Note,NameVN FROM dbo.Part, dbo.Material WHERE Material.MaterialCode = Part.MaterialCode AND PartCode = N'" + PartCode + "'");
            if (data.Rows.Count > 0)
            {
                PartDTO p = new PartDTO(data.Rows[0]);
                return p.MaterialCode;
            }
            return null;
        }
        public string MaterialNameByCode(string PartCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT PartCode,PartName,Material.MaterialCode,MaterialName,CustomerCode,CountBox,CountPart,WeightRunner,WeightPart,CycleTime,Cavity,Height,Note,NameVN FROM dbo.Part, dbo.Material WHERE Material.MaterialCode = Part.MaterialCode AND PartCode = N'" + PartCode + "'");
            if (data.Rows.Count > 0)
            {
                PartDTO p = new PartDTO(data.Rows[0]);
                return p.MaterialName;
            }
            return null;
        }
        public float WeightByCode(string PartCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT PartCode,PartName,Material.MaterialCode,MaterialName,CustomerCode,CountBox,CountPart,WeightRunner,WeightPart,CycleTime,Cavity,Height,Note,NameVN FROM dbo.Part, dbo.Material WHERE Material.MaterialCode = Part.MaterialCode AND PartCode = N'" + PartCode + "'");
            if (data.Rows.Count > 0)
            {
                PartDTO p = new PartDTO(data.Rows[0]);
                return p.WeightPart;
            }
            return 0;
        }
        public float WeightRunnerByCode(string PartCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT PartCode,PartName,Material.MaterialCode,MaterialName,CustomerCode,CountBox,CountPart,WeightRunner,WeightPart,CycleTime,Cavity,Height,Note,NameVN FROM dbo.Part, dbo.Material WHERE Material.MaterialCode = Part.MaterialCode AND PartCode = N'" + PartCode + "'");
            if (data.Rows.Count > 0)
            {
                PartDTO p = new PartDTO(data.Rows[0]);
                return p.WeightRunner;
            }
            return 0;
        }
        public float CycleTimeByCode(string PartCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT PartCode,PartName,Material.MaterialCode,MaterialName,CustomerCode,CountBox,CountPart,WeightRunner,WeightPart,CycleTime,Cavity,Height,Note,NameVN FROM dbo.Part, dbo.Material WHERE Material.MaterialCode = Part.MaterialCode AND PartCode = N'" + PartCode + "'");
            if (data.Rows.Count > 0)
            {
                PartDTO p = new PartDTO(data.Rows[0]);
                return p.CycleTime;
            }
            return 0;
        }
        public int CavityByCode(string PartCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT PartCode,PartName,Material.MaterialCode,MaterialName,CustomerCode,CountBox,CountPart,WeightRunner,WeightPart,CycleTime,Cavity,Height,Note,NameVN FROM dbo.Part, dbo.Material WHERE Material.MaterialCode = Part.MaterialCode AND PartCode = N'" + PartCode + "'");
            if (data.Rows.Count > 0)
            {
                PartDTO p = new PartDTO(data.Rows[0]);
                return p.Cavity;
            }
            return 0;
        }
        public int DateNote(string PartCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT PartCode,PartName,Material.MaterialCode,MaterialName,CustomerCode,CountBox,CountPart,WeightRunner,WeightPart,CycleTime,Cavity,Height,Note,NameVN FROM dbo.Part, dbo.Material WHERE Material.MaterialCode = Part.MaterialCode AND PartCode = N'" + PartCode + "'");
            if (data.Rows.Count > 0)
            {
                PartDTO p = new PartDTO(data.Rows[0]);
                return (int)p.Note;
            }
            return 5;
        }
        public string CustomerPart(string partcode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT PartCode,PartName,Material.MaterialCode,MaterialName,CustomerCode,CountBox,CountPart,WeightRunner,WeightPart,CycleTime,Cavity,Height,Note,NameVN FROM dbo.Part, dbo.Material WHERE Material.MaterialCode = Part.MaterialCode AND PartCode = N'" + partcode + "'");
            if (data.Rows.Count > 0)
            {
                PartDTO p = new PartDTO(data.Rows[0]);
                return p.CustomerCode;
            }
            return "";
        }
        public string NameVNPart(string partcode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT PartCode,PartName,Material.MaterialCode,MaterialName,CustomerCode,CountBox,CountPart,WeightRunner,WeightPart,CycleTime,Cavity,Height,Note,NameVN FROM dbo.Part, dbo.Material WHERE Material.MaterialCode = Part.MaterialCode AND PartCode = N'" + partcode + "'");
            if (data.Rows.Count > 0)
            {
                PartDTO p = new PartDTO(data.Rows[0]);
                return p.NameVN;
            }
            return "";
        }
        public string StylePart(string partCode)
        {
            try
            {
                return DataProvider.Instance.ExecuteScalar("Select StylePart From Part Where PartCode = N'" + partCode + "'").ToString();
            }
            catch
            {
                return "";
            }
        }
        #region Part Infor
        public object GetlistPartInfor()
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT * FROM PartInfor");
        }
        public bool InsertPartInfor(string code, float percent,string WeightBy)
        {
            string query = string.Format("INSERT dbo.PartInfor ( PartCode, Percentage , WeightBy) VALUES  ( N'{0}',  {1} , N'{2}')", code, percent, WeightBy);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdatePartInfor(string code, float percent, string WeightBy)
        {
            string query = string.Format("UPDATE dbo.PartInfor SET Percentage = '{1}', WeightBy = N'{2}' WHERE PartCode = N'{0}'", code, percent, WeightBy);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeletePartInfor(string code)
        {
            string query = string.Format("DELETE PartInfor WHERE PartCode = N'{0}'", code);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public float PercentPart(string code)
        {
            try
            {
                return (float)Convert.ToDouble(DataProvider.Instance.ExecuteScalar("SELECT Percentage FROM dbo.PartInfor WHERE PartCode = N'" + code + "'").ToString());
            }
            catch
            {
                return 0;
            }
        }
        public float WeightByPart(string code)
        {
            try
            {
                return (float)Convert.ToDouble(DataProvider.Instance.ExecuteScalar("SELECT WeightBy FROM dbo.PartInfor WHERE PartCode = N'" + code + "'").ToString());
            }
            catch
            {
                return 0;
            }
        }
        public int TestPartInfor(string code)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.PartInfor WHERE PartCode = N'" + code + "'");
            if (data.Rows.Count > 0)
            {
                return 1;
            }
            return -1;
        }
        public int TestPartCode(string code)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Part WHERE PartCode = N'" + code + "'");
            if (data.Rows.Count > 0)
            {
                return 1;
            }
            return -1;
        }
        #endregion
        #region Part Lock
        public object GetlistPartNew(string partCode)
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT PartCode,MoldNumber,MachineCode FROM dbo.MacInfor , dbo.Mold WHERE MacInfor.MoldCode = Mold.MoldCode AND PartCode = N'" + partCode + "'");
        }
        public object GetlistPartLock()
        {
            return (object)DataProvider.Instance.ExecuteQuery("select * from PartLock, StatusWH Where StatusWH.Id = StatusWh");
        }
        public bool InsertPartLock(string code, string name, string machine, string note, int StatusWh, string Yellow)
        {
            string query = string.Format("INSERT dbo.PartLock ( PartCode, MoldNumber, MachineCode, Note, StatusWh, Yellow ) VALUES  ( N'{0}', N'{1}',N'{2}',N'{3}', {4}, N'{5}')", code, name, machine, note, StatusWh, Yellow);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeletePartLock(int Id)
        {
            string query = string.Format("DELETE dbo.PartLock WHERE Id = {0}", Id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public int TestPartLock(string partCode, string moldNumber, string machineCode)
        {
            try
            {
                return int.Parse(DataProvider.Instance.ExecuteScalar("SELECT Id FROM dbo.PartLock WHERE PartCode = N'" + partCode + "'  AND MoldNumber = N'" + moldNumber + "' AND MachineCode = N'" + machineCode + "'").ToString());
            }
            catch
            {
                return -1;
            }
        }
        public string NotePartLock(int Id)
        {
            try
            {
                return DataProvider.Instance.ExecuteScalar("SELECT Note FROM dbo.PartLock WHERE Id =" + Id).ToString();
            }
            catch
            {
                return "";
            }
        }
        public int sttWhPartLock(int Id)
        {
            try
            {
                return int.Parse(DataProvider.Instance.ExecuteScalar("SELECT StatusWh FROM dbo.PartLock WHERE Id =" + Id).ToString());
            }
            catch
            {
                return 3;
            }
        }
        public string YellowPartLock(int Id)
        {
            try
            {
                return DataProvider.Instance.ExecuteScalar("SELECT Yellow FROM dbo.PartLock WHERE Id =" + Id).ToString();
            }
            catch
            {
                return "O";
            }
        }
        #endregion
        #region Form Part
        public object GetlistFormPart()
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.FormPart");
        }
        public bool DeleteFormPart(string part)
        {
            string query = string.Format("DELETE dbo.FormPart WHERE PartCode = N'{0}'", part);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool InsertFormPart(string part, string ld, string dk, string xh, string note)
        {
            string query = string.Format("INSERT dbo.FormPart ( PartCode , FormLD , FormDK , FormXH ,Note ) VALUES  ( N'{0}' , N'{1}' , N'{2}' ,  N'{3}' ,  N'{4}' )", part, ld, dk, xh, note);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateFormpart(string part, string ld, string dk, string xh, string note)
        {
            string query = string.Format("UPDATE dbo.FormPart SET FormLD = N'{1}' , FormDK = N'{2}' , FormXH = N'{3}' , Note = N'{4}' WHERE PartCode = N'{0}'", part, ld, dk, xh, note);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public string LD(string part)
        {
            try
            {
                return DataProvider.Instance.ExecuteScalar("SELECT FormLD FROM dbo.FormPart WHERE PartCode = N'" + part + "'").ToString();
            }
            catch
            {
                return "";
            }
        }
        public string DK(string part)
        {
            try
            {
                return DataProvider.Instance.ExecuteScalar("SELECT FormDK FROM dbo.FormPart WHERE PartCode = N'" + part + "'").ToString();
            }
            catch
            {
                return "";
            }
        }
        public string XH(string part)
        {
            try
            {
                return DataProvider.Instance.ExecuteScalar("SELECT FormXH FROM dbo.FormPart WHERE PartCode = N'" + part + "'").ToString();
            }
            catch
            {
                return "";
            }
        }
        #endregion
    }
}
