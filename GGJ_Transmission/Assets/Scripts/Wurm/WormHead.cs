using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormHead : MonoBehaviour
{
    //Variables
    //Stats
    private float speed = 10;
    private int childNum = 10;
    private float distMin = 0.75f;
    private float distMax = 0.9f;


    //Script
    Vector2 direction = new Vector2(0, 0);
    float rotation = 0;

    //Objects
    public GameObject child;
    private GameObject newParent;

    //Components
    private Rigidbody2D rb;

	// Use this for initialization
	private void Start ()
    {
        newParent = gameObject;
        rb = GetComponent<Rigidbody2D>();



        for(int i=0; i<childNum; i++)
        {
            GameObject nextChild = Instantiate(child, new Vector3((i+1) * distMin *(-1), 0, 0) + transform.position, Quaternion.identity);
            nextChild.GetComponent<WormChild>().parent = newParent;
            nextChild.GetComponent<WormChild>().speed = speed;
            nextChild.GetComponent<WormChild>().distMin = distMin;
            nextChild.GetComponent<WormChild>().distMax = distMax;

            newParent = nextChild;
        }
	}
	
	// Update is called once per frame
	private void Update ()
    {
        Move();
    }


    private void Move()
    {
        direction = (new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"))).normalized;
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        }

        transform.rotation = Quaternion.Euler(0f, 0f, rotation);
        rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
        
    }
}
