using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Puzzle;

public class DestroyDrop : MonoBehaviour
{
    [SerializeField] GameObject player;
    
    Board board = new Board();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnClicked()
    {
        Destroy(player);
        
    }

    
}
