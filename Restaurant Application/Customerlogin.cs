using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

public class Customerlogin
{
    public int LoginFunc(JsonClassLogin gebruiker)
    {
        Console.WriteLine("Wilt u inloggen type(1) of een account aanmaken type(2)");
        var inloggen_aanmaken = Console.ReadLine();
        if (inloggen_aanmaken == "2")
        {
            Console.WriteLine("Voer een gebruiksnaam in: ");
            var gebruikersnaam = Console.ReadLine();
            Console.WriteLine("Voer een wachtwoord in: ");
            var wachtwoord = Console.ReadLine();
            Console.WriteLine("Voer een E-mail in: ");
            var email_variabele = Console.ReadLine();

            gebruiker.Email = new List<string> { email_variabele };
            gebruiker.Gebruiksnaam = new List<string> { gebruikersnaam };
            gebruiker.id = new List<int> { new Random().Next(1000, 9999) };
            gebruiker.Wachtwoord = new List<string> { wachtwoord };

            string buffer = File.ReadAllText(@"gebruiker_id.json");
            JsonClassLogin gebruikerIdJson = JsonConvert.DeserializeObject<JsonClassLogin>(buffer);

            JsonClassLogin writeResultJson = new JsonClassLogin();

            writeResultJson.Email = new List<string>();
            writeResultJson.id = new List<int>();
            writeResultJson.Gebruiksnaam = new List<string>();
            writeResultJson.Wachtwoord = new List<string>();
            for (int i = 0; i < gebruikerIdJson.Email.Count; i++)
            {


                writeResultJson.Email.Add(gebruikerIdJson.Email[i]);
                writeResultJson.id.Add(gebruikerIdJson.id[i]);
                writeResultJson.Gebruiksnaam.Add(gebruikerIdJson.Gebruiksnaam[i]);
                writeResultJson.Wachtwoord.Add(gebruikerIdJson.Wachtwoord[i]);
            }


            writeResultJson.Email.Add(email_variabele);
            writeResultJson.Gebruiksnaam.Add(gebruikersnaam);
            writeResultJson.id.Add(new Random().Next(1000, 9999));
            writeResultJson.Wachtwoord.Add(wachtwoord);

            string strResultJson = JsonConvert.SerializeObject(writeResultJson);
            File.WriteAllText(@"gebruiker_id.json", strResultJson);
        }

        if (inloggen_aanmaken == "1")
        {
            string buffer = File.ReadAllText(@"gebruiker_id.json");
            JsonClassLogin gebruikerIdJson = JsonConvert.DeserializeObject<JsonClassLogin>(buffer);
            int counter = 0;
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("gebruiksnaam: ");
                var naam = Console.ReadLine();
                Console.WriteLine("wachtwoord: ");
                var wacht = Console.ReadLine();
                for (int j = 0; j < gebruikerIdJson.Gebruiksnaam.Count; j++)
                {
                    if (naam == gebruikerIdJson.Gebruiksnaam[j] && wacht == gebruikerIdJson.Wachtwoord[j])
                    {
                        Console.WriteLine("u bent ingelogd!");
                        return 2;
                    } 
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

