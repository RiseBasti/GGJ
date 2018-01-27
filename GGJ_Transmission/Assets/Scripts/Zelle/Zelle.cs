using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zelle : MonoBehaviour
{
    //Variables
    //Stats
    private int hp = 1;
    private float speed = 3;


    //Script
    Vector2 direction = new Vector2(0, 0);
    float rotation = 0;

    //Objects


    //Components
    private Rigidbody2D rb;



    // Use this for initialization
    private void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	private void Update ()
    {
        Move();
	}

    private void Move()
    {
        direction = (new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"))).normalized;

        if(Mathf.Abs(Input.GetAxis("Mouse X"))<0.01f && Mathf.Abs(Input.GetAxis("Mouse Y"))<0.01f)
        {
            direction = new Vector2(0,0);
        }
        else
        {
            rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        }

        transform.rotation = Quaternion.Euler(0f, 0f, rotation);
        rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
    }
}
