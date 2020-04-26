
using System;
using System.Net;
using System.Net.Mail;
using Newtonsoft.Json;
using System.IO;

public class email {
    public void emailFunc(JsonClassLogin email)
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

        string strResultJson = JsonConvert.SerializeObject(email);
        strResultJson = File.ReadAllText(@"gebruiker_id.json");
        JsonClassLogin resultJsonClass = JsonConvert.DeserializeObject<JsonClassLogin>(strResultJson);

        //ontvanger
        try
        {
            mail.To.Add(new MailAddress(resultJsonClass.Email[0])); // VERANDER DIT LATER >>>> [0]
            mail.Subject = "Inloggegevens";
            mail.IsBodyHtml = true;
            mail.Body = "Gebruiksnaam: " + resultJsonClass.Gebruiksnaam + "<br />" + "Wachtwoord: " + resultJsonClass.Wachtwoord;
            smtp.Send(mail);
            Console.WriteLine("Er is een mail gestuurd met uw inloggegevens naar uw email" + "\n" + "klik op een toets om terug te keren naar het hoofdmenu");
            Console.ReadKey();
        }
        catch 
        {
            Console.WriteLine("Het ingevoerde email adres dat hoort bij uw account is ongeldig waardoor er geen email kan worden gestuurd met inloggevens");
            Console.WriteLine("u wordt aangeraden om uw email adres te wijzigen");
            Console.WriteLine("type(1) om uw email adres te wijzigen of type(2) om terug te gaan naar het hoofdmenu");
            var aanraden = Console.ReadLine();
            if (aanraden == "1")
            {
                Console.WriteLine("uw huidige email adres is " + resultJsonClass.Email);
                Console.WriteLine("type uw nieuwe email adres in");
                resultJsonClass.Email[0] = Console.ReadLine(); // VERANDER DIT LATER >>>> [0]

                string strNieuweEmail = JsonConvert.SerializeObject(resultJsonClass);
                File.WriteAllText(@"gebruiker_id.json", strNieuweEmail);
                strNieuweEmail = File.ReadAllText(@"gebruiker_id.json");
                JsonClassLogin resultNieuweEmail = JsonConvert.DeserializeObject<JsonClassLogin>(strNieuweEmail);

                Console.WriteLine("uw nieuwe email is " + resultNieuweEmail.Email);
                Console.WriteLine("klik op een toets om terug te keren naar het hoofdmenu");
                Console.ReadKey();
            }
            if (aanraden == "2")
            {
                Console.WriteLine("klik op een toets om terug te keren naar het hoofdmenu");
                Console.ReadKey();
            }   
        } 
    }
}