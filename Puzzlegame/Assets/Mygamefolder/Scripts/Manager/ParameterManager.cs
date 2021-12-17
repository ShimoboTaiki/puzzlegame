using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class ParameterManager : SingletonMonoBehaviour<ParameterManager>
    {
        public Vector2Int boardSize=new Vector2Int(6,5);
        public Vector2 adjestPos = new Vector2(-2.5f, 2);
        public float dropLenght = 100;
    }
}