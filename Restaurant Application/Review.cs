using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Threading;

public class Review
{
    public void ReviewFunc()
    {
        Console.Clear();
        JsonClassReview reviewJson = new JsonClassReview();

        string keuze;
        Console.WriteLine("Welkom in het review gedeelte!\n Wat wilt u doen?\n  [1]. Review plaatsen voor een gerecht.\n  [2]. Reviews bekijken.\n  [X]. Terug naar het Hoofdmenu.");
        keuze = Console.ReadLine();

        if (keuze == "1") //Review plaatsen voor een gerecht.
        {
            Console.Clear();
            //Hier worden alle gerechten uit de json file gelezen zodat het verder gebruikt kan worden voor het opzoeken.
            string jsonfile_gerechten = File.ReadAllText(@"gerechten.json");
            JsonClassGerechten gerechten = JsonConvert.DeserializeObject<JsonClassGerechten>(jsonfile_gerechten);

            for (int i = 0; i < gerechten.maandag.Length; i++) //gerechten.maandag.Length omdat het even lang is als de rest van de dagen.
            {
                for (int j = 0; j < 1; j++)
                {
                    Console.WriteLine(gerechten.maandag[i][j]);
                    Console.WriteLine(gerechten.dinsdag[i][j]);
                    Console.WriteLine(gerechten.woensdag[i][j]);
                    Console.WriteLine(gerechten.donderdag[i][j]);
                    Console.WriteLine(gerechten.vrijdag[i][j]);
                    Console.WriteLine(gerechten.zaterdag[i][j]);
                    Console.WriteLine(gerechten.zondag[i][j]);
                }
            }

            Console.WriteLine("\nBekijk de gerechten hierboven.\n (Druk op een toets om verder te gaan met de review).");
            Console.ReadKey();

            //Kijkt of de json file bestaat in dezelfde directory als het project.
            string search_jsonfile = @"reviews.json";
            var exist = File.Exists(search_jsonfile) ? true : false;

            //Als de json file niet bestaat in de project folder wordt aangemaakt en gevuld met 'null'.
            if (exist == false)
            {
                string existance = JsonConvert.SerializeObject(null);
                File.WriteAllText(@"reviews.json", existance);
            }

            //Hier worden de reviews uit de json file gelezen zodat het verder gebruikt kan worden.
            string jsonfile_review = File.ReadAllText(@"reviews.json");
            JsonClassReview reviews = JsonConvert.DeserializeObject<JsonClassReview>(jsonfile_review);

            string naam = "";
            string gerecht = "";
            string review = "";
            int score = 0;

            Console.Clear();
            Console.WriteLine("Bij het plaatsen van een review zullen wij u drie vragen stellen.");

            Console.WriteLine("\nWat is uw naam?");
            naam = Console.ReadLine();
            Console.WriteLine("Voor welk gerecht wilt u een review plaatsen?");
            gerecht = Console.ReadLine();
            Console.WriteLine("Schrijf hier uw review (probeer het kort en bondig te houden).");
            review = Console.ReadLine();
            Console.WriteLine("Wat voor cijfer geeft u dit gerecht op basis van 1 tot 10?");
            score = Convert.ToInt32(Console.ReadLine());

            reviewJson.Naam = new List<string>();
            reviewJson.Gerecht = new List<string>();
            reviewJson.Review = new List<string>();
            reviewJson.Score = new List<int>();

            //Zorgt ervoor dat de nieuwe review erbij komt en niet word overschreven.
            if (reviews != null)
            {
                for (int i = 0; i < reviews.Naam.Count; i++)
                {
                    reviewJson.Naam.Add(reviews.Naam[i]);
                    reviewJson.Gerecht.Add(reviews.Gerecht[i]);
                    reviewJson.Review.Add(reviews.Review[i]);
                    reviewJson.Score.Add(reviews.Score[i]);
                }
            }

            reviewJson.Naam.Add(naam);
            reviewJson.Gerecht.Add(gerecht);
            reviewJson.Review.Add(review);
            reviewJson.Score.Add(score);

            //Hier worden de ingevulde gegevens opgeslagen in de json file.
            string strResultJson = JsonConvert.SerializeObject(reviewJson);
            File.WriteAllText(@"reviews.json", strResultJson);


        }
        else if (keuze == "2") //Reviews bekijken
        {
            Console.Clear();
            string jsonfile_review = File.ReadAllText(@"reviews.json");
            JsonClassReview reviews = JsonConvert.DeserializeObject<JsonClassReview>(jsonfile_review);

            for (int i = 0; i < reviews.Naam.Count; i++) //Naam omdat Count overal hetzelfde is. 
            {
                Console.WriteLine("Naam: " + reviews.Naam[i]);
                Console.WriteLine("Gerecht: " + reviews.Gerecht[i]);
                Console.WriteLine("Review: " + reviews.Review[i]);
                Console.WriteLine("Score: " + reviews.Score[i] + "\n");
            }

        }
        else if (keuze == "x" || keuze == "X") //Terug naar het hoofdmenu
        {
            
        }
        else
        {
            Console.WriteLine("Vul een getal in tussen de 1 en 2\n");
            ReviewFunc();
        }


    }
}
