using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
		public int deleteIndex;

		public Drop(Vector2Int pos, Type type, GameObject canvasObject)
		{
			ValueSetting(pos, type, canvasObject);
		}

		private void ValueSetting(Vector2Int pos, Type type, GameObject canvasObject)
		{
			this.deleteIndex = -100;
			this.pos = pos;
			this.type = type;
			this.dropObject = PoolingManager.Instance.PopPoolingObject(type);
			if (this.dropObject)
			{
				this.dropObject.transform.SetParent(canvasObject.transform, true);
				image = dropObject.GetComponent<Image>();
				image.color = ColorManager.Instance.GetColor(this.type);
				dropObject.GetComponent<RectTransform>().sizeDelta = Vector3.one * ParameterManager.Instance.dropLenght;
				dropObject.transform.localPosition = ParameterManager.Instance.GetDropCanvasPosition(pos);
			}
		}
		/// <summary>
		/// 見た目とロジックを別々にする
		/// </summary>
		/// <param name="pos"></param>
		/// <param name="type"></param>
		/// <param name="canvasObject"></param>
		/// <param name="viewPos"></param>
		public Drop(Vector2Int pos, Type type, GameObject canvasObject,Vector2 viewPos)
		{
			ValueSetting(pos, type, canvasObject);
			dropObject.transform.localPosition = viewPos;

		}
/// <summary>
/// 指定したロジック座標へ動く
/// </summary>
/// <param name="indexPos">指定した座標</param>
		public void IndexMove(Vector2Int indexPos)
		{
			Move(ParameterManager.Instance.GetDropCanvasPosition(indexPos));
		}

		public void SetIndexViewPosition(Vector2Int pos)
		{
			dropObject.transform.localPosition = ParameterManager.Instance.GetDropCanvasPosition(pos);
		}

		/// <summary>
		/// 指定したキャンバス座標へ動く
		/// </summary>
		/// <param name="pos">指定したキャンバス座標</param>
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
			this.dropObject.SetActive(false);
			PoolingManager.Instance.GetPoolingObjectPutBack(this.type, this.dropObject);
		}

		public void ViewPos()
		{
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		static void EntryPoolingObject()
		{
			Enum.GetValues(typeof(Puzzle.Type)).Cast<Puzzle.Type>().ToList().ForEach(type =>
			{
				GameObject prefab = ParameterManager.Instance.dropPrefab;
				PoolingManager.Instance.AddPoolingObject(type, prefab, 30);
			});
		}
	}
}