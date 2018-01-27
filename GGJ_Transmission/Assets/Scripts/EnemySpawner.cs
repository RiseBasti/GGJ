using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {


   // Enemies[] enemies;


     int MaxEnemies = 10;
    public GameObject Enemy;
    public GameObject Camera;
    public float Timer = 120;

    float timer = 120;



    // Use this for initialization
    void Start () {
        //enemies = new Enemies[MaxEnemies];


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


      /*  for (int i = 0; i < MaxEnemies; ++i) {
            
            if (enemies[i] != null) {

                enemies[i] = new Enemies("Big", SpawnAreal);
                Debug.Log("fuck");
            */
        }

    
}
