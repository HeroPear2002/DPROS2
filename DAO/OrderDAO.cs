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
   public class OrderDAO
    {
        private static OrderDAO instance;

        public static OrderDAO Instance
        {
            get
            {
                if (instance == null) instance = new OrderDAO();
                return instance;
            }

            set
            {
                instance = value;
            }
        }
        #region Order List
        public List<OrderListDTO> GetListOrderList()
        {
            List<OrderListDTO> listO = new List<OrderListDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.OrderList ORDER BY DateOrder DESC");
            foreach (DataRow item in data.Rows)
            {
                OrderListDTO o = new OrderListDTO(item);
                listO.Add(o);
            }
            return listO;
        }
        public List<OrderListDTO> GetListOrderListTop()
        {
            List<OrderListDTO> listO = new List<OrderListDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT TOP(20)* FROM dbo.OrderList ORDER BY DateOrder DESC");
            foreach (DataRow item in data.Rows)
            {
                OrderListDTO o = new OrderListDTO(item);
                listO.Add(o);
            }
            return listO;
        }
        public bool InsertOrderList(string OrderCode ,DateTime DateOrder ,string Employess ,string Room ,string DVT ,string NumberHQ ,string Bill )
        {
            int result = DataProvider.Instance.ExecuteNonQuery("EXEC dbo.USP_InsertOrderList @OrderCode , @DateOrder , @Employess , @Room , @DVT , @NumberHQ , @Bill ",new object[] { OrderCode, DateOrder, Employess, Room, DVT, NumberHQ, Bill });
            return result > 0;
        }
        public bool UpdateOrderList(string OrderCode, DateTime DateOrder, string Employess, string Room, string DVT, string NumberHQ, string Bill)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("EXEC dbo.USP_UpdateOrderList @OrderCode , @DateOrder , @Employess , @Room , @DVT , @NumberHQ , @Bill ", new object[] { OrderCode, DateOrder, Employess, Room, DVT, NumberHQ, Bill });
            return result > 0;
        }
        public bool DeleteOrderList(string OrderCode)
        {
            string query = string.Format("DELETE dbo.OrderList WHERE OrderCode = N'{0}'",OrderCode);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public int TestOrderlist(string OrderCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.OrderList WHERE OrderCode = N'"+ OrderCode + "'");
            if(data.Rows.Count>0)
            {
                return 1;
            }
            return -1;
        }
        public List<DistinctOrderDTO> DistinctOrderCode()
        {
            List<DistinctOrderDTO> listD = new List<DistinctOrderDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT OrderCode FROM dbo.OrderList ORDER BY DateOrder DESC");
            foreach (DataRow item in data.Rows)
            {
                DistinctOrderDTO d = new DistinctOrderDTO(item);
                listD.Add(d);
            }
            return listD;
        }
        public int CountOrderCode(DateTime date1,DateTime date2,string vendor)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT DISTINCT(OrderCode) FROM dbo.OrderInfor WHERE DateTT >='"+date1+"' AND DateTT <='"+date2+ "' AND VendorCode = N'"+vendor+"'");
            return data.Rows.Count;
        }
        #endregion
        #region Order Infor
        public object GetListOrderInfor()
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT Id,OrderInfor.OrderCode,OrderInfor.MaterialCode,MaterialName AS MaterialName,CountBy,Price,(CountBy * Price) AS Money ,DateDK,DateTT,NumberHQ,Bill FROM dbo.OrderInfor,dbo.OrderList, dbo.Material WHERE OrderInfor.OrderCode = OrderList.OrderCode AND Material.MaterialCode = OrderInfor.MaterialCode ORDER BY DateTT,DateDK");
        }
        public List<OrderInfor> GetListOrderInforByDate()
        {
            List<OrderInfor> listO = new List<OrderInfor>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT Id,OrderInfor.OrderCode,OrderInfor.MaterialCode,MaterialName,CountBy,Price,DateDK,VendorCode,StatusOrder FROM dbo.OrderInfor,dbo.OrderList, dbo.Material WHERE OrderInfor.OrderCode = OrderList.OrderCode AND Material.MaterialCode = OrderInfor.MaterialCode  AND StatusOrder = 1 ORDER BY DateDK");
            foreach (DataRow item in data.Rows)
            {
                OrderInfor o = new OrderInfor(item);
                listO.Add(o);
            }
            return listO;
        }
        public int TestOrderEverybody(DateTime date1, DateTime date2)
        {
           DataTable data = DataProvider.Instance.ExecuteQuery("SELECT Id,OrderInfor.OrderCode,OrderInfor.MaterialCode,MaterialName AS MaterialName,CountBy,Price,(CountBy * Price) AS Money ,DateDK,DateTT,NumberHQ,Bill FROM dbo.OrderInfor,dbo.OrderList, dbo.Material WHERE OrderInfor.OrderCode = OrderList.OrderCode AND Material.MaterialCode = OrderInfor.MaterialCode  AND StatusOrder = 1 AND DateDK >='" + date1 + "' AND DateDK <='" + date2 + "' ORDER BY DateTT,DateDK");
            if (data.Rows.Count > 0)
            {
                return 1;
            }
            else return -1;
        }
        public object GetListOrderInforByCode(string code)
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT Id,OrderInfor.OrderCode,OrderInfor.MaterialCode,MaterialName AS MaterialName,CountBy,Price,(CountBy * Price) AS Money ,DateDK,DateTT,NumberHQ,Bill FROM dbo.OrderInfor,dbo.OrderList, dbo.Material WHERE OrderInfor.OrderCode = OrderList.OrderCode AND Material.MaterialCode = OrderInfor.MaterialCode AND OrderInfor.OrderCode = N'"+code+"'");
        }
        public bool InsertOrderInfor(string OrderCode ,string MaterialCode ,int CountBy ,decimal Price ,DateTime DateDK ,string VendorCode,DateTime DateTT)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("EXEC dbo.USP_InsertOrderInfor @OrderCode , @MaterialCode , @CountBy , @Price , @DateDK , @VendorCode , @DateTT", new object[] { OrderCode,  MaterialCode,  CountBy,  Price,  DateDK , VendorCode , DateTT });
            return result > 0;
        }
        public bool UpdateOrderInfor(long Id ,string OrderCode, string MaterialCode, int CountBy, decimal Price, DateTime DateDK)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("EXEC dbo.USP_UpdateOrderInfor @Id , @OrderCode , @MaterialCode , @CountBy , @Price , @DateDK  ", new object[] {Id, OrderCode, MaterialCode, CountBy, Price, DateDK });
            return result > 0;
        }
        public bool DeleteOrderInforById(long Id)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("DELETE dbo.OrderInfor WHERE Id = " + Id);
            return result > 0;
        }
        public bool UpdateStatusMail(long Id,int mail)
        {
            string query = string.Format("UPDATE dbo.OrderInfor SET StatusMail = {1} WHERE Id = {0}", Id,mail);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateVendoerCode(string Order , string  vendor)
        {
            string query = string.Format("UPDATE dbo.OrderInfor SET VendorCode = N'{1}' WHERE OrderCode = N'{0}'", Order, vendor);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateStatusOrderInfor(string OrderCode,int status )
        {
            string query = string.Format("UPDATE dbo.OrderInfor SET StatusOrder = {1} WHERE OrderCode = N'{0}'",OrderCode,status);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteOrderInfor(string OrderCode)
        {
            string query = string.Format("DELETE dbo.OrderInfor WHERE OrderCode = N'" + OrderCode+"'");
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }       
        public int TestOrderInfor(string OrderCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.OrderInfor WHERE OrderCode = N'" + OrderCode + "'");
            if (data.Rows.Count > 0)
            {
                return 1;
            }
            return -1;
        }
        public DateTime? MinDateDK(string Order)
        {
            try
            {
                return DateTime.Parse(DataProvider.Instance.ExecuteScalar("SELECT MIN(DateDK) FROM dbo.OrderInfor,dbo.OrderList, dbo.Material WHERE OrderInfor.OrderCode = OrderList.OrderCode AND Material.MaterialCode = OrderInfor.MaterialCode AND OrderInfor.OrderCode = N'" + Order + "'").ToString());
            }
            catch 
            {
              return null;
            }
        }
        public DateTime? MaxDateDK(string Order)
        {
            try
            {
                return DateTime.Parse(DataProvider.Instance.ExecuteScalar("SELECT MAX(DateDK) FROM dbo.OrderInfor,dbo.OrderList, dbo.Material WHERE OrderInfor.OrderCode = OrderList.OrderCode AND Material.MaterialCode = OrderInfor.MaterialCode AND OrderInfor.OrderCode = N'" + Order + "'").ToString());
            }
            catch
            {
                return null;
            }

        }
        public string NumberHQ(string Order)
        {
            try
            {
                return DataProvider.Instance.ExecuteScalar("SELECT NumberHQ FROM dbo.OrderInfor,dbo.OrderList, dbo.Material WHERE OrderInfor.OrderCode = OrderList.OrderCode AND Material.MaterialCode = OrderInfor.MaterialCode AND OrderInfor.OrderCode = N'" + Order + "'").ToString();
            }
            catch
            {
                return "";
            }
        }
        public string VendorCode(string Order)
        {
            try
            {
                return DataProvider.Instance.ExecuteScalar("SELECT DISTINCT(VendorCode) FROM dbo.OrderInfor WHERE OrderCode = N'" + Order + "'").ToString();
            }
            catch
            {
                return null;
            }
        }
        public string Bill(string Order)
        {
            try
            {
                return DataProvider.Instance.ExecuteScalar("SELECT Bill FROM dbo.OrderInfor,dbo.OrderList, dbo.Material WHERE OrderInfor.OrderCode = OrderList.OrderCode AND Material.MaterialCode = OrderInfor.MaterialCode AND OrderInfor.OrderCode = N'" + Order + "'").ToString();
            }
            catch
            {
                return "";
            }
        }
        public bool CheckOrderInfor(string code, DateTime DateTT)
        {
            string query = string.Format("UPDATE dbo.OrderInfor SET DateTT = '{1}' WHERE OrderCode = N'{0}'", code, DateTT);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateStatusOrder(long id)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("UPDATE dbo.OrderInfor SET StatusOrder = 2 WHERE Id = " + id);
            return result > 0;
        }
        public int StatusMail(long Id)
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT StatusMail FROM dbo.OrderInfor WHERE Id = " + Id);
            }
            catch 
            {
                return 0;
            }
        }
        public int StatusOrder(long Id)
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT StatusOrder FROM dbo.OrderInfor WHERE Id = " +Id);
            }
            catch 
            {
                return 0;
            }
        }
        public DateTime DateInsert(string OrderCode)
        {
            try
            {
                return DateTime.Parse(DataProvider.Instance.ExecuteScalar("SELECT DateOrder FROM dbo.OrderList WHERE OrderCode = N'" + OrderCode + "'").ToString());
            }
            catch 
            {
                return DateTime.Now;
            }
        }
        #endregion
        public object HistoryOrder()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT DateOrder,Employess,OrderInfor.OrderCode,Material.VenderCode, MaterialName,DVT,Room,CountBy,Price,(CountBy * Price) AS Money ,DateDK,DateTT,NumberHQ,Bill FROM dbo.OrderInfor,dbo.OrderList, dbo.Material,dbo.Vender WHERE OrderInfor.OrderCode = OrderList.OrderCode AND OrderInfor.MaterialCode = Material.MaterialCode  AND Material.VenderCode = Vender.VenderCode");
        }
        #region Order Check
        public object OrderCheck()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT OrderCheck.Id,OrderCode,OrderInfor.MaterialCode,MaterialName,QuantityTT,DateCheck,Check1,Check2,Check3,Check4,Check5,Lot,Employess,Note FROM dbo.OrderCheck,dbo.OrderInfor,dbo.Material WHERE OrderInfor.Id = IdOrderInfor AND Material.MaterialCode = OrderInfor.MaterialCode");
        }
        public bool DeleteOrderCheck(long id)
        {
            string querry = string.Format("DELETE dbo.OrderCheck WHERE Id = {0}", id);
            int result = DataProvider.Instance.ExecuteNonQuery(querry);
            return result > 0;
        }
        public int QuantityTTOrder(long IdOrder)
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT SUM(QuantityTT) FROM dbo.OrderCheck WHERE IdOrderInfor = "+IdOrder);
            }
            catch 
            {

                return 0;
            }
        }
        #endregion
        #region FC MATERIAL
        public List<FCMaterialDTO> GetFCMaterialDTOs()
        {
            List<FCMaterialDTO> listF = new List<FCMaterialDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT Id,FCMaterial.MaterialCode,MaterialName,Quantity,DateFC FROM FCMaterial,Material WHERE FCMaterial.MaterialCode = Material.MaterialCode");
            foreach (DataRow item in data.Rows)
            {
                FCMaterialDTO f = new FCMaterialDTO(item);
                listF.Add(f);
            }
            return listF;
        }
        public List<MaterialCodeDTO> GetOnLyMaterialDTOs(DateTime date1,DateTime date2)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            List<MaterialCodeDTO> listF = new List<MaterialCodeDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT DISTINCT(FCMaterial.MaterialCode),MaterialName FROM FCMaterial,Material WHERE FCMaterial.MaterialCode = Material.MaterialCode AND DateFC >= '" + date1+"' AND DateFC <= '"+date2+"'");
            foreach (DataRow item in data.Rows)
            {
                MaterialCodeDTO f = new MaterialCodeDTO(item);
                listF.Add(f);
            }
            return listF;
        }
        public FCMaterialDTO GetItemFcMaterial(long Id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT Id,FCMaterial.MaterialCode,MaterialName,Quantity,DateFC FROM FCMaterial,Material WHERE FCMaterial.MaterialCode = Material.MaterialCode AND Id = "+Id);
            if(data.Rows.Count > 0)
            {
                FCMaterialDTO f = new FCMaterialDTO(data.Rows[0]);
                return f;
            }
            return null;
        }
        public FCMaterialDTO GetItemFcMaterial(string MaterialCode, DateTime DateFC)
        {
            try
            {
                return GetFCMaterialDTOs().FirstOrDefault(x => x.MaterialCode == MaterialCode && x.DateFC == DateFC);
            }
            catch 
            {
                return null;
            }
        }
        public bool InsertFCMaterial(string MaterialCode,int Quantity,DateTime DateFC)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format("INSERT INTO [dbo].[FCMaterial] ([MaterialCode],[Quantity],[DateFC]) VALUES (N'{0}',{1},'{2}')",MaterialCode,Quantity,DateFC);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateFCMaterial(long Id,string MaterialCode, int Quantity, DateTime DateFC)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format("UPDATE [dbo].[FCMaterial] SET [MaterialCode] = N'{1}',[Quantity] = {2},[DateFC] = '{3}' WHERE Id = {0}",Id, MaterialCode, Quantity, DateFC);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteFCMaterial(long Id)
        {
            string query = string.Format("DELETE [dbo].[FCMaterial] WHERE Id = {0}", Id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        #endregion
        #region FCPART
        public List<FCPartDTO> GetFCPartDTOs()
        {
            List<FCPartDTO> listP = new List<FCPartDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM FCPart");
            foreach (DataRow item in data.Rows)
            {
                FCPartDTO f = new FCPartDTO(item);
                listP.Add(f);
            }
            return listP;
        }
        public FCPartDTO GetItemFCPart(long id)
        {
            return GetFCPartDTOs().SingleOrDefault(x => x.Id == id);
        }
        public FCPartDTO GetItemFCPart(string PartCode,DateTime Date)
        {
            return GetFCPartDTOs().FirstOrDefault(x => x.PartCode == PartCode && x.DateFCPart == Date);
        }
        public bool InsertFCPart(string PartCode, int Quantity, DateTime DateFCPart, string Employess)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format("INSERT INTO [dbo].[FCPart] ([PartCode],[Quantity],[DateFCPart],[Employess]) VALUES (N'{0}',{1},'{2}',N'{3}')",PartCode,Quantity,DateFCPart,Employess);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateFCPart(long Id, string PartCode, int Quantity, DateTime DateFCPart, string Employess)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format("UPDATE [dbo].[FCPart] SET [PartCode] = N'{1}',[Quantity] = {2},[DateFCPart] = '{3}',[Employess] = N'{4}' WHERE Id = {0}",Id, PartCode, Quantity, DateFCPart, Employess);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool InsertFCPart(long Id)
        {
            string query = string.Format("DELETE  [dbo].[FCPart] WHERE Id = {0})", Id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        #endregion
    }
}
