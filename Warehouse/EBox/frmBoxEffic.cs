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


namespace WareHouse.EBox
{
    public partial class frmBoxEffic : Form
    {
        public frmBoxEffic()
        {
            InitializeComponent();
            LoadControl();
        }
        void LoadControl()
        {
            GCData.DataSource = BoxDAO.Instance.GetListBoxEffic();
        }
        private void btnExxcel_Click(object sender, EventArgs e)
        {
            frmFormBoxEffic f = new frmFormBoxEffic();
            f.ShowDialog();
        }
        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmInportBoxEffic f = new frmInportBoxEffic();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }
        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
        
            if (e.RowHandle >= 0) // chỉ xử lý trong cột họ tên thôi 
            {
                for (int i = -1; i <= e.RowHandle; i++)
                {
                    int AVG = int.Parse(view.GetRowCellValue(e.RowHandle, view.Columns["Iventory"]).ToString());
                    if (AVG > 0)
                    {
                            e.Appearance.BackColor = Color.Orange;
                            e.Appearance.ForeColor = Color.White;
                    }
                    else if(AVG ==0)
                    {
                        e.Appearance.BackColor = Color.White;
                        e.Appearance.ForeColor = Color.Black;
                    }
                    else
                    {
                        e.Appearance.BackColor = Color.Purple;
                        e.Appearance.ForeColor = Color.White;
                    }
                }

            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("bạn thực sự muốn xóa thông tin này?","Thông Báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    string PartCode = gridView1.GetRowCellValue(item, "PartCode").ToString();
                    string DateNew = gridView1.GetRowCellValue(item, "DateNew").ToString();
                    int Id = BoxDAO.Instance.TestBoxEffic(DateNew, PartCode);
                    BoxDAO.Instance.DeleteBoxEffic(Id);
                }
                LoadControl();
            }
        }
    }
}
