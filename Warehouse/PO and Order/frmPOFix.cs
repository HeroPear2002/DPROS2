using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;
using System.Collections;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid;
using WareHouse.Report;
using DevExpress.XtraReports.UI;
using WareHouse.Common;

namespace WareHouse.PO_and_Order
{
    public partial class frmPOFix : Form
    {

        public frmPOFix()
        {

            InitializeComponent();
            LoadControl();
        }
        /// <summary>
        /// Trạng thái : 
        ///0 :khi mới tạo PO Fix --> 1 : PO đã giao OK -->2 : Đã làm bb --> 3 : PO đã xuất --> 4: PO Làm bb nhưng chưa xuất --> 5: Đã xuất nhưng chưa giao -->6: Chưa xuất
        /// </summary>
        public bool Isinsert = false; 
        #region Control
        void LoadControl()
        {
            LoadPOInput();
            DateTime today = dtpkDateOut.Value.Date;
            DateTime date1 = today.AddDays(-5);
            DateTime date2 = today.AddDays(5);
            LoadStatus();
            LoadData(date1, date2);
            LockControl();
            DeleteText();
            LoadFilter();
            LoadMailPCAsync();
            timer1.Start();
            gridView1.CustomDrawRowIndicator += gridView1_CustomDrawRowIndicator;
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
        async void LoadMailPCAsync()
        {
            //if(Kun_Static.accountDTO.Type != 1)
            //{
                await SendMail();
            //}
        }
        async void LoadStatus()
        {
          await  LoadStatusPOFix(dtpkDateOut.Value.Date);
        }
        public static async Task LoadStatusPOFix( DateTime today)
        {
            await Task.Run(() =>
            {
                DateTime todayNow = DateTime.Now;
                DateTime date1 = today.AddDays(1 - today.Day);
                DateTime date2 = date1.AddMonths(1).AddSeconds(-10);
                List<POFixDTO> listPO = POFixDAO.Instance.GetListPOFix(date1, date2);
                foreach (POFixDTO item in listPO)
                {
                    long id = item.Id;
                    int statusCheck = POFixDAO.Instance.StatusPO(id);
                    DateTime dateOut = item.DateOut;
                    long idPOInput = item.IdPOInput;
                    string customer = PODAO.Instance.Customer(idPOInput);
                    int warn = CustomerDAO.Instance.WarnPOFix(customer);
                    double a = (todayNow - dateOut).TotalHours;
                    if (a >= -warn && statusCheck == 0)
                    {
                        POFixDAO.Instance.UpdatePOFixByCode(id, 6, "PO chưa xuất");
                    }
                    else if (a >= -warn && statusCheck == 2)
                    {
                        POFixDAO.Instance.UpdatePOFixByCode(id, 4, "PO làm BBGH nhưng chưa xuất");
                    }
                    else if (a < -warn && statusCheck == 4)
                    {
                        POFixDAO.Instance.UpdatePOFixByCode(id, 2, "");
                    }
                    else if (statusCheck == 3 && a >= 12)
                    {
                        POFixDAO.Instance.UpdatePOFixByCode(id, 5, "PO chưa giao");
                    }
                    else if (statusCheck == 5)
                    {
                        long idDe = (long)item.IdDe;
                        int statDe = DeliveryDAO.Instance.StatusDe(idDe);
                        if (statDe == 3)
                        {
                            POFixDAO.Instance.UpdatePOFixByCode(id, 1, "PO đã giao");
                        }
                        else if (a <= 12)
                        {
                            POFixDAO.Instance.UpdatePOFixByCode(id, 3, "PO đã xuất");
                        }
                    }
                    else if (statusCheck == 1)
                    {
                        POFixDAO.Instance.UpdatePOFixByCode(id, 1, "PO đã giao");
                    }
                    else if (a < -warn && statusCheck == 6)
                    {
                        POFixDAO.Instance.UpdatePOFixByCode(id, 0, "");
                    }
                }
            });
        }
    
        #region gửi mail
        public static async Task SendMail()
        {
            await Task.Run(() =>
            {
                List<string> listMail4 = new List<string>();
                List<string> listMail5 = new List<string>();
                List<POFixDTO> listP6 = POFixDAO.Instance.GetListPOFixByStatus6();
                List<POFixDTO> listP5 = POFixDAO.Instance.GetListPOFixByStatus5();
                string message6 = "";
                string message5 = "";
                int dk = 0;
                if (listP6.Count > 0)
                {
                    dk = 1;
                    message6 = "PO chưa xuất : \n";
                    foreach (POFixDTO item in listP6)
                    {
                        message6 += item.POCode + " ;";
                    }
                }
                if (listP5.Count > 0)
                {
                    dk = 2;
                    message5 = "PO chưa giao : \n";
                    foreach (POFixDTO item in listP5)
                    {
                        message5 += item.POCode + " ;";
                    }
                }
                List<AccountDTO> listEmail = AccountDAO.Instance.GetAccountEmail(2);
                if (dk > 0 && listEmail.Count > 0)
                {
                    string message = message6 + "\n\n\n\n" + message5;
                    string to = "";
                    foreach (AccountDTO item in listEmail)
                    {
                        to += item.EMail + ",";
                    }
                    string subject = "Cảnh báo PO Fix";
                    SendEMail.SendGMail(to, subject, message);
                }
            });
        }
        #endregion
        void LoadData(DateTime date1, DateTime date2)
        {
            List<POFixDTO> listPO = new List<POFixDTO>();
            listPO = POFixDAO.Instance.GetListPOFix(date1, date2);
            GCData.DataSource = listPO.OrderByDescending(x=>x.Status);
        }
        void LockControl()
        {
            txtPO.Enabled = false;
            txtPart.Enabled = false;
            nudQuantity.Enabled = false;
            dtpkDateOut.Enabled = true;
            txtPrice.Enabled = false;
            lkPOInput.Enabled = false;
            txtFactory.Enabled = false;
            txtCarNumber.Enabled = false;

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
        }
        void OpenControl()
        {
            lkPOInput.Enabled = true;
            nudQuantity.Enabled = true;
            dtpkDateOut.Enabled = true;
            txtFactory.Enabled = true;
            txtCarNumber.Enabled = true;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }
        void DeleteText()
        {
            txtPO.Text = String.Empty;
            txtPart.Text = String.Empty;
            nudQuantity.Value = 0;
            dtpkDateOut.Text = String.Empty;
            txtFactory.Text = String.Empty;
            txtCarNumber.Text = String.Empty;
            txtIdInput.Text = String.Empty;
        }
        void LoadPOInput()
        {
            List<PODTO> listP = PODAO.Instance.GetListPOInput();
            lkPOInput.Properties.DataSource = listP;
            lkPOInput.Properties.DisplayMember = "POCode";
            lkPOInput.Properties.ValueMember = "Id";
        }
        void AddText()
        {
            try
            {
                txtPO.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["POCode"]).ToString();
                txtPart.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["PartCode"]).ToString();
                nudQuantity.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Quantity"]).ToString();
                dtpkDateOut.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["DateOut"]).ToString();
                txtFactory.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["FactoryCustomer"]).ToString();
                txtCarNumber.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["CarNumber"]).ToString();
                txtIdInput.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["IdPOInput"]).ToString();
            }
            catch
            {
            }
        }
        void LoadFilter()
        {
            foreach (GridColumn gridColumn in gridView1.Columns)
            {
                gridColumn.FilterMode = ColumnFilterMode.DisplayText;
                gridColumn.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
            }
        }
        #endregion
        #region Event
        private void btnInport_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(2, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmInportPOFix f = new frmInportPOFix();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(2, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DeleteText();
            Isinsert = true;
            OpenControl();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(2, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Isinsert = false;
            OpenControl();
            txtPO.Enabled = false;
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
            if (MessageBox.Show("bạn thực sự muốn xóa thông tin này?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    long Id = long.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    int test = DeliveryDAO.Instance.TestDeliveryDetail(Id);
                    if (test != 1)
                    {
                        POFixDAO.Instance.DeletePOFix(Id);
                    }
                }
                LoadControl();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            long IdInput = long.Parse(txtIdInput.Text);
            PODTO pODTO = PODAO.Instance.GetItemPOInput(IdInput);
            int sum = POFixDAO.Instance.SumQuantity(IdInput);
            int quantity = (int)nudQuantity.Value;
            string POCode = txtPO.Text;
            string PartCode = txtPart.Text;
            DateTime today = dtpkDateOut.Value;
            DateTime DateOut = today.AddSeconds(-today.Second).AddMilliseconds(-today.Millisecond);
            DateTime DateInput = DateTime.Now;
            string Factory = txtFactory.Text;
            string CarNumber = txtCarNumber.Text;
            if (Isinsert == true)
            {
                if (pODTO.QuantityIn < (quantity + sum))
                {
                    MessageBox.Show("Số lượng giao quá lớn!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                POFixDAO.Instance.InsertPOFix(IdInput, POCode, PartCode, quantity, DateOut, "", 0, DateInput, Factory, CarNumber);
                MessageBox.Show("thêm thông tin thành công !".ToUpper());
                lkPOInput.Controls.Clear();
                LoadControl();
            }
            else
            {
                long id = long.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Id"]).ToString());
                int sum1 = POFixDAO.Instance.SumQuantity(IdInput, id); ;
                if (pODTO.Quantity < (quantity + sum1))
                {
                    MessageBox.Show("Số lượng giao quá lớn!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                POFixDAO.Instance.UpdatePOFix(id, IdInput, POCode, PartCode, quantity, DateOut,DateInput, Factory, CarNumber);
                MessageBox.Show("sửa thông tin thành công !".ToUpper());
                lkPOInput.Controls.Clear();
                LoadControl();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }
        private void GCData_Click(object sender, EventArgs e)
        {
            AddText();
        }

        #endregion
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
        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            DateTime today = DateTime.Now;
            if (e.RowHandle >= 0) // chỉ xử lý trong cột họ tên thôi 
            {
                int statusCheck = int.Parse(view.GetRowCellValue(e.RowHandle, view.Columns["Status"]).ToString());
                switch (statusCheck)
                {
                    case 1:

                        break;
                    case 2:
                        e.Appearance.BackColor = Color.Pink;
                        break;
                    case 3:
                        e.Appearance.BackColor = Color.Yellow;
                        break;
                    case 4:
                        e.Appearance.BackColor = Color.Orange;
                        break;
                    case 5:
                        e.Appearance.BackColor = Color.GreenYellow;
                        break;
                    case 6:
                        e.Appearance.BackColor = Color.Red;
                        break;
                    default:
                        break;
                }
            }
        }
      

        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadMailPCAsync();
        }

        private void lkPOInput_EditValueChanged(object sender, EventArgs e)
        {
            LoadText();

        }
        void LoadText()
        {
            long id = long.Parse(lkPOInput.EditValue.ToString());
            PODTO pODTO = PODAO.Instance.GetItemPOInput(id);
            txtIdInput.Text = id.ToString();
            txtPO.Text = pODTO.POCode;
            txtPart.Text = pODTO.PartCode;
            nudQuantity.Text = pODTO.Quantity.ToString();
            txtPrice.Text = pODTO.Price.ToString();
        }

        private void frmFormPOFix_Click(object sender, EventArgs e)
        {
            frmPOFixForm f = new frmPOFixForm();
            f.ShowDialog();
        }

        private void lkPOInput_TextChanged(object sender, EventArgs e)
        {
            long id = long.Parse(lkPOInput.EditValue.ToString());
            PODTO pODTO = PODAO.Instance.GetItemPOInput(id);
            txtIdInput.Text = id.ToString();
            txtPO.Text = pODTO.POCode;
            txtPart.Text = pODTO.PartCode;
            nudQuantity.Text = pODTO.QuantityIn.ToString();
            txtPrice.Text = pODTO.Price.ToString();
        }
        string LoadDeCode()
        {
            string a = "DD";
            DateTime today = DateTime.Now;
            int year = today.Year;
            int month = today.Month;
            int day = today.Day;
            int hour = today.Hour;
            int minute = today.Minute;
            int second = today.Second;
            int milliSecond = today.Millisecond;
            a = a + year.ToString() + month.ToString("D2") + day.ToString("D2") + hour.ToString("D2") + minute.ToString("D2") + second.ToString("D2") + milliSecond.ToString();
            return a;
        }
        long LoadCheck()
        {
            int dem = gridView1.SelectedRowsCount;
            string fact = "";
            string car = "";
            string fac = "";
            string date = "";
            int check = 0;
            foreach (var item in gridView1.GetSelectedRows())
            {
                string po = gridView1.GetRowCellValue(item, "POCode").ToString();
                if (check == 0)
                {
                    long id = long.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    int test = DeliveryDAO.Instance.TestDeliveryDetail(id);
                    int status = int.Parse(gridView1.GetRowCellValue(item, "Status").ToString());
                    if (test == 1)
                    {
                        return id;
                    }
                    if (status == 1 || status == 3 || status == 5)
                    {
                        return id;
                    }
                    fact = gridView1.GetRowCellValue(item, "FactoryCustomer").ToString();
                    car = gridView1.GetRowCellValue(item, "CarNumber").ToString();
                    fac = gridView1.GetRowCellValue(item, "FactoryCode").ToString();
                    date = gridView1.GetRowCellValue(item, "DateOut").ToString();
                }
                else
                {
                    string factoryCus = gridView1.GetRowCellValue(item, "FactoryCustomer").ToString();
                    string factory = gridView1.GetRowCellValue(item, "FactoryCode").ToString();
                    string carnumber = gridView1.GetRowCellValue(item, "CarNumber").ToString();
                    string dateOut = gridView1.GetRowCellValue(item, "DateOut").ToString();
                    if ((fact == factoryCus))
                    {
                        if (car == carnumber)
                        {
                            if(fac == factory)
                            {
                                if (date == dateOut)
                                {
                                    long id = long.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                                    int test = DeliveryDAO.Instance.TestDeliveryDetail(id);
                                    int status = int.Parse(gridView1.GetRowCellValue(item, "Status").ToString());
                                    if (test == 1)
                                    {
                                        return id;
                                    }
                                    if (status == 1 || status == 3 || status == 5)
                                    {
                                        return id;
                                    }
                                    fact = factoryCus;
                                    car = carnumber;
                                    date = dateOut;
                                }
                                else
                                {
                                    return -4;
                                }
                            }
                            else
                            {
                                return -3;
                            }                       
                        }
                        else
                        {
                            return -2;
                        }
                    }
                    else
                    {
                        return -1;
                    }
                }
                check++;
            }
            return 0;
        }

        private void btnCreateDe_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(2, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            long check1 = LoadCheck();
            if (check1 > 0)
            {
                string POFix = POFixDAO.Instance.GetItemPOFix(check).POCode;
                MessageBox.Show("Mã PO " + POFix + " này đã thêm vào BBGH rồi \nbạn hãy kiển tra lại.".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (check1 == -1)
            {
                MessageBox.Show("nhà máy giao hàng không trùng nhau \nbạn hãy kiển tra lại.".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (check1 == -2)
            {
                MessageBox.Show("Số xe không trùng nhau \nbạn hãy kiển tra lại.".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (check1 == -3)
            {
                MessageBox.Show("nhà máy sản xuất không trùng nhau \nbạn hãy kiển tra lại.".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (check1 == -4)
            {
                MessageBox.Show("Lot giao hàng không trùng nhau \nbạn hãy kiển tra lại.".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int count = 0;
            count = gridView1.SelectedRowsCount;
            if (count == 0)
            {
                MessageBox.Show("bạn chưa chọn po cần làm BBGH.".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string a = LoadDeCode();
            int dem = 0;
            int page = 1;
            int ratio = count % 20;
            int pageSize = count / 20;
            foreach (var item in gridView1.GetSelectedRows())
            {
                DateTime dateTime = DateTime.Parse(gridView1.GetRowCellValue(item, "DateOut").ToString());
                if (dem % 20 == 0)
                {
                    DeliveryDAO.Instance.InsertDelivery(a + "-" + page.ToString(), DateTime.Now, Kun_Static.accountDTO.UserName, "", 0, "BB chưa được xuất", dateTime);
                    dem = 0;
                    page++;
                }
                long MaxId = DeliveryDAO.Instance.MaxIdDelivery();
                //Thêm chi tiết BBGH ở đây
                long idPOFix = long.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                POFixDAO.Instance.UpdatePOFixByCode(idPOFix, 2, "", MaxId);
                DeliveryDAO.Instance.InsertDeliveryDetail(idPOFix, MaxId, "",0,0);
                dem++;
            }
            MessageBox.Show("Thêm biên bản thành công!".ToUpper());
            LoadControl();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DateTime today = dtpkDateOut.Value.Date;
            DateTime date1 = today.AddDays(1 - today.Day);
            DateTime date2 = date1.AddMonths(1).AddSeconds(-10);
            LoadStatus();
            LoadData(date1, date2);
        }

        private void lkPOInput_Click(object sender, EventArgs e)
        {
            LoadText();
        }

        private void btnPrintPO_Click(object sender, EventArgs e)
        {
            List<POCodeDTO> listP = new List<POCodeDTO>();
            foreach (var item in gridView1.GetSelectedRows())
            {
                string poCode = gridView1.GetRowCellValue(item, "POCode").ToString();
                string partCode = gridView1.GetRowCellValue(item, "PartCode").ToString();
                string partName = PartDAO.Instance.NamePartByCode(partCode);
                string quantity = gridView1.GetRowCellValue(item, "Quantity").ToString();
                string barCode = "KUN" + poCode + " " + quantity;
                listP.Add(new POCodeDTO(poCode.ToUpper(), partCode, partName, barCode));
            }
            rpBarCodePO report = new rpBarCodePO();
            report.DataSource = listP;
            report.LoadData();
            report.PrintDialog();
        }
    }
}
