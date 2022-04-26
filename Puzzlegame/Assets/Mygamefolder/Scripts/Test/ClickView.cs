using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


namespace Test
{
    public class ClickView : SingletonMonoBehaviour<ClickView>
    {
        [SerializeField] Image image;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        

        public void Clear()
        {
            image.color = Color.white;
        }

        public void MouseButtonUp()
        {
            image.color = Color.red;
        }

        public void MouseButtonDown()
        {
            image.color = Color.blue;
        }
    }
}