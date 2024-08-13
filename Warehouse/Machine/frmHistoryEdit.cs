using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DevExpress.XtraLayout;

namespace WareHouse.Machine
{
    public partial class frmHistoryEdit : Form
    {
        public frmHistoryEdit()
        {
            InitializeComponent();
            LoadControl();
            gridView1.CustomDrawRowIndicator += gridView1_CustomDrawRowIndicator;
            gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
        }
        public EventHandler LamMoi;
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
        public bool Isinsert = false;
        #region Control
        void LoadControl()
        {
            LoadData();
            LockControl();
            DeleteText();
            LoadMachine();
        }
        void LoadMachine()
        {
            string nameMachine = MachineDAO.Instance.GetMachine(Kun_Static.MachineCode).MachineName;
            lCMachine.Text = "Lý lịch sửa chữa máy " + Kun_Static.MachineCode + "=>" + nameMachine;
        }
        void LoadData()
        {
            gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            GCData.DataSource = MachineDAO.Instance.GetListEdit(Kun_Static.MachineCode);
        }
        void LockControl()
        {
            dtpkDate.Enabled = false;
            nudtime.Enabled = false;
            txtDetail.Enabled = false;
            txtEmployess.Enabled = false;
            txtErrorName.Enabled = false;
            txtnote.Enabled = false;
            txtReason.Enabled = false;
            txtTimeStart.Enabled = false;
            txtTimeMain.Enabled = false;
            dtpkDateError.Enabled = false;

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
        }
        void OpenControl()
        {
            dtpkDate.Enabled = true;
            nudtime.Enabled = true;
            txtDetail.Enabled = true;
            txtEmployess.Enabled = true;
            txtErrorName.Enabled = true;
            txtnote.Enabled = true;
            txtReason.Enabled = true;
            txtTimeStart.Enabled = true;
            dtpkDateError.Enabled = true;
            txtTimeMain.Enabled = true;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }
        void DeleteText()
        {
            txtID.Text = String.Empty;
            dtpkDate.Text = String.Empty;
            nudtime.Text = String.Empty;
            txtDetail.Text = String.Empty;
            txtEmployess.Text = String.Empty;
            txtErrorName.Text = String.Empty;
            txtnote.Text = String.Empty;
            txtReason.Text = String.Empty;
            txtTimeStart.Text = String.Empty;
            txtTimeMain.Text = String.Empty;
            dtpkDateError.Text = String.Empty;
        }
        void AddText()
        {
            try
            {
                txtID.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Id"]).ToString();
                dtpkDate.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["DateMachine"]).ToString();
                nudtime.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["TimeMachine"]).ToString();
                txtDetail.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Detail"]).ToString();
                txtEmployess.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Employess"]).ToString();
                txtErrorName.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["ErrorName"]).ToString();
                txtnote.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Note"]).ToString();
                txtReason.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Reason"]).ToString();
                txtTimeStart.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["TimeStart"]).ToString();
                txtTimeMain.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["TimeMain"]).ToString();
                dtpkDateError.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["DateError"]).ToString(); ;
            }
            catch
            {
            }
        }
        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DeleteText();
            OpenControl();
            Isinsert = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            OpenControl();
            Isinsert = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn thực sự muốn xóa thông tin này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    long id = long.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    MachineDAO.Instance.DeleteEdit(id);
                }
                LoadControl();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DateTime DateMachine = dtpkDate.Value;
            DateTime DateError = dtpkDateError.Value;
            int TimeMachine = (int)nudtime.Value;
            string MachineCode = Kun_Static.MachineCode;
            string ErrorName = txtErrorName.Text;
            string Reason = txtReason.Text;
            string Detail = txtDetail.Text;
            string Employess = txtEmployess.Text;
            string Note = txtnote.Text;
            string timeStart = txtTimeStart.Text;
            string timeMain = txtTimeMain.Text;
            int testMachine = MachineDAO.Instance.TestMachineByCode(MachineCode);
            if (testMachine == -1)
            {
                MessageBox.Show("mã thiết bị không đúng !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Isinsert == true)
            {
                MachineDAO.Instance.InsertEdit(DateMachine, TimeMachine, MachineCode, ErrorName, Reason, Detail, Employess, Note, DateError, timeStart, timeMain);
                MessageBox.Show("thêm thông tin thành công !".ToUpper());
                LoadControl();
            }
            else
            {
                long Id = long.Parse(txtID.Text);
                MachineDAO.Instance.UpdateEdit(Id, DateMachine, TimeMachine, MachineCode, ErrorName, Reason, Detail, Employess, Note, DateError, timeStart, timeMain);
                MessageBox.Show("sửa thông tin thành công !".ToUpper());
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

        private void txtTimeStart_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && (e.KeyChar != '.' ||
             (e.KeyChar == '.' && (txtTimeStart.Text.Length == 0 || txtTimeStart.Text.IndexOf('.') != -1))))
                e.Handled = true;
        }

        private void txtTimeMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && (e.KeyChar != '.' ||
             (e.KeyChar == '.' && (txtTimeMain.Text.Length == 0 || txtTimeMain.Text.IndexOf('.') != -1))))
                e.Handled = true;
        }

        private void frmHistoryEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }
    }
}
