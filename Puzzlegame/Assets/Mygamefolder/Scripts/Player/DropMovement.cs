using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
using UnityEngine.UI;
using UniRx;
using Puzzle;
using Cysharp.Threading.Tasks;
using System;
namespace Player
{
    public class DropMovement : MonoBehaviour
    {
        public Text text;
        public Puzzle.Board board;
        private Vector2Int dropPastPos=Vector2Int.zero;
        private void Start()
        {
            PlayerOperation().Forget();
            
        }

        async UniTaskVoid PlayerOperation()
        {
            while (true)
            {
                IDisposable playerOperationDispose=
                ParameterManager.Instance
                    .ObserveEveryValueChanged(instance => instance.GetDropPosition(Input.mousePosition))
                    .Where(pos=>ParameterManager.Instance.InBoard(pos)&&(dropPastPos-pos).magnitude<1.1f)
                    .Subscribe(pos => {
                        Debug.Log("動いた");
                        board.ChangeDrop(pos,dropPastPos);
                        dropPastPos = pos;
                    })
                    .AddTo(this);
                using (playerOperationDispose)
                {
                    await UniTask.WaitWhile(() => Input.GetMouseButtonDown(0));
                    await UniTask.WaitWhile(() => Input.GetMouseButtonUp(0));
                    await board.PuzzleProcess();
                }
            }
        }
        // Update is called once per frame
        
    }
}