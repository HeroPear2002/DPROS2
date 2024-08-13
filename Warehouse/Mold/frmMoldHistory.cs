using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;

namespace WareHouse.Mold
{
    public partial class frmMoldHistory : Form
    {
        public frmMoldHistory()
        {
            InitializeComponent();
            LoadControl();
        }
        void LoadControl()
        {
            LoadMoldCode();
            LoadMachine();
            LoadDetailMold();
            LoadErrorMold();
            LoadTribeMold();
            KhoaDK();
            XoaText();
            gridView2.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
        }
        void LoadMoldCode()
        {
            cbMoldCode.DataSource = MoldDAO.Instance.GetListMold();
            cbMoldCode.DisplayMember = "MoldCode";
            cbMoldCode.ValueMember = "MoldCode";
        }
        void LoadData()
        {
            string MoldCode = cbMoldCode.Text;
            GCData.DataSource = MoldDAO.Instance.GetListMoldHistory(MoldCode);
        }
        void KhoaDK()
        {
            txtId.Enabled = false;
            cbMachine.Enabled = false;
            cbCategory.Enabled = false;
            cbErrorM.Enabled = false;
            cbTribe.Enabled = false;
            txtDetail.Enabled = false;
            dtpkDateStart.Enabled = false;
            dtpkDateEnd.Enabled = false;
            dtpkDateError.Enabled = false;
            nudTime.Enabled = false;
            txtDetail1.Enabled = false;
            txtDetail2.Enabled = false;
            txtDetail3.Enabled = false;
            txtDetail4.Enabled = false;
            txtDetail5.Enabled = false;
            txtDetail6.Enabled = false;

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
        }
        void MoKhoaDK()
        {
            txtId.Enabled = false;
            cbMachine.Enabled = true;
            cbCategory.Enabled = true;
            cbErrorM.Enabled = true;
            cbTribe.Enabled = true;
            txtDetail.Enabled = true;
            dtpkDateStart.Enabled = true;
            dtpkDateEnd.Enabled = true;
            dtpkDateError.Enabled = true;
            nudTime.Enabled = true;
            txtDetail1.Enabled = true;
            txtDetail2.Enabled = true;
            txtDetail3.Enabled = true;
            txtDetail4.Enabled = true;
            txtDetail5.Enabled = true;
            txtDetail6.Enabled = true;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }
        void AddText()
        {
            try
            {
                txtId.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Id"]).ToString();
                cbMachine.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["MachineCode"]).ToString();
                cbCategory.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Category"]).ToString();
                cbErrorM.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Error"]).ToString();
                cbTribe.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["TribeError"]).ToString();
                txtDetail.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Detail"]).ToString();
                dtpkDateStart.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["DateStart"]).ToString();
                dtpkDateEnd.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["DateEnd"]).ToString();
                dtpkDateError.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["DateError"]).ToString();
                nudTime.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["TotalTime"]).ToString();
                txtDetail1.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Detail1"]).ToString();
                txtDetail2.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Detail2"]).ToString();
                txtDetail3.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Detail3"]).ToString();
                txtDetail4.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Detail4"]).ToString();
                txtDetail5.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Detail5"]).ToString();
                txtDetail6.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Detail6"]).ToString();
            }
            catch
            {
            }
        }
        void XoaText()
        {
            txtId.Text = String.Empty;
            cbMachine.Text = String.Empty;
            cbCategory.Text = String.Empty;
            cbErrorM.Text = String.Empty;
            cbTribe.Text = String.Empty;
            txtDetail.Text = String.Empty;
            dtpkDateStart.Text = String.Empty;
            dtpkDateEnd.Text = String.Empty;
            dtpkDateError.Text = String.Empty;
            nudTime.Text = String.Empty;
            txtDetail1.Text = String.Empty;
            txtDetail2.Text = String.Empty;
            txtDetail3.Text = String.Empty;
            txtDetail4.Text = String.Empty;
            txtDetail5.Text = String.Empty;
            txtDetail6.Text = String.Empty;
        }
        void LoadMachine()
        {
            List<MachineDTO> listM = MachineDAO.Instance.GetListMachine();
            cbMachine.DataSource = listM;
            cbMachine.DisplayMember = "MachineCode";
            cbMachine.ValueMember = "MachineCode";
        }
        void LoadErrorMold()
        {
            cbErrorM.DataSource = MoldDAO.Instance.GetListErrorMold();
            cbErrorM.DisplayMember = "NameError";
            cbErrorM.ValueMember = "Id";
        }
        void LoadDetailMold()
        {
            cbCategory.DataSource = MoldDAO.Instance.GetListCategoryMold(); ;
            cbCategory.DisplayMember = "NameError";
            cbCategory.ValueMember = "Id";
        }
        void LoadTribeMold()
        {
            cbTribe.DataSource = MoldDAO.Instance.GetListTribeMold(); ;
            cbTribe.DisplayMember = "NameError";
            cbTribe.ValueMember = "Id";
        }
        #region Event
        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            MoKhoaDK();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn thực sự muốn xóa thông tin này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView2.GetSelectedRows()) 
                {
                    int id = int.Parse(gridView2.GetRowCellValue(item, "Id").ToString());
                    MoldDAO.Instance.DeleteMoldHistory(id);
                }
                LoadControl();
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int Id = int.Parse(txtId.Text);
            string MachineCode = cbMachine.Text;
            DateTime DateError = dtpkDateError.Value;
            string Category = cbCategory.Text;
            string Error = cbErrorM.Text;
            string Tribe = cbTribe.Text;
            string Detail = txtDetail.Text;
            DateTime DateStart = dtpkDateStart.Value;
            DateTime DateEnd = dtpkDateEnd.Value;
            float totalTime = (float)Convert.ToDouble(nudTime.Text);
            string Detail1 = txtDetail1.Text;
            string Detail2 = txtDetail2.Text;
            string Detail3 = txtDetail3.Text;
            string Detail4 = txtDetail4.Text;
            string Detail5 = txtDetail5.Text;
            string Detail6 = txtDetail6.Text;
            MoldDAO.Instance.UpdateHistoryMold(Id, MachineCode, DateError, Category, Error, Tribe, Detail, DateStart, DateEnd, totalTime, Detail1, Detail2, Detail3, Detail4, Detail5, Detail6);
            int countShot = int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["CountShort"]).ToString());
            int totalShot = int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["TotalShort"]).ToString());
            MoldDAO.Instance.UpdateHistoryCountMold(Id, countShot, totalShot);
            MessageBox.Show("sửa thông tin thành công !".ToUpper());
            LoadControl();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }
        #endregion
        private void cbMoldCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void GCData_Click(object sender, EventArgs e)
        {
            AddText();
        }

        private void btnViewImage_Click(object sender, EventArgs e)
        {
            string mold = cbMoldCode.Text;
            try
            {
                Process.Start("\\\\adc\\DATA\\Dong_Duong\\PRO\\05_Tool\\Hồ sơ khuôn\\Lý lịch sửa chữa\\" + mold);
            }
            catch
            {
                XtraMessageBox.Show("File " + mold + " không tồn tại".ToUpper());
            }

        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            string mold = cbMoldCode.Text;
            try
            {
                Process.Start("\\\\adc\\DATA\\Dong_Duong\\PRO\\05_Tool\\Hồ sơ khuôn\\Lý lịch khuôn\\" + mold + ".xlsx");
            }
            catch
            {
                XtraMessageBox.Show("File " + mold + " không tồn tại".ToUpper());

            }

        }


    }
}
