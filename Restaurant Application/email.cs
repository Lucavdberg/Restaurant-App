
using System;
using System.Net;
using System.Net.Mail;
using Newtonsoft.Json;
using System.IO;

public class email {
    public void emailFunc()
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

        string buffer = File.ReadAllText(@"gebruiker_id.json");
        JsonClassLogin gebruikerIdJson = JsonConvert.DeserializeObject<JsonClassLogin>(buffer);

        Console.WriteLine("Vul hier uw emailadres in zodat wij een mail naar uw kunnen sturen met uw inloggegevens");
        var ingevoerdeEmail = Console.ReadLine();
        string naam = "";
        string wachtwoord = "";
        string gevondenEmail = "";
        for (int i = 0; i < gebruikerIdJson.Email.Count; i++)
        {
            if (ingevoerdeEmail == gebruikerIdJson.Email[i])
            {
                naam = gebruikerIdJson.Gebruiksnaam[i];
                wachtwoord = gebruikerIdJson.Wachtwoord[i];
                gevondenEmail = gebruikerIdJson.Email[i];
            }
        }

        if (naam != "" && wachtwoord != "")
        {
            try
            {
                mail.To.Add(new MailAddress(gevondenEmail)); 
                mail.Subject = "Inloggegevens";
                mail.IsBodyHtml = true;
                mail.Body = "Gebruiksnaam: " + naam + "<br />" + "Wachtwoord: " + wachtwoord;
                smtp.Send(mail);
                Console.WriteLine("Er is een mail gestuurd met uw inloggegevens naar uw email \nklik op een toets om terug te keren naar het hoofdmenu");
                Console.ReadKey();
            }
            catch
            {
                Console.WriteLine("Het ingevoerde email adres bestaat niet \nklik op een toets om terug te keren naar het hoofdmenu");
                Console.ReadKey();
            }
        }
    }
}