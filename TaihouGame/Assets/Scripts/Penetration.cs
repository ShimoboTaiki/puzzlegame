using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using IM;

public class Penetration : MonoBehaviour
{
    [SerializeField] private Text text;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        text.text = "残り" + ItemManager.penetrationCount.ToString() + "個" + "\n" + ItemManager.isUsedPenetrationCounter.ToString() + "ターン有効";
    }
    public void OnClicked()
    {
        if (ItemManager.penetrationCount > 0)
        {
            ItemManager.isUsedPenetrationCounter++;
            ItemManager.penetrationCount--;
        }
    }
}
