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

namespace WareHouse
{
    public partial class frmWarehouseSetup : Form
    {
        public frmWarehouseSetup()
        {
            InitializeComponent();
            LoadControl();
        }
       public EventHandler LamMoi;
        void LoadControl()
        {
            btnSave.Enabled = false;
            nudHeight.Enabled = false;
            GCData.DataSource = WareHouseDAO.Instance.GetlistWHLock();
        }
        private void frmWarehouseSetup_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }
        #region Event
        private void btnLook_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    int id = int.Parse(gridView1.GetRowCellValue(item,"Id").ToString());
                    WareHouseDAO.Instance.UpdateStatusWH(id, 5);
                }
                MessageBox.Show("Khóa vị trí thành công !".ToUpper());
                LoadControl();
            }
            catch 
            {
                MessageBox.Show("Error !".ToUpper());
            }

        }

        private void btnUnlook_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    int id = int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    WareHouseDAO.Instance.UpdateStatusWH(id, 1);
                }
                MessageBox.Show("mở Khóa vị trí thành công !".ToUpper());
                LoadControl();
            }
            catch
            {
                MessageBox.Show("Error !".ToUpper());
            }

        }

        private void btnEditHeight_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            nudHeight.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int height = (int)nudHeight.Value;
            try
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    int id = int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    WareHouseDAO.Instance.UpdateHeightWH(id, height);
                }
                MessageBox.Show("sửa thông tin thành công !".ToUpper());
                LoadControl();
            }
            catch
            {
                MessageBox.Show("Error !".ToUpper());
            }
        }
        #endregion
    }
}
