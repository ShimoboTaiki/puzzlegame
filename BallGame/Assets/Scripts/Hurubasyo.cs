using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StageM; 

public class Hurubasyo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(StageManager.stages[StageManager.stageNum-1].baniX*450/2.815f, 550, 0);
    }
}
