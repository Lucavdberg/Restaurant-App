
using System;
using Newtonsoft.Json;
using System.IO;

public class Reservering {
    public void reserveringFunc(JsonClassReservering reservering_id)
    {
        Console.WriteLine("vul een datum in: ");
        string datum = Console.ReadLine();
        Console.WriteLine("vul een tijdstip in: ");
        string tijdstip = Console.ReadLine();
        Console.WriteLine("vul het aantal personen in: ");
        string personen = Console.ReadLine();
        Console.WriteLine("vul hier belangrijke details in: ");
        string details = Console.ReadLine();
        Console.WriteLine("Uw reservering is aangemaakt!");
        Console.ReadKey();
        Console.WriteLine("Type (1) voor het bekijken van uw reservering of (2) om uw reservering te wijzigen");
        var reservering = Console.ReadLine();

        reservering_id.Datum = datum;
        reservering_id.Tijden = tijdstip;
        reservering_id.Personen = personen;
        reservering_id.Details = details;

        string strReserveringJson = JsonConvert.SerializeObject(reservering_id);
        Console.WriteLine(strReserveringJson);
        File.WriteAllText(@"reservering_id.json", strReserveringJson);
        Console.WriteLine("stored!");
        strReserveringJson = File.ReadAllText(@"reservering_id.json");
        JsonClassReservering resultReserveringClass = JsonConvert.DeserializeObject<JsonClassReservering>(strReserveringJson);
        Console.WriteLine(resultReserveringClass);

        string[] bestelling = new string[] { reservering_id.Datum, reservering_id.Tijden, reservering_id.Personen, reservering_id.Details };
        if (reservering == "1")
        {
            for (int i = 0; i < bestelling.Length; i++)
            {
                Console.WriteLine(bestelling[i]);
            }
        }
        else
        {
            Console.WriteLine("Wilt u de datum wijzigen type (1), wilt u de tijdstip wijzigen type (2), wilt u het aantal personen wijzigen type (3), wilt u de belangrijke details wijzigen type(4)");
            var wijzigen = Console.ReadLine();
            if (wijzigen == "1")
            {
                Console.WriteLine("vul een nieuwe datum in");
                reservering_id.Datum = Console.ReadLine();
            }
            if (wijzigen == "2")
            {
                Console.WriteLine("vul een nieuwe tijdstip in");
                reservering_id.Tijden = Console.ReadLine();
            }
            if (wijzigen == "3")
            {
                Console.WriteLine("vul een nieuwe aantal personen in");
                reservering_id.Personen = Console.ReadLine();
            }
            if (wijzigen == "4")
            {
                Console.WriteLine("vul de nieuwe belangrijke details in");
                reservering_id.Details = Console.ReadLine();
            }
            Console.WriteLine("Dit zijn uw nieuwe gegevens");
            string[] gewijzigdeBestelling = new string[] { reservering_id.Datum, reservering_id.Tijden, reservering_id.Personen, reservering_id.Details };
            for (int i = 0; i < gewijzigdeBestelling.Length; i++)
            {
                Console.WriteLine(gewijzigdeBestelling[i]);
            }
        }

    }

}