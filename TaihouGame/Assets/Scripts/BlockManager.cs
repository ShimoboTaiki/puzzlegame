using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SM;

public class BlockManager : MonoBehaviour
{
    [SerializeField] Block block;
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
        foreach (Vector4 vec in StageManager.stages[StageManager.stageNum-1].blockInform)
        {
            block.transform.localScale = new Vector2(vec.z, vec.w);
            Instantiate(block, new Vector2(vec.x,vec.y), Quaternion.identity);
        }
    }
}
