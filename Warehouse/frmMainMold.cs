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
using WareHouse.Mold;
using DTO;
using DAO;
using System.Threading;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace WareHouse
{
    public partial class frmMainMold : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private static frmMainMold instance;

        public static frmMainMold Instance { get {if(instance == null || instance.IsDisposed)
                {
                    instance = new frmMainMold();
                }
                else
                {
                    instance.Activate();
                }
                return instance;
            } set => instance = value; }

        public frmMainMold()
        {
            InitializeComponent();
            LoadControl();
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
        public class MainId
        {
            public static int MoldErrorId;
        }
        void LoadControl()
        {
            LoadToolAsync();
        }
        async void LoadToolAsync()
        {
            await LoadMoldInfor();
        }
        public static async Task LoadMoldInfor()
        {
            await Task.Run(() =>
            {
                DateTime today = DateTime.Now;
                DateTime dateCheck = today;
                List<MoldInforDTO> listM = MoldDAO.Instance.GetListMoldInfor();
                foreach (MoldInforDTO item in listM)
                {
                    int ShotTT = item.ShotTT;
                    int ShotTC = item.ShotTC;
                    string MoldeCode = item.MoldCode;
                    int test = MoldDAO.Instance.TestConfirm(MoldeCode);
                    float total = (float)ShotTT / (float)ShotTC;
                    int a = 0;
                    int b = MoldDAO.Instance.ConfirmMold(MoldeCode);
                    if (test == 1)
                    {
                        MoldDAO.Instance.UpdateConfirmMoldInfor(MoldeCode, 4);
                    }
                    else
                    {
                        if (total > 0.9)
                        {
                            a = 3;
                            MoldDAO.Instance.UpdateConfirmMoldInfor(MoldeCode, a);
                        }
                        else if (total <= 0.9 && total > 0.8)
                        {
                            a = 2;
                            MoldDAO.Instance.UpdateConfirmMoldInfor(MoldeCode, a);
                        }
                        else
                        {
                            a = 0;
                            MoldDAO.Instance.UpdateConfirmMoldInfor(MoldeCode, a);
                            MoldDAO.Instance.UpdateNoteMoldInfor(item.MoldCode, "");
                        }
                    }
                }
            });
        }
        #region QUẢN LÝ KHUÔN
        private void btnError_ItemClick(object sender, ItemClickEventArgs e)
        {
            MainId.MoldErrorId = 1;
            if (!CheckExistForm("frmMoldError"))
            {
                frmMoldError f = new frmMoldError();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmMoldError");
                frmMoldError f = new frmMoldError();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnRoomTest_ItemClick(object sender, ItemClickEventArgs e)
        {
            MainId.MoldErrorId = 2;
            if (!CheckExistForm("frmMoldError"))
            {
                frmMoldError f = new frmMoldError();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmMoldError");
                frmMoldError f = new frmMoldError();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnCategoryMold_ItemClick(object sender, ItemClickEventArgs e)
        {
            MainId.MoldErrorId = 3;
            if (!CheckExistForm("frmMoldError"))
            {
                frmMoldError f = new frmMoldError();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmMoldError");
                frmMoldError f = new frmMoldError();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnMoldInfor_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("fMold"))
            {
                fMold f = new fMold();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("fMold");
                fMold f = new fMold();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnListMold_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmMoldInfor"))
            {
                frmMoldInfor f = new frmMoldInfor();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmMoldInfor");
                frmMoldInfor f = new frmMoldInfor();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnMoldHistory_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmMoldHistory"))
            {
                frmMoldHistory f = new frmMoldHistory();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmMoldHistory");
                frmMoldHistory f = new frmMoldHistory();
                f.MdiParent = this;
                f.Show();
            }
        }
        private void btnMold1M_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmMoldSpecial"))
            {
                frmMoldSpecial f = new frmMoldSpecial();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmMoldSpecial");
                frmMoldSpecial f = new frmMoldSpecial();
                f.MdiParent = this;
                f.Show();
            }
        }
        #endregion


    }
}