using DevExpress.XtraGrid.Views.Grid;
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

namespace WareHouse.PCGridControl
{
    public partial class frmListKHBD : Form
    {
        public frmListKHBD()
        {
            InitializeComponent();
            LoadControl();
        }
        bool Isinsert = false;
        #region Control
        void LoadControl()
        {
            LockControl();
            LoadData();
            LoadPartCode();
        }
        void LoadData()
        {
           GCData.DataSource = TDSXDAO.Instance.GetListKHBD();
        }
        void LockControl()
        {
            cbPartCode.Enabled = false;
            cbMachineCode.Enabled = false;
            cbMoldCode.Enabled = false;
            nudQuantity.Enabled = false;

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
         
        }
        void OpenControl()
        {
            cbPartCode.Enabled = true;
            cbMachineCode.Enabled = true;
            cbMoldCode.Enabled = true;
            nudQuantity.Enabled = true;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }
        void DeleteText()
        {
            cbPartCode.Text = String.Empty;
            cbMachineCode.Text = String.Empty;
            cbMoldCode.Text = String.Empty;
            nudQuantity.Value = 0;
            txtID.Text = String.Empty;
        }
        void AddText()
        {
            try
            {
                cbPartCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["PartCode"]).ToString();
                cbMachineCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["MachineCode"]).ToString();
            }
            catch 
            {
            }
        }
        void LoadPartCode()
        {
            cbPartCode.DataSource = PartDAO.Instance.GetListPart();
            cbPartCode.DisplayMember = "PartCode";
            cbPartCode.ValueMember = "PartCode";
          
        }
        void LoadMoldCode()
        {
            string partCode = cbPartCode.Text; ;
            cbMoldCode.DataSource = MacInforDAO.Instance.GetListMoldByPart(partCode);
            cbMoldCode.DisplayMember = "MoldCode";
            cbMoldCode.ValueMember = "MoldCode";
           
        }
        void LoadMachineCode()
        {
            string partCode = cbPartCode.Text;
            string moldCode = cbMoldCode.Text;
            cbMachineCode.DataSource = MacInforDAO.Instance.GetListMachineByPartMold(partCode, moldCode);
            cbMachineCode.DisplayMember = "MachineCode";
            cbMachineCode.ValueMember = "MachineCode";
        }
        #endregion
        #region Event
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Isinsert = true;
            DeleteText();
            OpenControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Isinsert = false;
            OpenControl();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("bạn thực sự muốn xóa thông tin này ?".ToUpper(),"Thông Báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    long Id = long.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    TDSXDAO.Instance.DeleteKHBDbyId(Id);
                    TDSXDAO.Instance.DeleteKHBDbyId(Id+1);
                }
                LoadControl();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string partCode = cbPartCode.Text;
            string moldCode = cbMoldCode.Text;
            string machineCode = cbMachineCode.Text;
            int count = (int)nudQuantity.Value;
            int second = (int)PartDAO.Instance.CycleTimeByCode(partCode) * count;
            DateTime start = dtpkStart.Value;
            dtpkEnd.Value = start.AddSeconds(second);
            DateTime end = dtpkEnd.Value;
            
            if(Isinsert == true)
            {
                TDSXDAO.Instance.InsertKHBD(machineCode, partCode, moldCode, start, end, count, 1);
                MessageBox.Show("Thêm thông tin thành công !");
                LoadControl();
            }
            else
            {

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }
        #endregion

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            DateTime tomorow = DateTime.Today;
            if (e.RowHandle >= 0) // chỉ xử lý trong cột họ tên thôi 
            {
                DateTime today = DateTime.Parse(view.GetRowCellValue(e.RowHandle, view.Columns["StartTime"]).ToString());
                if (today > tomorow)
                {
                    e.Appearance.BackColor = Color.Bisque;
                    e.Appearance.ForeColor = Color.Black;
                }               
            }
        }

        private void cbPartCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMoldCode();
        }

        private void cbMoldCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMachineCode();
        }
    }
}
