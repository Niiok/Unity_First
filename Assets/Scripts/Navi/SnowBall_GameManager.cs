using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnowBall_GameManager : MonoBehaviour
{
    public List<GameObject> snowballs;

    private static SnowBall_GameManager sInstance;

    public static SnowBall_GameManager Instance
    {
        get
        {
            if (sInstance == null)
            {
                GameObject newGameObj = new GameObject("_GameManger");
                sInstance = newGameObj.AddComponent<SnowBall_GameManager>();
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

    private void OnEnable()
    {
        snowballs = new List<GameObject>();
    }

    private void OnDisable()
    {
        snowballs.Clear();
    }
}
