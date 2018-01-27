using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject Enemy;
    public GameObject Camera;

    private float timer = 1;



    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {

        timer -= Time.deltaTime;

        if (timer <= 0) {
            Spawner();
            timer = 0.5f;

        }
    }


    void Spawner() {
        

        float SpawnArealXmin = Camera.transform.position.x - 50;
        float SpawnArealXmax = Camera.transform.position.x + 50;

        float SpawnArealYmin = Camera.transform.position.y - 50;
        float SpawnArealYmax = Camera.transform.position.y + 50;

        float RandomX = Random.Range(SpawnArealXmin, SpawnArealXmax);
        float RandomY = Random.Range(SpawnArealYmin, SpawnArealYmax);

        Vector2 SpawnAreal = new Vector2(RandomX, RandomY);

        while(Vector2.Distance(SpawnAreal, Camera.transform.position)<7)
        {
            RandomX = Random.Range(SpawnArealXmin, SpawnArealXmax);
            RandomY = Random.Range(SpawnArealYmin, SpawnArealYmax);

            SpawnAreal = new Vector2(RandomX, RandomY);
        }

        Instantiate(Enemy, SpawnAreal,transform.rotation);
        }

    
}
