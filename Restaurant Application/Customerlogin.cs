using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Security;
using System.Text.RegularExpressions;

public class Customerlogin
{

    public Tuple<int, int> LoginFunc(JsonClassLogin gebruiker)
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
                string lol = JsonConvert.SerializeObject(null);
                File.WriteAllText(@"gebruiker_id.json", lol);
            }
            
            string buffer = File.ReadAllText(@"gebruiker_id.json");
            JsonClassLogin gebruikerIdJson = JsonConvert.DeserializeObject<JsonClassLogin>(buffer);

            var gebruikersnaam = "";
            var wachtwoord = "";
            var email_variabele = "";

            while (gebruikerIdJson != null)
            {
                bool check = false;
                bool check1 = false;
                bool checkE = false;
                // gebruiksnaam controleren
                try
                {
                 //    check1 = false;
                    do
                    {
                        Console.WriteLine("Voer een geldige gebruikersnaam in / bevat alleen letters en de eerste letter moet hoofdletter zijn ");
                         gebruikersnaam = Console.ReadLine();

                        if (Regex.IsMatch(gebruikersnaam, "^[A-Za-z]+$", RegexOptions.IgnoreCase) && (char.IsUpper(gebruikersnaam[0])))
                        {
                            check1 = true;
                        }

                    } while (!check1);
                }
                catch
                {
                    Console.WriteLine("Voer een geldige gebruikersnaam in / bevat alleen letters en de eerste letter moet hoofdletter zijn ");
                }

                Console.WriteLine("Voer een wachtwoord in: ");
                wachtwoord = Console.ReadLine();

                // Emeil controleren
                try
                {
                     checkE = false;
                    do
                    {
                        Console.WriteLine("Voer een geldig E-mail in: ");
                         email_variabele = Console.ReadLine();



                        if (Regex.Replace(email_variabele, "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", string.Empty).Length == 0)
                        {
                            checkE = true;
                        }


                    } while (!checkE);
                }
                catch
                {
                    Console.WriteLine("Voer een geldig E-mail in: ");
                }


                for (int i = 0; i < gebruikerIdJson.Gebruiksnaam.Count; i++)
                {
                    if (gebruikersnaam == gebruikerIdJson.Gebruiksnaam[i] || wachtwoord == gebruikerIdJson.Wachtwoord[i] || email_variabele == gebruikerIdJson.Email[i] || gebruikersnaam == "" || wachtwoord == "" || email_variabele == "")
                    {
                        check = true;
                      
                    }
                    
                }
                if (check = true)
                {
                    Console.WriteLine("Dit account bestaat al");
                }
                if (check == false)
                {
                    break;
                }
                if (checkE == true)
                {
                    break;
                }
                if (check1 == true)
                {
                    break;
                }



            }

            while (gebruikerIdJson == null)
            {
                bool check = false;
                bool check2 = false;
                bool checkE2 = false;
                // gebruikersnaam controleren
                try
                {
                    check2 = false;
                    do
                    {
                        Console.WriteLine("Voer een geldige gebruikersnaam in / bevat alleen letters en de eerste letter moet hoofdletter zijn ");
                         gebruikersnaam = Console.ReadLine();



                        if (Regex.IsMatch(gebruikersnaam, "^[A-Za-z]+$", RegexOptions.IgnoreCase) && (char.IsUpper(gebruikersnaam[0])))
                        {
                            check2 = true;
                        }


                    } while (!check2);
                }
                catch
                {
                    Console.WriteLine("Voer een geldige gebruikersnaam in / bevat alleen letters en de eerste letter moet hoofdletter zijn ");
                }
                
                
                Console.WriteLine("Voer een wachtwoord in: ");
                wachtwoord = Console.ReadLine();

                // Emeil controleren
                try
                {
                    checkE2 = false;
                    do
                    {
                        Console.WriteLine("Voer een geldig E-mail in: ");
                        string d = Console.ReadLine();



                        if (Regex.Replace(email_variabele, "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", string.Empty).Length == 0)
                        {
                            checkE2 = true;
                        }


                    } while (!checkE2);
                }
                catch
                {
                    Console.WriteLine("Voer een geldig E-mail in: ");
                }
   
              
                  

                if (gebruikersnaam == "" || wachtwoord == "" || email_variabele == "")
                {
                    check = true;
                    Console.WriteLine("Vul de velden in");
                }
                if (check == false)
                {
                    break;
                }
                if (checkE2 == true)
                {
                    break;
                }
                if (check2 == true)
                {
                    break;
                }
            }

            gebruiker.Email = new List<string> { email_variabele };
            gebruiker.Gebruiksnaam = new List<string> { gebruikersnaam };
            gebruiker.id = new List<int> { new Random().Next(1000, 9999) };
            gebruiker.Wachtwoord = new List<string> { wachtwoord };

            JsonClassLogin writeResultJson = new JsonClassLogin();

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

