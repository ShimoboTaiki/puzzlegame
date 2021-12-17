using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Puzzle;
namespace Manager{
    public class ColorManager : SingletonMonoBehaviour<ColorManager>
    {
        public Color redColor, blueColor, greenColor, yellowColor,errorColor;
        public int COLORMAXKIND = 4;
        public Color GetColor(Type type)
        {
            switch (type)
            {
                case Type.red:
                    return redColor;
                case Type.blue:
                    return blueColor;
                case Type.green:
                    return greenColor;
                case Type.yellow:
                    return yellowColor;
                default:
                    Debug.LogError("タイプの指定と色が合っていません");
                    return errorColor;
            }
        }
    }
}