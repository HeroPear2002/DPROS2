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
using DTO;

namespace WareHouse.QC
{
    public partial class frmQCCheck : Form
    {

        public frmQCCheck()
        {
            InitializeComponent();
            LoadControl();
            LoadColum();
            LoadYellow();
         
        }
        void LoadColum()
        {
            gridView1.Columns["Iventory"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Iventory", "Tổng = {0}");
        }
        void LoadControl()
        {
            LoadData();
            LoadStatus();
            btnSaveStatus.Enabled = false;
        }
     
        void LoadStatus()
        {
            cbStatus.DataSource = WareHouseDAO.Instance.StatusWarehouse();
            cbStatus.DisplayMember = "NameStatus";
            cbStatus.ValueMember = "Id";
        }
        void LoadYellow()
        {
            cbYellow.Items.Clear();
            cbYellow.Items.Add("NO");
            cbYellow.Items.Add("YES");

        }
        void AddText()
        {
            try
            {
                cbStatus.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["NameStatus"]).ToString();
                txtNote.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Note"]).ToString();
            }
            catch
            {

            }
        }
        void LoadData()
        {
            GCData.DataSource = IventoryPartDAO.Instance.GetListIventoryPartQC();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(4, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int status = (cbStatus.SelectedItem as StatusWarehouseDTO).Id;
            string Note = txtNote.Text;
            if (MessageBox.Show("bạn muốn đổi trạng thái linh kiện này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    int idWh = int.Parse(gridView1.GetRowCellValue(item, "IdWareHouse").ToString());
                    string yellow = gridView1.GetRowCellValue(item, "Yellow").ToString();
                    string PartCode = gridView1.GetRowCellValue(item, "PartCode").ToString();
                    if (yellow == "NO" && status == 2)
                    {
                        string cbyellow = cbYellow.Text;
                        if (cbyellow != "YES")
                        {
                            string msg = string.Format("mã linh kiện : {0} \n\nchưa phát hành thẻ vàng !".ToUpper(), PartCode);
                            MessageBox.Show(msg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            WareHouseDAO.Instance.UpdateYellowWH(idWh, cbyellow);
                            int id = int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                            IventoryPartDAO.Instance.UpdateNoteInputPart(id, Note);
                        }
                    }
                }
                LoadControl();
            }
        }

        private void GCData_Click(object sender, EventArgs e)
        {
            AddText();
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(4, Kun_Static.accountDTO.Type, user);
            if (check < 2 && cbStatus.Text == "NG")
            {
                MessageBox.Show("bạn không có quyền chuyển trạng thái Pallet này !".ToUpper());
                cbStatus.Text = String.Empty;
                btnSaveStatus.Enabled = false;
                return;
            }
            else
            {
                btnSaveStatus.Enabled = true;
            }
        }
        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0) // chỉ xử lý trong cột họ tên thôi 
            {
                string name = view.GetRowCellValue(e.RowHandle, view.Columns["Name"]).ToString();
                string tt = view.GetRowCellValue(e.RowHandle, view.Columns["NameStatus"]).ToString();
                if (name == "Kho 2")
                {
                    e.Appearance.BackColor = Color.Pink;
                    e.Appearance.ForeColor = Color.Black;
                }
                if (tt == "NG")
                {
                    e.Appearance.ForeColor = Color.Red;
                }
                if (tt == "Rework")
                {
                    e.Appearance.BackColor = Color.Yellow;
                    e.Appearance.ForeColor = Color.Black;
                }
            }
        }

        private void btnYellow_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(4, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("bạn muốn yêu cầu thẻ vàng linh kiện này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    int idWh = int.Parse(gridView1.GetRowCellValue(item, "IdWareHouse").ToString());
                    WareHouseDAO.Instance.UpdateYellowWH(idWh, "NO");
                }
                LoadControl();
            }
        }

        private void btnDeleteYellow_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(4, Kun_Static.accountDTO.Type, user);
            if (check < 2)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("bạn muốn hủy yêu cầu thẻ vàng linh kiện này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    int idWh = int.Parse(gridView1.GetRowCellValue(item, "IdWareHouse").ToString());
                    WareHouseDAO.Instance.UpdateYellowWH(idWh, "");
                }
                LoadControl();
            }
        }

        private void btnSaveStatus_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(4, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (check == 1)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    string befor = gridView1.GetRowCellValue(item, "NameStatus").ToString();
                    if (befor == "NG")
                    {
                        MessageBox.Show("bạn không có quyền chuyển trạng thái Pallet này!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cbStatus.Text = String.Empty;
                        btnSaveStatus.Enabled = false;
                        return;
                    }

                }
            }
            int status = (cbStatus.SelectedItem as StatusWarehouseDTO).Id;
            string after = cbStatus.Text;
            DateTime dateChange = DateTime.Now;
            string Note = txtNote.Text;
            if (MessageBox.Show("Xác nhận linh kiện đã kiểm tra OK trước khi chuyển trạng thái!".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Kun_Static.Style = 0;
                frmEmployessCode f = new frmEmployessCode();
                f.ShowDialog();
                string employess = Kun_Static.EmployessCode;
                int test = EmployessDAO.Instance.TestEmployessByCode(employess);
                if (test == 1)
                {
                    foreach (var item in gridView1.GetSelectedRows())
                    {
                        int idWh = int.Parse(gridView1.GetRowCellValue(item, "IdWareHouse").ToString());
                        int id = int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                        string befor = gridView1.GetRowCellValue(item, "NameStatus").ToString();
                        WareHouseDAO.Instance.UpdateStatusWH(idWh, status);
                        IventoryPartDAO.Instance.UpdateNoteInputPart(id, Note);
                        IventoryPartDAO.Instance.InputHistoryQC(id, dateChange, befor, after, employess);
                    }
                    LoadControl();
                }
                else
                {
                    MessageBox.Show("mã nhân viên không đúng !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnHU_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(4, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string Note = "";
            if (MessageBox.Show("mã linh kiện này đã thực sự hết Ùn ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                            int id = int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                            IventoryPartDAO.Instance.UpdateNoteInputPart(id, Note);
                            IventoryPartDAO.Instance.UpdateNote2InputPart(id, Note);
                }
                LoadControl();
            }
        }
    }
}
