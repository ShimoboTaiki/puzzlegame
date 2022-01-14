using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using ItemM;
using StageM;

public class GoalManager : MonoBehaviour
{
   [SerializeField]private GameObject goal;
    Material mat;
    private int stageN;
    // Start is called before the first frame update
    void Start()
    {
        goal.transform.position = StageManager.stages[0].goalPos;
        mat = goal.GetComponent<Renderer>().material;
        mat.color = new Color(1, 0, 0, 1);
        stageN = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (ItemManager.itemCount == 0)
        {
            mat.color = new Color(0, 0.5f, 1, 1);
        }
        else
        {
            mat.color = new Color(1, 0, 0, 1);
        }
        if (stageN != StageManager.stageNum)
        {
            stageN = StageManager.stageNum;
            goal.transform.position = StageManager.stages[stageN-1].goalPos;
            mat.color = new Color(1, 0, 0, 1);
        }
    }
}
