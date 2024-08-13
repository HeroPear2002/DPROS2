using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EMailDetail 
    {
        private long id;
        private string sMTP;
        private int port;
        private string email;
        private string appPass;

        public EMailDetail(long id, string sMTP, int port, string email, string appPass)
        {
            this.id = id;
            this.sMTP = sMTP;
            this.port = port;
            this.email = email;
            this.appPass = appPass;
        }
        public EMailDetail(DataRow row)
        {
            this.id = (long)row["Id"];
            this.sMTP = row["SMTP"].ToString();
            this.port = (int)row["Port"];
            this.email = row["Email"].ToString();
            this.appPass = row["AppPass"].ToString();
        }
        public long Id { get => id; set => id = value; }
        public string SMTP { get => sMTP; set => sMTP = value; }
        public int Port { get => port; set => port = value; }
        public string Email { get => email; set => email = value; }
        public string AppPass { get => appPass; set => appPass = value; }
    }
}
