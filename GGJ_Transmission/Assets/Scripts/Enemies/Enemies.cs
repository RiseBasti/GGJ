using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour {

    //Player Wurm
    public GameObject PW;
    private WormHead WH;
    BoxCollider2D BC;
    AnimationClip anim;
    private Animation Ator;
    Animator anima;

    //direcrion
    Vector2 direction;

    //Eigenschaften
    public string EnemyTyp;
    private float EnemiesSize;
   
    private float MaxSize;
    private int EnemyHP;

    private float EnemySpeed;
    private Rigidbody2D rb;
   
    public GameObject EnemyTarget;
    
    //Sprite
    private SpriteRenderer SR;
    Color color = new Color(1,1,1);

    //Speed
    private float MaxVelocity;

    //boolean
    public bool isEat = false;
    public bool boost = true;
    public bool Spawning = true;
    
    // Use this for initialization

    

    /*  public Enemies(string inTyp, Vector2  inPos) {

          transform.localPosition = inPos;



      }*/



    void Start () {
       direction = new Vector2(EnemyTarget.transform.position.x-transform.position.x, EnemyTarget.transform.position.y - transform.position.y).normalized;

        BC = gameObject.GetComponent<BoxCollider2D>();

        WH = PW.GetComponent<WormHead>();
        

        randomizer();
        Ator = gameObject.GetComponent<Animation>();
        anima = gameObject.GetComponent<Animator>();





        rb = GetComponent<Rigidbody2D>();
       // Size = gameObject.transform.lo;

        SR = gameObject.GetComponent<SpriteRenderer>();
        SR.color = color;
        

        Spawning = true;
        color.a = 0;
       // color = new Color(255,255,255);
        
       Rotation();
         
        
    }



    // Update is called once per frame
    void Update () {
        Deaying();
        Typs();
        transform.localScale = new Vector2(EnemiesSize, EnemiesSize);
        Fadein();
        

    }


    void Rotation() {

        float AngleRad = Mathf.Atan2(EnemyTarget.transform.position.y - transform.position.y, EnemyTarget.transform.position.x - transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg-90);



    }
    void Detection() {

        float d = Vector2.Distance(EnemyTarget.transform.position, transform.position);

        if (d < 1) {

            Rotation();

        }
    
    }

    void Speed() {
 
            rb.MovePosition(rb.position + direction * EnemySpeed *Time.deltaTime );
           
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Worm" && EnemyTyp != "Mutation") {

            EnemyTyp = "Mutation";
            transform.parent = col.transform;
            WH.GotDmg(MaxSize);

        }
    }
    void Typs() {


        switch (EnemyTyp) {

            case "Ant":

                MaxVelocity = 0.1f;
                MaxSize = 1f;
                EnemyHP = 1;
                EnemySpeed = 1f;
                anima.SetBool("isAnt", true);
                color = new Color(1, 0, 0);
                break;

            case "Moth":
                MaxVelocity = 0.3f;
                MaxSize = 3f;
                EnemyHP = 1;
                EnemySpeed = 2;
                anima.SetBool("isMoth", true);
                color = new Color(0.9f, 0.5f, 0.1f);
                break;


            case "Spikeboll":
                MaxVelocity = 0.1f;
                MaxSize = 3f;
                EnemyHP = 1;
                EnemySpeed = 10;
                anima.SetBool("isSpikeboll", true);
                color = new Color(0.9f, 0.8f,0);
                break;


            case "Mushroom":
                MaxVelocity = 0;
                MaxSize = 3f;
                EnemyHP = 1;
                EnemySpeed = 0f;
                anima.SetBool("isMushroom", true);
                color = new Color(0.9f, 0.5f, 0.1f);
                break;

            case "Wasps":
                MaxVelocity = 0.3f;
                MaxSize = 3f;
                EnemyHP = 1;
                EnemySpeed = 1;
                anima.SetBool("isWasps", true);
                color = new Color(1f, 1f, 0.1f);
                break;

            case "Mutation":
                MaxVelocity = 0f;
                MaxSize = 1f;
                EnemyHP = 1;
                EnemySpeed = 0f;
                anima.SetBool("isMutatet", true);
                SR.color = color; 
                break;

            default: 
                break;

        }

    }
    void Fadein() {




        if (Spawning == true)

        {

            color.a += 0.01f;
            EnemiesSize += 0.01f;
            BC.enabled= false;




            if (EnemiesSize > MaxSize)
            {
                color.a = 0;
                EnemiesSize = MaxSize;
                Spawning = false;
            }

        }
        else
        {
            BC.enabled = true;
            Speed();
            Detection();
        }




    }
    void randomizer() {


        int R =  Random.Range(0,25);

        if (R < 5)
        {
            EnemyTyp = "Ant";


        }
        if (R > 5 && R < 10)
        {
            EnemyTyp = "Moth";


        }

        if (R > 10 && R < 15)
        {
            EnemyTyp = "Spikeboll";


        }

        if (R > 15 && R < 20)
        {
            EnemyTyp = "Wasps";


        }

        if (R > 20 && R < 25)
        {
            EnemyTyp = "Mushroom";


        }


    }
    void Deaying() {

        if (isEat) {

            EnemiesSize -= 0.1f;

            if (EnemiesSize <= 0)
            {
                Destroy(gameObject);
            }

        }



    }

}
