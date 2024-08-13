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
   public class IventoryPartDAO
    {
        private static IventoryPartDAO instance;

        public static IventoryPartDAO Instance
        {
            get
            {
                if (instance == null) instance = new IventoryPartDAO();
                return instance;
            }
            set
            {
                instance = value;
            }
        }
        #region Tồn kho
        public List<IvenstoryDTO> GetListIventoryPartByDateOUT(DateTime date1, DateTime date2, string PartCode)
        {
            List<IvenstoryDTO> listI = new List<IvenstoryDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC dbo.[USP_GetListIventoryPartByDateOUT] @Date1 , @Date2 , @PartCode", new object[] { date1, date2 ,PartCode});
            foreach (DataRow item in data.Rows)
            {
                IvenstoryDTO i = new IvenstoryDTO(item);
                listI.Add(i);
            }
            return listI;
        }
        public List<IvenstoryDTO> GetListIventoryPartByDate(DateTime date1 ,DateTime date2)
        {
            List<IvenstoryDTO> listI = new List<IvenstoryDTO>();
            DataTable data= DataProvider.Instance.ExecuteQuery("EXEC dbo.USP_GetListIventoryPartByDate @Date1 , @Date2 ", new object[] { date1,date2 });
            foreach (DataRow item in data.Rows)
            {
                IvenstoryDTO i = new IvenstoryDTO(item);
                listI.Add(i);
            }
            return listI;
        }
        public List<IvenstoryDTO> GetListIvenstoryPart()
        {
            List<IvenstoryDTO> listI = new List<IvenstoryDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_GetListIventoryPart");
            foreach (DataRow item in data.Rows)
            {
                IvenstoryDTO i = new IvenstoryDTO(item);
                listI.Add(i);
            }
            return listI;
        }
        public int IventoryById(long id)
        {
            int sum = 0;
            List<IvenstoryDTO> listI = GetListIvenstoryPart().Where(x=>x.Id == id).ToList();
            foreach (IvenstoryDTO item in listI)
            {
                sum += item.Iventory;
            }
            return sum;
        }
        public List<IvenstoryDTO> GetListIventoryPartStatus(DateTime date)
        {
            List<IvenstoryDTO> listI = new List<IvenstoryDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_GetListIventoryPartStatus @DateInput ", new object[] { date });
            foreach (DataRow item in data.Rows)
            {
                IvenstoryDTO i = new IvenstoryDTO(item);
                listI.Add(i);
            }
            return listI;
        }
        public object GetListIventoryPartQC()
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT InputPart.Id, InputPart.PartCode,DateInput,DateManufacturi,CountInput,ISNULL(SUM(CountOut),0) AS CountXuat,(CountInput - ISNULL(SUM(CountOut),0)) AS Iventory,MoldNumber,MachineCode,StyleInput,IdWareHouse,Name,NameStatus,Yellow,Note,Note2,Lot,FactoryCode FROM dbo.InputPart LEFT JOIN dbo.OutputPart ON InputPart.Id = IdInput LEFT JOIN dbo.WareHouse ON IdWareHouse = WareHouse.Id LEFT JOIN dbo.StatusWH ON Status = StatusWH.Id WHERE  StatusInput = 0 AND StatusWH.Id<>10  GROUP BY InputPart.Id, InputPart.PartCode, DateInput, DateManufacturi, CountInput, MoldNumber, MachineCode, StyleInput, IdWareHouse, Name, NameStatus, Yellow, Note,Note2,Lot,FactoryCode ");
        }
        public object GetListIventoryPartPC()
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT InputPart.Id, InputPart.PartCode,DateInput,DateManufacturi,CountInput,ISNULL(SUM(CountOut),0) AS CountXuat,(CountInput - ISNULL(SUM(CountOut),0)) AS Iventory,MoldNumber,MachineCode,StyleInput,IdWareHouse,Name,NameStatus,Yellow,Note,Lot,FactoryCode FROM dbo.InputPart LEFT JOIN dbo.OutputPart ON InputPart.Id = IdInput LEFT JOIN dbo.WareHouse ON IdWareHouse = WareHouse.Id LEFT JOIN dbo.StatusWH ON Status = StatusWH.Id WHERE  StatusInput = 0 AND StatusWH.Id=10  GROUP BY InputPart.Id, InputPart.PartCode, DateInput, DateManufacturi, CountInput, MoldNumber, MachineCode, StyleInput, IdWareHouse, Name, NameStatus, Yellow, Note,Lot,FactoryCode ");
        }
        public object GetListIventoryPartQCByIDWH(int IdWH)
        {
            return (object)DataProvider.Instance.ExecuteQuery("SELECT InputPart.Id, InputPart.PartCode,DateInput,DateManufacturi,CountInput,ISNULL(SUM(CountOut),0) AS CountXuat,(CountInput - ISNULL(SUM(CountOut),0)) AS Iventory,MoldNumber,MachineCode,StyleInput,IdWareHouse,Name,NameStatus,Yellow,Note,Lot,FactoryCode FROM dbo.InputPart LEFT JOIN dbo.OutputPart ON InputPart.Id = IdInput LEFT JOIN dbo.WareHouse ON IdWareHouse = WareHouse.Id LEFT JOIN dbo.StatusWH ON Status = StatusWH.Id WHERE  StatusInput = 0 AND IdWareHouse = " + IdWH+ " GROUP BY InputPart.Id, InputPart.PartCode, DateInput, DateManufacturi, CountInput, MoldNumber, MachineCode, StyleInput, IdWareHouse, Name, NameStatus, Yellow, Note, Lot,FactoryCode ");
        }
        public List<IvenstoryDTO> GetListIvenstoryPartByIDWh(int IdWH)
        {
            List<IvenstoryDTO> listI = new List<IvenstoryDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_GetListIventoryPartByIdWH @IdWH",new object[] { IdWH });
            foreach (DataRow item in data.Rows)
            {
                IvenstoryDTO i = new IvenstoryDTO(item);
                listI.Add(i);
            }
            return listI;
        }
        #endregion
        #region Input
        public List<InputPartDTO> GetListInput(DateTime Date1,DateTime Date2)
        {
            List<InputPartDTO> listI = new List<InputPartDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC dbo.USP_GetListInPutByDate @Date1 , @Date2", new object[] { Date1, Date2 });
            foreach (DataRow item in data.Rows)
            {
                InputPartDTO i = new InputPartDTO(item);
                listI.Add(i);
            }
            return listI;
        }
        public int TestGetListInput(int idWH)
        {     
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Inputpart where StatusInput = 0 AND IdWareHouse = "+idWH);
          if(data.Rows.Count>0)
            {
                return 1;
            }
            return -1;
        }
        public List<InputPartDTO> GetListInputByMachine(DateTime Date1, DateTime Date2,string MachineCode)
        {
            List<InputPartDTO> listI = new List<InputPartDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC dbo.USP_GetListInPutByDate @Date1 , @Date2", new object[] { Date1, Date2 });
            foreach (DataRow item in data.Rows)
            {
                InputPartDTO i = new InputPartDTO(item);
                listI.Add(i);
            }
            return listI.Where(x=>x.MachineCode == MachineCode).ToList();
        }
        public bool InputPart(string PartCode,DateTime DateInput,int CountInput,string Employess,string MoldNumber,string MachineCode,int IdWareHouse,DateTime DateManufacturi, int StatusInput,string StyleInput,string Lot, string Note, string Note2, string FactoryCode)
        {
                int result = DataProvider.Instance.ExecuteNonQuery("EXEC dbo.USP_InputPart @PartCode , @DateInput , @CountInput , @Employess , @MoldNumber , @MachineCode , @IdWareHouse , @DateManufacturi , @StatusInput , @StyleInput , @Lot , @Note , @Note2 , @FactoryCode", new object[] { PartCode, DateInput,  CountInput, Employess, MoldNumber, MachineCode, IdWareHouse, DateManufacturi,StatusInput,StyleInput, Lot,Note,Note2,FactoryCode });
                return result > 0;
        }
        public bool UpdateInputPart(long Id,int status)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("UPDATE dbo.InputPart SET StatusInput = "+ status + " WHERE Id = " + Id);
            return result > 0;
        }
        public bool UpdateLotInputPart(long Id,string lot)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("UPDATE dbo.InputPart SET Lot = N'"+lot+"' WHERE Id = " + Id);
            return result > 0;
        }
        public bool UpdateDateInputPart(long Id, DateTime date)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("UPDATE dbo.InputPart SET DateManufacturi = '" + date + "' WHERE Id = " + Id);
            return result > 0;
        }
        public bool UpdateFactoryInputPart(long Id, string factoryCode)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("UPDATE dbo.InputPart SET FactoryCode = '" + factoryCode + "' WHERE Id = " + Id);
            return result > 0;
        }
        public bool UpdateNoteInputPart(long Id,string Note)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("UPDATE dbo.InputPart SET Note = N'"+Note+"' WHERE Id = " + Id);
            return result > 0;
        }
        public bool DeleteNInputPart(long Id, int idWH)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("DELETE dbo.InputPart WHERE Id > " + Id + " AND IdWareHouse = " + idWH);
            return result > 0;
        }
        
        public int TestIdWarehouse(int idWarehouse)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.InputPart WHERE StatusInput = 0 AND IdWareHouse = "+idWarehouse);
            if(data.Rows.Count >0)
            {
                return 1;
            }
            return -1;
        }
        public long MaxIdInput(int IdWh)
        {
            try
            {
                return (long)DataProvider.Instance.ExecuteScalar("SELECT MAX(Id) FROM dbo.InputPart WHERE IdWareHouse = " + IdWh);
            }
            catch 
            {

                return -1;
            }
   
        }
        public int StatusInput(long id)
        {
            return (int)DataProvider.Instance.ExecuteScalar("SELECT StatusInput FROM dbo.InputPart WHERE Id = " +id);
        }
        public bool UpdateNote2InputPart(long Id, string Note)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("UPDATE dbo.InputPart SET Note2 = N'" + Note + "' WHERE Id = " + Id);
            return result > 0;
        }
        #endregion
        #region Output
        public object GetListOutput(DateTime Date1, DateTime Date2)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC dbo.USP_GetListOutputByDate @Date1 , @Date2", new object[] { Date1, Date2 });
        }
        public List<IvenstoryDTO> GetListPartOKByCode(string PartCode, string Factorycode)
        {
            List<IvenstoryDTO> listI = new List<IvenstoryDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC dbo.USP_GetListPartOKByCode @PartCode , @FactoryCode ", new object[] { PartCode,Factorycode});
            foreach (DataRow item in data.Rows)
            {
                IvenstoryDTO i = new IvenstoryDTO(item);
                listI.Add(i);
            }
            return listI;
        }
        public List<IvenstoryDTO> GetListPartKHO2OKByCode(string PartCode)
        {
            List<IvenstoryDTO> listI = new List<IvenstoryDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC dbo.USP_GetListPartKHO2OKByCode @PartCode ", new object[] { PartCode });
            foreach (DataRow item in data.Rows)
            {
                IvenstoryDTO i = new IvenstoryDTO(item);
                listI.Add(i);
            }
            return listI;
        }
        public DateTime GetDateIventory(string PartCode, string FactoryCode)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC dbo.USP_GetListPartOKByCode @PartCode , @FactoryCode ", new object[] { PartCode , FactoryCode });
            IvenstoryDTO I = new IvenstoryDTO(data.Rows[0]);
            return I.DateManufacturi;
        }
        public bool OutputPart(long IdInput,DateTime DateOutput,int CountOut,string Employess,string StyleOutput)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("EXEC dbo.USP_OutputPart @IdInput , @DateOutput , @CountOut , @Employees , @StyleOutput", new object[] { IdInput, DateOutput, CountOut, Employess ,StyleOutput});
            return result > 0;
        }
        public bool OutputPartNotProvider(long IdInput, DateTime DateOutput, int CountOut, string Employess, string StyleOutput, long IdDe, string POCode)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format("INSERT INTO [dbo].[OutputPart] ([IdInput],[DateOutput],[Employess],[CountOut],[StyleOutput],[IdDe],[POCode]) VALUES({0},'{1}',N'{2}',{3},N'{4}',{5},N'{6}')", IdInput, DateOutput, Employess, CountOut, StyleOutput,IdDe,POCode);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public int TotalOutput(long Idinput ,DateTime date)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            try
            {
                string query = string.Format("SELECT SUM(CountOut) FROM dbo.OutputPart WHERE IdInput = {0} AND DateOutput <='{1}'",Idinput,date);
                return (int)DataProvider.Instance.ExecuteScalar(query);
            }
            catch 
            {
               return 0;
            }
        }
        public int IdOutputByIdInput(long idInput)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM OutputPart WHERE IdInput = " + idInput);
            if(data.Rows.Count > 0)
            {
                return 1;
            }
            return -1;
        }
        public long MaxIdOutput()
        {
            try
            {
                return long.Parse(DataProvider.Instance.ExecuteScalar("SELECT Max(Id) FROM OutputPart").ToString());
            }
            catch
            {
                return -1;
            }
        }
        #endregion
        #region Output NG
        public List<IvenstoryDTO> GetListPartNGByCode(string PartCode)
        {
            List<IvenstoryDTO> listI = new List<IvenstoryDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_GetListPartNGByCode @PartCode ", new object[] { PartCode });
            foreach (DataRow item in data.Rows)
            {
                IvenstoryDTO i = new IvenstoryDTO(item);
                listI.Add(i);
            }
            return listI;
        }
        public object GetListPartNG()
        {
            return DataProvider.Instance.ExecuteQuery("EXEC dbo.USP_GetListPartNG");
        }
        public int TotalPartNG(string PartCode)
        {
            int total = 0;
            List<IvenstoryDTO> lisI = GetListPartNGByCode(PartCode);
            foreach (IvenstoryDTO item in lisI)
            {
                total = total + item.Iventory;
            }
            return total;
        }
        public int TotalPartNGByIdWH(string PartCode, long idWH)
        {
            int total = 0;
            List<IvenstoryDTO> lisI = GetListPartNGByCode(PartCode);
            foreach (IvenstoryDTO item in lisI.Where(x=>x.IdWareHouse == idWH))
            {
                total = total + item.Iventory;
            }
            return total;
        }
        #endregion
        // Tổng tồn theo mã linh kiện
        public int TotalPartOK(string PartCode, string FactoryCode)
        {
            int total = 0;
            List<IvenstoryDTO> lisI = GetListPartOKByCode(PartCode, FactoryCode);
            foreach (IvenstoryDTO item in lisI)
            {
                total = total + item.Iventory;
            }
            return total;
        }
        public int TotalPartKHO2OK(string PartCode)
        {
            int total = 0;
            List<IvenstoryDTO> lisI = GetListPartKHO2OKByCode(PartCode);
            foreach (IvenstoryDTO item in lisI)
            {
                total = total + item.Iventory;
            }
            return total;
        }
        public int TotallPartAllStatus(string PartCode)
        {
            int total = 0;
            List<IvenstoryDTO> lisI = GetListIvenstoryPart().Where(x=>x.PartCode == PartCode).ToList();
            foreach (IvenstoryDTO item in lisI)
            {
                total = total + item.Iventory;
            }
            return total;
        }
        public int TotalInputbyDate(string PartCode, DateTime Date1, DateTime Date2)
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("USP_TotalInputByDate @PartCode , @Date1 , @Date2 ", new object[] { PartCode, Date1, Date2 });
            }
            catch
            {
                return 0;
            }
        }
        #region Edit Iventory
        public bool EditIventoryPart(long Id,string PartCode,int CountInput)
        {
            string querry = string.Format("UPDATE dbo.InputPart SET PartCode = N'{1}', CountInput = {2} WHERE Id = {0}",Id,PartCode,CountInput);
            int result = DataProvider.Instance.ExecuteNonQuery(querry);
            return result > 0;
        }
        public int QuantityInput(long Id)
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT CountInput FROM dbo.InputPart WHERE Id = " + Id);
            }
            catch 
            {
                return 0;
            }
        }
        #endregion
        #region QC
        public object GetListHistoryQC(DateTime date1, DateTime date2)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            return DataProvider.Instance.ExecuteQuery("Select HistoryQC.Id,DateChange,PartCode,MoldNumber,MachineCode,Name,HistoryQC.Employess,StatusBefor,StatusAfter,DateInput from HistoryQC, InputPart , WareHouse Where HistoryQC.IdInput = InputPart.Id AND InputPart.IdWareHouse = WareHouse.Id AND DateChange >= '" + date1 + "' AND DateChange <= '" + date2 + "'");
        }
        public bool InputHistoryQC(long IdInput, DateTime DateChange, string Befor, string After, string Employess)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string Querry = string.Format("INSERT INTO [dbo].[HistoryQC]([IdInput],[DateChange],[StatusBefor],[StatusAfter],[Employess])VALUES({0},'{1}',N'{2}',N'{3}',N'{4}')", IdInput, DateChange, Befor, After, Employess);
            int result = DataProvider.Instance.ExecuteNonQuery(Querry);
            return result > 0;
        }
        #endregion
    }
}
