using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Manager
{
    public class ParameterManager : SingletonMonoBehaviour<ParameterManager>
    {
        public Vector2Int boardSize=new Vector2Int(6,5);
        public Vector2 adjestPos = new Vector2(-2.5f, 2);
        public float dropLenght = 100;
        [Header("ドロップが動くのにかかる時間"),Range(0.1f,1)] public float moveTime = 0.5f;
        [Header("ドロップが消える個数")] public int destroyDropCount=3;
        [FormerlySerializedAs("prefab")] public GameObject dropPrefab;

        public Vector2Int GetDropPosition(Vector2 mousePos)
        {
            Vector2 pos;
            pos.x = mousePos.x - Screen.width/2;
            pos.y = mousePos.y - Screen.height/2;
            pos = Vector2Int.CeilToInt(pos / dropLenght - adjestPos-Vector2.one/2); 
            return Vector2Int.RoundToInt(pos);
        }
        public Vector2 GetDropCanvasPosition(Vector2Int dropPos)
        {
            return (dropPos + ParameterManager.Instance.adjestPos) * ParameterManager.Instance.dropLenght;
            
        }

        public bool InBoard(Vector2Int pos)
        {
            return 0 <= pos.x && pos.x < boardSize.x && 0 <= pos.y && pos.y < boardSize.y;
        }
    }
}