using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

public class Reservering 
{
    public void reserveringFunc(JsonClassReservering resultJson, JsonClassTafels tafels, int IdIngelogdPersoon)
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
        DateTime resultTime;
        Console.WriteLine(" Wat leuk dat u bij ons komt eten, om te reserveren moet u de volgende velden invullen.");
        while (true)
        {
            Console.WriteLine(" Datum: ");
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
                        while (datum == reserveringIdJson.Datum[j] && gebruikerIdJson.id[IdIngelogdPersoon] == reserveringIdJson.id[j])
                        {
                            Console.WriteLine(" U kunt maar 1 reservering plaatsen op dezelfde dag");
                            Console.WriteLine(" Vul alstublieft een andere datum in: ");
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
                            Console.WriteLine(" Op deze datum zijn er " + tafelJson.aantalPlaatsen[i] + " plekken beschikbaar waardoor u een andere datum zult moeten kiezen");
                            Console.WriteLine(" Vul alstublieft een andere datum in: ");
                            datum = Console.ReadLine();
                            //vervangt het symbool ´/´ en spatie met het symbool `-`
                            foreach (var c in charsToRemove)
                            {
                                datum = datum.Replace(c, "-");
                            }
                        }
                        else if (tafelJson.aantalPlaatsen[i] > 0 && tafelJson.aantalPlaatsen[i] <= 49)
                        {
                            Console.WriteLine(" Op deze datum zijn er " + tafelJson.aantalPlaatsen[i] + " plekken beschikbaar");
                             Console.WriteLine(" [1]. Doorgaan\n [2]. Andere datum selecteren\n");
                            var datumKeuze = Console.ReadLine();
                            if (datumKeuze == "2")
                            {
                                Console.WriteLine(" Vul alstublieft een andere datum in: ");
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
            //probeert de ingevoerde datum te veranderen naar datetime met als output resultDate
            bool timeCheck = DateTime.TryParse(datum, out resultDate);
            //als het omzetten naar Datetime is gelukt en het resultaat gelijk of hoger is dan de datum van vandaag en als de lengte van de datum gelijk is aan 10 en checkt of de reservering niet later dan een jaar vanaf nu wordt geplaatst
            if (timeCheck == true && resultDate >= DateTime.Today && datum.Length == 10 && resultDate <= DateTime.Today.AddYears(1))
            {
                break;
            }
            //als het omzetten naar Datetime niet is gelukt of als de lengte van de datum lager is dan 10
            else if (timeCheck == false || datum.Length < 10)
            {
                Console.WriteLine(" Onjuiste datum. Vul de datum in volgens dit format: " + DateTime.Today.ToString("dd-MM-yyyy") + ".\n");
            }
            //als het resultaat lager is dan de datum van vandaag
            else if (resultDate < DateTime.Today)
            {
                Console.WriteLine(" Deze datum is reeds verstreken, vul alstublieft een nieuwe datum in.\n");
            }
            else if (resultDate > DateTime.Today.AddYears(1))
            {
                Console.WriteLine(" U kunt alleen reserveren tussen nu en over een jaar, niet later dan dat.\n");
            }
        }

        while (true)
        {
            Console.WriteLine(" Tijdstip: ");
            tijdstip = Console.ReadLine();
            bool timeCheck1 = DateTime.TryParse(tijdstip, out resultTime);
            DateTime timeMin = DateTime.Parse("17:00:00");
            DateTime timeMax = DateTime.Parse("22:00:00");
            DateTime timeNow = DateTime.Now;
            if (resultTime < timeNow && resultDate == DateTime.Today)
            {
                Console.WriteLine(" U kunt niet in het verleden reserveren.");
            }
            else if (timeCheck1 == true && resultTime <= timeMax && resultTime >= timeMin)
            {
                break;
            }
            else if(timeCheck1 == false)
            {
                Console.WriteLine(" Onjuiste tijd. Vul het tijdstip in volgens dit format: 23:59\n");
            }
            else
            {
                Console.WriteLine(" Ons restaurant is open van 17:00 tot 00:00 en u kunt alleen reserveren tussen 17:00 en 22:00!\n");
            }
        }

        //code voor het aantal personen zodat er alleen getallen worden geaccepteerd als input
        while (true) 
        {
            bool isNumeric = true;
            Console.WriteLine(" Aantal personen: ");
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
                Console.WriteLine(" Voer het aantal personen in getallen in.");
            }
            //als de input van de gebruiker leeg is of alleen bestaat uit spaties of gelijk is aan null
            if (string.IsNullOrWhiteSpace(personen) || string.IsNullOrEmpty(personen))
            {
                Console.WriteLine(" Wij willen graag van u weten met hoeveel personen u komt eten.");
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
                                Console.WriteLine(" Het aantal beschikbare plekken op datum " + tafelJson.datum[i] + " is " + tafelJson.aantalPlaatsen[i] + " waardoor er niet genoeg plekken zijn\nu zult een nieuw aantal personen moeten invoeren");
                                Console.WriteLine(" Aantal personen: ");
                                personen = Console.ReadLine();
                                try
                                {
                                    personAmount = Int32.Parse(personen);
                                }
                                catch
                                {
                                    Console.WriteLine(" Voer het aantal personen in getallen in.");
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
                    Console.WriteLine(" Het ingevoerde getal moet positief zijn en ook lager dan het maximum aantal zitplaatsen namelijk: 50");
                }
                else if (personAmount > 0 && personAmount <= 50)
                {
                    break;
                }
            }
        }

        //code voor de belangrijke details zodat er alleen maar letters(met eventueel spaties ertussen) worden geaccepteerd als input
        while (true)
        {
            bool isLetter = true;
            Console.WriteLine(" Vul hier eventuele details in (verjaardag, allergiën, etc). Heeft u geen details, typ dan 'geen': ");
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
                Console.WriteLine(" Vul alleen letters in");
            }
            //als de input van de gebruiker leeg is of alleen bestaat uit spaties of gelijk is aan null
            if (string.IsNullOrWhiteSpace(details) || string.IsNullOrEmpty(details))
            {
                Console.WriteLine(" Dit vak moet ingevuld zijn als u geen details wilt schrijven vul dan 'geen' in");
            }
            //als de input bestaat uit letters en niet leeg is of alleen bestaat uit spaties of gelijk is aan null
            if (isLetter == true && !string.IsNullOrWhiteSpace(details) && !string.IsNullOrEmpty(details))
            {
                break;
            }
        }

