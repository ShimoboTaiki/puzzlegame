using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class PoolingManager : SingletonMonoBehaviour<PoolingManager>
    {
        private Dictionary<System.Object, Stack<GameObject>> _poolingStackMap =
            new Dictionary<object, Stack<GameObject>>();

        /// <summary>
        /// ObjectPoolの登録
        /// </summary>
        /// <param name="key">intでもstringでも何でも。呼び出しのときに使います。</param>
        /// <param name="obj">Pooingの対象のGameObject</param>
        /// <param name="poolingCount">poolの数</param>
        public void AddPoolingObject(System.Object key, GameObject obj,int poolingCount=10)
        {
            if (_poolingStackMap.ContainsKey(key))
            {
                Debug.LogWarning("同一キーに複数のプーリング対象が設定されています");
            }
            _poolingStackMap[key] = new Stack<GameObject>();
            for (int i = 0; i < poolingCount; i++)
            {
                PoolingInsnited(key,obj);
            }
        }
		
        /// <summary>
        /// PoolingStackへの追加
        /// </summary>
        protected void PoolingInsnited(System.Object key,GameObject obj)
        {
            PoolingPush(key, Instantiate(obj));
        }
        /// <summary>
        /// 親を指定してエフェクトを呼び出す
        /// </summary>
        /// <param name="key">登録のときに設定したキー</param>
        /// <returns>poolのオブジェクト</returns>
        public GameObject PopPoolingObject(System.Object key)
        {
            if (_poolingStackMap[key].Count  <2)
            {
                PoolingInsnited(key,_poolingStackMap[key].Peek());
            }

            GameObject obj = _poolingStackMap[key].Pop();
            obj.SetActive(true);
            return obj;
        }
        

        public void GetPoolingObjectPutBack(System.Object key,GameObject obj)
        {
            //await UniTask.Delay(System.TimeSpan.FromSeconds(putBackTime));
            PoolingPush(key,obj);
        }

        private void PoolingPush(System.Object key, GameObject obj)
        {
            obj.SetActive(false);
            obj.transform.parent = this.transform;
            _poolingStackMap[key].Push(obj);
        }
    }
}