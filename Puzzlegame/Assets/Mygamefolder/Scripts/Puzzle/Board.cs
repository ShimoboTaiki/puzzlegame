using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Puzzle
{
    public class Board : MonoBehaviour
    {
        [SerializeField] GameObject prefab;
        List<List<Drop>> dropList = new List<List<Drop>>();
        public GameObject canvasObject;
        void Start()
        {
            for (int i = 0; i < 5; i++)
            {
                dropList.Add(new List<Drop>());
                for (int j = 0; j < 6; j++)
                {
                    Vector2Int pos = new Vector2Int(i, j);
                    Type type = Type.red;
                    Drop drop = new Drop(pos, type);
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
                    GameObject dropobject = Instantiate(prefab,canvasObject.transform);
                    Vector2 pos = ((Vector2)drop.pos+new Vector2(-2,-2.5f))*100;
                    dropobject.transform.localPosition = pos;
                }
            }
        }
    }
}
