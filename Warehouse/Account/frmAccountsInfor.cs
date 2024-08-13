using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DAO;
using DevExpress.XtraGrid.Views.Grid;
using DTO;

namespace WareHouse.Account
{
    public partial class frmAccountsInfor : DevExpress.XtraEditors.XtraForm
    {
        public frmAccountsInfor()
        {
            InitializeComponent();
            LoadControl();
        }
        void LoadControl()
        {
            LoadDataAccount();
            LoadAccountInfor();
        }
        void LoadDataAccount()
        {
            int type = Kun_Static.accountDTO.Type;
            switch (type)
            {
                case 1:
                    GCDataAccout.DataSource = AccountDAO.Instance.GetAccount();
                    break;
                case 3:
                    GCDataAccout.DataSource = AccountDAO.Instance.GetAccount().Where(x => x.Type == 3).ToList();
                    break;
                case 4:
                    GCDataAccout.DataSource = AccountDAO.Instance.GetAccount().Where(x => x.Type == 4).ToList();
                    break;
                case 8:
                    List<AccountDTO> listA = new List<AccountDTO>();
                    List<AccountDTO> listA38 = AccountDAO.Instance.GetAccount().Where(x => x.Type == 3|| x.Type == 4 || x.Type == 5 || x.Type == 8).ToList();
                    foreach (AccountDTO item in listA38)
                    {
                        listA.Add(new AccountDTO(item.UserName, item.DisplayName, item.PassWord, item.Type, item.Decentraliza, item.EMail,item.RoomCode));
                    }
                    GCDataAccout.DataSource = listA;
                    break;
                default:
                    GCDataAccout.DataSource = AccountDAO.Instance.GetAccount().Where(x => x.Type == Kun_Static.accountDTO.Type);
                    break;
            }
        }
        void LoadAccountInfor()
        {
            int type = Kun_Static.accountDTO.Type;
            switch (type)
            {
                case 1:
                    GCAccountInfor.DataSource = AccountDAO.Instance.GetListAccountInfor();
                    break;
                case 3:
                    GCAccountInfor.DataSource = AccountDAO.Instance.GetListAccountInforBytype(Kun_Static.accountDTO.Type);
                    break;
                case 4:
                    GCAccountInfor.DataSource = AccountDAO.Instance.GetListAccountInforBytype(Kun_Static.accountDTO.Type);
                    break;
                case 8:
                    GCAccountInfor.DataSource = AccountDAO.Instance.GetListAccountInforBytypeNew();
                    break;
                default:
                    GCAccountInfor.DataSource = AccountDAO.Instance.GetListAccountInforBytype(Kun_Static.accountDTO.Type);
                    break;
            }

        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0)
            {

                string userName = view.GetRowCellValue(e.RowHandle, view.Columns["UserName"]).ToString();
                int Status = AccountDAO.Instance.PermissionAccount(userName);
                switch (Status)
                {
                    case 1:
                        e.Appearance.BackColor = Color.Yellow;
                        e.Appearance.ForeColor = Color.Black;
                        break;
                    case 2:
                        e.Appearance.BackColor = Color.Green;
                        e.Appearance.ForeColor = Color.White;
                        break;
                    default:
                        break;
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int permission = 0;
            try
            {
                permission = int.Parse(icbImage.EditValue.ToString());
            }
            catch
            {
                MessageBox.Show("bạn chưa chọn quyền cho User !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string user = Kun_Static.accountDTO.UserName;
            int testAcc = AccountDAO.Instance.PermissionAccount(user);
            if (testAcc < 2)
            {
                MessageBox.Show("bạn muốn cấp quyền cho User này?".ToUpper(), "Thông Báo", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
                if (MessageBox.Show("bạn muốn cấp quyền cho User này?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView2.GetSelectedRows())
                {
                    string UserName = gridView2.GetRowCellValue(item, "UserName").ToString();
                    AccountDAO.Instance.InsertAccountInfor(UserName, permission);
                }
                LoadControl();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int testAcc = AccountDAO.Instance.PermissionAccount(user);
            if (testAcc < 2)
            {
                MessageBox.Show("bạn muốn cấp quyền cho User này?".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("bạn muốn cấp quyền cho User này?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    string UserName = gridView1.GetRowCellValue(item, "UserName").ToString();
                    AccountDAO.Instance.DeleteAccountInfor(UserName);
                }
                LoadControl();
            }
        }
    }
}