using System;
using Newtonsoft.Json;
using System.IO;

public class ReserveringAnnuleren
{
    public void ReserveringAnnulerenFunc(int cijfer)
    {
        string buffer = File.ReadAllText(@"reservering_id.json");
        JsonClassReservering reserveringIdJson = JsonConvert.DeserializeObject<JsonClassReservering>(buffer);
        string bufferTwo = File.ReadAllText(@"gebruiker_id.json");
        JsonClassLogin gebruikerIdJson = JsonConvert.DeserializeObject<JsonClassLogin>(bufferTwo);

        int count = 0;
        Console.WriteLine("Dit zijn al uw reserveringen");
        for (int i = 0; i < reserveringIdJson.id.Count; i++)
        {
            if (reserveringIdJson.id[i] == gebruikerIdJson.id[cijfer])
            {
                Console.WriteLine(reserveringIdJson.Datum[i] + "\n" + reserveringIdJson.Tijden[i] + "\n" + reserveringIdJson.Personen[i] + "\n" + reserveringIdJson.Details[i] + "\n");
                count++;
            }
        }
        Console.WriteLine("type het getal in van welke reservering u wilt annuleren");
        string keuze;
        int intKeuze;

        while (true)
        {
            try
            {
                do
                {
                    keuze = Console.ReadLine();
                    intKeuze = Int32.Parse(keuze);
                    if (intKeuze <= 0 || intKeuze > count)
                    {
                        Console.WriteLine("het ingevoerde getal moet positief zijn en ook lager dan het aantal reserveringen");
                    }
                } while (intKeuze <= 0 || intKeuze > count);

                //we loopen hier door de id's van gebruikers in de reserveringen json
                int counter = 0;
                for (int i = 0; i < reserveringIdJson.id.Count; i++)
                {
                    //als de id in de reservering json gelijk is aan de id van de ingelogde gebruiker
                    if (reserveringIdJson.id[i] == gebruikerIdJson.id[cijfer] && counter == intKeuze - 1)
                    {
                        reserveringIdJson.id.RemoveAt(i);
                        reserveringIdJson.Datum.RemoveAt(i);
                        reserveringIdJson.Tijden.RemoveAt(i);
                        reserveringIdJson.Personen.RemoveAt(i);
                        reserveringIdJson.Details.RemoveAt(i);
                        counter++;
                    }
                    else if (reserveringIdJson.id[i] == gebruikerIdJson.id[cijfer])
                    {
                        counter++;
                    }
                }

                string strReserveringJson = JsonConvert.SerializeObject(reserveringIdJson);
                File.WriteAllText(@"reservering_id.json", strReserveringJson);
                string bufferThree = File.ReadAllText(@"reservering_id.json");
                JsonClassReservering nieuweReserveringIdJson = JsonConvert.DeserializeObject<JsonClassReservering>(bufferThree);

                Console.WriteLine("Uw reservering is geannuleerd");
                Console.WriteLine("Dit is uw nieuwe lijst van reserveringen");
                for (int i = 0; i < nieuweReserveringIdJson.id.Count; i++)
                {
                    if (nieuweReserveringIdJson.id[i] == gebruikerIdJson.id[cijfer])
                    {
                        Console.WriteLine(nieuweReserveringIdJson.Datum[i] + "\n" + nieuweReserveringIdJson.Tijden[i] + "\n" + nieuweReserveringIdJson.Personen[i] + "\n" + nieuweReserveringIdJson.Details[i] + "\n");
                    }
                }
                Console.WriteLine("klik op een toets om terug te keren naar het hoofdmenu");
                Console.ReadKey();
                break;
            }
            catch
            {
                Console.WriteLine("Voer een getal in");
            }
        }
    }
}