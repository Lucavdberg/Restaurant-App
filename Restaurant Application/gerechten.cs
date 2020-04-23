using System;

public class gerechten
{
    public void gerechtenFunc(string gerecht, JsonClassGerechten opzoekClass)
    {
        bool gerechtenCheck = true;

        for (int i = 0; i < opzoekClass.maandag.Length; i++)
        {
            for (int j = 0; j < 1; j++)
            {
                if (gerecht == opzoekClass.maandag[i][j])
                {
                    Console.WriteLine("Dit gerecht staat in ons menu voor Maandag");
                    gerechtenCheck = true;
                }
                else
                {
                    gerechtenCheck = false;
                }
            }
        }

        for (int i = 0; i < opzoekClass.dinsdag.Length; i++)
        {
            for (int j = 0; j < 1; j++)
            {
                if (gerecht == opzoekClass.dinsdag[i][j])
                {
                    Console.WriteLine("Dit gerecht staat in ons menu voor Dinsdag");
                    gerechtenCheck = true;
                }
                else
                {
                    gerechtenCheck = false;
                }
            }
        }

        for (int i = 0; i < opzoekClass.woensdag.Length; i++)
        {
            for (int j = 0; j < 1; j++)
            {
                if (gerecht == opzoekClass.woensdag[i][j])
                {
                    Console.WriteLine("Dit gerecht staat in ons menu voor Woensdag");
                    gerechtenCheck = true;
                }
                else
                {
                    gerechtenCheck = false;
                }
            }
        }

        for (int i = 0; i < opzoekClass.donderdag.Length; i++)
        {
            for (int j = 0; j < 1; j++)
            {
                if (gerecht == opzoekClass.donderdag[i][j])
                {
                    Console.WriteLine("Dit gerecht staat in ons menu voor Donderdag");
                    gerechtenCheck = true;
                }
                else
                {
                    gerechtenCheck = false;
                }
            }
        }

        for (int i = 0; i < opzoekClass.vrijdag.Length; i++)
        {
            for (int j = 0; j < 1; j++)
            {
                if (gerecht == opzoekClass.vrijdag[i][j])
                {
                    Console.WriteLine("Dit gerecht staat in ons menu voor Vrijdag");
                    gerechtenCheck = true;
                }
                else
                {
                    gerechtenCheck = false;
                }
            }
        }

        for (int i = 0; i < opzoekClass.zaterdag.Length; i++)
        {
            for (int j = 0; j < 1; j++)
            {
                if (gerecht == opzoekClass.zaterdag[i][j])
                {
                    Console.WriteLine("Dit gerecht staat in ons menu voor Zaterdag");
                    gerechtenCheck = true;
                }
                else
                {
                    gerechtenCheck = false;
                }
            }
        }

        for (int i = 0; i < opzoekClass.zondag.Length; i++)
        {
            for (int j = 0; j < 1; j++)
            {
                if (gerecht == opzoekClass.zondag[i][j])
                {
                    Console.WriteLine("Dit gerecht staat in ons menu voor Zondag");
                    gerechtenCheck = true;
                }
                else
                {
                    gerechtenCheck = false;
                }
            }
        }

        if (gerechtenCheck == false)
            Console.WriteLine("Dit gerecht staat helaas op dit moment niet in ons menu voor deze week");


        Console.WriteLine("klik op een toets om terug te keren naar het hoofdmenu");
        Console.ReadKey();
    }
}