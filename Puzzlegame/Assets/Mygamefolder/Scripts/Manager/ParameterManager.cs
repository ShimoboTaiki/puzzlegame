using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class ParameterManager : SingletonMonoBehaviour<ParameterManager>
    {
        public Vector2Int boardSize=new Vector2Int(6,5);
        public Vector2 adjestPos = new Vector2(-2.5f, 2);
        public float dropLenght = 100;

        public Vector2 GetDropPosition(Vector2 mousePos)
        {
            Vector2 pos;
            pos.x = mousePos.x - Screen.width/2;
            pos.y = mousePos.y - Screen.height/2;
            pos = Vector2Int.CeilToInt(pos / dropLenght - adjestPos-Vector2.one/2); 
            return pos;
        }
    }
}