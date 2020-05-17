using System;
using System.Collections.Generic;
using System.Text;

public class Review
{
    public void ReviewFunc()
    {
        string naam;
        string rating;
        string review;

        Console.WriteLine("Wat is uw naam?");
        naam = Console.ReadLine();
        Console.WriteLine("Wat voor cijfer tussen de 1 en 5 geeft u ons?");
        rating = Console.ReadLine();
        Console.WriteLine("Beschrijf uw ervaring.");
        review = Console.ReadLine();

        Console.WriteLine("\nUw review is opgeslagen! Hartelijk bedankt!\n");
    }
}
