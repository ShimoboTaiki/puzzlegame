using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Threading;
using StageM;

public class JamaManager : MonoBehaviour
{
    public Jama jama;
    private int stageN;
    private List<Jama> jamaList = new List<Jama>();
    private Transform tra;
    // Start is called before the first frame update
    async void Start()
    {
        await Task.Delay(1);
        stageN = 1;
        tra = jama.GetComponent<Transform>();
        foreach (Vector4 vec in StageManager.stages[0].jamaInform)
        {
            tra.localScale = new Vector3(vec.z, vec.w, 0);
            jamaList.Add(Instantiate(jama, new Vector3(vec.x, vec.y, 0), new Quaternion(0, 0, 0, 0)));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (stageN != StageManager.stageNum)
        {
            stageN = StageManager.stageNum;
            foreach (Jama jama in jamaList)
            {
                Destroy(jama.gameObject);
            }
            jamaList.Clear();
            foreach (Vector4 vec in StageManager.stages[stageN - 1].jamaInform)
            {
                tra.localScale = new Vector3(vec.z, vec.w, 0);
                jamaList.Add(Instantiate(jama, new Vector3(vec.x, vec.y), new Quaternion(0, 0, 0, 0)));
            }
        }
    }
}
