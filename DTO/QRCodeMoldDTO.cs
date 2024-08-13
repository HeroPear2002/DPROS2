using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class QRCodeMoldDTO
    {
        public QRCodeMoldDTO(string MoldCode, string MoldName, string MoldNumber, string DateSX, int ShotTC, int ShotTT, int TotalShot, string Cav, string Category, string QrCode)
        {
            this.MoldCode = MoldCode;
            this.MoldName = MoldName;
            this.MoldNumber = MoldNumber;
            this.DateSX = DateSX;
            this.ShotTC = ShotTC;
            this.ShotTT = ShotTT;
            this.TotalShot = TotalShot;
            this.Cav = Cav;
            this.Category = Category;
            this.QrCode = QrCode;
        }
        public QRCodeMoldDTO(DataRow row)
        {
            this.MoldCode = row["MoldCode"].ToString();
            this.MoldName = row["MoldName"].ToString();
            this.MoldNumber = row["MoldNumber"].ToString();
            this.DateSX = row["DateSX"].ToString();
            this.ShotTC = (int)row["ShotTC"];
            this.ShotTT = (int)row["ShotTT"];
            this.TotalShot = (int)row["TotalShot"];
            this.Cav = row["Cav"].ToString();
            this.Category = row["Category"].ToString();
            this.QrCode = row["QrCode"].ToString();
        }
        private string moldCode;
        private string moldName;
        private string moldNumber;
        private string dateSX;
        private int shotTC;
        private int shotTT;
        private int totalShot;
        private string cav;
        private string category;
        private string qrCode;

        public string MoldCode { get => moldCode; set => moldCode = value; }
        public string MoldName { get => moldName; set => moldName = value; }
        public string MoldNumber { get => moldNumber; set => moldNumber = value; }
        public string DateSX { get => dateSX; set => dateSX = value; }
        public int ShotTC { get => shotTC; set => shotTC = value; }
        public int ShotTT { get => shotTT; set => shotTT = value; }
        public int TotalShot { get => totalShot; set => totalShot = value; }
        public string Cav { get => cav; set => cav = value; }
        public string Category { get => category; set => category = value; }
        public string QrCode { get => qrCode; set => qrCode = value; }
    }
}
