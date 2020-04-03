
using System;
using System.Net;
using System.Net.Mail;

public class email {
    public void emailFunc(string email)
    {
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress("restaurantappgroep1a@gmail.com");
        SmtpClient smtp = new SmtpClient();
        smtp.Port = 587;
        smtp.EnableSsl = true;
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtp.UseDefaultCredentials = true;
        smtp.Credentials = new NetworkCredential("restaurantappgroep1a@gmail.com", "groep1groep1");
        smtp.Host = "smtp.gmail.com";
        


        //ontvanger
        mail.To.Add(new MailAddress("fatih.catak@outlook.com"));
        mail.Subject = "Inloggegevens";
        mail.IsBodyHtml = true;
        mail.Body = "Test";
        smtp.Send(mail);
        //smtp.Send("restaurantappgroep1a@gmail.com", "0986192@hr.nl", "Inloggegevens", "werkt het?");

    }

}