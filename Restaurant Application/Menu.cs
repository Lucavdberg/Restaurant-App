using System;
using Newtonsoft.Json;
using System.IO;

public class Menu
{

    public void MenuVanDeDagFunc(string day, JsonClassGerechten gerechtClass)
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
        if (AdminGerechtenJson != null)
        {
            if (day == "maandag" || day == "Maandag" || day == "menu maandag" || day == "het menu van maandag")
            {
                for (int i = 0; i < AdminGerechtenJson.maandag.Length; i++)
                {
                    for (int j = 0; j < AdminGerechtenJson.maandag[i].Length; j++)
                    {
                        Console.WriteLine(AdminGerechtenJson.maandag[i][j]);
                    }
                }
            }
            else if (day == "dinsdag" || day == "Dinsdag" || day == "menu dinsdag" || day == "het menu van dinsdag")
            {
                for (int i = 0; i < AdminGerechtenJson.dinsdag.Length; i++)
                {
                    for (int j = 0; j < AdminGerechtenJson.dinsdag[i].Length; j++)
                    {
                        Console.WriteLine(AdminGerechtenJson.dinsdag[i][j]);
                    }
                }
            }
            else if (day == "woensdag" || day == "Woensdag" || day == "menu woensdag" || day == "het menu van woensdag")
            {
                for (int i = 0; i < AdminGerechtenJson.woensdag.Length; i++)
                {
                    for (int j = 0; j < AdminGerechtenJson.woensdag[i].Length; j++)
                    {
                        Console.WriteLine(AdminGerechtenJson.woensdag[i][j]);
                    }
                }
            }
            else if (day == "donderdag" || day == "Donderdag" || day == "menu donderdag" || day == "het menu van donderdag")
            {
                for (int i = 0; i < AdminGerechtenJson.donderdag.Length; i++)
                {
                    for (int j = 0; j < AdminGerechtenJson.donderdag[i].Length; j++)
                    {
                        Console.WriteLine(AdminGerechtenJson.donderdag[i][j]);
                    }
                }
            }
            else if (day == "vrijdag" || day == "Vrijdag" || day == "menu vrijdag" || day == "het menu van vrijdag")
            {
                for (int i = 0; i < AdminGerechtenJson.vrijdag.Length; i++)
                {
                    for (int j = 0; j < AdminGerechtenJson.vrijdag[i].Length; j++)
                    {
                        Console.WriteLine(AdminGerechtenJson.vrijdag[i][j]);
                    }
                }
            }
            else if (day == "zaterdag" || day == "Zaterdag" || day == "menu zaterdag" || day == "het menu van zaterdag")
            {
                for (int i = 0; i < AdminGerechtenJson.zaterdag.Length; i++)
                {
                    for (int j = 0; j < AdminGerechtenJson.zaterdag[i].Length; j++)
                    {
                        Console.WriteLine(AdminGerechtenJson.zaterdag[i][j]);
                    }
                }
            }
            else if (day == "zondag" || day == "Zondag" || day == "menu zondag" || day == "het menu van zondag")
            {
                for (int i = 0; i < AdminGerechtenJson.zondag.Length; i++)
                {
                    for (int j = 0; j < AdminGerechtenJson.zondag[i].Length; j++)
                    {
                        Console.WriteLine(AdminGerechtenJson.zondag[i][j]);
                    }
                }
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

