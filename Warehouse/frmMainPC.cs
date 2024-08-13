using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DTO;
using WareHouse.PO_and_Order;
using WareHouse.EBox;
using WareHouse.PC;
using DAO;
using System.Net.Mail;
using System.Net;
using System.Threading;
using WareHouse.PCGridControl;
using WareHouse.Order;
using WareHouse.FMaterial;
using WareHouse.QRCodeMaterial;

namespace WareHouse
{
    public partial class frmMainPC : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private static frmMainPC instance;

        public static frmMainPC Instance { get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new frmMainPC();
                }
                else
                {
                    instance.Activate();
                }
                return instance;
            } set => instance = value; }

        public frmMainPC()
        {
            InitializeComponent();
        }

 
        #region CheckForm

        private bool CheckExistForm(string name)
        {
            bool check = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    check = true;
                    break;
                }

            }
            return check;
        }
        private void ActivateChildForm(string name)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    frm.Close();

                    break;
                }
            }
        }

        #endregion
        #region QL Sản Xuất
        private void btnPOInput_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmPOInput"))
            {
                frmPOInput f = new frmPOInput();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmPOInput");
                frmPOInput f = new frmPOInput();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnPOOutput_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmPOOutput"))
            {
                frmPOOutput f = new frmPOOutput();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmPOOutput");
                frmPOOutput f = new frmPOOutput();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnPOFix_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmPOFix"))
            {
                frmPOFix f = new frmPOFix();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmPOFix");
                frmPOFix f = new frmPOFix();
                f.MdiParent = this;
                f.Show();
            }
        }
        private void btnDeliveryNote_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmDeliveryNotes"))
            {
                frmDeliveryNotes f = new frmDeliveryNotes();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmDeliveryNotes");
                frmDeliveryNotes f = new frmDeliveryNotes();
                f.MdiParent = this;
                f.Show();
            }
        }
        private void btnBox_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmBoxList"))
            {
                frmBoxList f = new frmBoxList();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmBoxList");
                frmBoxList f = new frmBoxList();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnBoxInfor_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmBoxInfor"))
            {
                frmBoxInfor f = new frmBoxInfor();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmBoxInfor");
                frmBoxInfor f = new frmBoxInfor();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnEfficBox_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmBoxEffic"))
            {
                frmBoxEffic f = new frmBoxEffic();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmBoxEffic");
                frmBoxEffic f = new frmBoxEffic();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnCTSX_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmCTSX"))
            {
                frmCTSX f = new frmCTSX();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmCTSX");
                frmCTSX f = new frmCTSX();
                f.MdiParent = this;
                f.Show();
            }
        }
        #endregion
        #region QUẢN LÝ ĐƠN HÀNG
        private void btnOrderList_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmPOMaterial"))
            {
                frmPOMaterial f = new frmPOMaterial();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmPOMaterial");
                frmPOMaterial f = new frmPOMaterial();
                f.MdiParent = this;
                f.Show();
            }
        }

      
     
        #endregion
        #region TIẾN ĐỘ SẢN XUẤT

        private void btnTDSX_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmKHNL"))
            {
                frmKHNL f = new frmKHNL();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmTDSX");
                frmKHNL f = new frmKHNL();
                f.MdiParent = this;
                f.Show();
            }
        }


        private void btnOEE_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmMachineEfficiency"))
            {
                frmMachineEfficiency f = new frmMachineEfficiency();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmWeatherChart");
                frmMachineEfficiency f = new frmMachineEfficiency();
                f.MdiParent = this;
                f.Show();
            }
        }
        #endregion

        private void ribbon_SelectedPageChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (Ribbon.SelectedPage == rbfOrder)
            //    {

            //        if (!CheckExistForm("frmOrderEverybody"))
            //        {
            //            frmOrderEverybody f = new frmOrderEverybody();
            //            f.MdiParent = this;
            //            f.Show();
            //        }
            //        else
            //        {
            //            ActivateChildForm("frmOrderEverybody");
            //            frmOrderEverybody f = new frmOrderEverybody();
            //            f.MdiParent = this;
            //            f.Show();
            //        }

            //    }
            //}
            //catch (Exception ae)
            //{
            //    MessageBox.Show(ae.Message);
            //}
        }

        private void btnListTableSX_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmListTableSX"))
            {
                frmListTableSX f = new frmListTableSX();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmListTableSX");
                frmListTableSX f = new frmListTableSX();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnListTableTT_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmListTableTT"))
            {
                frmListTableTT f = new frmListTableTT();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmListTableTT");
                frmListTableTT f = new frmListTableTT();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnListTableDK_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmListTableDK"))
            {
                frmListTableDK f = new frmListTableDK();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmListTableDK");
                frmListTableDK f = new frmListTableDK();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnListTableXH_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmListTableXH"))
            {
                frmListTableXH f = new frmListTableXH();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmListTableXH");
                frmListTableXH f = new frmListTableXH();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnFCMaterial_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmFCMaterial"))
            {
                frmFCMaterial f = new frmFCMaterial();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmFCMaterial");
                frmFCMaterial f = new frmFCMaterial();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnFCPart_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmFCPart"))
            {
                frmFCPart f = new frmFCPart();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmFCPart");
                frmFCPart f = new frmFCPart();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnFormMaterial_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmMaterialTotal"))
            {
                frmMaterialTotal f = new frmMaterialTotal();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmMaterialTotal");
                frmMaterialTotal f = new frmMaterialTotal();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnChartPrice_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmMaterialChart"))
            {
                frmMaterialChart f = new frmMaterialChart();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmMaterialChart");
                frmMaterialChart f = new frmMaterialChart();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnMaterialPrice_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmPriceMaterial"))
            {
                frmPriceMaterial f = new frmPriceMaterial();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmPriceMaterial");
                frmPriceMaterial f = new frmPriceMaterial();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnTableMaterial_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmMaterialIventory"))
            {
                frmMaterialIventory f = new frmMaterialIventory();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmMaterialIventory");
                frmMaterialIventory f = new frmMaterialIventory();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnMaterialBy_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmMaterialBy"))
            {
                frmMaterialBy f = new frmMaterialBy();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmMaterialBy");
                frmMaterialBy f = new frmMaterialBy();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnTableExport_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmExportTable"))
            {
                frmExportTable f = new frmExportTable();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmExportTable");
                frmExportTable f = new frmExportTable();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnReceiptSlip_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmReceiptSlip"))
            {
                frmReceiptSlip f = new frmReceiptSlip();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmReceiptSlip");
                frmReceiptSlip f = new frmReceiptSlip();
                f.MdiParent = this;
                f.Show();
            }
        }
    }
}