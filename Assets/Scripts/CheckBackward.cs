using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckBackward : MonoBehaviour
{
    public GameObject Player;
    public GameObject Enemy;
    public Text Result;

    Vector2 characterPos;
    Vector2 characterDir;
    Vector2 monsterPos;
    Vector2 monsterDir;


    private void Update()
    {
        characterPos = new Vector2(Player.transform.position.x, Player.transform.position.z);
        characterDir = new Vector2(Player.transform.forward.x, Player.transform.forward.z);
        monsterPos = new Vector2(Enemy.transform.position.x, Enemy.transform.position.z);
        monsterDir = new Vector2(Enemy.transform.forward.x, Enemy.transform.forward.z);

        bool isBackward = Function_CheckBackward(
            characterPos,
            characterDir,
            monsterPos,
            monsterDir);

        Result.text = $"Enemy is in {(isBackward ? "<color=#FF0000>back</color>" : "front")} of Player";
    }



    bool Function_CheckBackward(
        Vector2 characterPos,
        Vector2 characterDir,
        Vector2 monsterPos,
        Vector2 monsterDir)
    {
        Vector2 vector = monsterPos - characterPos;

        return (characterDir.x * vector.x + characterDir.y * vector.y < 0) ;
    }
}
