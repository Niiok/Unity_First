using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_Spartan : MonoBehaviour
{
    private static GameManager_Spartan  sInstance;
    public float score = 0;
    public GameObject ground;
    Vector3 ground_pos;
    public int enemy_count = 0;

    public static GameManager_Spartan  Instance
    {
        get
        {
            if (sInstance == null)
            {
                GameObject newGameObj = new GameObject("_GameManger");
                sInstance = newGameObj.AddComponent<GameManager_Spartan>();
            }
            return sInstance;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        ground = GameObject.Find("Ground");
        ground_pos = ground.transform.position;
    }

    private void Update()
    {
        ground.transform.position = ground_pos;
        ground.transform.Translate(0, -enemy_count * 0.5f, 0);
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
