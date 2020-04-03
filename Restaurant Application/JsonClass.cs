using System;
using System.Collections.Generic;

public class JsonClass
{
    public int id { get; set; }
    public string Gebruiksnaam { get; set; }
    public string Wachtwoord { get; set; }
    public string Email { get; set; }

    public override string ToString()
    {
        return string.Format("Gebruikers_id:\n\tid: {0}, \n\tGebruiksnaam: {1}, \n\tWachtwoord {2}, \n\tEmail {3}", id, Gebruiksnaam, Wachtwoord, Email);
    }
}