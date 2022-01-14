using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using StageM;

namespace Reset
{
    public class Ball : MonoBehaviour
    {
        public static bool isReset = true;
        public static int isResethojo=0;
        public static bool isPlaying = true;
        private Rigidbody2D rig;
        private Transform tra;
        [SerializeField] private int speed=7;
        // Start is called before the first frame update
        async void Start()
        {
            rig=GetComponent<Rigidbody2D>();
            await Task.Delay(1);
            transform.position = new Vector3(StageManager.stages[0].baniX, 6, 0);
        }
        void Update()
        {
            if (transform.position.y < -5)
            {
                isReset = true;
                isResethojo = 0;
            }
            else
            {
                if (isResethojo>3)
                {
                    isReset = false;
                }
                else
                {
                    isResethojo ++;
                }
            }
            if (rig.gravityScale == 0)
            {
                isPlaying = false;
            }
            else
            {
                isPlaying = true;
            }
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("bane"))
            {
                rig.velocity = new Vector2(rig.velocity.x, speed);
            }
        }

    }
}