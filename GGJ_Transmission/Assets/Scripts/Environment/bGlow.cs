using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bGlow : MonoBehaviour
{
    public GameObject cam;
    private SpriteRenderer sr;
    public Color glowColor;
    private float speed;
    private float range;

    private float r;
    private float g;
    private float b;

	// Use this for initialization
	void Start ()
    {
        r = Random.Range(0.25f, 1);
        g = Random.Range(0.25f, 1);
        b = Random.Range(0.25f, 1);

        glowColor = new Color(r, g, b, 0.05f);
        sr = GetComponent<SpriteRenderer>();
        speed = Random.Range(5, 20);
        range = Random.Range(0.05f,0.15f);
        transform.localScale = new Vector2(Random.Range(1,5), Random.Range(1, 5));
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Mathf.Abs(transform.position.x-cam.transform.position.x) > 50 || Mathf.Abs(transform.position.y - cam.transform.position.y) > 50)
        {
            transform.position = new Vector2(Random.Range(-50,50) + cam.transform.position.x, Random.Range(-50, 50) + cam.transform.position.y);
        }

        glowColor.a = 0.3f + Mathf.PingPong(Time.time/speed, range);
        sr.color = glowColor;
        

    }
}
