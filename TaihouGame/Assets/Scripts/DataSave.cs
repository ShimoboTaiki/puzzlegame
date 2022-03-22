using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SelectStage;
using IM;

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
            ItemManager.bigBaniCount = PlayerPrefs.GetInt("saveItemBigBani", 3);
            ItemManager.zeroGravityCount = PlayerPrefs.GetInt("saveItemZeroGravity", 3);
            ItemManager.penetrationCount = PlayerPrefs.GetInt("saveItemPenetration", 3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        PlayerPrefs.SetInt("saveStageNum", GoStageButton.maxStageNum);
        PlayerPrefs.SetInt("saveItemBigBani", ItemManager.bigBaniCount);
        PlayerPrefs.SetInt("saveItemZeroGravity",ItemManager.zeroGravityCount);
        PlayerPrefs.SetInt("saveItemPenetration",ItemManager.penetrationCount);
        PlayerPrefs.Save();
    }
}
