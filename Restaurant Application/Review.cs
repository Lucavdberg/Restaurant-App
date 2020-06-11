using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

public class Review
{
    public void ReviewFunc()
    {
        Console.Clear();
        JsonClassReview reviewJson = new JsonClassReview();
        string keuze;
        Console.WriteLine("\n Wat leuk dat u een review wil plaatsen!\n Maak uw keuze.\n  [1]. Review plaatsen voor een gerecht.\n  [2]. Reviews bekijken.\n  [3]. Gemiddelde score van het restaurant bekijken.\n  [X]. Terug naar het Hoofdmenu.");
        keuze = Console.ReadLine();
        List<string> alleGerechtenList = new List<string>();
        if (keuze == "1") //Review plaatsen voor een gerecht.
        {
            Console.Clear();

            //Kijkt of de json file voor GERECHTEN bestaat in dezelfde directory als het project.
            string search_jsonfile_gerechten = @"gerechten.json";
            var exist_gerechten = File.Exists(search_jsonfile_gerechten) ? true : false;

            //Als de json file niet bestaat in de project folder wordt aangemaakt en gevuld met 'null'.
            if (exist_gerechten == false)
            {
                string existance_gerechten = JsonConvert.SerializeObject(null);
                File.WriteAllText(@"gerechten.json", existance_gerechten);
            }

            string jsonfile_gerechten = File.ReadAllText(@"gerechten.json");
            JsonClassGerechten gerechten = JsonConvert.DeserializeObject<JsonClassGerechten>(jsonfile_gerechten);

            if (gerechten == null)
            {
                Console.WriteLine(" Er staan nog geen gerechten in het menu...");
                Console.WriteLine("\n Druk op een toets om terug te keren naar het reviewmenu.");
                Console.ReadKey();
                ReviewFunc();
            }
            else
            {
                for (int i = 0; i < gerechten.maandag.Length; i++) //gerechten.maandag.Length omdat het even lang is als de rest van de dagen.
                {
                    for (int j = 0; j < 1; j++)
                    {
                        alleGerechtenList.Add(gerechten.maandag[i][j]);
                        alleGerechtenList.Add(gerechten.dinsdag[i][j]);
                        alleGerechtenList.Add(gerechten.woensdag[i][j]);
                        alleGerechtenList.Add(gerechten.donderdag[i][j]);
                        alleGerechtenList.Add(gerechten.vrijdag[i][j]);
                        alleGerechtenList.Add(gerechten.zaterdag[i][j]);
                        alleGerechtenList.Add(gerechten.zondag[i][j]);
                    }
                }
                IEnumerable<string> alleGerechtenListDist = alleGerechtenList.Distinct();
                var sortedGerechtenListDist = alleGerechtenListDist.OrderBy(s => s);

                foreach(string ger in sortedGerechtenListDist)
                {
                    Console.WriteLine(" " + ger);
                }


                Console.WriteLine("\n Bekijk en selecteer een van de gerechten hierboven.\n Druk op een toets om verder te gaan met de review. \n Let op u moet de naam van het gerecht precies overnemen!");
                Console.ReadKey();

                //Kijkt of de json file bestaat in dezelfde directory als het project.
                string search_jsonfile = @"reviews.json";
                var exist_reviews = File.Exists(search_jsonfile) ? true : false;

                //Als de json file niet bestaat in de project folder wordt aangemaakt en gevuld met 'null'.
                if (exist_reviews == false)
                {
                    string existance_reviews = JsonConvert.SerializeObject(null);
                    File.WriteAllText(@"reviews.json", existance_reviews);
                }

                //Hier worden de reviews uit de json file gelezen zodat het verder gebruikt kan worden.
                string jsonfile_review = File.ReadAllText(@"reviews.json");
                JsonClassReview reviews = JsonConvert.DeserializeObject<JsonClassReview>(jsonfile_review);

                string naam = "";
                string gerecht = "";
                string review = "";
                int score = 0;
                bool checkgerecht = false;
                bool checkscore = false;

                Console.Clear();
                Console.WriteLine(" Bij het plaatsen van een review zullen wij u drie vragen stellen.");

                Console.Write("\n Uw naam: ");
                naam = Console.ReadLine();
                Console.Write(" Het gerecht waarover u een review wilt plaatsen: ");
                gerecht = Console.ReadLine();


                while (checkgerecht == false) //Deze whileloop checkt of gebruiker een bestaand gerecht intypt.
                {
                    for (int i = 0; i < gerechten.maandag.Length; i++) //gerechten.maandag.Length omdat het even lang is als de rest van de dagen.
                    {
                        for (int j = 0; j < 1; j++)
                        {
                            if (gerecht == gerechten.maandag[i][j] || gerecht == gerechten.dinsdag[i][j] || gerecht == gerechten.woensdag[i][j] || gerecht == gerechten.donderdag[i][j] || gerecht == gerechten.vrijdag[i][j] || gerecht == gerechten.zaterdag[i][j] || gerecht == gerechten.zondag[i][j])
                            {
                                Console.WriteLine(" Dit gerecht staat in ons menu!");
                                checkgerecht = true;
                                break;
                            }
                        }
                        if (checkgerecht == true)
                        {
                            break;
                        }
                    }
                    if (checkgerecht == false)
                    {
                        Console.WriteLine(" Dit gerecht staat helaas niet in ons menu...");
                        Console.WriteLine(" Probeer het opnieuw, voor welk gerecht wilt u een review plaatsen?");
                        gerecht = Console.ReadLine();
                    }
                }

                Console.WriteLine(" Schrijf hier uw review (probeer het kort en bondig te houden).");
                review = Console.ReadLine();
                Console.WriteLine(" Wat voor cijfer geeft u dit gerecht op schaal van 1 tot 10?");
                score = Convert.ToInt32(Console.ReadLine());

                while (checkscore == false) //Deze whileloop checkt of gebruiker integer tussen 1 en 10 invuld
                {
                    if (score <= 10 && score > 0)
                    {
                        checkscore = true;
                        break;
                    }
                    else
                    {
                        checkscore = false;
                        Console.WriteLine(" Vul een heel getal in tussen 1 en 10 in...");
                        score = Convert.ToInt32(Console.ReadLine());
                    }
                }

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

                Console.WriteLine("\n Hartelijk bedankt voor moeite. Uw review is opgeslagen!");
                Console.WriteLine("\n Druk op een toets om terug te keren naar het reviewmenu.");
                Console.ReadKey();
                ReviewFunc();
            }
        }
        else if (keuze == "2") //Reviews bekijken
        {
            Console.Clear();
            //Kijkt of de json file bestaat in dezelfde directory als het project.
            string search_jsonfile = @"reviews.json";
            var exist_reviews = File.Exists(search_jsonfile) ? true : false;

            //Als de json file niet bestaat in de project folder wordt aangemaakt en gevuld met 'null'.
            if (exist_reviews == false)
            {
                string existance_reviews = JsonConvert.SerializeObject(null);
                File.WriteAllText(@"reviews.json", existance_reviews);
            }

            string jsonfile_review = File.ReadAllText(@"reviews.json");
            JsonClassReview reviews = JsonConvert.DeserializeObject<JsonClassReview>(jsonfile_review);

            if (reviews == null)
            {
                Console.WriteLine(" Er zijn nog geen reviews geplaatst...");
                Console.WriteLine("\nDruk op een toets om terug te keren naar het reviewmenu.");
                Console.ReadKey();
                ReviewFunc();
            }
            else
            {
                for (int i = 0; i < reviews.Naam.Count; i++) //Naam omdat Count overal hetzelfde is. 
                {
                    Console.WriteLine(" Naam: " + reviews.Naam[i]);
                    Console.WriteLine(" Gerecht: " + reviews.Gerecht[i]);
                    Console.WriteLine(" Review: " + reviews.Review[i]);
                    Console.WriteLine(" Score: " + reviews.Score[i] + "\n");
                }
                Console.WriteLine("\n Druk op een toets om terug te keren naar het reviewmenu.");
                Console.ReadKey();
                ReviewFunc();
            }
        }
        else if (keuze == "3") //Gemiddelde score checken
        {
            Console.Clear();

            //Kijkt of de json file bestaat in dezelfde directory als het project.
            string search_jsonfile = @"reviews.json";
            var exist_reviews = File.Exists(search_jsonfile) ? true : false;

            //Als de json file niet bestaat in de project folder wordt aangemaakt en gevuld met 'null'.
            if (exist_reviews == false)
            {
                string existance_reviews = JsonConvert.SerializeObject(null);
                File.WriteAllText(@"reviews.json", existance_reviews);
            }

            string jsonfile_review = File.ReadAllText(@"reviews.json");
            JsonClassReview reviews = JsonConvert.DeserializeObject<JsonClassReview>(jsonfile_review);

            if (reviews == null)
            {
                Console.WriteLine(" Er zijn nog geen reviews geplaatst...");
                Console.WriteLine("\n Druk op een toets om terug te keren naar het reviewmenu.");
                Console.ReadKey();
                ReviewFunc();
            }

            else
            {
                double avgscore = 0;

                for (int i = 0; i < reviews.Naam.Count; i++) //Naam omdat Count overal hetzelfde is. 
                {
                    avgscore = avgscore + reviews.Score[i]; //Telt alle scores op.
                }
                avgscore = (avgscore / reviews.Naam.Count); //Deelt alle opgetelde scores door het aantal reviews.
                Console.WriteLine(" De gemiddelde score van het restaurant is: " + avgscore);

                Console.WriteLine("\n Druk op een toets om terug te keren naar het reviewmenu.");
                Console.ReadKey();
                ReviewFunc();
            }

        }
        else if (keuze == "x" || keuze == "X") //Terug naar het hoofdmenu.
        {
            
        }
        else
        {
            Console.WriteLine(" Vul een getal in tussen de 1 en 3\n");
            Console.ReadKey();
            ReviewFunc();
        }
    }
}
