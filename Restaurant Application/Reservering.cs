using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Globalization;

public class Reservering 
{
    public void reserveringFunc(JsonClassReservering resultJson, JsonClassTafels tafels, int cijfer)
    {
        string bufferTwo = File.ReadAllText(@"reservering_id.json");
        JsonClassReservering reserveringIdJson = JsonConvert.DeserializeObject<JsonClassReservering>(bufferTwo);

        string buffer = File.ReadAllText(@"gebruiker_id.json");
        JsonClassLogin gebruikerIdJson = JsonConvert.DeserializeObject<JsonClassLogin>(buffer);

        //kijkt of de json file bestaat in dezelfde directory als het project
        string curFile = @"tafels.json";
        var exist = File.Exists(curFile) ? true : false;

        //de json file bestaat niet in het project folder en wordt aangemaakt en gevuld met null
        if (exist == false)
        {
            string existance = JsonConvert.SerializeObject(null);
            File.WriteAllText(@"tafels.json", existance);
        }

        string bufferThree = File.ReadAllText(@"tafels.json");
        JsonClassTafels tafelJson = JsonConvert.DeserializeObject<JsonClassTafels>(bufferThree);

        string datum;
        string tijdstip;
        string personen;
        string details;
        string reservering;
        int personAmount;
        DateTime resultDate;

        while (true)
        {
            Console.WriteLine("vul een datum in: ");
            datum = Console.ReadLine();
            var charsToRemove = new string[] { "/", " " }; 
            //vervangt het symbool (´/´) en (spatie) naar het symbool `-`
            foreach (var c in charsToRemove)
            {
                datum = datum.Replace(c, "-");
            }
            if (tafelJson != null)
            {
                for (int i = 0; i < tafelJson.datum.Count; i++)
                {
                    for (int j = 0; j < reserveringIdJson.Datum.Count; j++)
                    {
                        //zorgt ervoor dat een gebruiker niet op dezelfde dag nog een reservering kan plaatsen
                        while (datum == reserveringIdJson.Datum[j] && gebruikerIdJson.id[cijfer] == reserveringIdJson.id[j])
                        {
                            Console.WriteLine("U kunt maar 1 reservering plaatsen op dezelfde dag");
                            Console.WriteLine("vul een andere datum in: ");
                            datum = Console.ReadLine();
                            //vervangt het symbool ´/´ en spatie met het symbool `-`
                            foreach (var c in charsToRemove)
                            {
                                datum = datum.Replace(c, "-");
                            }
                        }
                    }
                    //als het ingevoerde datum gelijk is aan een datum in de json file
                    if (datum == tafelJson.datum[i])
                    {
                        //als het aantal zitplaatsen op dit datum gelijk/lager is dan 0
                        if (tafelJson.aantalPlaatsen[i] <= 0)
                        {
                            Console.WriteLine("op deze datum zijn er " + tafelJson.aantalPlaatsen[i] + " plekken beschikbaar waardoor u een andere datum zult moeten kiezen");
                            Console.WriteLine("vul een andere datum in: ");
                            datum = Console.ReadLine();
                            //vervangt het symbool ´/´ en spatie met het symbool `-`
                            foreach (var c in charsToRemove)
                            {
                                datum = datum.Replace(c, "-");
                            }
                        }
                        else
                        {
                            Console.WriteLine("op deze datum zijn er " + tafelJson.aantalPlaatsen[i] + " plekken beschikbaar");
                            Console.WriteLine("type(1) om door te gaan of type(2) om een andere datum te kiezen");
                            var datumKeuze = Console.ReadLine();
                            if (datumKeuze == "2")
                            {
                                Console.WriteLine("vul een andere datum in: ");
                                datum = Console.ReadLine();
                                //vervangt het symbool ´/´ en spatie met het symbool `-`
                                foreach (var c in charsToRemove)
                                {
                                    datum = datum.Replace(c, "-");
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
            //probeert het ingevoerde datum te veranderen naar datetime met als output resultDate
            bool timeCheck = DateTime.TryParse(datum, out resultDate);
            //als het omzetten naar Datetime is gelukt en het resultaat gelijk of hoger is dan de datum van vandaag en als de lengte van de datum gelijk is aan 10
            if (timeCheck == true && resultDate >= DateTime.Today && datum.Length == 10)
            {
                break;
            }
            //als het omzetten naar Datetime niet is gelukt of als de lengte van de datum lager is dan 10
            else if (timeCheck == false || datum.Length < 10)
            {
                Console.WriteLine("Vul een correcte datum in met getallen" + "\neen voorbeeld: 01-01-2020");
            }
            //als het resultaat lager is dan de datum van vandaag
            else if (resultDate < DateTime.Today)
            {
                Console.WriteLine("Vul geen oude datums in");
            }
        }

        while (true)
        {
            bool isNumeric = true;
            Console.WriteLine("vul een tijdstip in: ");
            tijdstip = Console.ReadLine();
            //loopt door elke getal van de input
            foreach (char c in tijdstip)
            {
                //als het geen getal is en niet gelijk is aan het symbool ':'
                if (!Char.IsDigit(c) && c != ':')
                {
                    isNumeric = false;
                }
                //als de lengte van de input niet groter is dan 5 of niet kleiner is dan 5
                if (tijdstip.Length > 5 || tijdstip.Length < 5)
                {
                    isNumeric = false;
                }
            }
            if (isNumeric == false)
            {
                Console.WriteLine("Vul een correcte tijdstip in met getallen" + "\neen voorbeeld: 10:30");
            }
            if (string.IsNullOrWhiteSpace(tijdstip) || string.IsNullOrEmpty(tijdstip))
            {
                Console.WriteLine("Dit vak moet ingevuld zijn");
            }
            if (isNumeric == true && !string.IsNullOrWhiteSpace(tijdstip) && !string.IsNullOrEmpty(tijdstip))
            {
                break;
            }
        }

        //code voor het aantal personen zodat er alleen getallen worden geaccepteerd als input
        while (true) 
        {
            bool isNumeric = true;
            Console.WriteLine("vul het aantal personen in: ");
            personen = Console.ReadLine();
            //loopt door elke getallen van de input
            foreach (char c in personen)
            {
                //als c geen cijfer is
                if (!Char.IsDigit(c))
                {
                    isNumeric = false;
                }
            }
            //als de input bestaat uit iets anders dan getallen
            if (isNumeric == false)
            {
                Console.WriteLine("voer alleen getallen in");
            }
            //als de input van de gebruiker leeg is of alleen bestaat uit spaties of gelijk is aan null
            if (string.IsNullOrWhiteSpace(personen) || string.IsNullOrEmpty(personen))
            {
                Console.WriteLine("Dit vak moet ingevuld zijn");
            }
            //als de input bestaat uit getallen en niet leeg is of alleen bestaat uit spaties of gelijk is aan null
            if (isNumeric == true && !string.IsNullOrWhiteSpace(personen) && !string.IsNullOrEmpty(personen))
            {
                personAmount = Int32.Parse(personen);
                if (tafelJson != null)
                {
                    for (int i = 0; i < tafelJson.aantalPlaatsen.Count; i++)
                    {
                        if (datum == tafelJson.datum[i]) 
                        {
                            int plaatsen = tafelJson.aantalPlaatsen[i];
                            int min = plaatsen -= personAmount;
                            bool minus = min < 0 ? true : false;
                            while (minus == true)
                            {
                                plaatsen = tafelJson.aantalPlaatsen[i];
                                Console.WriteLine("Het aantal beschikbare plekken op datum " + tafelJson.datum[i] + " is " + tafelJson.aantalPlaatsen[i] + " waardoor er niet genoeg plekken zijn\nu zult een nieuw aantal personen moeten invoeren");
                                Console.WriteLine("vul het aantal personen in: ");
                                personen = Console.ReadLine();
                                try
                                {
                                    personAmount = Int32.Parse(personen);
                                }
                                catch
                                {
                                    Console.WriteLine("voer alleen getallen in");
                                }
                                min = plaatsen -= personAmount;
                                minus = min < 0 ? true : false;
                            }
                            if (minus == false)
                            {
                                break;
                            }
                        }
                    }
                }   
                if (personAmount <= 0 || personAmount > 50)
                {
                    Console.WriteLine("het ingevoerde getal moet positief zijn en ook lager dan het maximum aantal zitplaatsen namelijk 50");
                }
                else if (personAmount > 0 && personAmount < 50)
                {
                    break;
                }
            }
        }

        //code voor de belangrijke details zodat er alleen maar letters(met eventueel spaties ertussen) worden geaccepteerd als input
        while (true)
        {
            bool isLetter = true;
            Console.WriteLine("vul hier belangrijke details in: ");
            details = Console.ReadLine();
            //loopt door elke letter van de input
            foreach (char c in details)
            {
                //als c geen letter is en ook niet gelijk is aan een spatie
                if (!Char.IsLetter(c) && c != ' ')
                {
                    isLetter = false;
                }
            }
            //als de input bestaat uit iets anders dan letters of spaties
            if (isLetter == false)
            {
                Console.WriteLine("Vul alleen letters in");
            }
            //als de input van de gebruiker leeg is of alleen bestaat uit spaties of gelijk is aan null
            if (string.IsNullOrWhiteSpace(details) || string.IsNullOrEmpty(details))
            {
                Console.WriteLine("Dit vak moet ingevuld zijn als u geen details wilt schrijven vul dan 'geen' in");
            }
            //als de input bestaat uit letters en niet leeg is of alleen bestaat uit spaties of gelijk is aan null
            if (isLetter == true && !string.IsNullOrWhiteSpace(details) && !string.IsNullOrEmpty(details))
            {
                break;
            }
        }

        Console.WriteLine("Uw reservering is aangemaakt!");
        Console.WriteLine("Type (1) voor het bekijken van uw reservering of (2) om uw reservering te wijzigen");
        reservering = Console.ReadLine(); 
        
        //maakt nieuwe lijsten aan
        resultJson.Datum = new List<string>();
        resultJson.Tijden = new List<string>();
        resultJson.Personen = new List<int>();
        resultJson.Details = new List<string>();
        resultJson.id = new List<int>();
        tafels.aantalPlaatsen = new List<int>();
        tafels.datum = new List<string>();
        tafels.id = new List<List<int>>();

        if (tafelJson != null)
        {
            for (int i = 0; i < tafelJson.aantalPlaatsen.Count; i++)
            {
                tafels.aantalPlaatsen.Add(tafelJson.aantalPlaatsen[i]);
                tafels.datum.Add(tafelJson.datum[i]);
                tafels.id.Add(tafelJson.id[i]);
            }
        }

        int indexGebruiker = 0;
        bool check = false;
        if (tafelJson != null)
        {
            for (int i = 0; i < tafelJson.datum.Count; i++)
            {
                if (datum == tafelJson.datum[i])
                {
                    indexGebruiker = i;
                    tafels.aantalPlaatsen[i] -= personAmount;
                    check = false;
                    tafels.id[i].Add(gebruikerIdJson.id[cijfer]);
                    break;  
                }
                else if (datum != tafelJson.datum[i])
                {
                    check = true;
                }
            }
        }

        if(check == true)
        {
            tafels.aantalPlaatsen.Add(50 - personAmount);
            tafels.datum.Add(datum);
            tafels.id.Add(new List<int> { gebruikerIdJson.id[cijfer] });
        }

        if (tafelJson == null)
        {
            tafels.aantalPlaatsen.Add(50 - personAmount);
            tafels.datum.Add(datum);
            tafels.id.Add(new List<int> { gebruikerIdJson.id[cijfer] });
        }

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
        //vult de lijsten met de ingevoerde gegevens
        resultJson.Datum.Add(datum);
        resultJson.Tijden.Add(tijdstip);
        resultJson.Personen.Add(personAmount);
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
            Console.WriteLine("Datum: " + datum);
            Console.WriteLine("Tijdstip: " + tijdstip);
            Console.WriteLine("Personen: " + personen);
            Console.WriteLine("Details: " + details + "\n");
        }
        else
        {
            Console.WriteLine("Uw nieuwe reservering");
            Console.WriteLine("Datum: " + datum);
            Console.WriteLine("Tijdstip: " + tijdstip);
            Console.WriteLine("Personen: " + personen);
            Console.WriteLine("Details: " + details + "\n");
            Console.WriteLine("Wilt u de datum wijzigen type (1), wilt u de tijdstip wijzigen type (2), wilt u het aantal personen wijzigen type (3), wilt u de belangrijke details wijzigen type(4), Wilt u alles wijzigen type(5)");
            var wijzigen = Console.ReadLine();
            if (wijzigen == "1")
            {
                Console.WriteLine("vul een nieuwe datum in");
                string datumGewijzigd = Console.ReadLine();
                resultJson.Datum[resultJson.Datum.Count - 1] = datumGewijzigd;
                if (check == true)
                {
                    tafels.aantalPlaatsen[tafelJson.aantalPlaatsen.Count] += personAmount;
                    tafels.id[tafelJson.id.Count].RemoveAt(tafelJson.id[tafelJson.id.Count - 1].Count - 1);
                }
                if (check == false)
                {
                    tafels.aantalPlaatsen[indexGebruiker] += personAmount;
                    tafels.id[indexGebruiker].RemoveAt(tafelJson.id[indexGebruiker].Count - 1);
                }             

                check = false;
                if (tafelJson != null)
                {
                    for (int i = 0; i < tafelJson.datum.Count; i++)
                    {
                        if (datumGewijzigd == tafelJson.datum[i])
                        {
                            tafels.aantalPlaatsen[i] -= personAmount;
                            check = false;
                            tafels.id[i].Add(gebruikerIdJson.id[cijfer]);
                            break;
                        }
                        else if (datumGewijzigd != tafelJson.datum[i])
                        {
                            check = true;
                        }
                    }
                }

                if (check == true)
                {
                    tafels.aantalPlaatsen.Add(50 - personAmount);
                    tafels.datum.Add(datumGewijzigd);
                    tafels.id.Add(new List<int> { gebruikerIdJson.id[cijfer] });
                }

                if (tafelJson == null)
                {
                    tafels.aantalPlaatsen.Add(50 - personAmount);
                    tafels.datum.Add(datumGewijzigd);
                    tafels.id.Add(new List<int> { gebruikerIdJson.id[cijfer] });
                }
            }
            if (wijzigen == "2")
            {
                Console.WriteLine("vul een nieuwe tijdstip in");
                string tijdenGewijzigd = Console.ReadLine();
                resultJson.Tijden[resultJson.Tijden.Count - 1] = tijdenGewijzigd;
            }
            if (wijzigen == "3")
            {
                Console.WriteLine("vul een nieuwe aantal personen in");
                var personenGewijzigd = Console.ReadLine();
                resultJson.Personen[resultJson.Personen.Count - 1] = Int32.Parse(personenGewijzigd);
                if (check == true)
                {
                    tafels.aantalPlaatsen[tafelJson.aantalPlaatsen.Count] += personAmount - Int32.Parse(personenGewijzigd);
                }
                if (check == false)
                {
                    tafels.aantalPlaatsen[indexGebruiker] += personAmount - Int32.Parse(personenGewijzigd);
                }
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
                resultJson.Datum[resultJson.Datum.Count - 1] = datumGewijzigd;
                Console.WriteLine("vul een nieuwe tijdstip in");
                string tijdenGewijzigd = Console.ReadLine();
                resultJson.Tijden[resultJson.Tijden.Count - 1] = tijdenGewijzigd;
                Console.WriteLine("vul een nieuwe aantal personen in");
                var personenGewijzigd = Console.ReadLine();
                resultJson.Personen[resultJson.Personen.Count - 1] = Int32.Parse(personenGewijzigd);
                Console.WriteLine("vul de nieuwe belangrijke details in");
                var detailsGewijzigd = Console.ReadLine();
                resultJson.Details[resultJson.Details.Count - 1] = detailsGewijzigd;

                if (check == true)
                {
                    tafels.aantalPlaatsen[tafelJson.aantalPlaatsen.Count] += personAmount;
                    tafels.id[tafelJson.id.Count].RemoveAt(tafelJson.id[tafelJson.id.Count-1].Count - 1);
                }
                if (check == false)
                {
                    tafels.aantalPlaatsen[indexGebruiker] += personAmount;
                    tafels.id[indexGebruiker].RemoveAt(tafelJson.id[indexGebruiker].Count - 1);
                }

                check = false;
                if (tafelJson != null)
                {
                    for (int i = 0; i < tafelJson.datum.Count; i++)
                    {
                        if (datumGewijzigd == tafelJson.datum[i])
                        {
                            tafels.aantalPlaatsen[i] -= Int32.Parse(personenGewijzigd);
                            check = false;
                            tafels.id[i].Add(gebruikerIdJson.id[cijfer]);
                            break;
                        }
                        else if (datumGewijzigd != tafelJson.datum[i])
                        {
                            check = true;
                        }
                    }
                }

                if (check == true)
                {
                    tafels.aantalPlaatsen.Add(50 - Int32.Parse(personenGewijzigd));
                    tafels.datum.Add(datumGewijzigd);
                    tafels.id.Add(new List<int> { gebruikerIdJson.id[cijfer] });
                }
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


//bij het aanpassen van de reservering moet de code van tekens invoeren in het begin geplakt worden