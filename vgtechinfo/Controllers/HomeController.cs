using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using vgtechinfo.Models;

namespace vgtechinfo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Send()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public void ValidarDados(string nome, string email, string telefone, string mensagem)
        {

            using (System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient())
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("alcantaraweb851@gmail.com", "gabriel851");


                using (System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage())
                {
                    mail.From = new System.Net.Mail.MailAddress(email);

                    if (!string.IsNullOrWhiteSpace("alcantaraweb851@gmail.com"))
                    {
                        mail.To.Add(new System.Net.Mail.MailAddress("alcantaraweb851@gmail.com"));
                    }

                    mail.Subject = "Preciso de suporte - Alcantara Web!";
                    mail.Body = "Nome do Solicitante:" + nome+ "\n\n E-Mail: " + email + "\n\n Telefone: " + telefone+ "\n\n Solicitação: " + mensagem;

                    smtp.Send(mail);

                    Response.Redirect("/Home/Send");
                }

            }
           
        }
    }
}
