using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Customerlogin
{
    public static string ReadPassword()
    {
        string password = "";
        ConsoleKeyInfo info = Console.ReadKey(true);
        while (info.Key != ConsoleKey.Enter)
        {
            if (info.Key != ConsoleKey.Backspace)
            {
                Console.Write("*");
                password += info.KeyChar;
            }
            else if (info.Key == ConsoleKey.Backspace)
            {
                if (!string.IsNullOrEmpty(password))
                {
                    // haal een letter van de lijst met het wachtwoord weg
                    password = password.Substring(0, password.Length - 1);
                    // de locatie van de cursor
                    int pos = Console.CursorLeft;
                    // verplaats de cursor naar links met een character
                    Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    // vervang het met een spatie
                    Console.Write(" ");
                    // verplaats de cursor naar links met een character (opnieuw)
                    Console.SetCursorPosition(pos - 1, Console.CursorTop);
                }
            }
            info = Console.ReadKey(true);
        }
        // een nieuwe lijn toevoegen want de gebruiker heeft op 'enter' gedrukt
        Console.WriteLine();
        return password;
    }
    public Tuple<int, int> LoginFunc(JsonClassLogin writeResultJson)
    {
        //Console.WriteLine("Wilt u inloggen type(1) of een account aanmaken type(2)");
        var inloggen_aanmaken = "";
        do
        {
            Console.WriteLine(" [1]. Inloggen\n [2]. Account aanmaken\n [3]. Terug naar het hoofdmenu");
            Console.Write("\n Uw keuze: ");
            inloggen_aanmaken = Console.ReadLine();
        } while (inloggen_aanmaken != "1" && inloggen_aanmaken != "2" && inloggen_aanmaken != "3");

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
                bool checkWachtwoord = false;
                bool checkGebruikersnaam = false;
                bool checkExistance = false;
                do
                {
                    Console.Clear();
                    Console.WriteLine("\n - U kunt een account aanmaken... Vul onderstaande gegevens in \n");
                    Console.WriteLine(" Gebruikersnaam... (LET OP: 1E LETTER HOOFDLETTER, MINIMAAL 5 KARAKTERS, LETTERS EN/OF CIJFERS)");
                    Console.Write(" Uw gebruikersnaam: ");
                    gebruikersnaam = Console.ReadLine();
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
                } while (checkGebruikersnaam == true);
                do
                {
                    Console.WriteLine("\n Wachtwoord... (LET OP: 1E LETTER HOOFDLETTER, MINIMAAL 8 KARAKTERS, LETTERS EN/OF CIJFERS)");
                    Console.Write(" Uw wachtwoord: ");
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
                bool checkEmail = false;
                try
                {
                    do
                    {
                        Console.WriteLine("\n E-mailadres...");
                        Console.Write(" Uw e-mailadres: ");
                        email_variabele = Console.ReadLine();
                        if (email_variabele == "")
                        {
                            checkEmail = false;
                        }

                        else if (Regex.Replace(email_variabele, "\\w+([-+.']\\w+)*@(hotmail|outlook|live|gmail|yahoo)(.com|.nl)$", string.Empty).Length == 0)

                        {
                            checkEmail = true;
                        }
                    } while (!checkEmail);
                }
                catch
                {
                    Console.WriteLine(" Voer a.u.b. een geldig e-mailadres in: ");
                }
                if (gebruikerIdJson != null) 
                {
                    for (int i = 0; i < gebruikerIdJson.Gebruiksnaam.Count; i++)
                    {
                        if (gebruikersnaam == gebruikerIdJson.Gebruiksnaam[i] || email_variabele == gebruikerIdJson.Email[i])
                        {
                            checkExistance = true;  
                        }
                    }
                    if(checkExistance == true)
                    {
                        Console.WriteLine(" Dit account bestaat al.");
                    }
                }
                if (checkWachtwoord == false && checkGebruikersnaam == false && checkEmail == true && checkExistance == false)
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
            Console.Clear();
            Console.WriteLine("\n - Inloggen... Vul uw gegevens in.");
            try
            {
                string buffer = File.ReadAllText(@"gebruiker_id.json");
                JsonClassLogin gebruikerIdJson = JsonConvert.DeserializeObject<JsonClassLogin>(buffer);
                int counter = 0;
                for (int i = 0; i < 5; i++)
                {
                    Console.Write("\n Uw gebruikersnaam: ");
                    var naam = Console.ReadLine();
                    Console.Write(" Uw wachtwoord: ");
                    var wacht = ReadPassword();
                    for (int j = 0; j < gebruikerIdJson.Gebruiksnaam.Count; j++)
                    {
                        if (naam == gebruikerIdJson.Gebruiksnaam[j] && wacht == gebruikerIdJson.Wachtwoord[j])
                        {
                            Console.WriteLine(" - U bent ingelogd!");
                            return Tuple.Create(2, j);
                        }
                    }
                    Console.WriteLine(" - Uw gegevens zijn verkeerd!");
                    counter++;
                    if (counter > 2)
                    {
                        Console.WriteLine(" - Uw inloggevens zijn te vaak fout ingevuld");
                        Console.WriteLine(" - login fail");
                        return Tuple.Create(1, 100);
                    }
                }
            }
            catch
            {
                Console.WriteLine(" - U moet eerst een account aanmaken");
                return Tuple.Create(3, 100);
            }
        }

        if (inloggen_aanmaken == "3")
        {
            return Tuple.Create(100, 100);
        }
        return Tuple.Create(0, 0);
    }
}