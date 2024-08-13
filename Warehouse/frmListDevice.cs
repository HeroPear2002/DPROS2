using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Tile;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;
using WareHouse.Employess;
using System.Net;

namespace WareHouse
{
    public partial class frmListDevice : Form
    {
        public frmListDevice()
        {
            InitializeComponent();
            LoadControl();
        }
      
        string urlPath = @"\\192.168.2.10\datasave\MACHINE\FILE";
        private WebClient _Wc = new WebClient();
        List<ListDeviceDTO> listD;
        public bool Isinsert = false;

        #region Control
        void LoadControl()
        {
            LoadData();
            LockControl();

        }
        void LoadData()
        {
            listD = MachineDAO.Instance.GetListDevice();
            GCData.DataSource = listD;
        }
     
        void LockControl()
        {
            txtName.Enabled = false;
            txtId.Enabled = false;
            txtLinkEveryDay.Enabled = false;
            txtLinkEveryMainten.Enabled = false;
            btnEveryday.Enabled = false;
            btnMainten.Enabled = false;
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
        }
        void OpenControl()
        {
            txtName.Enabled = true;
            btnEveryday.Enabled = true;
            btnMainten.Enabled = true;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }
        void DeleteText()
        {
            txtName.Text = String.Empty;
       
        }
        void AddText()
        {
            try
            {
                txtId.Text = tileView1.GetRowCellValue(tileView1.FocusedRowHandle, tileView1.Columns["Id"]).ToString();
                txtName.Text = tileView1.GetRowCellValue(tileView1.FocusedRowHandle, tileView1.Columns["Name"]).ToString();
            }
            catch
            {
            }
        }
        #endregion
        #region Event
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Isinsert = true;
            OpenControl();
            DeleteText();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Isinsert = false;
            OpenControl();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn thực sự muốn xóa thông tin này ?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    int Id = int.Parse(txtId.Text);
                    MachineDAO.Instance.DeleteDevice(Id);
                    MachineDAO.Instance.DeleteMachine(Id);
                }
                catch (Exception)
                {
                    MessageBox.Show("bạn chưa chọn thiết bị cần xóa !".ToUpper());
                }

            }
        }
        string LoadNameFile(string url)
        {
            string fileName = Path.GetFileName(url);
            // Use Path class to manipulate file and directory paths.
            string sourceFile = url;
            string destFile = System.IO.Path.Combine(urlPath, fileName);
            if (fileName.Length > 0)
            {
                if (System.IO.File.Exists(destFile))
                {
                    return fileName;
                }
                else
                {
                    try
                    {
                        System.IO.File.Copy(sourceFile, destFile, true);
                        return fileName;
                    }
                    catch 
                    {
                        return "";
                    }
                }
            }
            else
            {
                return "";
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string form = "";
            string urlEveryDay = LoadNameFile(txtLinkEveryDay.Text);
            string urlEveryMainten = LoadNameFile(txtLinkEveryMainten.Text);
            if (Isinsert == true)
            {
                try
                {
                    int _listDeviceDTO = MachineDAO.Instance.GetIdDeviceByName(name);
                    if (_listDeviceDTO != -1)
                    {
                        MessageBox.Show("tên thiết bị đã tồn tại! \n\nbạn hãy thay tên khác !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MachineDAO.Instance.InsertDevice(name, 0, "", form, urlEveryDay, urlEveryMainten);
                        MessageBox.Show("thêm thông tin thành công !".ToUpper());
                        LoadControl();
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("mã đã tồn tại".ToUpper());
                    }
                }
            }
            else
            {
                int id = int.Parse(txtId.Text);
                int status = MachineDAO.Instance.StatusDevice(id);
                MachineDAO.Instance.UpdateDevice(id, name, status, "", form, urlEveryDay, urlEveryMainten);
                MessageBox.Show("thêm thông tin thành công !".ToUpper());
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
            int id = int.Parse(txtId.Text);
            txtLinkEveryDay.Text = System.IO.Path.Combine(urlPath, MachineDAO.Instance.GetItemDevice(id).UrlEveryDay);
            txtLinkEveryMainten.Text = System.IO.Path.Combine(urlPath, MachineDAO.Instance.GetItemDevice(id).UrlEveryMainten);
        }

        private void btnPicter_Click(object sender, EventArgs e)
        {

        }
        private void GCData_DoubleClick(object sender, EventArgs e)
        {
            int Id = int.Parse(txtId.Text);
            Kun_Static.DeviceId = Id;
            Kun_Static.idCheck = 0;
            fMachineMaker f = new fMachineMaker();
            f.Show();
        }

        private void tileView1_ItemCustomize(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemCustomizeEventArgs e)
        {
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {

        }
        #endregion


        private void btnMainten_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtLinkEveryMainten.Text = ofd.FileName;
                }
            }
        }

        private void btnEveryday_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtLinkEveryDay.Text = ofd.FileName;
                }
            }
        }
    }
}
