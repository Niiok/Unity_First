using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager sInstance;
    public static GameManager Instance
    {
        get
        {
            if (sInstance == null)
            {
                GameObject newGameObj = new GameObject("_GameManger");
                sInstance = newGameObj.AddComponent<GameManager>();
            }
            return sInstance;
        }
    }

    public bool count_seconds = true;
    public float seconds = 0;
    public float timeover = 120;
    public float time_scale
    {
        get
        {
            return seconds / timeover;
        }
    }

    public float score = 0;
    public float global_speed
    {
        get
        {
            return 1 + score / 60;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (count_seconds)
            seconds += Time.deltaTime;
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
