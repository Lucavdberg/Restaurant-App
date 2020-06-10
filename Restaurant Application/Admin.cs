using System;
using Newtonsoft.Json;
using System.IO;
using System.ComponentModel.DataAnnotations.Schema;

public class Admin
{
    public void AdminReserveringenBekijken()
    {
        string bufferTwo = File.ReadAllText(@"reservering_id.json");
        JsonClassReservering reserveringIdJson = JsonConvert.DeserializeObject<JsonClassReservering>(bufferTwo);
        Console.Clear();
        if (reserveringIdJson != null)
        {
            Console.WriteLine("Alle reserveringen die zijn geplaatst:\n");
            for (int i = 0; i < reserveringIdJson.Datum.Count; i++)
            {
                //laat alle reserveringen zien in de json file
                Console.WriteLine("Klanten ID: " + reserveringIdJson.id[i]);
                Console.WriteLine("- - - - - - - - - - - - - - - - - - -");
                Console.WriteLine("Reservering datum:              " + reserveringIdJson.Datum[i]);
                Console.WriteLine("Reservering tijdstip:           " + reserveringIdJson.Tijden[i]);
                Console.WriteLine("Aantal personen aanwezig:       " + reserveringIdJson.Personen[i]);
                Console.WriteLine("Opmerkingen bij de reservering: " + reserveringIdJson.Details[i] + "\n");
            }
        }
        if (reserveringIdJson == null)
        {
            Console.WriteLine("Het restaurant heeft nog geen reviews");
        }

        Console.WriteLine("Klik op een toets om terug te keren naar de adminscherm");
        Console.ReadKey();
    }
    public void AdminReviewsBekijken()
    {
        //kijkt of de json file bestaat in dezelfde directory als het project
        string curFile = @"reviews.json";
        var exist = File.Exists(curFile) ? true : false;

        //de json file bestaat niet in het project folder en wordt aangemaakt en gevuld met null
        if (exist == false)
        {
            string existance = JsonConvert.SerializeObject(null);
            File.WriteAllText(@"reviews.json", existance);
        }

        string bufferTwo = File.ReadAllText(@"reviews.json");
        JsonClassReview reviewJson = JsonConvert.DeserializeObject<JsonClassReview>(bufferTwo);
        Console.Clear();
        if (reviewJson != null)
        {
            Console.WriteLine("Alle reviews die zijn geplaatst:\n");
            for (int i = 0; i < reviewJson.Score.Count; i++)
            {
                Console.WriteLine("Reviewer:                       " + reviewJson.Naam[i]);
                Console.WriteLine("gerecht:                        " + reviewJson.Gerecht[i]);
                Console.WriteLine("De review:                      " + reviewJson.Review[i]);
                Console.WriteLine("De score:                       " + reviewJson.Score[i] + "\n");
            }
        }
        if (reviewJson == null)
        {
            Console.WriteLine("Het restaurant heeft nog geen reviews");
        }

        Console.WriteLine("Klik op een toets om terug te keren naar de adminscherm");
        Console.ReadKey();
    }
    public void AdminGegevensBekijken()
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

