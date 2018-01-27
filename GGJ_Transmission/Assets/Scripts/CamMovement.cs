using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    //Variables
    public GameObject worm;
    public GameObject zelle;


	// Use this for initialization
	private void Start ()
    {
		
	}
	
	// Update is called once per frame
	private void Update ()
    {
        transform.position = new Vector3((worm.transform.position.x + zelle.transform.position.x) / 2, (worm.transform.position.y + zelle.transform.position.y) / 2,-10);
	}
}
