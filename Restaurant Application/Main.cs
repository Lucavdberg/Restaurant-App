using System;
using Newtonsoft.Json;
using System.IO;

namespace oefenen1
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonClassLogin gebruikerJson = new JsonClassLogin();
            Customerlogin loginClass = new Customerlogin();
            email emailClass = new email();
            JsonClassGerechtenIngevuld gerechtenIngevuldClass = new JsonClassGerechtenIngevuld();
            JsonClassReservering reserveringJson = new JsonClassReservering();
            Reservering ReserveringClass = new Reservering();
            Tafel tafelClass = new Tafel();
            JsonClassTafels tafelJson = new JsonClassTafels();
            ReserveringAnnuleren reserveringAnnulerenClass = new ReserveringAnnuleren();
            Restaurant restaurantClass = new Restaurant();
            Admin adminClass = new Admin();
            Review reviewClass = new Review();
            gerechten gerechtenClass = new gerechten();
            Menu menuVanEenDagClass = new Menu();
            AutoDeleteReservering autoDeleteReserveringClass = new AutoDeleteReservering();
            inloggegevensWijzigen inloggegevensWijzigenClass = new inloggegevensWijzigen();

            while (true) 
            {
                Console.Clear();
                Console.WriteLine("\n");
                restaurantClass.restaurantFunc();
                Console.WriteLine(" [1]. Menu bekijken\n [2]. Gerecht opzoeken\n [3]. Inloggen of account aanmaken\n [4]. Beheerder Login\n [5]. Review plaatsen\n");
                autoDeleteReserveringClass.AutoDeleteReserveringFunc();
                Console.Write(" Uw keuze: ");
                var menu_of_reservering = Console.ReadLine();
                if (menu_of_reservering == "1")
                {
                    Console.Clear();
                    Console.WriteLine("\n\n - Bij GROUP1 hebben wij elke dag van de week een verschillend menu.");
                    Console.WriteLine(" - U kunt een menu bekijken door de dag in te typen.");
                    string day = "";
                    do
                    {
                        Console.Write("\n Van welke dag wilt u het menu bekijken: ");
                        day = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("\n - Het menu van de gekozen dag! Wat heerlijk allemaal hé!");
                        Console.WriteLine("\n");
                    }
                    while (day != "maandag" && day != "Maandag" && day != "dinsdag" && day != "Dinsdag" && day != "woensdag" && day != "Woensdag" && day != "donderdag" && day != "Donderdag" && day != "vrijdag" && day != "Vrijdag" && day != "zaterdag" && day != "Zaterdag" && day != "zondag" && day != "Zondag");
                    menuVanEenDagClass.MenuVanDeDagFunc(day, gerechtenIngevuldClass.gerechtenIngevuldFunc());
                }
                else if (menu_of_reservering == "4")
                {
                    adminClass.adminFunc(gerechtenIngevuldClass.gerechtenIngevuldFunc());
                }
                else if (menu_of_reservering == "2")
                {
                    Console.Clear();
                    Console.WriteLine("\n\n - Bij GROUP1 hebben wij elke dag van de week een verschillend menu en dus ook verschillende gerechten.");
                    Console.WriteLine(" - U kunt op gerechten zoeken, dan kunt u zien op welke dag wij dit gerecht in ons menu hebben staan.");
                    var gerecht = "";
                    do
                    {
                        Console.WriteLine("\n Gerecht zoeken.. (LET OP: GERECHTEN MOETEN OP DE JUISTE MANIER GESPELD WORDEN: carpaccio(fout) ==> Carpaccio(goed)) ");
                        Console.Write("\n Welk gerecht wilt u zoeken: ");
                        gerecht = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("\n - Dit zijn de dagen waarop uw gerecht in ons menu staat!");
                        Console.WriteLine("\n");
                    } while (gerecht == "");
                    
                    gerechtenClass.gerechtenFunc(gerecht, gerechtenIngevuldClass.gerechtenIngevuldFunc());
                }
                else if (menu_of_reservering == "3")
                {
                    Console.WriteLine("\n - Inloggen of een account aanmaken.\n");
                    Tuple<int, int> login = loginClass.LoginFunc(gebruikerJson);
                    if (login.Item1 == 3)
                    {
                        Console.WriteLine(" Klik op een toets om terug te keren naar het hoofdmenu");
                        Console.ReadKey();
                    }
                    if (login.Item1 == 0)
                    {
                        Console.WriteLine("\n - Uw account is aangemaakt!");
                        Console.WriteLine(" -  Klik op een toets om terug te keren en in te loggen!");
                        Console.ReadKey();
                    }
                    if (login.Item1 == 1)
                    {
                        emailClass.emailFunc();
                    }
                    if (login.Item1 == 2)
                    {
                        string curFile = @"reservering_id.json";
                        var exist = File.Exists(curFile) ? true : false;

                        if (exist == false)
                        {
                            string existance = JsonConvert.SerializeObject(null);
                            File.WriteAllText(@"reservering_id.json", existance);
                        }

                        string bufferTwo = File.ReadAllText(@"gebruiker_id.json");
                        JsonClassLogin gebruikerIdJson = JsonConvert.DeserializeObject<JsonClassLogin>(bufferTwo);
                        while (true)
                        {
                            string buffer = File.ReadAllText(@"reservering_id.json");
                            JsonClassReservering reserveringIdJson = JsonConvert.DeserializeObject<JsonClassReservering>(buffer);

                            Console.Clear();
                            Console.WriteLine("\n\n - U bent nu ingelogd!");
                            Console.WriteLine("\n [1]. Uw reserveringen bekijken\n [2]. Nieuwe reservering maken\n [3]. Bestaande reservering annuleren\n [4]. Inloggegevens bekijken/wijzigen\n [5]. Uitloggen\n");
                            Console.Write(" Uw keuze: ");
                            var Ingelogd = Console.ReadLine();
                            if (Ingelogd == "1")
                            {
                                if (reserveringIdJson != null)
                                {
                                    int count = 0;
                                    Console.Clear();
                                    Console.WriteLine("\n - Dit zijn al uw reserveringen\n");
                                    for (int i = 0; i < reserveringIdJson.id.Count; i++)
                                    {
                                        if (reserveringIdJson.id[i] == gebruikerIdJson.id[login.Item2])
                                        {
                                            Console.WriteLine(" Reservering nummer: " + (count + 1));
                                            Console.WriteLine(" - - - - - - - - - - - - - - - - - - -");
                                            Console.WriteLine(" Datum:          " + reserveringIdJson.Datum[i] + "\n" + " Tijdstip:          " + reserveringIdJson.Tijden[i] + "\n" + " Personen:          " + reserveringIdJson.Personen[i] + "\n" + " Details:          " + reserveringIdJson.Details[i] + "\n");
                                            count++;
                                        }
                                    }
                                    Console.WriteLine("\n Klik op een toets om terug te keren naar de customer scherm");
                                    Console.ReadKey();
                                }
                                if (reserveringIdJson == null)
                                {
                                    Console.WriteLine(" U heeft nog geen reservering aangemaakt");
                                    Console.WriteLine("\n Klik op een toets om terug te keren naar de customer scherm");
                                    Console.ReadKey();
                                }  
                            }
                            else if (Ingelogd == "2")
                            {
                                if (reserveringIdJson != null)
                                {
                                    int count = 0;
                                    for (int i = 0; i < reserveringIdJson.id.Count; i++)
                                    {
                                        if (reserveringIdJson.id[i] == gebruikerIdJson.id[login.Item2])
                                        {
                                            count++;
                                        }
                                    }
                                    if (count < 3)
                                    {
                                        Console.Clear();
                                        ReserveringClass.reserveringFunc(reserveringJson, tafelClass.tafelFunc(), login.Item2);
                                    }
                                    if (count >= 3)
                                    {
                                        Console.WriteLine(" U kunt geen reservering meer aanmaken omdat u de limiet van 3 reserveringen heeft bereikt \n Annuleer een bestaande reservering voor het aanmaken van een nieuwe reservering");
                                        Console.WriteLine(" Klik op een toets om terug te keren naar de customer scherm");
                                        Console.ReadKey();
                                    }
                                }
                                if (reserveringIdJson == null)
                                {
                                    Console.Clear();
                                    ReserveringClass.reserveringFunc(reserveringJson, tafelClass.tafelFunc(), login.Item2);
                                }
                            }
                            else if (Ingelogd == "3")
                            {
                                if (reserveringIdJson != null)
                                {
                                    reserveringAnnulerenClass.ReserveringAnnulerenFunc(login.Item2);
                                }
                                if (reserveringIdJson == null)
                                {
                                    Console.WriteLine(" SU heeft nog geen reservering aangemaakt");
                                    Console.WriteLine(" Klik op een toets om terug te keren naar de customer scherm");
                                    Console.ReadKey();
                                }  
                            }
                            else if (Ingelogd == "4")
                            {
                                inloggegevensWijzigenClass.inloggegevensWijzigenFunc(login.Item2);
                            }
                            else if (Ingelogd == "5")
                            {
                                Console.WriteLine(" U bent uitgelogd!");
                                Console.WriteLine(" Druk op een toets om terug te keren naar het hoofdmenu");
                                Console.ReadKey();
                                break;
                            }
                        }
                    }
                }
                else if (menu_of_reservering == "5")
                {
                    reviewClass.ReviewFunc();
                }
            }
        }
    }
}
