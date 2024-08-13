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

namespace WareHouse.WareHouseMaterial
{
    public partial class frmHistoryDryingMaterial : DevExpress.XtraEditors.XtraForm
    {
        public frmHistoryDryingMaterial()
        {
            InitializeComponent();
            LoadControl();
            
        }
        #region Control
        void LoadControl()
        {
            LoadData();
            bandedGridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
        }
        void LoadData()
        {
            GCData.DataSource = WarehouseMaterialDAO.Instance.GetlistDrying(); ;
        }
        #endregion
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (var item in bandedGridView1.GetSelectedRows())
            {
                long Id = long.Parse(bandedGridView1.GetRowCellValue(item, "Id").ToString());
                string partCode = bandedGridView1.GetRowCellValue(item, "PartCode").ToString();
                string machineCode = bandedGridView1.GetRowCellValue(item, "MachineCode").ToString();
                string materialCode = bandedGridView1.GetRowCellValue(item, "MaterialCode").ToString();
                DateTime dateDrying = DateTime.Parse(bandedGridView1.GetRowCellValue(item, "DateDrying").ToString());
                string statusMachine = bandedGridView1.GetRowCellValue(item, "StatusMachine").ToString();
                float temperature = (float)Convert.ToDouble(bandedGridView1.GetRowCellValue(item, "Temperature").ToString());
                int countT = int.Parse(bandedGridView1.GetRowCellValue(item, "CountT").ToString());
                int countC = int.Parse(bandedGridView1.GetRowCellValue(item, "CountC").ToString());
                int countH = int.Parse(bandedGridView1.GetRowCellValue(item, "CountH").ToString());
                string lotT = bandedGridView1.GetRowCellValue(item, "LotT").ToString();
                string lotC = bandedGridView1.GetRowCellValue(item, "LotC").ToString();
                string lotH = bandedGridView1.GetRowCellValue(item, "LotH").ToString();
                string employess = bandedGridView1.GetRowCellValue(item, "Employess").ToString();
                string note = bandedGridView1.GetRowCellValue(item, "Note").ToString();
            
                WarehouseMaterialDAO.Instance.UpdateDryingMaterial(Id,partCode,machineCode,materialCode,dateDrying,statusMachine,temperature,countT,lotT,countC,lotC,countH,lotH,employess,note);
            }
            MessageBox.Show("sửa thông tin thành công !".ToUpper());
            LoadControl();
        }
    }
}