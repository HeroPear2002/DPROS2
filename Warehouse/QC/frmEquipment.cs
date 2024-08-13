using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;

namespace WareHouse.QC
{
    public partial class frmEquipment : Form
    {
   

        public frmEquipment()
        {
            InitializeComponent();
            LoadControl();
        }
        public bool Isinsert = false;


        #region Control
        void LoadControl()
        {
            LoadStatusCheck();
            LoadData();
            LockControl();
        }
        void LoadData()
        {
            GCData.DataSource = EquipmentDAO.Instance.GetListEquipment();
        }
        void LockControl()
        {
            txtCode.Enabled = false;
            txtName.Enabled = false;
            txtModel.Enabled = false;
            txtSerial.Enabled = false;
            txtMaker.Enabled = false;
            txtStatus.Enabled = false;
            nudCycle.Enabled = false;
            dtpkDateInput.Enabled = false;

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
        }
        void OpenControl()
        {
            txtCode.Enabled = true;
            txtName.Enabled = true;
            txtModel.Enabled = true;
            txtSerial.Enabled = true;
            txtMaker.Enabled = true;
            txtStatus.Enabled = true;
            nudCycle.Enabled = true;
            dtpkDateInput.Enabled = true;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }
        void DeleteText()
        {
            txtCode.Text = String.Empty;
            txtName.Text = String.Empty;
            txtModel.Text = String.Empty;
            txtSerial.Text = String.Empty;
            txtMaker.Text = String.Empty;
            txtStatus.Text = String.Empty;
            nudCycle.Text = String.Empty;
            dtpkDateInput.Text = String.Empty;
        }
        void AddText()
        {
            try
            {
                txtCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["EquipmentCode"]).ToString();
                txtName.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["EquipmentName"]).ToString();
                txtModel.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Model"]).ToString();
                txtSerial.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Serial"]).ToString();
                txtMaker.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Maker"]).ToString();
                txtStatus.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Status"]).ToString();
                nudCycle.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Cycle"]).ToString();
                dtpkDateInput.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["DateInput"]).ToString();
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
            int check = AccountDAO.Instance.CheckAccount(4, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            OpenControl();
            DeleteText();
            Isinsert = true;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(4, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            OpenControl();
            txtCode.Enabled = false;
            Isinsert = false;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(4, Kun_Static.accountDTO.Type, user);
            if (check < 2)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("bạn thực sự muốn xóa thông tin này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    string Code = gridView1.GetRowCellValue(item, "EquipmentCode").ToString();
                    EquipmentDAO.Instance.DeleteEquipment(Code);
                }
                LoadControl();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string EquipmentCode = txtCode.Text;
            string EquipmentName = txtName.Text;
            string Model = txtModel.Text;
            string Serial = txtSerial.Text;
            string Maker = txtMaker.Text;
            string Status = txtStatus.Text;
            int Cycle = (int)nudCycle.Value;
            int StatusMail = 0;
            DateTime dateInput = dtpkDateInput.Value;
            if (Isinsert == true)
            {
                EquipmentDAO.Instance.InsertEquipment(EquipmentCode, EquipmentName, Model, Serial, Maker, Status, Cycle, StatusMail, dateInput);
                MessageBox.Show("thêm thông tin thành công !".ToUpper());
                LoadControl();
            }
            else
            {
                EquipmentDAO.Instance.UpdateEquipment(EquipmentCode, EquipmentName, Model, Serial, Maker, Status, Cycle, dateInput);
                MessageBox.Show("sửa thông tin thành công !".ToUpper());
                LoadControl();
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }
        private void btnQCCheck_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(4, Kun_Static.accountDTO.Type, user);
            if (check < 2)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("bạn đã liên lạc với Vendor để xác nhận hiệu chuẩn ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    string Code = gridView1.GetRowCellValue(item, "EquipmentCode").ToString();
                    EquipmentDAO.Instance.UpdateStatusMailEquipment(Code, 1);
                }
                LoadControl();
            }
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
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(4, Kun_Static.accountDTO.Type, user);
            if (check < 2)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmConfirmEquipment f = new frmConfirmEquipment();
            f.ShowDialog();
        }
        private void GCData_Click(object sender, EventArgs e)
        {
            AddText();
        }
        private void btnInport_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(4, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmInportEquipment f = new frmInportEquipment();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }
        private void btnDownload_Click(object sender, EventArgs e)
        {
            frmFormEquipment f = new frmFormEquipment();
            f.ShowDialog();
        }
        #endregion
        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0) // chỉ xử lý trong cột họ tên thôi 
            {
                string code = view.GetRowCellValue(e.RowHandle, view.Columns["EquipmentCode"]).ToString();
                int statusCheck = EquipmentDAO.Instance.StatusCheck(code);
                switch (statusCheck)
                {
                    case 1:
                        e.Appearance.BackColor = Color.Orange;
                        e.Appearance.ForeColor = Color.White;
                        break;
                    case 2:
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        break;
                    case 3:
                        e.Appearance.BackColor = Color.Yellow;
                        e.Appearance.ForeColor = Color.Black;
                        break;
                    default:
                        break;
                }
            }
        }
        void LoadStatusCheck()
        {
            DateTime today = DateTime.Now;
            List<EquipmentDTO> lisE = EquipmentDAO.Instance.GetListEquipment();
            foreach (EquipmentDTO item in lisE)
            {
                try
                {
                    DateTime maxDate = DateTime.Parse(DataProvider.Instance.ExecuteScalar("SELECT MAX(DateIn) FROM dbo.HistoryEquipment WHERE EquipmentCode = N'" + item.EquipmentCode + "'").ToString());
                    System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
                    EquipmentDAO.Instance.UpdateDatecheckEquipment(item.EquipmentCode, maxDate);
                    int cycle = EquipmentDAO.Instance.Cycle(item.EquipmentCode);
                    int day = cycle - ((int)(today - maxDate).TotalDays);
                    if (day <= 15)
                    {
                        EquipmentDAO.Instance.UpdateStatusCheckEquipment(item.EquipmentCode, 2);

                    }
                    else if (day <= 30)
                    {
                        EquipmentDAO.Instance.UpdateStatusCheckEquipment(item.EquipmentCode, 1);

                    }
                    else
                    {
                        EquipmentDAO.Instance.UpdateStatusCheckEquipment(item.EquipmentCode, 0);
                    }
                }
                catch
                {
                    EquipmentDAO.Instance.UpdateStatusCheckEquipment(item.EquipmentCode, 3);
                }
            }
        }
    }
}
