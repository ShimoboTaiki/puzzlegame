using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Manager;
using DG.Tweening;
namespace Puzzle
{
    public class Drop
    {
        public Vector2Int pos;
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
            dropObject.transform.localPosition = ParameterManager.Instance.GetDropCanvasPosition(pos);
        }
        public void Move(Vector2 pos)
        {
            dropObject.transform.DOLocalMove(pos, ParameterManager.Instance.moveTime).SetEase(Ease.Linear);
        }
        public void ChangeColor(Color color)
        {
            image.color = color;
            
        }

        public void Delete()
        {
            Object.Destroy(this.dropObject);
        }
        
    }
}
