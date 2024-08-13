using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class BoxCheckDAO
    {
        private static BoxCheckDAO instance;

        public static BoxCheckDAO Instance
        {
            get
            {
                if (instance == null) instance = new BoxCheckDAO();
                return instance;
            }
            set => instance = value;
        }
        public List<BoxCheckDTO> GetListBoxCheck()
        {
            List<BoxCheckDTO> listB = new List<BoxCheckDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM BoxCheck");
            foreach (DataRow item in data.Rows)
            {
                BoxCheckDTO b = new BoxCheckDTO(item);
                listB.Add(b);
            }
            return listB;
        }
        public List<BoxCheckDTO> GetListBoxCheck(string CheckCode, string POCode)
        {
            List<BoxCheckDTO> listB = new List<BoxCheckDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM BoxCheck WHERE CheckCode = N'" + CheckCode+"' AND POCode = N'"+POCode+"'");
            foreach (DataRow item in data.Rows)
            {
                BoxCheckDTO b = new BoxCheckDTO(item);
                listB.Add(b);
            }
            return listB;
        }
        public List<BoxCheckDTO> GetListBoxCheck(string CheckCode)
        {
            List<BoxCheckDTO> listB = new List<BoxCheckDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM BoxCheck WHERE CheckCode = N'" + CheckCode + "'");
            foreach (DataRow item in data.Rows)
            {
                BoxCheckDTO b = new BoxCheckDTO(item);
                listB.Add(b);
            }
            return listB;
        }
        public BoxCheckDTO GetItemBoxCheck(string QrCode)
        {
            string query = "SELECT * FROM BoxCheck WHERE QrCode = N'" + QrCode + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            if(data.Rows.Count > 0)
            {
                BoxCheckDTO boxCheckDTO = new BoxCheckDTO(data.Rows[0]);
                return boxCheckDTO;
            }
            else
            {
                return null;
            }
        }
        public BoxCheckDTO GetItemBoxCheck(long id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM BoxCheck WHERE Id = " + id);
            if (data.Rows.Count > 0)
            {
                BoxCheckDTO boxCheckDTO = new BoxCheckDTO(data.Rows[0]);
                return boxCheckDTO;
            }
            else
            {
                return null;
            }
        }
        public bool InsertBoxCheck(string CheckCode,string PartCode,DateTime DateCheck,string EmployessCheck,int CountCheck,string LotNo,string QrCode,int StatusCheck,string Note,string MoldNumber,string MachineCode,string POCode)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-CA");
            string query = string.Format("INSERT INTO [dbo].[BoxCheck] ([CheckCode],[PartCode],[DateCheck],[EmployessCheck],[CountCheck],[LotNo],[QrCode],[StatusCheck],[Note],[MoldNumber],[MachineCode],[POCode]" +
                " ) VALUES (N'{0}',N'{1}','{2}',N'{3}',{4},N'{5}',N'{6}',{7},N'{8}',N'{9}',N'{10}',N'{11}')", CheckCode,PartCode,DateCheck,EmployessCheck,CountCheck,LotNo,QrCode,StatusCheck,Note,MoldNumber,MachineCode,POCode);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteBoxCheck(long Id)
        {
            string query = string.Format("DELETE [dbo].[BoxCheck] WHERE Id = {0}", Id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        #region CHECK DELIVERY
        public List<CheckDeliveryDTO> GetCheckDeliveryDTOs()
        {
            List<CheckDeliveryDTO> listC = new List<CheckDeliveryDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM CheckDelivery");
            foreach (DataRow item in data.Rows)
            {
                CheckDeliveryDTO c = new CheckDeliveryDTO(item);
                listC.Add(c);
            }
            return listC;
        }
        public List<CheckDeliveryDTO> GetCheckDeliveryDTOs(long IdDe)
        {
            List<CheckDeliveryDTO> listC = new List<CheckDeliveryDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM CheckDelivery WHERE IdDe = "+IdDe);
            foreach (DataRow item in data.Rows)
            {
                CheckDeliveryDTO c = new CheckDeliveryDTO(item);
                listC.Add(c);
            }
            return listC;
        }
        public List<CheckDeliveryDTO> GetCheckDeliveryDTOsPOCode(string checkCode,string POCode)
        {
            List<CheckDeliveryDTO> listC = new List<CheckDeliveryDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM CheckDelivery WHERE CheckCode = N'"+checkCode+"' AND POCode = N'" + POCode+"'");
            foreach (DataRow item in data.Rows)
            {
                CheckDeliveryDTO c = new CheckDeliveryDTO(item);
                listC.Add(c);
            }
            return listC;
        }
        public List<CheckDeliveryDTO> GetCheckDeliveryDTOs(string CheckCode)
        {
            List<CheckDeliveryDTO> listC = new List<CheckDeliveryDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM CheckDelivery WHERE CheckCode = N'"+CheckCode+"'");
            foreach (DataRow item in data.Rows)
            {
                CheckDeliveryDTO c = new CheckDeliveryDTO(item);
                listC.Add(c);
            }
            return listC;
        }
        public List<CheckDeliveryDTO> GetCheckDeliveryDTOs(string checkCode, string partCode, string Factory,string POCode)
        {
            List<CheckDeliveryDTO> listC = new List<CheckDeliveryDTO>();
            string query = string.Format("SELECT * FROM CheckDelivery WHERE CheckCode = N'{0}' AND PartCode = N'{1}' AND FactoryCode = N'{2}' AND POCode = N'{3}'",checkCode,partCode,Factory,POCode);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                CheckDeliveryDTO c = new CheckDeliveryDTO(item);
                listC.Add(c);
            }
            return listC;
        }
        public List<CheckDeliveryDTO> GetCheckDeliveryDTOs(string checkCode, string partCode, string Factory, string POCode, int StatusCheck)
        {
            List<CheckDeliveryDTO> listC = new List<CheckDeliveryDTO>();
            string query = string.Format("SELECT * FROM CheckDelivery WHERE CheckCode = N'{0}' AND PartCode = N'{1}' AND FactoryCode = N'{2}' AND POCode = N'{3}' AND StatusCheck = {4}", checkCode, partCode, Factory, POCode,StatusCheck);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                CheckDeliveryDTO c = new CheckDeliveryDTO(item);
                listC.Add(c);
            }
            return listC;
        }
        public CheckDeliveryDTO GetItemCheck(string checkCode, string partCode, string Factory, string POCode, int StatusCheck)
        {
            return GetCheckDeliveryDTOs(checkCode, partCode, Factory,POCode,StatusCheck).FirstOrDefault();
        }

        public List<CheckDeliveryDTO> GetCheckDeliveryDTOs(string CheckCode, int Status)
        {
            List<CheckDeliveryDTO> listC = new List<CheckDeliveryDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM CheckDelivery WHERE CheckCode = N'" + CheckCode + "' AND StatusCheck <> "+Status);
            foreach (DataRow item in data.Rows)
            {
                CheckDeliveryDTO c = new CheckDeliveryDTO(item);
                listC.Add(c);
            }
            return listC;
        }
        public bool InsertCheck(string CheckCode,long IdDe,string Employess,string PartCode,int QuantityCheck,int QuantityOut,string FactoryCode,string Note,int StatusCheck,string POCode)
        {
            string query = string.Format("INSERT INTO [dbo].[CheckDelivery] ([CheckCode],[IdDe],[Employess],[PartCode],[QuantityCheck],[QuantityOut],[FactoryCode],[Note],[StatusCheck],[POCode])" +
                " VALUES(N'{0}',{1},N'{2}',N'{3}',{4},{5},N'{6}',N'{7}',{8},N'{9}')",CheckCode,IdDe,Employess,PartCode,QuantityCheck,QuantityOut,FactoryCode,Note, StatusCheck, POCode);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateCheck(long id, int quantityCheck)
        {
            string query = string.Format("UPDATE [dbo].[CheckDelivery] SET [QuantityCheck] = {1} WHERE Id = {0}",id,quantityCheck);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateStatusCheck(long id, int StatusCheck)
        {
            string query = string.Format("UPDATE [dbo].[CheckDelivery] SET [StatusCheck] = {1} WHERE Id = {0}", id, StatusCheck);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateStatusCheck(long id, int StatusCheck,string Note)
        {
            string query = string.Format("UPDATE [dbo].[CheckDelivery] SET [StatusCheck] = {1}, [Note] = N'{2}' WHERE Id = {0}", id, StatusCheck,Note);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteCheck(long id)
        {
            string query = string.Format("DELETE [dbo].[CheckDelivery] WHERE Id = {0}",id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public int SumQuantityOut(string checkCode,string partCode,string poCode,string Factory)
        {
            int sum = 0;
            List<CheckDeliveryDTO> listC = GetCheckDeliveryDTOs(checkCode).Where(x => x.PartCode == partCode && x.POCode == poCode && x.FactoryCode == Factory && x.StatusCheck != 1).ToList();
            foreach (CheckDeliveryDTO item in listC)
            {
                sum += item.QuantityOut;
            }
            return sum;
        }
        public int SumQuantityCheck(string checkCode, string partCode, string poCode, string Factory)
        {
            int sum = 0;
            List<CheckDeliveryDTO> listC = GetCheckDeliveryDTOs(checkCode).Where(x => x.PartCode == partCode && x.POCode == poCode && x.FactoryCode == Factory && x.StatusCheck != 1).ToList();
            foreach (CheckDeliveryDTO item in listC)
            {
                sum += item.QuantityCheck;
            }
            return sum;
        }
        public int SumQuantityOutALL(string checkCode, string partCode, string poCode, string Factory)
        {
            int sum = 0;
            List<CheckDeliveryDTO> listC = GetCheckDeliveryDTOs(checkCode).Where(x => x.PartCode == partCode && x.POCode == poCode && x.FactoryCode == Factory).ToList();
            foreach (CheckDeliveryDTO item in listC)
            {
                sum += item.QuantityOut;
            }
            return sum;
        }
        public int SumQuantityCheckALL(string checkCode, string partCode, string poCode, string Factory)
        {
            int sum = 0;
            List<CheckDeliveryDTO> listC = GetCheckDeliveryDTOs(checkCode).Where(x => x.PartCode == partCode && x.POCode == poCode && x.FactoryCode == Factory).ToList();
            foreach (CheckDeliveryDTO item in listC)
            {
                sum += item.QuantityCheck;
            }
            return sum;
        }
        #endregion
    }
}
