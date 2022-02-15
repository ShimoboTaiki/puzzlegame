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
                board.PuzzleProcess();
            }
        }
    }
}