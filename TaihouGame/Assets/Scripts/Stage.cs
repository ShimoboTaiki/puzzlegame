using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public int ballCount;
    public List<Vector2> enemyList = new List<Vector2>();
    public List<Vector4> blockInform = new List<Vector4>();
    public List<Vector4> FBlockInform = new List<Vector4>();
    public List<Vector3> baneInform = new List<Vector3>();


    public Stage(int ballCount,List<Vector2> enemyList,List<Vector4> blockInform,List<Vector4> FBlockInform,List<Vector3> baneInform)
    {
        this.ballCount = ballCount;
        this.enemyList = enemyList;
        this.blockInform = blockInform;
        this.FBlockInform = FBlockInform;
        this.baneInform = baneInform;
    }
}
