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
using System.IO;
using DevExpress.XtraGrid.Views.Grid;
using DTO;
using System.Net.Mail;
using System.Threading;
using System.Net;
using System.Globalization;
using System.Data.SqlClient;
using WareHouse.Report;
using DevExpress.XtraReports.UI;
using WareHouse.Common;

namespace WareHouse.Mold
{
    public partial class frmMoldInfor : DevExpress.XtraEditors.XtraForm
    {

        public frmMoldInfor()
        {

            InitializeComponent();
            LoadControl();
        }
        public bool IsInsert = false;
        #region Control
        void LoadControl()
        {
            LoadCate();
            AsyncLoad();
            LoadData();
            LockControl();
            LoadMoldCode(); ;
        }
        async void LoadCate()
        {
            await LoadCategory();
        }
        public static async Task LoadCategory()
        {
            await Task.Run(() =>
            {
                List<MoldDTO> listK = MoldDAO.Instance.GetListMold();
                foreach (MoldDTO item in listK)
                {
                    string MoldeCode = item.MoldCode;
                    int kTest = MoldDAO.Instance.MaxId(MoldeCode);
                    if (kTest > 0)
                    {
                        string Category = MoldDAO.Instance.CategoryById(kTest);
                        MoldDAO.Instance.UpdateCategoryMold(MoldeCode, Category);
                    }
                }
            });
        }
        async void AsyncLoad()
        {
            await LoadMoldInfor();
            await SendMail();
        }
        public static async Task LoadMoldInfor()
        {
            await Task.Run(() =>
            {
                DateTime today = DateTime.Now;
                DateTime dateCheck = today;
                List<MoldInforDTO> listM = MoldDAO.Instance.GetListMoldInfor();
                foreach (MoldInforDTO item in listM)
                {
                    int ShotTT = item.ShotTT;
                    int ShotTC = item.ShotTC;
                    string MoldeCode = item.MoldCode;
                    int test = MoldDAO.Instance.TestConfirm(MoldeCode);
                    float total = (float)ShotTT / (float)ShotTC;
                    int a = 0;
                    int b = MoldDAO.Instance.ConfirmMold(MoldeCode);
                    if (test == 1)
                    {
                        MoldDAO.Instance.UpdateConfirmMoldInfor(MoldeCode, 4);
                    }
                    else
                    {
                        if (total > 0.9)
                        {
                            a = 3;
                            MoldDAO.Instance.UpdateConfirmMoldInfor(MoldeCode, a);
                        }
                        else if (total <= 0.9 && total > 0.8)
                        {
                            a = 2;
                            MoldDAO.Instance.UpdateConfirmMoldInfor(MoldeCode, a);
                        }
                        else
                        {
                            a = 0;
                            MoldDAO.Instance.UpdateConfirmMoldInfor(MoldeCode, a);
                            MoldDAO.Instance.UpdateNoteMoldInfor(item.MoldCode, "");
                            if((today - item.DateCheck).TotalDays >= 140)
                            {
                                MoldDAO.Instance.UpdateWainMoldInfor(MoldeCode, 1);
                            }
                            else if ((today - item.DateCheck).TotalDays <= 150 && (today - item.DateCheck).TotalDays > 140)
                            {
                                MoldDAO.Instance.UpdateWainMoldInfor(MoldeCode, 2);
                            }
                            else if ((today - item.DateCheck).TotalDays >= 160)
                            {
                                MoldDAO.Instance.UpdateWainMoldInfor(MoldeCode, 3);
                            }
                            else
                            {
                                if(item.Warn != 0)
                                MoldDAO.Instance.UpdateWainMoldInfor(MoldeCode, 0);
                            }
                        }
                    }
                }
            });
        }
        public static async Task SendMail()
        {
            await Task.Run(() =>
            {
                string message1 = "";
                string message2 = "";
                List<MoldInforDTO> listM2 = new List<MoldInforDTO>();
                List<MoldInforDTO> listM = MoldDAO.Instance.GetListMoldInfor();
                List<MoldInforDTO> listM1 = listM.Where(x => x.Confirm == 3 || x.Confirm == 2).ToList();
                List<MoldInforDTO> listMM = listM.Where(x => x.Warn >= 0).ToList();
                int dk = 0;
 
                if (listM1.Count > 0)
                {
                    dk = 1;
                    foreach (MoldInforDTO item in listM1)
                    {
                        if (item.PlanMold.Length <= 0)
                        {
                            message1 += item.MoldCode + " ;";
                        }
                    }
                }
                if (listMM.Count > 0)
                {
                    dk = 2;
                    foreach (MoldInforDTO item in listM)
                    {
                        message2 += item.MoldCode + " ;";
                    }
                }
                List<AccountDTO> Email = AccountDAO.Instance.GetAccountEmail(5);
                List<AccountDTO> EmailAll = AccountDAO.Instance.GetAccount().Where(x => x.EMail.Length > 5).ToList();
                if (dk == 1 && Email.Count > 0)
                {
                    string to = "";
                    foreach (AccountDTO item in Email)
                    {
                        to += item.EMail + ",";
                    }
                    string subject = "Cảnh báo khuôn chưa bảo dưỡng";
                    SendEMail.SendGMail(to, subject, message1);
                }
                else if (dk == 2 && EmailAll.Count > 0)
                {
                    string to = "";
                    foreach (AccountDTO item in Email)
                    {
                        to += item.EMail + ",";
                    }
                    string subject = "Cảnh báo khuôn cần cấp FA";
                    SendEMail.SendGMail(to, subject, message2);
                }
            });
        }
        void LoadMoldCode()
        {
            cbMoldCode.DataSource = MoldDAO.Instance.GetListMold();
            cbMoldCode.DisplayMember = "MoldCode";
            cbMoldCode.ValueMember = "MoldCode";
        }

