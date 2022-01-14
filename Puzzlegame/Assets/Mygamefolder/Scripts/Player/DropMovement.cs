using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
using UnityEngine.UI;
namespace Player
{
    public class DropMovement : MonoBehaviour
    {
        public Text text;
        // Update is called once per frame
        void Update()
        {
            Vector2 mousePos = Input.mousePosition;
            text.text = ParameterManager.Instance.GetDropPosition(mousePos) + System.Environment.NewLine + Input.mousePosition;
        }
    }
}