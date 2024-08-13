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
using WareHouse.Report;
using DevExpress.XtraReports.UI;
using System.Globalization;
using DTO;
using System.IO;
using DevExpress.XtraGrid.Views.Grid;

namespace WareHouse.Employess
{
    public partial class frmInforEmployess : DevExpress.XtraEditors.XtraForm
    {

        public frmInforEmployess()
        {
            InitializeComponent();
            LoadControl();
        }
        public bool Isinsert = false;
        #region Control
        void LoadControl()
        {
            LoadRoom();
            LoadDate();
            LockControl();
            LoadData();
            btnPrinter.Enabled = false;
        }
        void LoadRoom()
        {
            cbRoom.DataSource = EmployessDAO.Instance.GetListRoom();
            cbRoom.DisplayMember = "CodeRo";
            cbRoom.ValueMember = "CodeRo";
        }
        void LoadData()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            DateTime today = dtpkTo.Value;
            DateTime date1 = today.AddDays(-today.Day).AddDays(1);
            DateTime date2 = date1.AddMonths(1).AddMilliseconds(-10);
            int type = Kun_Static.accountDTO.Type;
            string room = Kun_Static.accountDTO.RoomCode;
            switch (type)
            {
                case 1:
                    GCData.DataSource = EmployessDAO.Instance.GetlistWriteEmployessByDate(date1, date2);
                    break;
                case 2:
                    GCData.DataSource = EmployessDAO.Instance.GetlistWriteEmployessByRoomCode(date1, date2, "PC");
                    break;
                case 3:
                    GCData.DataSource = EmployessDAO.Instance.GetlistWriteEmployessByRoomCode(date1, date2, "Pro");
                    break;
                case 4:
                    GCData.DataSource = EmployessDAO.Instance.GetlistWriteEmployessByRoomCode(date1, date2, "QC");
                    break;
                case 8:
                    GCData.DataSource = EmployessDAO.Instance.GetlistWriteEmployessByRoomCodeQCPRO(date1, date2);
                    break;
                //case 5:
                //    GCData.DataSource = EmployessDAO.Instance.GetlistWriteEmployessByRoomCode(date1, date2);
                //    break;
                case 7:
                    GCData.DataSource = EmployessDAO.Instance.GetlistWriteEmployessByRoomCode(date1, date2, "Adm");
                    break;
                default:
                    GCData.DataSource = EmployessDAO.Instance.GetlistWriteEmployessByRoomCode(date1, date2,room);
                    break;
            }
        }
        void LoadDate()
        {
            dtpkTo.Value = DateTime.Now;
        }
        void LockControl()
        {
            cbEmployess.Enabled = false;
            cbError.Enabled = false;
            cbPlus.Enabled = false;
            dtpkTo.Enabled = true;
            txtNote.Enabled = false;

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
        }
        void OpenControl()
        {
            cbEmployess.Enabled = true;
            cbError.Enabled = true;
            cbPlus.Enabled = true;
            dtpkTo.Enabled = true;
            txtNote.Enabled = true;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }
        void ClearText()
        {
            //cbEmployess.Text = String.Empty;
            cbError.Text = String.Empty;
            cbPlus.Text = String.Empty;
            dtpkTo.Text = String.Empty;
            txtID.Text = String.Empty;
        }
        void AddText()
        {
            try
            {
                cbEmployess.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["CodeEm"]).ToString();
                cbError.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["NameEr"]).ToString();
                cbPlus.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["NamePl"]).ToString();
                dtpkTo.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["DateHis"]).ToString();
                txtID.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Id"]).ToString();
                txtNote.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Note"]).ToString();
            }
            catch
            {

            }
        }
        void LoadEmployess()
        {
            List<EmployessDTO> listE = new List<EmployessDTO>();
            string room = cbRoom.Text;
            if (room == "ALL")
            {
                listE = EmployessDAO.Instance.GetlistEmployess().ToList();
            }
            else
            {
                listE = EmployessDAO.Instance.GetlistEmployess().Where(x => x.RoomCode == room).ToList();
            }

            cbEmployess.Properties.DataSource = listE;
            cbEmployess.Properties.DisplayMember = "EmployessCode";
            cbEmployess.Properties.ValueMember = "EmployessCode";
        }
        void LoadError()
        {
            string room = EmployessDAO.Instance.RoomByCode(cbEmployess.Text);
            cbError.DataSource = EmployessDAO.Instance.GetListErrorByRoom(room);
            cbError.DisplayMember = "NameEr";
            cbError.ValueMember = "NameEr";
        }
        void LoadPluss()
        {
            string room = EmployessDAO.Instance.RoomByCode(cbEmployess.Text);
            cbPlus.DataSource = EmployessDAO.Instance.GetListPlusByRoom(room);
            cbPlus.DisplayMember = "NamePl";
            cbPlus.ValueMember = "NamePl";
        }
        #endregion
        #region Event

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenControl();
            Isinsert = true;
            ClearText();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            OpenControl();
            Isinsert = false;
            cbEmployess.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn thực sự muốn xóa thông tin này ?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (var item in gridView2.GetSelectedRows())
                {
                    long id = long.Parse(gridView2.GetRowCellValue(item, "Id").ToString());
                    EmployessDAO.Instance.DeleteWriteEmployess(id);
                }
                LoadControl();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }
        private void GCData_Click(object sender, EventArgs e)
        {
            LoadError();
            LoadPluss();
            AddText();
            btnPrinter.Enabled = true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            DateTime today = DateTime.Now;
            DateTime date1 = today.Date.AddDays(-today.Day).AddDays(1);
            DateTime date2 = date1.AddMonths(1).AddMilliseconds(-1);
            string nameEr = cbError.Text;
            string codeEm = cbEmployess.Text;
            string room = EmployessDAO.Instance.RoomByCode(codeEm);
            string namePl = cbPlus.Text;
            string number = EmployessDAO.Instance.NumberEr(nameEr) + " " + EmployessDAO.Instance.NumberPl(namePl);
            string nameEm = EmployessDAO.Instance.NameEmployess(codeEm);
            int pointEr = EmployessDAO.Instance.PoitEr(nameEr, room);
            int pointPl = EmployessDAO.Instance.PoitPl(namePl, room);
            int totalEr = EmployessDAO.Instance.TotalPoitEr(codeEm, date1, date2);
            int totalPl = EmployessDAO.Instance.TotalPoitPl(codeEm, date1, date2);
            string note = txtNote.Text;
            int totalNow = 100 + totalPl - totalEr + (pointPl - pointEr);
            DateTime date = dtpkTo.Value;
            if (codeEm == "" || (nameEr == "" && namePl == "") || (nameEr != "" && namePl != ""))
            {
                MessageBox.Show("bạn chưa điền đầy đủ thông tin !\n\nBạn chỉ được chọn 1 hạng mục công điểm hoặc trừ điểm".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<CoupontEmployess> listC = new List<CoupontEmployess>();
            if (Isinsert == true)
            {
                EmployessDAO.Instance.InsertWriteEmployess(codeEm, date, nameEr, namePl, pointEr, pointPl, today, note, 1);
                MessageBox.Show("Thêm thông tin thành công !".ToUpper());
                LoadControl();
                listC.Add(new CoupontEmployess(codeEm.ToUpper(), nameEm.ToUpper(), today, date, pointEr + pointPl, totalNow, nameEr + namePl + " : " + note, number));
                rpCounpontEmployess rp = new rpCounpontEmployess();
                rp.DataSource = listC;
                rp.PrintDialog();
            }
            else
            {
                long id = long.Parse(txtID.Text);
                note = note + " -- Được chỉnh sửa bởi -- " + Kun_Static.accountDTO.UserName;
                EmployessDAO.Instance.UpdateWriteEmployess(id, codeEm, date, nameEr, namePl, pointEr, pointPl, note, 1);
                EditHistoryDAO.Instance.Insert(today, Kun_Static.accountDTO.UserName, "Sửa thông tin " + nameEr + namePl + pointEr + pointPl, "");
                MessageBox.Show("sửa thông tin thành công !".ToUpper());
                LoadControl();
            }
        }
        #endregion

        private void btnPrinter_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            DateTime today = DateTime.Now;
            DateTime date1 = today.Date.AddDays(-today.Day).AddDays(1);
            DateTime date2 = date1.AddMonths(1).AddMilliseconds(-1);
            long id = long.Parse(txtID.Text);
            string nameEr = cbError.Text;
            string codeEm = EmployessDAO.Instance.EmCodeById(id);
            string room = EmployessDAO.Instance.RoomByCode(codeEm);
            string namePl = cbPlus.Text;
            string note = txtNote.Text;
            string number = EmployessDAO.Instance.NumberEr(nameEr) + " " + EmployessDAO.Instance.NumberPl(namePl);
            string nameEm = EmployessDAO.Instance.NameEmployess(codeEm);
            int pointEr = EmployessDAO.Instance.PoitEr(nameEr, room);
            int pointPl = EmployessDAO.Instance.PoitPl(namePl, room);
            int totalEr = EmployessDAO.Instance.TotalPoitEr(codeEm, date1, date2);
            int totalPl = EmployessDAO.Instance.TotalPoitPl(codeEm, date1, date2);
            int status = int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["StatusInforEm"]).ToString());
            int totalNow = 100;
            if (status == 0)
            {
                totalNow = totalNow + totalPl - totalEr;
            }
            else
            {
                totalNow = totalNow + totalPl - totalEr + pointPl - pointEr;
            }
            DateTime date = dtpkTo.Value;
            List<CoupontEmployess> listC = new List<CoupontEmployess>();
            listC.Add(new CoupontEmployess(codeEm.ToUpper(), nameEm.ToUpper(), today, date, pointEr + pointPl, totalNow, nameEr + namePl + " : " + note, number));
            rpCounpontEmployess report = new rpCounpontEmployess();
            report.DataSource = listC;
            report.PrintDialog();
            this.Close();
        }
        private void cbEmployess_EditValueChanged(object sender, EventArgs e)
        {
            LoadError();
            LoadPluss();
            ClearText();
        }

        private void cbEmployess_Click(object sender, EventArgs e)
        {
            LoadError();
            LoadPluss();
            ClearText();
        }
        private void cbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEmployess();
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

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            DateTime today = dtpkTo.Value;
            DateTime date1 = today.Date.AddDays(-today.Day).AddDays(1).AddMonths(-today.Month + 1); 
            DateTime date2 = date1.AddYears(1).AddSeconds(-10); 
            int type = Kun_Static.accountDTO.Type;
            string room = Kun_Static.accountDTO.RoomCode;
            switch (type)
            {
                case 1:
                    GCData.DataSource = EmployessDAO.Instance.GetlistWriteEmployessByDate(date1, date2);
                    break;
                case 2:
                    GCData.DataSource = EmployessDAO.Instance.GetlistWriteEmployessByRoomCode(date1, date2, "PC");
                    break;
                case 3:
                    GCData.DataSource = EmployessDAO.Instance.GetlistWriteEmployessByRoomCode(date1, date2, "Pro");
                    break;
                case 4:
                    GCData.DataSource = EmployessDAO.Instance.GetlistWriteEmployessByRoomCode(date1, date2, "QC");
                    break;
                case 8:
                    GCData.DataSource = EmployessDAO.Instance.GetlistWriteEmployessByRoomCodeQCPRO(date1, date2);
                    break;
                //case 5:
                //    GCData.DataSource = EmployessDAO.Instance.GetlistWriteEmployessByRoomCode(date1, date2);
                //    break;
                case 7:
                    GCData.DataSource = EmployessDAO.Instance.GetlistWriteEmployessByRoomCode(date1, date2, "Adm");
                    break;
                default:
                    GCData.DataSource = EmployessDAO.Instance.GetlistWriteEmployessByRoomCode(date1, date2, room);
                    break;
            }
        }

        private void btnAppro_Click(object sender, EventArgs e)
        {
            int testAcc = AccountDAO.Instance.PermissionAccount(Kun_Static.accountDTO.UserName);
            if (testAcc < 2)
            {
                MessageBox.Show("bạn không có quyền truy cập !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (MessageBox.Show("bạn muốn phê duyệt phiếu này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    foreach (var item in gridView2.GetSelectedRows())
                    {
                        long id = long.Parse(gridView2.GetRowCellValue(item, "Id").ToString());
                        EmployessDAO.Instance.ApproEmployess(id, 0);
                    }
                    LoadControl();
                }
            }
        }
        private void gridView2_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0) // chỉ xử lý trong cột họ tên thôi 
            {
                int status = int.Parse(view.GetRowCellValue(e.RowHandle, view.Columns["StatusInforEm"]).ToString());
                if (status == 1)
                {
                    e.Appearance.BackColor = Color.Turquoise;
                    e.Appearance.ForeColor = Color.Black;
                }
            }

        }
    }
}