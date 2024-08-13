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

namespace WareHouse.WareHouseMaterial
{
    public partial class frmSetupWH : Form
    {
        public frmSetupWH()
        {
            InitializeComponent();
           
        }
        public EventHandler LamMoi;


        private void btnSetUp_Click(object sender, EventArgs e)
        {
           
            string []array = txtY.Text.Split(',');
            int x = int.Parse(txtX.Text);
            string name = "";
            int status = 1;
            string k = "";
            List<WarehouseMaterial> listW = WarehouseMaterialDAO.Instance.GetListAllWareHouse();
            if(listW.Count == 0)
            {
                for (int i = 0; i <= x; i++)
                {
                    name = i.ToString();
                    WarehouseMaterialDAO.Instance.InsertWareHouse(name, status, "x",1000);
                }
            }
            foreach (var item in array)
            {
                for (int i = 0; i <= x; i++)
                {
                    if(i == 0)
                    {
                        name = item.ToUpper();
                        k = "y";
                        status = 1;
                    }
                    else
                    {
                        name = item.ToUpper() + "-"+ i.ToString();
                        k = "A";
                        status = 1;
                    }
                    WarehouseMaterialDAO.Instance.InsertWareHouse(name, status, k,1000);
                }
            }
            MessageBox.Show("thêm thông tin thành công !".ToUpper());
        }

        private void frmSetupWH_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }
    }
}
