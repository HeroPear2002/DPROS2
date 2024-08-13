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
using DTO;
using WareHouse.Weather;

namespace WareHouse
{
    public partial class frmWeather : Form
    {
        public frmWeather()
        {
            InitializeComponent();
            LoadControl();
        }
        public bool Isinsert = false;
        #region Control()
        void LoadControl()
        {
            LockControl();
            LoadData();
            LoadLocation();
            DeleteText();
        }
        void LoadData()
        {
            GCData.DataSource = WeatherDAO.Instance.GetlistWeather().OrderByDescending(x=>x.DateWeater);
        }
        void LockControl()
        {
            cbWhere.Enabled = false;
            txtC.Enabled = false;
            txtF.Enabled = false;

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
        }
        void OpenControl()
        {
            cbWhere.Enabled = true;
            txtC.Enabled = true;
            txtF.Enabled = true;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }
        void DeleteText()
        {
            cbWhere.Text = String.Empty;
            txtF.Text = String.Empty;
            txtC.Text = String.Empty;
        }
        void AddText()
        {
            try
            {
                txtId.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Id"]).ToString();
                txtC.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Temperature"]).ToString();
                txtF.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Humidity"]).ToString();
                cbWhere.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Location"]).ToString();
            }
            catch
            {

            }
        }
        void LoadLocation()
        {
            cbWhere.DataSource = WeatherDAO.Instance.GetlistLocation();
            cbWhere.DisplayMember = "NameLocation";
            cbWhere.ValueMember = "NameLocation";
        }
        #endregion
        #region Event
        private void btnWhere_Click(object sender, EventArgs e)
        {
            frmLocationWeather f = new frmLocationWeather();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenControl();
            DeleteText();
            Isinsert = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            OpenControl();
            Isinsert = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
          if(MessageBox.Show("bạn thực sự muốn xóa thông tin này?","Thông Báo",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    int Id = int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    WeatherDAO.Instance.DeleteWeather(Id);
                }
                LoadControl();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string name = cbWhere.Text;
            float c = (float)Convert.ToDouble(txtC.Text);
            float f = (float)Convert.ToDouble(txtF.Text);
            DateTime today = DateTime.Now;
            if (Isinsert == true)
            {
                int test = WeatherDAO.Instance.TestWeather(name, today);
                if(test == -1)
                {
                    WeatherDAO.Instance.InsertWeather(name, c, f, today, Kun_Static.accountDTO.UserName);
                    MessageBox.Show("thêm thông tin thành công !".ToUpper());
                    LoadControl();
                }
                else
                {
                    MessageBox.Show("bạn đã kiểm tra vị trí này rồi".ToUpper(),"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    LoadControl();
                }
            }
            else
            {
                int id = int.Parse(txtId.Text);
                WeatherDAO.Instance.UpdateWeather(id,name, c, f);
                MessageBox.Show("Sửa thông tin thành công !".ToUpper());
                LoadControl();
            }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }
        #endregion

        private void GCData_Click(object sender, EventArgs e)
        {
            AddText();
        }

        private void frmWeather_Load(object sender, EventArgs e)
        {

        }
    }
}
