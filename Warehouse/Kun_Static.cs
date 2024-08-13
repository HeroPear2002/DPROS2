using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse.WareHouseMaterial;

namespace WareHouse
{
   public class Kun_Static
    {
        public static int HistoryMainten = 0;
        public static string EmployessCode = null;
        public static AccountDTO accountDTO = null;
        public static int Style = 0;
        public static int IdWh = 0;
        public static string NameWhMaterial = "";
        public static int IdWhMaterial = 0;
        public static int TotalBox = 0;
        public static long IdDe = 0;
        public static string FactoryCode = "";
        public static long IdPOInput = 0;
        public static List<MaterialByDTO> listMReturn = new List<MaterialByDTO>();
        public static long IdPOMaterial = 0;
        public static string MachineCode = "";
        public static int idCheck;
        public static int DeviceId = 0;
        public static string QrCodeMachine = "";
        public static string CheckCode = "";
        public static string POCode = "";
        public static string ReceiptCode = "";
        public static string MessageBoxDetail = "";
        public static int MessageBoxValue = 0;
        public static int CountBoxCycle = 0;
        public static int CheckCycle = 0;
        public static int CheckOutMateial = 0;
        public static string NoteCTSX = "";
        public static OutputMaterial outputMaterial = null;
        public static int CountCon = 900;
        public static string CheckAdd = "";
    }
}
