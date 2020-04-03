using System;
using System.Collections.Generic;

public class JsonClassReservering
{
    public int id { get; set; }
    public string Datum { get; set; }
    public string Tijden { get; set; }
    public string Personen { get; set; }
    public string Details { get; set; }

    public override string ToString()
    {
        return string.Format("Gebruikers_id:\n\tid: {0}, \n\tDatum {1}, \n\tTijden {2}, \n\tPersonen {3}, \n\tDetails {4}", id, Datum, Tijden, Personen, Details);
    }
}