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
    public partial class frmBoxNature : Form
    {
        public frmBoxNature()
        {
            InitializeComponent();
            LoadControl();
        }
        public bool IsInsert = false;
        #region Control
        void LoadControl()
        {
            LockControl();
            LoadData();
            LoadPartCode();
        }
        void LoadData()
        {
            GCData.DataSource = BoxNatureDAO.Instance.GetlistBox();
        }
        void LockControl()
        {
            txtBoxName.Enabled = false;
            txtID.Enabled = false;
            nudQuantity.Enabled = false;
            txtNote.Enabled = false;

            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
            btnSave.Enabled = false;

        }
        void OpenControl()
        {
            txtBoxName.Enabled = true;
            
            nudQuantity.Enabled = true;
            txtNote.Enabled = true;

            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
        }
        void DeleteText()
        {
            txtID.Text = String.Empty;
            txtBoxName.Text = String.Empty;
            txtNote.Text = String.Empty;
            nudQuantity.Text = String.Empty;
        }
        void AddText()
        {
            try
            {
                txtID.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Id"]).ToString();
                txtNote.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Note"]).ToString();
                txtBoxName.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["BoxName"]).ToString();
                nudQuantity.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Quantity"]).ToString();
            }
            catch
            {
            }
        }
        void LoadPartCode()
        {
            txtNote.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtNote.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection data = new AutoCompleteStringCollection();
            AddItem(data);
            txtNote.AutoCompleteCustomSource = data;
        }
        void AddItem(AutoCompleteStringCollection col)
        {
            List<PartDTO> listP = PartDAO.Instance.GetListPart();
            foreach (PartDTO item in listP)
            {
                col.Add(item.PartCode);
            }
        }

        #endregion
        #region Envent
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(3, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            OpenControl();
            DeleteText();
            IsInsert = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(3, Kun_Static.accountDTO.Type, user);
            if (check < 2)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("bạn muốn xóa thông tin này ?".ToUpper(),"Thông Báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    int Id = int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    BoxNatureDAO.Instance.Delete(Id);
                }
                LoadControl();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(3, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            OpenControl();
            IsInsert = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string BoxName = txtBoxName.Text;
            string note = txtNote.Text;
            int quantity = (int)nudQuantity.Value;
            if(note.Length == 0)
            {
                MessageBox.Show("bạn chưa điền mã linh kiện sử dụng thùng/hộp này !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(IsInsert == true)
            {
                    BoxNatureDAO.Instance.Insert(BoxName, quantity, note);
                    MessageBox.Show("thêm thông tin thành công !".ToUpper());
                    LoadControl();
            }
            else
            {
                int Id = int.Parse(txtID.Text);
                BoxNatureDAO.Instance.Update(Id,BoxName, quantity, note);
                MessageBox.Show("sửa thông tin thành công !".ToUpper());
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
        }
        #endregion


    }
}
