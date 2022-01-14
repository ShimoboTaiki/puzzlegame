using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using StartPush;
using StageM;
using Reset;

public class BaneManager : MonoBehaviour
{
    public Bane bane;
    BoxCollider2D col;
    private List<Bane> baneList = new List<Bane>();
    private int stageN;
    // Start is called before the first frame update
    async void Start()
    {
        await Task.Delay(3);
        stageN = 1;
        col = bane.GetComponent<BoxCollider2D>();
        col.size = new Vector2(1, 5);
        for (int i = 0; i < StageManager.stages[0].baneInform.Count; i++)
        {
            bane.transform.localScale = new Vector3(StageManager.stages[0].baneInform[i].y, 0.1f, 0);
            baneList.Add(Instantiate(bane, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, StageManager.stages[0].baneInform[i].x)));
        }
    }

    void Update()
    {
        if (GameStart.isPushed)
        {
            foreach (Bane b in baneList)
            {
                BoxCollider2D yukaCol = b.GetComponent<BoxCollider2D>();
                yukaCol.size = new Vector2(1, 1);
            }
        }

        if (stageN != StageManager.stageNum)
        {
            stageN = StageManager.stageNum;
            foreach (Bane b in baneList)
            {
                Destroy(b.gameObject);
            }
            baneList.Clear();
            for (int i = 0; i < StageManager.stages[stageN - 1].baneInform.Count; i++)
            {
                bane.transform.localScale = new Vector3(StageManager.stages[stageN - 1].baneInform[i].y * 3, 0.1f, 0);
                baneList.Add(Instantiate(bane, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, StageManager.stages[stageN - 1].baneInform[i].x)));
            }
        }
        if (Ball.isReset)
        {
            foreach (Bane b in baneList)
            {
                BoxCollider2D yukaCol = b.GetComponent<BoxCollider2D>();
                yukaCol.size = new Vector2(1, 5);
            }
        }
    }
}