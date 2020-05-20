using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

public class Tafel
{
    public JsonClassTafels tafelFunc()
    {
        JsonClassTafels tafelsJson = new JsonClassTafels();
        tafelsJson.aantalTafels = 50;
        return tafelsJson;
    }
    public string datum;
    public int vrije_stoelen;
    public Tafel(string _datum, int _vrije_stoelen)
    {
        datum = _datum;
        vrije_stoelen = _vrije_stoelen;
    }
    public static void ReserveerDag(string datum, int stoelen)
    {
        string buffer = File.ReadAllText(@"omar.json");
        JsonClassTafels resultaat = JsonConvert.DeserializeObject<JsonClassTafels>(buffer);

        Tafel dag = null;
        List<Tafel> dagen = new List<Tafel>();
        //ArrayList dagen = new ArrayList();
        foreach (Tafel d in dagen)
        {

            if (d.datum == datum)
                dag = d;
            
        }

        if (dag == null)
            dagen.Add(new Tafel(datum, 50 - stoelen));

        else {
            dag.vrije_stoelen -= stoelen;
        }
        string result = JsonConvert.SerializeObject(dagen);
        File.WriteAllText(@"omar.json", result);
    }
}


