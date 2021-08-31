using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingBird_UI : MonoBehaviour
{
    public Text score_text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (FlyBirdManager.Instance.state)
        {
            case FlyBirdManager.State.Sleep:
                score_text.text = "Press To Start!";
                break;
            case FlyBirdManager.State.Fly:
                score_text.text = ((int)(FlyBirdManager.Instance.score * FlyBirdManager.Instance.score)).ToString();
                break;
            case FlyBirdManager.State.Ko:
                score_text.text = "Your score is\n" + ((int)(FlyBirdManager.Instance.score * FlyBirdManager.Instance.score)).ToString();
                break;
        }
    }
}
