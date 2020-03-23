using System;

class Program
{

    // Main method
    static void Main(string[] args)
    {
        // Local Function
        string[] AddValue(string day,
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
            Console.WriteLine("Type een dag in");
            return new string[] { };
        }

        // Calling Local function
        var maandag_een = Tuple.Create(
          Tuple.Create("Pizza Margherita", "Traditionele pizza met tomatensaus en kaas", "Bevat: granen, gluten, melk, lactose", "7,25 Euro"),
          Tuple.Create("Costoletted’Agnelloalla Griglia", "Gegrilde lamskoteletten", "19,25 Euro", ""),
          Tuple.Create("Pizza Hawaii", "Traditionele pizza met tomatensaus, ham, ananas en kaas", "Bevat: granen, gluten, melk, lactose", "8,50 Euro"),
          Tuple.Create("Branzino all griglia", "Op de huid gegrilde zeebaars", "23,50 Euro", ""),
          Tuple.Create("Pasta Bolognese", "Traditionele pasta op basis van rundergehaktsaus", "Bevat: granen, gluten, melk, lactose", "8,50 Euro"),
          Tuple.Create("Pasta Pesto", "Tradiotionele pasta op basis van pesto met cherrytomaatjes, pijnboompitten en mozzarella", "Bevat: granen, gluten, melk, lactose, noten.", "7,75 Euro"),
          Tuple.Create("Italiaanse olijven", "Italiaanse olijven in olijfolie", "5,00 Euro", "")
        );
        var maandag_twee = Tuple.Create(
          Tuple.Create("Pestobrood met gesmolten kaas", "Verse pesto met gesmolten kaas", "Bevat: granen, gluten, melk, lactose", "5,00 Euro"),
          Tuple.Create("Polpette", "Rundergehaktballetjes in huisgemaakte napolitana saus met marscapone, geserveerd met geroosterd brood", "Bevat: granen, gluten, melk, lactose, eieren, selderij", "5,00 Euro"),
          Tuple.Create("Stokbrood met kruidenboter", "Een vers afgebakken stokbrood met een schaaltje kruidenboter erbij geserveerd", "Bevat: granen, gluten", "5,00 Euro"),
          Tuple.Create("Carpaccio", "Dungesneden runderfilet met Parmezaanse kaas, rucola, pijnboompitten en pesto", "Bevat: noten, lactose", "9,25 Euro")
        );
        var dinsdag_een = Tuple.Create(
          Tuple.Create("Pizza Siciliana", "Traditionele pizza met tomatensaus, kaas ansjovis, olijven en kappertjes", "Bevat: granen, gluten, melk, lactose, vis", "9,00 Euro"),
          Tuple.Create("Pizza Pollo", "Traditionele pizza met tomatensaus, kaas, kipfilet, ui, paprika en champignons", "Bevat: granen, gluten, melk, lactose", "8,00 Euro"),
          Tuple.Create("Pollo Al Pesto", "Kipfilet met pesto, kappertjes, olijven, lichte pikante tomatensaus en knoflook", "Bevat: noten", "7,50 Euro"),
          Tuple.Create("Entrecote", "Premium gesneden stuk rundvlees", "24,50 Euro", ""),
          Tuple.Create("Pasta Tonno", "Tradiotionele pasta op basis van roomsaus met tonijn, ui en knoflook", "Bevat: granen, gluten, melk, lactose, vis", "8,75 Euro"),
          Tuple.Create("Pasta Napolitana", "Tradiotionele pasta op basis van Napolitaanse tomatensaus", "Bevat: granen, gluten, melk, lactose", "8,50 Euro"),
          Tuple.Create("Tiramisu", "Huisgemaakt Italiaans nagerecht met lange vingers, marscapone en amaretto", "Bevat: granen, gluten, melk, lactose,  eieren", "4,50 Euro")
        );
        var dinsdag_twee = Tuple.Create(
          Tuple.Create("Calamari Friti", "Gefrituurde inktvis", "Bevat: granen, gluten, vis", "6,00 Euro"),
          Tuple.Create("Insalata Puteolana", "Salade met paprika, ui, ei, asperges en ham", "5,75 Euro", ""),
          Tuple.Create("Tartufo Nero", "Chocolade truffelijs", "Bevat: granen, gluten, melk, lactose, noten, soja", "5,50 Euro"),
          Tuple.Create("Salmone", "Marinato gerookte zalm met ui en kappertjes", "9,75 Euro", "")
        );
        var woensdag_een = Tuple.Create(
          Tuple.Create("Pizza Pepperoni", "Traditionele pizza met tomatensaus, pepperoni en kaas", "Bevat: granen, gluten, lactose", "9,00 Euro"),
          Tuple.Create("Salmone al Zafferano", "Zalmmoot in saffraansaus met kappertjes", "17,50 Euro", ""),
          Tuple.Create("Pizza Quatro Formaggi ", "Traditionele pizza met vier soorten kaas", "Bevat: granen, gluten, lactose", "10,50 Euro"),
          Tuple.Create("Pizza Nutella", "Traditionele pizza met nutellasaus en verse aardbeien", "Bevat: granen, gluten, lactose", "8,75 Euro"),
          Tuple.Create("Bistecca", "Kogelbiefstuk met champignon of pepersaus", "21,00 Euro", ""),
          Tuple.Create("Pasta Pollo", "Traditionele pasta op basis van roomsaus met kipfilet, tomaten, ui en champignons", "Bevat: granen, gluten, lactose", "9,75 Euro"),
          Tuple.Create("Melanzane alla Parmigiana", "Gegratineerde aubergine uit de oven in tomatensaus en Parmezaanse kaas", "Bevat: lactose", "6,50 Euro")
        );
        var woensdag_twee = Tuple.Create(
          Tuple.Create("Sutlac", "Rijstpudding", "Bevat: granen, lactose", "4,95 Euro"),
          Tuple.Create("Tartufo al cioccolato", "Truffel bomb met een hart van vanilleijs, chocoladesaus en slagroom", "Bevat: lactose", "6,50 Euro"),
          Tuple.Create("Runder Carpaccio", "Argentijns rund, pestodressing, pijnboompitten, Parmezaanse kaas en verse rucola", "Bevat: noten, lactose", "11,50 Euro"),
          Tuple.Create("Gambaretti Casserole", "Garnalen geroosterd in de oven met knoflook en rode chili olie", "9,50 Euro", "")
        );
        var donderdag_een = Tuple.Create(
          Tuple.Create("Burger Mio Papa", "US Angus burger met 10% dry aged-beef met frites", "14,50 Euro", ""),
          Tuple.Create("Pollo alla griglia", "Gegrilde kipfilet", "13,50 Euro", ""),
          Tuple.Create("Pasta Carbonara", "Traditionele pasta op basis van roomsaus met kaas en reepjes spek", "Bevat: granen, gluten, lactose, melk, eieren", "9,75 Euro"),
          Tuple.Create("Pizza Marinara", "Traditionele pizza met tomatensaus gekruid met oregano en knoflook", "Bevat: granen, gluten", "9,50 Euro"),
          Tuple.Create("Lasagne a’la Jamie Oliver", "Verse lasagne uit de oven volgens het recept van Jamie Oliver", "Bevat: gluten, lactose", "11,00 Euro"),
          Tuple.Create("Ragu bolognese met tagliatelle", "Tagliatelle in romige tomatensaus", "Bevat: gluten, melk", "12,50 Euro"),
          Tuple.Create("Zalm Carpaccio", "Zalm in de oven geroosterd met pestodressing en pijnboompitten", "Bevat: noten", "12,00 Euro")
        );
        var donderdag_twee = Tuple.Create(
          Tuple.Create("Salade Caprese", "Salade met tomaat, basilicum en buffelmozzarella", "Bevat: lactose", "10,00 Euro"),
          Tuple.Create("Tartufo Limoncello", "Citroenijs met limoncello saus bedekt met schuimvlokjes", "Bevat: lactose", "5,95 Euro"),
          Tuple.Create("Panna cotta caramelo", "Melk en room dessert met een laag van zachte karamel", "Bevat: melk, lactose", "5,95 Euro"),
          Tuple.Create("Cassata", "Vanille ijs met room, pistache en gekonfijte vruchten", "Bevat: lactose, noten", "5,95 Euro")
        );
        var vrijdag_een = Tuple.Create(
          Tuple.Create("Lasagne bolognese met bechamelsaus", "Verse lasagne uit de oven met rundergehakt en bechamelsaus", "Bevat: gluten, lactose, melk", "13,50 Euro"),
          Tuple.Create("Macaroni met vegetarische gehaktballetjes", "Macaroni met vegi balletjes", "Bevat: gluten", "10,50 Euro"),
          Tuple.Create("Vegan pasta pesto", "Veganistische pasta met pestosaus", "Bevat: noten", "10,00 Euro"),
          Tuple.Create("Pasta ovenschotel met zalm en spinazie", "Zalmpasta met spinazie uit de oven", "Bevat: gluten", "12,50 Euro"),
          Tuple.Create("Gnocchi met bolognesesaus", "Overheerlijke gnocchi", "Bevat: gluten, melk", "14,25 Euro"),
          Tuple.Create("Risotto met boerenkool en worst", "Rijstgerecht met boerenkool en rookworst", "Bevat: granen", "15,25 Euro"),
          Tuple.Create("Gevuld stokbrood met mozzarella", "Vers stokbrood gevuld met mozzarella ", "Bevat: granen, gluten, lactose", "5,95 Euro")
        );
        var vrijdag_twee = Tuple.Create(
          Tuple.Create("Gebakken zalm", "Zalmmoot vers uit de oven", "8,95 Euro", ""),
          Tuple.Create("Bruschetta salade", "Salade met tomaat, mozzarella en stukken bruchetta", "Bevat: granen, gluten, lactose", "7,80 Euro"),
          Tuple.Create("Cassata ", "Vanille ijs met room, pistache en gekonfijte vruchten", "Bevat: lactose, noten", "5,95 Euro"),
          Tuple.Create("Runder Carpaccio", "Argentijns rund, pestodressing, pijnboompitten, Parmezaanse kaas en verse rucola", "Bevat: noten, lactose", "11,50 Euro")
        );
        var zaterdag_een = Tuple.Create(
          Tuple.Create("Ravioli met tomaatje uit de oven", "Verse ravioli gevuld met ricotta geserveerd met in de oven gegrilde tomaat", "Bevat: gluten, lactose", "13,00 Euro"),
          Tuple.Create("Spaghetti bolognese ", "Verse spagetti met romige tomatensaus", "Bevat: gluten, melk", "11,50 Euro"),
          Tuple.Create("Calzone Pollo", "Dubbelgevouwen pizza met tomatensaus, kaas en kipfilet", "Bevat: gluten, granen, lactose", "10,75 Euro"),
          Tuple.Create("Tomatensoep met orzo", "Tomatensoep geserveerd met orzo (soort klein gesneden pasta)", "Bevat: gluten, granen", "13,75 Euro"),
          Tuple.Create("Lasagne met chamignons", "Verse lasagne met champignons", "Bevat: gluten. lactose", "14,50 Euro"),
          Tuple.Create("Pasta gambaretti e spinacci", "Traditionele pasta met garnalen en spinazie in een roomsaus", "Bevat: gluten, lactose, melk", "16,25 Euro"),
          Tuple.Create("Gevuld stokbrood met mozzarella", "Vers stokbrood gevuld met mozzarella", "Bevat: granen, gluten, lactose", "5,95 Euro")
        );
        var zaterdag_twee = Tuple.Create(
          Tuple.Create("Salade Caprese", "Salade met tomaat, basilicum en buffelmozzarella", "Bevat: lactose", "10,00 Euro"),
          Tuple.Create("Sutlac", "Rijstpudding", "Bevat: granen, melk, lactose", "4,95 Euro"),
          Tuple.Create("Italiaanse olijven", "Italiaanse olijven in olijfolie", "5,00 Euro", ""),
          Tuple.Create("Tartufo Nero", "Chocolade truffelijs", "Bevat: granen, gluten, melk, lactose, noten, soja", "4,50 Euro")
        );
        var zondag_een = Tuple.Create(
          Tuple.Create("Pizza Margheritha", "Traditionele pizza met tomatensaus en kaas", "Bevat: granen, gluten, melk, lactose ", "7,25 Euro"),
          Tuple.Create("Pizza Siciliana", "Traditionele pizza met tomatensaus, kaas, ansjovis, olijven en kappertjes", "Bevat: granen, gluten, melk, lactose, vis", "9,00 Euro"),
          Tuple.Create("Calzone Pollo", "Dubbelgevouwen pizza met tomatensaus, kaas en kipfilet", "Bevat: gluten, granen, lactose", "10,75 Euro"),
          Tuple.Create("Burger Mio Papa", "US Angus burger met 10% dry aged-beef met frites", "14,50 Euro", ""),
          Tuple.Create("Lasagne bolognese met bechamelsaus", "Verse lasagne uit de oven met rundergehakt en bechamelsaus", "Bevat: gluten, lactose, melk", "13,50 Euro"),
          Tuple.Create("Ravioli met tomaatje uit de oven", "Verse ravioli gevuld met ricotta geserveerd met in de oven gegrilde tomaat", "Bevat: gluten, lactose", "13,00 Euro"),
          Tuple.Create("Carpaccio", "Dungesneden runderfilet met Parmezaanse kaas, rucola, pijnboompitten en pesto", "Bevat: noten, lactose", "9,25 Euro")
        );
        var zondag_twee = Tuple.Create(
          Tuple.Create("Tiramisu", "Huisgemaakt Italiaans nagerecht met lange vingers, mascarpone en amaretto", "Bevat: granen, gluten, melk, lactose, eieren", "4,50 Euro"),
          Tuple.Create("Melanzane alla Parmigiana", "Gegratineerde aubergine uit de oven in tomatensaus en Parmezaanse kaas", "Bevat: lactose", "6,50 Euro"),
          Tuple.Create("Italiaanse olijven", "Italiaanse olijven in olijfolie", "5,00 Euro", ""),
          Tuple.Create("Salmone", "Marinato gerookte zalm met ui en kappertjes", "9,75 Euro", "")
        );
        Console.WriteLine("Welkom bij ons restaurant");
        Console.WriteLine("U kunt via deze applicatie een reservering plaatsen en het menu bekijken");
        Console.WriteLine("Wilt u een reservering plaatsen type dan (reservering) of een menu bekijken type dan (menu)");
        var menu_of_reservering = Console.ReadLine();
        if (menu_of_reservering == "menu")
        {
            Console.WriteLine("Van welke dag wilt u het menu bekijken");
            var day = Console.ReadLine();
            var menukaart = AddValue(day, maandag_een, maandag_twee, dinsdag_een, dinsdag_twee, woensdag_een, woensdag_twee, donderdag_een, donderdag_twee, vrijdag_een, vrijdag_twee, zaterdag_een, zaterdag_twee, zondag_een, zondag_twee);
        }
        Console.WriteLine("Geen reserveringen beschikbaar");
       
    }
}