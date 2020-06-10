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

        string bufferThree = File.ReadAllText(@"tafels.json");
        JsonClassTafels tafelJson = JsonConvert.DeserializeObject<JsonClassTafels>(bufferThree);

        int count = 0;
        Console.Clear();
        Console.WriteLine(" - Dit zijn al uw reserveringen\n");
        for (int i = 0; i < reserveringIdJson.id.Count; i++)
        {    
            if (reserveringIdJson.id[i] == gebruikerIdJson.id[cijfer])
            {
                Console.WriteLine(" Reservering nummer: " + (count + 1));
                Console.WriteLine(" Datum:          " + reserveringIdJson.Datum[i] + "\n" + " Tijdstip:          " + reserveringIdJson.Tijden[i] + "\n" + " Personen:          " + reserveringIdJson.Personen[i] + "\n" + " Details:          " + reserveringIdJson.Details[i] + "\n");
                count++;
            }
        }
        if (count == 0)
        {
            Console.WriteLine(" U heeft nog geen reserveringen");
            Console.WriteLine(" Klik op een toets om terug te keren naar de customer scherm");
            Console.ReadKey();
        }

        string keuze;
        int intKeuze;
        while (count != 0)
        {
            Console.WriteLine(" Welke reservering wilt u annuleren? Reserveringnummer: ");
            try
            {
                do
                {
                    keuze = Console.ReadLine();
                    intKeuze = Int32.Parse(keuze);
                    if (intKeuze <= 0 || intKeuze > count)
                    {
                        Console.WriteLine(" het ingevoerde getal moet positief zijn en ook lager dan het aantal reserveringen");
                    }
                } while (intKeuze <= 0 || intKeuze > count);

                Console.WriteLine("\nWeet u zeker dat u deze reservering wilt annuleren");
                Console.WriteLine(" [1]. Ja\n [2]. Nee\n");
                string jaOfNee = "";
                do
                {
                    jaOfNee = Console.ReadLine();
                    if (jaOfNee != "1" && jaOfNee != "2")
                    {
                        Console.WriteLine(" [1]. Ja\n [2]. Nee\n");
                    }
                } while (jaOfNee != "1" && jaOfNee != "2");
                if (jaOfNee == "2")
                {
                    Console.WriteLine("klik op een toets om terug te keren naar de customer scherm");
                    Console.ReadKey();
                    break;
                }
                //we loopen hier door de id's van gebruikers in de reserveringen json
                int counter = 0;
                string gekozenDatum = "";
                int gekozenPersonen = 0;
                for (int i = 0; i < reserveringIdJson.id.Count; i++)
                {
                    //als de id in de reservering json gelijk is aan de id van de ingelogde gebruiker
                    if (reserveringIdJson.id[i] == gebruikerIdJson.id[cijfer] && counter == intKeuze - 1)
                    {
                        gekozenDatum = reserveringIdJson.Datum[i];
                        gekozenPersonen = reserveringIdJson.Personen[i];
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
                
                for (int i = 0; i < tafelJson.id.Count; i++)
                {
                    for (int j = 0; j < tafelJson.id[i].Count; j++) 
                    {
                        if (tafelJson.datum[i] == gekozenDatum && tafelJson.id[i][j] == gebruikerIdJson.id[cijfer])
                        {
                            tafelJson.aantalPlaatsen[i] += gekozenPersonen;
                            tafelJson.id[i].RemoveAt(j);
                        }
                    }
                }

                string strNieuweTafelJson = JsonConvert.SerializeObject(tafelJson);
                File.WriteAllText(@"tafels.json", strNieuweTafelJson);

                string strReserveringJson = JsonConvert.SerializeObject(reserveringIdJson);
                File.WriteAllText(@"reservering_id.json", strReserveringJson);
                string bufferFour = File.ReadAllText(@"reservering_id.json");
                JsonClassReservering nieuweReserveringIdJson = JsonConvert.DeserializeObject<JsonClassReservering>(bufferFour);

                Console.WriteLine(" Uw reservering is geannuleerd");
                Console.WriteLine(" Dit is uw nieuwe lijst van reserveringen\n");
                for (int i = 0; i < nieuweReserveringIdJson.id.Count; i++)
                {
                    if (nieuweReserveringIdJson.id[i] == gebruikerIdJson.id[cijfer])
                    {
                        Console.WriteLine("Datum:          " + nieuweReserveringIdJson.Datum[i] + "\n" + "Tijdstip:          " + nieuweReserveringIdJson.Tijden[i] + "\n" + "Personen:          " + nieuweReserveringIdJson.Personen[i] + "\n" + "Details:          " + nieuweReserveringIdJson.Details[i] + "\n");
                    }
                }
                Console.WriteLine(" Klik op een toets om terug te keren naar de customer scherm");
                Console.ReadKey();
                break;
            }
            catch
            {
                Console.WriteLine("");
            }
        }
    }
}