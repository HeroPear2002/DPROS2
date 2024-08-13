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

namespace WareHouse.QC
{
    public partial class frmConfirmEquipment : Form
    {
        public frmConfirmEquipment()
        {
            InitializeComponent();
            LoadControl();
        }
        #region Control()
        void LoadControl()
        {
            LockControl();
            LoadData();
        }
        void LockControl()
        {
            dtpkDateCheck.Enabled = false;
            txtEmployess.Enabled = false;
            txtPeople.Enabled = false;
            btnSave.Enabled = false;
        }
        void OpenControl()
        {
            dtpkDateCheck.Enabled = true;
            txtEmployess.Enabled = true;
            txtPeople.Enabled = true;
            btnSave.Enabled = true;
        }
        void LoadData()
        {
            GCData.DataSource = EquipmentDAO.Instance.GetListEquipmentByStatusCheck();
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            string employess = txtEmployess.Text;
            string people = txtPeople.Text;
            DateTime date = dtpkDateCheck.Value;
            foreach (var item in gridView1.GetSelectedRows())
            {
                string code = gridView1.GetRowCellValue(item, "EquipmentCode").ToString();
                EquipmentDAO.Instance.InsertHistoryEquipment(code, date, people, employess);
            }
            LoadControl();
        }

        private void GCData_Click(object sender, EventArgs e)
        {
            OpenControl();
        }
    }
}
