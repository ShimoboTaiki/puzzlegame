using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CannonName;
using Count;
using IM;

public class Hassya : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject cannon;
    private GameObject ballClone;
    [SerializeField] private float speed;
    private Vector3 ballThrowRot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void Onclicked()
    {
        if (BallCountManager.ballCount > 0)
        {
            float ballPosX = cannon.transform.position.x;
            float ballPosY = cannon.transform.position.y;
            ballClone = Instantiate(ball, new Vector3(ballPosX, ballPosY, 0), Quaternion.identity);
            Rigidbody2D rig = ballClone.GetComponent<Rigidbody2D>();
            CircleCollider2D col = ballClone.GetComponent<CircleCollider2D>();
            if (ItemManager.isUsedBigBaniCounter>0)
            {
                ballClone.transform.localScale = ball.transform.localScale * 2;
                ItemManager.isUsedBigBaniCounter--;
            }
            if (ItemManager.isUsedZeroGravityCounter > 0)
            {
                rig.gravityScale = 0;
                ItemManager.isUsedZeroGravityCounter--;
            }
            else
            {
                rig.gravityScale = 1;
            }
            if (ItemManager.isUsedPenetrationCounter > 0)
            {
                col.isTrigger = true;
                ItemManager.isUsedPenetrationCounter--;
            }
            else
            {
                col.isTrigger = false;
            }
            ballThrowRot = cannon.transform.rotation.eulerAngles;
            speed = Mathf.Sqrt(Cannon.speed * 15);
            float forceX = speed * Mathf.Cos(ballThrowRot.z * Mathf.PI / 180);
            float forceY = speed * Mathf.Sin(ballThrowRot.z * Mathf.PI / 180);
            rig.velocity=new Vector2(forceX,forceY);
            BallCountManager.ballCount--;
        }
    }
}
