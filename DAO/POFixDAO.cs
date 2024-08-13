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
   public class POFixDAO
    {
        private static POFixDAO instance;

        public static POFixDAO Instance
        {
            get
            {
                if (instance == null) instance = new POFixDAO();
                return instance;
            }
            set
            {
                instance = value;
            }
        }
        public List<POFixDTO> GetListPOFix()
        {
            List<POFixDTO> listP = new List<POFixDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT POFix.Id,POFix.POCode,POFix.PartCode,Quantity,POFix.DateOut,POFix.Note,POFix.Status,POFix.DateInput,FactoryCustomer,CarNumber,IdPOInput,IdDe,FactoryCode FROM dbo.POFix,USP_POInput WHERE IdPOInput = USP_POInput.Id ORDER BY Status DESC");
            foreach (DataRow item in data.Rows)
            {
                POFixDTO p = new POFixDTO(item);
                listP.Add(p);
            }
            return listP;           
        }
        public List<POFixDTO> GetListPOFix(DateTime date1,DateTime date2)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            List<POFixDTO> listP = new List<POFixDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT POFix.Id,POFix.POCode,POFix.PartCode,Quantity,POFix.DateOut,POFix.Note,POFix.Status,POFix.DateInput,FactoryCustomer,CarNumber,IdPOInput,IdDe,FactoryCode FROM dbo.POFix,USP_POInput WHERE IdPOInput = USP_POInput.Id AND POFix.DateOut >= '" + date1+ "' AND POFix.DateOut <= '" + date2+"'");
            foreach (DataRow item in data.Rows)
            {
                POFixDTO p = new POFixDTO(item);
                listP.Add(p);
            }
            return listP;
        }
        public List<POFixDTO> GetListPOFix(int status)
        {
            List<POFixDTO> listP = new List<POFixDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT POFix.Id,POFix.POCode,POFix.PartCode,Quantity,POFix.DateOut,POFix.Note,POFix.Status,POFix.DateInput,FactoryCustomer,CarNumber,IdPOInput,IdDe,FactoryCode FROM dbo.POFix,USP_POInput WHERE IdPOInput = USP_POInput.Id AND Status = " + status);
            foreach (DataRow item in data.Rows)
            {
                POFixDTO p = new POFixDTO(item);
                listP.Add(p);
            }
            return listP;
        }
        public List<POFixDTO> GetListPOFix06()
        {
            List<POFixDTO> listP = new List<POFixDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT POFix.Id,POFix.POCode,POFix.PartCode,Quantity,POFix.DateOut,POFix.Note,POFix.Status,POFix.DateInput,FactoryCustomer,CarNumber,IdPOInput,IdDe,FactoryCode FROM dbo.POFix,USP_POInput WHERE IdPOInput = USP_POInput.Id AND (Status = 0 OR Status = 6)");
            foreach (DataRow item in data.Rows)
            {
                POFixDTO p = new POFixDTO(item);
                listP.Add(p);
            }
            return listP;
        }
        public POFixDTO GetItemPOFix(long Id)
        {
            return GetListPOFix().SingleOrDefault(x => x.Id == Id);
        }
        public POFixDTO GetItemPOFixByIdDe(long IdDe)
        {
            return GetListPOFix().FirstOrDefault(x => x.IdDe == IdDe);
        }
        public List<POFixDTO> GetListPOFix(long IdPOInput)
        {
            List<POFixDTO> listP = new List<POFixDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT POFix.Id,POFix.POCode,POFix.PartCode,Quantity,POFix.DateOut,POFix.Note,POFix.Status,POFix.DateInput,FactoryCustomer,CarNumber,IdPOInput,IdDe,FactoryCode FROM dbo.POFix,USP_POInput WHERE IdPOInput = USP_POInput.Id AND IdPOInput = " + IdPOInput);
            foreach (DataRow item in data.Rows)
            {
                POFixDTO p = new POFixDTO(item);
                listP.Add(p);
            }
            return listP;
        }
        public List<POFixDTO> GetListPOFixByStatus6()
        {
            List<POFixDTO> listP = new List<POFixDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT POFix.Id,POFix.POCode,POFix.PartCode,Quantity,POFix.DateOut,POFix.Note,POFix.Status,POFix.DateInput,FactoryCustomer,CarNumber,IdPOInput,IdDe,FactoryCode FROM dbo.POFix,USP_POInput WHERE IdPOInput = USP_POInput.Id AND Status = 6");
            foreach (DataRow item in data.Rows)
            {
                POFixDTO p = new POFixDTO(item);
                listP.Add(p);
            }
            return listP;
        }
        public List<POFixDTO> GetListPOFixByStatus5()
        {
            List<POFixDTO> listP = new List<POFixDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT POFix.Id,POFix.POCode,POFix.PartCode,Quantity,POFix.DateOut,POFix.Note,POFix.Status,POFix.DateInput,FactoryCustomer,CarNumber,IdPOInput,IdDe,FactoryCode FROM dbo.POFix,USP_POInput WHERE IdPOInput = USP_POInput.Id AND Status = 5");
            foreach (DataRow item in data.Rows)
            {
                POFixDTO p = new POFixDTO(item);
                listP.Add(p);
            }
            return listP;
        }
        public int TestPOCode(string POCode)
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT Count(*) FROM dbo.POFix WHERE POCode = N'" + POCode+"'");
            }
            catch 
            {
                return -1;
            }
        }
        public int StatusPO(string POCode)
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT Status FROM dbo.POFix WHERE POCode = N'" + POCode + "'");
            }
            catch
            {
                return -1;
            }
        }
        public int StatusPO(long id)
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT Status FROM dbo.POFix WHERE Id = "+id);
            }
            catch
            {
                return -1;
            }
        }
        public DateTime DateOut(string POCode)
        {

                return (DateTime)DataProvider.Instance.ExecuteScalar("SELECT DateOut FROM dbo.POFix WHERE POCode = N'" + POCode + "'");
            
        }
        public bool InsertPOFix(long IdPOInput, string POCode , string PartCode ,int Quantity , DateTime DateOut ,string Note ,int Status , DateTime DateInput,string Factory, string CarNumber)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("EXEC dbo.USP_InsertPOFix @IdPOInput , @POCode , @PartCode , @Quantity , @DateOut , @Note , @Status , @DateInput , @FactoryCustomer , @CarNumber", new object[] { IdPOInput,POCode, PartCode, Quantity, DateOut, Note, Status, DateInput,Factory,CarNumber });
            return result > 0;
        }
        public bool UpdatePOFix(long Id,long IdPOInput, string POCode, string PartCode, int Quantity, DateTime DateOut,DateTime DateInput, string Factory, string CarNumber)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("EXEC dbo.USP_UpdatePOFix @Id , @IdPOInput , @POCode , @PartCode , @Quantity , @DateOut , @DateInput , @FactoryCustomer , @CarNumber", new object[] { Id,IdPOInput, POCode, PartCode, Quantity, DateOut,DateInput,Factory, CarNumber });
            return result > 0;
        }
        public bool UpdatePOFixByCode(string POCode,int status , string Note)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("UPDATE dbo.POFix SET Status = "+status+" , Note = N'"+Note+"' WHERE POCode = N'"+POCode+"'");
            return result > 0;
        }
        public bool UpdatePOFixByCode(long Id, int status, string Note)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("UPDATE dbo.POFix SET Status = " + status + " , Note = N'" + Note + "' WHERE Id = "+Id);
            return result > 0;
        }
        public bool UpdatePOFixByIdDe(long IdDe, int status, string Note)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("UPDATE dbo.POFix SET Status = " + status + " , Note = N'" + Note + "', IdDe = Null WHERE IdDe = " + IdDe);
            return result > 0;
        }
        public bool UpdatePOFixById(long Id, int status, string Note)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("UPDATE dbo.POFix SET Status = " + status + " , Note = N'" + Note + "', IdDe = Null WHERE Id = " + Id);
            return result > 0;
        }
        public bool UpdatePOFixByCode(long Id, int status, string Note,long IdDe)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("UPDATE dbo.POFix SET Status = " + status + " , Note = N'" + Note + "' , IdDe = "+IdDe+" WHERE Id = " + Id);
            return result > 0;
        }
        public bool DeletePOFix(long Id)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("DELETE dbo.POFix WHERE Id = "+Id);
            return result > 0;
        }
        public bool DeletePOFixByIdInput(long IdPOInput)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("DELETE dbo.POFix WHERE IdPOInput = " + IdPOInput);
            return result > 0;
        }
        public int SumQuantity(long IdPOInput)
        {
            List<POFixDTO> listP = GetListPOFix(IdPOInput);
            int sum = 0;
            foreach (var item in listP)
            {
                sum += item.Quantity;
            }
            return sum;
        }
        public int SumQuantity(long IdPOInput,long Id)
        {
            List<POFixDTO> listP = GetListPOFix(IdPOInput).Where(x=>x.Id != Id).ToList();
            int sum = 0;
            foreach (var item in listP)
            {
                sum += item.Quantity;
            }
            return sum;
        }
    }
}
