using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
   public class WarehouseMaterialDAO
    {
        private static WarehouseMaterialDAO instance;

        public static WarehouseMaterialDAO Instance
        {
            get
            {
                if (instance == null) instance = new WarehouseMaterialDAO();
                return instance;
            }

            set
            {
                instance = value;
            }
        }
        public static int TableWidth = 32;
        public static int TableHeight = 32;
        public List<WarehouseMaterial> GetListAllWareHouse()
        {
            List<WarehouseMaterial> listW = new List<WarehouseMaterial>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.WarehouseMaterial");
            foreach (DataRow item in data.Rows)
            {
                WarehouseMaterial w = new WarehouseMaterial(item);
                listW.Add(w);
            }
            return listW;
        }
        public List<WarehouseMaterial> GetListWareHouse(string Style)
        {
            List<WarehouseMaterial> listW = new List<WarehouseMaterial>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.WarehouseMaterial WHERE Style = N'" + Style + "'");
            foreach (DataRow item in data.Rows)
            {
                WarehouseMaterial w = new WarehouseMaterial(item);
                listW.Add(w);
            }
            return listW;
        }
        public List<WarehouseMaterial> GetListWareHouse()
        {
            List<WarehouseMaterial> listW = new List<WarehouseMaterial>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.WarehouseMaterial");
            foreach (DataRow item in data.Rows)
            {
                WarehouseMaterial w = new WarehouseMaterial(item);
                listW.Add(w);
            }
            return listW;
        }
        public bool InsertWareHouse(string Name, int Status, string Style, int Weight)
        {
            string query = string.Format("INSERT dbo.WarehouseMaterial ( Name, StatusWH, Style , WeightWH) VALUES  ( N'{0}', {1}, N'{2}',{3})", Name, Status, Style, Weight);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateWareHouse(int Id, string Name, int Status, string Style, int Weight)
        {
            string query = string.Format("UPDATE [dbo].[WarehouseMaterial] SET [Name] = N'{1}' ,[StatusWH] = {2} ,[Style] = N'{3}' ,[WeightWH] = {4} WHERE [Id] = {0}", Id, Name, Status, Style, Weight);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteWareHouse(int Id)
        {
            string query = string.Format("DELETE dbo.WarehouseMaterial WHERE Id = {0}", Id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateStatus(int Id, int status)
        {
            string query = string.Format("UPDATE dbo.WarehouseMaterial SET StatusWH = {1} WHERE Id = {0}",Id,status);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateWeigth(int Id, int WeightWH)
        {
            string query = string.Format("UPDATE dbo.WarehouseMaterial SET WeightWH = {1} WHERE Id = {0}", Id, WeightWH);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateStyle(int Id, string Style)
        {
            string query = string.Format("UPDATE dbo.WarehouseMaterial SET Style = N'{1}' WHERE Id = {0}", Id, Style);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public List<WarehouseMaterial> GetNameInput(int WeightWH)
        {
            List<WarehouseMaterial> listW = new List<WarehouseMaterial>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.WarehouseMaterial WHERE Style = N'A' AND StatusWH = 1 AND WeightWH > " + (WeightWH-1));
            foreach (DataRow item in data.Rows)
            {
                WarehouseMaterial w = new WarehouseMaterial(item);
                listW.Add(w);
            }
            return listW;
        }
        public List<WarehouseMaterial> GetNameInput(int WeightWH,string Style)
        {
            List<WarehouseMaterial> listW = new List<WarehouseMaterial>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.WarehouseMaterial WHERE Style = N'"+Style+"' AND StatusWH = 1 AND WeightWH <= " +WeightWH);
            foreach (DataRow item in data.Rows)
            {
                WarehouseMaterial w = new WarehouseMaterial(item);
                listW.Add(w);
            }
            return listW;
        }
        public List<WarehouseMaterial> GetNameInput()
        {
            List<WarehouseMaterial> listW = new List<WarehouseMaterial>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.WarehouseMaterial WHERE Style = N'A' AND StatusWH = 1 ");
            foreach (DataRow item in data.Rows)
            {
                WarehouseMaterial w = new WarehouseMaterial(item);
                listW.Add(w);
            }
            return listW;
        }
        public List<WarehouseMaterial> GetNameInputTryTest()
        {
            List<WarehouseMaterial> listW = new List<WarehouseMaterial>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.WarehouseMaterial WHERE Style = N'I' AND StatusWH = 1");
            foreach (DataRow item in data.Rows)
            {
                WarehouseMaterial w = new WarehouseMaterial(item);
                listW.Add(w);
            }
            return listW;
        }
        public int IdWarehouseMaterial(string name)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.WarehouseMaterial WHERE Name = N'"+name+"'");
            if(data.Rows.Count >0)
            {
                WarehouseMaterial w = new WarehouseMaterial(data.Rows[0]);
                return w.Id;
            }
            return -1;
        }
        public int WeightWarehouseMaterial(int Id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.WarehouseMaterial WHERE Id = " + Id);
            if (data.Rows.Count > 0)
            {
                WarehouseMaterial w = new WarehouseMaterial(data.Rows[0]);
                return w.WeightWH;
            }
            return 0;
        }
        public int StatusWH(long Id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.WarehouseMaterial WHERE Id = " + Id);
            if (data.Rows.Count > 0)
            {
                WarehouseMaterial w = new WarehouseMaterial(data.Rows[0]);
                return w.StatusWH;
            }
            return 1;
        }
        public string NameWH(int Id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.WarehouseMaterial WHERE Id = " + Id);
            if (data.Rows.Count > 0)
            {
                WarehouseMaterial w = new WarehouseMaterial(data.Rows[0]);
                return w.Name;
            }
            return "";
        }
        #region đếm trạng thái của kho
        public int TotalAll()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT COUNT(*) FROM dbo.WarehouseMaterial WHERE Style = N'A' AND StatusWH <> 9");
            }
            catch
            {
                return 0;
            }
        }
        public int TotalWhite()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT COUNT(*) FROM dbo.WarehouseMaterial WHERE Style = N'A' AND StatusWH = 1");
            }
            catch 
            {
                return 0;
            }
        }
        public int TotalOK()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT COUNT(*) FROM dbo.WarehouseMaterial WHERE Style = N'A' AND StatusWH = 2");
            }
            catch
            {
                return 0;
            }
        }
        public int TotalYellow()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT COUNT(*) FROM dbo.WarehouseMaterial WHERE Style = N'A' AND StatusWH = 4");
            }
            catch
            {
                return 0;
            }
        }
        public int TotalRed()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT COUNT(*) FROM dbo.WarehouseMaterial WHERE Style = N'A' AND StatusWH = 3");
            }
            catch
            {
                return 0;
            }
        }
        public int TotalGreen()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT COUNT(*) FROM dbo.WarehouseMaterial WHERE Style = N'A' AND StatusWH = 5");
            }
            catch
            {
                return 0;
            }
        }
        public int TotalBlack()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT COUNT(*) FROM dbo.WarehouseMaterial WHERE Style = N'A' AND StatusWH = 6");
            }
            catch
            {
                return 0;
            }
        }
        public int TotalPink()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT COUNT(*) FROM dbo.WarehouseMaterial WHERE Style = N'A' AND StatusWH = 7");
            }
            catch
            {
                return 0;
            }
        }
        public int TotalPurple()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT COUNT(*) FROM dbo.WarehouseMaterial WHERE Style = N'A' AND StatusWH = 8");
            }
            catch
            {
                return 0;
            }
        }
        public int TotalOrange()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT COUNT(*) FROM dbo.WarehouseMaterial WHERE Style = N'A' AND StatusWH = 10");
            }
            catch
            {
                return 0;
            }
        }
        #endregion
        #region Drying Material
        public object GetlistDrying()
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT Id,PartCode,MachineCode,DryingMaterial.MaterialCode,MaterialName,DateDrying,StatusMachine,Temperature,CountT,LotT,CountC,LotC,CountH,LotH,Employess,Note , (CountT+CountC+CountH) AS Total FROM dbo.DryingMaterial ,dbo.Material WHERE DryingMaterial.MaterialCode = Material.MaterialCode");
        }
        public bool DeleteDrying(long Id)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("DELETE dbo.DryingMaterial WHERE Id = " + Id);
            return result > 0;
        }
        public bool UpdateDryingMaterial(long Id, string PartCode, string MachineCode, string MaterialCode, DateTime DateDrying, string StatusMachine, float Temperature, int CountT, string LotT, int CountC, string LotC, int CountH, string LotH, string Employess, string Note)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("EXEC dbo.USP_UpdateDrying @Id , @PartCode , @MachineCode , @MaterialCode , @DateDrying , @StatusMachine , @Temperature , @CountT , @LotT , @CountC , @LotC , @CountH , @LotH , @Employess , @Note ", new object[] { Id, PartCode, MachineCode, MaterialCode, DateDrying, StatusMachine, Temperature, CountT, LotT, CountC, LotC, CountH, LotH, Employess, Note });
            return result > 0;
        }
        #endregion
    }
}
