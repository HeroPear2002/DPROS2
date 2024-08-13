using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;
using WareHouse.Employess;
using WareHouse.Machine;
using System.Diagnostics;

namespace WareHouse
{
    public partial class fMachineMaker : Form
    {
        public fMachineMaker()
        {
            InitializeComponent();
            LoadControl();
            Control.CheckForIllegalCrossThreadCalls = false;
            gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
        }
        public bool IsInsert = false;
        #region Control
        void LoadControl()
        {
            LoadData();
            KhoaDK();
            LoadName();
        }
        void LoadName()
        {
            int Device = Kun_Static.DeviceId;
            string NameMachine = MachineDAO.Instance.NameListDevice(Device);
            this.Text = "Danh Sách " + NameMachine;
        }
        void LoadData()
        {
            int device = Kun_Static.DeviceId;
            GCData.DataSource = MachineDAO.Instance.GetListDataMachineByDevice(device);
        }
        void KhoaDK()
        {
            txbMachineCode.Enabled = false;
            txbMachineName.Enabled = false;
            txbMachineInfo.Enabled = false;
            txbMachineMaker.Enabled = false;
            dtpkDateInput.Enabled = false;
            txbCodeTSCD.Enabled = false;
            txbVendor.Enabled = false;
            dtpkDateSX.Enabled = false;
            dtpkDateMaker.Enabled = false;

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
        }
        void MoKhoaDK()
        {
            txbMachineCode.Enabled = true;
            txbMachineName.Enabled = true;
            txbMachineInfo.Enabled = true;
            txbMachineMaker.Enabled = true;
            dtpkDateInput.Enabled = true;
            txbCodeTSCD.Enabled = true;
            txbVendor.Enabled = true;
            dtpkDateSX.Enabled = true;
            dtpkDateMaker.Enabled = true;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }
        void XoaText()
        {
            txbMachineCode.Text = String.Empty;
            txbMachineName.Text = String.Empty;
            txbMachineInfo.Text = String.Empty;
            txbMachineMaker.Text = String.Empty;
            dtpkDateInput.Text = String.Empty;
            txbCodeTSCD.Text = String.Empty;
            txbVendor.Text = String.Empty;
            dtpkDateSX.Text = String.Empty;
            dtpkDateMaker.Text = String.Empty;
        }
        void AddText()
        {
            try
            {
                txbMachineCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["MachineCode"]).ToString();
                txbMachineName.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["MachineName"]).ToString();
                txbMachineInfo.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["MachineInfor"]).ToString();
                txbMachineMaker.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["MachineMake"]).ToString();
                dtpkDateInput.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["DateInput"]).ToString();
                txbCodeTSCD.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["CodeTSCD"]).ToString();
                txbVendor.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Vendor"]).ToString();
                dtpkDateSX.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["DateSX"]).ToString();
                dtpkDateMaker.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["DateMaker"]).ToString();
            }
            catch
            {

            }
        }

        #endregion
        #region Event
        private void btnAdd_Click(object sender, EventArgs e)
        {
            MoKhoaDK();
            XoaText();
            IsInsert = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string machineCode = txbMachineCode.Text;
            string machineName = txbMachineName.Text;
            string machineInfor = txbMachineInfo.Text;
            string machineMake = txbMachineMaker.Text;
            string DateMaker = dtpkDateMaker.Value.ToString();
            DateTime DateInput = dtpkDateInput.Value;
            string CodeTSCD = txbCodeTSCD.Text;
            string Vendor = txbVendor.Text;
            DateTime DateSX = dtpkDateSX.Value;
            int Device = Kun_Static.DeviceId;
            int StatusMachine = 0;
            if (machineCode.Length == 0)
            {
                MessageBox.Show("mã thiết bị trống ".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (IsInsert == true)
            {
                try
                {
                    MachineDAO.Instance.InsertMachine(machineCode, machineName, machineInfor, machineMake, DateInput, CodeTSCD, Vendor, DateSX, Device, StatusMachine, DateMaker);
                    MessageBox.Show("thêm thông tin thành công!".ToUpper());
                    LoadControl();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("mã thiết bị đã tồn tại !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MachineDAO.Instance.UpdateMachine(machineCode, machineName, machineInfor, machineMake, DateInput, CodeTSCD, Vendor, DateSX, Device, StatusMachine, DateMaker);
                MessageBox.Show("sửa thông tin thành công!".ToUpper());
                LoadControl();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            MoKhoaDK();
            txbMachineCode.Enabled = false;
            IsInsert = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn thực sự muốn xóa thông tin này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    string MachineCode = gridView1.GetRowCellValue(item, "MachineCode").ToString();
                    MachineDAO.Instance.DeleteMachine(MachineCode);
                }
                LoadControl();
            }
        }
        #endregion
        #region Inport/Export
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
        private void btnDownload_Click(object sender, EventArgs e)
        {
            frmFormMachine f = new frmFormMachine();
            f.ShowDialog();
        }
        private void btnInport_Click(object sender, EventArgs e)
        {
            Kun_Static.DeviceId = frmMainDevices.MainId.DeviceId;
            frmInportMachine f = new frmInportMachine();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }
        private void btnUpdateMachine_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        #endregion
        #region Check  
        private void btnEveryShort_Click(object sender, EventArgs e)
        {
            Kun_Static.MachineCode = txbMachineCode.Text;
            if (Kun_Static.MachineCode.Length > 0)
            {
                frmEveryday f = new frmEveryday();
                f.LamMoi += new EventHandler(btnUpdateMachine_Click);
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("bạn chưa chọn máy cần kiểm tra".ToUpper());
            }
        }

        private void btnEveryLong_Click(object sender, EventArgs e)
        {

            Kun_Static.MachineCode = txbMachineCode.Text;
            int k = Kun_Static.accountDTO.Type;
            if (Kun_Static.MachineCode.Length > 0)
            {
                frmEveryMainten f = new frmEveryMainten();
                f.LamMoi += new EventHandler(btnUpdateMachine_Click);
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("bạn chưa chọn máy cần kiểm tra".ToUpper());
            }
        }
        #endregion

        private void gridView1_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0) // chỉ xử lý trong cột họ tên thôi 
            {
                string MachineCode = view.GetRowCellValue(e.RowHandle, view.Columns["MachineCode"]).ToString();
                int status = MachineDAO.Instance.StatusMachineByCode(MachineCode);
                if (status == 10)
                {
                     e.Appearance.BackColor = Color.Gray;
                }
                      
            }
        }

        private void GCData_Click(object sender, EventArgs e)
        {
            AddText();
        }

        private void fMachineMaker_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void cbDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            fMachineMaker f = new fMachineMaker();
            f.Show();
        }

        private void btnInforMachine_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn muốn xác nhận máy tạm!".ToUpper(), "Thông báo", MessageBoxButtons.OK) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    string machineCode = gridView1.GetRowCellValue(item, "MachineCode").ToString();
                    MachineDAO.Instance.UpdateStatusMay(machineCode, 10, "");
                }
                LoadControl();
            }
        }
    }
}

