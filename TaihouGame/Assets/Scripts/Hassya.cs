using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CannonName;
using Count;

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
            ballThrowRot = cannon.transform.rotation.eulerAngles;
            rig.gravityScale = 1;
            speed = Cannon.speed * 1.3f;
            float forceX = speed * Mathf.Cos(ballThrowRot.z * Mathf.PI / 180);
            float forceY = speed * Mathf.Sin(ballThrowRot.z * Mathf.PI / 180);
            rig.AddForce(new Vector2(forceX, forceY), ForceMode2D.Impulse);
            BallCountManager.ballCount--;
        }
    }
}
