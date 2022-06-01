using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail; 


namespace WebApplication2.BL.Healper
{
    public static class SendMailHealper
    {
        public static string sendMail(string title , string msg)
        {
            try
            {
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("radio.mahdy@gmail.com", "A@0123420729321");
                smtp.Send("radio.mahdy@gmail.com", "mahmoodmady44@gmail.com", title, msg);
                return "Mail Sent Successfully";
            }
            catch (Exception)
            {
                return "Mail Failed";
            }
            

        }
    }
}
