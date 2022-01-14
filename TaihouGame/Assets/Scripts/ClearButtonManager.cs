using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SM;

public class ClearButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickedNext()
    {
        StageManager.stageNum++;
        SceneManager.LoadScene("Stage");
    }
    public void OnClickedBackTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
