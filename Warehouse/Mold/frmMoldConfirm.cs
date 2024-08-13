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

namespace WareHouse.Mold
{
    public partial class frmMoldConfirm : Form
    {
        public frmMoldConfirm()
        {
            InitializeComponent();
            LoadControl();
        }
        public EventHandler LamMoi;
        void LoadControl()
        {
            int typeAcc = Kun_Static.accountDTO.Type;
            string moldCode = frmMoldInfor.MoldInfor.moldCode;
            switch (typeAcc)
            {
                case 1:
                    {
                        string msg = string.Format(" phòng pc xác nhận\n\n Mã Khuôn : {0}\n\n Được phép chạy tiếp".ToUpper(),moldCode);
                        lblNote.Text =msg;
                    }
                    break;
                case 2:
                    {
                        string msg = string.Format(" phòng pc xác nhận\n\n Mã Khuôn : {0}\n\n Được phép chạy tiếp".ToUpper(), moldCode);
                        lblNote.Text = msg;
                    }
                    break;
                case 4:
                    {
                        string msg = string.Format(" phòng QC xác nhận\n\n Mã Khuôn : {0}\n\n Được phép chạy tiếp".ToUpper(), moldCode);
                        lblNote.Text = msg;
                    }
                    break;
                case 5:
                    {
                        string msg = string.Format(" phòng mold xác nhận\n\n Mã Khuôn : {0}\n\n Được phép chạy tiếp".ToUpper(), moldCode);
                        lblNote.Text = msg;
                    }
                    break;
                default:
                    break;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            int typeAcc = Kun_Static.accountDTO.Type;
            string moldCode = frmMoldInfor.MoldInfor.moldCode;
            string msg = "";
            string txt = txtNote.Text;
            string note = "";
            string noteMold = MoldDAO.Instance.NoteMold(moldCode);
            switch (typeAcc)
            {
                case 1:
                    {
                        typeAcc = 2;
                        msg = " phòng pc xác nhận không thể xác nhận lần nữa";
                        note = "PC : " + txt;
                    
                    }
                    break;
                case 2:
                    {
                        msg = " phòng pc xác nhận không thể xác nhận lần nữa";
                        note = "PC : " + txt;
                      
                    }
                    break;
                case 4:
                    {
                        msg = " phòng qc xác nhận không thể xác nhận lần nữa";
                        note = "QC : " + txt;
                   
                    }
                    break;
                case 5:
                    {
                        msg = " phòng Mold xác nhận không thể xác nhận lần nữa";
                        note = "Mold : " + txt;
                        
                    }
                    break;
                default:
                    break;
            }
            note = note +"\n"+ noteMold;
            int test = MoldDAO.Instance.TestMoldConfirm(moldCode, typeAcc);
            if (test == -1)
            {
                if (txt.Length > 0)
                {
                    MoldDAO.Instance.InsertMoldConfirm(moldCode, typeAcc);
                    MoldDAO.Instance.UpdateNoteMoldInfor(moldCode, note);
                    MessageBox.Show("xác nhận thành công !".ToUpper());
                    this.Close();
                }
                else
                {
                    MessageBox.Show("bạn chưa điền lý do cho chạy khuôn này ?".ToUpper());
                }
            }
            else
            {
                MessageBox.Show(msg.ToUpper());
            }
        }

        private void frmMoldConfirm_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }
    }
}
