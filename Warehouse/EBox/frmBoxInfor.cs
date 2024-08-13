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

namespace WareHouse.EBox
{
    public partial class frmBoxInfor : Form
    {


        public frmBoxInfor()
        {
            InitializeComponent();
            LoadControl();
        }
        public bool IsInsert = false;

        #region Control
        void LoadControl()
        {
            LoadData();
            KhoaDK();
            XoaText();
            LoadBoxCode();
            LoadPartCode();
        }
        void LoadData()
        {
            GCData.DataSource = BoxDAO.Instance.GetListBoxInfor();
        }
        void KhoaDK()
        {
            cbBoxList.Enabled = false;
            cbPartCode.Enabled = false;
            

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
        }
        void MoKhoaDK()
        {
            cbBoxList.Enabled = true;
            cbPartCode.Enabled = true;
           

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }
        void XoaText()
        {
            cbPartCode.Text = String.Empty;
            cbBoxList.Text = String.Empty;
            cbID.Text = String.Empty;
        }
        void AddText()
        {
            try
            {
                cbBoxList.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["BoxCode"]).ToString();
                cbPartCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["PartCode"]).ToString();
                cbID.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Id"]).ToString();
            }
            catch 
            {

            }
   
        }
        void LoadBoxCode()
        {
            cbBoxList.DataSource = BoxDAO.Instance.GetListBox();
            cbBoxList.DisplayMember = "BoxCode";
            cbBoxList.ValueMember = "BoxCode";
        }
        void LoadPartCode()
        {
            cbPartCode.DataSource = PartDAO.Instance.GetListPart();
            cbPartCode.DisplayMember = "PartCode";
            cbPartCode.ValueMember = "PartCode";
        }

        #endregion
        #region Event
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(2, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MoKhoaDK();
            IsInsert = true;
            XoaText();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(2, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MoKhoaDK();
            IsInsert = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(2, Kun_Static.accountDTO.Type, user);
            if (check < 2)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("bạn thực sự muốn xóa thông tin này ?".ToUpper(),"Thông Báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    int Id = int.Parse(gridView1.GetRowCellValue(item,"Id").ToString());
                    BoxDAO.Instance.DeleteBoxInfor(Id);
                }
                LoadControl();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string BoxCode = cbBoxList.Text;
            string PartCode = cbPartCode.Text;
            if(IsInsert == true)
            {
                BoxDAO.Instance.InsertBoxInfor(BoxCode, PartCode);
                MessageBox.Show("thêm thông tin thành công !".ToUpper());
                LoadControl();
            }
            else
            {
                int Id = int.Parse(cbID.Text);
                BoxDAO.Instance.UpdateBoxInfor(Id,BoxCode, PartCode);
                MessageBox.Show("thêm thông tin thành công !".ToUpper());
                LoadControl();
            }
        }
        #endregion
        private void GCData_Click(object sender, EventArgs e)
        {
            AddText();
        }
        private void btnDownload_Click(object sender, EventArgs e)
        {
            frmFormBoxInfor f = new frmFormBoxInfor();
            f.ShowDialog();
        }
        private void btnInport_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(2, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmInportBoxInfor f = new frmInportBoxInfor();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }
    }
}
