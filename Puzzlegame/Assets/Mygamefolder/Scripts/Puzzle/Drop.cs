using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzle
{
    public class Drop
    {
        public Vector2 pos;
        public Type type;
        public Drop(Vector2Int pos, Type type)
        {
            this.pos=pos;
            this.type=type;
        }
    }
}
