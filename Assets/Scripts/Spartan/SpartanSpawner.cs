using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpartanSpawner : MonoBehaviour
{
    public float interval = 5.0f;
    public GameObject spartans;
    private float term = 0;
    float init_interval;

    // Start is called before the first frame update
    void Start()
    {
        init_interval = interval;
    }

    // Update is called once per frame
    void Update()
    {
        term += Time.deltaTime;

        if(term > interval)
        {
            term = 0;
            Instantiate(spartans, transform.position, transform.rotation);

            if (GameManager_Spartan.Instance.score % 100 == 0)
                interval *= 0.9f;
        }

    }

    private void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 200, 200), "Score : " + GameManager_Spartan.Instance.score);
    }
}
