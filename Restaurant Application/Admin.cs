using System;
using Newtonsoft.Json;
using System.IO;
public class Admin
{
    public void adminFunc(JsonClassGerechten newgerechten)
    {
        JsonClassGerechten gerechtenJson = new JsonClassGerechten();
        Console.WriteLine("Wat is uw admin gebruiksernaam?");
        var naam = Console.ReadLine();
        Console.WriteLine("Wat is uw admin wachtwoord?");
        var ww = Console.ReadLine();
        if (naam == "Admin" && ww == "Admin123")
        {
            Console.WriteLine("Logged In!");
            Console.WriteLine("Van welke dag wilt u iets veranderen in het menu?");
            var dag = Console.ReadLine();
            if (dag == "maandag" || dag == "Maandag") {
                gerechtenJson.maandag = new string[11][];
                for(int i = 0; i < 11; i++)
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
                }
                gerechtenJson.dinsdag = newgerechten.dinsdag;
                gerechtenJson.woensdag = newgerechten.woensdag;
                gerechtenJson.donderdag = newgerechten.donderdag;
                gerechtenJson.vrijdag = newgerechten.vrijdag;
                gerechtenJson.zaterdag = newgerechten.zaterdag;
                gerechtenJson.zondag = newgerechten.zondag;

                string nieuw = JsonConvert.SerializeObject(gerechtenJson);
                File.WriteAllText(@"gerechten.json", nieuw);
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
                gerechtenJson.maandag = newgerechten.maandag;
                gerechtenJson.woensdag = newgerechten.woensdag;
                gerechtenJson.donderdag = newgerechten.donderdag;
                gerechtenJson.vrijdag = newgerechten.vrijdag;
                gerechtenJson.zaterdag = newgerechten.zaterdag;
                gerechtenJson.zondag = newgerechten.zondag;

                string nieuw1 = JsonConvert.SerializeObject(gerechtenJson);
                File.WriteAllText(@"gerechten.json", nieuw1);
                }
                string nieuwhier = JsonConvert.SerializeObject(gerechtenJson);
                File.WriteAllText(@"gerechten.json", nieuwhier);
            }
        
    }
}