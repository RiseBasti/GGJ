using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Zelle : MonoBehaviour
{
    //Variables
    //Stats
    private float speed = 3;

    private float eatSpeed = 1;



    //Script
    private Vector2 direction = new Vector2(0, 0);
    private float rotation = 0;

    private bool eating = false;
    private float eatTimer = 0;
    public bool dead = false;

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

        //Debug.Log(dead);

        if (!dead)
        {

            Move();
            Eat();
        }
        else

        {
            SceneManager.LoadScene("GameOver");
        }
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

        transform.rotation = Quaternion.Euler(0f, 0f, rotation-90);
        rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
    }

    private void Eat()
    {
        if (eating)
        {
            eatTimer -= Time.deltaTime * eatSpeed;
            if (eatTimer <= 0)
            {
                eating = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Enemy" || collision.tag == "Item")
        {
            Enemies enemies = collision.GetComponent<Enemies>();
            if(enemies.EnemyTyp == "Mutation")
            {

                if(!eating && Input.GetAxis("Eat") != 0)

                {
                    transform.localScale += new Vector3(0.1f, 0.1f, 0);
                    eatSpeed += 0.1f;
                    eating = true;
                    enemies.isEat = true;
                    enemies.eatSpeed = eatSpeed;
                    eatTimer = enemies.MaxSize;
                    collision.transform.position = transform.position;
                    collision.transform.parent = transform;
                }
            }
            else
            {
                enemies.EnemyTyp = "Mutation";
                collision.transform.parent = transform;
                dead = true;
            }
        }
    }
}
