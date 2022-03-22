using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SelectStage;
using IM;

public class DestroyData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClicked()
    {
        PlayerPrefs.DeleteAll();
        GoStageButton.maxStageNum = 1;
        ItemManager.bigBaniCount = 3;
        ItemManager.zeroGravityCount = 3;
        ItemManager.penetrationCount = 3;

    }
}
