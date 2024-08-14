using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse.Common
{
   public class SendEMail
    {
        public static void SendGMail(string to,string subject,string message)
        {
            //EMailDetail eM = EMailDetailDAO.Instance.GetItem();
            //string from = eM.Email;
            //to = to.Substring(0, to.Length - 1);
            //MailMessage mess = new MailMessage(from, to, subject, message);
            //SmtpClient client = new SmtpClient(eM.SMTP, eM.Port);
            //client.EnableSsl = true;
            //client.Credentials = new NetworkCredential(eM.Email, eM.AppPass);
            //try
            //{
            //    client.Send(mess);
            //}
            //catch (Exception ex)
            //{
            //    EditHistoryDAO.Instance.Insert(DateTime.Now, Kun_Static.accountDTO.UserName, ex.Message, "Lỗi Gửi Mail");
            //}
        }
    }
}
