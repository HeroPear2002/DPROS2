using DevExpress.XtraReports.UI;
using System;
using System.Collections;
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
using WareHouse.Report;

namespace WareHouse.FMaterial
{
    public partial class frmBatrcodeMaterial : Form
    {
        public frmBatrcodeMaterial()
        {
            InitializeComponent();
            LoadControl();
        }
        void LoadControl()
        {
            LoadMaterialCode();
        }
        void LoadMaterialCode()
        {
            List<MaterialDTO> listP = MaterialDAO.Instance.GetListMaterial();
            cbMaterialCode.Properties.DataSource = listP;
            cbMaterialCode.Properties.DisplayMember = "MaterialCode";
            cbMaterialCode.Properties.ValueMember = "MaterialName";
        }
        private void btnBarCode_Click(object sender, EventArgs e)
        {
            ArrayList listMaterial = new ArrayList();
            string MateriCode = cbMaterialCode.Text;
            string name = MaterialDAO.Instance.GetNameMaterialByCode(MateriCode);
            int Count = (int)nudCount.Value;
            string BarCodeMaterial = "";
            int n = Count / 1000;
            if(Count <= 1000)
            {
                BarCodeMaterial = MateriCode + "&" + Count.ToString();
                listMaterial.Add(new BarcodeMaterial(MateriCode, name, Count, BarCodeMaterial, "", "", ""));
            }
            else if (n*1000 == Count)
            {
                for (int i = 1; i <= n; i++)
                {
                    
                    BarCodeMaterial = MateriCode + "&" + "1000";
                    listMaterial.Add(new BarcodeMaterial(MateriCode, name, 1000, BarCodeMaterial, "", "", ""));
                }
            }
            else
            {
                for (int i = 1; i <= n; i++)
                {

                    BarCodeMaterial = MateriCode + "&" + "1000";
                    listMaterial.Add(new BarcodeMaterial(MateriCode, name, 1000, BarCodeMaterial, "", "", ""));
                }
                BarCodeMaterial = MateriCode + "&" + (Count - (n*1000)).ToString();
                listMaterial.Add(new BarcodeMaterial(MateriCode, name, (Count - (n * 1000)), BarCodeMaterial, "", "", ""));
            }
            rpBarCodeMaterial report = new rpBarCodeMaterial();
            report.DataSource = listMaterial;
            report.LoadData();
            report.PrintDialog();
        }
    }
}
