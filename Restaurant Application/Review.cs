using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
public class Review
{
    public void ReviewFunc()
    {
        string keuze;
        string gerecht;

        Console.WriteLine("Welkom in het review gedeelte!\n Wat wilt u doen?\n [1]. Review plaatsen voor een gerecht.\n [2]. Reviews bekijken.\n");
        keuze = Console.ReadLine();

        if (keuze == "1") //Review plaatsen voor een gerecht
        {
            Console.WriteLine("Voor welk gerecht wilt u een review plaatsen?");
            gerecht = Console.ReadLine();


            string jsonfile_gerechten = File.ReadAllText(@"gerechten.json");
            JsonClassGerechten gerechten = JsonConvert.DeserializeObject<JsonClassGerechten>(jsonfile_gerechten);
            //Hier worden alle gerechten uit de json file gelezen zodat het verder gebruikt kan worden.


            for (int i = 0; i < gerechten.maandag.Length; i++) //gerechten.maandag.Length omdat het even lang is als de rest van de dagen.
            {
                for (int j = 0; j < 1; j++)
                {
                    if (gerecht == gerechten.maandag[i][j])
                    {
                        Console.WriteLine("Dit gerecht staat in ons menu.");
                        break;
                    }
                    if (gerecht == gerechten.dinsdag[i][j])
                    {
                        Console.WriteLine("Dit gerecht staat in ons menu.");
                        break;
                    }
                    if (gerecht == gerechten.woensdag[i][j])
                    {
                        Console.WriteLine("Dit gerecht staat in ons menu.");
                        break;
                    }
                    if (gerecht == gerechten.donderdag[i][j])
                    {
                        Console.WriteLine("Dit gerecht staat in ons menu.");
                        break;
                    }
                    if (gerecht == gerechten.vrijdag[i][j])
                    {
                        Console.WriteLine("Dit gerecht staat in ons menu.");
                        break;
                    }
                    if (gerecht == gerechten.zaterdag[i][j])
                    {
                        Console.WriteLine("Dit gerecht staat in ons menu.");
                        break;
                    }
                    if (gerecht == gerechten.zondag[i][j])
                    {
                        Console.WriteLine("Dit gerecht staat in ons menu.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Dit gerecht staat helaas niet in ons menu.");
                        ReviewFunc();
                    }
                }
            }

            //Kijkt of de json file bestaat in dezelfde directory als het project.
            string search_jsonfile = @"reviews.json";
            var exist = File.Exists(search_jsonfile) ? true : false;

            //Als de json file niet bestaat in de project folder wordt aangemaakt en gevuld met 'null'.
            if (exist == false)
            {
                string jsonfile_reviews = JsonConvert.SerializeObject(null);
                File.WriteAllText(@"reviews.json", jsonfile_reviews);
            }




        }
        else if (keuze == "2") //Reviews bekijken
        {
            Console.WriteLine("Keuze2 is nog niet af");
        }
        else
        {
            Console.WriteLine("Vul een getal in tussen de 1 en 2\n");
            ReviewFunc();
        }
    }
}
