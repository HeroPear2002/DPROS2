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
    public class IventoryMaterialDAO
    {
        private static IventoryMaterialDAO instance;

        public static IventoryMaterialDAO Instance
        {
            get
            {
                if (instance == null) instance = new IventoryMaterialDAO();
                return instance;
            }

            set
            {
                instance = value;
            }
        }
        #region Input Material
        public bool InsertInputMaterial(string MaterialCode, DateTime DateInput, float QuantityInput, int IdWH, int StatusInput, string StyleInput, string Employess, string Rohs)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("EXEC dbo.USP_InsertMaterial @MaterialCode , @DateInput , @QuantityInput , @IdWH , @StatusInput , @StyleInput , @Employess , @Rosh ", new object[] { MaterialCode, DateInput, QuantityInput, IdWH, StatusInput, StyleInput, Employess, Rohs });
            return result > 0;
        }
        public bool IsertHistory(string MaterialCode, DateTime DateInput, float QuantityInput, string StyleInput, string Employess, string NameWh)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("EXEC dbo.USP_HistoryInputMaterial @MaterialCode , @DateInput , @QuantityInput , @StyleInput , @Employess , @NameWh ", new object[] { MaterialCode, DateInput, QuantityInput, StyleInput, Employess, NameWh });
            return result > 0;
        }
        public bool UpdateQuantityInput(long Id, float Quantity)
        {
            string query = string.Format("UPDATE dbo.InputMaterial SET QuantityInput = {1} WHERE Id = {0}", Id, Quantity);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateLot(long Id, string lot)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("UPDATE dbo.InputMaterial SET Lot = N'" + lot + "' WHERE Id = " + Id);
            return result > 0;
        }
        public bool UpdateRosh(string materialCode, string rosh)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("UPDATE dbo.InputMaterial SET Rosh = N'" + rosh + "' WHERE MaterialCode = N'" + materialCode + "'");
            return result > 0;
        }
        public bool UpdateStatust(long id, int status)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("UPDATE dbo.InputMaterial SET StatusInput = " + status + " WHERE Id = " + id);
            return result > 0;
        }
        #endregion
        #region Output Material
        public bool OutPutMaterial(long IdInput, DateTime DateOutput, float Quantity, string Employees, string StyleOutput, string PartCode, string MachineCode, string Lot)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("EXEC dbo.USP_OutputMaterial @IdInput ,  @DateOutput , @Quantity , @Employees , @StyleOutput , @PartCode , @MachineCode , @Lot", new object[] { IdInput, DateOutput, Quantity, Employees, StyleOutput, PartCode, MachineCode, Lot });
            return result > 0;
        }
        #endregion
        #region Tông kho Nguyên Liệu
        public IventoryMaterialDTO GetItem(long Id)
        {
            return GetListIventory().SingleOrDefault(x => x.Id == Id);
        }
        public List<IventoryMaterialDTO> GetListIventory()
        {
            List<IventoryMaterialDTO> listI = new List<IventoryMaterialDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT InputMaterial.Id, InputMaterial.MaterialCode,MaterialName,DateInput,ISNULL(SUM(QuantityOutput),0) AS CountXuat,(QuantityInput - ISNULL(SUM(QuantityOutput),0)) AS QuantityInput,StyleInput,IdWH,Name,Rosh,InputMaterial.Lot FROM dbo.InputMaterial LEFT JOIN dbo.OutputMaterial ON InputMaterial.Id = IdInput LEFT JOIN dbo.WarehouseMaterial ON IdWH = WarehouseMaterial.Id LEFT JOIN dbo.Material ON InputMaterial.MaterialCode = Material.MaterialCode  WHERE  StatusInput = 0 GROUP BY  InputMaterial.Id, InputMaterial.MaterialCode,MaterialName, DateInput, QuantityInput, StyleInput, IdWH, Name, Rosh, InputMaterial.Lot");
            foreach (DataRow item in data.Rows)
            {
                IventoryMaterialDTO i = new IventoryMaterialDTO(item);
                listI.Add(i);
            }
            return listI;
        }

        public List<IventoryMaterialDTO> GetListIventoryStyle()
        {
            List<IventoryMaterialDTO> listI = new List<IventoryMaterialDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT InputMaterial.Id, InputMaterial.MaterialCode,MaterialName,DateInput,ISNULL(SUM(QuantityOutput),0) AS CountXuat,(QuantityInput - ISNULL(SUM(QuantityOutput),0)) AS QuantityInput,StyleInput,IdWH,Name,Rosh,InputMaterial.Lot FROM dbo.InputMaterial LEFT JOIN dbo.OutputMaterial ON InputMaterial.Id = IdInput LEFT JOIN dbo.WarehouseMaterial ON IdWH = WarehouseMaterial.Id LEFT JOIN dbo.Material ON InputMaterial.MaterialCode = Material.MaterialCode  WHERE  StatusInput = 0 AND (StyleInput = N'TC' OR StyleInput = N'HH') GROUP BY  InputMaterial.Id, InputMaterial.MaterialCode,MaterialName, DateInput, QuantityInput, StyleInput, IdWH, Name, Rosh, InputMaterial.Lot");
            foreach (DataRow item in data.Rows)
            {
                IventoryMaterialDTO i = new IventoryMaterialDTO(item);
                listI.Add(i);
            }
            return listI;
        }
        public List<IventoryMaterialDTO> GetListIventoryStart1()
        {
            List<IventoryMaterialDTO> listI = new List<IventoryMaterialDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT InputMaterial.Id, InputMaterial.MaterialCode,MaterialName,DateInput,ISNULL(SUM(QuantityOutput),0) AS CountXuat,(QuantityInput - ISNULL(SUM(QuantityOutput),0)) AS QuantityInput,StyleInput,IdWH,Name,Rosh,InputMaterial.Lot FROM dbo.InputMaterial LEFT JOIN dbo.OutputMaterial ON InputMaterial.Id = IdInput LEFT JOIN dbo.WarehouseMaterial ON IdWH = WarehouseMaterial.Id LEFT JOIN dbo.Material ON InputMaterial.MaterialCode = Material.MaterialCode  WHERE  StatusInput = 1 GROUP BY  InputMaterial.Id, InputMaterial.MaterialCode,MaterialName, DateInput, QuantityInput, StyleInput, IdWH, Name, Rosh, InputMaterial.Lot");
            foreach (DataRow item in data.Rows)
            {
                IventoryMaterialDTO i = new IventoryMaterialDTO(item);
                listI.Add(i);
            }
            return listI;
        }
        public List<IventoryMaterialDTO> GetListIventoryStart1ByIdinput()
        {
            List<IventoryMaterialDTO> listI = new List<IventoryMaterialDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT InputMaterial.Id, InputMaterial.MaterialCode,MaterialName,DateInput,ISNULL(SUM(QuantityOutput),0) AS CountXuat,(QuantityInput - ISNULL(SUM(QuantityOutput),0)) AS QuantityInput,StyleInput,IdWH,Name,Rosh,InputMaterial.Lot FROM dbo.InputMaterial LEFT JOIN dbo.OutputMaterial ON InputMaterial.Id = IdInput LEFT JOIN dbo.WarehouseMaterial ON IdWH = WarehouseMaterial.Id LEFT JOIN dbo.Material ON InputMaterial.MaterialCode = Material.MaterialCode  WHERE  StatusInput = 1 GROUP BY  InputMaterial.Id, InputMaterial.MaterialCode,MaterialName, DateInput, QuantityInput, StyleInput, IdWH, Name, Rosh, InputMaterial.Lot");
            foreach (DataRow item in data.Rows)
            {
                IventoryMaterialDTO i = new IventoryMaterialDTO(item);
                listI.Add(i);
            }
            return listI;
        }
        public List<IventoryMaterialDTO> GetListIventoryNot7()
        {
            List<IventoryMaterialDTO> listI = new List<IventoryMaterialDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT InputMaterial.Id, InputMaterial.MaterialCode,MaterialName,DateInput,ISNULL(SUM(QuantityOutput),0) AS CountXuat,(QuantityInput - ISNULL(SUM(QuantityOutput),0)) AS QuantityInput,StyleInput,IdWH,Name,Rosh,InputMaterial.Lot FROM dbo.InputMaterial LEFT JOIN dbo.OutputMaterial ON InputMaterial.Id = IdInput LEFT JOIN dbo.WarehouseMaterial ON IdWH = WarehouseMaterial.Id LEFT JOIN dbo.Material ON InputMaterial.MaterialCode = Material.MaterialCode  WHERE  StatusInput = 0 AND (StatusWH <> 10 AND StatusWH <> 7) GROUP BY  InputMaterial.Id, InputMaterial.MaterialCode,MaterialName, DateInput, QuantityInput, StyleInput, IdWH, Name, Rosh, InputMaterial.Lot");
            foreach (DataRow item in data.Rows)
            {
                IventoryMaterialDTO i = new IventoryMaterialDTO(item);
                listI.Add(i);
            }
            return listI;
        }
        public List<IventoryMaterialDTO> GetListIventory6()
        {
            List<IventoryMaterialDTO> listI = new List<IventoryMaterialDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT InputMaterial.Id, InputMaterial.MaterialCode,MaterialName,DateInput,ISNULL(SUM(QuantityOutput),0) AS CountXuat,(QuantityInput - ISNULL(SUM(QuantityOutput),0)) AS QuantityInput,StyleInput,IdWH,Name,Rosh,InputMaterial.Lot FROM dbo.InputMaterial LEFT JOIN dbo.OutputMaterial ON InputMaterial.Id = IdInput LEFT JOIN dbo.WarehouseMaterial ON IdWH = WarehouseMaterial.Id LEFT JOIN dbo.Material ON InputMaterial.MaterialCode = Material.MaterialCode  WHERE  StatusInput = 0 AND StatusWH = 6 GROUP BY  InputMaterial.Id, InputMaterial.MaterialCode,MaterialName, DateInput, QuantityInput, StyleInput, IdWH, Name, Rosh, InputMaterial.Lot");

            foreach (DataRow item in data.Rows)
            {
                IventoryMaterialDTO i = new IventoryMaterialDTO(item);
                listI.Add(i);
            }
            return listI;
        }
        public List<IventoryMaterialDTO> GetListIventoryByCode(string MaterialCode)
        {
            List<IventoryMaterialDTO> listI = new List<IventoryMaterialDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT InputMaterial.Id, InputMaterial.MaterialCode,MaterialName,DateInput,ISNULL(SUM(QuantityOutput),0) AS CountXuat,(QuantityInput - ISNULL(SUM(QuantityOutput),0)) AS QuantityInput,StyleInput,IdWH,Name,Rosh,InputMaterial.Lot FROM dbo.InputMaterial LEFT JOIN dbo.OutputMaterial ON InputMaterial.Id = IdInput LEFT JOIN dbo.WarehouseMaterial ON IdWH = WarehouseMaterial.Id LEFT JOIN dbo.Material ON InputMaterial.MaterialCode = Material.MaterialCode  WHERE  StatusInput = 0 AND (StatusWH <> 7 AND StatusWH <> 10) AND InputMaterial.MaterialCode = N'" + MaterialCode + "' GROUP BY  InputMaterial.Id, InputMaterial.MaterialCode,MaterialName, DateInput, QuantityInput, StyleInput, IdWH, Name, Rosh, InputMaterial.Lot");

            foreach (DataRow item in data.Rows)
            {
                IventoryMaterialDTO i = new IventoryMaterialDTO(item);
                listI.Add(i);
            }
            return listI;
        }
        public List<IventoryMaterialDTO> GetListIventoryByCode5(string MaterialCode)
        {
            List<IventoryMaterialDTO> listI = new List<IventoryMaterialDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT InputMaterial.Id, InputMaterial.MaterialCode,MaterialName,DateInput,ISNULL(SUM(QuantityOutput),0) AS CountXuat,(QuantityInput - ISNULL(SUM(QuantityOutput),0)) AS QuantityInput,StyleInput,IdWH,Name,Rosh,InputMaterial.Lot FROM dbo.InputMaterial LEFT JOIN dbo.OutputMaterial ON InputMaterial.Id = IdInput LEFT JOIN dbo.WarehouseMaterial ON IdWH = WarehouseMaterial.Id LEFT JOIN dbo.Material ON InputMaterial.MaterialCode = Material.MaterialCode  WHERE  StatusInput = 0 AND (StatusWH <> 7 AND StatusWH <> 10) AND InputMaterial.MaterialCode = N'" + MaterialCode + "' AND StatusWH <> 5 GROUP BY  InputMaterial.Id, InputMaterial.MaterialCode,MaterialName, DateInput, QuantityInput, StyleInput, IdWH, Name, Rosh, InputMaterial.Lot");

            foreach (DataRow item in data.Rows)
            {
                IventoryMaterialDTO i = new IventoryMaterialDTO(item);
                listI.Add(i);
            }
            return listI;
        }
        public List<IventoryMaterialDTO> GetListIventoryByCode4()
        {
            List<IventoryMaterialDTO> listI = new List<IventoryMaterialDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT InputMaterial.Id, InputMaterial.MaterialCode,MaterialName,DateInput,ISNULL(SUM(QuantityOutput),0) AS CountXuat,(QuantityInput - ISNULL(SUM(QuantityOutput),0)) AS QuantityInput,StyleInput,IdWH,Name,Rosh,InputMaterial.Lot FROM dbo.InputMaterial LEFT JOIN dbo.OutputMaterial ON InputMaterial.Id = IdInput LEFT JOIN dbo.WarehouseMaterial ON IdWH = WarehouseMaterial.Id LEFT JOIN dbo.Material ON InputMaterial.MaterialCode = Material.MaterialCode  WHERE  StatusInput = 0  AND StatusWH = 4 GROUP BY  InputMaterial.Id, InputMaterial.MaterialCode,MaterialName, DateInput, QuantityInput, StyleInput, IdWH, Name, Rosh, InputMaterial.Lot");

            foreach (DataRow item in data.Rows)
            {
                IventoryMaterialDTO i = new IventoryMaterialDTO(item);
                listI.Add(i);
            }
            return listI;
        }
        public List<IventoryMaterialDTO> GetListIventoryByCode34()
        {
            List<IventoryMaterialDTO> listI = new List<IventoryMaterialDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT InputMaterial.Id, InputMaterial.MaterialCode,MaterialName,DateInput,ISNULL(SUM(QuantityOutput),0) AS CountXuat,(QuantityInput - ISNULL(SUM(QuantityOutput),0)) AS QuantityInput,StyleInput,IdWH,Name,Rosh,InputMaterial.Lot FROM dbo.InputMaterial LEFT JOIN dbo.OutputMaterial ON InputMaterial.Id = IdInput LEFT JOIN dbo.WarehouseMaterial ON IdWH = WarehouseMaterial.Id LEFT JOIN dbo.Material ON InputMaterial.MaterialCode = Material.MaterialCode  WHERE  StatusInput = 0  AND (StatusWH = 4 OR StatusWH = 3) GROUP BY  InputMaterial.Id, InputMaterial.MaterialCode,MaterialName, DateInput, QuantityInput, StyleInput, IdWH, Name, Rosh, InputMaterial.Lot");

            foreach (DataRow item in data.Rows)
            {
                IventoryMaterialDTO i = new IventoryMaterialDTO(item);
                listI.Add(i);
            }
            return listI;
        }
        public List<IventoryMaterialDTO> GetListIventoryByIdWh(int IdWH)
        {
            List<IventoryMaterialDTO> listI = new List<IventoryMaterialDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT InputMaterial.Id, InputMaterial.MaterialCode,MaterialName,DateInput,ISNULL(SUM(QuantityOutput),0) AS CountXuat,(QuantityInput - ISNULL(SUM(QuantityOutput),0)) AS QuantityInput,StyleInput,IdWH,Name,Rosh,InputMaterial.Lot FROM dbo.InputMaterial LEFT JOIN dbo.OutputMaterial ON InputMaterial.Id = IdInput LEFT JOIN dbo.WarehouseMaterial ON IdWH = WarehouseMaterial.Id LEFT JOIN dbo.Material ON InputMaterial.MaterialCode = Material.MaterialCode  WHERE  StatusInput = 0 AND IdWH = " + IdWH + "  GROUP BY  InputMaterial.Id, InputMaterial.MaterialCode,MaterialName, DateInput, QuantityInput, StyleInput, IdWH, Name, Rosh, InputMaterial.Lot");

            foreach (DataRow item in data.Rows)
            {
                IventoryMaterialDTO i = new IventoryMaterialDTO(item);
                listI.Add(i);
            }
            return listI;
        }
        public string MaterialCodeById(long id)
        {
            List<IventoryMaterialDTO> listI = GetListIventory().Where(x => x.Id == id).ToList();
            string a = "";
            foreach (IventoryMaterialDTO item in listI)
            {
                a = item.MaterialCode;
            }
            return a;
        }
        public int StatusInput(long id)
        {
            return (int)DataProvider.Instance.ExecuteScalar("Select StatusInput from InputMaterial where Id = " + id);
        }
        public string GetEployessById(int Id)
        {
            try
            {
                return DataProvider.Instance.ExecuteScalar("SELECT Employess FROM dbo.InputMaterial,dbo.Material,dbo.WarehouseMaterial WHERE InputMaterial.MaterialCode = Material.MaterialCode AND WarehouseMaterial.Id = IdWH AND StatusInput = 0 AND InputMaterial.Id = " + Id).ToString();
            }
            catch
            {

                return "";
            }

        }
        public List<IventoryMaterialDTO> GetListOutputIventory(string MaterialCode)
        {
            List<IventoryMaterialDTO> listI = new List<IventoryMaterialDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT InputMaterial.Id, InputMaterial.MaterialCode,MaterialName,DateInput,ISNULL(SUM(QuantityOutput),0) AS CountXuat," +
                "(QuantityInput - ISNULL(SUM(QuantityOutput),0)) AS QuantityInput,StyleInput,IdWH,Name,Rosh,InputMaterial.Lot FROM dbo.InputMaterial LEFT JOIN dbo.OutputMaterial ON InputMaterial.Id = IdInput " +
                "LEFT JOIN dbo.WarehouseMaterial ON IdWH = WarehouseMaterial.Id LEFT JOIN dbo.Material ON InputMaterial.MaterialCode = Material.MaterialCode  WHERE  StatusInput = 0 AND StatusWH <> 10 AND InputMaterial.MaterialCode = N'" + MaterialCode + "' AND StyleInput <> N'TC'" +
                " GROUP BY  InputMaterial.Id, InputMaterial.MaterialCode,MaterialName, DateInput, QuantityInput, StyleInput, IdWH, Name, Rosh, InputMaterial.Lot ORDER BY DateInput ASC");
            foreach (DataRow item in data.Rows)
            {
                IventoryMaterialDTO i = new IventoryMaterialDTO(item);
                listI.Add(i);
            }
            return listI;
        }
        public List<IventoryMaterialDTO> GetListOutputIventory(string MaterialCode,string Style)
        {
            List<IventoryMaterialDTO> listI = new List<IventoryMaterialDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT InputMaterial.Id, InputMaterial.MaterialCode,MaterialName,DateInput,ISNULL(SUM(QuantityOutput),0) AS CountXuat,(QuantityInput - ISNULL(SUM(QuantityOutput),0)) AS QuantityInput," +
                "StyleInput,IdWH,Name,Rosh,InputMaterial.Lot FROM dbo.InputMaterial LEFT JOIN dbo.OutputMaterial ON InputMaterial.Id = IdInput LEFT JOIN dbo.WarehouseMaterial ON IdWH = WarehouseMaterial.Id LEFT JOIN dbo.Material ON InputMaterial.MaterialCode = Material.MaterialCode  WHERE  StatusInput = 0 AND StatusWH <> 10 " +
                "AND InputMaterial.MaterialCode = N'" + MaterialCode + "' AND StyleInput = N'"+Style+"' GROUP BY  InputMaterial.Id, InputMaterial.MaterialCode,MaterialName, DateInput, QuantityInput, StyleInput, IdWH, Name, Rosh, InputMaterial.Lot ORDER BY DateInput ASC");

            foreach (DataRow item in data.Rows)
            {
                IventoryMaterialDTO i = new IventoryMaterialDTO(item);
                listI.Add(i);
            }
            return listI;
        }
        public float TotalIventoryByCode(string MaterialCode,string Style)
        {
            List<IventoryMaterialDTO> listI = GetListOutputIventory(MaterialCode,Style);
            float sum = 0;
            foreach (IventoryMaterialDTO item in listI)
            {
                sum = sum + item.QuantityInput;
            }
            return sum;
        }
        public float TotalIventoryByCode(string MaterialCode)
        {
            List<IventoryMaterialDTO> listI = GetListOutputIventory(MaterialCode);
            float sum = 0;
            foreach (IventoryMaterialDTO item in listI)
            {
                sum = sum + item.QuantityInput;
            }
            return sum;
        }
        public float TotalIventoryByCodeByID(long id, string materialCode)
        {
            List<IventoryMaterialDTO> listI = GetListOutputIventory(materialCode).Where(x => x.Id == id).ToList();
            float sum = 0;
            foreach (IventoryMaterialDTO item in listI)
            {
                sum = sum + item.QuantityInput;
            }
            return sum;
        }
        public float IventoryMaterial(string MaterialCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT InputMaterial.Id, InputMaterial.MaterialCode,MaterialName,DateInput,ISNULL(SUM(QuantityOutput),0) AS CountXuat,(QuantityInput - ISNULL(SUM(QuantityOutput),0)) AS QuantityInput,StyleInput,IdWH,Name,Rosh,InputMaterial.Lot FROM dbo.InputMaterial LEFT JOIN dbo.OutputMaterial ON InputMaterial.Id = IdInput LEFT JOIN dbo.WarehouseMaterial ON IdWH = WarehouseMaterial.Id LEFT JOIN dbo.Material ON InputMaterial.MaterialCode = Material.MaterialCode  WHERE  StatusInput = 0 AND InputMaterial.MaterialCode = N'" + MaterialCode + "' GROUP BY  InputMaterial.Id, InputMaterial.MaterialCode,MaterialName, DateInput, QuantityInput, StyleInput, IdWH, Name, Rosh, InputMaterial.Lot ORDER BY DateInput ASC");

            if (data.Rows.Count > 0)
            {
                IventoryMaterialDTO i = new IventoryMaterialDTO(data.Rows[0]);
                return i.QuantityInput;
            }
            return 0;
        }
        public float IventoryMaterialById(long Id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT InputMaterial.Id, InputMaterial.MaterialCode,MaterialName,DateInput,ISNULL(SUM(QuantityOutput),0) AS CountXuat,(QuantityInput - ISNULL(SUM(QuantityOutput),0)) AS QuantityInput,StyleInput,IdWH,Name,Rosh,InputMaterial.Lot FROM dbo.InputMaterial LEFT JOIN dbo.OutputMaterial ON InputMaterial.Id = IdInput LEFT JOIN dbo.WarehouseMaterial ON IdWH = WarehouseMaterial.Id LEFT JOIN dbo.Material ON InputMaterial.MaterialCode = Material.MaterialCode  WHERE  StatusInput = 0 AND InputMaterial.Id = " + Id + " GROUP BY  InputMaterial.Id, InputMaterial.MaterialCode,MaterialName, DateInput, QuantityInput, StyleInput, IdWH, Name, Rosh, InputMaterial.Lot ORDER BY DateInput ASC");

            if (data.Rows.Count > 0)
            {
                IventoryMaterialDTO i = new IventoryMaterialDTO(data.Rows[0]);
                return i.QuantityInput;
            }
            return 0;
        }
        //Sửa thêm Rosh
        public long IdIventory(string MaterialCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT InputMaterial.Id, InputMaterial.MaterialCode,MaterialName,DateInput,ISNULL(SUM(QuantityOutput),0) AS CountXuat,(QuantityInput - ISNULL(SUM(QuantityOutput),0)) AS QuantityInput,StyleInput,IdWH,Name,Rosh,InputMaterial.Lot FROM dbo.InputMaterial LEFT JOIN dbo.OutputMaterial ON InputMaterial.Id = IdInput LEFT JOIN dbo.WarehouseMaterial ON IdWH = WarehouseMaterial.Id LEFT JOIN dbo.Material ON InputMaterial.MaterialCode = Material.MaterialCode  WHERE  StatusInput = 0 AND StatusWH <> 10 AND InputMaterial.MaterialCode = N'" + MaterialCode + "' GROUP BY  InputMaterial.Id, InputMaterial.MaterialCode,MaterialName, DateInput, QuantityInput, StyleInput, IdWH, Name, Rosh, InputMaterial.Lot ORDER BY DateInput ASC");

            if (data.Rows.Count > 0)
            {
                IventoryMaterialDTO i = new IventoryMaterialDTO(data.Rows[0]);
                return i.Id;
            }
            return -1;
        }
        public int StatusWHMaterial(string MaterialCode)
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT StatusWH FROM dbo.InputMaterial,dbo.Material,dbo.WarehouseMaterial WHERE InputMaterial.MaterialCode = Material.MaterialCode AND WarehouseMaterial.Id = IdWH AND StatusInput = 0 AND InputMaterial.MaterialCode = N'" + MaterialCode + "'");
            }
            catch 
            {
                return -1;
            }
        }
        public long IdInputMaterial(string MaterialCode, int IdWh)
        {

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT InputMaterial.Id, InputMaterial.MaterialCode,MaterialName,DateInput,ISNULL(SUM(QuantityOutput),0) AS CountXuat,(QuantityInput - ISNULL(SUM(QuantityOutput),0)) AS QuantityInput,StyleInput,IdWH,Name,Rosh,InputMaterial.Lot FROM dbo.InputMaterial LEFT JOIN dbo.OutputMaterial ON InputMaterial.Id = IdInput LEFT JOIN dbo.WarehouseMaterial ON IdWH = WarehouseMaterial.Id LEFT JOIN dbo.Material ON InputMaterial.MaterialCode = Material.MaterialCode  WHERE  StatusInput = 0 AND IdWH = " + IdWh + " AND InputMaterial.MaterialCode = N'" + MaterialCode + "' GROUP BY  InputMaterial.Id, InputMaterial.MaterialCode,MaterialName, DateInput, QuantityInput, StyleInput, IdWH, Name, Rosh, InputMaterial.Lot ORDER BY DateInput ASC");
            if (data.Rows.Count > 0)
            {
                IventoryMaterialDTO i = new IventoryMaterialDTO(data.Rows[0]);
                return i.Id;
            }
            return -1;
        }
        public long MaxIdInput()
        {
            return long.Parse(DataProvider.Instance.ExecuteScalar("SELECT MAX(Id) FROM InputMaterial").ToString());
        }

        public float QuantityInputMaterial(string MaterialCode, int IdWh)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT InputMaterial.Id, InputMaterial.MaterialCode,MaterialName,DateInput,ISNULL(SUM(QuantityOutput),0) AS CountXuat,(QuantityInput - ISNULL(SUM(QuantityOutput),0)) AS QuantityInput,StyleInput,IdWH,Name,Rosh,InputMaterial.Lot FROM dbo.InputMaterial LEFT JOIN dbo.OutputMaterial ON InputMaterial.Id = IdInput LEFT JOIN dbo.WarehouseMaterial ON IdWH = WarehouseMaterial.Id LEFT JOIN dbo.Material ON InputMaterial.MaterialCode = Material.MaterialCode  WHERE  StatusInput = 0 AND IdWH = " + IdWh + " AND InputMaterial.MaterialCode = N'" + MaterialCode + "' GROUP BY  InputMaterial.Id, InputMaterial.MaterialCode,MaterialName, DateInput, QuantityInput, StyleInput, IdWH, Name, Rosh, InputMaterial.Lot ORDER BY DateInput ASC");
            if (data.Rows.Count > 0)
            {
                IventoryMaterialDTO i = new IventoryMaterialDTO(data.Rows[0]);
                return i.QuantityInput;
            }
            return 0;
        }
        public float TotalMaterialByCode(string MaterialCode)
        {
            List<IventoryMaterialDTO> listR = GetListIventory().Where(x => x.MaterialCode == MaterialCode).ToList();
            float sum = 0;
            foreach (IventoryMaterialDTO item in listR)
            {
                sum += item.QuantityInput;
            }
            return sum;
        }

        public string GetLotByID(long IdIventory)
        {
            try
            {
                return DataProvider.Instance.ExecuteScalar("SELECT Lot FROM dbo.InputMaterial WHERE Id = " + IdIventory).ToString();
            }
            catch
            {
                return "";
            }

        }
        public long MaxIDOutput(string PartCode, string MachineCode)
        {
            try
            {
                return (long)DataProvider.Instance.ExecuteScalar("SELECT MAX(Id) FROM dbo.OutputMaterial WHERE PartCode = N'" + PartCode + "' AND MachineCode = N'" + MachineCode + "'");
            }
            catch
            {
                return -1;
            }
        }
        public string GetLotOutput(long IdOutput)
        {
            try
            {
                return DataProvider.Instance.ExecuteScalar("SELECT Lot FROM dbo.OutputMaterial WHERE Id = " + IdOutput).ToString();
            }
            catch
            {
                return "";
            }
        }
        #endregion
        #region Action
        public List<MaterialCodeDTO> GetMaterialCode()
        {
            List<MaterialCodeDTO> listM = new List<MaterialCodeDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT DISTINCT(InputMaterial.MaterialCode),MaterialName FROM dbo.InputMaterial,dbo.Material WHERE InputMaterial.MaterialCode = Material.MaterialCode AND StatusInput = 0 ORDER BY MaterialName");
            foreach (DataRow item in data.Rows)
            {
                MaterialCodeDTO m = new MaterialCodeDTO(item);
                listM.Add(m);
            }
            return listM;
        }
        #endregion
        #region Statistic Material
        public object StatisticInput(DateTime Date1, DateTime Date2)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC dbo.USP_StatisticInputMaterial @Date1 , @Date2 ", new object[] { Date1, Date2 });
        }
        public object StatisticOutput(DateTime Date1, DateTime Date2)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC dbo.USP_StatisticOutputMaterial @Date1 , @Date2 ", new object[] { Date1, Date2 });
        }
        #endregion
        #region RE Statistic Material
        public object ReStatisticOutput(DateTime Date1, DateTime Date2)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            return DataProvider.Instance.ExecuteQuery("SELECT InputMaterial.MaterialCode,MaterialName,DateReInput,QuantityReOutput,DateReoutput,ReOutputMaterial.Employess,MachineCode,PartCode,Name,Reason,QuantityCyclePlan,LotCycle,Note FROM dbo.ReOutputMaterial, dbo.ReInputMaterial, dbo.InputMaterial,dbo.Material,WarehouseMaterial WHERE InputMaterial.Id = IdInput AND ReInputMaterial.Id = IdReInput AND InputMaterial.MaterialCode = Material.MaterialCode AND WarehouseMaterial.Id = InputMaterial.IdWH AND DateReoutput >= '" + Date1 + "' AND DateReoutput <= '" + Date2 + "'");
        }
        public object ReStatisticInput(DateTime Date1, DateTime Date2)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            return DataProvider.Instance.ExecuteQuery("SELECT InputMaterial.MaterialCode,MaterialName,DateReInput,Quantity,Name,ReInputMaterial.Employess from ReInputMaterial,InputMaterial,WarehouseMaterial,Material Where Material.MaterialCode  = InputMaterial.MaterialCode AND IdInput = InputMaterial.Id AND ReInputMaterial.IdWh = WarehouseMaterial.Id AND DateReInput >= '" + Date1 + "' AND DateReInput <= '" + Date2 + "'");
        }

        #endregion
        #region Edit Iventory
        public bool EditIventoryMaterial(long Id, string MaterilCode, int QuantityInput, int Quantity)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("EXEC dbo.USP_EditIventoryMaterial @Id , @MaterilCode , @QuantityInput , @Quantity", new object[] { Id, MaterilCode, QuantityInput, Quantity });
            return result > 0;
        }
        #endregion
        #region REINPUT Material
        public List<IventoryReMaterial> GetInforReMaterial(long idInput)
        {
            List<IventoryReMaterial> listI = new List<IventoryReMaterial>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT ReInputMaterial.Id,IdInput,InputMaterial.MaterialCode,MaterialName,ISNULL(SUM(QuantityReOutput), 0) AS CountXuat,(Quantity - ISNULL(SUM(QuantityReOutput), 0)) AS Quantity,DateReInput FROM dbo.ReInputMaterial LEFT JOIN dbo.ReOutputMaterial ON ReInputMaterial.Id = IdReInput LEFT JOIN dbo.InputMaterial ON IdInput = InputMaterial.Id LEFT JOIN dbo.Material ON InputMaterial.MaterialCode = Material.MaterialCode WHERE StatusReInput = 0 AND IdInput = " + idInput + " GROUP BY ReInputMaterial.Id, InputMaterial.MaterialCode,MaterialName,Quantity,IdInput,DateReInput ");
            foreach (DataRow item in data.Rows)
            {
                IventoryReMaterial i = new IventoryReMaterial(item);
                listI.Add(i);
            }
            return listI;
        }
        public List<ReIventoryMaterial> GetListReMaterial()
        {
            List<ReIventoryMaterial> listM = new List<ReIventoryMaterial>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT ReInputMaterial.Id,IdInput,InputMaterial.MaterialCode,MaterialName,ISNULL(SUM(QuantityReOutput), 0) AS CountXuat,(Quantity - ISNULL(SUM(QuantityReOutput), 0)) AS Quantity FROM dbo.ReInputMaterial LEFT JOIN dbo.ReOutputMaterial ON ReInputMaterial.Id = IdReInput LEFT JOIN dbo.InputMaterial ON IdInput = InputMaterial.Id LEFT JOIN dbo.Material ON InputMaterial.MaterialCode = Material.MaterialCode WHERE StatusReInput = 0 GROUP BY ReInputMaterial.Id, InputMaterial.MaterialCode,MaterialName,Quantity,IdInput ");
            foreach (DataRow item in data.Rows)
            {
                ReIventoryMaterial r = new ReIventoryMaterial(item);
                listM.Add(r);
            }
            return listM;
        }
        public List<ReIventoryMaterial> GetListReMaterialByStatusInput1()
        {
            List<ReIventoryMaterial> listM = new List<ReIventoryMaterial>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT ReInputMaterial.Id,IdInput,InputMaterial.MaterialCode,MaterialName,ISNULL(SUM(QuantityReOutput), 0) AS CountXuat,(Quantity - ISNULL(SUM(QuantityReOutput), 0)) AS Quantity FROM dbo.ReInputMaterial LEFT JOIN dbo.ReOutputMaterial ON ReInputMaterial.Id = IdReInput LEFT JOIN dbo.InputMaterial ON IdInput = InputMaterial.Id LEFT JOIN dbo.Material ON InputMaterial.MaterialCode = Material.MaterialCode WHERE  StatusInput = 1  GROUP BY ReInputMaterial.Id, InputMaterial.MaterialCode,MaterialName,Quantity,IdInput ");
            foreach (DataRow item in data.Rows)
            {
                ReIventoryMaterial r = new ReIventoryMaterial(item);
                listM.Add(r);
            }
            return listM;
        }
        public bool InsertReInputMaterial(long IdInput, float Quantity, int IdWh, int StatusReInput, DateTime DateReInput, string Employess)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format("INSERT dbo.ReInputMaterial ( IdInput ,  Quantity , IdWh , StatusReInput , DateReInput , Employess) VALUES  ( {0} , {1} , {2} , {3} , '{4}' , N'{5}' )", IdInput, Quantity, IdWh, StatusReInput, DateReInput, Employess);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateQuantityReInputMaterial(long id, float quantity)
        {
            string query = string.Format("UPDATE dbo.ReInputMaterial SET Quantity = {1} WHERE Id = {0}", id, quantity);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateStartReInputMaterial(long id, int statusRe)
        {
            string query = string.Format("UPDATE dbo.ReInputMaterial SET StatusReInput = {1} WHERE IdInput = {0}", id, statusRe);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateStartByIdReInputMaterial(long id, int statusRe)
        {
            string query = string.Format("UPDATE dbo.ReInputMaterial SET StatusReInput = {1} WHERE Id = {0}", id, statusRe);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public float ReQuantitybyIdInput(long idInput)
        {
            List<ReIventoryMaterial> list = GetListReMaterial().Where(x => x.IdInput == idInput).ToList();
            float sum = 0;
            foreach (var item in list)
            {
                sum += item.Quantity;
            }
            return sum;
        }
        public float ReQuantitybyId(long id)
        {
            List<ReIventoryMaterial> list = GetListReMaterial().Where(x => x.Id == id).ToList();
            float sum = 0;
            foreach (var item in list)
            {
                sum += item.Quantity;
            }
            return sum;
        }
        public float TotalReMaterialByCode(string MaterialCode)
        {
            List<ReIventoryMaterial> listR = GetListReMaterial().Where(x => x.MaterialCode == MaterialCode).ToList();
            float sum = 0;
            foreach (ReIventoryMaterial item in listR)
            {
                sum += item.Quantity;
            }
            return sum;
        }
        public long IdReInputMaterial(long idInput)
        {
            try
            {
                return (long)DataProvider.Instance.ExecuteScalar("SELECT Id FROM dbo.ReInputMaterial WHERE StatusReInput = 0 AND IdInput = " + idInput);
            }
            catch
            {
                return -1;
            }
        }
        #endregion
        #region REOUTPUT Material
        public bool OutputMaterialCycle(long IdReInput, DateTime DateReoutput, float QuantityReOutput, string Employess, string PartCode, string MachineCode, string Note, string Reason, string LotCycle, float QuantityCyclePlan)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format("INSERT INTO [dbo].[ReOutputMaterial] ([IdReInput],[DateReoutput],[QuantityReOutput],[Employess],[PartCode],[MachineCode],[Note],[Reason],[LotCycle],[QuantityCyclePlan]) VALUES ({0},'{1}',{2},N'{3}',N'{4}',N'{5}',N'{6}',N'{7}',N'{8}',{9})", IdReInput, DateReoutput, QuantityReOutput, Employess, PartCode, MachineCode, Note, Reason, LotCycle, QuantityCyclePlan);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        #endregion
        #region REINPUT MATERIAL HH
        public List<ReIventoryMaterialHH> GetListMaterialHH()
        {
            List<ReIventoryMaterialHH> listR = new List<ReIventoryMaterialHH>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT ReInputHH.Id,IdInput,InputMaterial.MaterialCode,MaterialName,ISNULL(SUM(QuantityOutputHH), 0) AS CountXuat,(QuantityInputHH - ISNULL(SUM(QuantityOutputHH), 0)) AS QuantityInputHH ,DateInputHH FROM dbo.ReInputHH LEFT JOIN dbo.ReOutputHH ON ReInputHH.Id = IdReInputHH LEFT JOIN dbo.InputMaterial ON IdInput = InputMaterial.Id LEFT JOIN dbo.Material ON InputMaterial.MaterialCode = Material.MaterialCode  WHERE StatusReInputHH = 0 GROUP BY ReInputHH.Id, InputMaterial.MaterialCode,MaterialName,QuantityInputHH,IdInput,DateInputHH ");
            foreach (DataRow item in data.Rows)
            {
                ReIventoryMaterialHH r = new ReIventoryMaterialHH(item);
                listR.Add(r);
            }
            return listR;
        }
        public List<ReIventoryMaterialHH> GetListMaterialHHByIdInput(long idInput)
        {
            List<ReIventoryMaterialHH> listR = new List<ReIventoryMaterialHH>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT ReInputHH.Id,IdInput,InputMaterial.MaterialCode,MaterialName,ISNULL(SUM(QuantityOutputHH), 0) AS CountXuat,(QuantityInputHH - ISNULL(SUM(QuantityOutputHH), 0)) AS QuantityInputHH ,DateInputHH FROM dbo.ReInputHH LEFT JOIN dbo.ReOutputHH ON ReInputHH.Id = IdReInputHH LEFT JOIN dbo.InputMaterial ON IdInput = InputMaterial.Id LEFT JOIN dbo.Material ON InputMaterial.MaterialCode = Material.MaterialCode WHERE StatusReInputHH = 0 AND IdInput = " + idInput + " GROUP BY ReInputHH.Id, InputMaterial.MaterialCode,MaterialName,QuantityInputHH,IdInput,DateInputHH ");
            foreach (DataRow item in data.Rows)
            {
                ReIventoryMaterialHH r = new ReIventoryMaterialHH(item);
                listR.Add(r);
            }
            return listR;
        }
        public bool InsertReInputMaterialHH(long IdInput, float QuantityInputHH, int StatusReInputHH, DateTime DateInputHH, string Employess,string Note)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format("INSERT INTO [dbo].[ReInputHH]([IdInput],[DateInputHH],[QuantityInputHH],[StatusReInputHH],[Employess],[Note]) VALUES ({0},'{1}',{2},{3},N'{4}',N'{5}')", IdInput, DateInputHH, QuantityInputHH, StatusReInputHH, Employess,Note);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateQuantityMaterialHH(long id, float QuantityInputHH)
        {
            string query = string.Format("UPDATE dbo.ReInputHH SET QuantityInputHH = {1} WHERE Id = {0}", id, QuantityInputHH);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateStartReInputHH(long id, int statusRe)
        {
            string query = string.Format("UPDATE dbo.ReInputHH SET StatusReInputHH = {1} WHERE Id = {0}", id, statusRe);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateStartReInputHHByIdInput(long id, int statusRe)
        {
            string query = string.Format("UPDATE dbo.ReInputHH SET StatusReInputHH = {1} WHERE IdInput = {0}", id, statusRe);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public List<IventoryReMaterialHH> GetInforReMaterialHH(long idInput)
        {
            List<IventoryReMaterialHH> listI = new List<IventoryReMaterialHH>();
            DataTable data = DataProvider.Instance.ExecuteQuery(" SELECT ReInputHH.Id,IdInput,InputMaterial.MaterialCode,MaterialName,ISNULL(SUM(QuantityOutputHH), 0) AS CountXuat,(QuantityInputHH - ISNULL(SUM(QuantityOutputHH), 0)) AS QuantityInputHH , DateInputHH FROM dbo.ReInputHH LEFT JOIN dbo.ReOutputHH ON ReInputHH.Id = IdReInputHH LEFT JOIN dbo.InputMaterial ON IdInput = InputMaterial.Id LEFT JOIN dbo.Material ON InputMaterial.MaterialCode = Material.MaterialCode WHERE StatusReInputHH = 0 AND IdInput = " + idInput + "GROUP BY ReInputHH.Id, InputMaterial.MaterialCode,MaterialName,QuantityInputHH,IdInput,DateInputHH");
            foreach (DataRow item in data.Rows)
            {
                IventoryReMaterialHH i = new IventoryReMaterialHH(item);
                listI.Add(i);
            }
            return listI;
        }
        public float ReQuantityHHbyId(long idInput)
        {
            List<ReIventoryMaterialHH> list = GetListMaterialHH().Where(x => x.IdInput == idInput).ToList();
            float a = 0;
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    a = a + item.QuantityInputHH;
                }
                return a;
            }
            return 0;
        }
        public float IventoryMaterialHH(long id)
        {
            List<ReIventoryMaterialHH> list = GetListMaterialHH().Where(x => x.Id == id).ToList();
            float a = 0;
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    a = item.QuantityInputHH;
                }
                return a;
            }
            return 0;
        }
        public float TotalReMaterialHHByCode(string MaterialCode)
        {
            List<ReIventoryMaterialHH> listR = GetListMaterialHH().Where(x => x.MaterialCode == MaterialCode).ToList();
            float sum = 0;
            foreach (ReIventoryMaterialHH item in listR)
            {
                sum += item.QuantityInputHH;
            }
            return sum;
        }
        #endregion
        #region REOUTPUT MATERIAL HH
        public bool InsertReOutputMaterialHH(long IdReInputHH, DateTime DateOutputHH, float QuantityOutputHH, string Employess, string PartCode, string MachineCode, string Note,string Reason,string LotMix,float QuantityMixPlan)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format("INSERT INTO [dbo].[ReOutputHH] ([IdReInputHH],[DateOutputHH],[QuantityOutputHH],[Employess],[PartCode],[MachineCode],[Note],[Reason],[LotMix],[QuantityMixPlan]) VALUES ({0},'{1}',{2},N'{3}',N'{4}',N'{5}',N'{6}',N'{7}',N'{8}',{9})", IdReInputHH, DateOutputHH, QuantityOutputHH, Employess, PartCode, MachineCode, Note,Reason,LotMix,QuantityMixPlan);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        #endregion
        #region STATISTIC REMATERIAL HH
        public object StatisticReOutputHH(DateTime Date1, DateTime Date2)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            return DataProvider.Instance.ExecuteQuery("SELECT InputMaterial.MaterialCode,MaterialName,DateInputHH,QuantityOutputHH,DateOutputHH,ReOutputHH.Employess,MachineCode,PartCode,Name,ReOutputHH.Note,LotMix,Reason,QuantityMixPlan FROM dbo.ReOutputHH, dbo.ReInputHH, dbo.InputMaterial,dbo.Material,WarehouseMaterial WHERE InputMaterial.Id = IdInput AND ReInputHH.Id = IdReInputHH AND InputMaterial.MaterialCode = Material.MaterialCode AND WarehouseMaterial.Id = InputMaterial.IdWH AND DateOutputHH >= '" + Date1 + "' AND DateOutputHH <= '" + Date2 + "'");
        }
        public object StatisticReInputHH(DateTime Date1, DateTime Date2)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            return DataProvider.Instance.ExecuteQuery("SELECT InputMaterial.MaterialCode,MaterialName,DateInputHH,QuantityInputHH,Name,ReInputHH.Employess,ReInputHH.Note from ReInputHH,InputMaterial,WarehouseMaterial,Material Where Material.MaterialCode  = InputMaterial.MaterialCode AND IdInput = InputMaterial.Id AND InputMaterial.IdWH = WarehouseMaterial.Id AND DateInputHH >= '" + Date1 + "' AND DateInputHH <= '" + Date2 + "'");
        }

        #endregion
    }
}
