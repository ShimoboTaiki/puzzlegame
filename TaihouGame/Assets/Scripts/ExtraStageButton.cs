using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExStage;

public class ExtraStageButton : MonoBehaviour
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
        if (ExtraStage.canGoExtraStage)
        {
            if (ExtraStage.isExtraStage)
            {
                ExtraStage.isExtraStage = false;
            }
            else
            {
                ExtraStage.isExtraStage = true;
            }
        }
    }
}
