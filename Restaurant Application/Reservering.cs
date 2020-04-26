
using System;
using Newtonsoft.Json;
using System.IO;


public class Reservering {
    public void reserveringFunc(JsonClassReservering reservering_id, JsonClassTafels tafels)
    {
        Console.WriteLine("vul een datum in: ");
        string datum = Console.ReadLine();
        Console.WriteLine("vul een tijdstip in: ");
        string tijdstip = Console.ReadLine();
        var datumJson = DateTime.TryParse(datum + " " + tijdstip, out DateTime result);
        Console.WriteLine("vul het aantal personen in: ");
        string personen = Console.ReadLine();
        int newperson = Int32.Parse(personen);
        Console.WriteLine("vul hier belangrijke details in: ");
        string details = Console.ReadLine();
        Console.WriteLine("Uw reservering is aangemaakt!");
        Console.WriteLine("Type (1) voor het bekijken van uw reservering of (2) om uw reservering te wijzigen");
        string reservering = Console.ReadLine();

        reservering_id.Datum = datum;
        reservering_id.Tijden = tijdstip;
        reservering_id.Personen = newperson;
        reservering_id.Details = details;
        tafels.aantalTafels -= newperson;

        string strReserveringJson = JsonConvert.SerializeObject(reservering_id);
        File.WriteAllText(@"reservering_id.json", strReserveringJson);
        strReserveringJson = File.ReadAllText(@"reservering_id.json");
        JsonClassReservering resultReserveringClass = JsonConvert.DeserializeObject<JsonClassReservering>(strReserveringJson);

        string strTafelJson = JsonConvert.SerializeObject(tafels);
        File.WriteAllText(@"tafels.json", strTafelJson);
        strTafelJson = File.ReadAllText(@"tafels.json");
        JsonClassReservering resultTafelClass = JsonConvert.DeserializeObject<JsonClassReservering>(strTafelJson);

        string[] bestelling = new string[] { reservering_id.Datum, reservering_id.Tijden, reservering_id.Personen.ToString(), reservering_id.Details };
        if (reservering == "1")
        {
            for (int i = 0; i < bestelling.Length; i++)
            {
                Console.WriteLine(bestelling[i]);
            }
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
                reservering_id.Datum = datumGewijzigd;
            }
            if (wijzigen == "2")
            {
                Console.WriteLine("vul een nieuwe tijdstip in");
                string tijdenGewijzigd = Console.ReadLine();
                var nieuweTijdenJson = DateTime.TryParse(datum + " " + tijdenGewijzigd, out DateTime resultGewijzigd);
                reservering_id.Tijden = tijdenGewijzigd;
            }
            if (wijzigen == "3")
            {
                Console.WriteLine("vul een nieuwe aantal personen in");
                var personenGewijzigd = Console.ReadLine();
                reservering_id.Personen = Int32.Parse(personenGewijzigd);
                tafels.aantalTafels = tafels.aantalTafels - reservering_id.Personen + newperson;
            }
            if (wijzigen == "4")
            {
                Console.WriteLine("vul de nieuwe belangrijke details in");
                reservering_id.Details = Console.ReadLine();
            }
            if (wijzigen == "5")
            {
                Console.WriteLine("vul een nieuwe datum in");
                string datumGewijzigd = Console.ReadLine();
                Console.WriteLine("vul een nieuwe tijdstip in");
                string tijdenGewijzigd = Console.ReadLine();
                Console.WriteLine("vul een nieuwe aantal personen in");
                var personenGewijzigd = Console.ReadLine();
                reservering_id.Personen = Int32.Parse(personenGewijzigd);
                Console.WriteLine("vul de nieuwe belangrijke details in");
                reservering_id.Details = Console.ReadLine();
                tafels.aantalTafels = tafels.aantalTafels - reservering_id.Personen + newperson;
                var nieuweDatumTijdJson = DateTime.TryParse(datumGewijzigd + " " + tijdenGewijzigd, out DateTime resultGewijzigdTwee);
                reservering_id.Datum = datumGewijzigd;
                reservering_id.Tijden = tijdenGewijzigd;
            }
            Console.WriteLine("Dit zijn uw nieuwe gegevens");
            string[] gewijzigdeBestelling = new string[] { reservering_id.Datum, reservering_id.Tijden, reservering_id.Personen.ToString(), reservering_id.Details };
            for (int i = 0; i < gewijzigdeBestelling.Length; i++)
            {
                Console.WriteLine(gewijzigdeBestelling[i]);
            }
        }
        string strNieuweReserveringJson = JsonConvert.SerializeObject(reservering_id);
        File.WriteAllText(@"reservering_id.json", strNieuweReserveringJson);
        strNieuweReserveringJson = File.ReadAllText(@"reservering_id.json");
        JsonClassReservering resultNieuweReservering = JsonConvert.DeserializeObject<JsonClassReservering>(strNieuweReserveringJson);

        string strNieuweTafelJson = JsonConvert.SerializeObject(tafels);
        File.WriteAllText(@"tafels.json", strNieuweTafelJson);
        strNieuweTafelJson = File.ReadAllText(@"tafels.json");
        JsonClassReservering resultNieuweTafelClass = JsonConvert.DeserializeObject<JsonClassReservering>(strNieuweTafelJson);

        Console.WriteLine("klik op een toets om terug te keren naar het hoofdmenu");
        Console.ReadKey();
    }
}