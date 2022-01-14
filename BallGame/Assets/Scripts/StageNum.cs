using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StageM;

public class StageNum : MonoBehaviour
{
    public Text stageNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        stageNumber.text = "Stage"+StageManager.stageNum.ToString();
    }
}
