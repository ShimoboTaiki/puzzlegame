using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StageM;
using Reset;
using System.Threading.Tasks;

namespace StartPush
{
    public class GameStart : MonoBehaviour
    {
        public GameObject ball;
        public Text text;
        public static bool isPushed = false;
        private Rigidbody2D rig;
        private int stageN;
        async void Start()
        {
            await Task.Delay(1);
            stageN = 1;
            rig = ball.GetComponent<Rigidbody2D>();
            rig.gravityScale = 0;
            transform.localPosition = StageManager.stages[0].buttonPos;
        }
        void Update()
        {
            if (stageN != StageManager.stageNum)
            {
                stageN = StageManager.stageNum;
                transform.localPosition = StageManager.stages[stageN - 1].buttonPos;
            }
            if (Ball.isReset)
            {
                if (rig != null)
                {
                    ball.transform.position = new Vector3(StageManager.stages[stageN - 1].baniX, 6, 0);
                    rig.gravityScale = 0;
                    rig.velocity = Vector2.zero;
                    rig.angularVelocity = 0;
                }
            }
            if (Ball.isPlaying)
            {
                text.text = "Reset";
            }
            else
            {
                text.text = "Start";
            }
        }
        void Onclicked()
        {
            if (Ball.isPlaying)
            {
                Ball.isReset = true;
                Ball.isResethojo = 0;
            }
            else
            {
                rig.gravityScale = 1;
                isPushed = true;
            }
        }
    }
}