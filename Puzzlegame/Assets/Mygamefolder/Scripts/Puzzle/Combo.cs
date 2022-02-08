using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzle
{
    public class Combo : MonoBehaviour
    {
        public Type type;
        public List<Drop> comboDrop;
        public Combo()
        {
            comboDrop = new List<Drop>();
        }
    }
}