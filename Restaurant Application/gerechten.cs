using System;

public class gerechten
{
    public void gerechtenFunc(string gerecht, JsonClassGerechten opzoekClass)
    {
        string[] array1 = new string[]{opzoekClass.maandag[0][0], opzoekClass.maandag[1][0], opzoekClass.maandag[2][0], opzoekClass.maandag[3][0], opzoekClass.maandag[4][0], opzoekClass.maandag[5][0], 
            opzoekClass.maandag[6][0], opzoekClass.maandag[7][0], opzoekClass.maandag[8][0], opzoekClass.maandag[9][0], opzoekClass.maandag[10][0] };

        string[] array2 = new string[]{opzoekClass.dinsdag[0][0], opzoekClass.dinsdag[1][0], opzoekClass.dinsdag[2][0], opzoekClass.dinsdag[3][0], opzoekClass.dinsdag[4][0], opzoekClass.dinsdag[5][0],
        opzoekClass.dinsdag[6][0], opzoekClass.dinsdag[7][0], opzoekClass.dinsdag[8][0], opzoekClass.dinsdag[9][0], opzoekClass.dinsdag[10][0] };

        string[] array3 = new string[]{opzoekClass.woensdag[0][0], opzoekClass.woensdag[1][0], opzoekClass.woensdag[2][0], opzoekClass.woensdag[3][0], opzoekClass.woensdag[4][0], opzoekClass.woensdag[5][0],
        opzoekClass.woensdag[6][0], opzoekClass.woensdag[7][0], opzoekClass.woensdag[8][0], opzoekClass.woensdag[9][0], opzoekClass.woensdag[10][0] };

        string[] array4 = new string[]{opzoekClass.donderdag[0][0], opzoekClass.donderdag[1][0], opzoekClass.donderdag[2][0], opzoekClass.donderdag[3][0], opzoekClass.donderdag[4][0], opzoekClass.donderdag[5][0],
        opzoekClass.donderdag[6][0], opzoekClass.donderdag[7][0], opzoekClass.donderdag[8][0], opzoekClass.donderdag[9][0], opzoekClass.donderdag[10][0] };

        string[] array5 = new string[]{opzoekClass.vrijdag[0][0], opzoekClass.vrijdag[1][0], opzoekClass.vrijdag[2][0], opzoekClass.vrijdag[3][0], opzoekClass.vrijdag[4][0], opzoekClass.vrijdag[5][0],
        opzoekClass.vrijdag[6][0], opzoekClass.vrijdag[7][0], opzoekClass.vrijdag[8][0], opzoekClass.vrijdag[9][0], opzoekClass.vrijdag[10][0] };

        string[] array6 = new string[]{opzoekClass.zaterdag[0][0], opzoekClass.zaterdag[1][0], opzoekClass.zaterdag[2][0], opzoekClass.zaterdag[3][0], opzoekClass.zaterdag[4][0], opzoekClass.zaterdag[5][0],
        opzoekClass.zaterdag[6][0], opzoekClass.zaterdag[7][0], opzoekClass.zaterdag[8][0], opzoekClass.zaterdag[9][0], opzoekClass.zaterdag[10][0] };

        string[] array7 = new string[]{opzoekClass.zondag[0][0], opzoekClass.zondag[1][0], opzoekClass.zondag[2][0], opzoekClass.zondag[3][0], opzoekClass.zondag[4][0], opzoekClass.zondag[5][0],
        opzoekClass.zondag[6][0], opzoekClass.zondag[7][0], opzoekClass.zondag[8][0], opzoekClass.zondag[9][0], opzoekClass.zondag[10][0] };

        bool gerechtCheck = true;
        for (int i = 0; i < array1.Length; i++)
        {
            if (array1[i] == gerecht)
            {
                Console.WriteLine("Dit gerecht staat in ons menu voor Maandag");
                gerechtCheck = false;
            }
            if (array2[i] == gerecht)
            {
                Console.WriteLine("Dit gerecht staat in ons menu voor Dinsdag");
                gerechtCheck = false;
            }
            if (array3[i] == gerecht)
            {
                Console.WriteLine("Dit gerecht staat in ons menu voor Woensdag");
                gerechtCheck = false;
            }
            if (array4[i] == gerecht)
            {
                Console.WriteLine("Dit gerecht staat in ons menu voor Donderdag");
                gerechtCheck = false;
            }
            if (array5[i] == gerecht)
            {
                Console.WriteLine("Dit gerecht staat in ons menu voor Vrijdag");
                gerechtCheck = false;
            }
            if (array6[i] == gerecht)
            {
                Console.WriteLine("Dit gerecht staat in ons menu voor Zaterdag");
                gerechtCheck = false;
            }
            if (array7[i] == gerecht)
            {
                Console.WriteLine("Dit gerecht staat in ons menu voor Zondag");
                gerechtCheck = false;
            }
            if (i == array1.Length-1 && gerechtCheck == true) 
            { 
                Console.WriteLine("Dit gerecht staat helaas op dit moment niet in ons menu voor deze week");
            }
        }
        Console.WriteLine("klik op een toets om terug te keren naar het hoofdmenu");
        Console.ReadKey();
    }
}