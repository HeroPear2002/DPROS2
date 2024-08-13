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
using DevExpress.XtraGrid.Views.Grid;
using DTO;
using DevExpress.XtraSplashScreen;
using WareHouse.Employess;
using System.Threading;

namespace WareHouse
{
    public partial class frmIventoryByDate : DevExpress.XtraEditors.XtraForm
    {
        public frmIventoryByDate()
        {
            InitializeComponent();
            LoadDate();
            LoadPartCode();
            LoadColum();
            gridView1.CustomDrawRowIndicator += gridView1_CustomDrawRowIndicator;
        }
        void LoadColum()
        {
            gridView1.Columns["Iventory"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Iventory", "Tổng = {0}");
        }
        void LoadPartCode()
        {
            cbPartCode.DataSource = PartDAO.Instance.GetListPart();
            cbPartCode.ValueMember = "PartCode";
            cbPartCode.DisplayMember = " PartCode";
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
        private void btnView_Click(object sender, EventArgs e)
        {
            DateTime date1 = dtpkDate1.Value;
            DateTime date2 = dtpkDate2.Value;
            string PartCode = cbPartCode.Text;
            List<IvenstoryDTO> listInew = IventoryPartDAO.Instance.GetListIventoryPartByDateOUT(date1, date2,PartCode);
            GCData.DataSource = listInew;
        }
        void LoadDate()
        {
            DateTime today = DateTime.Now.Date;
            dtpkDate1.Value = today.AddDays(-today.Day).AddDays(1);
            dtpkDate2.Value = dtpkDate1.Value.AddMonths(1).AddDays(-1).AddMilliseconds(10);
        }
    }
}