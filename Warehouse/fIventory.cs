using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;
using WareHouse.Input;
using WareHouse.Output;
using WareHouse.Report;
using DevExpress.XtraSplashScreen;
using WareHouse.Employess;
using System.Threading;

namespace WareHouse
{
    public partial class fIventory : Form, IMessageFilter
    {

        public fIventory()
        {
            InitializeComponent();
            LoadControl();
            LoadColum();
            gridView1.CustomDrawRowIndicator += gridView1_CustomDrawRowIndicator;
        }
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
            gridView1.Columns["Iventory"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Iventory", "Tổng = {0}");
        }

        bool cal(Int32 _Width, GridView _View)
        {
            _View.IndicatorWidth = _View.IndicatorWidth < _Width ? _Width : _View.IndicatorWidth;
            return true;
        }
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (!gridView1.IsGroupRow(e.RowHandle)) //Nếu không phải là Group
            {
                if (e.Info.IsRowIndicator) //Nếu là dòng Indicator
                {
                    if (e.RowHandle < 0)
                    {
                        e.Info.ImageIndex = 0;
                        e.Info.DisplayText = string.Empty;
                    }
                    else
                    {
                        e.Info.ImageIndex = -1; //Không hiển thị hình
                        e.Info.DisplayText = (e.RowHandle + 1).ToString(); //Số thứ tự tăng dần
                    }
                    SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font); //Lấy kích thước của vùng hiển thị Text
                    Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                    BeginInvoke(new MethodInvoker(delegate { cal(_Width, gridView1); })); //Tăng kích thước nếu Text vượt quá
                }
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", (e.RowHandle * -1)); //Nhân -1 để đánh lại số thứ tự tăng dần
                SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                BeginInvoke(new MethodInvoker(delegate { cal(_Width, gridView1); }));
            }
        }
        void LoadControl()
        {
            LoadAsyncWarning();
            LoadUpdate();
            LoadAsyncNote();
            LoadData();
            OutForm();
            btnRePrint.Enabled = false;
        }
        async void LoadAsyncNote()
        {
            await LoadUpdateNote();
        }
        async void LoadAsyncWarning()
        {
            await LoadWarning();
        }
        static async Task LoadWarning()
        {
            await Task.Run(() =>
            {
                List<IvenstoryDTO> listI = IventoryPartDAO.Instance.GetListIvenstoryPart();
                DateTime today = DateTime.Now;
                foreach (IvenstoryDTO item in listI)
                {
                    int idWH = item.IdWareHouse;
                    int status = WareHouseDAO.Instance.StatusWarehouseById(idWH);
                    int total = (int)(today - item.DateManufacturi).TotalDays;
                    switch (status)
                    {
                        case 2:
                            {
                                if (total >= 90)
                                {
                                    WareHouseDAO.Instance.UpdateStatusWH(idWH, 8);
                                }
                                //else if (total >= 30)
                                //{
                                //    WareHouseDAO.Instance.UpdateStatusWH(idWH, 10);
                                //}
                            }
                            break;
                        case 4:
                            {
                                if (total >= 3 && total < 7)
                                {
                                    WareHouseDAO.Instance.UpdateStatusWH(idWH, 6);
                                }
                                if (total >= 7)
                                {
                                    WareHouseDAO.Instance.UpdateStatusWH(idWH, 7);
                                }
                            }
                            break;
                        case 6:
                            {
                                if (total >= 7)
                                {
                                    WareHouseDAO.Instance.UpdateStatusWH(idWH, 7);
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            });
        }
        void LoadData()
        {
            GCData.DataSource = IventoryPartDAO.Instance.GetListIvenstoryPart();
        }
        private void btnInput_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Kun_Static.Style = 1;
            _checkOut = 1;
            frmEmployessCode f = new frmEmployessCode();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }
        private void btnInput2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Kun_Static.Style = 5;
            _checkOut = 1;
            frmEmployessCode f = new frmEmployessCode();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void btnOutput_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Kun_Static.Style = 2;
            _checkOut = 1;
            frmEmployessCode f = new frmEmployessCode();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }
        #region Kiểm Tra 
        public void LoadUpdate()
        {
            int i = 0;
            List<IvenstoryDTO> listI = IventoryPartDAO.Instance.GetListIvenstoryPart();
            foreach (IvenstoryDTO item in listI.Where(x => x.Iventory == 0).ToList())
            {
                long id = item.Id;
                int idWh = item.IdWareHouse;
                IventoryPartDAO.Instance.UpdateInputPart(id, 1);
                WareHouseDAO.Instance.UpdateStatusWH(idWh, 1);
            }
            List<IvenstoryDTO> listI1 = IventoryPartDAO.Instance.GetListIventoryPartStatus(DateTime.Now);
            foreach (IvenstoryDTO item in listI1)
            {
                long id = item.Id;
                int iventory = IventoryPartDAO.Instance.IventoryById(id);
                if (iventory > 0)
                {
                    IventoryPartDAO.Instance.UpdateInputPart(item.Id, 0);
                    WareHouseDAO.Instance.UpdateStatusWH(item.IdWareHouse, 4);
                    IventoryPartDAO.Instance.DeleteNInputPart(item.Id, item.IdWareHouse);
                    EditHistoryDAO.Instance.Insert(DateTime.Now, Kun_Static.accountDTO.UserName, "Chuyển Id Input " + item.Id + " về 0 , Update vị trí về 4 , Xóa vị trí còn lại", item.Name);
                }
            }

        }
        async Task LoadUpdateNote()
        {
            List<IvenstoryDTO> listI = IventoryPartDAO.Instance.GetListIvenstoryPart();
            await Task.Run(() =>
            {
                foreach (IvenstoryDTO item in listI)
                {
                    int iventory = item.Iventory;
                    int countPart = PartDAO.Instance.CountPartByCode(item.PartCode);
                    int a = (iventory % countPart);
                    if (item.Note2.Trim().Length == 0 || item.Note2.Trim() == "Vị trí có thùng lẻ")
                    {
                        if (a != 0)
                        {
                            IventoryPartDAO.Instance.UpdateNote2InputPart(item.Id, "Vị trí có thùng lẻ");
                        }
                        else
                        {
                            IventoryPartDAO.Instance.UpdateNote2InputPart(item.Id, "");
                        }
                    }
                }
            });
        }
        #endregion
        #region In lại phiếu nhập
        private void btnRePrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            List<CouponInputPart> listC = new List<CouponInputPart>();
            try
            {
                string PartCode = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["PartCode"]).ToString();
                DateTime DateInput = DateTime.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["DateInput"]).ToString());
                DateTime DateManufacturi = DateTime.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["DateManufacturi"]).ToString());
                string Name = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Name"]).ToString();
                string Machine = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["MachineCode"]).ToString();
                string Mold = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["MoldNumber"]).ToString();
                string Lot = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Lot"]).ToString();
                string BarCode = PartCode.ToUpper() + "&" + Machine.ToUpper() + "&" + Mold.ToUpper() + "&" + Lot.ToUpper();
                string factoryCode = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["FactoryCode"]).ToString();
                string QrCode = PartCode + "&" + Machine + "&" + Mold + "&" + factoryCode + "&" + Lot;
                listC.Add(new CouponInputPart(PartCode, DateInput, DateManufacturi, Name, factoryCode, QrCode));
                rpCouponPart report = new rpCouponPart();
                report.DataSource = listC;
                report.Print();
            }
            catch
            {
            }

        }
        #endregion
        private void btnReOutput_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int type = Kun_Static.accountDTO.Type;
            if (type == 1 || type == 2)
            {
                _checkOut = 1;
                Kun_Static.Style = 4;
                frmEmployessCode f = new frmEmployessCode();
                f.LamMoi += new EventHandler(btnUpdate_Click);
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("bạn không có quyền truy cập !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReInput_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Kun_Static.Style = 3;
            _checkOut = 1;
            frmEmployessCode f = new frmEmployessCode();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }
        #region Public Class
        public class IventoryPart
        {
            static public long Id;
            static public string PartCode;
            static public int Iventory;
            static public string Name;
        }
        #endregion
        private void GCData_Click(object sender, EventArgs e)
        {
            btnRePrint.Enabled = true;
            try
            {
                IventoryPart.Id = long.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Id"]).ToString());
                IventoryPart.PartCode = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["PartCode"]).ToString();
                IventoryPart.Iventory = int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Iventory"]).ToString());
                IventoryPart.Name = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Name"]).ToString();
            }
            catch
            {
            }
        }
        private void GCData_DoubleClick(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(2, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmEditIventoryPart f = new frmEditIventoryPart();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();

        }
        private void btnUpdate_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadControl();
        }
        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0) // chỉ xử lý trong cột họ tên thôi 
            {
                string Lot = view.GetRowCellValue(e.RowHandle, view.Columns["Lot"]).ToString();

                if (Lot == "")
                {
                    e.Appearance.BackColor = Color.Pink;
                    e.Appearance.ForeColor = Color.Black;
                }
            }
        }

        private void btnOutputK2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Kun_Static.Style = 6;
            frmEmployessCode f = new frmEmployessCode();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }

        private void btnInputPartDD1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _checkOut = 1;
            Kun_Static.Style = 7;
            frmEmployessCode f = new frmEmployessCode();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }

        private void btnOutputDD1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Kun_Static.Style = 8;
            _checkOut = 1;
            frmEmployessCode f = new frmEmployessCode();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }
    }
}
