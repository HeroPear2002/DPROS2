using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DevExpress.XtraSplashScreen;
using DTO;
using WareHouse.Employess;

namespace WareHouse
{
    public partial class fLogin : Form
    {
        public const int LOCALE_USER_DEFAULT = 0x00000400;
        public const int LOCALE_SSHORTDATE = 0x0000001F;
        public const int LOCALE_STIMEFORMAT = 0x1003;
        public const int LOCALE_SSHORTTIME = 0x0079;

        public const int BSF_QUERY = 0x00000001;
        public const int BSF_IGNORECURRENTTASK = 0x00000002;
        public const int BSF_FLUSHDISK = 0x00000004;
        public const int BSF_NOHANG = 0x00000008;
        public const int BSF_POSTMESSAGE = 0x00000010;
        public const int BSF_FORCEIFHUNG = 0x00000020;
        public const int BSF_NOTIMEOUTIFNOTHUNG = 0x00000040;
        public const int BSF_MSGSRV32ISOK = unchecked((int)0x80000000);
        public const int BSF_MSGSRV32ISOK_BIT = 31;

        public const int BSM_ALLCOMPONENTS = 0x00000000;
        public const int BSM_VXDS = 0x00000001;
        public const int BSM_NETDRIVER = 0x00000002;
        public const int BSM_INSTALLABLEDRIVERS = 0x00000004;
        public const int BSM_APPLICATIONS = 0x00000008;
        public const int BSM_ALLDESKTOPS = 0x00000010;

        public const int WM_WININICHANGE = 0x001A;

        [DllImport("Kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern Boolean SetLocaleInfo(int Locale, int LCType, string lpLCData);

        [DllImport("User32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int BroadcastSystemMessage(int flags, ref int lpInfo, uint Msg, uint wParam, IntPtr lParam);
        void SetupDate()
        {
            if (SetLocaleInfo(LOCALE_USER_DEFAULT, LOCALE_SSHORTDATE, "dd/MM/yyyy"))
            {
                int dwRecipients = BSM_APPLICATIONS | BSM_ALLDESKTOPS;
                string sString = "intl";
                GCHandle GCH = GCHandle.Alloc(sString, GCHandleType.Pinned);
                IntPtr pString = GCH.AddrOfPinnedObject();
                BroadcastSystemMessage(BSF_FORCEIFHUNG | BSF_IGNORECURRENTTASK | BSF_NOHANG | BSF_NOTIMEOUTIFNOTHUNG, ref dwRecipients, WM_WININICHANGE, 0, pString);
            }
        }
        public fLogin()
        {
            InitializeComponent();
            LoadControl();
            SetupDate();
        }
        void LoadControl()
        {
            this.AcceptButton = btnLogin;
            this.CancelButton = btnExit;
        }
        void XoaText()
        {
            txbPassWord.Text = String.Empty;
        }
        bool Login(string userName, string passWord)
        {
            return AccountDAO.Instance.Login(userName, passWord);
           
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txbUseName.Text;
            string passWord = AccountDAO.Instance.ToMD5(txbPassWord.Text);
            if (Login(userName, passWord))
            {
               
                AccountDTO loginAccount = AccountDAO.Instance.GetAccountByUser(userName);
                Kun_Static.accountDTO = loginAccount;
               frmMainMenu f = new frmMainMenu();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu".ToUpper());
                txbPassWord.SelectAll();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
           DateTime today = DateTime.Now;
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình ?".ToUpper(),"Thông báo",MessageBoxButtons.OKCancel)!=System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
            if (Kun_Static.accountDTO != null && today.Hour == 17)
            {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(frmWaitForm), true, true, false);
                string dataBase = "WHDD2";
                string disk = @"\\192.168.2.10\data\DONG DUONG 2\IT\000.BACKUP\DPROS2\" + dataBase + "-" + DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss");
                BackupDAO.Instance.BackupDataBase(dataBase, disk);
                SplashScreenManager.CloseForm(false);
                }
            catch
            {

            }

            }

        }
    }
}
