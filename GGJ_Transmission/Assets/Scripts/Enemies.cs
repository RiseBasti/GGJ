using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour {




    //Eigenschaften
    public string EmemyTyp = "Big";
    public float EnemiesSize = 0;
    Vector2 Size;
    public float MaxSize = 1;
    public int EnemyHP = 1;
    public float EnemySpeed = 0.5f;
    private Rigidbody2D rb;
    public Transform EnemyTarget;
    Sprite Visual;
    //Sprite
    private SpriteRenderer SR;
    Color Color = Color.white;

    //Speed
    public float MaxVelocity = 0.5f;
    public float MinVelocity = -0.5f;
    //boolean
    public bool boost = true;
    public bool Spawning = true;
    // Use this for initialization


  /*  public Enemies(string inTyp, Vector2  inPos) {

        transform.localPosition = inPos;
        


    }*/



    void Start () {
        
        rb = GetComponent<Rigidbody2D>();
       // Size = gameObject.transform.lo;

        SR = gameObject.GetComponent<SpriteRenderer>();
        SR.color = Color;

        Spawning = true;
        Color.a = 0;
        
       Rotation();
        
        
    }



    // Update is called once per frame
    void Update () {

        Typs();
        transform.localScale = new Vector2(EnemiesSize, EnemiesSize);
        Fadein();


    }


    void Rotation() {

        float AngleRad = Mathf.Atan2(EnemyTarget.position.y - transform.position.y, EnemyTarget.position.x - transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);


    }
    void Detection() {

        float d = Vector2.Distance(EnemyTarget.position, transform.position);

        if (d < 1) {

            Rotation();

        }
    
    }

    void Speed() {

        //Debug.Log(boost);

        float RVX = rb.velocity.x;
        float RVY = rb.velocity.y;

        if (RVX < 1 || RVX > -1) {
            rb.AddForce(transform.right * EnemySpeed);
            //boost = false;
            //rb.velocity = new Vector2(0, RVY);
        }

        if (RVY < 1 || RVY > -1)
        {
            rb.AddForce(transform.right * EnemySpeed);
            // boost = false;
            // rb.velocity = new Vector2(RVX, 0);
        }

        if (boost) {
          
           // rb.AddForce(transform.right * EnemySpeed);

        }
  


        
        
        


    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wurm") {

            EmemyTyp = "Mutation";

        }
    }


    void Typs() {



        if (EmemyTyp == "Smale")
        {

            // Visual = Resources.Load<Sprite>();
            MaxSize = 0.5f;
            EnemyHP = 1;
            EnemySpeed = 1f;
    
 

}
        if (EmemyTyp == "Big")
        {
            MaxSize = 5f;
            EnemyHP = 1;
            EnemySpeed = 0.5f;
            //Visual = Resources.Load<Sprite>();
        }
        if (EmemyTyp == "Mutation")
        {
            MaxSize = 1f;
            EnemyHP = 1;
            EnemySpeed = 0.5f;
            //Visual = Resources.Load<Sprite>();
        }











    }

    void Fadein() {


      

        if (Spawning == true)
            
        {

         Color.a += 0.01f;
         EnemiesSize += 0.01f;
            
        
            


            if (EnemiesSize > MaxSize)
            {
               Color.a = 0;
               EnemiesSize = MaxSize;
               Spawning = false;
            }

        }
        else
        {

            Speed();
            Detection();
            //EnemiesSize = 0;
        }




    }

}
