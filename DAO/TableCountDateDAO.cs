using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
   public class TableCountDateDAO
    {
        private static TableCountDateDAO instance;

        public static TableCountDateDAO Instance
        {
            get
            {
                if (instance == null) instance = new TableCountDateDAO();
                return instance;
            }

            set
            {
                instance = value;
            }
        }
        public List<TotalLKDTO> GetListTable()
        {
            List<TotalLKDTO> listT = new List<TotalLKDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableDateIventory");
            foreach (DataRow item in data.Rows)
            {
                TotalLKDTO t = new TotalLKDTO(item);
                listT.Add(t);
            }
            return listT;
        }
        public bool InsertTableCountDate(string PartCode ,DateTime Date ,int Output , int Input , int Total , int CountDate , int TotalNow , int InputNow , int CountDateNow )
        {
            int result = DataProvider.Instance.ExecuteNonQuery("EXEC dbo.USP_InsertTableDateIventory @PartCode , @Date , @Output , @Input , @Total , @CountDate , @TotalNow , @InputNow , @CountDateNow ",new object[] { PartCode, Date, Output, Input, Total, CountDate, TotalNow, InputNow, CountDateNow });
            return result > 0;
        }
        public bool UpdateTableCountDate(long Id, int Output, int Input, int Total, int CountDate, int TotalNow, int InputNow, int CountDateNow)
        {
            string query = string.Format("UPDATE dbo.TableDateIventory SET Output = {1}, Input = {2}, Total = {3} , CountDate = {4} , TotalNow = {5} , InputNow = {6} , CountDateNow = {7} WHERE Id = {0}", Id, Output, Input, Total, CountDate, TotalNow, InputNow, CountDateNow);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateTableCountDateNow(long Id, int TotalNow, int InputNow, int CountDateNow)
        {
            string query = string.Format("UPDATE dbo.TableDateIventory SET TotalNow = {1} , InputNow = {2} , CountDateNow = {3} WHERE Id = {0}", Id, TotalNow, InputNow, CountDateNow);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public int InputNow(long Id)
        {
            return (int)DataProvider.Instance.ExecuteScalar("SELECT InputNow FROM dbo.TableDateIventory WHERE Id =" +Id);
        }
        public bool DeleteTableCoutDate(long Id)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("DELETE dbo.TableDateIventory WHERE Id <= " + Id);
            return result > 0;
        }
        public long GetIdTableByDate(string PartCode, DateTime Date)
        {
            try
            {
                return (long)DataProvider.Instance.ExecuteScalar("EXEC dbo.USP_SelectTableDateIventory @PartCode , @Date ",new object[] { PartCode, Date });
            }
            catch 
            {

                return -1;
            }
        }
    }
}
