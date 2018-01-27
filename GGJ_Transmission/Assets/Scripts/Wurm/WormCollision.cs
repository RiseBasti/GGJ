﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormCollision : MonoBehaviour
{
    //Variabales
    //Components
    public WormHead wormHead;


	// Use this for initialization
	private void Start ()
    {
		
	}
	
	// Update is called once per frame
	private void Update ()
    {
		
	}

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            switch (coll.gameObject.GetComponent<Enemies>().EnemyTyp)
            {
                case "Big":
                    wormHead.enemy1++;
                    break;
                case "Small":
                    wormHead.enemy2++;
                    break;
                default:
                    
                    break;
            }
        }
    }
}