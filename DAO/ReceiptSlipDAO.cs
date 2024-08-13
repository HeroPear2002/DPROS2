using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ReceiptSlipDAO
    {
        private static ReceiptSlipDAO instance;

        public static ReceiptSlipDAO Instance {
            get
            {
                if (instance == null) instance = new ReceiptSlipDAO();
                return instance;
            }
            set => instance = value; }
        public List<String> DistinctReceipt(DateTime date1,DateTime date2)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-CA");
            List<string> listR = new List<string>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT DISTINCT(ReceiptCode) FROM ReceiptSlip  WHERE DatePrinter >= '"+date1+"' AND DatePrinter <='"+date2+"'");
            foreach (DataRow item in data.Rows)
            {
                string a = item["ReceiptCode"].ToString();
                listR.Add(a);
            }
            return listR;
        }
        public List<ReceiptSlipDTO> GetReceiptSlipDTOs()
        {
            List<ReceiptSlipDTO> listR = new List<ReceiptSlipDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT ReceiptSlip.Id,ReceiptSlip.IdDetail,ReceiptCode,POMaterialDetail.MaterCode,MaterialName,QuantityPlan,DatePrinter,ReceiptSlip.Employess,Note FROM ReceiptSlip,ProgressDetail,POMaterialDetail,Material WHERE POMaterialDetail.Id = ProgressDetail.IdDetail AND ReceiptSlip.IdDetail = ProgressDetail.Id AND POMaterialDetail.MaterCode = Material.MaterialCode");
            foreach (DataRow item in data.Rows)
            {
                ReceiptSlipDTO r = new ReceiptSlipDTO(item);
                listR.Add(r);
            }
            return listR;
        }
        public List<ReceiptSlipDTO> GetReceiptSlipDTOs(long IdDetail)
        {
            List<ReceiptSlipDTO> listR = new List<ReceiptSlipDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT ReceiptSlip.Id,ReceiptSlip.IdDetail,ReceiptCode,POMaterialDetail.MaterCode,MaterialName,QuantityPlan,DatePrinter,ReceiptSlip.Employess,Note FROM ReceiptSlip,ProgressDetail,POMaterialDetail,Material WHERE POMaterialDetail.Id = ProgressDetail.IdDetail AND ReceiptSlip.IdDetail = ProgressDetail.Id AND POMaterialDetail.MaterCode = Material.MaterialCode AND ReceiptSlip.IdDetail = " + IdDetail);
            foreach (DataRow item in data.Rows)
            {
                ReceiptSlipDTO r = new ReceiptSlipDTO(item);
                listR.Add(r);
            }
            return listR;
        }
        public List<ReceiptSlipDTO> GetReceiptSlipDTOs(string ReceiptCode)
        {
            List<ReceiptSlipDTO> listR = new List<ReceiptSlipDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT ReceiptSlip.Id,ReceiptSlip.IdDetail,ReceiptCode,POMaterialDetail.MaterCode,MaterialName,QuantityPlan,DatePrinter,ReceiptSlip.Employess,Note FROM ReceiptSlip,ProgressDetail,POMaterialDetail,Material WHERE POMaterialDetail.Id = ProgressDetail.IdDetail AND ReceiptSlip.IdDetail = ProgressDetail.Id AND POMaterialDetail.MaterCode = Material.MaterialCode AND ReceiptCode = N'" + ReceiptCode+"'");
            foreach (DataRow item in data.Rows)
            {
                ReceiptSlipDTO r = new ReceiptSlipDTO(item);
                listR.Add(r);
            }
            return listR;
        }
        public ReceiptSlipDTO ReceiptSlipDTO(string ReceiptCode)
        {
            return GetReceiptSlipDTOs(ReceiptCode).FirstOrDefault();
        }
        public bool InsertReceiptSlip(string ReceiptCode,long IdDetail,DateTime DatePrinter,string Employess,string Note)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-CA");
            string query = string.Format("INSERT INTO [dbo].[ReceiptSlip]([ReceiptCode],[IdDetail],[DatePrinter],[Employess],[Note]) VALUES (N'{0}',{1},'{2}',N'{3}',N'{4}')",ReceiptCode,IdDetail,DatePrinter,Employess,Note);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateReceiptSlip(string ReceiptCode, string Note)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-CA");
            string query = string.Format("UPDATE [dbo].[ReceiptSlip] SET [Note] = N'{1}' WHERE [ReceiptCode] = N'{0}'", ReceiptCode, Note);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteReceiptSlip(long Id)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-CA");
            string query = string.Format("DELETE [dbo].[ReceiptSlip] WHERE Id = "+Id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
