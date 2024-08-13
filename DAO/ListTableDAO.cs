using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ListTableDAO
    {
        private static ListTableDAO instance;

        public static ListTableDAO Instance
        {
            get
            {
                if (instance == null) instance = new ListTableDAO();
                return instance;
            }
            set => instance = value;
        }
        #region Table SX
        public object ListTableSXByDate(DateTime date1, DateTime date2)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-CA");
            return (object)DataProvider.Instance.ExecuteQuery("select * from TableSX where StartTime >= '"+date1+"' AND StartTime <='"+date2+"'");
        }
        public bool EditTableSX(long id,DateTime startTime,DateTime endTime)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-CA");
            string query = string.Format("update TableSX set StartTime = '{1}' , EndTime = '{2}' where Id = {0}",id,startTime,endTime);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result>0;
        }
        #endregion
        #region Table TT
        public object ListTableTTByDate(DateTime date1, DateTime date2)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-CA");
            return (object)DataProvider.Instance.ExecuteQuery("select TableTT.Id,MachineCode,MoldNumber,PartCode,TableTT.StartTime,TableTT.EndTime,Note from TableTT,TableSX where IdSX = TableSx.Id AND TableTT.StartTime >= '"+date1+"' AND TableTT.StartTime <= '"+date2+"'");
        }
        public bool EditTableTT(long id, DateTime startTime, DateTime endTime)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-CA");
            string query = string.Format("update TableTT set StartTime = '{1}' , EndTime = '{2}' where Id = {0}", id, startTime, endTime);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        #endregion
        #region Table DK
        public object ListTableDKByDate(DateTime date1, DateTime date2)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-CA");
            return (object)DataProvider.Instance.ExecuteQuery("select TableDK.Id,MachineCode,MoldNumber,PartCode,TableDK.StartTime,TableDK.EndTime,Note from TableDK,TableSX where IdSX = TableSx.Id AND TableDK.StartTime >= '"+date1+"' AND TableDK.StartTime <= '"+date2+"'");
        }
        public bool EditTableDK(long id, DateTime startTime, DateTime endTime)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-CA");
            string query = string.Format("update TableDK set StartTime = '{1}' , EndTime = '{2}' where Id = {0}", id, startTime, endTime);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        #endregion
        #region Table XH
        public object ListTableXHByDate(DateTime date1, DateTime date2)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-CA");
            return (object)DataProvider.Instance.ExecuteQuery("select TableXH.Id,MachineCode,MoldNumber,PartCode,TableXH.StartTime,TableXH.EndTime,Note from TableXH,TableSX where IdSX = TableSx.Id AND TableXH.StartTime >= '"+date1+"' AND TableXH.StartTime <= '"+date2+"'");
        }
        public bool EditTableXH(long id, DateTime startTime, DateTime endTime)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-CA");
            string query = string.Format("update TableXH set StartTime = '{1}' , EndTime = '{2}' where Id = {0}", id, startTime, endTime);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteTableXH(long id)
        {
            
            string query = string.Format("Delete TableXH where Id = {0}", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        #endregion
    }
}
