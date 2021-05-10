using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public Vector3 startPosition;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        startPosition = transform.position;
        Launch();
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
        Launch();
    }

    private void Launch()
    {
        //if(StartScript.instance.gameStarted == true)
        //{
            float x = UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1;
            float y = UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1;
            rb.velocity = new Vector2(speed * x, speed * y);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1Goal"))
        {
            Debug.Log("Player 2 Scored...");
            GameManager.instance.Player2Scored();
        }
        else if (collision.gameObject.CompareTag("Player2Goal"))
        {
            Debug.Log("Player 1 Scored...");
            GameManager.instance.Player1Scored();
        }
    }
}
