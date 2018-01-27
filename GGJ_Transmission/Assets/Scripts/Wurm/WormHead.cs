using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormHead : MonoBehaviour
{
    //Variables
    //Stats
    private int hp = 5;
    private float speed = 5;
    private int childNum = 4;
    private float distMin = 0.45f;
    private float distMax = 0.65f;


    //Script
    Vector2 direction = new Vector2(0, 0);
    float rotation = 0;

    //Objects
    public GameObject child;
    public Sprite childSprite;
    public Sprite endSprite;
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
            //AllChilds
            GameObject nextChild = Instantiate(child, new Vector3((i+1) * distMin *(-1), 0, 0) + transform.position, Quaternion.identity);
            nextChild.GetComponent<WormChild>().parent = newParent;
            nextChild.GetComponent<WormChild>().speed = speed;

            if(i<childNum-1)
            {
                //MiddleChilds
                nextChild.GetComponent<WormChild>().mySprite = childSprite;
                nextChild.GetComponent<WormChild>().distMin = distMin;
                nextChild.GetComponent<WormChild>().distMax = distMax;
            }
            else
            {
                //LastChild
                nextChild.GetComponent<WormChild>().mySprite = endSprite;
                nextChild.GetComponent<WormChild>().distMin = distMin+0.1f;
                nextChild.GetComponent<WormChild>().distMax = distMax+0.1f;
            }

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
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f || Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f)
        {
            rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        }

        transform.rotation = Quaternion.Euler(0f, 0f, rotation);
        rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
        
    }
}
