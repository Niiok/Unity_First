using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S04_GUItest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        GUI.TextArea(new Rect(200, 200, 200, 30), "wow wow");
        GUI.TextField(new Rect(200, 250, 200, 30), "wow wow");
        GUI.Box(new Rect(200, 300, 200, 30), "wow wow");

        GUILayout.Label("ohhhh");
        if(GUI.Button(new Rect(400, 200, 200, 30), "scene change"))
        {
            GameManager.Instance.ChangeScene("01basic");
        }
    }
}
