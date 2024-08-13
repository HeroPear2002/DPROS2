using System.Windows.Forms;
using DevExpress.XtraBars;
using DTO;
using WareHouse.FMaterial;
using WareHouse.EBox;
using WareHouse.FParts;
using WareHouse.Account;
using WareHouse.PC;
using WareHouse.WareHouseMaterial;
using WareHouse.Mac;
using WareHouse.Factory;
using DAO;

namespace WareHouse
{
    public partial class frmMainDataSoure : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private static frmMainDataSoure instance;

        public static frmMainDataSoure Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new frmMainDataSoure();
                }
                else
                { instance.Activate(); }
                return instance;
            }
            set => instance = value;
        }

        public frmMainDataSoure()
        {
            InitializeComponent();
            ChangeAccount();
        }
        void ChangeAccount()
        {
            int type = Kun_Static.accountDTO.Type;
            if (type == 6)
            {
                btnAdmin.Enabled = false;
                btnPermission.Enabled = false;
            }
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
        #region DỮ LIỆU NGUỒN

        private void btnVendor_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("fSupplier"))
            {
                fSupplier f = new fSupplier();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("fSupplier");
                fSupplier f = new fSupplier();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnCustomer_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("fCustomer"))
            {
                fCustomer f = new fCustomer();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("fCustomer");
                fCustomer f = new fCustomer();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnMaterial_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("fMaterial"))
            {
                fMaterial f = new fMaterial();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("fMaterial");
                fMaterial f = new fMaterial();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnMaterialHH_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmMaterialInfor"))
            {
                frmMaterialInfor f = new frmMaterialInfor();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmMaterialInfor");
                frmMaterialInfor f = new frmMaterialInfor();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnPart_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("fPart"))
            {
                fPart f = new fPart();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("fPart");
                fPart f = new fPart();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnPartInfor_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmPartInfor"))
            {
                frmPartInfor f = new frmPartInfor();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmPartInfor");
                frmPartInfor f = new frmPartInfor();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnMac_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("fMacInformation"))
            {
                fMacInformation f = new fMacInformation();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("fMacInformation");
                fMacInformation f = new fMacInformation();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnBoxNature_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmBoxNature"))
            {
                frmBoxNature f = new frmBoxNature();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmBoxNature");
                frmBoxNature f = new frmBoxNature();
                f.MdiParent = this;
                f.Show();
            }
        }
        private void btnRatio_ItemClick(object sender, ItemClickEventArgs e)
        {

            if (!CheckExistForm("frmRatioMaterial"))
            {
                frmRatioMaterial f = new frmRatioMaterial();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmRatioMaterial");
                frmRatioMaterial f = new frmRatioMaterial();
                f.MdiParent = this;
                f.Show();
            }
        }
        #endregion

        #region Account 
        private void btnAccount_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmAccountInfor"))
            {
                frmAccountInfor f = new frmAccountInfor();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmAccountInfor");
                frmAccountInfor f = new frmAccountInfor();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnAdmin_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmAccount"))
            {
                frmAccount f = new frmAccount();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmAccount");
                frmAccount f = new frmAccount();
                f.MdiParent = this;
                f.Show();
            }
        }
        #endregion

        private void btnLockPart_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmLockPart"))
            {
                frmLockPart f = new frmLockPart();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmLockPart");
                frmLockPart f = new frmLockPart();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnFormPart_ItemClick(object sender, ItemClickEventArgs e)
        {

            if (!CheckExistForm("frmFormPartCode"))
            {
                frmFormPartCode f = new frmFormPartCode();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmFormPartCode");
                frmFormPartCode f = new frmFormPartCode();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnHistoryMac_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmHistoryMac"))
            {
                frmHistoryMac f = new frmHistoryMac();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmHistoryMac");
                frmHistoryMac f = new frmHistoryMac();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnFactory_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmFactory"))
            {
                frmFactory f = new frmFactory();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmFactory");
                frmFactory f = new frmFactory();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnMac4M_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmMac4M"))
            {
                frmMac4M f = new frmMac4M();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmMac4M");
                frmMac4M f = new frmMac4M();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnMaterialBegin_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmMaterialBegin"))
            {
                frmMaterialBegin f = new frmMaterialBegin();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmMaterialBegin");
                frmMaterialBegin f = new frmMaterialBegin();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnPermission_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmAccountsInfor"))
            {
                frmAccountsInfor f = new frmAccountsInfor();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmAccountsInfor");
                frmAccountsInfor f = new frmAccountsInfor();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnMachineDry_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmMachineDry"))
            {
                frmMachineDry f = new frmMachineDry();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmMachineDry");
                frmMachineDry f = new frmMachineDry();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnReason_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmReason"))
            {
                frmReason f = new frmReason();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmReason");
                frmReason f = new frmReason();
                f.MdiParent = this;
                f.Show();
            }
        }
    }
}