using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
using DG.Tweening;
namespace Puzzle
{
    public class Board : MonoBehaviour
    {
        [SerializeField] GameObject prefab;
        List<List<Drop>> dropList = new List<List<Drop>>();
        public GameObject canvasObject;
        void Start()
        {
            for (int i = 0; i < ParameterManager.Instance.boardSize.x; i++)
            {
                dropList.Add(new List<Drop>());
                for (int j = 0; j < ParameterManager.Instance.boardSize.y; j++)
                {
                    Vector2Int pos = new Vector2Int(i, j);
                    Type type = (Type)Random.Range(0, ColorManager.Instance.COLORMAXKIND);
                    Drop drop = new Drop(pos, type,prefab,canvasObject);
                    dropList[i].Add(drop);
                }
            }
            Viewing();
        }
        void Viewing()
        {
            foreach(var drops in dropList)
            {
                foreach(var drop in drops)
                {
                    //GameObject dropobject = Instantiate(prefab,canvasObject.transform);
                    //Vector2 pos = ((Vector2)drop.pos+new Vector2(-2,-2.5f))*100;
                    //dropobject.transform.localPosition = pos;
                }
            }
        }

        public void ChangeDrop(Vector2Int dropPosA ,Vector2Int dropPosB)
        {
            Vector2 canvasPosA = ParameterManager.Instance.GetDropCanvasPosition(dropPosA);
            Vector2 canvasPosB = ParameterManager.Instance.GetDropCanvasPosition(dropPosB);
            try
            {
                dropList[dropPosA.x][dropPosA.y].Move(canvasPosB);
                dropList[dropPosB.x][dropPosB.y].Move(canvasPosA);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                Debug.Log((dropPosA, dropPosB));
            }
            Drop temp = dropList[dropPosA.x][dropPosA.y];
            dropList[dropPosA.x][dropPosA.y] = dropList[dropPosB.x][dropPosB.y];
            dropList[dropPosB.x][dropPosB.y] = temp;
        }
    }
}
