using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SM;

namespace Count
{
    public class BallCountManager : MonoBehaviour
    {
        public static int ballCount=1;
        public static int destroyballCount;
        [SerializeField] private Text ballCountText;
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(CreateStage());
        }

        // Update is called once per frame
        void Update()
        {
            ballCountText.text = "残りばに" + ballCount.ToString() + "個";
            if (ballCount == 0&&destroyballCount==0)
            {
                ballCount = 1;
                SceneManager.LoadScene("GameOver");
            }
        }

        private IEnumerator CreateStage()
        {
            yield return new WaitForSeconds(0.01f);
            ballCount = StageManager.stages[StageManager.stageNum - 1].ballCount;
            destroyballCount = ballCount;
        }
    }
}