using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class MachineDetailDAO
    {
        private static MachineDetailDAO instance;

        public static MachineDetailDAO Instance
        {
            get
            {
                if (instance == null) instance = new MachineDetailDAO();
                return instance;
            }
            set => instance = value;
        }
        #region MACHINE DETAIL
        public List<MachineDetailDTO> GetListMachineDetail()
        {
            List<MachineDetailDTO> listM = new List<MachineDetailDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM MachineDetail");
            foreach (DataRow item in data.Rows)
            {
                MachineDetailDTO m = new MachineDetailDTO(item);
                listM.Add(m);
            }
            return listM;
        }
        public List<MachineDetailDTO> GetListMachineDetail(string machineCode)
        {
            List<MachineDetailDTO> listM = new List<MachineDetailDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM MachineDetail WHERE MachineCode = N'" + machineCode + "'");
            foreach (DataRow item in data.Rows)
            {
                MachineDetailDTO m = new MachineDetailDTO(item);
                listM.Add(m);
            }
            return listM;
        }

        public bool InsertMachineDetail(string MachineCode, string Col1, string Col2, string Col3)
        {
            string query = string.Format("INSERT INTO [dbo].[MachineDetail] ([MachineCode],[Col1],[Col2],[Col3]) VALUES (N'{0}',N'{1}',N'{2}',N'{3}')", MachineCode, Col1, Col2, Col3);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateMachineDetail(long Id, string MachineCode, string Col1, string Col2, string Col3)
        {
            string query = string.Format("UPDATE [dbo].[MachineDetail] SET [MachineCode] = N'{1}',[Col1] = N'{2}',[Col2] = N'{3}',[Col3] = N'{4}' WHERE Id = {0}", Id, MachineCode, Col1, Col2, Col3);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteMachineDetail(long Id)
        {
            string query = string.Format("DELETE [dbo].[MachineDetail] WHERE Id = {0}", Id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        #endregion
    }
}
