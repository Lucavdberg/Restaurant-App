using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Customerlogin
{
    public Tuple<int, int> LoginFunc(JsonClassLogin writeResultJson)
    {
        Console.WriteLine("Wilt u inloggen type(1) of een account aanmaken type(2)");
        var inloggen_aanmaken = Console.ReadLine();
        if (inloggen_aanmaken == "2")
        {
            //kijkt of de json file bestaat in dezelfde directory als het project
            string curFile = @"gebruiker_id.json";
            var exist = File.Exists(curFile) ? true : false;

            //de json file bestaat niet in het project folder en wordt aangemaakt en gevuld met null
            if (exist == false)
            {
                string existance = JsonConvert.SerializeObject(null);
                File.WriteAllText(@"gebruiker_id.json", existance);
            }
            
            string buffer = File.ReadAllText(@"gebruiker_id.json");
            JsonClassLogin gebruikerIdJson = JsonConvert.DeserializeObject<JsonClassLogin>(buffer);

            var gebruikersnaam = "";
            var wachtwoord = "";
            var email_variabele = "";

            while (true)
            {
                bool check = false;
                bool checkTwo = false;
                int checker = 0;
                bool checkE  = false;
                Console.WriteLine("Voer een gebruiksnaam in: (met een lengte van 5 karakters met letters en de eerste letter als hoofdletter )");
                gebruikersnaam = Console.ReadLine();
                Console.WriteLine("Voer een wachtwoord in: (met een lengte van 8 karakters met letters en de eerste letter als hoofdletter)");
                wachtwoord = Console.ReadLine();
                
                try
                {
                     checkE = false;
                    do
                    {
                        Console.WriteLine("Voer een E-mail in: (xxx@xxx.xxx)");
                        email_variabele = Console.ReadLine();



                        if (Regex.Replace(email_variabele, "\\w+([-+.']\\w+)@\\w+([-.]\\w+)\\.\\w+([-.]\\w+)*", string.Empty).Length == 0)
                        {
                            checkE = true;
                        }


                    } while (checkE);
                }
                catch
                {
                    Console.WriteLine("Voer een gildge E-mail in: (xx32wex@xxx.xxx)");
                }

                if (gebruikerIdJson != null) {
                    for (int i = 0; i < gebruikerIdJson.Gebruiksnaam.Count; i++)
                    {
                        if (gebruikersnaam == gebruikerIdJson.Gebruiksnaam[i] || wachtwoord == gebruikerIdJson.Wachtwoord[i] || email_variabele == gebruikerIdJson.Email[i] || gebruikersnaam == "" || wachtwoord == "" || email_variabele == "")
                        {
                            check = true;
                            Console.WriteLine("Dit account bestaat al");

                        }
                    }
                    if (checkE == true)
                    {
                        break;
                    }
                }

                if (gebruikerIdJson == null) {
                    if (gebruikersnaam == "" || wachtwoord == "" || email_variabele == "")
                    {
                        check = true;
                        Console.WriteLine("Vul de velden in");
                    }
                }
                foreach (char character in gebruikersnaam)
                {
                    if (!Char.IsLetter(character) || gebruikersnaam.Length < 5 || !Char.IsUpper(gebruikersnaam[0]))
                    {
                        checkTwo = true;
                        checker = 2;
                    }
                }
                foreach (char character in wachtwoord)
                {
                    if (!Char.IsLetter(character) || wachtwoord.Length < 8 || !Char.IsUpper(wachtwoord[0]))
                    {
                        check = true;
                        checker = 1;
                    }   
                }
                if (check == true && checker == 1)
                {
                    Console.WriteLine("voer een sterker wachtwoord in met een lengte van 8 karakters met letters en de eerste letter als hoofdletter");
                }
                if (checkTwo == true && checker == 2)
                {
                    Console.WriteLine("voer een langere gebruikersnaam in met een lengte van 5 karakters met letters en de eerste letter als hoofdletter");
                }
                if (check == false && checkTwo == false)
                {
                    break;
                }
            }

            writeResultJson.Email = new List<string>();
            writeResultJson.id = new List<int>();
            writeResultJson.Gebruiksnaam = new List<string>();
            writeResultJson.Wachtwoord = new List<string>();

            if(gebruikerIdJson != null)
            {
                for (int i = 0; i < gebruikerIdJson.Email.Count; i++)
                {
                    writeResultJson.Email.Add(gebruikerIdJson.Email[i]);
                    writeResultJson.id.Add(gebruikerIdJson.id[i]);
                    writeResultJson.Gebruiksnaam.Add(gebruikerIdJson.Gebruiksnaam[i]);
                    writeResultJson.Wachtwoord.Add(gebruikerIdJson.Wachtwoord[i]);
                }
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
            try
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
                            return Tuple.Create(2, j);
                        }
                    }
                    Console.WriteLine("uw gegevens zijn verkeerd!");
                    counter++;
                    if (counter > 2)
                    {
                        Console.WriteLine("Uw inloggevens zijn te vaak fout ingevuld");
                        Console.WriteLine("login fail");
                        return Tuple.Create(1, 100);
                    }
                }
            }
            catch
            {
                Console.WriteLine("U moet eerst een account aanmaken");
                return Tuple.Create(3, 100);
            }
        }
        return Tuple.Create(0, 0);
    }
}