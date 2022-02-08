using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
using UnityEngine.UI;
using UniRx;
using Puzzle;
namespace Player
{
    public class DropMovement : MonoBehaviour
    {
        public Text text;
        public Puzzle.Board board;
        private Vector2Int dropPastPos=Vector2Int.zero;
        private void Start()
        {
            ParameterManager.Instance
                .ObserveEveryValueChanged(instance => instance.GetDropPosition(Input.mousePosition))
                .Where(pos=>ParameterManager.Instance.InBoard(pos)&&(dropPastPos-pos).magnitude<1.1f)
                .Subscribe(pos => {
                    Debug.Log("動いた");
                    board.ChangeDrop(pos,dropPastPos);
                    dropPastPos = pos;
                })
                .AddTo(this);
        }
        // Update is called once per frame
        void Update()
        {
            Vector2 mousePos = Input.mousePosition;
            text.text = ParameterManager.Instance.GetDropPosition(mousePos) + System.Environment.NewLine + Input.mousePosition;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                List<Combo> combos = new List<Combo>();
                for(int i = 0; i< ParameterManager.Instance.boardSize.x;i++)
                {
                    for(int j=0; j < ParameterManager.Instance.boardSize.y; j++)
                    {
                        Combo combo = new Combo();
                        try
                        {
                            combo = board.SearchCombo(new Vector2Int(i, j));
                        }
                        catch(System.ArgumentOutOfRangeException e)
                        {
                            Debug.Log("エラー");
                        }
                        if (combo.comboDrop.Count!=0)
                        {
                            combos.Add(combo);
                        }
                        //combos.Add(board.SearchCombo(new Vector2Int(i, j)))
                    }
                }
                Debug.Log(combos.Count);
                foreach(Combo c in combos)
                {
                    foreach(Drop d in c.comboDrop)
                    {
                        //d.ChangeColor(Color.black);
                        d.dropObject.SetActive(false);
                    }
                }
            }
        }
    }
}