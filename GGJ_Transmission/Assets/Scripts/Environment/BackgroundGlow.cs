using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGlow : MonoBehaviour
{
    //Variables
    public GameObject bGlow;

    // Use this for initialization
    void Start ()
    {
		for(int i = 0; i<100; i++)
        {
            Instantiate(bGlow, new Vector2(Random.Range(-50,50),Random.Range(-50,50)), Quaternion.identity);
        }
	}
}
