using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SM;

namespace SelectStage
{
    public class GoStageButton : MonoBehaviour
    {
        [SerializeField] private int buttonNumber;
        [SerializeField] private Text text;
        public static int maxStageNum;
        private bool isLocked;
        // Start is called before the first frame update
        void Start()
        {

            if (buttonNumber < maxStageNum + 1)
            {
                text.fontSize = 100;
                text.text = buttonNumber.ToString();
                isLocked = false;

            }
            else
            {
                text.fontSize = 50;
                text.text = buttonNumber.ToString() + "\nlocked";
                isLocked = true;
            }

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnClickedGoStage()
        {

            if (!isLocked)
            {
                StageManager.stageNum = buttonNumber;

                SceneManager.LoadScene("Stage");
            }

        }
    }
}