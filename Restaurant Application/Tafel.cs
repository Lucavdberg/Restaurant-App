using System;
using System.Collections.Generic;

public class Tafel
{
    public JsonClassTafels tafelFunc()
    {
        JsonClassTafels tafelsJson = new JsonClassTafels();
        tafelsJson.aantalPlaatsen = new List<int>();
        return tafelsJson;
    }
}