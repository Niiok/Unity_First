using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVtest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        List<Dictionary<string, object>> data = CSVreader.Read("TestCSVData");
        for(var i = 0; i < data.Count; i++)
        {
            print("ID : " + data[i]["ID"] + " , " +
                "Name : " + data[i]["Name"] + " , " +
                "Description : " + data[i]["Description"]);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
