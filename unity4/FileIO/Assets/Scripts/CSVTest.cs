using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        List<Dictionary<string, string>> data = CSVReader.Read("test");

        for (int i = 0; i < data.Count; i++)
        {
            Debug.Log("name " + data[i]["name"] + " " +
                "age " + data[i]["age"] + " " +
                "speed" + data[i]["speed"] + " " +
                "desc " + data[i]["description"]);
        }
    }

   
}
