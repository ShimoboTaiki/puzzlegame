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

        public void ChangeDrop(Vector2Int dropPosA, Vector2Int dropPosB)
        {
            if ((!ParameterManager.Instance.InBoard(dropPosA)) || (!ParameterManager.Instance.InBoard(dropPosB)))
            {
                Debug.LogWarning("画面外が指定されました。");
                return;
            }
            Vector2 canvasPosA = ParameterManager.Instance.GetDropCanvasPosition(dropPosA);
            Vector2 canvasPosB = ParameterManager.Instance.GetDropCanvasPosition(dropPosB);

            dropList[dropPosA.x][dropPosA.y].Move(canvasPosB);
            dropList[dropPosB.x][dropPosB.y].Move(canvasPosA);
            Drop temp = dropList[dropPosA.x][dropPosA.y];
            dropList[dropPosA.x][dropPosA.y] = dropList[dropPosB.x][dropPosB.y];
            dropList[dropPosB.x][dropPosB.y] = temp;
        }

        public void PuzzleProcess()
        {
            List<Combo> combos = new List<Combo>();
            for(int i = 0; i< ParameterManager.Instance.boardSize.x;i++)
            {
                for(int j=0; j < ParameterManager.Instance.boardSize.y; j++)
                {
                    Combo combo = new Combo();
                    combo = this.SearchCombo(new Vector2Int(i, j));
                    
                    if (combo.comboDrops.Count!=0)
                    {
                        combos.Add(combo);
                    }
                    //combos.Add(board.SearchCombo(new Vector2Int(i, j)))
                }
            }
            Debug.Log(combos.Count);
            DeleteDrop(combos);
        }

        public Combo SearchCombo(Vector2Int pos)
        {
            Combo combo = new Combo();
            Vector2Int searchPos;
            searchPos = pos;
            combo.type = dropList[pos.x][pos.y].type;
            int deleteCount = ParameterManager.Instance.destroyDropCount;
            if (pos.x < ParameterManager.Instance.boardSize.x+1 - deleteCount)
            {

                while (dropList[searchPos.x][searchPos.y].type
                    == dropList[pos.x][pos.y].type)
                {
                    if ((!ParameterManager.Instance.InBoard(searchPos + 1 * Vector2Int.right)) || (dropList[searchPos.x+1][searchPos.y].type!=dropList[pos.x][pos.y].type))
                    {
                        break;
                    }
                    searchPos.x++;

                }
            }
            if (pos.x ==3)
            {
                Debug.Log("");
            }
            if (searchPos.x - pos.x >= ParameterManager.Instance.destroyDropCount - 1)
            {
                
                for (int i = 0; i < searchPos.x - pos.x+1 ; i++)
                {
                    combo.comboDrops.Add(dropList[i + pos.x][pos.y]);

                }
            }
            else
            {
                Vector2Int hoge = searchPos;
                hoge = pos;
                Debug.Log("加算されませんでした");
            }

            searchPos = pos;
            if (pos.y < ParameterManager.Instance.boardSize.y+1 - deleteCount)
            {
                while (dropList[searchPos.x][searchPos.y].type
                    == dropList[pos.x][pos.y].type)
                {
                    if ((!ParameterManager.Instance.InBoard(searchPos + 1 * Vector2Int.up)) || (dropList[searchPos.x][searchPos.y+1].type!=dropList[pos.x][pos.y].type))
                    {
                        break;
                    }
                    searchPos.y++;

                }

            }
            if (searchPos.y - pos.y >= ParameterManager.Instance.destroyDropCount - 1)
            {
                for (int i = 0; i < searchPos.y - pos.y+1 ; i++)
                {
                    combo.comboDrops.Add(dropList[pos.x][i + pos.y]);
                }
            }
            else
            {
                Vector2Int hoge = searchPos;
                hoge = pos;
                Debug.Log("加算されませんでした");
            }
            //if (combo.comboDrop.Count == 0)
            //{
            //    return;
            //}
            //else
            //{
            //    return combo;
            //}
            return combo;
        }

        private void DeleteDrop(List<Combo> combos)
        {
            foreach (Combo combo in combos)
            {
                foreach (Drop drop in combo.comboDrops)
                {
                    this.dropList[drop.pos.x][drop.pos.y] = null;
                    drop.Delete();
                }
            }
        }
//TODO:ドロップの落ちる処理を実装する
        private void FallDrop()
        {
            
        }

        
    }
}
