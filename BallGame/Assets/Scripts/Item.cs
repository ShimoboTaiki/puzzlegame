using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemM;

public class Item : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ball")
        {
            Destroy(gameObject);
            ItemManager.itemCount--;
        }
    }
}
