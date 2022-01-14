using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using StartPush;
using StageM;
using Reset;

public class YukaManager : MonoBehaviour
{
    public Yuka yuka;
    BoxCollider2D col;
    private List<Yuka> yukaList = new List<Yuka>();
    private int stageN;
    private bool r=false;
    // Start is called before the first frame update
    void Start()
    {
        stageN = 1;
        col = yuka.GetComponent<BoxCollider2D>();
        col.size = new Vector2(1, 5);
        for (int i = 0; i < StageManager.stages[0].yukaInform.Count; i++)
        {
            yuka.transform.localScale= new Vector3(StageManager.stages[0].yukaInform[i].y*3, 0.1f, 0);
            yukaList.Add(Instantiate(yuka, new Vector3(0, 0, 0), Quaternion.Euler(0,0,StageManager.stages[0].yukaInform[i].x)));
        }
    }

    void Update()
    {
        if (GameStart.isPushed)
        {
            GameStart.isPushed = false;
            foreach (Yuka y in yukaList)
            {
                BoxCollider2D yukaCol = y.GetComponent<BoxCollider2D>();
                yukaCol.size = new Vector2(1, 1);
            }
        }

        if (stageN != StageManager.stageNum)
        {
            stageN = StageManager.stageNum;
            foreach(Yuka yuka in yukaList)
            {
                Destroy(yuka.gameObject);
            }
            yukaList.Clear();
            for (int i = 0; i < StageManager.stages[stageN - 1].yukaInform.Count; i++)
            {
                yuka.transform.localScale = new Vector3(StageManager.stages[stageN - 1].yukaInform[i].y * 3, 0.1f, 0);
                yukaList.Add(Instantiate(yuka, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, StageManager.stages[stageN - 1].yukaInform[i].x)));
            }
        }
        if (Ball.isReset)
        {
            foreach (Yuka y in yukaList)
            {
                BoxCollider2D yukaCol = y.GetComponent<BoxCollider2D>();
                yukaCol.size = new Vector2(1, 5);
            }
        } 
    }
}
