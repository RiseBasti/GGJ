using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormChild : MonoBehaviour
{
    //Variables
    //Stats
    //...

    //Script
    [HideInInspector] public float speed;
    [HideInInspector] public float distMin;
    [HideInInspector] public float distMax;

    private Vector2 direction = new Vector2(0,0);
    private float rotation = 0;

    [HideInInspector] public Sprite mySprite;

    //Objects
    [HideInInspector] public GameObject parent;

    //Components
    private Rigidbody2D rb;
    private SpriteRenderer sr;


	// Use this for initialization
	private void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        sr.sprite = mySprite;
	}
	
	// Update is called once per frame
	private void Update ()
    {
        Move();
	}

    private void Move()
    {
        direction = (new Vector2(parent.transform.position.x - transform.position.x, parent.transform.position.y - transform.position.y)).normalized;
        rotation = Mathf.Atan2(parent.transform.position.y - transform.position.y, parent.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
        float distance = Vector2.Distance(parent.transform.position, transform.position);

        transform.rotation = Quaternion.Euler(0f, 0f, rotation);

        if(distance>distMax)
        {
            rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
        }
        else if (distance>distMin)
        {
            rb.MovePosition(rb.position + direction * ((distance-distMin)/(distMax-distMin)) * speed * Time.deltaTime);
        }
    }
}
