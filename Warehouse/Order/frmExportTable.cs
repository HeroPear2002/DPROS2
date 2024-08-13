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

namespace WareHouse.Order
{
    public partial class frmExportTable : DevExpress.XtraEditors.XtraForm
    {
        public frmExportTable()
        {
            InitializeComponent();
            LoadControl();
        }
        void LoadControl()
        {
            LoadSupplier();
        }
        void LoadSupplier()
        {
            glSupplier.Properties.DataSource = VendorDAO.Instance.GetListVender();
            glSupplier.Properties.DisplayMember = "VenderCode";
            glSupplier.Properties.ValueMember = "VenderCode";
        }
        void LoadData()
        {
            DateTime today = dtpkDate.Value.Date;
            today = today.AddDays(1 - today.Day);
            string supplier = glSupplier.Text;
            List<MaterialByDTO> listM = MaterialDAO.Instance.GetMaterialBy().Where(x => x.DateBy >= today && x.DateBy <= today.AddMonths(6) && x.VenderCode == supplier).ToList();
            DateTime date = today.AddDays(1 - today.Day);
            List<FormMaterial> listFM = new List<FormMaterial>();
            Col1.Caption = "T" + today.Month.ToString() + "." + today.Year.ToString();
            Col2.Caption = "T" + (today.AddMonths(1).Month).ToString() + "." + today.AddMonths(1).Year.ToString();
            Col3.Caption = "T" + (today.AddMonths(2).Month.ToString()) + "." + today.AddMonths(2).Year.ToString();
            Col4.Caption = "T" + (today.AddMonths(3).Month.ToString()) + "." + today.AddMonths(3).Year.ToString();
            Col5.Caption = "T" + (today.AddMonths(4).Month.ToString()) + "." + today.AddMonths(4).Year.ToString();
            Col6.Caption = "T" + (today.AddMonths(5).Month.ToString()) + "." + today.AddMonths(5).Year.ToString();
            List<MaterialByDTO> listFC = listM.Where(x => x.DateBy == date).ToList();
            int Month1 = 0;
            int Month2 = 0;
            int Month3 = 0;
            int Month4 = 0;
            int Month5 = 0;
            int Month6 = 0;
            int i = 0;
            foreach (MaterialByDTO item in listFC)
            {
                i++;
                Month1 = QuantityBy(item.MaterialCode, date);
                Month2 = QuantityBy(item.MaterialCode, date.AddMonths(1));
                Month3 = QuantityBy(item.MaterialCode, date.AddMonths(2));
                Month4 = QuantityBy(item.MaterialCode, date.AddMonths(3));
                Month5 = QuantityBy(item.MaterialCode, date.AddMonths(4));
                Month6 = QuantityBy(item.MaterialCode, date.AddMonths(5));
                listFM.Add(new FormMaterial(item.MaterialCode, item.MaterialName, item.ColorCode, i, Month1, Month2, Month3, Month4, Month5, Month6));
            }
            GCData.DataSource = listFM;
        }
        int QuantityBy(string materialCode, DateTime date)
        {
            MaterialByDTO materialByDTO = MaterialDAO.Instance.GetItemMaterialBy(materialCode, date);
            if(materialByDTO == null)
            {
                return 0;
            }
            return materialByDTO.QuantityBy;
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            Common.ExportExcel.Export(GCData);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}