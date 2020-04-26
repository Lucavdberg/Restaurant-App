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

            while (true) 
            {
                Console.WriteLine("Welkom bij ons restaurant");
                Console.WriteLine("U kunt via deze applicatie een reservering plaatsen en het menu bekijken");
                Console.WriteLine("Wilt u een menu bekijken type(1), wilt u een gerecht opzoeken type(2), wilt u een reservering maken type(3)");
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
                    int loginFail = loginClass.LoginFunc(gebruikerJson);
                    if (loginFail == 0)
                    {
                        Console.WriteLine("u kunt nu een reservering plaatsen");
                        ReserveringClass.reserveringFunc(reserveringJson, tafelClass.tafelFunc());
                    }
                    if (loginFail == 1)
                    {
                        emailClass.emailFunc(gebruikerJson);
                    }
                    if (loginFail == 2)
                    {
                        Console.WriteLine("Wilt u een bestaande reservering bekijken type(1) of wilt u een nieuwe reservering aanmaken type(2)");
                        var Ingelogd = Console.ReadLine();
                        if (Ingelogd == "1") 
                        {
                            JsonClassReservering ingelogdModus = JsonConvert.DeserializeObject<JsonClassReservering>(File.ReadAllText(@"reservering_id.json"));
                            using (StreamReader file = File.OpenText(@"reservering_id.json"))
                            {
                                JsonSerializer serializer = new JsonSerializer();
                                JsonClassReservering leesReservering = (JsonClassReservering)serializer.Deserialize(file, typeof(JsonClassReservering));
                                Console.WriteLine(leesReservering.Datum + "\n" + leesReservering.Tijden + "\n" + leesReservering.Personen + "\n" + leesReservering.Details);
                            }
                        }
                        else if (Ingelogd == "2")
                        {
                            Console.WriteLine("u kunt nu een reservering plaatsen");
                            ReserveringClass.reserveringFunc(reserveringJson, tafelClass.tafelFunc());
                        }
                    }
                }
            }
        }
    }
}