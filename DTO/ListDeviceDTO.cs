using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ListDeviceDTO
    {
        public ListDeviceDTO(int Id, string Name, int StatusDevice, string UrlImage, string FormCode, string UrlEveryDay, string UrlEverMainten)
        {
            this.Id = Id;
            this.Name = Name;
            this.StatusDevice = StatusDevice;
            this.UrlImage = UrlImage;
            this.FormCode = FormCode;
            this.UrlEveryDay = UrlEveryDay;
            this.UrlEveryMainten = UrlEveryMainten;
        }
        public ListDeviceDTO(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.Name = row["Name"].ToString();
            this.StatusDevice = (int)row["StatusDevice"];
            this.FormCode = row["FormCode"].ToString();
            this.UrlImage = row["UrlImage"].ToString();
            this.UrlEveryDay = row["UrlEveryDay"].ToString();
            this.UrlEveryMainten = row["UrlEveryMainten"].ToString();
        }
        private int id;
        private string name;
        private int statusDevice;
        private string formCode;
        private string urlImage;
        private string urlEveryDay;
        private string urlEveryMainten;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public int StatusDevice
        {
            get
            {
                return statusDevice;
            }

            set
            {
                statusDevice = value;
            }
        }
        public string UrlImage { get => urlImage; set => urlImage = value; }
        public string FormCode { get => formCode; set => formCode = value; }
        public string UrlEveryDay { get => urlEveryDay; set => urlEveryDay = value; }
        public string UrlEveryMainten { get => urlEveryMainten; set => urlEveryMainten = value; }
    }
}
