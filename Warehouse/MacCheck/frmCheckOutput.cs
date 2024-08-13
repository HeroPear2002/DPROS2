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
using DTO;
using DevExpress.XtraGrid.Views.Grid;
using System.Net.Mail;
using System.Net;
using WareHouse.Report;
using DevExpress.XtraReports.UI;

namespace WareHouse.PCGridControl
{
    public partial class frmCheckOutput : DevExpress.XtraEditors.XtraForm
    {
        public frmCheckOutput()
        {
            InitializeComponent();
            LoadControl();
        }
        void LoadControl()
        {
            LoadAsyncStatus();
            LoadData();
            LoadAsyncSend();
        }
        async void LoadAsyncStatus()
        {
           await LoadStatus();
        }
       async void LoadAsyncSend()
        {
            if(Kun_Static.accountDTO.Type != 1)
            {
                await SendMail();
            }
        }
        public static async Task LoadStatus()
        {
            await Task.Run(() =>
            {
                DateTime today = DateTime.Now;
            List<CheckDeliveryDTO> listCheck = BoxCheckDAO.Instance.GetCheckDeliveryDTOs();
            foreach (CheckDeliveryDTO item in listCheck)
            {
                if(item.QuantityOut == item.QuantityCheck)
                {
                    BoxCheckDAO.Instance.UpdateStatusCheck(item.Id, 1, "Đã kiểm tra");
                }
                else if(item.StatusCheck == 0)
                {
                    DateTime lotNo = DeliveryDAO.Instance.GetItemDelivery(item.IdDe).DateDelivery;
                    if ((today-lotNo).TotalHours > -1)
                    {
                        BoxCheckDAO.Instance.UpdateStatusCheck(item.Id, 2,"Chưa kiểm tra");
                    }
                }
            }
            });
        }
        #region gửi mail
        public static async Task SendMail()
        {
            await Task.Run(() =>
            {
                List<string> listMail = new List<string>();
                List<CheckDeliveryDTO> listB = BoxCheckDAO.Instance.GetCheckDeliveryDTOs().Where(x=>x.StatusCheck == 2).ToList();
                string message = "";
                foreach (CheckDeliveryDTO item in listB)
                {
                    message += item.POCode + ";";
                }
                List<AccountDTO> listEmail = AccountDAO.Instance.GetAccountEmail(2);
                if (listB.Count > 0 && listEmail.Count > 0)
                {
                    string from = "system.dongduongpla@gmail.com";
                    foreach (AccountDTO item in listEmail)
                    {
                        string to = item.EMail;
                        string subject = "Có PO chưa được check".ToUpper();
                        MailMessage mess = new MailMessage(from, to, subject, message);
                        SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                        client.EnableSsl = true;
                        client.Credentials = new NetworkCredential("system.dongduongpla@gmail.com", "hkasfjovfnbnamne");
                        try
                        {
                            client.Send(mess);
                        }
                        catch
                        {
                        }
                    }
                }
            });
        }
        #endregion
        void LoadData()
        {
            List<CheckDeliveryDTO> listCheck = BoxCheckDAO.Instance.GetCheckDeliveryDTOs();
            GCData.DataSource = listCheck.OrderByDescending(x=>x.StatusCheck);
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(2, Kun_Static.accountDTO.Type, user);
            if (check < 2)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("bạn muốn xác nhận thông tin này?".ToUpper(), "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    long id = long.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    BoxCheckDAO.Instance.UpdateStatusCheck(id, 3,"Đã xác nhận");
                }
                LoadControl();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(2, Kun_Static.accountDTO.Type, user);
            if (check < 2)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(MessageBox.Show("bạn muốn xóa thông tin này?".ToUpper(),"Thông báo",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    long id = long.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    BoxCheckDAO.Instance.DeleteCheck(id);
                }
                LoadControl();
            }

        }

        private void btnReOldCheck_Click(object sender, EventArgs e)
        {
            Kun_Static.Style = 12;
            string checkCode = LoadText();
            if (checkCode.Length == 0)
            {
                MessageBox.Show("bạn hãy chọn mã Check !".ToUpper(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Kun_Static.CheckCode = checkCode;
            frmEmployessCode f = new frmEmployessCode();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }

        private void btnCheckOld_Click(object sender, EventArgs e)
        {
            Kun_Static.Style = 11;
            string checkCode = LoadText();
            if(checkCode == "")
            {
                MessageBox.Show("bạn hãy chọn mã Check !".ToUpper(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Kun_Static.CheckCode = checkCode;
            Kun_Static.CheckCode = LoadText();
            frmEmployessCode f = new frmEmployessCode();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }

        private void btnCheckNew_Click(object sender, EventArgs e)
        {
            Kun_Static.Style = 10;
            frmEmployessCode f = new frmEmployessCode();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }
        string LoadText()
        {
            string a = "";
            foreach (var item in gridView1.GetSelectedRows())
            {
                a = gridView1.GetRowCellValue(item, "CheckCode").ToString();
            }
            return a;
        }
        private void GCData_Click(object sender, EventArgs e)
        {
            LoadText();
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if(e.RowHandle >= 0)
            {
                int status = int.Parse(view.GetRowCellValue(e.RowHandle, view.Columns["StatusCheck"]).ToString());
                if(status == 2)
                {
                    e.Appearance.BackColor = Color.Red;
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            rpYesOrNo rp = new rpYesOrNo();
            rp.PrintDialog();
        }
    }
}