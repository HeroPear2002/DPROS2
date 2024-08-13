using DevExpress.XtraEditors;
using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using WareHouse.PO_and_Order;
using WareHouse.WareHouseMaterial;

namespace WareHouse
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Office 2016 Colorful", "Office Blue");
            WindowsFormsSettings.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new fLogin());
        }
        private static void initCulturalFormattingChanges()
        {
            CultureInfo cultureDefinition = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
            cultureDefinition.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            cultureDefinition.DateTimeFormat.ShortTimePattern = "HH:mm:ss tt";
            Thread.CurrentThread.CurrentCulture = cultureDefinition;
        }
    }
}
