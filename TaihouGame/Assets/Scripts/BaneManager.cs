using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SM;

public class BaneManager : MonoBehaviour
{
    [SerializeField] private GameObject bane;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateStage());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator CreateStage()
    {
        yield return new WaitForSeconds(0.01f);
        foreach (Vector3 vec in StageManager.stages[StageManager.stageNum - 1].baneInform)
        {
            bane.transform.localScale = new Vector2(vec.z, vec.z);
            Instantiate(bane, new Vector2(vec.x,vec.y), Quaternion.identity);
        }
    }
}
