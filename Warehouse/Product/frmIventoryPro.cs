using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DAO;
using System.Diagnostics;
using DTO;
using DevExpress.XtraGrid.Views.Grid;
using System.Linq;
using DevExpress.XtraSplashScreen;
using WareHouse.Employess;
using WareHouse.Common;

namespace WareHouse.Product
{
    public partial class frmIventoryPro : DevExpress.XtraEditors.XtraForm
    {
        public frmIventoryPro()
        {
            InitializeComponent();
            LoadData();
        }
        void LoadIventory()
        {
            List<ProductIventoryDTO> listPr = ProductDAO.Instance.ListIventoryProduct();
            foreach (ProductIventoryDTO item in listPr)
            {
                if(item.Iventory == 0)
                {
                    ProductDAO.Instance.UpdateStatusInput(item.Id, 1);
                }
            }
        }
        void LoadData()
        {
            LoadIventory();
            List<ProductIventoryDTO> listPr = new List<ProductIventoryDTO>();
            List<ProductCodeDTO> listCode = ProductDAO.Instance.GetListCodeProduct();
            foreach (ProductCodeDTO item in listCode)
            {
                float sum = 0;
                string Rohs = "";
                List<ProductIventoryDTO> listPr1 = ProductDAO.Instance.ListIventoryProduct(item.ProductCode);
                foreach (ProductIventoryDTO item1 in listPr1)
                {
                    sum += item1.Iventory;
                    Rohs = item1.Rohs;
                }
                listPr.Add(new ProductIventoryDTO(1, item.ProductCode.ToUpper(), item.Name, DateTime.Now, 1, sum, Rohs));
            }
            GCData.DataSource = listPr.OrderBy(x => x.Iventory);
        }

        private void btnInput_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmStatisticInputPro f = new frmStatisticInputPro();
            f.ShowDialog();
        }

        private void btnOutput_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmStatisticOutputProduct f = new frmStatisticOutputProduct();
            f.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.FieldName == "ProductCode")
            {
                string code = e.CellValue.ToString();
                string a = ProductDAO.Instance.NoteProduct(code);
                try
                {
                    Process.Start(a);
                }
                catch
                {
                    MessageBox.Show("đường link không đúng".ToUpper());
                }
            }
        }
        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0) // chỉ xử lý trong cột họ tên thôi 
            {
                string code = view.GetRowCellValue(e.RowHandle, view.Columns["ProductCode"]).ToString();
                float constan = ProductDAO.Instance.CountConstan(code);
                float sum = ProductDAO.Instance.TotalIventory(code);
                if (sum < constan)
                {
                    e.Appearance.BackColor = Color.Red;
                    e.Appearance.ForeColor = Color.White;
                    
                }
                
            }
        }

        private void btnExPort_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExportExcel.Export(GCData);
        }
    }
}