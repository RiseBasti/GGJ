using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormHead : MonoBehaviour
{
    //Variables
    //Stats
    private float hp = 10;
    private float speed = 5;
    private int childNum = 4;
    private float distMin = 0.45f;
    private float distMax = 0.65f;

    private float contamination = 0;


    //Script
    Vector2 direction = new Vector2(0, 0);
    float rotation = 0;

    [HideInInspector] public Color dmgColor;
    [HideInInspector] public float pulsAlpha = 255;

    private bool dead = false;

    //Objects
    public GameObject child;
    public Sprite midSprite;
    public Sprite endSprite;
    private GameObject newParent;

    //Components
    private Rigidbody2D rb;
    private SpriteRenderer mySprite;
    private WormHead wormHead;

	// Use this for initialization
	private void Start ()
    {
        newParent = gameObject;
        rb = GetComponent<Rigidbody2D>();
        mySprite = GetComponent<SpriteRenderer>();
        wormHead = GetComponent<WormHead>();

        for(int i=0; i<childNum; i++)
        {
            //AllChilds
            GameObject newChild = Instantiate(child, new Vector3((i+1) * distMin *(-1), 0, 0) + transform.position, Quaternion.identity);
            newChild.GetComponent<WormChild>().parent = newParent;
            newChild.GetComponent<WormChild>().wormHead = wormHead;
            newChild.GetComponent<WormChild>().speed = speed;
            newChild.GetComponent<SpriteRenderer>().sortingOrder = -i;

            if (i<childNum-1)
            {
                //MiddleChilds
                newChild.GetComponent<WormChild>().mySprite = midSprite;
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
        DmgColor();
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

    private void DmgColor()
    {
        dmgColor = new Color(Mathf.Clamp(contamination / (hp / 2), 0, 1), Mathf.Clamp((hp - contamination) / (hp / 2), 0, 1), 0, 255); //Mathf.PingPong(Time.time, 1)
        mySprite.color = dmgColor;
    }

    public void GotDmg(int cont)
    {
        contamination += cont;
        if(contamination>=hp)
        {
            dead = true;
        }
    }
    public void GotHealed(int cont)
    {
        contamination -= cont;
    }
}
