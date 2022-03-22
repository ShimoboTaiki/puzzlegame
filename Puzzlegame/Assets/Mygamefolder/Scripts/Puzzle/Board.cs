using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
using DG.Tweening;
using UnityEngine.UI;
namespace Puzzle
{
    public class Board : MonoBehaviour
    {
        List<List<Drop>> dropList = new List<List<Drop>>();
        public GameObject canvasObject;
        public Text debugText;
        void Start()
        {
            for (int i = 0; i < ParameterManager.Instance.boardSize.x; i++)
            {
                dropList.Add(new List<Drop>());
                for (int j = 0; j < ParameterManager.Instance.boardSize.y; j++)
                {
                    Vector2Int pos = new Vector2Int(i, j);
                    Type type = (Type)Random.Range(0, ColorManager.Instance.COLORMAXKIND);
                    Drop drop = new Drop(pos, type,canvasObject);
                    dropList[i].Add(drop);
                }
            }
            Viewing();
        }

        void Update()
        {

            string boardText = "";
            for (int j =ParameterManager.Instance.boardSize.y-1; j >=0  ; j--)
            {
                for (int i = 0; i < ParameterManager.Instance.boardSize.x; i++)
                {
                    if (dropList[i][j] == null)
                    {
                        boardText += "N";
                    }
                    else
                    {
                        if (dropList[i][j].deleteFlag)
                        {
                            boardText += "<color=white>";
                        }
                        else
                        {
                            boardText += "<color=black>";
                        }
                        switch (dropList[i][j].type)
                        {
                            case Type.blue:
                                boardText += "B";
                                break;
                            case Type.green:
                                boardText += "G";
                                break;
                            case Type.yellow:
                                boardText += "Y";
                                break;
                            case Type.red:
                                boardText += "R";
                                break;
                        }

                        boardText += "</color>";
                    }
                }

                boardText += System.Environment.NewLine;
            }

            debugText.text = boardText;
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

        public void Otosu()
        {
            FallDrop();
            
        }

        public void OtosuMitame()
        {
            for (int i = 0; i < ParameterManager.Instance.boardSize.x; i++)
            {
                for (int j = 0; j < ParameterManager.Instance.boardSize.y; j++)
                {
                    if (dropList[i][j] != null)
                    {
                        dropList[i][j].IndexMove(new Vector2Int(i,j));
                    }
                }
            }
        }

        public Combo SearchCombo(Vector2Int pos)
        {
            Combo combo = new Combo();
            combo.type = dropList[pos.x][pos.y].type;
            
            dropList.ForEach(list=>list.ForEach(drop=>drop.deleteFlag=false));
            List<Drop> horizontalDropList = GetComboDirection(pos, Vector2Int.right);
            List<Drop> verticalDropList = GetComboDirection(pos, Vector2Int.up);
            combo.comboDrops.UnionWith(horizontalDropList);
            combo.comboDrops.UnionWith(verticalDropList);
            if (combo.comboDrops.Count >= 3)
            {
                int actionListCount = 0X7FEFFFFF;
            }
            return combo;
        }

        public List<Drop> GetComboDirection(Vector2Int pos, Vector2Int searchVec)
        {
            Type type = dropList[pos.x][pos.y].type;
            List<Drop> returnList=new List<Drop>();
            returnList.Add(dropList[pos.x][pos.y]);
            while (true)
            {
                pos += searchVec;
                if (ParameterManager.Instance.InBoard(pos) && type == dropList[pos.x][pos.y].type)
                {
                    returnList.Add( dropList[pos.x][pos.y]);
                }
                else
                {
                    break;
                }
            }

            if (!(returnList.Count >= ParameterManager.Instance.destroyDropCount))
            {
                returnList.Clear();
            }
            else
            {

                returnList.ForEach(drop =>  drop.deleteFlag = true);
            }

            return returnList;

        }
        private void DeleteDrop(List<Combo> combos)
        {
            // foreach (Combo combo in combos)
            // {
            //     foreach (Drop drop in combo.comboDrops)
            //     {
            //         this.dropList[drop.pos.x][drop.pos.y] = null;
            //         Debug.Log(drop.pos);
            //         drop.Delete();
            //     }
            // }
            for (int i = 0; i < ParameterManager.Instance.boardSize.x;i++)
            {
                for (int j = 0; j < ParameterManager.Instance.boardSize.y; j++)
                {
                    if (dropList[i][j].deleteFlag)
                    {
                        dropList[i][j].Delete();     
                    }
                }
            }
        }
//TODO:ドロップの落ちる処理を実装する
        private void FallDrop()
        {
            for (int i = 0; i < ParameterManager.Instance.boardSize.x; i++)
            {
                for (int j = 1; j < ParameterManager.Instance.boardSize.y; j++)
                {
                    if (dropList[i][j] == null)
                    {
                        continue;
                    }

                    int searchPosY=j-1;
                    while (dropList[i][searchPosY] == null)
                    {
                        searchPosY--;
                        if (!ParameterManager.Instance.InBoard(new Vector2Int(i, searchPosY-1 )))
                        {
                            break;
                        }

                        

                    }

                    searchPosY++;
                    

                    if (j!=searchPosY )
                    {
                        try
                        {
                            dropList[i][searchPosY] = dropList[i][j];
                            dropList[i][j] = null;
                        }
                        catch (System.Exception e)
                        {
                            Debug.LogError(e);
                        }
                    }
                }
            }
        }

        
    }
}
