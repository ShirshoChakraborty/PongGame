using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleL : MonoBehaviour
{
    public float speed;
    public Vector3 startPosition;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (touchPos.x < 0)
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

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
    }
}
