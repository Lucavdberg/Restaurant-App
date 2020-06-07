﻿using System;
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

            while (true) 
            {
                Console.Clear();
                Console.WriteLine("\n");
                restaurantClass.restaurantFunc();
                Console.WriteLine("U kunt via deze applicatie een reservering plaatsen en het menu bekijken");
                Console.WriteLine(" [1]. Menu bekijken\n [2]. Gerecht opzoeken\n [3]. Reservering maken\n [4]. Beheerder Login\n [5]. Review plaatsen\n");
                var menu_of_reservering = Console.ReadLine();
                if (menu_of_reservering == "1")
                {
                    Console.WriteLine("Van welke dag wilt u het menu bekijken");
                    string day = "";
                    do
                    {
                        Console.WriteLine("type een dag van de week");
                        day = Console.ReadLine();
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
                    Console.WriteLine("Van welk gerecht wilt u weten op welke dag deze beschikbaar is?");
                    var gerecht = Console.ReadLine();
                    Console.WriteLine("---------------------------------------");
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
                        string curFile = @"reservering_id.json";
                        var exist = File.Exists(curFile) ? true : false;

                        if (exist == false)
                        {
                            string existance = JsonConvert.SerializeObject(null);
                            File.WriteAllText(@"reservering_id.json", existance);
                        }

                        string buffer = File.ReadAllText(@"reservering_id.json");
                        JsonClassReservering reserveringIdJson = JsonConvert.DeserializeObject<JsonClassReservering>(buffer);

                        string bufferTwo = File.ReadAllText(@"gebruiker_id.json");
                        JsonClassLogin gebruikerIdJson = JsonConvert.DeserializeObject<JsonClassLogin>(bufferTwo);
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("Wilt u bestaande reserveringen bekijken type(1), wilt u een nieuwe reservering aanmaken type(2) of wilt u een bestaande reservering annuleren type(3), Wilt u uitlogen type(4)");
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
                                            Console.WriteLine("Datum: " + reserveringIdJson.Datum[i] + "\n" + "Tijdstip: " + reserveringIdJson.Tijden[i] + "\n" + "Personen: " + reserveringIdJson.Personen[i] + "\n" + "Details: " + reserveringIdJson.Details[i] + "\n");
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
                                        ReserveringClass.reserveringFunc(reserveringJson, tafelClass.tafelFunc(), login.Item2);
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
                                    Console.WriteLine("U heeft nog geen reservering aangemaakt");
                                    Console.WriteLine("klik op een toets om terug te keren naar het hoofdmenu");
                                    Console.ReadKey();
                                }  
                            }
                            else if (Ingelogd == "4")
                            {
                                Console.WriteLine("U bent uitgelogd!");
                                Console.WriteLine("Druk op een toets om terug te keren naar het hoofdmenu");
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
