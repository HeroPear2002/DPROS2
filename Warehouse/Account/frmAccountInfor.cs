using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;

namespace WareHouse.Account
{
    public partial class frmAccountInfor : Form
    {
        public frmAccountInfor()
        {
            InitializeComponent();
            ChangeAccount();
        }
        void XoaText()
        {
            txtNewPass.Text = String.Empty;
            txtReNewPass.Text = String.Empty;
            txtPass.Text = String.Empty;
        }
        void ChangeAccount()
        {
            txtUserName.Text = Kun_Static.accountDTO.UserName;
            txtDisplayName.Text = Kun_Static.accountDTO.DisplayName;
        }
        void updateAccount()
        {
            string displayName = txtDisplayName.Text;
            string password = AccountDAO.Instance.ToMD5(txtPass.Text);
            string newpass = AccountDAO.Instance.ToMD5(txtNewPass.Text);
            string renewpass = AccountDAO.Instance.ToMD5(txtReNewPass.Text);
            string userName = txtUserName.Text;

            if (!newpass.Equals(renewpass))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu đúng với mật khẩu mới!");
            }
            else
            {
                if (AccountDAO.Instance.UpdateAccount(userName, displayName, password, newpass))
                {
                    MessageBox.Show("Cập nhật thành công");
                    /*if (updateAccount != null)
                        updateAccount(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(userName)));*/
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đúng mật khấu");
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            updateAccount();
            XoaText();
        }
    }
}
