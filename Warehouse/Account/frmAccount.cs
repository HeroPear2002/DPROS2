using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using DAO;
using DTO;

namespace WareHouse.Account
{
    public partial class frmAccount : Form
    {

        public frmAccount()
        {
            InitializeComponent();
            LoadControl();
        }
        bool IsInsert = false;
        void LoadControl()
        {
            LoadData();
            XoaText();
            KhoaDK();
            LoadDecentraliza();
            LoadRoom();
            ChangeAccount();
        }
        void ChangeAccount()
        {
            int type = Kun_Static.accountDTO.Type;
            if (type == 6)
            {
                txtUserName.Enabled = false;
                txtDisplayName.Enabled = false;
                txtPassWord.Enabled = false;
                cb.Enabled = false;
                txtEMail.Enabled = false;

                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                simpleButton1.Enabled = false;
            }
        }
        void KhoaDK()
        {
            txtUserName.Enabled = false;
            txtDisplayName.Enabled = false;
            txtPassWord.Enabled = false;
            cb.Enabled = false;
            txtEMail.Enabled = false;

            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
            simpleButton1.Enabled = false;
        }
        void MoKhoaDK()
        {
            txtUserName.Enabled = true;
            txtDisplayName.Enabled = true;
            txtPassWord.Enabled = true;
            cb.Enabled = true;
            txtEMail.Enabled = true;

            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            simpleButton1.Enabled = true;
        }
        void XoaText()
        {
            txtUserName.Text = String.Empty;
            txtDisplayName.Text = String.Empty;
            txtPassWord.Text = String.Empty;
            cb.Text = String.Empty;
            txtEMail.Text = String.Empty;
            cbRoomCode.Text = String.Empty;
        }
        void AddText()
        {
            try
            {
                txtUserName.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["UserName"]).ToString();
                txtDisplayName.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["DisplayName"]).ToString();
                cb.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Decentraliza"]).ToString();
                txtEMail.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["EMail"]).ToString();
                cbRoomCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["RoomCode"]).ToString();
            }
            catch
            {

            }
        }
        void LoadData()
        {
            if (Kun_Static.accountDTO.Type == 1)
            {
                GCData.DataSource = AccountDAO.Instance.GetAccount();
            }
            else if (Kun_Static.accountDTO.Type == 8)
            {
                GCData.DataSource = AccountDAO.Instance.GetAccount().Where(x => x.Type == 6 || x.Type == 3 || x.Type == 4 || x.Type == 5 || x.Type == 8);
            }
            else
            {
                GCData.DataSource = AccountDAO.Instance.GetAccount().Where(x => x.Type == 6 || x.Type == Kun_Static.accountDTO.Type);
            }
        }
        void LoadDecentraliza()
        {
            int type = Kun_Static.accountDTO.Type;
            if (type == 1)
            {
                cb.DataSource = AccountDAO.Instance.GetlistDecentraliza();
                cb.DisplayMember = "Decentraliza";
                cb.ValueMember = "Id";
            }
            else if (type == 8)
            {
                cb.DataSource = AccountDAO.Instance.GetlistDecentraliza8(type);
                cb.DisplayMember = "Decentraliza";
                cb.ValueMember = "Id";
            }
            else
            {
                cb.DataSource = AccountDAO.Instance.GetlistDecentraliza1(type);
                cb.DisplayMember = "Decentraliza";
                cb.ValueMember = "Id";
            }
        }
        void LoadRoom()
        {
            cbRoomCode.DataSource = EmployessDAO.Instance.GetListRoom();
            cbRoomCode.DisplayMember = "CodeRo";
            cbRoomCode.ValueMember = "CodeRo";
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string user = txtUserName.Text;
            string dis = txtDisplayName.Text;
            string pass = AccountDAO.Instance.ToMD5(txtPassWord.Text);
            int type = (cb.SelectedItem as DecentralizaDTO).Id;
            string email = txtEMail.Text;
            string roomCode = cbRoomCode.Text;
            if (IsInsert == true)
            {
                try
                {
                    AccountDAO.Instance.InsertAccount(user, pass, dis, type, email,roomCode);
                    MessageBox.Show("Thêm User thành công!");
                    LoadControl();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("User đã tồn tại !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else
            {
                AccountDAO.Instance.UpdateNewAccount(user, dis, type, email,roomCode);
                MessageBox.Show("Sửa User thành công!");
                LoadControl();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn thực sự muốn xóa User này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    string User = gridView1.GetRowCellValue(item, "UserName").ToString();
                    AccountDAO.Instance.DeleteAccount(User);
                }
                LoadControl();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MoKhoaDK();
            XoaText();
            IsInsert = true;
        }

        private void btnRePass_Click(object sender, EventArgs e)
        {
            if (Kun_Static.accountDTO.Type != 1)
            {
                MessageBox.Show("bạn chưa được phân quyền ".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("bạn thực sự muốn Reset Password của User này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                string pass = AccountDAO.Instance.ToMD5("1");
                foreach (var item in gridView1.GetSelectedRows())
                {
                    string User = gridView1.GetRowCellValue(item, "UserName").ToString();
                    AccountDAO.Instance.ResetPassword(User, pass);
                }
                LoadControl();
            }
        }

        private void GCData_Click(object sender, EventArgs e)
        {
            AddText();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            MoKhoaDK();
            txtPassWord.Enabled = false;
            txtUserName.Enabled = false;
            IsInsert = false;
        }
    }
}
