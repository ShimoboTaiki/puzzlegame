using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SelectStage;

public class DataSave : MonoBehaviour
{
    public static bool isLoaded=false;
    // Start is called before the first frame update
    void Start()
    {
        if (!isLoaded)
        {
            GoStageButton.maxStageNum = PlayerPrefs.GetInt("saveStageNum", 1);
            isLoaded = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        PlayerPrefs.SetInt("saveStageNum", GoStageButton.maxStageNum);
        PlayerPrefs.Save();
    }
}
