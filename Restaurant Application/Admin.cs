using System;
using Newtonsoft.Json;
using System.IO;
using System.ComponentModel.DataAnnotations.Schema;

public class Admin
{
    public void adminFunc(JsonClassGerechten newgerechten)
    {
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
        Console.WriteLine("Wat is uw admin gebruiksernaam?");
        var naam = Console.ReadLine();
        Console.WriteLine("Wat is uw admin wachtwoord?");
        var ww = Console.ReadLine();
        while (naam != "Admin" || ww != "Admin123")
        {
            Console.WriteLine("De inloggevens zijn onjuist");
            Console.WriteLine("Wat is uw admin gebruiksernaam?");
            naam = Console.ReadLine();
            Console.WriteLine("Wat is uw admin wachtwoord?");
            ww = Console.ReadLine();
        } 
        if (naam == "Admin" && ww == "Admin123")
        {
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
            }
            string buffer2 = File.ReadAllText(@"gerechten.json");
            JsonClassGerechten AGJ = JsonConvert.DeserializeObject<JsonClassGerechten>(buffer2);
            Console.WriteLine("Logged In!");
            Console.WriteLine("Van welke dag wilt u iets veranderen in het menu?");
            string dag = "";
            do
            {
                Console.WriteLine("type een dag van de week");
                dag = Console.ReadLine();
            }
            while (dag != "maandag" && dag != "Maandag" && dag != "dinsdag" && dag != "Dinsdag" && dag != "woensdag" && dag != "Woensdag" && dag != "donderdag" && dag != "Donderdag" && dag != "vrijdag" && dag != "Vrijdag" && dag != "zaterdag" && dag != "Zaterdag" && dag != "zondag" && dag != "Zondag");
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

        }
        Console.WriteLine("klik op een toets om terug te keren naar het hoofdmenu");
        Console.ReadKey();
    }
}