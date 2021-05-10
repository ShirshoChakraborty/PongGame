using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleR : MonoBehaviour
{
    public float speed;
    public Vector3 startPosition;
    Rigidbody2D rb;
    public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("choice") == 1)
        {
            if (ball.gameObject.transform.position.x > 0)
                rb.transform.position = new Vector3(rb.gameObject.transform.position.x, ball.gameObject.transform.position.y);
            rb.velocity = Vector2.zero;
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (touchPos.x > 0)
                {
                    if (touchPos.y > 0)
                        rb.velocity = Vector2.up * speed;
                    else
                        rb.velocity = Vector2.down * speed;
                }
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }
        
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
    }
}
