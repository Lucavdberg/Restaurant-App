using System;

public class Menu
{

    public void MenuVanDeDagFunc(string day, JsonClassGerechten gerechtClass)
    {
        if (day == "maandag" || day == "Maandag" || day == "menu maandag" || day == "het menu van maandag")
        {
            for (int i = 0; i < gerechtClass.maandag.Length; i++)
            {
                for (int j = 0; j < gerechtClass.maandag[i].Length; j++)
                {
                    Console.WriteLine(gerechtClass.maandag[i][j]);
                }
            }
        }
        else if (day == "dinsdag" || day == "Dinsdag" || day == "menu dinsdag" || day == "het menu van dinsdag")
        {
            for (int i = 0; i < gerechtClass.dinsdag.Length; i++)
            {
                for (int j = 0; j < gerechtClass.dinsdag[i].Length; j++)
                {
                    Console.WriteLine(gerechtClass.dinsdag[i][j]);
                }
            }
        }
        else if (day == "woensdag" || day == "Woensdag" || day == "menu woensdag" || day == "het menu van woensdag")
        {
            for (int i = 0; i < gerechtClass.woensdag.Length; i++)
            {
                for (int j = 0; j < gerechtClass.woensdag[i].Length; j++)
                {
                    Console.WriteLine(gerechtClass.woensdag[i][j]);
                }
            }
        }
        else if (day == "donderdag" || day == "Donderdag" || day == "menu donderdag" || day == "het menu van donderdag")
        {
            for (int i = 0; i < gerechtClass.donderdag.Length; i++)
            {
                for (int j = 0; j < gerechtClass.donderdag[i].Length; j++)
                {
                    Console.WriteLine(gerechtClass.donderdag[i][j]);
                }
            }
        }
        else if (day == "vrijdag" || day == "Vrijdag" || day == "menu vrijdag" || day == "het menu van vrijdag")
        {
            for (int i = 0; i < gerechtClass.vrijdag.Length; i++)
            {
                for (int j = 0; j < gerechtClass.vrijdag[i].Length; j++)
                {
                    Console.WriteLine(gerechtClass.vrijdag[i][j]);
                }
            }
        }
        else if (day == "zaterdag" || day == "Zaterdag" || day == "menu zaterdag" || day == "het menu van zaterdag")
        {
            for (int i = 0; i < gerechtClass.zaterdag.Length; i++)
            {
                for (int j = 0; j < gerechtClass.zaterdag[i].Length; j++)
                {
                    Console.WriteLine(gerechtClass.zaterdag[i][j]);
                }
            }
        }
        else if (day == "zondag" || day == "Zondag" || day == "menu zondag" || day == "het menu van zondag")
        {
            for (int i = 0; i < gerechtClass.zondag.Length; i++)
            {
                for (int j = 0; j < gerechtClass.zondag[i].Length; j++)
                {
                    Console.WriteLine(gerechtClass.zondag[i][j]);
                }
            }
        }
        Console.WriteLine("voer hier alleen dagen in van de week");
        Console.WriteLine("klik op een toets om terug te keren naar het hoofdmenu");
        Console.ReadKey();
    }
}

