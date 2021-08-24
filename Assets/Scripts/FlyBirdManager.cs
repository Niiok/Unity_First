using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlyBirdManager : MonoBehaviour
{
    public enum State
    {
        Sleep,
        Fly,
        Ko
    }
    public State state = State.Sleep;
    public float score = 0;

    private static FlyBirdManager sInstance;

    public static FlyBirdManager Instance
    {
        get
        {
            if (sInstance == null)
            {
                GameObject newGameObj = new GameObject("_FlyBirdManger");
                sInstance = newGameObj.AddComponent<FlyBirdManager>();
            }
            return sInstance;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

