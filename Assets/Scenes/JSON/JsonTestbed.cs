using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class JsonTestbed : MonoBehaviour
{
    public string path = @"test.json";

    // Start is called before the first frame update
    void Start()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            JsonUtility.FromJsonOverwrite(json, this);

            print("file exist");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        string str = JsonUtility.ToJson(this);
        File.WriteAllText(path, str);
    }
}
