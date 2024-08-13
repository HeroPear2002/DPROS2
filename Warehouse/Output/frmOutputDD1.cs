using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DAO;

namespace WareHouse.Output
{
    public partial class frmOutputDD1 : DevExpress.XtraEditors.XtraForm
    {
        public frmOutputDD1()
        {
            InitializeComponent();
            LoadControl();
            LoadColum();
            gridView1.CustomDrawRowIndicator += gridView1_CustomDrawRowIndicator;
        }
        public EventHandler LamMoi;
        void LoadColum()
        {
            gridView1.Columns["Iventory"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Iventory", "Tổng = {0}");
        }

        bool cal(Int32 _Width, GridView _View)
        {
            _View.IndicatorWidth = _View.IndicatorWidth < _Width ? _Width : _View.IndicatorWidth;
            return true;
        }
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (!gridView1.IsGroupRow(e.RowHandle)) //Nếu không phải là Group
            {
                if (e.Info.IsRowIndicator) //Nếu là dòng Indicator
                {
                    if (e.RowHandle < 0)
                    {
                        e.Info.ImageIndex = 0;
                        e.Info.DisplayText = string.Empty;
                    }
                    else
                    {
                        e.Info.ImageIndex = -1; //Không hiển thị hình
                        e.Info.DisplayText = (e.RowHandle + 1).ToString(); //Số thứ tự tăng dần
                    }
                    SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font); //Lấy kích thước của vùng hiển thị Text
                    Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                    BeginInvoke(new MethodInvoker(delegate { cal(_Width, gridView1); })); //Tăng kích thước nếu Text vượt quá
                }
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", (e.RowHandle * -1)); //Nhân -1 để đánh lại số thứ tự tăng dần
                SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                BeginInvoke(new MethodInvoker(delegate { cal(_Width, gridView1); }));
            }
        }
        void LoadControl()
        {
            LoadData();
            btnSave.Enabled = false;
        }
        void LoadData()
        {
            GCDATA.DataSource = IventoryPartDAO.Instance.GetListIvenstoryPart();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string Employess = Kun_Static.EmployessCode;
            if (MessageBox.Show("bạn muốn xuất linh kiện sang kho Đông Dương 2".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    long id = long.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    int idWH = int.Parse(gridView1.GetRowCellValue(item, "IdWareHouse").ToString());
                    int quantity = int.Parse(gridView1.GetRowCellValue(item, "Iventory").ToString());
                    DateTime today = DateTime.Now;
                    IventoryPartDAO.Instance.OutputPart(id, today, quantity, Employess, "Xuất chuyển kho");
                }
                LoadControl();
                MessageBox.Show("Xuất thành công chuyển kho ".ToUpper());
            }
        }

        private void GCDATA_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void frmOutputDD2_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }
    }
}