        string bufferTwo = File.ReadAllText(@"gebruiker_id.json");
        JsonClassLogin gebruikerJson = JsonConvert.DeserializeObject<JsonClassLogin>(bufferTwo);
        Console.Clear();
        if (gebruikerJson != null)
        {
            Console.WriteLine("Alle gegevens van gebruikers:\n");
            for (int i = 0; i < gebruikerJson.Gebruiksnaam.Count; i++)
            {
                Console.WriteLine("Klanten ID: " + gebruikerJson.id[i]);
                Console.WriteLine("- - - - - - - - - - - - - - - - - - -");
                Console.WriteLine("Gebruikersnaam:                 " + gebruikerJson.Gebruiksnaam[i]);
                Console.WriteLine("Wachtwoord:                     " + "*******");
                Console.WriteLine("E-mail:                         " + gebruikerJson.Email[i] + "\n");
            }
        }
        if (gebruikerJson == null)
        {
            Console.WriteLine("Het restaurant heeft nog geen gebruikers");
        }
        Console.WriteLine(" Klik op een toets om terug te keren naar de adminscherm");
        Console.ReadKey();
    }
    public void adminFunc(JsonClassGerechten newgerechten)
    {
        Console.Clear();
        //kijkt of de json file bestaat in dezelfde directory als het project
        string curFile = @"gerechten.json";
        var exist = File.Exists(curFile) ? true : false;

        //de json file bestaat niet in het project folder en wordt aangemaakt en gevuld met null
        if (exist == false)
        {
            string existance = JsonConvert.SerializeObject(null);
            File.WriteAllText(@"gerechten.json", existance);
        }
        string buffer = File.ReadAllText(@"gerechten.json");
        JsonClassGerechten AdminGerechtenJson = JsonConvert.DeserializeObject<JsonClassGerechten>(buffer);
        JsonClassGerechten gerechtenJson = new JsonClassGerechten();
        Console.WriteLine("\n - Als Admin inloggen... Vul uw gegevens in.\n");
        Console.Write(" Admin gebruikersnaam: ");
        var naam = Console.ReadLine();
        Console.Write(" Admin wachtwoord: ");
        var ww = Customerlogin.ReadPassword();
        int count01 = 0;
        while (naam != "Admin" || ww != "Admin123")
        {
            count01++;
            if (count01 > 2)
            {
                break;
            }
            Console.WriteLine("De inloggevens zijn onjuist");
            Console.WriteLine("Wat is uw admin gebruiksernaam?");
            naam = Console.ReadLine();
            Console.WriteLine("Wat is uw admin wachtwoord?");
            ww = Customerlogin.ReadPassword();
        }
        while (naam == "Admin" && ww == "Admin123")
        {
            Console.Clear();
            Console.WriteLine("\n ... Logged in as Admin!\n");
            Console.WriteLine(" Welkom Administrator! Wat wilt u doen\n");
            if (AdminGerechtenJson == null)
            {
                gerechtenJson.maandag = newgerechten.maandag;
                gerechtenJson.dinsdag = newgerechten.dinsdag;
                gerechtenJson.woensdag = newgerechten.woensdag;
                gerechtenJson.donderdag = newgerechten.donderdag;
                gerechtenJson.vrijdag = newgerechten.vrijdag;
                gerechtenJson.zaterdag = newgerechten.zaterdag;
                gerechtenJson.zondag = newgerechten.zondag;
                string nieuw2 = JsonConvert.SerializeObject(gerechtenJson);
                File.WriteAllText(@"gerechten.json", nieuw2);
                Console.WriteLine(" Het menu is nu automatisch aangemaakt omdat deze er nog niet was.\n");
            }
            Console.WriteLine(" [1]. Menu aanpassen\n [2]. Alle gegevens van gebruikers bekijken\n [3]. Alle reviews bekijken\n [4]. Alle reserveringen bekijken\n [5]. Review verwijderen\n [6]. Reservering verwijderen\n [7]. Uitloggen\n");
            Console.Write(" Uw keuze: ");
            string keuze = Console.ReadLine();
            if (keuze == "1")
            {
                string buffer2 = File.ReadAllText(@"gerechten.json");
                JsonClassGerechten AGJ = JsonConvert.DeserializeObject<JsonClassGerechten>(buffer2);
                Console.WriteLine("Van welke dag wilt u iets veranderen in het menu?");
                string dag = "";
                string jaOfNee = "";
                do
                {
                    Console.WriteLine("type een dag van de week");
                    dag = Console.ReadLine();
                    Console.WriteLine("\n Weet u zeker dat u deze dag wilt kiezen");
                    Console.WriteLine(" [1]. Ja\n [2]. Nee\n");
                    do
                    {
                        jaOfNee = Console.ReadLine();
                        if (jaOfNee != "1" && jaOfNee != "2")
                        {
                            Console.WriteLine(" [1]. Ja\n [2]. Nee\n");
                        }
                    }
                    while (jaOfNee != "1" && jaOfNee != "2");
                }
                while (dag != "maandag" && dag != "Maandag" && dag != "dinsdag" && dag != "Dinsdag" && dag != "woensdag" && dag != "Woensdag" && dag != "donderdag" && dag != "Donderdag" && dag != "vrijdag" && dag != "Vrijdag" && dag != "zaterdag" && dag != "Zaterdag" && dag != "zondag" && dag != "Zondag");
                if (jaOfNee == "2")
                {
                    Console.WriteLine("klik op een toets om terug te keren naar de admin scherm");
                    Console.ReadKey();
                }
                if (jaOfNee == "1")
                {
                    if (dag == "maandag" || dag == "Maandag")
                    {
                        gerechtenJson.maandag = new string[11][];
                        for (int i = 0; i < 11; i++)
                        {
                            Console.WriteLine("Naam gerecht:");
                            string naamgerecht = Console.ReadLine();
                            var result1 = naamgerecht == "" ? "NoName" : naamgerecht;
                            Console.WriteLine("Beschrijving gerecht:");
                            var beschrijvinggerecht = Console.ReadLine();
                            var result2 = beschrijvinggerecht == "" ? "Een lekker gerecht" : beschrijvinggerecht;
                            Console.WriteLine("Allergenen gerecht:");
                            var allergenengerecht = Console.ReadLine();
                            var result3 = allergenengerecht == "" ? " " : allergenengerecht;
                            Console.WriteLine("Prijs gerecht:");
                            var prijsgerecht = Console.ReadLine();
                            var result4 = prijsgerecht == "" ? "10,00 Euro" : prijsgerecht;
                            gerechtenJson.maandag[i] = new string[] { result1, result2, result3, result4 };
                            gerechtenJson.dinsdag = AGJ.dinsdag;
                            gerechtenJson.woensdag = AGJ.woensdag;
                            gerechtenJson.donderdag = AGJ.donderdag;
                            gerechtenJson.vrijdag = AGJ.vrijdag;
                            gerechtenJson.zaterdag = AGJ.zaterdag;
                            gerechtenJson.zondag = AGJ.zondag;
                        }
                    }
                    if (dag == "dinsdag" || dag == "Dinsdag")
                    {
                        gerechtenJson.dinsdag = new string[11][];
                        for (int i = 0; i < 11; i++)
                        {
                            Console.WriteLine("Naam gerecht:");
                            string naamgerecht = Console.ReadLine();
                            var result1 = naamgerecht == "" ? "NoName" : naamgerecht;
                            Console.WriteLine("Beschrijving gerecht:");
                            var beschrijvinggerecht = Console.ReadLine();
                            var result2 = beschrijvinggerecht == "" ? "Een lekker gerecht" : beschrijvinggerecht;
                            Console.WriteLine("Allergenen gerecht:");
                            var allergenengerecht = Console.ReadLine();
                            var result3 = allergenengerecht == "" ? " " : allergenengerecht;
                            Console.WriteLine("Prijs gerecht:");
                            var prijsgerecht = Console.ReadLine();
                            var result4 = prijsgerecht == "" ? "10,00 Euro" : prijsgerecht;
                            gerechtenJson.dinsdag[i] = new string[] { result1, result2, result3, result4 };
                        }
                    }
                    if (dag == "woensdag" || dag == "Woensdag")
                    {
                        gerechtenJson.woensdag = new string[11][];
                        for (int i = 0; i < 11; i++)
                        {
                            Console.WriteLine("Naam gerecht:");
                            string naamgerecht = Console.ReadLine();
                            var result1 = naamgerecht == "" ? "NoName" : naamgerecht;
                            Console.WriteLine("Beschrijving gerecht:");
                            var beschrijvinggerecht = Console.ReadLine();
                            var result2 = beschrijvinggerecht == "" ? "Een lekker gerecht" : beschrijvinggerecht;
                            Console.WriteLine("Allergenen gerecht:");
                            var allergenengerecht = Console.ReadLine();
                            var result3 = allergenengerecht == "" ? " " : allergenengerecht;
                            Console.WriteLine("Prijs gerecht:");
                            var prijsgerecht = Console.ReadLine();
                            var result4 = prijsgerecht == "" ? "10,00 Euro" : prijsgerecht;

                            gerechtenJson.woensdag[i] = new string[] { result1, result2, result3, result4 };
                        }
                    }
                    if (dag == "donderdag" || dag == "Donderdag")
                    {
                        gerechtenJson.donderdag = new string[11][];
                        for (int i = 0; i < 11; i++)
                        {
                            Console.WriteLine("Naam gerecht:");
                            string naamgerecht = Console.ReadLine();
                            var result1 = naamgerecht == "" ? "NoName" : naamgerecht;
                            Console.WriteLine("Beschrijving gerecht:");
                            var beschrijvinggerecht = Console.ReadLine();
                            var result2 = beschrijvinggerecht == "" ? "Een lekker gerecht" : beschrijvinggerecht;
                            Console.WriteLine("Allergenen gerecht:");
                            var allergenengerecht = Console.ReadLine();
                            var result3 = allergenengerecht == "" ? " " : allergenengerecht;
                            Console.WriteLine("Prijs gerecht:");
                            var prijsgerecht = Console.ReadLine();
                            var result4 = prijsgerecht == "" ? "10,00 Euro" : prijsgerecht;
                            gerechtenJson.donderdag[i] = new string[] { result1, result2, result3, result4 };
                        }
                    }
                    if (dag == "vrijdag" || dag == "Vrijdag")
                    {
                        gerechtenJson.vrijdag = new string[11][];
                        for (int i = 0; i < 11; i++)
                        {
                            Console.WriteLine("Naam gerecht:");
                            string naamgerecht = Console.ReadLine();
                            var result1 = naamgerecht == "" ? "NoName" : naamgerecht;
                            Console.WriteLine("Beschrijving gerecht:");
                            var beschrijvinggerecht = Console.ReadLine();
                            var result2 = beschrijvinggerecht == "" ? "Een lekker gerecht" : beschrijvinggerecht;
                            Console.WriteLine("Allergenen gerecht:");
                            var allergenengerecht = Console.ReadLine();
                            var result3 = allergenengerecht == "" ? " " : allergenengerecht;
                            Console.WriteLine("Prijs gerecht:");
                            var prijsgerecht = Console.ReadLine();
                            var result4 = prijsgerecht == "" ? "10,00 Euro" : prijsgerecht;
                            gerechtenJson.vrijdag[i] = new string[] { result1, result2, result3, result4 };
                        }
                    }
                    if (dag == "zaterdag" || dag == "Zaterdag")
                    {
                        gerechtenJson.zaterdag = new string[11][];
                        for (int i = 0; i < 11; i++)
                        {
                            Console.WriteLine("Naam gerecht:");
                            string naamgerecht = Console.ReadLine();
                            var result1 = naamgerecht == "" ? "NoName" : naamgerecht;
                            Console.WriteLine("Beschrijving gerecht:");
                            var beschrijvinggerecht = Console.ReadLine();
                            var result2 = beschrijvinggerecht == "" ? "Een lekker gerecht" : beschrijvinggerecht;
                            Console.WriteLine("Allergenen gerecht:");
                            var allergenengerecht = Console.ReadLine();
                            var result3 = allergenengerecht == "" ? " " : allergenengerecht;
                            Console.WriteLine("Prijs gerecht:");
                            var prijsgerecht = Console.ReadLine();
                            var result4 = prijsgerecht == "" ? "10,00 Euro" : prijsgerecht;
                            gerechtenJson.zaterdag[i] = new string[] { result1, result2, result3, result4 };
                        }
                    }
                    if (dag == "zondag" || dag == "Zondag")
                    {
                        gerechtenJson.zondag = new string[11][];
                        for (int i = 0; i < 11; i++)
                        {
                            Console.WriteLine("Naam gerecht:");
                            string naamgerecht = Console.ReadLine();
                            var result1 = naamgerecht == "" ? "NoName" : naamgerecht;
                            Console.WriteLine("Beschrijving gerecht:");
                            var beschrijvinggerecht = Console.ReadLine();
                            var result2 = beschrijvinggerecht == "" ? "Een lekker gerecht" : beschrijvinggerecht;
                            Console.WriteLine("Allergenen gerecht:");
                            var allergenengerecht = Console.ReadLine();
                            var result3 = allergenengerecht == "" ? " " : allergenengerecht;
                            Console.WriteLine("Prijs gerecht:");
                            var prijsgerecht = Console.ReadLine();
                            var result4 = prijsgerecht == "" ? "10,00 Euro" : prijsgerecht;
                            gerechtenJson.zondag[i] = new string[] { result1, result2, result3, result4 };
                        }
                    }
                    if (dag == "alles" || dag == "Alles")
                    {
                        gerechtenJson.maandag = new string[11][];
                        for (int i = 0; i < 11; i++)
                        {
                            Console.WriteLine("Naam gerecht:");
                            string naamgerecht = Console.ReadLine();
                            var result1 = naamgerecht == "" ? "NoName" : naamgerecht;
                            Console.WriteLine("Beschrijving gerecht:");
                            var beschrijvinggerecht = Console.ReadLine();
                            var result2 = beschrijvinggerecht == "" ? "Een lekker gerecht" : beschrijvinggerecht;
                            Console.WriteLine("Allergenen gerecht:");
                            var allergenengerecht = Console.ReadLine();
                            var result3 = allergenengerecht == "" ? " " : allergenengerecht;
                            Console.WriteLine("Prijs gerecht:");
                            var prijsgerecht = Console.ReadLine();
                            var result4 = prijsgerecht == "" ? "10,00 Euro" : prijsgerecht;
                            Console.WriteLine("U bent bij maandag gegevens:" + i);
                            gerechtenJson.maandag[i] = new string[] { result1, result2, result3, result4 };
                        }
                        gerechtenJson.dinsdag = new string[11][];
                        for (int i = 0; i < 11; i++)
                        {
                            Console.WriteLine("Naam gerecht:");
                            string naamgerecht = Console.ReadLine();
                            var result1 = naamgerecht == "" ? "NoName" : naamgerecht;
                            Console.WriteLine("Beschrijving gerecht:");
                            var beschrijvinggerecht = Console.ReadLine();
                            var result2 = beschrijvinggerecht == "" ? "Een lekker gerecht" : beschrijvinggerecht;
                            Console.WriteLine("Allergenen gerecht:");
                            var allergenengerecht = Console.ReadLine();
                            var result3 = allergenengerecht == "" ? " " : allergenengerecht;
                            Console.WriteLine("Prijs gerecht:");
                            var prijsgerecht = Console.ReadLine();
                            var result4 = prijsgerecht == "" ? "10,00 Euro" : prijsgerecht;
                            Console.WriteLine("U bent bij dinsdag gegevens:" + i);
                            gerechtenJson.dinsdag[i] = new string[] { result1, result2, result3, result4 };
                        }
                        gerechtenJson.woensdag = new string[11][];
                        for (int i = 0; i < 11; i++)
                        {
                            Console.WriteLine("Naam gerecht:");
                            string naamgerecht = Console.ReadLine();
                            var result1 = naamgerecht == "" ? "NoName" : naamgerecht;
                            Console.WriteLine("Beschrijving gerecht:");
                            var beschrijvinggerecht = Console.ReadLine();
                            var result2 = beschrijvinggerecht == "" ? "Een lekker gerecht" : beschrijvinggerecht;
                            Console.WriteLine("Allergenen gerecht:");
                            var allergenengerecht = Console.ReadLine();
                            var result3 = allergenengerecht == "" ? " " : allergenengerecht;
                            Console.WriteLine("Prijs gerecht:");
                            var prijsgerecht = Console.ReadLine();
                            var result4 = prijsgerecht == "" ? "10,00 Euro" : prijsgerecht;
                            gerechtenJson.woensdag[i] = new string[] { result1, result2, result3, result4 };
                        }
                        for (int i = 0; i < 11; i++)
                        {
                            Console.WriteLine("Naam gerecht:");
                            string naamgerecht = Console.ReadLine();
                            var result1 = naamgerecht == "" ? "NoName" : naamgerecht;
                            Console.WriteLine("Beschrijving gerecht:");
                            var beschrijvinggerecht = Console.ReadLine();
                            var result2 = beschrijvinggerecht == "" ? "Een lekker gerecht" : beschrijvinggerecht;
                            Console.WriteLine("Allergenen gerecht:");
                            var allergenengerecht = Console.ReadLine();
                            var result3 = allergenengerecht == "" ? " " : allergenengerecht;
                            Console.WriteLine("Prijs gerecht:");
                            var prijsgerecht = Console.ReadLine();
                            var result4 = prijsgerecht == "" ? "10,00 Euro" : prijsgerecht;
                            gerechtenJson.donderdag[i] = new string[] { result1, result2, result3, result4 };
                        }
                        gerechtenJson.vrijdag = new string[11][];
                        for (int i = 0; i < 11; i++)
                        {
                            Console.WriteLine("Naam gerecht:");
                            string naamgerecht = Console.ReadLine();
                            var result1 = naamgerecht == "" ? "NoName" : naamgerecht;
                            Console.WriteLine("Beschrijving gerecht:");
                            var beschrijvinggerecht = Console.ReadLine();
                            var result2 = beschrijvinggerecht == "" ? "Een lekker gerecht" : beschrijvinggerecht;
                            Console.WriteLine("Allergenen gerecht:");
                            var allergenengerecht = Console.ReadLine();
                            var result3 = allergenengerecht == "" ? " " : allergenengerecht;
                            Console.WriteLine("Prijs gerecht:");
                            var prijsgerecht = Console.ReadLine();
                            var result4 = prijsgerecht == "" ? "10,00 Euro" : prijsgerecht;
                            gerechtenJson.vrijdag[i] = new string[] { result1, result2, result3, result4 };
                        }
                        gerechtenJson.zaterdag = new string[11][];
                        for (int i = 0; i < 11; i++)
                        {
                            Console.WriteLine("Naam gerecht:");
                            string naamgerecht = Console.ReadLine();
                            var result1 = naamgerecht == "" ? "NoName" : naamgerecht;
                            Console.WriteLine("Beschrijving gerecht:");
                            var beschrijvinggerecht = Console.ReadLine();
                            var result2 = beschrijvinggerecht == "" ? "Een lekker gerecht" : beschrijvinggerecht;
                            Console.WriteLine("Allergenen gerecht:");
                            var allergenengerecht = Console.ReadLine();
                            var result3 = allergenengerecht == "" ? " " : allergenengerecht;
                            Console.WriteLine("Prijs gerecht:");
                            var prijsgerecht = Console.ReadLine();
                            var result4 = prijsgerecht == "" ? "10,00 Euro" : prijsgerecht;
                            gerechtenJson.zaterdag[i] = new string[] { result1, result2, result3, result4 };
                        }
                        gerechtenJson.zondag = new string[11][];
                        for (int i = 0; i < 11; i++)
                        {
                            Console.WriteLine("Naam gerecht:");
                            string naamgerecht = Console.ReadLine();
                            var result1 = naamgerecht == "" ? "NoName" : naamgerecht;
                            Console.WriteLine("Beschrijving gerecht:");
                            var beschrijvinggerecht = Console.ReadLine();
                            var result2 = beschrijvinggerecht == "" ? "Een lekker gerecht" : beschrijvinggerecht;
                            Console.WriteLine("Allergenen gerecht:");
                            var allergenengerecht = Console.ReadLine();
                            var result3 = allergenengerecht == "" ? " " : allergenengerecht;
                            Console.WriteLine("Prijs gerecht:");
                            var prijsgerecht = Console.ReadLine();
                            var result4 = prijsgerecht == "" ? "10,00 Euro" : prijsgerecht;
                            gerechtenJson.zondag[i] = new string[] { result1, result2, result3, result4 };
                        }
                    }
                    string nieuw = JsonConvert.SerializeObject(gerechtenJson);
                    File.WriteAllText(@"gerechten.json", nieuw);


                    Console.WriteLine(" Klik op een toets om terug te keren naar het hoofdmenu");
                    Console.ReadKey();
                }
            }
            else if (keuze == "2")
            {
                AdminGegevensBekijken();
            }
            else if (keuze == "3")
            {
                AdminReviewsBekijken();
            }
            else if (keuze == "4")
            {
                AdminReserveringenBekijken();
            }
            else if (keuze == "5")
            {
                string jsonfile_review1 = File.ReadAllText(@"reviews.json");
                JsonClassReview reviews1 = JsonConvert.DeserializeObject<JsonClassReview>(jsonfile_review1);
                if (reviews1 == null || reviews1.Naam == null || reviews1.Naam.Count == 0)
                {
                    Console.WriteLine(" Er is nog geen review");
                    Console.WriteLine(" Klik op een toets om terug te keren naar de adminscherm");
                    Console.ReadKey();
                }
                else if (reviews1 != null || reviews1.Naam != null || reviews1.Naam.Count != 0)
                {
                    int count1 = 0;
                    Console.WriteLine("Dit zijn de reviews");
                    for (int i = 0; i < reviews1.Naam.Count; i++)
                    {

                        Console.WriteLine("nummer van review " + (count1 + 1));
                        Console.WriteLine("Name: " + reviews1.Naam[i] + "\n" + "gerecht: " + reviews1.Gerecht[i] + "\n" + "review: " + reviews1.Review[i] + "\n" + "score : " + reviews1.Score[i] + "\n");
                        count1++;
                    }
                    Console.WriteLine("\n Wilt u doorgaan met verwijderen");
                    Console.WriteLine(" [1]. Ja (LET OP DIT IS DEFINITIEF!)\n [2]. Nee\n");
                    string jaOfNee2 = "";
                    do
                    {
                        jaOfNee2 = Console.ReadLine();
                        if (jaOfNee2 != "1" && jaOfNee2 != "2")
                        {
                            Console.WriteLine(" [1]. Ja (LET OP DIT IS DEFINITIEF!)\n [2]. Nee\n");
                        }
                    }
                    while (jaOfNee2 != "1" && jaOfNee2 != "2");
                    if (jaOfNee2 == "2")
                    {
                        Console.WriteLine("klik op een toets om terug te keren naar de adminscherm");
                        Console.ReadKey();
                    }
                    if (jaOfNee2 == "1")
                    {
                        if (reviews1 != null && reviews1.Naam.Count > 0 && reviews1.Review.Count > 0 && reviews1.Score.Count > 0 && reviews1.Gerecht.Count > 0)
                        {
                            Console.Write(" Welk nummer review wilt u verwijderen: ");
                            string numberstring;
                            int numberint;

                            while (count1 != 0)
                            {
                                try
                                {
                                    do
                                    {
                                        numberstring = Console.ReadLine();
                                        numberint = Int32.Parse(numberstring);
                                        if (numberint <= 0 || numberint > count1)
                                        {
                                            Console.WriteLine("het ingevoerde getal moet positief zijn en ook lager dan het aantal reserveringen");
                                        }

                                    } while (numberint <= 0 || numberint > count1);

                                    reviews1.Naam.RemoveAt(numberint - 1);
                                    reviews1.Gerecht.RemoveAt(numberint - 1);
                                    reviews1.Review.RemoveAt(numberint - 1);
                                    reviews1.Score.RemoveAt(numberint - 1);
                                    int count2 = 0;
                                    for (int i = 0; i < reviews1.Naam.Count; i++)
                                    {
                                        Console.WriteLine(" Nummer van review: " + (count2 + 1));
                                        Console.WriteLine(" Naam: " + reviews1.Naam[i] + "\n" + "gerecht: " + reviews1.Gerecht[i] + "\n" + "review: " + reviews1.Review[i] + "\n" + "score : " + reviews1.Score[i] + "\n");
                                        count2++;
                                    }
                                    Console.WriteLine(" Klik op een toets om terug te keren naar de adminscherm");
                                    Console.ReadKey();
                                    break;
                                }

                                catch
                                {
                                    Console.WriteLine("\n typ een nummer");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine(" Er is nog geen review geplaatst!");
                            Console.WriteLine(" Klik op een toets om terug te keren naar de adminscherm");
                            Console.ReadKey();
                        }
                        string reviews2 = JsonConvert.SerializeObject(reviews1);
                        File.WriteAllText(@"reviews.json", reviews2);
                    }
                }
            }
            else if (keuze == "6")
            {
                //kijkt of de json file bestaat in dezelfde directory als het project
                string curFileThree = @"reservering_id.json";
                var existThree = File.Exists(curFileThree) ? true : false;

                //de json file bestaat niet in het project folder en wordt aangemaakt en gevuld met null
                if (existThree == false)
                {
                    string existance = JsonConvert.SerializeObject(null);
                    File.WriteAllText(@"reservering_id.json", existance);
                }

                string bufferThree = File.ReadAllText(@"reservering_id.json");
                JsonClassReservering reserveringIdJson = JsonConvert.DeserializeObject<JsonClassReservering>(bufferThree);

                //kijkt of de json file bestaat in dezelfde directory als het project
                string curFileTwo = @"tafels.json";
                var existTwo = File.Exists(curFileTwo) ? true : false;

                //de json file bestaat niet in het project folder en wordt aangemaakt en gevuld met null
                if (existTwo == false)
                {
                    string existance = JsonConvert.SerializeObject(null);
                    File.WriteAllText(@"tafels.json", existance);
                }

                string bufferTwo = File.ReadAllText(@"tafels.json");
                JsonClassTafels tafelJson = JsonConvert.DeserializeObject<JsonClassTafels>(bufferTwo);

                if (reserveringIdJson == null)
                {
                    Console.WriteLine(" Er zijn nog geen reserveringen aangemaakt");
                    Console.WriteLine(" Klik op een toets om terug te keren naar de admin scherm");
                    Console.ReadKey();

                }

                int count = 0;
                Console.Clear();
                Console.WriteLine("Dit zijn al de reserveringen");
                if (reserveringIdJson != null)
                {
                    for (int i = 0; i < reserveringIdJson.id.Count; i++)
                    {
                        Console.WriteLine("reservering nummer: " + (count + 1));
                        Console.WriteLine("klantenID: " + reserveringIdJson.id[i] + "\n" + "Datum: " + reserveringIdJson.Datum[i] + "\n" + "Tijdstip: " + reserveringIdJson.Tijden[i] + "\n" + "Personen: " + reserveringIdJson.Personen[i] + "\n" + "Details: " + reserveringIdJson.Details[i] + "\n");
                        count++;
                    }
                    if (count == 0)
                    {
                        Console.WriteLine("Er zijn nog geen reserveringen aangemaakt");
                        Console.WriteLine(" Klik op een toets om terug te keren naar de admin scherm");
                        Console.ReadKey();
                    }
                }
                Console.WriteLine("\n Wilt u doorgaan met verwijderen ");
                Console.WriteLine(" [1]. Ja (LET OP DIT IS DEFINITIEF!)\n [2]. Nee\n");
                string jaOfNee2 = "";
                do
                {
                    jaOfNee2 = Console.ReadLine();
                    if (jaOfNee2 != "1" && jaOfNee2 != "2")
                    {
                        Console.WriteLine(" [1]. Ja (LET OP DIT IS DEFINITIEF!)\n [2]. Nee\n");
                    }
                }
                while (jaOfNee2 != "1" && jaOfNee2 != "2");
                if (jaOfNee2 == "2")
                {
                    Console.WriteLine(" Klik op een toets om terug te keren naar de adminscherm");
                    Console.ReadKey();
                }
                string keuzeReservering;
                int intKeuze;
                if (jaOfNee2 == "1")
                {
                    while (count != 0)
                    {
                        Console.WriteLine(" Typ het nummer van de reservering die u wilt annuleren: ");
                        try
                        {
                            do
                            {
                                keuzeReservering = Console.ReadLine();
                                intKeuze = Int32.Parse(keuzeReservering);
                                if (intKeuze <= 0 || intKeuze > count)
                                {
                                    Console.WriteLine(" Het ingevoerde getal moet positief zijn en ook lager dan het aantal reserveringen");
                                }
                            } while (intKeuze <= 0 || intKeuze > count);

                            var gekozenDatum = reserveringIdJson.Datum[intKeuze - 1];
                            var gekozenPersonen = reserveringIdJson.Personen[intKeuze - 1];
                            var gekozenID = reserveringIdJson.id[intKeuze - 1];
                            reserveringIdJson.id.RemoveAt(intKeuze - 1);
                            reserveringIdJson.Datum.RemoveAt(intKeuze - 1);
                            reserveringIdJson.Tijden.RemoveAt(intKeuze - 1);
                            reserveringIdJson.Personen.RemoveAt(intKeuze - 1);
                            reserveringIdJson.Details.RemoveAt(intKeuze - 1);
                            for (int k = 0; k < tafelJson.id.Count; k++)
                            {
                                for (int j = 0; j < tafelJson.id[k].Count; j++)
                                {
                                    if (tafelJson.datum[k] == gekozenDatum && tafelJson.id[k][j] == gekozenID)
                                    {
                                        tafelJson.aantalPlaatsen[k] += gekozenPersonen;
                                        tafelJson.id[k].RemoveAt(j);

                                    }
                                }
                            }
                        }
                        catch
                        {
                            Console.WriteLine("");
                        }

                        string strNieuweReserveringJson = JsonConvert.SerializeObject(reserveringIdJson);
                        File.WriteAllText(@"reservering_id.json", strNieuweReserveringJson);

                        string strNieuweTafelJson = JsonConvert.SerializeObject(tafelJson);
                        File.WriteAllText(@"tafels.json", strNieuweTafelJson);

                        Console.Clear();
                        Console.WriteLine("Dit is de nieuwe lijst van reserveringen");
                        for (int i = 0; i < reserveringIdJson.id.Count; i++)
                        {
                            Console.WriteLine("reservering nummer: " + (i + 1));
                            Console.WriteLine("klantenID: " + reserveringIdJson.id[i] + "\n" + "Datum: " + reserveringIdJson.Datum[i] + "\n" + "Tijdstip: " + reserveringIdJson.Tijden[i] + "\n" + "Personen: " + reserveringIdJson.Personen[i] + "\n" + "Details: " + reserveringIdJson.Details[i] + "\n");
                            count++;
                        }
                        Console.WriteLine(" Klik op een toets om terug te keren naar de admin scherm");
                        Console.ReadKey();
                        break;
                    }
                }
            }
            else if (keuze == "7")
            {
                Console.WriteLine("\n U bent uitgelogd!");
                Console.WriteLine(" Druk op een toets om terug te keren naar het hoofdmenu");
                Console.ReadKey();
                break;
            }
        }

    }
}
