using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using IM;

public class ZeroGravity : MonoBehaviour
{
    [SerializeField] private Text text;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        text.text = "残り" + ItemManager.zeroGravityCount.ToString() + "個" + "\n" + ItemManager.isUsedZeroGravityCounter.ToString() + "ターン有効";
    }
    public void OnClicked()
    {
        if (ItemManager.zeroGravityCount > 0)
        {
            ItemManager.isUsedZeroGravityCounter++;
            ItemManager.zeroGravityCount--;
        }
    }
}
