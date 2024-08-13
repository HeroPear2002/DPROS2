using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ChartCategoryDAO
    {
        private static ChartCategoryDAO ins;

        public static ChartCategoryDAO Ins
        {
            get
            {
                if (ins == null) ins = new ChartCategoryDAO();
                return ins;
            }
            set => ins = value;
        }
        public List<ChartCategoryDTO> GetListChartShortByDate(DateTime date1, DateTime date2, string MachineCode)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            List<ChartCategoryDTO> listC = new List<ChartCategoryDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT HistoryDevice.Id,DataCount,DateCheck,NameCategory,Detail,Limit,MachineCode,IdCategory FROM dbo.HistoryDevice,dbo.CategoryTest,dbo.RelationShip WHERE IdRelationShip = RelationShip.Id AND IdCategory = CategoryTest.Id AND ConfirmCategory = 1 AND Timer = 24 AND MachineCode = N'" + MachineCode + "' AND DateCheck >= '" + date1 + "' AND DateCheck <= '" + date2 + "'");
            foreach (DataRow item in data.Rows)
            {
                ChartCategoryDTO c = new ChartCategoryDTO(item);
                listC.Add(c);
            }
            return listC;
        }
        public List<ChartCategoryDTO> GetListChartLongByDate(DateTime date1, DateTime date2, string MachineCode)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            List<ChartCategoryDTO> listC = new List<ChartCategoryDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT HistoryDevice.Id,DataCount,DateCheck,NameCategory,Detail,Limit,MachineCode,IdCategory FROM dbo.HistoryDevice,dbo.CategoryTest,dbo.RelationShip WHERE IdRelationShip = RelationShip.Id AND IdCategory = CategoryTest.Id AND ConfirmCategory = 1 AND Timer > 24 AND MachineCode = N'" + MachineCode + "' AND DateCheck >= '" + date1 + "' AND DateCheck <= '" + date2 + "'");
            foreach (DataRow item in data.Rows)
            {
                ChartCategoryDTO c = new ChartCategoryDTO(item);
                listC.Add(c);
            }
            return listC;
        }
        public List<OnlyCategoryTest> GetOnlyCate(DateTime date1, DateTime date2, string MachineCode)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            List<OnlyCategoryTest> listC = new List<OnlyCategoryTest>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT  DISTINCT(CategoryTest.Id),NameCategory FROM dbo.HistoryDevice,dbo.CategoryTest,dbo.RelationShip WHERE IdRelationShip = RelationShip.Id AND IdCategory = CategoryTest.Id AND ConfirmCategory = 1 AND Timer = 24 AND MachineCode = N'" + MachineCode + "' AND DateCheck >= '" + date1 + "' AND DateCheck <= '" + date2 + "'");
            foreach (DataRow item in data.Rows)
            {
                OnlyCategoryTest c = new OnlyCategoryTest(item);
                listC.Add(c);
            }
            return listC;
        }
        public List<OnlyCategoryTest> GetOnlyCateLong(DateTime date1, DateTime date2, string MachineCode)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            List<OnlyCategoryTest> listC = new List<OnlyCategoryTest>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT  DISTINCT(CategoryTest.Id),NameCategory FROM dbo.HistoryDevice,dbo.CategoryTest,dbo.RelationShip WHERE IdRelationShip = RelationShip.Id AND IdCategory = CategoryTest.Id AND ConfirmCategory = 1 AND Timer > 24 AND MachineCode = N'" + MachineCode + "' AND DateCheck >= '" + date1 + "' AND DateCheck <= '" + date2 + "'");
            foreach (DataRow item in data.Rows)
            {
                OnlyCategoryTest c = new OnlyCategoryTest(item);
                listC.Add(c);
            }
            return listC;
        }
    }
}
