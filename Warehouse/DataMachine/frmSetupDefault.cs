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


namespace WareHouse.DataMachine
{
    public partial class frmSetupDefault : DevExpress.XtraEditors.XtraForm
    {
        public frmSetupDefault()
        {
            InitializeComponent();
            LoadControl();
            LockControl();
        }
        #region LoadControl
        void LoadControl()
        {
            LoadDataMold();
            LoadDataMachine();
            LoadDataCategory();
            LoadDataSetup();
        }
        void LoadDataMold()
        {
            GCDataMold.DataSource = MoldDAO.Instance.GetListMold();
        }
        void LoadDataMachine()
        {
            GCDataMachine.DataSource = MachineDAO.Instance.GetListMachineByDevice(1);
        }
        void LoadDataCategory()
        {
            GCDataCategory.DataSource = DataMachineDAO.Instance.GetListCategoryDefault();
        }
        void LoadDataSetup()
        {
            GCDataSetup.DataSource = DataMachineDAO.Instance.GetListSetupDefault();
        }
        void LockControl()
        {
            txtValue.Enabled = false;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            float value = 0;
            try
            {
                value = (float)Convert.ToDouble(txtValue.Text);
            }
            catch
            {
            }
            if (value == 0)
            {
                MessageBox.Show("bạn chưa điền giá trị tiêu chuẩn !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("bạn muốn lưu thông tin này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (var itemMold in gridView1.GetSelectedRows())
                {
                    string moldCode = gridView1.GetRowCellValue(itemMold, "MoldCode").ToString();
                    foreach (var itemMachine in gridView2.GetSelectedRows())
                    {
                        string machineCode = gridView2.GetRowCellValue(itemMachine, "MachineCode").ToString();
                        foreach (var itemCategory in gridView3.GetSelectedRows())
                        {
                            int idCategory = int.Parse(gridView3.GetRowCellValue(itemCategory, "Id").ToString());
                            long test = DataMachineDAO.Instance.IdSetupdefault(idCategory, moldCode, machineCode);
                            if (test == -1)
                            {
                                DataMachineDAO.Instance.InsertSetupDefault(idCategory, moldCode, machineCode, value);
                            }
                        }
                    }
                }
                LoadDataSetup();
                LockControl();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn thực sự muốn xóa thông tin này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView4.GetSelectedRows())
                {
                    long id = long.Parse(gridView4.GetRowCellValue(item, "Id").ToString());
                    DataMachineDAO.Instance.DeleteSetupdefault(id);
                }
                LoadDataSetup();
            }
        }

        private void GCDataCategory_Click(object sender, EventArgs e)
        {
            txtValue.Enabled = true;
            btnSave.Enabled = true;
        }

        private void GCDataSetup_Click(object sender, EventArgs e)
        {
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn muốn sửa những thông tin này?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView4.GetSelectedRows())
                {
                    long id = long.Parse(gridView4.GetRowCellValue(item, "Id").ToString());
                    float value = (float)Convert.ToDouble(gridView4.GetRowCellValue(item, "ValueDefault").ToString());
                    DataMachineDAO.Instance.UpdateSetupdefault(id, value);
                }
                LoadControl();
                LockControl();
            }
        }
    }
}