        void LoadData()
        {
            GCData.DataSource = MoldDAO.Instance.GetListMoldInfor();
        }
        void LockControl()
        {
            cbMoldCode.Enabled = false;
            nudShotTC.Enabled = false;
            nudShotTT.Enabled = false;
            nudTotalShot.Enabled = false;
            cbCategory.Enabled = false;
            txtNote.Enabled = false;
            txtStatus.Enabled = false;
            txtPlan.Enabled = false;
            nudCav.Enabled = false;
            nudCavNG.Enabled = false;

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;

        }
        void OpenControl()
        {
            cbMoldCode.Enabled = true;
            nudShotTC.Enabled = true;
            nudShotTT.Enabled = true;
            nudTotalShot.Enabled = true;
            cbCategory.Enabled = true;
            txtNote.Enabled = true;
            txtStatus.Enabled = true;
            txtPlan.Enabled = true;
            nudCav.Enabled = true;
            nudCavNG.Enabled = true;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }
        void DeleteText()
        {
            cbMoldCode.Text = String.Empty;
            nudShotTC.Text = String.Empty;
            nudShotTT.Text = String.Empty;
            nudTotalShot.Text = String.Empty;
            cbCategory.Text = String.Empty;
            txtNote.Text = String.Empty;
            txtStatus.Text = String.Empty;
            txtPlan.Text = String.Empty;
            nudCav.Text = String.Empty;
            nudCavNG.Text = String.Empty;
        }
        void AddText()
        {
            try
            {
                cbMoldCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["MoldCode"]).ToString();
                nudShotTC.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["ShotTC"]).ToString();
                nudShotTT.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["ShotTT"]).ToString();
                nudTotalShot.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["TotalShot"]).ToString();
                cbCategory.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Category"]).ToString();
                txtNote.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Note"]).ToString();
                txtStatus.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["StatusMold"]).ToString();
                txtPlan.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["PlanMold"]).ToString();
                nudCav.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Cav"]).ToString();
                nudCavNG.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["CavNG"]).ToString();
            }
            catch
            {

            }
        }
        #endregion
        #region Event
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(5, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            OpenControl();
            DeleteText();
            IsInsert = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(5, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            OpenControl();
            IsInsert = false;
            cbMoldCode.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(5, Kun_Static.accountDTO.Type, user);
            if (check < 2)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("bạn thực sự muốn xóa thông tin này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    string MoldCode = gridView1.GetRowCellValue(item, "MoldCode").ToString();
                    MoldDAO.Instance.DeleteMoldInfor(MoldCode);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string MoldCode = cbMoldCode.Text;
            int ShotTC = (int)nudShotTC.Value;
            int ShotTT = (int)nudShotTT.Value;
            int TotalShot = (int)nudTotalShot.Value;
            int Confirm = 0;
            string Category = cbCategory.Text;
            string cav = nudCav.Value.ToString();
            string Note = txtNote.Text;
            string statusMold = txtStatus.Text;

            string cavNG = nudCavNG.Value.ToString();
            string planMold = txtPlan.Text;
            if (IsInsert == true)
            {
                try
                {
                    MoldDAO.Instance.InsertMoldInfor(MoldCode, ShotTC, ShotTT, TotalShot, Confirm, Category, Note, statusMold, cav, cavNG, planMold, DateTime.Now, 0);
                    MessageBox.Show("thêm thông tin thành công !".ToUpper());
                    LoadControl();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("mã khuôn đã tồn tại".ToUpper(), "Thông Bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else
            {
                MoldDAO.Instance.UpdateMoldInfor(MoldCode, ShotTC, ShotTT, TotalShot, Category, Note, statusMold, cav, cavNG, planMold);
                MessageBox.Show("sửa thông tin thành công !".ToUpper());
                LoadControl();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(5, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmInportMoldInfor f = new frmInportMoldInfor();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            frmFormMoldInfor f = new frmFormMoldInfor();
            f.ShowDialog();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            #region Xuất Excel
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;

                    switch (fileExtenstion)
                    {
                        case ".xls":
                            GCData.ExportToXls(exportFilePath);
                            break;
                        case ".xlsx":
                            GCData.ExportToXlsx(exportFilePath);
                            break;
                        case ".rtf":
                            GCData.ExportToRtf(exportFilePath);
                            break;
                        case ".pdf":
                            GCData.ExportToPdf(exportFilePath);
                            break;
                        case ".html":
                            GCData.ExportToHtml(exportFilePath);
                            break;
                        case ".mht":
                            GCData.ExportToMht(exportFilePath);
                            break;
                        default:
                            break;
                    }

                    if (File.Exists(exportFilePath))
                    {
                        try
                        {
                            //Try to open the file and let windows decide how to open it.
                            System.Diagnostics.Process.Start(exportFilePath);
                        }
                        catch
                        {
                            String msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        String msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                        MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            #endregion
        }
        private void GCData_Click(object sender, EventArgs e)
        {
            AddText();
        }

        #endregion
        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {

            GridView view = sender as GridView;
            if (e.RowHandle >= 0) // chỉ xử lý trong cột họ tên thôi 
            {
                string MoldeCode = view.GetRowCellValue(e.RowHandle, view.Columns["MoldCode"]).ToString();
                int a = MoldDAO.Instance.ConfirmMold(MoldeCode);
                switch (a)
                {
                    case 1:
                        e.Appearance.BackColor = Color.Purple;
                        e.Appearance.ForeColor = Color.White;
                        break;
                    case 2:
                        e.Appearance.BackColor = Color.Orange;
                        e.Appearance.ForeColor = Color.White;
                        break;
                    case 3:
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        break;
                    case 4:
                        e.Appearance.BackColor = Color.Yellow;
                        e.Appearance.ForeColor = Color.Black;
                        break;
                    case -5:
                        e.Appearance.BackColor = Color.Gray;
                        e.Appearance.ForeColor = Color.Red;
                        break;
                    default:
                        {
                            int wain = int.Parse(view.GetRowCellValue(e.RowHandle, view.Columns["Warn"]).ToString());
                            if (wain == 1)
                            {
                                e.Appearance.BackColor = Color.LightBlue;
                            }
                            else if (wain == 2)
                            {
                                e.Appearance.BackColor = Color.SlateGray;
                            }
                            else if(wain == 2)
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.White;
                            }
                            
                        }
                        break;
                }
            }
        }
        #region Publich Infor
        public class MoldInfor
        {
            static public string moldCode;
            static public int shotTT;
            static public int totalShot;
        }
        #endregion
        private void btnConfirm_Click(object sender, EventArgs e)
        {

            if (cbMoldCode.Text.Length > 0)
            {
                int confirm = MoldDAO.Instance.ConfirmMold(cbMoldCode.Text);
                if (confirm == 3)
                {
                    MoldInfor.moldCode = cbMoldCode.Text;
                    frmMoldConfirm f = new frmMoldConfirm();
                    f.LamMoi += new EventHandler(btnUpdate_Click);
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("khuôn này vẫn chạy bình thường không cần xác nhận !".ToUpper());
                }
            }
            else
            {
                MessageBox.Show("bạn chưa chọn mã khuôn cần xác nhận".ToUpper());
            }
        }

        private void GCData_DoubleClick(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(5, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MoldInfor.moldCode = cbMoldCode.Text;
            MoldInfor.shotTT = (int)nudShotTT.Value;
            MoldInfor.totalShot = (int)nudTotalShot.Value;
            frmMoldDetail f = new frmMoldDetail();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }

        private void btnWarn_Click(object sender, EventArgs e)
        {
            string today = dtpkWarn.Text;
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(5, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("bạn muốn chuyển trạng thái khuôn chờ ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    string mold = gridView1.GetRowCellValue(item, "MoldCode").ToString();
                    MoldDAO.Instance.UpdateWainMoldInfor(mold, -1);
                }
                LoadControl();
            }
        }

        private void btnInputMold_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(5, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmInputMold f = new frmInputMold();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(5, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<QRCodeMoldDTO> listQ = new List<QRCodeMoldDTO>();
            string moldCode = cbMoldCode.Text;
            string moldName = "";
            string moldNumber = "";
            string dateSX = "";
            int shotTC = (int)nudShotTC.Value;
            int shotTT = (int)nudShotTT.Value;
            int totalShot = (int)nudTotalShot.Value;
            string category = cbCategory.Text;
            int IdCategory = MoldDAO.Instance.IdErrorMold(category);
            string cav = nudCav.Value.ToString();
            string QrCode = "";
            if (moldCode.Length > 0)
            {
                List<MoldDTO> listM = MoldDAO.Instance.GetListMold().Where(x => x.MoldCode == moldCode).ToList();
                foreach (MoldDTO item in listM)
                {
                    moldName = item.MoldName;
                    moldNumber = item.MoldNumber;
                    dateSX = item.DateSX.ToString();
                }
                QrCode = moldCode + "&" + moldName + "&" + moldNumber + "&" + dateSX + "&" + shotTC + "&" + shotTT + "&" + totalShot + "&" + cav + "&" + IdCategory.ToString();
                listQ.Add(new QRCodeMoldDTO(moldCode, moldName, moldNumber, dateSX, shotTC, shotTT, totalShot, cav, IdCategory.ToString(), QrCode));
                rpQrCodeMold rp = new rpQrCodeMold();
                rp.DataSource = listQ;
                rp.PrintDialog();
                MoldDAO.Instance.UpdateConfirmMoldInfor(moldCode, -5);
                EditHistoryDAO.Instance.Insert(DateTime.Now, Kun_Static.accountDTO.UserName, "Đã chuyển khuôn : " + moldCode, "");
                LoadControl();
            }
            else
            {
                MessageBox.Show("bạn chưa chọn mã khuôn cần chuyển !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}