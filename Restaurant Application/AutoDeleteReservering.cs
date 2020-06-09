using System;
using Newtonsoft.Json;
using System.IO;

public class AutoDeleteReservering
{
    public void AutoDeleteReserveringFunc()
    {
        //kijkt of de json file bestaat in dezelfde directory als het project
        string curFile = @"reservering_id.json";
        var exist = File.Exists(curFile) ? true : false;

        //de json file bestaat niet in het project folder en wordt aangemaakt en gevuld met null
        if (exist == false)
        {
            string existance = JsonConvert.SerializeObject(null);
            File.WriteAllText(@"reservering_id.json", existance);
        }

        string buffer = File.ReadAllText(@"reservering_id.json");
        JsonClassReservering reserveringIdJson = JsonConvert.DeserializeObject<JsonClassReservering>(buffer);

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

        if (reserveringIdJson != null)
        {
            string gekozenDatum = "";
            int gekozenPersonen = 0;
            int gekozenID = 0;
            var vandaag = DateTime.Now;
            DateTime resultTime;
            for (int i = 0; i < reserveringIdJson.Datum.Count; i++)
            {
                bool reserveringstijd = DateTime.TryParse(reserveringIdJson.Datum[i] + " " + reserveringIdJson.Tijden[i] + ":00", out resultTime);
                var resultTimeTwo = resultTime.AddHours(2);
                if (vandaag >= resultTimeTwo)
                {
                    gekozenDatum = reserveringIdJson.Datum[i];
                    gekozenPersonen = reserveringIdJson.Personen[i];
                    gekozenID = reserveringIdJson.id[i];
                    reserveringIdJson.id.RemoveAt(i);
                    reserveringIdJson.Datum.RemoveAt(i);
                    reserveringIdJson.Tijden.RemoveAt(i);
                    reserveringIdJson.Personen.RemoveAt(i);
                    reserveringIdJson.Details.RemoveAt(i);
                    i--;
                }
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

            string strNieuweReserveringJson = JsonConvert.SerializeObject(reserveringIdJson);
            File.WriteAllText(@"reservering_id.json", strNieuweReserveringJson);

            string strNieuweTafelJson = JsonConvert.SerializeObject(tafelJson);
            File.WriteAllText(@"tafels.json", strNieuweTafelJson);
        }
    }
}