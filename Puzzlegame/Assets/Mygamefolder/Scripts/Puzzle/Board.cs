using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
using DG.Tweening;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using
System;
using Random = UnityEngine.Random;

namespace Puzzle
{
    public class Board : MonoBehaviour
    {
        List<List<Drop>> dropList = new List<List<Drop>>();
        public GameObject canvasObject;
        public Text debugText;
        
        void Awake()
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
            if (dropList.Count == ParameterManager.Instance.boardSize.x)
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

        public async UniTaskVoid PuzzleProcess()
        {
            for(int i = 0; i< ParameterManager.Instance.boardSize.x;i++)
            {
                for(int j=0; j < ParameterManager.Instance.boardSize.y; j++)
                {
                    if (this.SearchCombo(new Vector2Int(i, j)))
                    {
                        DeleteDrop();
                        await UniTask.Delay(TimeSpan.FromSeconds(0.5));
                    }
                }
            }
            

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

        public bool SearchCombo(Vector2Int pos)
        {
            if (dropList[pos.x][pos.y].deleteFlag)
            {
                return false;
            }
           // Type  type = dropList[pos.x][pos.y].type;
           
            bool rightFlag =GetComboDirection(pos, Vector2Int.right);
            bool upFlag =GetComboDirection(pos, Vector2Int.up);
            return rightFlag || upFlag;
        }

        public bool GetComboDirection(Vector2Int pos, Vector2Int searchVec)
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



            return returnList.Count >= ParameterManager.Instance.destroyDropCount;

        }
        private void DeleteDrop()
        {
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

            int a = 1;
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
