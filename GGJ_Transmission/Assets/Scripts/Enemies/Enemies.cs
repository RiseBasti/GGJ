using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    //Variables
    //Stats
    [HideInInspector] public string EnemyTyp;
    [HideInInspector] private float deathTimer = 100;


    //Script
    [HideInInspector] public float eatSpeed = 1;
    Vector2 direction;
    [HideInInspector] public float EnemiesSize;
    [HideInInspector] public float MaxSize;
    private float EnemySpeed;
    private float rotation = 0;

    public bool isEat = false;
    private bool hpRestored = false;
    public bool boost = true;
    public bool Spawning = true;
    public bool collected = false;

    //Objects
    private GameObject playerWorm;
    private WormHead wormHead;
    private ParticleSystem ps;
    private GameObject EnemyTarget;
    

    //Components
    BoxCollider2D boxCol;
    AnimationClip anim;
    private Animation Ator;
    Animator anima;

    private Rigidbody2D rb;

    private SpriteRenderer sr;
    private Color enemyColor = new Color(1, 1, 1);


    // Use this for initialization
    void Start()
    {
        

        playerWorm = GameObject.FindGameObjectWithTag("WormHead");
        wormHead = playerWorm.GetComponent<WormHead>();

        EnemyTarget = GameObject.FindGameObjectWithTag("Zelle");

        direction = new Vector2((EnemyTarget.transform.position.x + Random.Range(-12, 12)) - transform.position.x, (EnemyTarget.transform.position.y + Random.Range(-7, 7)) - transform.position.y).normalized;

        boxCol = gameObject.GetComponent<BoxCollider2D>();

        
        Ator = gameObject.GetComponent<Animation>();
        anima = gameObject.GetComponent<Animator>();
        ps = GetComponent<ParticleSystem>();
        rb = GetComponent<Rigidbody2D>();
        // Size = gameObject.transform.lo;

        sr = gameObject.GetComponent<SpriteRenderer>();

        randomizer();

        Spawning = true;
        enemyColor.a = 0;

        Typs();

        Rotation();
    }



    // Update is called once per frame
    void Update()
    {
        Deaying();
       
        Fadein();

        if(deathTimer>0 && EnemyTyp != "Mutation")
        {
            deathTimer -= Time.deltaTime;
            if(deathTimer<=0)
            {
                //print(deathTimer);
                isEat = true;
                hpRestored = true;
            }
        }

    }


    void Rotation()
    {
        rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotation-90);
    }
    void Detection()
    {

        float d = Vector2.Distance(EnemyTarget.transform.position, transform.position);

        if (EnemyTyp != "Beatle" && EnemyTyp != "Mushrooms" && d < 5)
        {
            direction = new Vector2(EnemyTarget.transform.position.x - transform.position.x, EnemyTarget.transform.position.y - transform.position.y).normalized;
            Rotation();
        }

    }
    void Speed()
    {
        rb.MovePosition(rb.position + direction * EnemySpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (isEat) { return; }
        ps.Play();
        if (EnemyTyp == "Beatle")
        {

            if (col.gameObject.tag == "WormHead")
            {
                transform.parent = col.transform;
                EnemyTyp = "Mutation";
                Typs();
                
               
                hpRestored = true;
                isEat = true;
            }

        }
        else if((col.gameObject.tag == "Worm" || col.gameObject.tag == "WormHead") && EnemyTyp != "Mutation")
        {
            
            transform.parent = col.transform;
            EnemyTyp = "Mutation";
            Typs();
            wormHead.GotDmg(MaxSize);
            boxCol.enabled = true;
            
            


        }
    }
    void Typs()
    {
        switch (EnemyTyp)
        {

            case "Ant":
                MaxSize = 1f;
                EnemySpeed = 2f;
                deathTimer = 15;
                anima.SetBool("isAnt", true);
                enemyColor = new Color(1, 0, 0);
                boxCol.size = new Vector2(0.25f,0.4f);
                break;

            case "Moth":
                MaxSize = 3f;
                EnemySpeed = 1f;
                deathTimer = 40;
                anima.SetBool("isMoth", true);
                enemyColor = new Color(0.9f, 0.5f, 0.1f);
                boxCol.size = new Vector2(0.9f, 0.4f);
                boxCol.offset = new Vector2(0, -0.05f);
                break;


            case "Spikeboll":
                MaxSize = 3f;
                EnemySpeed = 1.5f;
                deathTimer = 20;
                anima.SetBool("isSpikeboll", true);
                enemyColor = new Color(0.9f, 0.8f, 0);
                boxCol.size = new Vector2(0.35f, 0.35f);
                break;


            case "Mushroom":
                MaxSize = 3f;
                EnemySpeed = 0f;
                deathTimer = 100;
                anima.SetBool("isMushroom", true);
                enemyColor = new Color(0.9f, 0.5f, 0.1f);
                boxCol.size = new Vector2(0.5f, 0.5f);
                break;

            case "Wasps":
                MaxSize = 3f;
                EnemySpeed = 3f;
                deathTimer = 20;
                anima.SetBool("isWasps", true);
                enemyColor = new Color(1f, 1f, 0.1f);
                boxCol.size = new Vector2(0.3f, 0.65f);
                break;

            case "Mutation":

                EnemySpeed = 0f;
                deathTimer = 100;
                anima.SetBool("isMutatet", true);
                enemyColor.a = 1;
                isEat = false;
                sr.color = enemyColor;
                boxCol.size = new Vector2(1, 1);
                boxCol.offset = new Vector2(0, 0);
                break;


            case "Beatle":
                gameObject.tag = "Item";
                MaxSize = 1f;
                EnemySpeed = 4f;
                deathTimer = 10;
                anima.SetBool("isBeatle", true);
                enemyColor = new Color(0.13f, 0.4f, 1f);
                boxCol.size = new Vector2(1, 1);
                break;


            default:
                break;

        }
        
    }
    void Fadein()
    {

        if (Spawning == true)
        {
            enemyColor.a += 0.01f;
            EnemiesSize += 0.01f;
            transform.localScale = new Vector2(EnemiesSize, EnemiesSize);
            boxCol.enabled = false;

            if (EnemiesSize > MaxSize)
            {
                enemyColor.a = 0;
                EnemiesSize = MaxSize;
                Spawning = false;
            }
        }
        else
        {
            boxCol.enabled = true;
            Speed();
            Detection();
        }
    }
    void randomizer()
    {


        int R = Random.Range(0, 31);

        if (R < 10)
        {
            EnemyTyp = "Ant";


        }
        if (R > 10 && R < 15)
        {
            EnemyTyp = "Moth";


        }

        if (R > 15 && R < 18)
        {
            EnemyTyp = "Spikeboll";


        }

        if (R > 18 && R < 20)
        {
            EnemyTyp = "Wasps";


        }

        if (R > 20 && R < 27)
        {
            EnemyTyp = "Mushroom";


        }

        if (R > 27 && R < 31)
        {
            EnemyTyp = "Beatle";


        }



    }
    void Deaying()
    {

        if (isEat)
        {
            boxCol.enabled = false;
            if (!hpRestored)
            {
                wormHead.GotHealed(MaxSize);
                hpRestored = true;
            }


            EnemiesSize -= Time.deltaTime * eatSpeed;
            transform.localScale = new Vector2(EnemiesSize, EnemiesSize);


            if (EnemiesSize <= 0)
            {
                Destroy(gameObject);
            }
        }

    }

 
}
