using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
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
using WareHouse.Report;

namespace WareHouse.PO_and_Order
{
    public partial class frmPOInput : Form
    {
        public frmPOInput()
        {
            InitializeComponent();
            LoadControl();
        }
        void LoadControl()
        {
            LockControl();
            LoadAsyc();
            LoadAsycLoadStatus();
            LoadListPO();
            LoadMaPro();
            LoadFactory();
            LoadCustomer();
            gridView1.CustomDrawRowIndicator += gridView1_CustomDrawRowIndicator;
        }
        async void LoadAsycLoadStatus()
        {
            await LoadStatus();
           
        }
        async void LoadAsyc()
        {
            await LoadUpdatePO(dtpkDateOut.Value);
        }
        public bool IsInsert = false;
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
        #region :Control
        void LockControl()
        {
            txtPOCode.Enabled = false;
            cbPartCode.Enabled = false;
            nudQuantity.Enabled = false;
            txtPrice.Enabled = false;
            cbCustomer.Enabled = false;
            dtpkDateInput.Enabled = false;
            dtpkDateOut.Enabled = true;
            cbFactoryCode.Enabled = false;

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
        }
        void OpenControl()
        {
            txtPOCode.Enabled = true;
            cbPartCode.Enabled = true;
            nudQuantity.Enabled = true;
            txtPrice.Enabled = true;
            cbCustomer.Enabled = true;
            dtpkDateInput.Enabled = true;
            dtpkDateOut.Enabled = true;
            cbFactoryCode.Enabled = true;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }
        void ClearText()
        {
            txtPOCode.Text = String.Empty;
            cbPartCode.Text = String.Empty;
            nudQuantity.Text = String.Empty;
        }
        public static async Task LoadStatus()
        {
            await Task.Run(() =>
            {
                List<PODTO> listP = PODAO.Instance.GetListPOInput();
                DateTime today = DateTime.Now;
                foreach (PODTO item in listP)
                {
                    if (item.Quantity == 0)
                    {
                        PODAO.Instance.UpdateStatusPO(item.Id, 1);
                    }
                    else
                    {
                        int warn = CustomerDAO.Instance.WarnPOInput(item.Customer);
                        int a = (int)(item.DateOut.Date - today.Date).TotalDays;
                        if (a == 0)
                        {
                            PODAO.Instance.UpdateStatusPO(item.Id, 3);
                        }
                        else if (a < 0)
                        {
                            PODAO.Instance.UpdateStatusPO(item.Id, 4);
                        }
                        else if (a <= warn)
                        {
                            PODAO.Instance.UpdateStatusPO(item.Id, 2);
                        }
                        else if (a > warn && item.StatusPO != 1)
                        {
                            PODAO.Instance.UpdateStatusPO(item.Id, 0);
                        }
                    }
                }
            });

        }
        public static async Task LoadUpdatePO(DateTime today)
        {
            await Task.Run(() =>
            {
                List<PODTO> listP = new List<PODTO>();
                DateTime date1 = today.AddDays(1 - today.Day);
                DateTime date2 = date1.AddMonths(1).AddSeconds(-10);
                listP = PODAO.Instance.GetListAllPOInput(date1, date2);
                foreach (PODTO item in listP.Where(x => x.StatusPO == 2).ToList())
                {
                    List<OnlyDateOutput> listO = PODAO.Instance.GetListOnlyDateOut(item.Id);
                    if (listO.Count == 0)
                    {
                        PODAO.Instance.UpdateStatusPO(item.Id, 0);
                        PODAO.Instance.UpdateQuantityOut(item.Id, 0);
                    }
                    else
                    {
                        int sum = PODAO.Instance.SumQuantityOut(item.Id);
                        if (sum == item.QuantityIn)
                        {
                            PODAO.Instance.UpdateStatusPO(item.Id, 1);
                            PODAO.Instance.UpdateQuantityOut(item.Id, item.QuantityOut);
                        }
                    }
                }
                foreach (PODTO item in listP.Where(x => x.StatusPO == 1).ToList())
                {
                    int sum = PODAO.Instance.SumQuantityOut(item.Id);
                    if (sum != item.QuantityIn)
                    {
                        PODAO.Instance.UpdateStatusPO(item.Id, 0);
                    }
                }
            });
        }
        void LoadListPO()
        {
            List<PODTO> listP = PODAO.Instance.GetListPOInput();
            GCData.DataSource = listP;
        }
        void AddText()
        {
            try
            {
                txtPOCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["POCode"]).ToString();
                cbPartCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["PartCode"]).ToString();
                nudQuantity.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["QuantityIn"]).ToString();
                dtpkDateInput.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["DateInput"]).ToString();
                cbFactoryCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["FactoryCode"]).ToString();
                cbCustomer.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Customer"]).ToString();
                txtPrice.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Price"]).ToString();
                dtpkDateOut.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["DateOut"]).ToString();
            }
            catch
            { }
        }
        void LoadMaPro()
        {
            List<PartDTO> listLK = PartDAO.Instance.GetListPart();
            cbPartCode.DataSource = listLK;
            cbPartCode.ValueMember = "PartCode";
            cbPartCode.DisplayMember = "PartCode";

        }
        void LoadFactory()
        {
            cbFactoryCode.DataSource = FactoryDAO.Instance.GetListDistinctAllFactory();
            cbFactoryCode.DisplayMember = "FactoryCode";
            cbFactoryCode.ValueMember = "FactoryCode";
        }
        void LoadCustomer()
        {
            cbCustomer.DataSource = CustomerDAO.Instance.GetListCustomerDTO();
            cbCustomer.DisplayMember = "CustomerCode";
            cbCustomer.ValueMember = "CustomerCode";
        }
        #endregion
        #region Event

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(2, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            IsInsert = true;
            OpenControl();
            ClearText();
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
            IsInsert = false;
            OpenControl();
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
            if (MessageBox.Show("bạn thực sự muốn xóa thông tin này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    long Id = long.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    List<POFixDTO> listPO = POFixDAO.Instance.GetListPOFix(Id);
                    if (listPO.Count == 0)
                    {
                        PODAO.Instance.DeletePO(Id);
                    }
                }
                LoadControl();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string POCode = txtPOCode.Text;
            if (POCode.Trim().Length == 0)
            {
                MessageBox.Show("bạn hãy điền mã PO!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string PartCode = cbPartCode.Text;
            if (PartCode.Trim().Length == 0)
            {
                MessageBox.Show("bạn hãy điền mã linh kiện!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string FactoryCode = cbFactoryCode.Text;
            string Customer = cbCustomer.Text;
            if (CustomerDAO.Instance.TestCustomerDTO(Customer) == -1)
            {
                MessageBox.Show("mã khách hàng không chính xác !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string Price = txtPrice.Text;
            int quantity = (int)nudQuantity.Value;
            if (quantity == 0)
            {
                MessageBox.Show("bạn chưa điền số lượng!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime DateInput = dtpkDateInput.Value;
            DateTime DateOut = dtpkDateOut.Value;
            if (FactoryDAO.Instance.TestFactoryByFacCode(FactoryCode) == -1)
            {
                MessageBox.Show("mã nhà máy chính xác !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (IsInsert == true)
            {
                long test = PODAO.Instance.TestPO(POCode, PartCode, Price);
                if (test > -1)
                {
                    MessageBox.Show("thông tin này đã tồn tại !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    PODAO.Instance.InsertPO(POCode, PartCode, quantity, DateInput, 0, FactoryCode, Price, DateOut, Customer);
                    MessageBox.Show("thêm thông tin thành công!".ToUpper());
                    LoadControl();
                }
            }
            else
            {
                long Id = long.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Id"]).ToString());
                PODAO.Instance.UpdatePO(Id, POCode, PartCode, quantity, DateInput, 0, FactoryCode, Price, DateOut, Customer);
                MessageBox.Show("sửa thông tin thành công!".ToUpper());
                LoadControl();
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadControl();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            frmInportPO f = new frmInportPO();
            f.LamMoi += new EventHandler(btnView_Click);
            f.ShowDialog();
        }
        #endregion

        private void GCData_Click(object sender, EventArgs e)
        {
            AddText();
        }
        private void gridView1_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            DateTime today = DateTime.Now.Date;
            if (e.RowHandle >= 0) // chỉ xử lý trong cột họ tên thôi 
            {
                int status = int.Parse(view.GetRowCellValue(e.RowHandle, view.Columns["StatusPO"]).ToString());
                switch (status)
                {
                    case 2:
                        e.Appearance.BackColor = Color.GreenYellow;
                        break;
                    case 3:
                        e.Appearance.BackColor = Color.Yellow;
                        break;
                    case 4:
                        e.Appearance.BackColor = Color.Red;
                        break;
                    default:
                        break;
                }
            }
        }
        private void btnDownload_Click(object sender, EventArgs e)
        {
            frmFormPO f = new frmFormPO();
            f.ShowDialog();
        }

        private void btnPrinter_Click(object sender, EventArgs e)
        {
            List<POCodeDTO> listP = new List<POCodeDTO>();
            foreach (var item in gridView1.GetSelectedRows())
            {
                string poCode = gridView1.GetRowCellValue(item, "POCode").ToString();
                string partCode = gridView1.GetRowCellValue(item, "PartCode").ToString();
                string partName = PartDAO.Instance.NamePartByCode(partCode);
                string quantity = gridView1.GetRowCellValue(item, "QuantityIn").ToString();
                string barCode = "KUN" + poCode + " " + quantity;
                listP.Add(new POCodeDTO(poCode.ToUpper(), partCode, partName, barCode));
            }
            rpBarCodePO report = new rpBarCodePO();
            report.DataSource = listP;
            report.LoadData();
            report.PrintDialog();
            this.Close();
        }

        private void btnViewMonth_Click(object sender, EventArgs e)
        {
            List<PODTO> listP = new List<PODTO>();
            DateTime today = dtpkDateOut.Value.Date;
            DateTime date1 = today.AddDays(1 - today.Day);
            DateTime date2 = date1.AddMonths(1).AddSeconds(-10);
            listP = PODAO.Instance.GetListAllPOInput(date1, date2);
            GCData.DataSource = listP;
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            List<PODTO> listP = new List<PODTO>();
            listP = PODAO.Instance.GetListAllPOInput();
            GCData.DataSource = listP;
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && (e.KeyChar != '.' ||
               (e.KeyChar == '.' && (txtPrice.Text.Length == 0 || txtPrice.Text.IndexOf('.') != -1))))
                e.Handled = true;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Common.ExportExcel.Export(GCData);
        }
        private void GCData_DoubleClick(object sender, EventArgs e)
        {
            Kun_Static.IdPOInput = long.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Id"]).ToString());
            frmDetailPO f = new frmDetailPO();
            f.ShowDialog();
        }
    }
}
