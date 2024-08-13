using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DryingAndPourDAO
    {
        private static DryingAndPourDAO instance;

        public static DryingAndPourDAO Instance
        {
            get
            {
                if (instance == null) instance = new DryingAndPourDAO();
                return instance;
            }
            set => instance = value;
        }
        public List<DryingDTO> GetListDrying()
        {
            List<DryingDTO> listD = new List<DryingDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT Id,DryingMaterial.MaterialCode,MaterialName,MachineDry," +
                "QuantityDry,DateDrying,DatePour,Employess,PartCode,MachineCode,StatusDry,Note FROM DryingMaterial,Material WHERE " +
                "Material.MaterialCode = DryingMaterial.MaterialCode ORDER BY Id");
            foreach (DataRow item in data.Rows)
            {
                DryingDTO d = new DryingDTO(item);
                listD.Add(d);
            }
            return listD;
        }
        public List<DryingDTO> GetListDrying(long Id)
        {
            List<DryingDTO> listD = new List<DryingDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT Id,DryingMaterial.MaterialCode,MaterialName,MachineDry," +
                "QuantityDry,DateDrying,DatePour,Employess,PartCode,MachineCode,StatusDry,Note FROM DryingMaterial,Material WHERE " +
                "Material.MaterialCode = DryingMaterial.MaterialCode AND Id = "+Id);
            foreach (DataRow item in data.Rows)
            {
                DryingDTO d = new DryingDTO(item);
                listD.Add(d);
            }
            return listD;
        }
        public DryingDTO GetItemDry(long Id)
        {
           return GetListDrying(Id).FirstOrDefault();
        }
        public long MaxIdDrying()
        {
            try
            {
                return long.Parse(DataProvider.Instance.ExecuteScalar("Select MAX(Id) FROM DryingMaterial").ToString());
            }
            catch 
            {
                return 0;
            }
        }
        public bool IsinsertDrying(string MaterialCode,string MachineDry,float QuantityDry,DateTime DateDrying,string Employess,string PartCode,string MachineCode,int StatusDry,string Note)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-CA");
            string query = string.Format("INSERT INTO [dbo].[DryingMaterial] ([MaterialCode],[MachineDry],[QuantityDry],[DateDrying],[Employess],[PartCode],[MachineCode],[StatusDry],[Note]) " +
                "VALUES (N'{0}',N'{1}',{2},'{3}',N'{4}',N'{5}',N'{6}',{7},N'{8}')", MaterialCode,MachineDry,QuantityDry,DateDrying,Employess,PartCode,MachineCode,StatusDry,Note);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateDrying(long Id,string MaterialCode, string MachineDry, float QuantityDry, DateTime DateDrying, string Employess, string PartCode, string MachineCode, string Note)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-CA");
            string query = string.Format("UPDATE [dbo].[DryingMaterial] SET [MaterialCode] = N'{1}',[MachineDry] = N'{2}',[QuantityDry] = {3},[DateDrying] = '{4}',[Employess] = N'{5}'," +
                "[PartCode] = N'{6}',[MachineCode] = N'{7}',[Note] = N'{8}' WHERE Id = {0}",Id, MaterialCode, MachineDry, QuantityDry, DateDrying, Employess, PartCode, MachineCode, Note);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateDrying(long Id,DateTime DatePour,int StatusDry)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-CA");
            string query = string.Format("UPDATE [dbo].[DryingMaterial] SET [DatePour] = '{1}', [StatusDry] = {2} WHERE Id = {0}", Id,DatePour,StatusDry);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteDrying(long Id)
        {
            string query = string.Format("DELETE [dbo].[DryingMaterial] WHERE Id = {0}",Id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
