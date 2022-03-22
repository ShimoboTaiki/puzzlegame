using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SelectStage;
using IM;

public class DataSaveOnly : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
