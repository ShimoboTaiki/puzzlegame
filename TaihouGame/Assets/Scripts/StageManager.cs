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
        public List<List<Vector3>> baniHoleInform = new List<List<Vector3>>();
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
                blockInform[i - 1].Add(new Vector4(-4, 3, 1, 1));
                blockInform[i - 1].Add(new Vector4(3, -2, 1, 1));
                blockInform[i - 1].Add(new Vector4(0, 1, 1, 1));
                baneInform[i - 1].Add(new Vector3(0, -1, 1));
                stages.Add(new Stage(ballCount, enemyList[i - 1], blockInform[i - 1], FBlockInform[i - 1], baneInform[i - 1],baniHoleInform[i-1]));

                //Stage2
                i = 2;
                CreateStage();
                ballCount = 15;
                enemyList[i - 1].Add(new Vector2(-5, 3));
                enemyList[i - 1].Add(new Vector2(-2, -1));
                enemyList[i - 1].Add(new Vector2(1, 3));
                enemyList[i - 1].Add(new Vector2(2, 3));
                blockInform[i - 1].Add(new Vector4(0, 2, 1, 1));
                blockInform[i - 1].Add(new Vector4(1, 2, 1, 1));
                blockInform[i - 1].Add(new Vector4(2, 2, 1, 1));
                blockInform[i - 1].Add(new Vector4(0, 3, 1, 1));
                FBlockInform[i - 1].Add(new Vector4(-6, 2, 6, 1));
                FBlockInform[i - 1].Add(new Vector4(-3, 3, 1, 3));
                baneInform[i - 1].Add(new Vector3(0, -2, 3));
                stages.Add(new Stage(ballCount, enemyList[i - 1], blockInform[i - 1], FBlockInform[i - 1], baneInform[i - 1], baniHoleInform[i - 1]));

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
                stages.Add(new Stage(ballCount, enemyList[i - 1], blockInform[i - 1], FBlockInform[i - 1], baneInform[i - 1], baniHoleInform[i - 1]));

                //Stage4
                i = 4;
                CreateStage();
                ballCount = 15;
                for (int j = 0; j < 8; j++)
                {
                    enemyList[i - 1].Add(new Vector2(-6 + j, -2 + j));
                }
                enemyList[i - 1].Add(new Vector2(7, -2));
                blockInform[i - 1].Add(new Vector4(6, -1, 1, 1));
                blockInform[i - 1].Add(new Vector4(6, -2, 1, 1));
                blockInform[i - 1].Add(new Vector4(6, -3, 1, 1));
                blockInform[i - 1].Add(new Vector4(7, -3, 1, 1));
                blockInform[i - 1].Add(new Vector4(8, -3, 1, 1));
                blockInform[i - 1].Add(new Vector4(8, -2, 1, 1));
                blockInform[i - 1].Add(new Vector4(8, -1, 1, 1));
                blockInform[i - 1].Add(new Vector4(7, -1, 1, 1));
                baneInform[i - 1].Add(new Vector3(3, 0, 2));
                stages.Add(new Stage(ballCount, enemyList[i - 1], blockInform[i - 1], FBlockInform[i - 1], baneInform[i - 1], baniHoleInform[i - 1]));

                //Stage5
                i = 5;
                CreateStage();
                ballCount = 10;
                enemyList[i - 1].Add(new Vector2(0, -1));
                blockInform[i - 1].Add(new Vector4(1, -1, 0, 0));
                blockInform[i - 1].Add(new Vector4(3, -1, 1, 1));
                blockInform[i - 1].Add(new Vector4(2, -1, 1, 1));
                FBlockInform[i - 1].Add(new Vector4(2, 2, 7, 1));
                FBlockInform[i - 1].Add(new Vector4(3, 4.1f, 9, 1));
                FBlockInform[i - 1].Add(new Vector4(5, 1, 1, 1));
                FBlockInform[i - 1].Add(new Vector4(7, 1, 1, 5.2f));
                FBlockInform[i - 1].Add(new Vector4(-1, -1, 1, 5));
                baneInform[i - 1].Add(new Vector3(7, -3, 2));
                stages.Add(new Stage(ballCount, enemyList[i - 1], blockInform[i - 1], FBlockInform[i - 1], baneInform[i - 1], baniHoleInform[i - 1]));

                //Stage6
                i = 6;
                CreateStage();
                ballCount = 15;
                enemyList[i - 1].Add(new Vector2(7, 4));
                enemyList[i - 1].Add(new Vector2(1, 2));
                enemyList[i - 1].Add(new Vector2(2, 0));
                FBlockInform[i - 1].Add(new Vector4(0, 5, 1, 11));
                baneInform[i - 1].Add(new Vector3(6, -3, 2));
                stages.Add(new Stage(ballCount, enemyList[i - 1], blockInform[i - 1], FBlockInform[i - 1], baneInform[i - 1], baniHoleInform[i - 1]));

                //Stage7
                i = 7;
                CreateStage();
                ballCount = 10;
                enemyList[i - 1].Add(new Vector2(-4, 3));
                enemyList[i - 1].Add(new Vector2(1, -4));
                enemyList[i - 1].Add(new Vector2(1, 2));
                blockInform[i - 1].Add(new Vector4(0, 2,1,1));
                blockInform[i - 1].Add(new Vector4(0, -2, 1, 1));
                blockInform[i - 1].Add(new Vector4(0, -1, 1, 1));
                FBlockInform[i - 1].Add(new Vector4(1, 1, 3, 1));
                blockInform[i - 1].Add(new Vector4(2, 2, 1, 1));
                baneInform[i - 1].Add(new Vector3(5, -4, 3));
                baniHoleInform[i - 1].Add(new Vector3(-1, -3, 1));
                stages.Add(new Stage(ballCount, enemyList[i - 1], blockInform[i - 1], FBlockInform[i - 1], baneInform[i - 1], baniHoleInform[i - 1]));

                //Stage8
                i = 8;
                CreateStage();
                ballCount = 9;
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < 2 * j + 1; k++)
                    {
                        enemyList[i - 1].Add(new Vector2(2 * j, k));
                        enemyList[i - 1].Add(new Vector2(k, 2 * j));
                        enemyList[i - 1].Add(new Vector2(2 * j, -k));
                        enemyList[i - 1].Add(new Vector2(k, -2 * j));
                        enemyList[i - 1].Add(new Vector2(-2 * j, k));
                        enemyList[i - 1].Add(new Vector2(-k, 2 * j));
                        enemyList[i - 1].Add(new Vector2(-2 * j, -k));
                        enemyList[i - 1].Add(new Vector2(-k, -2 * j));

                    }
                }
                for (int j = 0; j < 2; j++)
                {
                    blockInform[i - 1].Add(new Vector4(2 * j + 1, 2 * j + 1, 1, 1));
                    blockInform[i - 1].Add(new Vector4(-2 * j - 1, 2 * j + 1, 1, 1));
                    blockInform[i - 1].Add(new Vector4(2 * j + 1, -2 * j - 1, 1, 1));
                    blockInform[i - 1].Add(new Vector4(-2 * j - 1, -2 * j - 1, 1, 1));
                    for (int k = 0; k < 2 * j + 1; k++)
                    {
                        blockInform[i - 1].Add(new Vector4(2 * j + 1, k, 1, 1));
                        blockInform[i - 1].Add(new Vector4(k, 2 * j + 1, 1, 1));
                        blockInform[i - 1].Add(new Vector4(2 * j + 1, -k, 1, 1));
                        blockInform[i - 1].Add(new Vector4(k, -2 * j - 1, 1, 1));
                        blockInform[i - 1].Add(new Vector4(-2 * j - 1, k, 1, 1));
                        blockInform[i - 1].Add(new Vector4(-k, 2 * j + 1, 1, 1));
                        blockInform[i - 1].Add(new Vector4(-2 * j - 1, -k, 1, 1));
                        blockInform[i - 1].Add(new Vector4(-k, -2 * j - 1, 1, 1));

                    }
                }
                stages.Add(new Stage(ballCount, enemyList[i - 1], blockInform[i - 1], FBlockInform[i - 1], baneInform[i - 1], baniHoleInform[i - 1]));

                //Stage9
                i = 9;
                CreateStage();
                ballCount = 10;
                enemyList[i - 1].Add(new Vector2(-1, 4));
                enemyList[i - 1].Add(new Vector2(7, -2));
                blockInform[i - 1].Add(new Vector4(-1, 1, 1, 1));
                FBlockInform[i - 1].Add(new Vector4(-2, 2.5f, 1, 4));
                FBlockInform[i - 1].Add(new Vector4(0, 2.5f, 1, 4));
                FBlockInform[i - 1].Add(new Vector4(-1, 5, 3, 1));
                baneInform[i - 1].Add(new Vector3(1, -5, 4));
                baniHoleInform[i - 1].Add(new Vector3(3, -2.5f, 1.5f));
                stages.Add(new Stage(ballCount, enemyList[i - 1], blockInform[i - 1], FBlockInform[i - 1], baneInform[i - 1], baniHoleInform[i - 1]));

                //Stage10
                i = 10;
                CreateStage();
                ballCount = 3;
                enemyList[i - 1].Add(new Vector2(4, -4));
                blockInform[i - 1].Add(new Vector4(2, -1, 1, 3));
                FBlockInform[i - 1].Add(new Vector4(1, 0.51f, 1, 2));
                FBlockInform[i - 1].Add(new Vector4(3.01f, 1.01f, 1, 3));
                FBlockInform[i - 1].Add(new Vector4(1, -3, 1, 3));
                FBlockInform[i - 1].Add(new Vector4(3.01f, -3.04f, 1, 2.92f));
                FBlockInform[i - 1].Add(new Vector4(-1, 0.01f, 3, 1));
                FBlockInform[i - 1].Add(new Vector4(-1, -2, 3, 1));
                FBlockInform[i - 1].Add(new Vector4(2, -4, 1, 1));
                stages.Add(new Stage(ballCount, enemyList[i - 1], blockInform[i - 1], FBlockInform[i - 1], baneInform[i - 1], baniHoleInform[i - 1]));

                isdifined = true;
            }
        }

        private void CreateStage()
        {
            enemyList.Add(new List<Vector2>());
            blockInform.Add(new List<Vector4>());
            FBlockInform.Add(new List<Vector4>());
            baneInform.Add(new List<Vector3>());
            baniHoleInform.Add(new List<Vector3>());
        }
    }
}