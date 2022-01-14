using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Count;

public class Ball : MonoBehaviour
{
    Rigidbody2D rig;
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
}