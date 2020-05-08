using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

public class Reservering 
{
    public void reserveringFunc(JsonClassTafels tafels, int cijfer)
    {
        string bufferTwo = File.ReadAllText(@"reservering_id.json");
        JsonClassReservering reserveringIdJson = JsonConvert.DeserializeObject<JsonClassReservering>(bufferTwo);

        string buffer = File.ReadAllText(@"gebruiker_id.json");
        JsonClassLogin gebruikerIdJson = JsonConvert.DeserializeObject<JsonClassLogin>(buffer);

        string datum;
        string tijdstip;
        string personen;
        string details;
        string reservering;
        int newperson;

        while (true)
        {
            try
            {
                //leest de gegevens voor de reservatie
                Console.WriteLine("vul een datum in: ");
                datum = Console.ReadLine();
                Console.WriteLine("vul een tijdstip in: ");
                tijdstip = Console.ReadLine();
                Console.WriteLine("vul het aantal personen in: ");
                do
                {
                    //zorgt ervoor dat het ingevoerde aantal personen positief is en lager is dan 50
                    personen = Console.ReadLine();
                    newperson = Int32.Parse(personen);
                    if (newperson <= 0 || newperson > 50)
                    {
                        Console.WriteLine("het ingevoerde getal moet positief zijn en ook lager dan het maximum aantal zitplaatsen namelijk 50");
                    }
                } while (newperson <= 0 || newperson > 50);
                
                Console.WriteLine("vul hier belangrijke details in: ");
                details = Console.ReadLine();
                Console.WriteLine("Uw reservering is aangemaakt!");
                Console.WriteLine("Type (1) voor het bekijken van uw reservering of (2) om uw reservering te wijzigen");
                reservering = Console.ReadLine();
                //var datumJson = DateTime.TryParse(datum + " " + tijdstip, out DateTime result);
                break;
            }
            catch
            {
                Console.WriteLine("Vul een positief getal in voor het aantal personen");
            }
        }

        //maakt nieuwe lijsten aan en vult ze met de gegevens van de reservatie
        //reservering_id.Datum = new List<string> { datum };
        //reservering_id.Tijden = new List<string> { tijdstip };
        //reservering_id.Personen = new List<int> { newperson };
        //reservering_id.Details = new List<string> { details };
        //reservering_id.id = new List<int> { gebruikerIdJson.id[cijfer] };
        //trekt het aantal personen van de reservatie af van het maximum van 50 personen voor het restaurant
        tafels.aantalTafels -= newperson;

        //maakt een nieuwe JsonClassReservering aan
        JsonClassReservering resultJson = new JsonClassReservering();

        //maakt nieuwe lijsten aan
        resultJson.Datum = new List<string>();
        resultJson.Tijden = new List<string>();
        resultJson.Personen = new List<int>();
        resultJson.Details = new List<string>();
        resultJson.id = new List<int>();

        //reserveringIdJson is de json file waar de reserveringen in worden opgeslagen
        if (reserveringIdJson != null)
        {
            for (int i = 0; i < reserveringIdJson.Datum.Count; i++)
            {
                //vult de lijsten met alle gegevens die al in de json file van de reserveringen staan
                resultJson.Datum.Add(reserveringIdJson.Datum[i]);
                resultJson.Tijden.Add(reserveringIdJson.Tijden[i]);
                resultJson.Personen.Add(reserveringIdJson.Personen[i]);
                resultJson.Details.Add(reserveringIdJson.Details[i]);
                resultJson.id.Add(reserveringIdJson.id[i]);
            }
        }
        //de lijst wordt gevuld met de ingevoerde gegevens
        resultJson.Datum.Add(datum);
        resultJson.Tijden.Add(tijdstip);
        resultJson.Personen.Add(newperson);
        resultJson.Details.Add(details);
        resultJson.id.Add(gebruikerIdJson.id[cijfer]);

        //de resultjson lijst zetten we om in een json file
        string strReserveringJson = JsonConvert.SerializeObject(resultJson);
        File.WriteAllText(@"reservering_id.json", strReserveringJson);

        string strTafelJson = JsonConvert.SerializeObject(tafels);
        File.WriteAllText(@"tafels.json", strTafelJson);

        if (reservering == "1")
        {
            Console.WriteLine("Uw nieuwe reservering");
            Console.WriteLine(datum);
            Console.WriteLine(tijdstip);
            Console.WriteLine(personen);
            Console.WriteLine(details);
        }
        else
        {
            Console.WriteLine("Wilt u de datum wijzigen type (1), wilt u de tijdstip wijzigen type (2), wilt u het aantal personen wijzigen type (3), wilt u de belangrijke details wijzigen type(4), Wilt u alles wijzigen type(5)");
            var wijzigen = Console.ReadLine();
            if (wijzigen == "1")
            {
                Console.WriteLine("vul een nieuwe datum in");
                string datumGewijzigd = Console.ReadLine();
                var nieuweDatumJson = DateTime.TryParse(datumGewijzigd + " " + tijdstip, out DateTime resultGewijzigd);
                resultJson.Datum[resultJson.Datum.Count - 1] = datumGewijzigd;
            }
            if (wijzigen == "2")
            {
                Console.WriteLine("vul een nieuwe tijdstip in");
                string tijdenGewijzigd = Console.ReadLine();
                var nieuweTijdenJson = DateTime.TryParse(datum + " " + tijdenGewijzigd, out DateTime resultGewijzigd);
                resultJson.Tijden[resultJson.Tijden.Count - 1] = tijdenGewijzigd;
            }
            if (wijzigen == "3")
            {
                Console.WriteLine("vul een nieuwe aantal personen in");
                var personenGewijzigd = Console.ReadLine();
                resultJson.Personen[resultJson.Personen.Count - 1] = Int32.Parse(personenGewijzigd);
                tafels.aantalTafels = tafels.aantalTafels - resultJson.Personen[resultJson.Personen.Count - 1] + newperson;
            }
            if (wijzigen == "4")
            {
                Console.WriteLine("vul de nieuwe belangrijke details in");
                var detailsGewijzigd = Console.ReadLine();
                resultJson.Details[resultJson.Details.Count - 1] = detailsGewijzigd;
            }
            if (wijzigen == "5")
            {
                Console.WriteLine("vul een nieuwe datum in");
                string datumGewijzigd = Console.ReadLine();
                Console.WriteLine("vul een nieuwe tijdstip in");
                string tijdenGewijzigd = Console.ReadLine();
                Console.WriteLine("vul een nieuwe aantal personen in");
                var personenGewijzigd = Console.ReadLine();
                resultJson.Personen[resultJson.Personen.Count - 1] = Int32.Parse(personenGewijzigd);
                Console.WriteLine("vul de nieuwe belangrijke details in");
                var detailsGewijzigd = Console.ReadLine();
                resultJson.Details[resultJson.Details.Count - 1] = detailsGewijzigd;
                tafels.aantalTafels = tafels.aantalTafels - resultJson.Personen[resultJson.Personen.Count - 1] + newperson;
                var nieuweDatumTijdJson = DateTime.TryParse(datumGewijzigd + " " + tijdenGewijzigd, out DateTime resultGewijzigdTwee);
                resultJson.Datum[resultJson.Datum.Count - 1] = datumGewijzigd;
                resultJson.Tijden[resultJson.Tijden.Count - 1] = tijdenGewijzigd;
            }
            string strNieuweReserveringJson = JsonConvert.SerializeObject(resultJson);
            File.WriteAllText(@"reservering_id.json", strNieuweReserveringJson);
            string nieuweReservering = File.ReadAllText(@"reservering_id.json");
            JsonClassReservering nieuweReserveringIdJson = JsonConvert.DeserializeObject<JsonClassReservering>(nieuweReservering);

            Console.WriteLine("Dit zijn uw nieuwe gegevens");
            string[] gewijzigdeBestelling = new string[] { nieuweReserveringIdJson.Datum[nieuweReserveringIdJson.Datum.Count - 1], nieuweReserveringIdJson.Tijden[nieuweReserveringIdJson.Tijden.Count - 1], nieuweReserveringIdJson.Personen[nieuweReserveringIdJson.Personen.Count - 1].ToString(), nieuweReserveringIdJson.Details[nieuweReserveringIdJson.Details.Count - 1] };
            for (int i = 0; i < gewijzigdeBestelling.Length; i++)
            {
                Console.WriteLine(gewijzigdeBestelling[i]);
            }
        }

        string strNieuweTafelJson = JsonConvert.SerializeObject(tafels);
        File.WriteAllText(@"tafels.json", strNieuweTafelJson);

        Console.WriteLine("klik op een toets om terug te keren naar het hoofdmenu");
        Console.ReadKey();
    }
}