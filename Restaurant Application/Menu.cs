using System;

public class Menu
{

    public string[] MenuVanDeDagFunc(string day,
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

        if (day == "maandag" || day == "Maandag" || day == "menu maandag" || day == "het menu van maandag")
        {
            string[] a = new string[] {
              maandag_een.Item1.Item1, maandag_een.Item1.Item2, maandag_een.Item1.Item3, maandag_een.Item1.Item4, "",
              maandag_een.Item2.Item1, maandag_een.Item2.Item2, maandag_een.Item2.Item3, "",
              maandag_een.Item3.Item1, maandag_een.Item3.Item2, maandag_een.Item3.Item3, maandag_een.Item3.Item4, "",
              maandag_een.Item4.Item1, maandag_een.Item4.Item2, maandag_een.Item4.Item3, "",
              maandag_een.Item5.Item1, maandag_een.Item5.Item2, maandag_een.Item5.Item3, maandag_een.Item5.Item4, "",
              maandag_een.Item6.Item1, maandag_een.Item6.Item2, maandag_een.Item6.Item3, maandag_een.Item6.Item4, "",
              maandag_een.Item7.Item1, maandag_een.Item7.Item2, maandag_een.Item7.Item3, "",
              maandag_twee.Item1.Item1, maandag_twee.Item1.Item2, maandag_twee.Item1.Item3, maandag_twee.Item1.Item4, "",
              maandag_twee.Item2.Item1, maandag_twee.Item2.Item2, maandag_twee.Item2.Item3, maandag_twee.Item2.Item4, "",
              maandag_twee.Item3.Item1, maandag_twee.Item3.Item2, maandag_twee.Item3.Item3, maandag_twee.Item3.Item4, "",
              maandag_twee.Item4.Item1, maandag_twee.Item4.Item2, maandag_twee.Item4.Item3, maandag_twee.Item4.Item4, ""
              };
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a[i]);
            }
            return a;
        }
        else if (day == "dinsdag" || day == "Dinsdag" || day == "menu dinsdag" || day == "het menu van dinsdag")
        {
            string[] b = new string[] {
              dinsdag_een.Item1.Item1, dinsdag_een.Item1.Item2, dinsdag_een.Item1.Item3, dinsdag_een.Item1.Item4, "",
              dinsdag_een.Item2.Item1, dinsdag_een.Item2.Item2, dinsdag_een.Item2.Item3, dinsdag_een.Item2.Item4, "",
              dinsdag_een.Item3.Item1, dinsdag_een.Item3.Item2, dinsdag_een.Item3.Item3, dinsdag_een.Item3.Item4, "",
              dinsdag_een.Item4.Item1, dinsdag_een.Item4.Item2, dinsdag_een.Item4.Item3, "",
              dinsdag_een.Item5.Item1, dinsdag_een.Item5.Item2, dinsdag_een.Item5.Item3, dinsdag_een.Item5.Item4, "",
              dinsdag_een.Item6.Item1, dinsdag_een.Item6.Item2, dinsdag_een.Item6.Item3, dinsdag_een.Item6.Item4, "",
              dinsdag_een.Item7.Item1, dinsdag_een.Item7.Item2, dinsdag_een.Item7.Item3, dinsdag_een.Item7.Item4, "",
              dinsdag_twee.Item1.Item1, dinsdag_twee.Item1.Item2, dinsdag_twee.Item1.Item3, dinsdag_twee.Item1.Item4, "",
              dinsdag_twee.Item2.Item1, dinsdag_twee.Item2.Item2, dinsdag_twee.Item2.Item3, "",
              dinsdag_twee.Item3.Item1, dinsdag_twee.Item3.Item2, dinsdag_twee.Item3.Item3, dinsdag_twee.Item3.Item4, "",
              dinsdag_twee.Item4.Item1, dinsdag_twee.Item4.Item2, dinsdag_twee.Item4.Item3, ""
              };
            for (int i = 0; i < b.Length; i++)
            {
                Console.WriteLine(b[i]);
            }
            return b;
        }
        else if (day == "woensdag" || day == "Woensdag" || day == "menu woensdag" || day == "het menu van woensdag")
        {
            string[] c = new string[] {
              woensdag_een.Item1.Item1, woensdag_een.Item1.Item2, woensdag_een.Item1.Item3, woensdag_een.Item1.Item4, "",
              woensdag_een.Item2.Item1, woensdag_een.Item2.Item2, woensdag_een.Item2.Item3, "",
              woensdag_een.Item3.Item1, woensdag_een.Item3.Item2, woensdag_een.Item3.Item3, woensdag_een.Item3.Item4, "",
              woensdag_een.Item4.Item1, woensdag_een.Item4.Item2, woensdag_een.Item4.Item3, woensdag_een.Item4.Item4, "",
              woensdag_een.Item5.Item1, woensdag_een.Item5.Item2, woensdag_een.Item5.Item3, "",
              woensdag_een.Item6.Item1, woensdag_een.Item6.Item2, woensdag_een.Item6.Item3, woensdag_een.Item6.Item4, "",
              woensdag_een.Item7.Item1, woensdag_een.Item7.Item2, woensdag_een.Item7.Item3, woensdag_een.Item7.Item4, "",
              woensdag_twee.Item1.Item1, woensdag_twee.Item1.Item2, woensdag_twee.Item1.Item3, woensdag_twee.Item1.Item4, "",
              woensdag_twee.Item2.Item1, woensdag_twee.Item2.Item2, woensdag_twee.Item2.Item3, woensdag_twee.Item2.Item4, "",
              woensdag_twee.Item3.Item1, woensdag_twee.Item3.Item2, woensdag_twee.Item3.Item3, woensdag_twee.Item3.Item4, "",
              woensdag_twee.Item4.Item1, woensdag_twee.Item4.Item2, woensdag_twee.Item4.Item3, ""
              };
            for (int i = 0; i < c.Length; i++)
            {
                Console.WriteLine(c[i]);
            }
            return c;
        }
        else if (day == "donderdag" || day == "Donderdag" || day == "menu donderdag" || day == "het menu van donderdag")
        {
            string[] d = new string[] {
              donderdag_een.Item1.Item1, donderdag_een.Item1.Item2, donderdag_een.Item1.Item3, "",
              donderdag_een.Item2.Item1, donderdag_een.Item2.Item2, donderdag_een.Item2.Item3, "",
              donderdag_een.Item3.Item1, donderdag_een.Item3.Item2, donderdag_een.Item3.Item3, donderdag_een.Item3.Item4, "",
              donderdag_een.Item4.Item1, donderdag_een.Item4.Item2, donderdag_een.Item4.Item3, donderdag_een.Item4.Item4, "",
              donderdag_een.Item5.Item1, donderdag_een.Item5.Item2, donderdag_een.Item5.Item3, donderdag_een.Item5.Item4, "",
              donderdag_een.Item6.Item1, donderdag_een.Item6.Item2, donderdag_een.Item6.Item3, donderdag_een.Item6.Item4, "",
              donderdag_een.Item7.Item1, donderdag_een.Item7.Item2, donderdag_een.Item7.Item3, donderdag_een.Item7.Item4, "",
              donderdag_twee.Item1.Item1, donderdag_twee.Item1.Item2, donderdag_twee.Item1.Item3, donderdag_twee.Item1.Item4, "",
              donderdag_twee.Item2.Item1, donderdag_twee.Item2.Item2, donderdag_twee.Item2.Item3, donderdag_twee.Item2.Item4, "",
              donderdag_twee.Item3.Item1, donderdag_twee.Item3.Item2, donderdag_twee.Item3.Item3, donderdag_twee.Item3.Item4, "",
              donderdag_twee.Item4.Item1, donderdag_twee.Item4.Item2, donderdag_twee.Item4.Item3, donderdag_twee.Item4.Item4, ""
              };
            for (int i = 0; i < d.Length; i++)
            {
                Console.WriteLine(d[i]);
            }
            return d;
        }
        else if (day == "vrijdag" || day == "Vrijdag" || day == "menu vrijdag" || day == "het menu van vrijdag")
        {
            string[] e = new string[] {
              vrijdag_een.Item1.Item1, vrijdag_een.Item1.Item2, vrijdag_een.Item1.Item3, vrijdag_een.Item1.Item4, "",
              vrijdag_een.Item2.Item1, vrijdag_een.Item2.Item2, vrijdag_een.Item2.Item3, vrijdag_een.Item2.Item4, "",
              vrijdag_een.Item3.Item1, vrijdag_een.Item3.Item2, vrijdag_een.Item3.Item3, vrijdag_een.Item3.Item4, "",
              vrijdag_een.Item4.Item1, vrijdag_een.Item4.Item2, vrijdag_een.Item4.Item3, vrijdag_een.Item4.Item4, "",
              vrijdag_een.Item5.Item1, vrijdag_een.Item5.Item2, vrijdag_een.Item5.Item3, vrijdag_een.Item5.Item4, "",
              vrijdag_een.Item6.Item1, vrijdag_een.Item6.Item2, vrijdag_een.Item6.Item3, vrijdag_een.Item6.Item4, "",
              vrijdag_een.Item7.Item1, vrijdag_een.Item7.Item2, vrijdag_een.Item7.Item3, vrijdag_een.Item7.Item4, "",
              vrijdag_twee.Item1.Item1, vrijdag_twee.Item1.Item2, vrijdag_twee.Item1.Item3, "",
              vrijdag_twee.Item2.Item1, vrijdag_twee.Item2.Item2, vrijdag_twee.Item2.Item3, vrijdag_twee.Item2.Item4, "",
              vrijdag_twee.Item3.Item1, vrijdag_twee.Item3.Item2, vrijdag_twee.Item3.Item3, vrijdag_twee.Item3.Item4, "",
              vrijdag_twee.Item4.Item1, vrijdag_twee.Item4.Item2, vrijdag_twee.Item4.Item3, vrijdag_twee.Item4.Item4, ""
              };
            for (int i = 0; i < e.Length; i++)
            {
                Console.WriteLine(e[i]);
            }
            return e;
        }
        else if (day == "zaterdag" || day == "Zaterdag" || day == "menu zaterdag" || day == "het menu van zaterdag")
        {
            string[] f = new string[] {
              zaterdag_een.Item1.Item1, zaterdag_een.Item1.Item2, zaterdag_een.Item1.Item3, zaterdag_een.Item1.Item4, "",
              zaterdag_een.Item2.Item1, zaterdag_een.Item2.Item2, zaterdag_een.Item2.Item3, zaterdag_een.Item2.Item4, "",
              zaterdag_een.Item3.Item1, zaterdag_een.Item3.Item2, zaterdag_een.Item3.Item3, zaterdag_een.Item3.Item4, "",
              zaterdag_een.Item4.Item1, zaterdag_een.Item4.Item2, zaterdag_een.Item4.Item3, zaterdag_een.Item4.Item4, "",
              zaterdag_een.Item5.Item1, zaterdag_een.Item5.Item2, zaterdag_een.Item5.Item3, zaterdag_een.Item5.Item4, "",
              zaterdag_een.Item6.Item1, zaterdag_een.Item6.Item2, zaterdag_een.Item6.Item3, zaterdag_een.Item6.Item4, "",
              zaterdag_een.Item7.Item1, zaterdag_een.Item7.Item2, zaterdag_een.Item7.Item3, zaterdag_een.Item7.Item4, "",
              zaterdag_twee.Item1.Item1, zaterdag_twee.Item1.Item2, zaterdag_twee.Item1.Item3, zaterdag_twee.Item1.Item4, "",
              zaterdag_twee.Item2.Item1, zaterdag_twee.Item2.Item2, zaterdag_twee.Item2.Item3, zaterdag_twee.Item2.Item4, "",
              zaterdag_twee.Item3.Item1, zaterdag_twee.Item3.Item2, zaterdag_twee.Item3.Item3, "",
              zaterdag_twee.Item4.Item1, zaterdag_twee.Item4.Item2, zaterdag_twee.Item4.Item3, zaterdag_twee.Item4.Item4, ""
              };
            for (int i = 0; i < f.Length; i++)
            {
                Console.WriteLine(f[i]);
            }
            return f;
        }
        else if (day == "zondag" || day == "Zondag" || day == "menu zondag" || day == "het menu van zondag")
        {
            string[] g = new string[] {
              zondag_een.Item1.Item1, zondag_een.Item1.Item2, zondag_een.Item1.Item3, zondag_een.Item1.Item4, "",
              zondag_een.Item2.Item1, zondag_een.Item2.Item2, zondag_een.Item2.Item3, zondag_een.Item2.Item4, "",
              zondag_een.Item3.Item1, zondag_een.Item3.Item2, zondag_een.Item3.Item3, zondag_een.Item3.Item4, "",
              zondag_een.Item4.Item1, zondag_een.Item4.Item2, zondag_een.Item4.Item3, "",
              zondag_een.Item5.Item1, zondag_een.Item5.Item2, zondag_een.Item5.Item3, zondag_een.Item5.Item4, "",
              zondag_een.Item6.Item1, zondag_een.Item6.Item2, zondag_een.Item6.Item3, zondag_een.Item6.Item4, "",
              zondag_een.Item7.Item1, zondag_een.Item7.Item2, zondag_een.Item7.Item3, zondag_een.Item7.Item4, "",
              zondag_twee.Item1.Item1, zondag_twee.Item1.Item2, zondag_twee.Item1.Item3, zondag_twee.Item1.Item4, "",
              zondag_twee.Item2.Item1, zondag_twee.Item2.Item2, zondag_twee.Item2.Item3, zondag_twee.Item2.Item4, "",
              zondag_twee.Item3.Item1, zondag_twee.Item3.Item2, zondag_twee.Item3.Item3, "",
              zondag_twee.Item4.Item1, zondag_twee.Item4.Item2, zondag_twee.Item4.Item3, ""
              };
            for (int i = 0; i < g.Length; i++)
            {
                Console.WriteLine(g[i]);
            }
            return g;
        }
        Console.WriteLine("Type een dag in ");
        return new string[] { };
    }



}

