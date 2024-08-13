using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class BoxDAO
    {
        private static BoxDAO instance;

        public static BoxDAO Instance
        {
            get
            {
                if (instance == null) instance = new BoxDAO();
                return instance;
            }

            set
            {
                instance = value;
            }
        }
        #region BOX
        public List<BoxListDTO> GetListBox()
        {
            List<BoxListDTO> listB = new List<BoxListDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.BoxList");
            foreach (DataRow item in data.Rows)
            {
                BoxListDTO b = new BoxListDTO(item);
                listB.Add(b);
            }
            return listB;
        }
        public bool InsertListBox(string BoxCode, string BoxName, string StyleBox, int BoxIventory)
        {
            string query = string.Format("INSERT dbo.BoxList ( BoxCode , BoxName , StyleBox , BoxIventory ) VALUES  ( N'{0}' ,  N'{1}' ,  N'{2}' , {3}  )", BoxCode, BoxName, StyleBox, BoxIventory);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateListBox(string BoxCode, string BoxName, string StyleBox, int BoxIventory)
        {
            string query = string.Format("UPDATE dbo.BoxList SET BoxName = N'{1}', StyleBox = N'{2}', BoxIventory = {3} WHERE BoxCode = N'{0}'", BoxCode, BoxName, StyleBox, BoxIventory);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteListBox(string BoxCode)
        {
            string query = string.Format("DELETE dbo.BoxList WHERE BoxCode = N'{0}'", BoxCode);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateIventoryListBox(string BoxCode, int BoxIventory)
        {
            string query = string.Format(" UPDATE dbo.BoxList SET BoxIventory = {1} WHERE BoxCode = N'{0}'", BoxCode, BoxIventory);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public int TestBoxList(string BoxCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.BoxList WHERE BoxCode = N'" + BoxCode + "'");
            if (data.Rows.Count > 0)
            {
                return 1;
            }
            return -1;
        }
        public int IventoryBoxList(string BoxCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.BoxList WHERE BoxCode = N'" + BoxCode + "'");
            if (data.Rows.Count > 0)
            {
                BoxListDTO b = new BoxListDTO(data.Rows[0]);
                return b.BoxIventory;
            }
            return 0;
        }
        #endregion
        #region Box Infor
        public object GetListBoxInfor()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.BoxInfor");
        }
        public bool InsertBoxInfor(string BoxCode, string PartCode)
        {
            string query = string.Format("INSERT dbo.BoxInfor ( BoxCode, PartCode ) VALUES  ( N'{0}', N'{1}')", BoxCode, PartCode);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateBoxInfor(int Id, string BoxCode, string PartCode)
        {
            string query = string.Format("UPDATE dbo.BoxInfor SET BoxCode = N'{1}' ,PartCode = N'{2}' WHERE Id = {0}", Id, BoxCode, PartCode);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteBoxInfor(int Id)
        {
            string query = string.Format("DELETE dbo.BoxInfor WHERE Id  = {0}", Id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public int IdBoxInfor(string BoxCode, string PartCode)
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT Id FROM dbo.BoxInfor WHERE BoxCode = N'" + BoxCode + "' AND PartCode = N'" + PartCode + "'");
            }
            catch
            {
                return -1;
            }
        }
        public string BoxCodeByPart(string PartCode)
        {
            try
            {
                return DataProvider.Instance.ExecuteScalar("SELECT DISTINCT(BoxCode) FROM dbo.BoxInfor WHERE PartCode = N'" + PartCode + "'").ToString();
            }
            catch
            {
                return null;
            }
        }
        #endregion
        #region ReBox
        public bool InsertReBox(string BoxCode, DateTime DateCheck)
        {
            string query = string.Format("INSERT dbo.ReBox ( BoxCode, DateCheck ) VALUES  ( N'{0}', '{1}')", BoxCode, DateCheck);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteReBox(DateTime DateCheck)
        {
            string query = string.Format("DELETE dbo.ReBox WHERE DateCheck <= '{0}'", DateCheck);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        #endregion
        #region Box Effic
        public object GetListBoxEffic()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT DateNew,BoxEffic.PartCode,BoxInfor.BoxCode,StyleBox,Quantity,CountBox,CountBoxTT,(CountBoxTT-CountBox) AS Iventory FROM dbo.BoxEffic,dbo.BoxList,dbo.BoxInfor WHERE BoxInfor.BoxCode = BoxList.BoxCode AND BoxEffic.PartCode = BoxInfor.PartCode");
        }
        public int TestBoxEffic(string DateNew, string PartCode)
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT Id FROM dbo.BoxEffic WHERE DateNew = N'"+DateNew+"' AND PartCode = N'"+PartCode+"'");
            }
            catch 
            {
                return -1;
            } 
        }
        public bool DeleteBoxEffic(int Id)
        {
               int result =  DataProvider.Instance.ExecuteNonQuery("DELETE dbo.BoxEffic WHERE Id ="+Id);
                return result > 0;
      
        }
        public bool InsertBoxEffic(string DateNew, string PartCode, int Quantity, int CountBox, int CountBoxTT)
    {
        string query = string.Format("INSERT dbo.BoxEffic ( DateNew , PartCode , Quantity , CountBox , CountBoxTT ) VALUES  ( N'{0}' , N'{1}' , {2} , {3} , {4} )", DateNew, PartCode, Quantity, CountBox, CountBoxTT);
        int result = DataProvider.Instance.ExecuteNonQuery(query);
        return result > 0;
    }
    public bool UpdateBoxEffic(int Id, string DateNew, string PartCode, int Quantity, int CountBox, int CountBoxTT)
    {
        string query = string.Format("UPDATE [dbo].[BoxEffic] SET [DateNew] = N'{1}',[PartCode] = N'{2}',[Quantity] = {3},[CountBox] = {4},[CountBoxTT] = {5} WHERE Id = {0}", Id, DateNew, PartCode, Quantity, CountBox, CountBoxTT);
        int result = DataProvider.Instance.ExecuteNonQuery(query);
        return result > 0;
    }
        #endregion
        #region Box Total
        public int ToTalBoxByCode(string BoxCode,DateTime Date1,DateTime Date2)
        {
            try
            {
                string query = string.Format("SELECT COUNT(*) FROM dbo.ReBox WHERE DateCheck >= '{1}' AND DateCheck <='{2}' AND BoxCode = N'{0}'",BoxCode,Date1,Date2);
                return (int)DataProvider.Instance.ExecuteScalar(query);
            }
            catch
            {

                return 0;
            }
        }
        public int ToTalBox( DateTime Date1, DateTime Date2)
        {
            try
            {
                string query = string.Format("SELECT COUNT(*) FROM dbo.ReBox WHERE DateCheck >= '{0}' AND DateCheck <='{1}'", Date1, Date2);
                return (int)DataProvider.Instance.ExecuteScalar(query);
            }
            catch
            {

                return 0;
            }
        }
        #endregion
    }
}
