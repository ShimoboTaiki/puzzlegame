using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
using UnityEngine.UI;
using UniRx;
using Puzzle;
using Cysharp.Threading.Tasks;
using System;
using UniRx.Triggers;
using Test;

namespace Player
{
    public class DropMovement : MonoBehaviour
    {
        public Text text;
        public Puzzle.Board board;
        
        private void Start()
        {
            PlayerOperation().Forget();
            
        }

        async UniTaskVoid PlayerOperation()
        {
            while (true)
            {
                await UniTask.WaitUntil(() => Input.GetMouseButtonDown(0));
                ClickView.Instance.MouseButtonDown();
                Vector2Int currentPos=ParameterManager.Instance.GetIndexPosition(Input.mousePosition);
                if (!ParameterManager.Instance.InBoard(currentPos))
                {
                    continue;
                }

                ReactiveProperty<Vector2Int> playerPos = new ReactiveProperty<Vector2Int>(currentPos);
                var mouseObserver = this.UpdateAsObservable().Subscribe(_ =>
                    playerPos.Value = ParameterManager.Instance.GetIndexPosition(Input.mousePosition));
                playerPos.Subscribe(value =>
                {
                    board.ChangeDrop(value, currentPos);
                    currentPos = value;
                });
                await UniTask.WaitWhile(() => Input.GetMouseButton(0));
                mouseObserver.Dispose();
                playerPos.Dispose();
                ClickView.Instance.MouseButtonUp();
                bool comboLoop = true;
                while (comboLoop)
                {
                    comboLoop=await board.PuzzleProcess();
                    if (comboLoop)
                    {
                        await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
                    }
                }
                ClickView.Instance.Clear();
            }
            
            // while (true)
            // {
            //     Vector2Int dropPastPos=Vector2Int.zero;
            //     IDisposable playerOperationDispose=
            //     ParameterManager.Instance
            //         .ObserveEveryValueChanged(instance => instance.GetIndexPosition(Input.mousePosition))
            //         .Where(pos=>ParameterManager.Instance.InBoard(pos)&&(dropPastPos-pos).magnitude<1.1f)
            //         .Subscribe(pos => {
            //             Debug.Log("動いた");
            //             board.ChangeDrop(pos,dropPastPos);
            //             dropPastPos = pos;
            //         })
            //         .AddTo(this);
            //     using (playerOperationDispose)
            //     {
            //         await UniTask.WaitWhile(() => Input.GetMouseButtonDown(0));
            //         //await UniTask.WhenAll (UniTask.WaitWhile(() => Input.GetMouseButtonUp(0)),UniTask.Delay(TimeSpan.FromSeconds(1)));
            //         await UniTask.WaitWhile(() => Input.GetMouseButtonUp(0));
            //         await board.PuzzleProcess();
            //     }
            // }
        }
        
        
    }
}