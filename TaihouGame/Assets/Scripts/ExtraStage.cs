using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExStage
{
    public class ExtraStage : MonoBehaviour
    {
        public static bool canGoExtraStage;
        public static bool isExtraStage;
        [SerializeField] private GameObject extraButton;
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(Extra());
        }

        // Update is called once per frame
        void Update()
        {

        }
        IEnumerator Extra()
        {
            yield return new WaitForSeconds(0.01f);
            if (canGoExtraStage)
            {
                extraButton.SetActive(true);
            }
            else
            {
                extraButton.SetActive(false);
            }
        }
    }
}