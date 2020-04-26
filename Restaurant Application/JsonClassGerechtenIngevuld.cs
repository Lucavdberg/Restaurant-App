public class JsonClassGerechtenIngevuld
{
    public JsonClassGerechten gerechtenIngevuldFunc()
    {
        JsonClassGerechten gerechtenJson = new JsonClassGerechten();
        gerechtenJson.maandag = new string[][]
             {
                new string[] { "Pizza Margherita", "Traditionele pizza met tomatensaus en kaas", "Bevat: granen, gluten, melk, lactose", "7,25 Euro", "" },
                new string[] { "Costoletted’Agnelloalla Griglia", "Gegrilde lamskoteletten", "19,25 Euro", "" },
                new string[] { "Pizza Hawaii", "Traditionele pizza met tomatensaus, ham, ananas en kaas", "Bevat: granen, gluten, melk, lactose", "8,50 Euro", "" },
                new string[] { "Branzino all griglia", "Op de huid gegrilde zeebaars", "23,50 Euro", "" },
                new string[] { "Pasta Bolognese", "Traditionele pasta op basis van rundergehaktsaus", "Bevat: granen, gluten, melk, lactose", "8,50 Euro", "" },
                new string[] { "Pasta Pesto", "Tradiotionele pasta op basis van pesto met cherrytomaatjes, pijnboompitten en mozzarella", "Bevat: granen, gluten, melk, lactose, noten.", "7,75 Euro", "" },
                new string[] { "Italiaanse olijven", "Italiaanse olijven in olijfolie", "5,00 Euro", "" },
                new string[] { "Pestobrood met gesmolten kaas", "Verse pesto met gesmolten kaas", "Bevat: granen, gluten, melk, lactose", "5,00 Euro", "" },
                new string[] { "Polpette", "Rundergehaktballetjes in huisgemaakte napolitana saus met marscapone, geserveerd met geroosterd brood", "Bevat: granen, gluten, melk, lactose, eieren, selderij", "5,00 Euro", "" },
                new string[] { "Stokbrood met kruidenboter", "Een vers afgebakken stokbrood met een schaaltje kruidenboter erbij geserveerd", "Bevat: granen, gluten", "5,00 Euro", "" },
                new string[] { "Carpaccio", "Dungesneden runderfilet met Parmezaanse kaas, rucola, pijnboompitten en pesto", "Bevat: noten, lactose", "9,25 Euro", "" }
             };
        gerechtenJson.dinsdag = new string[][]
        {
                new string[] { "Pizza Siciliana", "Traditionele pizza met tomatensaus, kaas ansjovis, olijven en kappertjes", "Bevat: granen, gluten, melk, lactose, vis", "9,00 Euro", "" },
                new string[] { "Pizza Pollo", "Traditionele pizza met tomatensaus, kaas, kipfilet, ui, paprika en champignons", "Bevat: granen, gluten, melk, lactose", "8,00 Euro", "" },
                new string[] { "Pollo Al Pesto", "Kipfilet met pesto, kappertjes, olijven, lichte pikante tomatensaus en knoflook", "Bevat: noten", "7,50 Euro", "" },
                new string[] { "Entrecote", "Premium gesneden stuk rundvlees", "24,50 Euro", "" },
                new string[] { "Pasta Tonno", "Tradiotionele pasta op basis van roomsaus met tonijn, ui en knoflook", "Bevat: granen, gluten, melk, lactose, vis", "8,75 Euro", "" },
                new string[] { "Pasta Napolitana", "Tradiotionele pasta op basis van Napolitaanse tomatensaus", "Bevat: granen, gluten, melk, lactose", "8,50 Euro", "" },
                new string[] { "Tiramisu", "Huisgemaakt Italiaans nagerecht met lange vingers, marscapone en amaretto", "Bevat: granen, gluten, melk, lactose,  eieren", "4,50 Euro", "" },
                new string[] { "Calamari Friti", "Gefrituurde inktvis", "Bevat: granen, gluten, vis", "6,00 Euro", "" },
                new string[] { "Insalata Puteolana", "Salade met paprika, ui, ei, asperges en ham", "5,75 Euro", "" },
                new string[] { "Tartufo Nero", "Chocolade truffelijs", "Bevat: granen, gluten, melk, lactose, noten, soja", "5,50 Euro", "" },
                new string[] { "Salmone", "Marinato gerookte zalm met ui en kappertjes", "9,75 Euro", "" }
        };
        gerechtenJson.woensdag = new string[][]
        {
                new string[] { "Pizza Pepperoni", "Traditionele pizza met tomatensaus, pepperoni en kaas", "Bevat: granen, gluten, lactose", "9,00 Euro", "" },
                new string[] { "Salmone al Zafferano", "Zalmmoot in saffraansaus met kappertjes", "17,50 Euro", "" },
                new string[] { "Pizza Quatro Formaggi ", "Traditionele pizza met vier soorten kaas", "Bevat: granen, gluten, lactose", "10,50 Euro", "" },
                new string[] { "Pizza Nutella", "Traditionele pizza met nutellasaus en verse aardbeien", "Bevat: granen, gluten, lactose", "8,75 Euro", "" },
                new string[] { "Bistecca", "Kogelbiefstuk met champignon of pepersaus", "21,00 Euro", "" },
                new string[] { "Pasta Pollo", "Traditionele pasta op basis van roomsaus met kipfilet, tomaten, ui en champignons", "Bevat: granen, gluten, lactose", "9,75 Euro", "" },
                new string[] { "Melanzane alla Parmigiana", "Gegratineerde aubergine uit de oven in tomatensaus en Parmezaanse kaas", "Bevat: lactose", "6,50 Euro", "" },
                new string[] { "Sutlac", "Rijstpudding", "Bevat: granen, lactose", "4,95 Euro", "" },
                new string[] { "Tartufo al cioccolato", "Truffel bomb met een hart van vanilleijs, chocoladesaus en slagroom", "Bevat: lactose", "6,50 Euro", "" },
                new string[] { "Runder Carpaccio", "Argentijns rund, pestodressing, pijnboompitten, Parmezaanse kaas en verse rucola", "Bevat: noten, lactose", "11,50 Euro", "" },
                new string[] { "Gambaretti Casserole", "Garnalen geroosterd in de oven met knoflook en rode chili olie", "9,50 Euro", "" }
        };
        gerechtenJson.donderdag = new string[][]
        {
                new string[] { "Burger Mio Papa", "US Angus burger met 10% dry aged-beef met frites", "14,50 Euro", "" },
                new string[] { "Pollo alla griglia", "Gegrilde kipfilet", "13,50 Euro", "" },
                new string[] { "Pasta Carbonara", "Traditionele pasta op basis van roomsaus met kaas en reepjes spek", "Bevat: granen, gluten, lactose, melk, eieren", "9,75 Euro", "" },
                new string[] { "Pizza Marinara", "Traditionele pizza met tomatensaus gekruid met oregano en knoflook", "Bevat: granen, gluten", "9,50 Euro", "" },
                new string[] { "Lasagne a’la Jamie Oliver", "Verse lasagne uit de oven volgens het recept van Jamie Oliver", "Bevat: gluten, lactose", "11,00 Euro", "" },
                new string[] { "Ragu bolognese met tagliatelle", "Tagliatelle in romige tomatensaus", "Bevat: gluten, melk", "12,50 Euro", "" },
                new string[] { "Zalm Carpaccio", "Zalm in de oven geroosterd met pestodressing en pijnboompitten", "Bevat: noten", "12,00 Euro", "" },
                new string[] { "Salade Caprese", "Salade met tomaat, basilicum en buffelmozzarella", "Bevat: lactose", "10,00 Euro", "" },
                new string[] { "Tartufo Limoncello", "Citroenijs met limoncello saus bedekt met schuimvlokjes", "Bevat: lactose", "5,95 Euro", "" },
                new string[] { "Panna cotta caramelo", "Melk en room dessert met een laag van zachte karamel", "Bevat: melk, lactose", "5,95 Euro", "" },
                new string[] { "Cassata", "Vanille ijs met room, pistache en gekonfijte vruchten", "Bevat: lactose, noten", "5,95 Euro", "" }
        };
        gerechtenJson.vrijdag = new string[][]
        {
                new string[] { "Lasagne bolognese met bechamelsaus", "Verse lasagne uit de oven met rundergehakt en bechamelsaus", "Bevat: gluten, lactose, melk", "13,50 Euro", "" },
                new string[] { "Macaroni met vegetarische gehaktballetjes", "Macaroni met vegi balletjes", "Bevat: gluten", "10,50 Euro", "" },
                new string[] { "Vegan pasta pesto", "Veganistische pasta met pestosaus", "Bevat: noten", "10,00 Euro", "" },
                new string[] { "Pasta ovenschotel met zalm en spinazie", "Zalmpasta met spinazie uit de oven", "Bevat: gluten", "12,50 Euro", "" },
                new string[] { "Gnocchi met bolognesesaus", "Overheerlijke gnocchi", "Bevat: gluten, melk", "14,25 Euro", "" },
                new string[] { "Risotto met boerenkool en worst", "Rijstgerecht met boerenkool en rookworst", "Bevat: granen", "15,25 Euro", "" },
                new string[] { "Gevuld stokbrood met mozzarella", "Vers stokbrood gevuld met mozzarella ", "Bevat: granen, gluten, lactose", "5,95 Euro", "" },
                new string[] { "Gebakken zalm", "Zalmmoot vers uit de oven", "8,95 Euro", "" },
                new string[] { "Bruschetta salade", "Salade met tomaat, mozzarella en stukken bruchetta", "Bevat: granen, gluten, lactose", "7,80 Euro", "" },
                new string[] { "Cassata ", "Vanille ijs met room, pistache en gekonfijte vruchten", "Bevat: lactose, noten", "5,95 Euro", "" },
                new string[] { "Runder Carpaccio", "Argentijns rund, pestodressing, pijnboompitten, Parmezaanse kaas en verse rucola", "Bevat: noten, lactose", "11,50 Euro", "" }
        };
        gerechtenJson.zaterdag = new string[][]
        {
                new string[] { "Ravioli met tomaatje uit de oven", "Verse ravioli gevuld met ricotta geserveerd met in de oven gegrilde tomaat", "Bevat: gluten, lactose", "13,00 Euro", "" },
                new string[] { "Spaghetti bolognese ", "Verse spagetti met romige tomatensaus", "Bevat: gluten, melk", "11,50 Euro", "" },
                new string[] { "Calzone Pollo", "Dubbelgevouwen pizza met tomatensaus, kaas en kipfilet", "Bevat: gluten, granen, lactose", "10,75 Euro", "" },
                new string[] { "Tomatensoep met orzo", "Tomatensoep geserveerd met orzo (soort klein gesneden pasta)", "Bevat: gluten, granen", "13,75 Euro", "" },
                new string[] { "Lasagne met chamignons", "Verse lasagne met champignons", "Bevat: gluten. lactose", "14,50 Euro", "" },
                new string[] { "Pasta gambaretti e spinacci", "Traditionele pasta met garnalen en spinazie in een roomsaus", "Bevat: gluten, lactose, melk", "16,25 Euro", "" },
                new string[] { "Gevuld stokbrood met mozzarella", "Vers stokbrood gevuld met mozzarella", "Bevat: granen, gluten, lactose", "5,95 Euro", "" },
                new string[] { "Salade Caprese", "Salade met tomaat, basilicum en buffelmozzarella", "Bevat: lactose", "10,00 Euro", "" },
                new string[] { "Sutlac", "Rijstpudding", "Bevat: granen, melk, lactose", "4,95 Euro", "" },
                new string[] { "Italiaanse olijven", "Italiaanse olijven in olijfolie", "5,00 Euro", "" },
                new string[] { "Tartufo Nero", "Chocolade truffelijs", "Bevat: granen, gluten, melk, lactose, noten, soja", "4,50 Euro", "" }
        };
        gerechtenJson.zondag = new string[][]
        {
                new string[] { "Pizza Margheritha", "Traditionele pizza met tomatensaus en kaas", "Bevat: granen, gluten, melk, lactose ", "7,25 Euro", "" },
                new string[] { "Pizza Siciliana", "Traditionele pizza met tomatensaus, kaas, ansjovis, olijven en kappertjes", "Bevat: granen, gluten, melk, lactose, vis", "9,00 Euro", "" },
                new string[] { "Calzone Pollo", "Dubbelgevouwen pizza met tomatensaus, kaas en kipfilet", "Bevat: gluten, granen, lactose", "10,75 Euro", "" },
                new string[] { "Burger Mio Papa", "US Angus burger met 10% dry aged-beef met frites", "14,50 Euro", "" },
                new string[] { "Lasagne bolognese met bechamelsaus", "Verse lasagne uit de oven met rundergehakt en bechamelsaus", "Bevat: gluten, lactose, melk", "13,50 Euro", "" },
                new string[] { "Ravioli met tomaatje uit de oven", "Verse ravioli gevuld met ricotta geserveerd met in de oven gegrilde tomaat", "Bevat: gluten, lactose", "13,00 Euro", "" },
                new string[] { "Carpaccio", "Dungesneden runderfilet met Parmezaanse kaas, rucola, pijnboompitten en pesto", "Bevat: noten, lactose", "9,25 Euro", "" },
                new string[] { "Tiramisu", "Huisgemaakt Italiaans nagerecht met lange vingers, mascarpone en amaretto", "Bevat: granen, gluten, melk, lactose, eieren", "4,50 Euro", "" },
                new string[] { "Melanzane alla Parmigiana", "Gegratineerde aubergine uit de oven in tomatensaus en Parmezaanse kaas", "Bevat: lactose", "6,50 Euro", "" },
                new string[] { "Italiaanse olijven", "Italiaanse olijven in olijfolie", "5,00 Euro", "" },
                new string[] { "Salmone", "Marinato gerookte zalm met ui en kappertjes", "9,75 Euro", "" }
        };
        return gerechtenJson;
    }
}




