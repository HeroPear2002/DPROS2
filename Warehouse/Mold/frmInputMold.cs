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
using System.Globalization;

namespace WareHouse.Mold
{
    public partial class frmInputMold : DevExpress.XtraEditors.XtraForm
    {
        public frmInputMold()
        {
            InitializeComponent();
        }
        public EventHandler LamMoi;
        private void btnSave_Click(object sender, EventArgs e)
        {
            int test = EmployessDAO.Instance.TestEmployessByCode(txtEmployess.Text);
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            if (test == 1)
            {
                string QrCode = txtQrCode.Text;
                if (QrCode.Length > 0)
                {
                    string[] array = QrCode.Split('&');
                    string moldCode = array[0];
                    string moldName = array[1];
                    string moldNumber = array[2];
                    string dateSX = array[3];
                    int shotTC = int.Parse(array[4]);
                    int shotTT = int.Parse(array[5]);
                    int totalShot = int.Parse(array[6]);
                    string cav = array[7];
                    int Idcategory = int.Parse(array[8]);
                    string category = "";
                    if (Idcategory != -1)
                    {
                        category = MoldDAO.Instance.NameErrorMold(Idcategory);
                    }

                    DateTime date = DateTime.Now;
                    try
                    {
                        date = DateTime.Parse(dateSX);
                    }
                    catch
                    {

                    }
                    int testMold = MoldDAO.Instance.TestMoldInforByCode(moldCode);
                    if (testMold == 1)
                    {
                        MoldDAO.Instance.UpdateMoldInforByQRCode(moldCode, shotTC, shotTT, totalShot, category, cav, 0);
                        MessageBox.Show("nhận khuôn thành công !".ToUpper());
                        this.Close();
                    }
                    else
                    {
                        int testMoldList = MoldDAO.Instance.TestMoldByCode(moldCode);
                        if (testMoldList == 1)
                        {
                            MoldDAO.Instance.InsertMoldInfor(moldCode, shotTC, shotTT, totalShot, 0, category, "", "", cav, "", "", DateTime.Now, 0);
                            MessageBox.Show("nhận khuôn thành công !".ToUpper());
                            this.Close();
                        }
                        else
                        {
                            MoldDAO.Instance.InsertMold(moldCode, moldName, moldNumber, "", "", DateTime.Now, "", date, totalShot, txtEmployess.Text, "");
                            MoldDAO.Instance.InsertMoldInfor(moldCode, shotTC, shotTT, totalShot, 0, category, "", "", cav, "", "", DateTime.Now, 0);
                            MessageBox.Show("nhận khuôn thành công !".ToUpper());
                            this.Close();
                        }
                    }
                    EditHistoryDAO.Instance.Insert(DateTime.Now, txtEmployess.Text, " Đã nhận khuôn : " + moldCode, "");
                }
                else
                {
                    MessageBox.Show("mã QRCode không đúng !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("mã nhân viên không đúng !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmInputMold_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }
    }
}