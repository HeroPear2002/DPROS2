using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
   public class MaterialInforDAO
    {
        private static MaterialInforDAO instance;

        public static MaterialInforDAO Instance
        {
            get
            {
                if (instance == null) instance = new MaterialInforDAO();
                return instance;
            }

            set
            {
                instance = value;
            }
        }
        public List<MaterialInforDTO> GetlistMaterial()
        {
            List<MaterialInforDTO> listM = new List<MaterialInforDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.MaterialInfor");
            foreach (DataRow item in data.Rows)
            {
                MaterialInforDTO m = new MaterialInforDTO(item);
                listM.Add(m);
            }
            return listM;
        }
        public List<MaterialInforDTO> GetlistMaterialByCode(string Code)
        {
            List<MaterialInforDTO> listM = new List<MaterialInforDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.MaterialInfor WHERE MaterialInfor = N'"+Code+"'");
            foreach (DataRow item in data.Rows)
            {
                MaterialInforDTO m = new MaterialInforDTO(item);
                listM.Add(m);
            }
            return listM;
        }
        public bool Insert(string MaterialInfor ,string MaterialCode , float Count)
        {
            string query = string.Format("INSERT dbo.MaterialInfor ( MaterialInfor , MaterialCode , Count ) VALUES  ( N'{0}' ,  N'{1}' , {2} )", MaterialInfor, MaterialCode, Count);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool Update(int Id,string MaterialInfor, string MaterialCode, float Count)
        {
            string query = string.Format("UPDATE dbo.MaterialInfor SET MaterialInfor = N'{1}',MaterialCode = N'{2}',Count = {3} WHERE Id = {0}",Id, MaterialInfor, MaterialCode, Count);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool Delete(int Id)
        {
            string query = string.Format("DELETE dbo.MaterialInfor WHERE Id = {0}",Id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public int testMaterialCode(string code,string material)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.MaterialInfor WHERE MaterialCode = N'" + code + "' AND MaterialInfor = N'" + material + "'");
            if(data.Rows.Count>0)
            {
                MaterialInforDTO m = new MaterialInforDTO(data.Rows[0]);
                return m.Id;
            }
            return -1;
        }
        #region Table Inventory Material
        public List<TableInventoryMaterial> GetTableInventoryMaterials()
        {
            List<TableInventoryMaterial> listTI = new List<TableInventoryMaterial>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT TableInventoryMaterial.MaterialCode,MaterialName,QuantityInventory,Note FROM TableInventoryMaterial,Material WHERE TableInventoryMaterial.MaterialCode = Material.MaterialCode");
            foreach (DataRow item in data.Rows)
            {
                TableInventoryMaterial t = new TableInventoryMaterial(item);
                listTI.Add(t);
            }
            return listTI;
        }
        public TableInventoryMaterial GetItemTableMaterial(string MaterialCode)
        {
            return GetTableInventoryMaterials().SingleOrDefault(x => x.MaterialCode == MaterialCode);
;       }
        public bool InsertTableMaterial(string MaterialCode,int QuantityInventory,string Note)
        {
            string query = string.Format("INSERT INTO [dbo].[TableInventoryMaterial] ([MaterialCode],[QuantityInventory],[Note]) VALUES (N'{0}',{1},N'{2}')",MaterialCode,QuantityInventory,Note);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateTableMaterial(string MaterialCode, int QuantityInventory, string Note)
        {
            string query = string.Format("UPDATE [dbo].[TableInventoryMaterial] SET [QuantityInventory] = {1},[Note] = N'{2}' WHERE [MaterialCode] = N'{0}'", MaterialCode, QuantityInventory, Note);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteTableMaterial(string MaterialCode)
        {
            string query = string.Format("DELETE [dbo].[TableInventoryMaterial] WHERE MaterialCode = N'{0}'", MaterialCode);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteTableMaterial()
        {
            string query = string.Format("DELETE [dbo].[TableInventoryMaterial]");
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        #endregion
    }
}
