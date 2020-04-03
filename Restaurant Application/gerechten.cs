using System;

public class gerechten
{
    public string gerechtenFunc(string gerecht,
            Tuple<Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>> maandag_een,
            Tuple<Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>> maandag_twee,
            Tuple<Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>> dinsdag_een,
            Tuple<Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>> dinsdag_twee,
            Tuple<Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>> woensdag_een,
            Tuple<Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>> woensdag_twee,
            Tuple<Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>> donderdag_een,
            Tuple<Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>> donderdag_twee,
            Tuple<Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>> vrijdag_een,
            Tuple<Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>> vrijdag_twee,
            Tuple<Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>> zaterdag_een,
            Tuple<Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>> zaterdag_twee,
            Tuple<Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>> zondag_een,
            Tuple<Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>, Tuple<string, string, string, string>> zondag_twee)
    {
        string[] array1 = new string[]{maandag_een.Item1.Item1, maandag_een.Item2.Item1, maandag_een.Item3.Item1, maandag_een.Item4.Item1, maandag_een.Item5.Item1,
                maandag_een.Item6.Item1, maandag_een.Item7.Item1, maandag_twee.Item1.Item1, maandag_twee.Item2.Item1, maandag_twee.Item3.Item1, maandag_twee.Item4.Item1};

        string[] array2 = new string[]{dinsdag_een.Item1.Item1, dinsdag_een.Item2.Item1, dinsdag_een.Item3.Item1, dinsdag_een.Item4.Item1, dinsdag_een.Item5.Item1,
                dinsdag_een.Item6.Item1, dinsdag_een.Item7.Item1, dinsdag_twee.Item1.Item1, dinsdag_twee.Item2.Item1, dinsdag_twee.Item3.Item1, dinsdag_twee.Item4.Item1};

        string[] array3 = new string[]{woensdag_een.Item1.Item1, woensdag_een.Item2.Item1, woensdag_een.Item3.Item1, woensdag_een.Item4.Item1, woensdag_een.Item5.Item1,
                woensdag_een.Item6.Item1, woensdag_een.Item7.Item1, woensdag_twee.Item1.Item1, woensdag_twee.Item2.Item1, woensdag_twee.Item3.Item1, woensdag_twee.Item4.Item1};

        string[] array4 = new string[]{donderdag_een.Item1.Item1, donderdag_een.Item2.Item1, donderdag_een.Item3.Item1, donderdag_een.Item4.Item1, donderdag_een.Item5.Item1,
                donderdag_een.Item6.Item1, donderdag_een.Item7.Item1, donderdag_twee.Item1.Item1, donderdag_twee.Item2.Item1, donderdag_twee.Item3.Item1, donderdag_twee.Item4.Item1};

        string[] array5 = new string[]{vrijdag_een.Item1.Item1, vrijdag_een.Item2.Item1, vrijdag_een.Item3.Item1, vrijdag_een.Item4.Item1, vrijdag_een.Item5.Item1,
                vrijdag_een.Item6.Item1, vrijdag_een.Item7.Item1, vrijdag_twee.Item1.Item1, vrijdag_twee.Item2.Item1, vrijdag_twee.Item3.Item1, vrijdag_twee.Item4.Item1};

        string[] array6 = new string[]{zaterdag_een.Item1.Item1, zaterdag_een.Item2.Item1, zaterdag_een.Item3.Item1, zaterdag_een.Item4.Item1, zaterdag_een.Item5.Item1,
                zaterdag_een.Item6.Item1, zaterdag_een.Item7.Item1, zaterdag_twee.Item1.Item1, zaterdag_twee.Item2.Item1, zaterdag_twee.Item3.Item1, zaterdag_twee.Item4.Item1};

        string[] array7 = new string[]{zondag_een.Item1.Item1, zondag_een.Item2.Item1, zondag_een.Item3.Item1, zondag_een.Item4.Item1, zondag_een.Item5.Item1,
                zondag_een.Item6.Item1, zondag_een.Item7.Item1, zondag_twee.Item1.Item1, zondag_twee.Item2.Item1, zondag_twee.Item3.Item1, zondag_twee.Item4.Item1};

        for (int i = 0; i < array1.Length; i++)
        {
            if (array1[i] == gerecht)
            {
                Console.WriteLine("Maandag");
                return "";
            }
            if (array2[i] == gerecht)
            {
                Console.WriteLine("Dinsdag");
            }
            if (array3[i] == gerecht)
            {
                Console.WriteLine("Woensdag");
            }
            if (array4[i] == gerecht)
            {
                Console.WriteLine("Donderdag");
            }
            if (array5[i] == gerecht)
            {
                Console.WriteLine("Vrijdag");
            }
            if (array6[i] == gerecht)
            {
                Console.WriteLine("Zaterdag");
            }
            if (array7[i] == gerecht)
            {
                Console.WriteLine("Zondag");
            }
            


        }
        return "";
    }
}