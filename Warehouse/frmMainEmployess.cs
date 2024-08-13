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
using WareHouse.Employess;

namespace WareHouse
{
    public partial class frmMainEmployess : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private static frmMainEmployess instance;

        public static frmMainEmployess Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new frmMainEmployess();
                }
                else
                {
                    instance.Activate();
                }
                return instance;
            }
            set => instance = value;
        }

        public frmMainEmployess()
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
        #region Employess

        private void btnEmployessInfor_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmListEmployess"))
            {
                frmListEmployess f = new frmListEmployess();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmListEmployess");
                frmListEmployess f = new frmListEmployess();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnEmployess_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmEmployess"))
            {
                frmEmployess f = new frmEmployess();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmEmployess");
                frmEmployess f = new frmEmployess();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnRoom_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmRoom"))
            {
                frmRoom f = new frmRoom();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmRoom");
                frmRoom f = new frmRoom();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnCategory_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmPlusAndError"))
            {
                frmPlusAndError f = new frmPlusAndError();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmPlusAndError");
                frmPlusAndError f = new frmPlusAndError();
                f.MdiParent = this;
                f.Show();
            }
        }
        private void btnInfor_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmInforEmployess"))
            {
                frmInforEmployess f = new frmInforEmployess();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmInforEmployess");
                frmInforEmployess f = new frmInforEmployess();
                f.MdiParent = this;
                f.Show();
            }
        }

        #endregion

        private void btnPosition_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmPosition"))
            {
                frmPosition f = new frmPosition();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmPosition");
                frmPosition f = new frmPosition();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnEmployessCard_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmEmployessCard"))
            {
                frmEmployessCard f = new frmEmployessCard();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmEmployessCard");
                frmEmployessCard f = new frmEmployessCard();
                f.MdiParent = this;
                f.Show();
            }
        }
    }
}