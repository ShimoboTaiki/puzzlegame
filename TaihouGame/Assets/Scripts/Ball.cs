using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Count;


public class Ball : MonoBehaviour
{
    Rigidbody2D rig;
    private bool isBani=false;
    private int isBaniCount=0;
    private Vector3 baniPos;
    private Vector3 ballPos;
    private bool isBanifinished=false;
    private bool isTriggerBaniHole=false;

    // Start is called before the first frame update
    void Start()
    {
        rig = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -5)
        {
            BallCountManager.destroyballCount--;
            Destroy(gameObject);
        }
        if (rig.gravityScale == 0)
        {
            if (gameObject.transform.position.x > 10 || gameObject.transform.position.y > 8)
            {
                BallCountManager.destroyballCount--;
                Destroy(gameObject);
            }
        }
        if (isBani)
        {
            if (!isBanifinished)
            {
                rig.velocity = Vector2.zero;
                rig.gravityScale = 0;
                ballPos = gameObject.transform.position;
                isBanifinished = true;
            }
            if (isBaniCount < 30)
            {
                gameObject.transform.position += (baniPos - ballPos)/30;
                isBaniCount++;
            }
            else
            {
                BallCountManager.destroyballCount--;
                Destroy(gameObject);
            }
        }
        
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bane"))
        {
            Vector2 vec;
            vec = gameObject.transform.position - collision.transform.position;
            rig.AddForce(vec*6,ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("baniHole")&&!isTriggerBaniHole)
        {
            baniPos = collision.transform.position;
            isTriggerBaniHole = true;
            isBani = true;
            
        }
    }
}