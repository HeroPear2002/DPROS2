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

namespace WareHouse.Weather
{
    public partial class frmLocationWeather : Form
    {
        public frmLocationWeather()
        {
            InitializeComponent();
            LoadControl();
        }
        public EventHandler LamMoi;
        public bool IsInsert = false;

        #region Control()
        void LoadControl()
        {
            LockControl();
            LoadData();
            DeleteText();
        }
        void LoadData()
        {
            GCData.DataSource = WeatherDAO.Instance.GetlistLocation();
        }
        void LockControl()
        {
            txtLocation.Enabled = false;

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
        }
        void OpenControl()
        {
            txtLocation.Enabled = true;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }
        void DeleteText()
        {
            txtLocation.Text = String.Empty;
            txtID.Text = String.Empty;
        }
        void AddText()
        {
            try
            {
                txtID.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Id"]).ToString();
                txtLocation.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["NameLocation"]).ToString();
            }
            catch
            {

            }
        }
        #endregion
        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenControl();
            DeleteText();
            IsInsert = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            OpenControl();
            IsInsert = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn thực sự muốn xóa thông tin này ?", "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    int Id = int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    WeatherDAO.Instance.DeleteLocation(Id);
                }
                LoadControl();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtLocation.Text;
            if (IsInsert == true)
            {
                WeatherDAO.Instance.InsertLocation(name);
                MessageBox.Show("thêm thông tin thành công !".ToUpper());
                LoadControl();
            }
            else
            {
                int id = int.Parse(txtID.Text);
                WeatherDAO.Instance.UpdateLocation(id, name);
                MessageBox.Show("sửa thông tin thành công !".ToUpper());
                LoadControl();
            }
        }

        private void frmLocationWeather_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            AddText();
        }
    }
}
