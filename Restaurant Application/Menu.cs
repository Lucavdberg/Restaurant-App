using System;

public class Menu
{

    public void MenuVanDeDagFunc(string day, JsonClassGerechten gerechtClass)
    {
        if (day == "maandag" || day == "Maandag" || day == "Ma" || day == "ma")
        {
            for (int i = 0; i < gerechtClass.maandag.Length; i++)
            {
                for (int j = 0; j < gerechtClass.maandag[i].Length; j++)
                {
                    Console.WriteLine(gerechtClass.maandag[i][j]);
                }
            }
        }
        else if (day == "dinsdag" || day == "Dinsdag" || day == "Di" || day == "di")
        {
            for (int i = 0; i < gerechtClass.dinsdag.Length; i++)
            {
                for (int j = 0; j < gerechtClass.dinsdag[i].Length; j++)
                {
                    Console.WriteLine(gerechtClass.dinsdag[i][j]);
                }
            }
        }
        else if (day == "woensdag" || day == "Woensdag" || day == "Wo" || day == "wo")
        {
            for (int i = 0; i < gerechtClass.woensdag.Length; i++)
            {
                for (int j = 0; j < gerechtClass.woensdag[i].Length; j++)
                {
                    Console.WriteLine(gerechtClass.woensdag[i][j]);
                }
            }
        }
        else if (day == "donderdag" || day == "Donderdag" || day == "Do" || day == "do")
        {
            for (int i = 0; i < gerechtClass.donderdag.Length; i++)
            {
                for (int j = 0; j < gerechtClass.donderdag[i].Length; j++)
                {
                    Console.WriteLine(gerechtClass.donderdag[i][j]);
                }
            }
        }
        else if (day == "vrijdag" || day == "Vrijdag" || day == "Do" || day == "do")
        {
            for (int i = 0; i < gerechtClass.vrijdag.Length; i++)
            {
                for (int j = 0; j < gerechtClass.vrijdag[i].Length; j++)
                {
                    Console.WriteLine(gerechtClass.vrijdag[i][j]);
                }
            }
        }
        else if (day == "zaterdag" || day == "Zaterdag" || day == "Za" || day == "za")
        {
            for (int i = 0; i < gerechtClass.zaterdag.Length; i++)
            {
                for (int j = 0; j < gerechtClass.zaterdag[i].Length; j++)
                {
                    Console.WriteLine(gerechtClass.zaterdag[i][j]);
                }
            }
        }
        else if (day == "zondag" || day == "Zondag" || day == "Zo" || day == "zo")
        {
            for (int i = 0; i < gerechtClass.zondag.Length; i++)
            {
                for (int j = 0; j < gerechtClass.zondag[i].Length; j++)
                {
                    Console.WriteLine(gerechtClass.zondag[i][j]);
                }
            }
        }
        else
        {
            Console.WriteLine("Voer hier alleen dagen in van de week. Bijvoorbeeld: Ma, Maandag, Di, Dinsdag etc.");
        }
        Console.WriteLine("Druk op een toets om terug te keren naar het hoofdmenu.");
        Console.ReadKey();
    }
}

