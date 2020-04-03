using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

public class Customerlogin
{
    public int LoginFunc(JsonClass gebruiker)
    {
       

        Console.WriteLine("Wilt u inloggen of een account aanmaken");
        var inloggen_aanmaken = Console.ReadLine();
        if (inloggen_aanmaken == "aanmaken" || inloggen_aanmaken == "account aanmaken")
        {
            Console.Write("Voer een gebruiksnaam in: ");
            var gebruiksnaam = Console.ReadLine();
            Console.Write("Voer een wachtwoord in: ");
            var wachtwoord = Console.ReadLine();
            Console.Write("Voer een E-mail in: ");
            var email_variabele = Console.ReadLine();



            gebruiker.Email = email_variabele;
            gebruiker.Gebruiksnaam = gebruiksnaam;
            gebruiker.id = 123123;
            gebruiker.Wachtwoord = wachtwoord;

            string strResultJson = JsonConvert.SerializeObject(gebruiker);
            Console.WriteLine(strResultJson);
            File.WriteAllText(@"gebruiker_id.json", strResultJson);
            Console.WriteLine("stored!");
            strResultJson = File.ReadAllText(@"gebruiker_id.json");
            JsonClass resultJsonClass = JsonConvert.DeserializeObject<JsonClass>(strResultJson);
            Console.WriteLine(resultJsonClass.Email);
            
        }

        if (inloggen_aanmaken == "inloggen")
        {
            int counter = 0;
            for (int i = 0; i < 5; i++)
            {
                string strResultJson = JsonConvert.SerializeObject(gebruiker);
                strResultJson = File.ReadAllText(@"gebruiker_id.json");
                JsonClass resultJsonClass = JsonConvert.DeserializeObject<JsonClass>(strResultJson);
                string inlogNaam = resultJsonClass.Gebruiksnaam;
                string inlogWachtwoord = resultJsonClass.Wachtwoord;

                Console.Write("gebruiksnaam: ");
                var naam = Console.ReadLine();
                Console.Write("wachtwoord: ");
                var wacht = Console.ReadLine();
                if (naam == inlogNaam && wacht == inlogWachtwoord)
                {
                    Console.WriteLine("u bent ingelogd!");
                    Console.ReadKey();
                    return 2;
           
                }
                          
                Console.WriteLine("uw gegevens zijn verkeerd!");
                counter++;
                if (counter > 2)
                {
                    Console.WriteLine("Uw inloggevens zijn te vaak fout ingevuld");
                    
                    Console.WriteLine("login fail");
                    return 1;
                }

            }
        }

        return 0;
    }
}

