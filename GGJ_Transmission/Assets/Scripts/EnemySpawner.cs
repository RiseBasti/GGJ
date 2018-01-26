using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {





    public GameObject Enemy;
    public GameObject Camera;
    public float Timer = 120;
    private float CountDown = 1;
    float timer = 120;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        

         timer -= 1;

        if (timer <= 0) {
            Spawner();
            timer = 120;

        }



       


    }


    void Spawner() {


        float SpawnArealXmin = Camera.transform.position.x - 10;
        float SpawnArealXmax = Camera.transform.position.x + 10;

        float SpawnArealYmin = Camera.transform.position.y - 10;
        float SpawnArealYmax = Camera.transform.position.y + 10;

        float RandomX = Random.Range(SpawnArealXmin, SpawnArealXmax);
        float RandomY = Random.Range(SpawnArealYmin, SpawnArealYmax);

        Vector2 SpawnAreal = new Vector2(RandomX, RandomY);

        Instantiate(Enemy, SpawnAreal,transform.rotation);

    }
}
