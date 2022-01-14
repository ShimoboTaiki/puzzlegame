using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using StageM;
using Reset;

namespace ItemM
{
    public class ItemManager : MonoBehaviour
    {
        public Item item;
        private List<Item> itemList = new List<Item>();
        public static int itemCount;
        private int stageN;
        // Start is called before the first frame update
        async void Start()
        {
            await Task.Delay(1);
            stageN = 1;
            itemCount = StageManager.stages[0].itemPos.Count;
            for (int i = 0; i < itemCount; i++)
            {
                itemList.Add(Instantiate(item, StageManager.stages[0].itemPos[i], new Quaternion(0, 0, 0, 0)));
            }
        }

        void Update()
        {
            if (stageN != StageManager.stageNum)
            {
                stageN = StageManager.stageNum;
                itemList.Clear();
                itemCount = StageManager.stages[stageN - 1].itemPos.Count;
                foreach(Vector3 vec in StageManager.stages[stageN - 1].itemPos)
                {
                    itemList.Add(Instantiate(item, vec, new Quaternion(0, 0, 0, 0)));
                }
            }
            if (Ball.isReset)
            {
                foreach(Item item in itemList)
                {
                    if (item != null)
                    {
                        Destroy(item.gameObject);
                    }
                }
                itemList.Clear();
                itemCount = StageManager.stages[stageN - 1].itemPos.Count;
                for(int i = 0; i< itemCount; i++)
                {
                    itemList.Add(Instantiate(item, StageManager.stages[stageN - 1].itemPos[i], new Quaternion(0, 0, 0, 0)));
                }
            }
        }
    }
}