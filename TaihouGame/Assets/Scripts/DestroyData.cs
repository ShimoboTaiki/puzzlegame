using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SelectStage;

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
    }
}
