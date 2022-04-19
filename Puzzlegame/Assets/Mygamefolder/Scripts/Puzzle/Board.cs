using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
using DG.Tweening;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using System;
using System.Linq;
using Random = UnityEngine.Random;
using UniRx;
using UniRx.Triggers;

namespace Puzzle
{
    public class Board : MonoBehaviour
    {
        private List<List<Drop>> dropList = new List<List<Drop>>();
        public GameObject canvasObject;
        public Text debugText;
        private List<HashSet<Drop>> _comboDrops = new List<HashSet<Drop>>();

        private readonly List<Vector2Int> _directions = new List<Vector2Int>()
            {Vector2Int.down, Vector2Int.up, Vector2Int.right, Vector2Int.left,};

        private int boardSizeX;
        private int boardSizeY;

        void Awake()
        {
            boardSizeX = ParameterManager.Instance.boardSize.x;
            boardSizeY = ParameterManager.Instance.boardSize.y;
            for (int i = 0; i < boardSizeX; i++)
            {
                dropList.Add(new List<Drop>());
                for (int j = 0; j < boardSizeY; j++)
                {
                    var drop = CreateDrop(i, j);
                    dropList[i].Add(drop);
                }
            }

            this.UpdateAsObservable().Subscribe(_ => Viewing()).AddTo(this);
        }

        private Drop CreateDrop(int i, int j)
        {
            Vector2Int pos = new Vector2Int(i, j);
            Type type = (Type) Random.Range(0, ColorManager.Instance.COLORMAXKIND);
            Drop drop = new Drop(pos, type, canvasObject);
            return drop;
        }

        private Drop CreateFallDrop(int i, int j,Vector2Int viewIndexPos)
        {
            Drop drop = CreateDrop(i, j);
            drop.SetIndexViewPosition(viewIndexPos);
            return drop;
        }

