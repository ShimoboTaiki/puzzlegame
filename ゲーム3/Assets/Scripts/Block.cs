using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    public Text fNum;
    public Text rNum;
    public Text lNum;
    public Text uNum;
    public Text bNum;

    private Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mat=GetComponent<Renderer>().material;
        mat.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
