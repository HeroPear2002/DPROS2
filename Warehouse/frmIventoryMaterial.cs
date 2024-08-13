using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;
using WareHouse.Report;
using WareHouse.WareHouseMaterial;

namespace WareHouse
{
    public partial class frmIventoryMaterial : Form, IMessageFilter
    {
        public frmIventoryMaterial()
        {
            InitializeComponent();
            LoadColum();
            LoadControl();
            ChangeAccount();
        }
        public bool Isinsert = false;
        int _checkOut = 0;
        private System.Windows.Forms.Timer mTimer;
        int countCon = Kun_Static.CountCon;
        private int count;
        int timeLogout;
        void OutForm()
        {
            mTimer = new System.Windows.Forms.Timer();
            mTimer.Interval = 1000;
            mTimer.Tick += LogoutUser;
            mTimer.Enabled = true;
            count = countCon;
            Application.AddMessageFilter(this);
            timeLogout = countCon; // 15s logout - thay đổi thời gian logout ở đây 
            //label2.Text = timeLogout.ToString();
        }
        private const int WM_MOUSEMOVE = 0x0200;
        public bool PreFilterMessage(ref Message m)
        {
            // Monitor message for keyboard and mouse messages
            bool active = m.Msg == 0x100 || m.Msg == 0x101;  // WM_KEYDOWN/UP
            active = active || m.Msg == 0xA0 || m.Msg == 0x200;  // WM_(NC)MOUSEMOVE
            active = active || m.Msg == 0x10;    // WM_CLOSE, in case dialog closes
            if (active)
            {
                ActivedApp();
            }

            return false;
        }

        public void ActivedApp()
        {
            mTimer.Enabled = false;
            mTimer.Start();
        }

        private void LogoutUser(object sender, EventArgs e)
        {
            // No activity, logout user
            count--;
            // label2.Text = count.ToString();
            if (_checkOut == 0)
            {
                if (count == 0)
                {
                    mTimer.Enabled = false;
                    this.Close();
                }
            }
            else
            {
                count = countCon;
            }
        }
        void LoadColum()
        {
            gridView1.Columns["QuantityInput"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "QuantityInput", "Tổng = {0}");
        }
        void ChangeAccount()
        {
            int type = Kun_Static.accountDTO.Type;
            if (type == 1 || type == 2)
            {

            }
        }
        void LoadControl()
        {
            List<IventoryMaterialDTO> listINew = new List<IventoryMaterialDTO>();
            List<IventoryMaterialDTO> listI = IventoryMaterialDAO.Instance.GetListIventory();
            foreach (IventoryMaterialDTO item in listI)
            {
                float Requantity = IventoryMaterialDAO.Instance.ReQuantitybyIdInput(item.Id);
                float RequantityHH = IventoryMaterialDAO.Instance.ReQuantityHHbyId(item.Id);
                float iventory = item.QuantityInput + Requantity + RequantityHH;
                if(iventory <= 0)
                {
                    IventoryMaterialDAO.Instance.UpdateStatust(item.Id, 1);
                    IventoryMaterialDAO.Instance.UpdateStartReInputMaterial(item.Id, 1);
                    IventoryMaterialDAO.Instance.UpdateStartReInputHHByIdInput(item.Id, 1);
                    WarehouseMaterialDAO.Instance.UpdateStatus((int)item.IdWH, 1);
                }
                else
                {
                    listINew.Add(new IventoryMaterialDTO(item.Id, item.IdWH, item.MaterialCode, item.DateInput, item.MaterialName, iventory, item.Name,item.StyleInput, item.Lot, item.Rosh));
                }
            }
            GCData.DataSource = listINew;
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
        public static class Iventory
        {
            static public long Id;
            static public string MaterialCode;
            static public DateTime DateInput;
            static public int QuantityInput;
            static public string Name;
        }
        private void btnEditiventory_Click(object sender, EventArgs e)
        {
            if (Iventory.MaterialCode.Length != 0)
            {
                frmEditIventoryMaterial f = new frmEditIventoryMaterial();
                f.LamMoi += new EventHandler(btnUpdate_Click);
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("bạn chưa chọn thông tin cần sửa !".ToUpper());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }

        private void GCData_Click(object sender, EventArgs e)
        {
            btnPrint.Enabled = true;

            try
            {
                Iventory.Id = long.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Id"]).ToString());
                Iventory.MaterialCode = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["MaterialCode"]).ToString();
                Iventory.DateInput = DateTime.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["DateInput"]).ToString());
                Iventory.QuantityInput = int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["QuantityInput"]).ToString());
                Iventory.Name = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Name"]).ToString();
                txtLot.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Lot"]).ToString();
            }
            catch
            {

            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            List<BarcodeMaterial> listAll = new List<BarcodeMaterial>();
            try
            {
                int id = int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Id"]).ToString());
                List<IventoryMaterialDTO> listMaterial = IventoryMaterialDAO.Instance.GetListIventory().Where(x => x.Id == id).ToList();
                string Employess = IventoryMaterialDAO.Instance.GetEployessById(id);
                foreach (IventoryMaterialDTO item in listMaterial)
                {
                    listAll.Add(new BarcodeMaterial(item.MaterialCode, item.MaterialName, item.QuantityInput, item.Name, item.DateInput.ToString(), Employess, (MaterialDAO.Instance.NatureMaterial(item.MaterialCode))));
                }
                AutoPrintMaterial report = new AutoPrintMaterial(listAll);
                report.DataSource = listAll;
                report.LoadData();
                report.Print();
            }
            catch
            {
            }
        }

        private void btnAddLot_Click(object sender, EventArgs e)
        {
            txtLot.Enabled = true;
            btnSave.Enabled = true;
            Isinsert = true;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {

            btnSave.Enabled = true;
            Isinsert = false;
        }
        void LockControl()
        {
            txtLot.Enabled = false;
            btnSave.Enabled = false;

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string lot = txtLot.Text;
            if (Isinsert == true)
            {
                // update Lot
                _checkOut = 1;
                foreach (var item in gridView1.GetSelectedRows())
                {
                    long Id = long.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    IventoryMaterialDAO.Instance.UpdateLot(Id, lot);
                }
                MessageBox.Show("thêm thành công !".ToUpper());
                LockControl();
                LoadControl();
            }
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {

        }

        private void btnOutput_Click(object sender, EventArgs e)
        {

        }

        private void btnRohs_Click(object sender, EventArgs e)
        {
            try
            {
                string materialCode = gridView1.GetRowCellValue(gridView1.FocusedRowHandle,gridView1.Columns["MaterialCode"]).ToString();
                string a = MaterialDAO.Instance.RohsFile(materialCode);
                try
                {
                    Process.Start(a);
                }
                catch
                {
                    MessageBox.Show("nguyên liệu này chưa có rohs".ToUpper());
                }
            }
            catch 
            {
            }
          
        }
    }
}
