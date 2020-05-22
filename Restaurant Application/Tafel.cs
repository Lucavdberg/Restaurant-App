using System;

public class Tafel
{
    public JsonClassTafels tafelFunc()
    {
        JsonClassTafels tafelsJson = new JsonClassTafels();
        tafelsJson.aantalTafels = 50;
        return tafelsJson;
    }
}