        void Viewing()
        {
            try
            {
                string boardText = "";
                for (int j = boardSizeY - 1; j >= 0; j--)
                {
                    for (int i = 0; i < boardSizeX; i++)
                    {
                        if (dropList[i][j] == null)
                        {
                            boardText += "N";
                        }
                        else
                        {
                            if (dropList[i][j].deleteIndex >= 0)
                            {
                                boardText += "<color=white>";
                            }
                            else
                                boardText += "<color=black>";

                            boardText += dropList[i][j].type switch
                            {
                                Type.blue => "B",
                                Type.green => "G",
                                Type.yellow => "Y",
                                Type.red => "R",
                                _ => throw new ArgumentOutOfRangeException()
                            };
                            boardText += "</color>";
                        }
                    }

                    boardText += System.Environment.NewLine;
                }

                debugText.text = boardText;
            }
            catch (ArgumentOutOfRangeException e)
            {
                debugText.text = "只今、drop listの中身を操作中...";
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
            (dropList[dropPosA.x][dropPosA.y], dropList[dropPosB.x][dropPosB.y]) = (dropList[dropPosB.x][dropPosB.y],
                dropList[dropPosA.x][dropPosA.y]);
        }

        public async UniTask PuzzleProcess()
        {
            _comboDrops.Clear();

            for (int i = 0; i < boardSizeX; i++)
            {
                for (int j = 0; j < boardSizeY; j++)
                {
                    SearchCombo(new Vector2Int(i, j));
                }
            }

            for (int i = 0; i < boardSizeX; i++)
            {
                for (int j = 0; j < boardSizeY; j++)
                {
                    JoinCombo(new Vector2Int(i, j),new Vector2Int(1,0));
                    JoinCombo(new Vector2Int(i, j),new Vector2Int(0,1));
                    // JoinCombo(new Vector2Int(i, j),new Vector2Int(1,0));
                    // JoinCombo(new Vector2Int(i, j),new Vector2Int(1,0));
                    
                }
            }

            await DeleteDrop();
            FallDrop();
        }




        private void SearchCombo(Vector2Int pos)
        {
            if (dropList[pos.x][pos.y] != null)
            {
                if (dropList[pos.x][pos.y].deleteIndex >= 0)
                {
                    return;
                }
            }
            _directions.ForEach(direction => GetComboDirection(pos, direction));
        }

        private void GetComboDirection(Vector2Int pos, Vector2Int searchVec)
        {
            if (dropList[pos.x][pos.y] == null) return;

            var type = dropList[pos.x][pos.y].type;
            var drops = new HashSet<Drop> {dropList[pos.x][pos.y]};
            while (true)
            {
                pos += searchVec;

                if (ParameterManager.Instance.InBoard(pos) && type == dropList[pos.x][pos.y].type)
                {
                    drops.Add(dropList[pos.x][pos.y]);
                }
                else
                {
                    break;
                }
            }

            if (drops.Count < ParameterManager.Instance.destroyDropCount) return;

            if (drops.Any(drop => drop.deleteIndex >= 0))
            {
                //他でコンボにカウントされているか探索
                var otherComboJoinDrops = drops.Where(drop => drop.deleteIndex >= 0)
                    //.OrderBy(x => x) //左下から消えてほしいので昇順ソート
                    .ToList();

                //今回見つかったコンボとindex[0]を結合
                var margeTargetCombo = _comboDrops[otherComboJoinDrops[0].deleteIndex];
                margeTargetCombo.UnionWith(drops);

                //既存のもので今回結合できることが明らかになったコンボのインデックスの一覧を取得する
                var margeIndexes = otherComboJoinDrops
                    .Skip(1) //1番の要素に対してマージするので、1回処理をスキップする。
                    .Select(drop => drop.deleteIndex)
                    .OrderBy(x => -x) //下でRemoveAtにてIndexを使用している。前の方から詰めて消すとインデックスがずれるため逆順にソートしている
                    .ToList();

                //既存のコンボと今回マージできるものを結合している
                margeIndexes.ForEach(comboIndex => margeTargetCombo.UnionWith(_comboDrops[comboIndex]));

                //結合した既存コンボをリストから除外 
                margeIndexes.ForEach(comboIndex => _comboDrops.RemoveAt(comboIndex));

                //deleteIndexの上書き
                margeTargetCombo.ToList().ForEach(drop => drop.deleteIndex = otherComboJoinDrops[0].deleteIndex);
            }
            else
            {
                drops.ToList().ForEach(drop => drop.deleteIndex = _comboDrops.Count);
                _comboDrops.Add(drops);
            }
        }

        private async UniTask DeleteDrop()
        {
            for (int index = 0; index < _comboDrops.Count; index++)
            {
                List<Drop> deleteList = new List<Drop>();
                for (int i = 0; i < boardSizeX; i++)
                {
                    for (int j = 0; j < boardSizeY; j++)
                    {
                        if (index == dropList[i][j].deleteIndex)
                        {
                            deleteList.Add(dropList[i][j]);
                        }
                    }
                }

                deleteList.ForEach(drop => drop.Delete());
                await UniTask.Delay(TimeSpan.FromSeconds(0.5));
            }
            
        }

        //TODO:ドロップの落ちる処理を実装する
        private void FallDrop()
        {
            #region Dropへのロジック部分
            
            for (int i = 0; i < boardSizeX; i++)
            {
                dropList[i] = dropList[i].Where(drop => drop != null && drop.deleteIndex < 0).ToList();
                for (int j = 0; j < boardSizeY; j++)
                {
                    if (j<dropList[i].Count)
                    {
                        dropList[i][j].pos = new Vector2Int(i, j);
                    }
                    else
                    {
                        dropList[i].Add(CreateFallDrop(i, j ,new Vector2Int(i,j+ParameterManager.Instance.boardSize.y)));
                    }
                }
            }
            #endregion
            #region Dropの見た目

            for (int i = 0; i < boardSizeX; i++)
            {
                for (int j = 0; j < boardSizeY; j++)
                {
                    dropList[i][j].IndexMove(dropList[i][j].pos);
                }
            }
            #endregion
        }

        private void JoinCombo(Vector2Int pos,Vector2Int searchVec)
        {
            if (!ParameterManager.Instance.InBoard(pos + searchVec)) return;

            int posIndex = dropList[pos.x][pos.y].deleteIndex;
            int searchPosIndex = dropList[pos.x+searchVec.x][pos.y+searchVec.y].deleteIndex;

            if (dropList[pos.x][pos.y].type == dropList[pos.x + searchVec.x][pos.y + searchVec.y].type)
            {
                if (posIndex >= 0 && searchPosIndex >= 0)
                {
                    if(posIndex==searchPosIndex)return;

                    foreach (var drop in _comboDrops[Math.Max(posIndex, searchPosIndex)])
                    {
                        _comboDrops[Math.Min(posIndex, searchPosIndex)].Add(drop);
                        
                        drop.deleteIndex = Math.Min(posIndex, searchPosIndex);
                    }

                    foreach (var dropSet in _comboDrops)
                    {
                        foreach (var drop in dropSet)
                        {
                            if (drop.deleteIndex > Math.Max(posIndex, searchPosIndex))
                            {
                                drop.deleteIndex--;
                            }
                        }
                    }

                    _comboDrops.RemoveAt(Math.Max(posIndex, searchPosIndex));
                }
            }
        }
    }
}