using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace oefenen1
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonClass gebruikerJson = new JsonClass();
            Customerlogin loginClass = new Customerlogin();
            email emailClass = new email();

            JsonClassGerechten gerechtenJson = new JsonClassGerechten();
            gerechtenJson.a = 5;
            

            int a = loginClass.LoginFunc(gebruikerJson);
          

            Console.WriteLine("gebruikerjson is ingevuld door inlog.cs met: " + gebruikerJson.Email);

            if (a == 1) 
            {
                emailClass.emailFunc(gebruikerJson.Email);
            }
            
            
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
            Console.WriteLine("Wilt u een reservering plaatsen type dan (reservering) of een menu bekijken type dan ( 1 voor een menu op dag) of (2 voor een menu op gerecht)");
            var menu_of_reservering = Console.ReadLine();
            if (menu_of_reservering == "1")
            {
                Console.WriteLine("Van welke dag wilt u het menu bekijken");
                var day = Console.ReadLine();
                Menu menuVanEenDagClass = new Menu();
                menuVanEenDagClass.MenuVanDeDagFunc(day, maandag_een, maandag_twee, dinsdag_een, dinsdag_twee, woensdag_een, woensdag_twee, donderdag_een, donderdag_twee, vrijdag_een, vrijdag_twee, zaterdag_een, zaterdag_twee, zondag_een, zondag_twee);
            }
            else if (menu_of_reservering == "2")
            {
                Console.WriteLine("welke gerecht wil je ?");
                var gerecht = Console.ReadLine();
                gerechten gerechtenClass = new gerechten();
                gerechtenClass.gerechtenFunc(gerecht, maandag_een, maandag_twee, dinsdag_een, dinsdag_twee, woensdag_een, woensdag_twee, donderdag_een, donderdag_twee, vrijdag_een, vrijdag_twee, zaterdag_een, zaterdag_twee, zondag_een, zondag_twee);
            }
            else if (menu_of_reservering == "3")
            {
                JsonClassReservering reserveringJson = new JsonClassReservering();
                Reservering ReserveringClass = new Reservering();
                ReserveringClass.reserveringFunc(reserveringJson);
                
            }
            Console.WriteLine("test");
        }
    }
}