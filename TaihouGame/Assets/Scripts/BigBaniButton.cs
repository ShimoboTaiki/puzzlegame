using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IM;
using UnityEngine.UI;

public class BigBaniButton : MonoBehaviour
{
    [SerializeField] private Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "残り" + ItemManager.bigBaniCount.ToString() + "個" + "\n" + ItemManager.isUsedBigBaniCounter.ToString() + "ターン有効";
    }
    public void OnClicked()
    {
        if (ItemManager.bigBaniCount > 0)
        {
            ItemManager.isUsedBigBaniCounter++;
            ItemManager.bigBaniCount--;
        }
    }
}
