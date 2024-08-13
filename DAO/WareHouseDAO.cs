using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
   public class WareHouseDAO
    {
        private static WareHouseDAO instance;

        public static WareHouseDAO Instance
        {
            get
            {
                if (instance == null) instance = new WareHouseDAO();
                return instance;
            }

            set
            {
                instance = value;
            }
        }
        public static int TableWidth = 34;
        public static int TableHeight = 34;

        public List<WareHouseDTO> GetListWareHouse(string Style)
        {
            List<WareHouseDTO> listW = new List<WareHouseDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.WareHouse WHERE Style = N'"+Style+"'");
            foreach (DataRow item in data.Rows)
            {
                WareHouseDTO w = new WareHouseDTO(item);
                listW.Add(w);
            }
            return listW;
        }
        public WareHouseDTO GetItem(int Id)
        {
            return GetListAllWareHouse().Find(x => x.Id == Id);
        }
        public List<WareHouseDTO> GetListAllWareHouse()
        {
            List<WareHouseDTO> listW = new List<WareHouseDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.WareHouse");
            foreach (DataRow item in data.Rows)
            {
                WareHouseDTO w = new WareHouseDTO(item);
                listW.Add(w);
            }
            return listW;
        }
        public List<WareHouseDTO> GetListWareHouseByStatus()
        {
            List<WareHouseDTO> listW = new List<WareHouseDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.WareHouse WHERE Status <> 5 AND Status >1");
            foreach (DataRow item in data.Rows)
            {
                WareHouseDTO w = new WareHouseDTO(item);
                listW.Add(w);
            }
            return listW;
        }
        public bool InsertWareHouse(string Name, int Status, int Height, string Style)
        {
            string query = string.Format("INSERT dbo.WareHouse ( Name, Status, Height, Style ) VALUES  ( N'{0}', {1}, {2}, N'{3}')", Name, Status, Height, Style);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateWareHouse(int Id, string Name, int Status, int Height, string Style)
        {
            string query = string.Format("UPDATE [dbo].[WareHouse] SET [Name] = N'{1}' ,[Status] = {2} ,[Height] = {3} ,[Style] = N'{4}' WHERE [Id] = {0}",Id,Name,Status,Height,Style);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteWareHouse(int Id)
        {
            string query = string.Format("DELETE dbo.WareHouse WHERE Id = {0}",Id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateStatusWH(int Id,int status)
        {
            string query = string.Format("UPDATE dbo.WareHouse SET Status = {1} WHERE Id = {0}", Id, status);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateYellowWH(int Id, string yellow)
        {
            string query = string.Format("UPDATE dbo.WareHouse SET Yellow = N'{1}' WHERE Id = {0}", Id, yellow);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateHeightWH(int Id, int height)
        {
            string query = string.Format("UPDATE dbo.WareHouse SET Height = {1} WHERE Id = {0}", Id, height);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public int IdWarehouse(string name)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Warehouse WHERE Name = N'"+name+"'");
            if(data.Rows.Count >0)
            {
                WareHouseDTO w = new WareHouseDTO(data.Rows[0]);
                return w.Id;
            }
            return -1;
        }
        public string NameWarehouse(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Warehouse WHERE ID = " + id);
            if (data.Rows.Count > 0)
            {
                WareHouseDTO w = new WareHouseDTO(data.Rows[0]);
                return w.Name;
            }
            return "";
        }

        public int IdWarehouseById(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Warehouse WHERE Id = "+id +" AND Status > 1");
            if (data.Rows.Count > 0)
            {
                return 1;
            }
            return -1;
        }
        public int StatusWarehouseById(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Warehouse WHERE Id = " + id );
            if (data.Rows.Count > 0)
            {
                WareHouseDTO w = new WareHouseDTO(data.Rows[0]);
                return w.Status;
            }
            return -1;
        }
        #region Load X,Y
        public List<WareHouseDTO> GetNameInput(int height)
        {
            List<WareHouseDTO> listW = new List<WareHouseDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.WareHouse WHERE Style <> N'x' AND Style <> N'y' AND Status = 1 AND Height >= " + height+" ORDER BY Height ASC");
            foreach (DataRow item in data.Rows)
            {
                WareHouseDTO w = new WareHouseDTO(item);
                listW.Add(w);
            }
            return listW;
        }
        public List<WareHouseDTO> GetNameInput2()
        {
            List<WareHouseDTO> listW = new List<WareHouseDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.WareHouse WHERE Status = 1 ORDER BY Height DESC");
            foreach (DataRow item in data.Rows)
            {
                WareHouseDTO w = new WareHouseDTO(item);
                listW.Add(w);
            }
            return listW;
        }
        public List<WareHouseDTO> GetlistWarehouseByStatus()
        {
            List<WareHouseDTO> listW = new List<WareHouseDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.WareHouse WHERE Status > 1 AND Status <> 5 AND Style <> N'x' AND Style <> N'y' AND Style <> N'K2'");
            foreach (DataRow item in data.Rows)
            {
                WareHouseDTO w = new WareHouseDTO(item);
                listW.Add(w);
            }
            return listW;
        }
        #endregion
        #region Load Layout Kho Thành Phẩm
        #endregion
        //Load trạng thái kho
        public List<StatusWarehouseDTO> StatusWarehouse()
        {
            List<StatusWarehouseDTO> listS = new List<StatusWarehouseDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.StatusWH WHERE Id = 2 OR Id = 3 OR Id = 4 OR Id = 9");
            foreach (DataRow item in data.Rows)
            {
                StatusWarehouseDTO s = new StatusWarehouseDTO(item);
                listS.Add(s);
            }
            return listS;
        }
        public List<StatusWarehouseDTO> StatusAppointment()
        {
            List<StatusWarehouseDTO> listS = new List<StatusWarehouseDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.StatusWH WHERE Id = 2 OR Id = 3");
            foreach (DataRow item in data.Rows)
            {
                StatusWarehouseDTO s = new StatusWarehouseDTO(item);
                listS.Add(s);
            }
            return listS;
        }
        public List<StatusWarehouseDTO> StatusWarehousePartLock()
        {
            List<StatusWarehouseDTO> listS = new List<StatusWarehouseDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.StatusWH WHERE Id = 3 OR Id = 4 OR Id = 9");
            foreach (DataRow item in data.Rows)
            {
                StatusWarehouseDTO s = new StatusWarehouseDTO(item);
                listS.Add(s);
            }
            return listS;
        }
        #region Khóa Vị Trí
        public object GetlistWHLock()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT WareHouse.Id,Name,Height,NameStatus FROM dbo.WareHouse,dbo.StatusWH WHERE StatusWH.Id = Status AND Style <> N'x' AND Style <> N'y' AND Style <> N'K2' AND(Status = 1 OR Status = 5)");
        }
        #endregion
        #region Tính vị trí
        public int TotalAll()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT COUNT(*) FROM dbo.WareHouse WHERE Style <> N'x' AND Style <> N'y' AND Style <> N'K2' AND Style <> N'H2' AND Height >1");
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
                return (int)DataProvider.Instance.ExecuteScalar("SELECT COUNT(*) FROM dbo.WareHouse WHERE Style <> N'x' AND Style <> N'y' AND Style <> N'K2' AND Style <> N'H2' AND Status = 1 AND Height >1");
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
                return (int)DataProvider.Instance.ExecuteScalar("SELECT COUNT(*) FROM dbo.WareHouse WHERE Style <> N'x' AND Style <> N'y' AND Style <> N'K2' AND Style <> N'H2' AND Status = 5 AND Height >1");
            }
            catch
            {
                return 0;
            }
        }
        public int TotalBlue()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT COUNT(*) FROM dbo.WareHouse WHERE Style <> N'x' AND Style <> N'y' AND Style <> N'K2' AND Style <> N'H2' AND Status = 2 ");
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
                return (int)DataProvider.Instance.ExecuteScalar("SELECT COUNT(*) FROM dbo.WareHouse WHERE Style <> N'x' AND Style <> N'y' AND Style <> N'K2' AND Style <> N'H2' AND Status = 3");
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
                return (int)DataProvider.Instance.ExecuteScalar("SELECT COUNT(*) FROM dbo.WareHouse WHERE Style <> N'x' AND Style <> N'y' AND Style <> N'K2' AND Style <> N'H2' AND Status = 6");
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
                return (int)DataProvider.Instance.ExecuteScalar("SELECT COUNT(*) FROM dbo.WareHouse WHERE Style <> N'x' AND Style <> N'y' AND Style <> N'K2' AND Style <> N'H2' AND Status = 7");
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
                return (int)DataProvider.Instance.ExecuteScalar("SELECT COUNT(*) FROM dbo.WareHouse WHERE Style <> N'x' AND Style <> N'y' AND Style <> N'K2' AND Style <> N'H2' AND Status = 8");
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
                return (int)DataProvider.Instance.ExecuteScalar("SELECT COUNT(*) FROM dbo.WareHouse WHERE Style <> N'x' AND Style <> N'y' AND Style <> N'K2' AND Style <> N'H2' AND Status = 4");
            }
            catch
            {
                return 0;
            }
        }
        public int TotalPurpel()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT COUNT(*) FROM dbo.WareHouse WHERE Style <> N'x' AND Style <> N'y' AND Style <> N'K2' AND Style <> N'H2' AND Status = 9");
            }
            catch
            {
                return 0;
            }
        }
        public int TotalDarkBlue()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT COUNT(*) FROM dbo.WareHouse WHERE Style <> N'x' AND Style <> N'y' AND Style <> N'K2' AND Style <> N'H2' AND Status = 10");
            }
            catch
            {
                return 0;
            }
        }
        #endregion
    }
}
