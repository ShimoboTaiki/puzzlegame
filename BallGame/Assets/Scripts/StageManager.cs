using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StageM
{
    public class StageManager : MonoBehaviour
    {
        public static List<Stage> stages = new List<Stage>();

        int baniX;
        List<List<Vector3>> itemPos = new List<List<Vector3>>();
        List<List<Vector2>> yukaInform = new List<List<Vector2>>();//vector2(yukaRot,yukaLengh)
        Vector3 goalPos;
        Vector3 buttonPos;
        List<List<Vector2>> baneInform = new List<List<Vector2>>();
        List<List<Vector4>> jamaInform = new List<List<Vector4>>();//vector2(position,scale)
        public static int stageNum;
        private int i=0;


        void Start()
        {
            stageNum = 1;

            //Stage1
            i ++;
            ResetList();
            baniX = 2;
            yukaInform[i-1].Add(new Vector2(20, 1.5f));
            goalPos = new Vector3(-2, -3, 0);
            buttonPos = new Vector3(-250, 400, 0);
            CreateStage(i);

            //Stage2
            i ++;
            ResetList();
            baniX = 0;
            itemPos[i - 1].Add(new Vector3(2, 0, 0));
            itemPos[i - 1].Add(new Vector3(-1, -2, 0));
            yukaInform[i - 1].Add(new Vector2(30, 1));
            yukaInform[i - 1].Add(new Vector2(-30, 1));
            goalPos = new Vector3(-2, -3.5f, 0);
            buttonPos = new Vector3(250, -550, 0);
            CreateStage(i);

            //Stage3
            i ++;
            ResetList();
            baniX = -2;
            itemPos[i - 1].Add(new Vector3(-0.5f, -4, 0));
            yukaInform[i - 1].Add(new Vector2(-60, 1));
            yukaInform[i - 1].Add(new Vector2(40, 0.3f));
            yukaInform[i - 1].Add(new Vector2(0, 0.3f));
            goalPos = new Vector3(2, -3, 0);
            buttonPos = new Vector3(250, 500, 0);
            CreateStage(i);

            //Stage4
            i ++;
            ResetList();
            baniX = 0;
            itemPos[i - 1].Add(new Vector3(0, -3, 0));
            goalPos = new Vector3(0, -1, 0);
            buttonPos = new Vector3(250, -200, 0);
            baneInform[i - 1].Add(new Vector2(0, 0.5f));
            CreateStage(i);

            //Stage5
            i ++;
            ResetList();
            baniX = -2;
            itemPos[i - 1].Add(new Vector3(0, -2.5f, 0));
            yukaInform[i - 1].Add(new Vector2(-20, 0.6f));
            yukaInform[i - 1].Add(new Vector2(20, 1));
            goalPos = new Vector3(-2.3f, -3.5f, 0);
            buttonPos = new Vector3(300, 600, 0);
            baneInform[i - 1].Add(new Vector2(0, 0.3f));
            jamaInform[i - 1].Add(new Vector4(-1, -3, 0.7f, 3));
            CreateStage(i);

            //Stage6
            i ++;
            ResetList();
            baniX = 2;
            itemPos[i - 1].Add(new Vector3(-2,2,0));
            itemPos[i - 1].Add(new Vector3(-0.5f, -2, 0));
            yukaInform[i - 1].Add(new Vector2(20, 1));
            yukaInform[i - 1].Add(new Vector2(-20, 1.5f));
            yukaInform[i - 1].Add(new Vector2(90, 0.5f));
            goalPos = new Vector3(2, -3);
            buttonPos = new Vector3(-300, -550, 0);
            baneInform[i - 1].Add(new Vector2(0, 0.5f));
            jamaInform[i - 1].Add(new Vector4(-0.5f, 3, 1, 4));
            CreateStage(i);

            //Stage7
            i ++;
            ResetList();
            baniX = -1;
            itemPos[i-1].Add(new Vector3(-2, 3, 0));
            itemPos[i-1].Add(new Vector3(2, 4, 0));
            yukaInform[i-1].Add(new Vector2(20, 0.5f));
            yukaInform[i-1].Add(new Vector2(-30, 1));
            yukaInform[i-1].Add(new Vector2(30, 1));
            goalPos = new Vector3(-1, 3, 0);
            buttonPos = new Vector3(250, -550, 0);
            baneInform[i-1].Add(new Vector2(0, 0.5f));
            jamaInform[i-1].Add(new Vector4(0, 4, 0.5f, 2));
            CreateStage(i);

            //Stage8
            i++;
            ResetList();
            baniX = 2;
            itemPos[i - 1].Add(new Vector3(1.5f, -3.5f, 0));
            yukaInform[i - 1].Add(new Vector2(7, 0.5f));
            goalPos = new Vector3(-2, 3, 0);
            buttonPos = new Vector3(-300, -500, 0);
            baneInform[i - 1].Add(new Vector2(0, 0.3f));
            baneInform[i - 1].Add(new Vector2(0, 0.3f));
            baneInform[i - 1].Add(new Vector2(0, 0.3f));
            CreateStage(i);

            //Stage9
            i++;
            ResetList();
            baniX = -2;
            itemPos[i - 1].Add(new Vector3(-1.5f, -3, 0));
            itemPos[i - 1].Add(new Vector3(2, -0.5f, 0));
            yukaInform[i - 1].Add(new Vector2(-70, 1));
            yukaInform[i - 1].Add(new Vector2(0, 0.7f));
            yukaInform[i - 1].Add(new Vector2(70, 1));
            goalPos = new Vector3(1.5f, -2, 0);
            buttonPos = new Vector3(0, 600, 0);
            baneInform[i - 1].Add(new Vector2(0,0.3f));
            CreateStage(i);

            //Stage10
            i++;
            ResetList();
            baniX = 0;
            itemPos[i - 1].Add(new Vector3(1, 0, 0));
            yukaInform[i - 1].Add(new Vector2(20, 1));
            yukaInform[i - 1].Add(new Vector2(-30, 1.5f));
            yukaInform[i - 1].Add(new Vector2(0, 0.7f));
            goalPos = new Vector3(2, -2, 0);
            buttonPos = new Vector3(-300, -600, 0);
            baneInform[i - 1].Add(new Vector2(0, 0.5f));
            jamaInform[i - 1].Add(new Vector4(0, 1, 6, 0.5f));
            CreateStage(i);
        }

        void ResetList()
        {
            itemPos.Add(new List<Vector3>());
            yukaInform.Add(new List<Vector2>());
            baneInform.Add(new List<Vector2>());
            jamaInform.Add(new List<Vector4>());
        }

        void CreateStage(int i)
        {
            stages.Add(new Stage(baniX, itemPos[i - 1], yukaInform[i - 1], goalPos, buttonPos, baneInform[i - 1], jamaInform[i - 1]));
        }
    }
}