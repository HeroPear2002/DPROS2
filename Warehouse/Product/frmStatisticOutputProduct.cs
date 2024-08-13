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
using System.Globalization;

namespace WareHouse.Product
{
    public partial class frmStatisticOutputProduct : DevExpress.XtraEditors.XtraForm
    {

        public frmStatisticOutputProduct()
        {
            InitializeComponent();
            LoadControl();
        }
        #region Control
        void LoadControl()
        {
            LoadDate();
            LoadCode();
            LoadData();
        }
        void CleanText()
        {
            cbCode.Text = String.Empty;
            txtCount.Text = String.Empty;
        }
        void LoadCode()
        {
            cbCode.DataSource = ProductDAO.Instance.DistinctProduct();
            cbCode.DisplayMember = "ProductCode";
            cbCode.ValueMember = "ProductCode";
        }
        void LoadDate()
        {
            DateTime today = DateTime.Now.Date;
            dtpkDate1.Value = today.AddDays(-today.Day + 1);
            dtpkDate2.Value = dtpkDate1.Value.AddMonths(1).AddSeconds(-5);
        }
        void LoadData()
        {
            GCData.DataSource = ProductDAO.Instance.ListOutputProduct();
        }
        #endregion
        private void btnOutput_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string code = cbCode.Text;
            float countOut = (float)Math.Round(Convert.ToDouble(txtCount.Text), 2);
            float totalIventory = ProductDAO.Instance.TotalIventory(code);
            if (countOut > 0)
            {
                if (countOut <= totalIventory)
                {
                    List<ProductIventoryDTO> listP = ProductDAO.Instance.ListIventoryProduct(code);
                    foreach (ProductIventoryDTO item in listP.OrderBy(y => y.DateInput))
                    {
                        float iventory = item.Iventory;
                        float b = countOut - iventory;
                        if (b <= 0)
                        {
                            ProductDAO.Instance.InsertOutputPro(item.Id, today, Kun_Static.accountDTO.UserName, countOut, "", "");
                            MessageBox.Show("Xuất kho thành công !".ToUpper());
                            countOut = 0;
                            CleanText();
                            LoadControl();
                            return;
                        }
                        else
                        {
                            ProductDAO.Instance.InsertOutputPro(item.Id, today, Kun_Static.accountDTO.UserName, iventory, "", "");
                            ProductDAO.Instance.UpdateStatusInput(item.Id, 1);
                            countOut = b;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("hàng trong kho không đủ !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("bạn chưa điền số lượng xuất !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now.Date;
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            GCData.DataSource = ProductDAO.Instance.ListOutputProduct(dtpkDate1.Value, dtpkDate2.Value);
        }
    }
}