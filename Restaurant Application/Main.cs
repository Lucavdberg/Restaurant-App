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

            while (true) 
            {
                Console.WriteLine("\n");
                restaurantClass.restaurantFunc();
                Console.WriteLine("U kunt via deze applicatie een reservering plaatsen en het menu bekijken");
                Console.WriteLine(" [1]. Menu bekijken\n [2]. Gerecht opzoeken\n [3]. Reservering maken\n [4]. Review plaatsen");
                var menu_of_reservering = Console.ReadLine();
                if (menu_of_reservering == "1")
                {
                    Console.WriteLine("Van welke dag wilt u het menu bekijken");
                    var day = Console.ReadLine();
                    Menu menuVanEenDagClass = new Menu();
                    menuVanEenDagClass.MenuVanDeDagFunc(day, gerechtenIngevuldClass.gerechtenIngevuldFunc());
                }
                else if (menu_of_reservering == "2")
                {
                    Console.WriteLine("welke gerecht wil je ?");
                    var gerecht = Console.ReadLine();
                    gerechten gerechtenClass = new gerechten();
                    gerechtenClass.gerechtenFunc(gerecht, gerechtenIngevuldClass.gerechtenIngevuldFunc());
                }
                else if (menu_of_reservering == "3")
                {
                    Console.WriteLine("om een reservering te plaatsen moet u eerst inloggen of een account aanmaken");
                    Tuple<int, int> login = loginClass.LoginFunc(gebruikerJson);
                    if (login.Item1 == 3)
                    {
                        Console.WriteLine("klik op een toets om terug te keren naar het hoofdmenu");
                        Console.ReadKey();
                    }
                    if (login.Item1 == 0)
                    {
                        Console.WriteLine("u kunt nu terug keren naar het hoofdscherm om in te loggen \nklik op een toets om terug te keren naar het hoofdmenu");
                        Console.ReadKey();
                    }
                    if (login.Item1 == 1)
                    {
                        emailClass.emailFunc();
                    }
                    if (login.Item1 == 2)
                    {
                        string curFile = @"C:\Users\F\source\repos\Restaurant-App\Restaurant Application\bin\Debug\netcoreapp3.1\reservering_id.json";
                        Console.WriteLine(File.Exists(curFile) ? "File exists." : "File does not exist.");
                        var exist = File.Exists(curFile) ? true : false;

                        if (exist == false)
                        {
                            string lol = JsonConvert.SerializeObject(null);
                            File.WriteAllText(@"reservering_id.json", lol);
                        }

                        string buffer = File.ReadAllText(@"reservering_id.json");
                        JsonClassReservering reserveringIdJson = JsonConvert.DeserializeObject<JsonClassReservering>(buffer);

                        string bufferTwo = File.ReadAllText(@"gebruiker_id.json");
                        JsonClassLogin gebruikerIdJson = JsonConvert.DeserializeObject<JsonClassLogin>(bufferTwo);

                        Console.WriteLine("Wilt u bestaande reserveringen bekijken type(1), wilt u een nieuwe reservering aanmaken type(2) of wilt u een bestaande reservering annuleren type(3)");
                        var Ingelogd = Console.ReadLine();
                        if (Ingelogd == "1")
                        {
                            if (reserveringIdJson != null)
                            {
                                Console.WriteLine("Dit zijn al uw reserveringen");
                                for (int i = 0; i < reserveringIdJson.id.Count; i++)
                                {
                                    if (reserveringIdJson.id[i] == gebruikerIdJson.id[login.Item2])
                                    {
                                        Console.WriteLine(reserveringIdJson.Datum[i] + "\n" + reserveringIdJson.Tijden[i] + "\n" + reserveringIdJson.Personen[i] + "\n" + reserveringIdJson.Details[i] + "\n");
                                    }
                                }
                                Console.WriteLine("klik op een toets om terug te keren naar het hoofdmenu");
                                Console.ReadKey();
                            }
                            if (reserveringIdJson == null)
                            {
                                Console.WriteLine("U heeft nog geen reservering aangemaakt");
                                Console.WriteLine("klik op een toets om terug te keren naar het hoofdmenu");
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
                                    Console.WriteLine("u kunt nu een reservering plaatsen");
                                    ReserveringClass.reserveringFunc(tafelClass.tafelFunc(), login.Item2);
                                }
                                if (count >= 3)
                                {
                                    Console.WriteLine("u kunt geen reservering meer aanmaken omdat u de limiet van 3 reserveringen heeft bereikt \nannuleer een bestaande reservering voor het aanmaken van een nieuwe reservering");
                                    Console.WriteLine("klik op een toets om terug te keren naar het hoofdmenu");
                                    Console.ReadKey();
                                }
                            }
                            if (reserveringIdJson == null)
                            {
                                Console.WriteLine("u kunt nu een reservering plaatsen");
                                ReserveringClass.reserveringFunc(tafelClass.tafelFunc(), login.Item2);
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
                                Console.WriteLine("U heeft nog geen reservering aangemaakt");
                                Console.WriteLine("klik op een toets om terug te keren naar het hoofdmenu");
                                Console.ReadKey();
                            }  
                        }     
                    }
                }
                else if (menu_of_reservering == "4")
                {
                    Review reviewClass = new Review();
                    reviewClass.ReviewFunc();
                    Console.WriteLine("Druk op een toets om terug te keren naar het hoofdmenu");
                    Console.ReadKey();
                }
            }
        }
    }
}