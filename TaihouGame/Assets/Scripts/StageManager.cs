using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SM
{
    public class StageManager : MonoBehaviour
    {
        public static List<Stage> stages = new List<Stage>();
        private int ballCount;
        private List<List<Vector2>> enemyList = new List<List<Vector2>>();
        private List<List<Vector4>> blockInform = new List<List<Vector4>>();
        private List<List<Vector4>> FBlockInform = new List<List<Vector4>>();
        private List<List<Vector3>> baneInform = new List<List<Vector3>>();
        private int i;
        public static int stageNum=1;
        public static bool isdifined = false;
        // Start is called before the first frame update
        void Start()
        {
            if (!isdifined)
            {
                //Stage1
                i = 1;
                CreateStage();
                ballCount = 20;
                enemyList[i - 1].Add(new Vector2(5, -1));
                blockInform[i - 1].Add(new Vector4(-4, 3,1,1));
                blockInform[i - 1].Add(new Vector4(3, -2,1,1));
                blockInform[i - 1].Add(new Vector4(0, 1,1,1));
                baneInform[i - 1].Add(new Vector3(0, -1, 1));
                stages.Add(new Stage(ballCount, enemyList[i - 1], blockInform[i - 1],FBlockInform[i-1], baneInform[i - 1]));

                //Stage2
                i = 2;
                CreateStage();
                ballCount = 15;
                enemyList[i - 1].Add(new Vector2(-5, 3));
                enemyList[i - 1].Add(new Vector2(-2, -1));
                enemyList[i - 1].Add(new Vector2(1, 3));
                enemyList[i - 1].Add(new Vector2(2, 3));
                blockInform[i - 1].Add(new Vector4(0, 2,1,1));
                blockInform[i - 1].Add(new Vector4(1, 2,1,1));
                blockInform[i - 1].Add(new Vector4(2, 2,1,1));
                blockInform[i - 1].Add(new Vector4(0, 3,1,1));
                FBlockInform[i - 1].Add(new Vector4(-6, 2, 6, 1));
                FBlockInform[i - 1].Add(new Vector4(-3, 3, 1, 3));
                baneInform[i - 1].Add(new Vector3(0, -2, 3));
                stages.Add(new Stage(ballCount, enemyList[i - 1], blockInform[i - 1],FBlockInform[i-1], baneInform[i - 1]));

                //Stage3
                i = 3;
                CreateStage();
                ballCount = 10;
                enemyList[i - 1].Add(new Vector2(4, 4));
                enemyList[i - 1].Add(new Vector2(-1.5f, 2));
                blockInform[i - 1].Add(new Vector4(3, 2, 1, 1));
                blockInform[i - 1].Add(new Vector4(4, 2, 1, 1));
                blockInform[i - 1].Add(new Vector4(5, 2, 1, 1));
                FBlockInform[i - 1].Add(new Vector4(2, 5, 1, 7));
                baneInform[i - 1].Add(new Vector3(5, -1, 2));
                stages.Add(new Stage(ballCount, enemyList[i - 1], blockInform[i - 1], FBlockInform[i - 1], baneInform[i - 1]));

                isdifined = true;
            }
        }

        private void CreateStage()
        {
            enemyList.Add(new List<Vector2>());
            blockInform.Add(new List<Vector4>());
            FBlockInform.Add(new List<Vector4>());
            baneInform.Add(new List<Vector3>());
        }
    }
}