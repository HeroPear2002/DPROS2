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
   public class CTSXDAO
    {
        private static CTSXDAO instance;

        public static CTSXDAO Instance
        {
            get
            {
                if (instance == null) instance = new CTSXDAO();
                return instance;
            }

            set
            {
                instance = value;
            }
        }
        public List<PartCodeDTO> PartCodeCTSX()
        {
            List<PartCodeDTO> listP = new List<PartCodeDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT DISTINCT(PartCode) FROM dbo.MacInfor");
            foreach (DataRow item in data.Rows)
            {
                PartCodeDTO p = new PartCodeDTO(item);
                listP.Add(p);
            }
            return listP;
        }
        public object MoldCodeCTSX(string PartCode)
        {
            return DataProvider.Instance.ExecuteQuery("SELECT DISTINCT(MoldCode) FROM dbo.MacInfor WHERE PartCode = N'" + PartCode + "'");
        }
        public object MachineCodeCTSX(string PartCode,string MoldCode)
        {
            return DataProvider.Instance.ExecuteQuery("SELECT DISTINCT(MachineCode) FROM dbo.MacInfor WHERE PartCode = N'"+PartCode+"' AND MoldCode = N'"+MoldCode+"'");
        }
        public List<ProductDirectives> GetDataCTSX()
        {
            List<ProductDirectives> listD = new List<ProductDirectives>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT Id,ChiThiSX.DateInput,ChiThiSX.PartCode,Quantity,MachineCode," +
                "ChiThiSX.MoldCode,MoldNumber,NoteSX,NoteNL,FactoryCode,Part.MaterialCode,MaterialName,WeightUse, WeightOut," +
                "ChiThiSX.Status,ChiThiSX.Note FROM dbo.ChiThiSX ,dbo.Mold,Part,Material WHERE ChiThiSX.MoldCode = Mold.MoldCode AND " +
                "Part.PartCode = ChiThiSX.PartCode AND Material.MaterialCode = Part.MaterialCode ORDER BY ChiThiSX.Id DESC");
            foreach (DataRow item in data.Rows)
            {
                ProductDirectives p = new ProductDirectives(item);
                listD.Add(p);
            }
            return listD;
        }
        public ProductDirectives GetItem(long Id)
        {
            return GetDataCTSX().SingleOrDefault(x => x.Id == Id);
        }
        public bool InsertCTSX(DateTime DateInput , string PartCode , int Quantity , string MachineCode , 
            string MoldCode ,string NoteSX , string NoteNL ,string FactoryCode,float WeightUse,float WeightOut,int Status)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format("INSERT dbo.ChiThiSX ( DateInput , PartCode , Quantity , MachineCode , MoldCode , NoteSX ," +
                " NoteNL , FactoryCode,WeightUse,WeightOut,Status) VALUES  " +
                "('{0}' ,  N'{1}' , {2} ,  N'{3}' , N'{4}' , N'{5}' , N'{6}' , N'{7}' ,{8},{9},{10})", 
                DateInput, PartCode, Quantity, MachineCode, MoldCode, NoteSX, NoteNL,FactoryCode, WeightUse, WeightOut, Status);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateCTSX(long Id , DateTime DateInput, string PartCode, int Quantity, string MachineCode, string MoldCode, 
            string NoteSX, string NoteNL ,string FactoryCode, float WeightUse)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string query = string.Format("UPDATE [dbo].[ChiThiSX] SET [DateInput] = '{1}' ,[PartCode] = N'{2}' ,[Quantity] = {3} ," +
                "[MachineCode] = N'{4}',[MoldCode] = N'{5}' , [NoteSX] = N'{6}' , [NoteNL] = N'{7}' , [FactoryCode] = N'{8}' " +
                " , WeightUse = {9} WHERE Id = {0}", Id,DateInput, PartCode, Quantity, MachineCode, MoldCode, NoteSX, NoteNL, FactoryCode, WeightUse);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateCTSX(long Id, float WeightOut)
        {
            string query = string.Format("UPDATE [dbo].[ChiThiSX] SET WeightOut = {1} WHERE Id = {0}", Id, WeightOut);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateCTSXWeightUse(long Id, float WeightUse)
        {
            string query = string.Format("UPDATE [dbo].[ChiThiSX] SET WeightUse = {1} WHERE Id = {0}", Id, WeightUse);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateStatusCTSX(long Id, int Status)
        {
            string query = string.Format("UPDATE [dbo].[ChiThiSX] SET Status = {1} WHERE Id = {0}", Id, Status);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateStatusCTSX(long Id, int Status, string Note)
        {
            string query = string.Format("UPDATE [dbo].[ChiThiSX] SET Status = {1} , Note = N'{2}' WHERE Id = {0}", Id, Status,Note);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteCTSX(long Id)
        {
            string query = string.Format("DELETE dbo.ChiThiSX WHERE Id = {0}", Id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public string MoldCodeById(long Id)
        {
            return DataProvider.Instance.ExecuteScalar("SELECT MoldCode from ChiThiSX Where Id = " + Id).ToString();
        }
    }
}
