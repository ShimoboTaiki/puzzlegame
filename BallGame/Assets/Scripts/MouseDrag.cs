using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Reset;

public class MouseDrag : MonoBehaviour
{
    private Vector3 offset;
    private Vector3 screenPoint;
    void OnMouseDown()
    {
        if (!Ball.isPlaying)
        {
            this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            this.offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        }
    }
    
    void OnMouseDrag()
    {
        if (!Ball.isPlaying)
        {
            Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + this.offset;
            transform.position = currentPosition;
        }
    }
}
