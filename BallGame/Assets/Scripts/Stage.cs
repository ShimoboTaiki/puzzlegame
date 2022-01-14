using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public int baniX;
    public List<Vector3> itemPos = new List<Vector3>();
    public List<Vector2> yukaInform = new List<Vector2>();
    public Vector3 goalPos;
    public Vector3 buttonPos;
    public List<Vector2> baneInform = new List<Vector2>();
    public List<Vector4> jamaInform = new List<Vector4>();

    public Stage(int baniX, List<Vector3> itemPos, List<Vector2> yukaInform, Vector3 goalPos, Vector3 buttonPos, List<Vector2> baneInform, List<Vector4> jamInform)
    {
        this.baniX = baniX;
        this.itemPos = itemPos;
        this.yukaInform = yukaInform;
        this.goalPos = goalPos;
        this.buttonPos = buttonPos;
        this.baneInform = baneInform;
        this.jamaInform = jamInform;
    }
}
