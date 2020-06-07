using System;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;

public class inloggegevensWijzigen
{
    public void inloggegevensWijzigenFunc(int cijfer)
    {
        string buffer = File.ReadAllText(@"gebruiker_id.json");
        JsonClassLogin gebruikerIdJson = JsonConvert.DeserializeObject<JsonClassLogin>(buffer);
        
        var gebruikersnaam = "";
        var wachtwoord = "";
        var email_variabele = "";
        
        while (true)
        {
            Console.Clear();
            for (int i = 0; i < gebruikerIdJson.Gebruiksnaam.Count; i++)
            {
                if (gebruikerIdJson.id[i] == gebruikerIdJson.id[cijfer])
                {
                    Console.WriteLine("Dit zijn uw huidige inloggegevens");
                    Console.WriteLine("Gebruikersnaam: " + gebruikerIdJson.Gebruiksnaam[i] + "\n" + "Wachtwoord: " + gebruikerIdJson.Wachtwoord[i] + "\n" + "E-mail: " + gebruikerIdJson.Email[i] + "\n");
                }
            }

            Console.WriteLine("wat wilt u wijzigen");
            Console.WriteLine(" [1]. Gebruikersnaam wijzigen\n [2]. Wachtwoord wijzigen\n [3]. E-mail wijzigen\n [4]. Terug naar de customerscherm\n");

            bool checkWachtwoord = false;
            bool checkGebruikersnaam = false;
            bool checkEmail = false;
            bool checkExistance = false;
            var keuzeGegevens = Console.ReadLine();
            if (keuzeGegevens == "1")
            {
                do
                {
                    checkExistance = false;
                    Console.WriteLine("Voer een nieuwe gebruiksnaam in: (met een lengte van 5 karakters met letters en/of cijfers en de eerste letter als hoofdletter)");
                    gebruikersnaam = Console.ReadLine();
                    for (int i = 0; i < gebruikerIdJson.Gebruiksnaam.Count; i++)
                    {
                        if (gebruikersnaam == gebruikerIdJson.Gebruiksnaam[i])
                        {
                            checkExistance = true;
                        }
                    }
                    if (checkExistance == true)
                    {
                        Console.WriteLine("Deze gebruikersnaam is al ingenomen");
                    }
                    foreach (char character in gebruikersnaam)
                    {
                        if (!Char.IsLetterOrDigit(character) || gebruikersnaam.Length < 5 || !Char.IsUpper(gebruikersnaam[0]))
                        {
                            checkGebruikersnaam = true;
                        }
                        else
                        {
                            checkGebruikersnaam = false;
                        }
                    }
                    if (string.IsNullOrWhiteSpace(gebruikersnaam) || string.IsNullOrEmpty(gebruikersnaam))
                    {
                        checkGebruikersnaam = true;
                    }
                } while (checkGebruikersnaam == true || checkExistance == true);

                for (int i = 0; i < gebruikerIdJson.id.Count; i++)
                {
                    if (gebruikerIdJson.id[cijfer] == gebruikerIdJson.id[i])
                    {
                        gebruikerIdJson.Gebruiksnaam[i] = gebruikersnaam;
                    }
                }

            }
            if (keuzeGegevens == "2")
            {
                do
                {
                    Console.WriteLine("Voer een nieuwe wachtwoord in: (met een lengte van 8 karakters met letters en/of cijfers en de eerste letter als hoofdletter)");
                    wachtwoord = Console.ReadLine();
                    foreach (char character in wachtwoord)
                    {
                        if (!Char.IsLetterOrDigit(character) || wachtwoord.Length < 8 || !Char.IsUpper(wachtwoord[0]))
                        {
                            checkWachtwoord = true;
                        }
                        else
                        {
                            checkWachtwoord = false;
                        }
                    }
                    if (string.IsNullOrWhiteSpace(wachtwoord) || string.IsNullOrEmpty(wachtwoord))
                    {
                        checkWachtwoord = true;
                    }
                } while (checkWachtwoord == true);

                for (int i = 0; i < gebruikerIdJson.id.Count; i++)
                {
                    if (gebruikerIdJson.id[cijfer] == gebruikerIdJson.id[i])
                    {
                        gebruikerIdJson.Wachtwoord[i] = wachtwoord;
                    }
                }

            }
            if (keuzeGegevens == "3")
            {
                try
                {
                    do
                    {
                        checkExistance = false;
                        Console.WriteLine("Voer een  E-mail in: ");
                        email_variabele = Console.ReadLine();
                        for (int i = 0; i < gebruikerIdJson.Email.Count; i++)
                        {
                            if (email_variabele == gebruikerIdJson.Email[i])
                            {
                                checkExistance = true;
                            }
                        }
                        if (checkExistance == true)
                        {
                            Console.WriteLine("Dit account bestaat al");
                        }
                        if (Regex.Replace(email_variabele, "^[A-Za-z0-9_-]+@(hotmail|gmail|yahoo)(.com|.nl)$", string.Empty).Length == 0)
                        {
                            if (checkExistance == false)
                            {
                                checkEmail = true;
                            }
                        }
                    } while (checkEmail == false || checkExistance == true);
                }
                catch
                {
                    Console.WriteLine("Voer een geldig E-mail in: ");
                }

                for (int i = 0; i < gebruikerIdJson.id.Count; i++)
                {
                    if (gebruikerIdJson.id[cijfer] == gebruikerIdJson.id[i])
                    {
                        gebruikerIdJson.Email[i] = email_variabele;
                    }
                }

            }
            if (keuzeGegevens == "4")
            {
                Console.WriteLine("klik op een toets om terug te keren naar de customer scherm");
                Console.ReadKey();
                break;
            }
            string strNieuweGebruikerIdJson = JsonConvert.SerializeObject(gebruikerIdJson);
            File.WriteAllText(@"gebruiker_id.json", strNieuweGebruikerIdJson);
        }
    }
}