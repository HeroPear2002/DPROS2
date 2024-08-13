using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using WareHouse.Employess;
using DTO;

namespace WareHouse
{
    public partial class frmEmployess : Form
    {

        public frmEmployess()
        {
            InitializeComponent();
            LoadControl();
        }
        public bool Isinsert = false;
        #region Control
        void LoadControl()
        {
            LoadData();
            LoadRoom();
            KhoaDK();
            LoadSuper();
        }
        void LoadData()
        {
            GCData.DataSource = EmployessDAO.Instance.GetlistAllEmployess().OrderBy(x => x.Status);
        }
        void KhoaDK()
        {
            txtEmployessCode.Enabled = false;
            txtEmployessName.Enabled = false;
            dtpkDateInput.Enabled = false;
            cbSuper.Enabled = false;
            cbRoom.Enabled = false;
            ckbStatust.Enabled = false;

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
        }
        void MoKhoaDK()
        {
            txtEmployessCode.Enabled = true;
            txtEmployessName.Enabled = true;
            dtpkDateInput.Enabled = true;
            cbSuper.Enabled = true;
            cbRoom.Enabled = true;
            ckbStatust.Enabled = true;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }
        void XoaText()
        {
            txtEmployessCode.Text = String.Empty;
            txtEmployessName.Text = String.Empty;
            dtpkDateInput.Text = String.Empty;
            cbSuper.Text = String.Empty;
            cbRoom.Text = String.Empty;
        }
        void LoadRoom()
        {
            cbRoom.DataSource = EmployessDAO.Instance.GetListRoom();
            cbRoom.DisplayMember = "CodeRo";
            cbRoom.ValueMember = "CodeRo";
        }
        void LoadSuper()
        {
            cbSuper.DataSource = EmployessDAO.Instance.GetlistEmployess();
            cbSuper.DisplayMember = "EmployessCode";
            cbSuper.ValueMember = "EmployessCode";
        }
        void AddText()
        {
            try
            {
                txtEmployessCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["EmployessCode"]).ToString();
                txtEmployessName.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["EmployessName"]).ToString();
                dtpkDateInput.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["DateInput"]).ToString();
                cbRoom.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["RoomCode"]).ToString();
                cbSuper.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Super"]).ToString();
                int status = EmployessDAO.Instance.StatusByCode(txtEmployessCode.Text);
                if (status == 1)
                {
                    ckbStatust.Checked = true;
                }
                else
                {
                    ckbStatust.Checked = false;
                }
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
            int check = AccountDAO.Instance.CheckAccount(7, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MoKhoaDK();
            Isinsert = true;
            XoaText();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(7, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MoKhoaDK();
            Isinsert = false;
            txtEmployessCode.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(7, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("bạn thực sự muốn xóa thông tin này?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    string employess = gridView1.GetRowCellValue(item, "EmployessCode").ToString();
                    EmployessDAO.Instance.DeleteEmployess(employess);
                }
                LoadControl();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string employessCode = txtEmployessCode.Text;
            string employessName = txtEmployessName.Text;
            int status = 0;
            if (ckbStatust.Checked == true)
            {
                status = 1;
            }
            DateTime dateInput = dtpkDateInput.Value;
            string roomCode = cbRoom.Text;
            string super = cbSuper.Text;
            if (Isinsert == true)
            {
                EmployessDAO.Instance.InsertEmployess(employessCode.ToUpper(), employessName.ToUpper(), dateInput, roomCode, super, status);
                MessageBox.Show("thêm thông tin thành công !".ToUpper());
                LoadControl();
            }
            else
            {
                EmployessDAO.Instance.UpdateEmployess(employessCode.ToUpper(), employessName.ToUpper(), dateInput, roomCode, super, status);
                MessageBox.Show("sửa thông tin thành công !".ToUpper());
                LoadControl();

            }
        }
        #endregion
        #region Inport

        private void btnForm_Click(object sender, EventArgs e)
        {
            frmFormEmployess f = new frmFormEmployess();
            f.ShowDialog();
        }

        private void btnInport_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(7, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmInportEmployess f = new frmInportEmployess();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }

        private void btnExport_Click(object sender, EventArgs e)
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
        #endregion
        private void GCData_Click(object sender, EventArgs e)
        {
            AddText();
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0) // chỉ xử lý trong cột họ tên thôi 
            {

                string code = view.GetRowCellValue(e.RowHandle, view.Columns["EmployessCode"]).ToString();
                int a = EmployessDAO.Instance.StatusByCode(code);
                if (a == 1)
                {
                    e.Appearance.BackColor = Color.Yellow;
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(7, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("bạn thực sự muốn xóa thông tin này?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    string employess = gridView1.GetRowCellValue(item, "EmployessCode").ToString();
                    EmployessDAO.Instance.UpdateEmployess(employess, 1);
                }
                LoadControl();
            }
        }
    }
}
