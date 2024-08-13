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

namespace WareHouse
{
    public partial class frmPainWarehouse : DevExpress.XtraEditors.XtraForm
    {
        public frmPainWarehouse()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int vtx = int.Parse(txtX.Text);
            string[] vty = txtY.Text.Split(',');
            int vtTy = int.Parse(txtTY.Text);
            //Vẽ X
            for (int i = 0; i <= vtx; i++)
            {
                WareHouseDAO.Instance.InsertWareHouse(i.ToString().ToUpper(), 1, 1, "x");
            }
            //Vẽ Layout
            string name = "";
            string style = "";
            int height = 1;

            foreach (var item in vty)
            {
                for (int i = 1; i <= vtTy; i++)
                {
                    for (int j = 0; j <= vtx; j++)
                    {
                        if (j == 0)
                        {
                            name = item.ToUpper() + i.ToString().ToUpper();
                            style = "y";
                            height = 1;

                        }
                        else
                        {
                            name = item.ToUpper() + i.ToString().ToUpper() + "-" + j.ToString().ToUpper();
                            style = "a";
                            height = 1800;
                        }
                        WareHouseDAO.Instance.InsertWareHouse(name, 1, height, style);
                    }
                }
            }
            MessageBox.Show("Nhập OK");
        }
    }
}