using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour {

    //Eigenschaften
    public string EmemyTyp = "";
    public float EnemiesSize = 1;
    public int EnemyHP = 1;
    public float EnemySpeed = 0.01f;
    private Rigidbody2D rb;
    public Transform EnemyTarget;

    //Speed
    public float MaxVelocity = 0.5f;
    public float MinVelocity = -0.5f;
    public bool boost = true;

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody2D>();
       Rotation();


    }



    // Update is called once per frame
    void Update () {

        Speed();


        Detection();

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

        Debug.Log(boost);

        float RVX = rb.velocity.x;
        float RVY = rb.velocity.y;

        if (RVX > 1 || RVX < -1) {

           //boost = false;
           //rb.velocity = new Vector2(0, RVY);
        }

        if (RVY > 1 || RVY < -1)
        {

           // boost = false;
           // rb.velocity = new Vector2(RVX, 0);
        }

        if (boost) {
          
           // rb.AddForce(transform.right * EnemySpeed);

        }
  


        
        
        


    }
}
