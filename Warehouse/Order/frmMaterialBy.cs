using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DAO;
using DTO;
using DevExpress.XtraGrid.Views.Grid;

namespace WareHouse.Order
{
    public partial class frmMaterialBy : DevExpress.XtraEditors.XtraForm
    {
        public frmMaterialBy()
        {
            InitializeComponent();
            LoadControl();
        }
        void LoadControl()
        {
            LoadData();
        }
        void LoadData()
        {
            DateTime today = dtpkDate.Value.Date;
            today = today.AddDays(1 - today.Day);
            List<MaterialByDTO> listM = MaterialDAO.Instance.GetMaterialBy().Where(x => x.DateBy >= today && x.DateBy <= today.AddMonths(6)).ToList();
            GCData.DataSource = listM;
        }
        string LoadCheck()
        {
            string sup = "";
            string supplierCode = "";
            string dateTime = "";
            int check = 0;
            foreach (var item in gridView1.GetSelectedRows())
            {
                int quantityBy = int.Parse(gridView1.GetRowCellValue(item, "QuantityBy").ToString());
                int quantityOrder = int.Parse(gridView1.GetRowCellValue(item, "QuantityOrder").ToString());
                if (quantityOrder >= quantityBy)
                {
                    return "a";
                }
                if (check == 0)
                {
                    supplierCode = gridView1.GetRowCellValue(item, "VenderCode").ToString();
                    dateTime = gridView1.GetRowCellValue(item, "DateBy").ToString();
                }
                else
                {
                    string supplier = gridView1.GetRowCellValue(item, "VenderCode").ToString();
                    string date = gridView1.GetRowCellValue(item, "DateBy").ToString();
                    if (supplier == supplierCode)
                    {
                        if (date == dateTime)
                        {
                            sup = gridView1.GetRowCellValue(item, "VenderCode").ToString();
                        }
                        else
                        {
                            return "c";
                        }
                    }
                    else
                    {
                        return "b";
                    }
                }
                check++;
            }
            return sup;
        }
        private void btnExportTable_Click(object sender, EventArgs e)
        {
            frmExportTable f = new frmExportTable();
            f.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("bạn muốn sửa thông tin này?".ToUpper(),"Thông báo",MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    long Id = long.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Id"]).ToString());
                    int quantityIn = int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["QuantityBy"]).ToString());
                    MaterialDAO.Instance.UpdateMaterialBy(Id, quantityIn, "");
                    LoadControl();
                }
            }
            catch 
            {
            }
            
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void btnAddPO_Click(object sender, EventArgs e)
        {
            List<MaterialByDTO> listReturn = new List<MaterialByDTO>();
            string kun = LoadCheck();
            if (kun == "b")
            {
                MessageBox.Show("nhà cung cấp không trùng nhau!".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (kun == "c")
            {
                MessageBox.Show("ngày tháng năm không chùng nhau!".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (kun == "a")
            {
                MessageBox.Show("Nguyên liệu đã đặt hết số lượng\n\nbạn hãy kiểm tra lại hoặc chỉnh sửa cố lượng mua!".ToUpper(), "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            var listMSelected = gridView1.GetSelectedRows();
            if (listMSelected.Length == 0)
            {
                MessageBox.Show("bạn chưa chọn nguyên liệu để thêm vào PO!".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (var item in listMSelected)
            {
                var materialByDTO = gridView1.GetRow(item) as MaterialByDTO;
                materialByDTO.QuantityBy = materialByDTO.QuantityBy - materialByDTO.QuantityOrder;
                materialByDTO.QuantityOrder = 0;
                listReturn.Add(materialByDTO);
            }
            Kun_Static.listMReturn = listReturn;
            frmPOMaterialInput frm = new frmPOMaterialInput();
            frm.LamMoi += new EventHandler(btnUpdate_Click);
            frm.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0)
            {
                int quantityBy = int.Parse(view.GetRowCellValue(e.RowHandle, view.Columns["QuantityBy"]).ToString());
                int quantityOrder = int.Parse(view.GetRowCellValue(e.RowHandle, view.Columns["QuantityOrder"]).ToString());
                if (quantityOrder >= quantityBy)
                {
                    e.Appearance.BackColor = Color.Yellow;
                }
            }
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
            if (MessageBox.Show("bạn muốn xóa thông tin này?".ToUpper(), "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    long id = long.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    MaterialDAO.Instance.DeleteMaterialBy(id);
                }
                LoadControl();
            }
        }
    }
}