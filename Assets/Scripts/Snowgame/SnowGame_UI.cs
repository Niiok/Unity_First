using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnowGame_UI : MonoBehaviour
{
    public Text score_text;
    public Text size_text;
    public Text degree_text;

    GameObject sunlight;
    GameObject player;

    Light sun_light;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Snowman_Player");

        sunlight = GameObject.Find("Directional Light");
        sun_light = sunlight.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        score_text.text = "Biggest size : " + GameManager.Instance.score.ToString();
        sun_light.intensity = GameManager.Instance.time_scale;
        //if(GameManager.Instance.time_scale > 1)
        //{
        //    Color new_col = sun_light.color;
        //    new_col.g -= Time.deltaTime;
        //    sun_light.color = new_col;
        //}

        size_text.text = "Current size : " + (player != null ? player.transform.localScale.sqrMagnitude : 0);

        degree_text.text = (GameManager.Instance.time_scale * 30 - 10).ToString() + " 'C";

    }   
}
