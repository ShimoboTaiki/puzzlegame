using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SM;
using SelectStage;

public class GameClear : MonoBehaviour
{
    [SerializeField] private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "Stage" + StageManager.stageNum + "クリア!!";
        if (StageManager.stageNum == GoStageButton.maxStageNum)
        {
            GoStageButton.maxStageNum++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