        Console.WriteLine(" Uw reservering is aangemaakt!");
        Console.WriteLine(" [1]. Reservering bekijken\n [2]. Reservering wijzigen\n [3]. Terug naar de customer scherm\n");
        do
        {
            reservering = Console.ReadLine();
            if (reservering != "1" && reservering != "2" && reservering != "3")
            {
                Console.Clear();
                Console.WriteLine(" [1]. Reservering bekijken\n [2]. Reservering wijzigen\n [3]. Terug naar de customer scherm\n");
            }
        } while (reservering != "1" && reservering != "2" && reservering != "3");
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
                    tafels.id[i].Add(gebruikerIdJson.id[IdIngelogdPersoon]);
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
            tafels.id.Add(new List<int> { gebruikerIdJson.id[IdIngelogdPersoon] });
        }

        if (tafelJson == null)
        {
            tafels.aantalPlaatsen.Add(50 - personAmount);
            tafels.datum.Add(datum);
            tafels.id.Add(new List<int> { gebruikerIdJson.id[IdIngelogdPersoon] });
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
        resultJson.id.Add(gebruikerIdJson.id[IdIngelogdPersoon]);

        //de resultjson lijst zetten we om in een json file
        string strReserveringJson = JsonConvert.SerializeObject(resultJson);
        File.WriteAllText(@"reservering_id.json", strReserveringJson);

        string strTafelJson = JsonConvert.SerializeObject(tafels);
        File.WriteAllText(@"tafels.json", strTafelJson);

        if (reservering == "1")
        {
            Console.WriteLine(" Uw nieuwe reservering");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - -");
            Console.WriteLine(" Reservering datum:              " + datum);
            Console.WriteLine(" Reservering tijdstip:           " + tijdstip);
            Console.WriteLine(" Aantal personen aanwezig:       " + personen);
            Console.WriteLine(" Opmerkingen bij de reservering: " + details+ "\n");
        }
        else if (reservering == "2")
        {
            Console.Clear();
            Console.WriteLine(" Uw nieuwe reservering");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - -");
            Console.WriteLine(" Reservering datum:              " + datum);
            Console.WriteLine(" Reservering tijdstip:           " + tijdstip);
            Console.WriteLine(" Aantal personen aanwezig:       " + personen);
            Console.WriteLine(" Opmerkingen bij de reservering: " + details + "\n");
            Console.WriteLine(" [1]. Datum wijzigen\n [2]. Tijdstip wijzigen\n [3]. Aantal personen wijzigen\n [4]. Details wijzigen\n [5]. Alles wijzigen");
            string bufferFour = File.ReadAllText(@"tafels.json");
            JsonClassTafels tafelJsonTwo = JsonConvert.DeserializeObject<JsonClassTafels>(bufferFour);
            string bufferFive = File.ReadAllText(@"reservering_id.json");
            JsonClassReservering reserveringIdJsonTwo = JsonConvert.DeserializeObject<JsonClassReservering>(bufferFive);
            var wijzigen = Console.ReadLine();
            if (wijzigen == "1")
            {
                string datumGewijzigd;
                while (true)
                {
                    Console.WriteLine(" Datum: ");
                    datumGewijzigd = Console.ReadLine();
                    var charsToRemove = new string[] { "/", " " };
                    //vervangt het symbool (´/´) en (spatie) naar het symbool `-`
                    foreach (var c in charsToRemove)
                    {
                        datumGewijzigd = datumGewijzigd.Replace(c, "-");
                    }
                    if (tafelJsonTwo != null)
                    {
                        for (int i = 0; i < tafelJsonTwo.datum.Count; i++)
                        {
                            for (int j = 0; j < reserveringIdJsonTwo.Datum.Count; j++)
                            {
                                //zorgt ervoor dat een gebruiker niet op dezelfde dag nog een reservering kan plaatsen
                                while (datumGewijzigd == reserveringIdJsonTwo.Datum[j] && gebruikerIdJson.id[cijfer] == reserveringIdJsonTwo.id[j])
                                {
                                    Console.WriteLine(" U kunt maar 1 reservering plaatsen op dezelfde dag");
                                    Console.WriteLine(" Vul alstublieft een andere datum in: ");
                                    datumGewijzigd = Console.ReadLine();
                                    //vervangt het symbool ´/´ en spatie met het symbool `-`
                                    foreach (var c in charsToRemove)
                                    {
                                        datumGewijzigd = datumGewijzigd.Replace(c, "-");
                                    }
                                }
                            }
                            //als het ingevoerde datum gelijk is aan een datum in de json file
                            if (datumGewijzigd == tafelJsonTwo.datum[i])
                            {
                                //als het aantal zitplaatsen op dit datum gelijk/lager is dan 0
                                if (tafelJsonTwo.aantalPlaatsen[i] <= 0)
                                {
                                    Console.WriteLine(" Op deze datum zijn er " + tafelJsonTwo.aantalPlaatsen[i] + " plekken beschikbaar waardoor u een andere datum zult moeten kiezen");
                                    Console.WriteLine(" Vul alstublieft een andere datum in: ");
                                    datumGewijzigd = Console.ReadLine();
                                    //vervangt het symbool ´/´ en spatie met het symbool `-`
                                    foreach (var c in charsToRemove)
                                    {
                                        datumGewijzigd = datumGewijzigd.Replace(c, "-");
                                    }
                                }
                                else if (tafelJsonTwo.aantalPlaatsen[i] > 0 && tafelJsonTwo.aantalPlaatsen[i] <= 49)
                                {
                                    Console.WriteLine(" Op deze datum zijn er " + tafelJsonTwo.aantalPlaatsen[i] + " plekken beschikbaar");
                                    Console.WriteLine(" [1]. Doorgaan\n [2]. Andere datum selecteren\n");
                                    var datumKeuze = Console.ReadLine();
                                    if (datumKeuze == "2")
                                    {
                                        Console.WriteLine(" Vul alstublieft een andere datum in: ");
                                        datumGewijzigd = Console.ReadLine();
                                        //vervangt het symbool ´/´ en spatie met het symbool `-`
                                        foreach (var c in charsToRemove)
                                        {
                                            datumGewijzigd = datumGewijzigd.Replace(c, "-");
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
                    //probeert de ingevoerde datum te veranderen naar datetime met als output resultDate
                    bool timeCheck = DateTime.TryParse(datumGewijzigd, out resultDate);
                    //als het omzetten naar Datetime is gelukt en het resultaat gelijk of hoger is dan de datum van vandaag en als de lengte van de datum gelijk is aan 10 en checkt of de reservering niet later dan een jaar vanaf nu wordt geplaatst
                    if (timeCheck == true && resultDate >= DateTime.Today && datumGewijzigd.Length == 10 && resultDate <= DateTime.Today.AddYears(1))
                    {
                        break;
                    }
                    //als het omzetten naar Datetime niet is gelukt of als de lengte van de datum lager is dan 10
                    else if (timeCheck == false || datumGewijzigd.Length < 10)
                    {
                        Console.WriteLine(" Onjuiste datum. Vul de datum in volgens dit format: " + DateTime.Today.ToString("dd-MM-yyyy") + ".\n");
                    }
                    //als het resultaat lager is dan de datum van vandaag
                    else if (resultDate < DateTime.Today)
                    {
                        Console.WriteLine(" Deze datum is reeds verstreken, vul alstublieft een nieuwe datum in.\n");
                    }
                    else if (resultDate > DateTime.Today.AddYears(1))
                    {
                        Console.WriteLine(" U kunt alleen reserveren tussen nu en over een jaar, niet later dan dat.\n");
                    }
                }
                resultJson.Datum[resultJson.Datum.Count - 1] = datumGewijzigd;
                if (check == true)
                {
                    tafels.aantalPlaatsen[tafelJsonTwo.aantalPlaatsen.Count-1] += personAmount;
                    if ((tafelJsonTwo.id[tafelJsonTwo.id.Count - 1].Count - 1) == -1)
                    {
                        tafels.id[tafelJsonTwo.id.Count].RemoveAt(tafelJsonTwo.id[tafelJsonTwo.id.Count - 1].Count);
                    }
                    else
                    {
                        tafels.id[tafelJsonTwo.id.Count-1].RemoveAt(tafelJsonTwo.id[tafelJsonTwo.id.Count - 1].Count - 1);
                    }
                }
                if (check == false)
                {
                    tafels.aantalPlaatsen[indexGebruiker] += personAmount;
                    tafels.id[indexGebruiker].RemoveAt(tafelJsonTwo.id[indexGebruiker].Count - 1);
                }             

                check = false;
                if (tafelJsonTwo != null)
                {
                    for (int i = 0; i < tafelJsonTwo.datum.Count; i++)
                    {
                        if (datumGewijzigd == tafelJsonTwo.datum[i])
                        {
                            tafels.aantalPlaatsen[i] -= personAmount;
                            check = false;
                            tafels.id[i].Add(gebruikerIdJson.id[IdIngelogdPersoon]);
                            break;
                        }
                        else if (datumGewijzigd != tafelJsonTwo.datum[i])
                        {
                            check = true;
                        }
                    }
                }

                Console.WriteLine("check: " + check);
                if (check == true)
                {
                    tafels.aantalPlaatsen.Add(50 - personAmount);
                    tafels.datum.Add(datumGewijzigd);
                    tafels.id.Add(new List<int> { gebruikerIdJson.id[IdIngelogdPersoon] });
                }

                if (tafelJsonTwo == null)
                {
                    tafels.aantalPlaatsen.Add(50 - personAmount);
                    tafels.datum.Add(datumGewijzigd);
                    tafels.id.Add(new List<int> { gebruikerIdJson.id[IdIngelogdPersoon] });
                }
            }
            if (wijzigen == "2")
            {
                string tijdenGewijzigd;
                while (true)
                {
                    Console.WriteLine(" Tijdstip: ");
                    tijdenGewijzigd = Console.ReadLine();
                    bool timeCheck1 = DateTime.TryParse(tijdenGewijzigd, out resultTime);
                    DateTime timeMin = DateTime.Parse("17:00:00");
                    DateTime timeMax = DateTime.Parse("22:00:00");
                    if (timeCheck1 == true && resultTime <= timeMax && resultTime >= timeMin)
                    {
                        break;
                    }
                    else if (timeCheck1 == false)
                    {
                        Console.WriteLine(" Onjuiste tijd. Vul het tijdstip in volgens dit format: 23:59\n");
                    }
                    else
                    {
                        Console.WriteLine(" Ons restaurant is open van 17:00 tot 00:00 en u kunt alleen reserveren tussen 17:00 en 22:00!\n");
                    }
                }
                resultJson.Tijden[resultJson.Tijden.Count - 1] = tijdenGewijzigd;
            }
            if (wijzigen == "3")
            {
                //code voor het aantal personen zodat er alleen getallen worden geaccepteerd als input
                string personenGewijzigd;
                while (true)
                {
                    bool isNumeric = true;
                    Console.WriteLine(" Aantal personen: ");
                    personenGewijzigd = Console.ReadLine();
                    //loopt door elke getallen van de input
                    foreach (char c in personenGewijzigd)
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
                        Console.WriteLine(" Voer het aantal personen in getallen in.");
                    }
                    //als de input van de gebruiker leeg is of alleen bestaat uit spaties of gelijk is aan null
                    if (string.IsNullOrWhiteSpace(personenGewijzigd) || string.IsNullOrEmpty(personenGewijzigd))
                    {
                        Console.WriteLine(" Wij willen graag van u weten met hoeveel personen u komt eten.");
                    }
                    //als de input bestaat uit getallen en niet leeg is of alleen bestaat uit spaties of gelijk is aan null
                    if (isNumeric == true && !string.IsNullOrWhiteSpace(personenGewijzigd) && !string.IsNullOrEmpty(personenGewijzigd))
                    {
                        personAmount = Int32.Parse(personenGewijzigd);
                        if (tafelJsonTwo != null)
                        {
                            for (int i = 0; i < tafelJsonTwo.aantalPlaatsen.Count; i++)
                            {
                                if (datum == tafelJsonTwo.datum[i])
                                {
                                    int plaatsen = tafelJsonTwo.aantalPlaatsen[i];
                                    int min = plaatsen -= personAmount;
                                    bool minus = min < 0 ? true : false;
                                    while (minus == true)
                                    {
                                        plaatsen = tafelJsonTwo.aantalPlaatsen[i];
                                        Console.WriteLine(" Het aantal beschikbare plekken op datum " + tafelJsonTwo.datum[i] + " is " + tafelJsonTwo.aantalPlaatsen[i] + " waardoor er niet genoeg plekken zijn\nu zult een nieuw aantal personen moeten invoeren");
                                        Console.WriteLine(" Aantal personen: ");
                                        personenGewijzigd = Console.ReadLine();
                                        try
                                        {
                                            personAmount = Int32.Parse(personenGewijzigd);
                                        }
                                        catch
                                        {
                                            Console.WriteLine(" Voer het aantal personen in getallen in.");
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
                            Console.WriteLine(" Het ingevoerde getal moet positief zijn en ook lager dan het maximum aantal zitplaatsen namelijk: 50");
                        }
                        else if (personAmount > 0 && personAmount <= 50)
                        {
                            break;
                        }
                    }
                }
                resultJson.Personen[resultJson.Personen.Count - 1] = Int32.Parse(personenGewijzigd);
                if (check == true)
                {
                    tafels.aantalPlaatsen[tafelJsonTwo.aantalPlaatsen.Count] += Int32.Parse(personen) - personAmount;
                }
                if (check == false)
                {
                    tafels.aantalPlaatsen[indexGebruiker] += Int32.Parse(personen) - personAmount;
                }
            }
            if (wijzigen == "4")
            {
                //code voor de belangrijke details zodat er alleen maar letters(met eventueel spaties ertussen) worden geaccepteerd als input
                string detailsGewijzigd;
                while (true)
                {
                    bool isLetter = true;
                    Console.WriteLine(" Vul hier eventuele details in (verjaardag, allergiën, etc). Heeft u geen details, typ dan 'geen': ");
                    detailsGewijzigd = Console.ReadLine();
                    //loopt door elke letter van de input
                    foreach (char c in detailsGewijzigd)
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
                        Console.WriteLine(" Vul alleen letters in");
                    }
                    //als de input van de gebruiker leeg is of alleen bestaat uit spaties of gelijk is aan null
                    if (string.IsNullOrWhiteSpace(detailsGewijzigd) || string.IsNullOrEmpty(detailsGewijzigd))
                    {
                        Console.WriteLine(" Dit vak moet ingevuld zijn als u geen details wilt schrijven vul dan 'geen' in");
                    }
                    //als de input bestaat uit letters en niet leeg is of alleen bestaat uit spaties of gelijk is aan null
                    if (isLetter == true && !string.IsNullOrWhiteSpace(detailsGewijzigd) && !string.IsNullOrEmpty(detailsGewijzigd))
                    {
                        break;
                    }
                }
                resultJson.Details[resultJson.Details.Count - 1] = detailsGewijzigd;
            }
            if (wijzigen == "5")
            {
                string datumGewijzigd;
                while (true)
                {
                    Console.WriteLine(" Datum: ");
                    datumGewijzigd = Console.ReadLine();
                    var charsToRemove = new string[] { "/", " " };
                    //vervangt het symbool (´/´) en (spatie) naar het symbool `-`
                    foreach (var c in charsToRemove)
                    {
                        datumGewijzigd = datumGewijzigd.Replace(c, "-");
                    }
                    if (tafelJsonTwo != null)
                    {
                        for (int i = 0; i < tafelJsonTwo.datum.Count; i++)
                        {
                            for (int j = 0; j < reserveringIdJsonTwo.Datum.Count; j++)
                            {
                                //zorgt ervoor dat een gebruiker niet op dezelfde dag nog een reservering kan plaatsen
                                while (datumGewijzigd == reserveringIdJsonTwo.Datum[j] && gebruikerIdJson.id[cijfer] == reserveringIdJsonTwo.id[j])
                                {
                                    Console.WriteLine(" U kunt maar 1 reservering plaatsen op dezelfde dag");
                                    Console.WriteLine(" Vul alstublieft een andere datum in: ");
                                    datumGewijzigd = Console.ReadLine();
                                    //vervangt het symbool ´/´ en spatie met het symbool `-`
                                    foreach (var c in charsToRemove)
                                    {
                                        datumGewijzigd = datumGewijzigd.Replace(c, "-");
                                    }
                                }
                            }
                            //als het ingevoerde datum gelijk is aan een datum in de json file
                            if (datumGewijzigd == tafelJsonTwo.datum[i])
                            {
                                //als het aantal zitplaatsen op dit datum gelijk/lager is dan 0
                                if (tafelJsonTwo.aantalPlaatsen[i] <= 0)
                                {
                                    Console.WriteLine(" Op deze datum zijn er " + tafelJsonTwo.aantalPlaatsen[i] + " plekken beschikbaar waardoor u een andere datum zult moeten kiezen");
                                    Console.WriteLine(" Vul alstublieft een andere datum in: ");
                                    datumGewijzigd = Console.ReadLine();
                                    //vervangt het symbool ´/´ en spatie met het symbool `-`
                                    foreach (var c in charsToRemove)
                                    {
                                        datumGewijzigd = datumGewijzigd.Replace(c, "-");
                                    }
                                }
                                else if (tafelJsonTwo.aantalPlaatsen[i] > 0 && tafelJsonTwo.aantalPlaatsen[i] <= 49)
                                {
                                    Console.WriteLine(" Op deze datum zijn er " + tafelJsonTwo.aantalPlaatsen[i] + " plekken beschikbaar");
                                    Console.WriteLine(" [1]. Doorgaan\n [2]. Andere datum selecteren\n");
                                    var datumKeuze = Console.ReadLine();
                                    if (datumKeuze == "2")
                                    {
                                        Console.WriteLine(" Vul alstublieft een andere datum in: ");
                                        datumGewijzigd = Console.ReadLine();
                                        //vervangt het symbool ´/´ en spatie met het symbool `-`
                                        foreach (var c in charsToRemove)
                                        {
                                            datumGewijzigd = datumGewijzigd.Replace(c, "-");
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
                    //probeert de ingevoerde datum te veranderen naar datetime met als output resultDate
                    bool timeCheck = DateTime.TryParse(datumGewijzigd, out resultDate);
                    //als het omzetten naar Datetime is gelukt en het resultaat gelijk of hoger is dan de datum van vandaag en als de lengte van de datum gelijk is aan 10 en checkt of de reservering niet later dan een jaar vanaf nu wordt geplaatst
                    if (timeCheck == true && resultDate >= DateTime.Today && datumGewijzigd.Length == 10 && resultDate <= DateTime.Today.AddYears(1))
                    {
                        break;
                    }
                    //als het omzetten naar Datetime niet is gelukt of als de lengte van de datum lager is dan 10
                    else if (timeCheck == false || datumGewijzigd.Length < 10)
                    {
                        Console.WriteLine(" Onjuiste datum. Vul de datum in volgens dit format: " + DateTime.Today.ToString("dd-MM-yyyy") + ".\n");
                    }
                    //als het resultaat lager is dan de datum van vandaag
                    else if (resultDate < DateTime.Today)
                    {
                        Console.WriteLine(" Deze datum is reeds verstreken, vul alstublieft een nieuwe datum in.\n");
                    }
                    else if (resultDate > DateTime.Today.AddYears(1))
                    {
                        Console.WriteLine(" U kunt alleen reserveren tussen nu en over een jaar, niet later dan dat.\n");
                    }
                }
                resultJson.Datum[resultJson.Datum.Count - 1] = datumGewijzigd;

                string tijdenGewijzigd;
                while (true)
                {
                    Console.WriteLine(" Tijdstip: ");
                    tijdenGewijzigd = Console.ReadLine();
                    bool timeCheck1 = DateTime.TryParse(tijdenGewijzigd, out resultTime);
                    DateTime timeMin = DateTime.Parse("17:00:00");
                    DateTime timeMax = DateTime.Parse("22:00:00");
                    if (timeCheck1 == true && resultTime <= timeMax && resultTime >= timeMin)
                    {
                        break;
                    }
                    else if (timeCheck1 == false)
                    {
                        Console.WriteLine(" Onjuiste tijd. Vul het tijdstip in volgens dit format: 23:59\n");
                    }
                    else
                    {
                        Console.WriteLine(" Ons restaurant is open van 17:00 tot 00:00 en u kunt alleen reserveren tussen 17:00 en 22:00!\n");
                    }
                }
                resultJson.Tijden[resultJson.Tijden.Count - 1] = tijdenGewijzigd;

                //code voor het aantal personen zodat er alleen getallen worden geaccepteerd als input
                string personenGewijzigd;
                while (true)
                {
                    bool isNumeric = true;
                    Console.WriteLine(" Aantal personen: ");
                    personenGewijzigd = Console.ReadLine();
                    //loopt door elke getallen van de input
                    foreach (char c in personenGewijzigd)
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
                        Console.WriteLine(" Voer het aantal personen in getallen in.");
                    }
                    //als de input van de gebruiker leeg is of alleen bestaat uit spaties of gelijk is aan null
                    if (string.IsNullOrWhiteSpace(personenGewijzigd) || string.IsNullOrEmpty(personenGewijzigd))
                    {
                        Console.WriteLine(" Wij willen graag van u weten met hoeveel personen u komt eten.");
                    }
                    //als de input bestaat uit getallen en niet leeg is of alleen bestaat uit spaties of gelijk is aan null
                    if (isNumeric == true && !string.IsNullOrWhiteSpace(personenGewijzigd) && !string.IsNullOrEmpty(personenGewijzigd))
                    {
                        personAmount = Int32.Parse(personenGewijzigd);
                        if (tafelJsonTwo != null)
                        {
                            for (int i = 0; i < tafelJsonTwo.aantalPlaatsen.Count; i++)
                            {
                                if (datum == tafelJsonTwo.datum[i])
                                {
                                    int plaatsen = tafelJsonTwo.aantalPlaatsen[i];
                                    int min = plaatsen -= personAmount;
                                    bool minus = min < 0 ? true : false;
                                    while (minus == true)
                                    {
                                        plaatsen = tafelJsonTwo.aantalPlaatsen[i];
                                        Console.WriteLine(" Het aantal beschikbare plekken op datum " + tafelJsonTwo.datum[i] + " is " + tafelJsonTwo.aantalPlaatsen[i] + " waardoor er niet genoeg plekken zijn\nu zult een nieuw aantal personen moeten invoeren");
                                        Console.WriteLine(" Aantal personen: ");
                                        personenGewijzigd = Console.ReadLine();
                                        try
                                        {
                                            personAmount = Int32.Parse(personenGewijzigd);
                                        }
                                        catch
                                        {
                                            Console.WriteLine(" Voer het aantal personen in getallen in.");
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
                            Console.WriteLine(" Het ingevoerde getal moet positief zijn en ook lager dan het maximum aantal zitplaatsen namelijk: 50");
                        }
                        else if (personAmount > 0 && personAmount <= 50)
                        {
                            break;
                        }
                    }
                }
                resultJson.Personen[resultJson.Personen.Count - 1] = Int32.Parse(personenGewijzigd);

                //code voor de belangrijke details zodat er alleen maar letters(met eventueel spaties ertussen) worden geaccepteerd als input
                string detailsGewijzigd;
                while (true)
                {
                    bool isLetter = true;
                    Console.WriteLine(" Vul hier eventuele details in (verjaardag, allergiën, etc). Heeft u geen details, typ dan 'geen': ");
                    detailsGewijzigd = Console.ReadLine();
                    //loopt door elke letter van de input
                    foreach (char c in detailsGewijzigd)
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
                        Console.WriteLine(" Vul alleen letters in");
                    }
                    //als de input van de gebruiker leeg is of alleen bestaat uit spaties of gelijk is aan null
                    if (string.IsNullOrWhiteSpace(detailsGewijzigd) || string.IsNullOrEmpty(detailsGewijzigd))
                    {
                        Console.WriteLine(" Dit vak moet ingevuld zijn als u geen details wilt schrijven vul dan 'geen' in");
                    }
                    //als de input bestaat uit letters en niet leeg is of alleen bestaat uit spaties of gelijk is aan null
                    if (isLetter == true && !string.IsNullOrWhiteSpace(detailsGewijzigd) && !string.IsNullOrEmpty(detailsGewijzigd))
                    {
                        break;
                    }
                }
                resultJson.Details[resultJson.Details.Count - 1] = detailsGewijzigd;

                if (check == true)
                {
                    tafels.aantalPlaatsen[tafelJsonTwo.aantalPlaatsen.Count-1] += Int32.Parse(personen);
                    if ((tafelJsonTwo.id[tafelJsonTwo.id.Count - 1].Count - 1) == -1) 
                    {
                        tafels.id[tafelJsonTwo.id.Count].RemoveAt(tafelJsonTwo.id[tafelJsonTwo.id.Count - 1].Count);
                    }
                    else
                    {
                        tafels.id[tafelJsonTwo.id.Count-1].RemoveAt(tafelJsonTwo.id[tafelJsonTwo.id.Count - 1].Count - 1);
                    }
                }
                if (check == false)
                {
                    tafels.aantalPlaatsen[indexGebruiker] += Int32.Parse(personen);
                    tafels.id[indexGebruiker].RemoveAt(tafelJsonTwo.id[indexGebruiker].Count - 1);
                }

                check = false;
                if (tafelJsonTwo != null)
                {
                    for (int i = 0; i < tafelJsonTwo.datum.Count; i++)
                    {
                        if (datumGewijzigd == tafelJsonTwo.datum[i])
                        {
                            tafels.aantalPlaatsen[i] -= Int32.Parse(personenGewijzigd);
                            check = false;
                            tafels.id[i].Add(gebruikerIdJson.id[IdIngelogdPersoon]);
                            break;
                        }
                        else if (datumGewijzigd != tafelJsonTwo.datum[i])
                        {
                            check = true;
                        }
                    }
                }

                if (check == true)
                {
                    tafels.aantalPlaatsen.Add(50 - Int32.Parse(personenGewijzigd));
                    tafels.datum.Add(datumGewijzigd);
                    tafels.id.Add(new List<int> { gebruikerIdJson.id[IdIngelogdPersoon] });
                }
            }
            string strNieuweReserveringJson = JsonConvert.SerializeObject(resultJson);
            File.WriteAllText(@"reservering_id.json", strNieuweReserveringJson);
            string nieuweReservering = File.ReadAllText(@"reservering_id.json");
            JsonClassReservering nieuweReserveringIdJson = JsonConvert.DeserializeObject<JsonClassReservering>(nieuweReservering);

            Console.WriteLine("Dit zijn uw nieuwe gegevens");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - -");
            Console.WriteLine(" Reservering datum:              " + nieuweReserveringIdJson.Datum[nieuweReserveringIdJson.Datum.Count - 1]);
            Console.WriteLine(" Reservering tijdstip:           " + nieuweReserveringIdJson.Tijden[nieuweReserveringIdJson.Tijden.Count - 1]);
            Console.WriteLine(" Aantal personen aanwezig:       " + nieuweReserveringIdJson.Personen[nieuweReserveringIdJson.Personen.Count - 1].ToString());
            Console.WriteLine(" Opmerkingen bij de reservering: " + nieuweReserveringIdJson.Details[nieuweReserveringIdJson.Details.Count - 1] + "\n");   
        }
        else if (reservering == "3")
        {

        }
        string strNieuweTafelJson = JsonConvert.SerializeObject(tafels);
        File.WriteAllText(@"tafels.json", strNieuweTafelJson);
        Console.WriteLine("klik op een toets om terug te keren naar de customer scherm");
        Console.ReadKey();
    }
}
