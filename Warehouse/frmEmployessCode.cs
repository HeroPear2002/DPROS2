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
using WareHouse.Input;
using WareHouse.MacCheck;
using WareHouse.Output;
using WareHouse.PC;
using WareHouse.PCGridControl;
using WareHouse.PO_and_Order;

namespace WareHouse
{
    public partial class frmEmployessCode : Form
    {
        public frmEmployessCode()
        {
            InitializeComponent();
            LoadControl();
        }
        public EventHandler LamMoi;
        int style = Kun_Static.Style;
        int style1 = Kun_Static.IdWh;
     
        void LoadControl()
        {
            this.AcceptButton = btnOK;
            Kun_Static.EmployessCode = txtEmployess.Text;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            Kun_Static.EmployessCode = txtEmployess.Text;
            int test = EmployessDAO.Instance.TestEmployessByCode(txtEmployess.Text);
            if (test == 1)
            {
                if (style1 == 8)
                {
                    frmCheckPC f = new frmCheckPC();
                    f.LamMoi += new EventHandler(btnExit_Click);
                    f.ShowDialog();
                    style1 = 0;
                }
                else
                {
                    switch (style)
                    {
                        case 1:
                            {
                                frmInputPart f = new frmInputPart();
                                f.LamMoi += new EventHandler(btnExit_Click);
                                f.ShowDialog();
                            }
                            break;
                        case 2:
                            {
                                frmOutputPart f = new frmOutputPart();
                                f.LamMoi += new EventHandler(btnExit_Click);
                                f.ShowDialog();
                            }
                            break;
                        case 3:
                            {
                                frmReInputPart f = new frmReInputPart();
                                f.LamMoi += new EventHandler(btnExit_Click);
                                f.ShowDialog();
                            }
                            break;
                        case 4:
                            {
                                frmReOutputPart f = new frmReOutputPart();
                                f.LamMoi += new EventHandler(btnExit_Click);
                                f.ShowDialog();
                            }
                            break;
                        case 5:
                            {
                                frmInput2 f = new frmInput2();
                                f.LamMoi += new EventHandler(btnExit_Click);
                                f.ShowDialog();
                               
                            }
                            break;
                        case 7:
                            {
                                frmInputPartDD1 f = new frmInputPartDD1();
                                f.LamMoi += new EventHandler(btnExit_Click);
                                f.ShowDialog();
                               
                            }
                            break;
                        case 8:
                            {
                                frmOutputDD1 f = new frmOutputDD1();
                                f.LamMoi += new EventHandler(btnExit_Click);
                                f.ShowDialog();
                            }
                            break;
                        case 9:
                            {
                                frmApproveDelivery f = new frmApproveDelivery();
                                f.LamMoi += new EventHandler(btnExit_Click);
                                f.ShowDialog();
                            }
                            break;
                        case 10:
                            {
                                frmAddCheck f = new frmAddCheck();
                                f.LamMoi += new EventHandler(btnExit_Click);
                                f.ShowDialog();
                            }
                            break;
                        case 11:
                            {
                                frmAddCheck f = new frmAddCheck();
                                f.LamMoi += new EventHandler(btnExit_Click);
                                f.ShowDialog();
                            }
                            break;
                        case 12:
                            {
                                frmPOCheck f = new frmPOCheck();
                                f.LamMoi += new EventHandler(btnExit_Click);
                                f.ShowDialog();
                            }
                            break;
                        default:
                            this.Close();
                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show("mã nhân viên không đúng !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Kun_Static.EmployessCode = "";
                txtEmployess.Enabled = true;
                txtEmployess.Focus(); 
                return;
            }

        }

        private void frmEmployessCode_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Kun_Static.Style = 0;
            LamMoi?.Invoke(sender, e);
            this.Close();
        }

        private void txtEmployess_TextChanged(object sender, EventArgs e)
        {
         
        }
    }
}
