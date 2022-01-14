using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CannonName
{
    public class Cannon : MonoBehaviour
    {
        [SerializeField] private GameObject target;
        private Transform targettra;
        [SerializeField] private Vector2 pos;
        private Vector3 cR;
        public static float speed;
        // Start is called before the first frame update
        void Start()
        {
            targettra = target.GetComponent<Transform>();
            cR = Vector3.zero;
        }

        // Update is called once per frame
        void Update()
        {
            cR.z = Mathf.Atan((targettra.position.y - pos.y) / (targettra.position.x - pos.x)) * 180 / Mathf.PI;
            gameObject.transform.rotation = Quaternion.Euler(cR);
            speed = Mathf.Sqrt((targettra.position.y - pos.y) * (targettra.position.y - pos.y) + (targettra.position.x - pos.x) * (targettra.position.x - pos.x));
        }
    }
}