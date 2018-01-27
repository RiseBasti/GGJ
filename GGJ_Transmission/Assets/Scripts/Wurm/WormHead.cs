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

    //Buffs, Debuffs
    [HideInInspector] public int enemy1 = 0;
    [HideInInspector] public int enemy2 = 0;
    [HideInInspector] public int enemy3 = 0;
    [HideInInspector] public int enemy4 = 0;
    [HideInInspector] public int enemy5 = 0;


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
    private WormHead wormHead;

	// Use this for initialization
	private void Start ()
    {
        newParent = gameObject;
        rb = GetComponent<Rigidbody2D>();
        wormHead = GetComponent<WormHead>();

        for(int i=0; i<childNum; i++)
        {
            //AllChilds
            GameObject newChild = Instantiate(child, new Vector3((i+1) * distMin *(-1), 0, 0) + transform.position, Quaternion.identity);
            newChild.GetComponent<WormChild>().parent = newParent;
            newChild.GetComponent<WormCollision>().wormHead = GetComponent<WormHead>();
            newChild.GetComponent<WormChild>().speed = speed;

            if (i<childNum-1)
            {
                //MiddleChilds
                newChild.GetComponent<WormChild>().mySprite = childSprite;
                newChild.GetComponent<WormChild>().distMin = distMin;
                newChild.GetComponent<WormChild>().distMax = distMax;
            }
            else
            {
                //LastChild
                newChild.GetComponent<WormChild>().mySprite = endSprite;
                newChild.GetComponent<WormChild>().distMin = distMin+0.1f;
                newChild.GetComponent<WormChild>().distMax = distMax+0.1f;
            }

            newParent = newChild;
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
