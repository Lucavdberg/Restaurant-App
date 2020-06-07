using System;
using Newtonsoft.Json;
using System.IO;
public class gerechten
{
    public void gerechtenFunc(string gerecht, JsonClassGerechten opzoekClass)
    {
        //kijkt of de json file bestaat in dezelfde directory als het project
        string curFile = @"gerechten.json";
        var exist = File.Exists(curFile) ? true : false;

        //de json file bestaat niet in het project folder en wordt aangemaakt en gevuld met null
        if (exist == false)
        {
            string lol = JsonConvert.SerializeObject(null);
            File.WriteAllText(@"gerechten.json", lol);
        }
        string buffer = File.ReadAllText(@"gerechten.json");
        JsonClassGerechten AdminGerechtenJson = JsonConvert.DeserializeObject<JsonClassGerechten>(buffer);
        bool gerechtenCheck = false;
        if (AdminGerechtenJson != null)
        {
            for (int i = 0; i < AdminGerechtenJson.maandag.Length; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    if (gerecht == AdminGerechtenJson.maandag[i][j])
                    {
                        Console.WriteLine("Dit gerecht staat in ons menu voor Maandag");
                        gerechtenCheck = true;
                    }
                }
            }
            for (int i = 0; i < AdminGerechtenJson.dinsdag.Length; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    if (gerecht == AdminGerechtenJson.dinsdag[i][j])
                    {
                        Console.WriteLine("Dit gerecht staat in ons menu voor Dinsdag");
                        gerechtenCheck = true;
                    }
                }
            }
            for (int i = 0; i < AdminGerechtenJson.woensdag.Length; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    if (gerecht == AdminGerechtenJson.woensdag[i][j])
                    {
                        Console.WriteLine("Dit gerecht staat in ons menu voor Woensdag");
                        gerechtenCheck = true;
                    }
                }
            }
            for (int i = 0; i < AdminGerechtenJson.donderdag.Length; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    if (gerecht == AdminGerechtenJson.donderdag[i][j])
                    {
                        Console.WriteLine("Dit gerecht staat in ons menu voor Donderdag");
                        gerechtenCheck = true;
                    }
                }
            }
            for (int i = 0; i < AdminGerechtenJson.vrijdag.Length; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    if (gerecht == AdminGerechtenJson.vrijdag[i][j])
                    {
                        Console.WriteLine("Dit gerecht staat in ons menu voor Vrijdag");
                        gerechtenCheck = true;
                    }
                }
            }
            for (int i = 0; i < AdminGerechtenJson.zaterdag.Length; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    if (gerecht == AdminGerechtenJson.zaterdag[i][j])
                    {
                        Console.WriteLine("Dit gerecht staat in ons menu voor Zaterdag");
                        gerechtenCheck = true;
                    }
                }
            }
            for (int i = 0; i < AdminGerechtenJson.zondag.Length; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    if (gerecht == AdminGerechtenJson.zondag[i][j])
                    {
                        Console.WriteLine("Dit gerecht staat in ons menu voor Zondag");
                        gerechtenCheck = true;
                    }
                }
            }

            if (gerechtenCheck == false)
            {
                Console.WriteLine("Dit gerecht staat helaas op dit moment niet in ons menu voor deze week");
            }
        }
        if (AdminGerechtenJson == null)
        {
            Console.WriteLine("De admin moet nog een menu toevoegen.");
        }
        Console.WriteLine("klik op een toets om terug te keren naar het hoofdmenu");
        Console.ReadKey();
    }
}