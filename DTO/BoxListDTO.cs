using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class BoxListDTO
    {
        public BoxListDTO(string BoxCode,string BoxName,string StyleBox,int BoxIventory)
        {
            this.BoxCode = BoxCode;
            this.BoxName = BoxName;
            this.StyleBox = StyleBox;
            this.BoxIventory = BoxIventory;
        }
        public BoxListDTO(DataRow row)
        {
            this.BoxCode = row["BoxCode"].ToString();
            this.BoxName = row["BoxName"].ToString();;
            this.StyleBox = row["StyleBox"].ToString();;
            this.BoxIventory = (int)row["BoxIventory"];
        }
        private string boxCode;
        private string boxName;
        private string styleBox;
        private int boxIventory;
        public string BoxCode
        {
            get
            {
                return boxCode;
            }

            set
            {
                boxCode = value;
            }
        }

        public string BoxName
        {
            get
            {
                return boxName;
            }

            set
            {
                boxName = value;
            }
        }

        public string StyleBox
        {
            get
            {
                return styleBox;
            }

            set
            {
                styleBox = value;
            }
        }

        public int BoxIventory
        {
            get
            {
                return boxIventory;
            }

            set
            {
                boxIventory = value;
            }
        }
    }
}
