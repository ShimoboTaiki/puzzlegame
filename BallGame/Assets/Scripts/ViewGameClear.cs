using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ItemM;
using StageM;

public class ViewGameClear : MonoBehaviour
{
    public Text text;
    public GameObject ball;
    private Rigidbody2D rig;

    void Start()
    {
        rig = ball.GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ball" && ItemManager.itemCount==0)
        {
            if (StageManager.stageNum < StageManager.stages.Count)
            {
                StageManager.stageNum++;
                ball.transform.position = new Vector3(StageManager.stages[StageManager.stageNum - 1].baniX, 6, 0);
                rig.velocity = Vector2.zero;
                rig.gravityScale = 0;
                rig.angularVelocity = 0;
            }
            else
            {
                rig.gravityScale = 0;
                rig.velocity = Vector2.zero;
                rig.angularVelocity = 0;
                text.text = "GameClear!!";
            }
        }
    }
}
