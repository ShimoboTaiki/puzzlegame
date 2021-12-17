using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Manager;

namespace Puzzle
{
    public class Drop
    {
        public Vector2 pos;
        public Type type;
        public GameObject dropObject;
        private Image image;
        public Drop(Vector2Int pos, Type type,GameObject prefab,GameObject canvasObject)
        {
            this.pos=pos;
            this.type=type;
            this.dropObject = UnityEngine.Object.Instantiate(prefab, canvasObject.transform);
            image = dropObject.GetComponent<Image>();
            image.color = ColorManager.Instance.GetColor(this.type);
            dropObject.GetComponent<RectTransform>(). sizeDelta= Vector3.one * ParameterManager.Instance.dropLenght;
            dropObject.transform.localPosition = (this.pos + ParameterManager.Instance.adjestPos) * ParameterManager.Instance.dropLenght;
        }
    }
}
