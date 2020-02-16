using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject player1;
    public GameObject[] asteroidPrefab;

    public static GameManger instance;

    public int lives = 3;
    public int score = 0;

    public bool isPaused = false;
    

    public List<GameObject> enemiesList = new List<GameObject>();
    public GameObject[] enemyPrefab;
    public GameObject[] enemySpawnPoint;
    public float randomNum;
    public Vector3 startSpot;
    public float enemyShipChance=8;
    public float enemySpawnRadius = 5;
    public Vector2 randomSpot;
    public int enemyShipOfChoice = 0;
    public int asteroidOfChoice = 0;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            Debug.LogError("I tried to create a second game manager");
        }
        //spawns the player
        Respawn();
       
    }

    // Update is called once per frame
    void Update()
    {
        //quits application if player press escape button or when lives = 0
        if (Input.GetKeyDown(KeyCode.Escape) || lives == 0)
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            //if (player1 == null)
            //{
            //    Respawn();
            //}
        }
       
        //if the num of enemies is less than 3
        if(enemiesList.Count < 3)
        {
            //rolls random number between 0 and 10
            randomNum = Random.Range(0.0f, 10.0f);
            //if Random number > 7 then spawn a enemy ship
            if(randomNum > enemyShipChance)
            {
                EnemyRespawn();
            }
            else
            {
                AsteroidRespawn();
            }
        }
    }
    //respawn player function
    public void Respawn()
    {
        player1 = Instantiate(playerPrefab);
    }
    //spawns asteroids
    public void AsteroidRespawn()
    {
        //determines the random spot within a circle with a designer given radius
        randomSpot = Random.insideUnitCircle * enemySpawnRadius;
        //sets the starting position somewhere within whatever the designer sets units from the original while keeping the same z axis as the player and cannont spawn within origin
        startSpot.Set(player1.transform.position.x + randomSpot.x, player1.transform.position.y + randomSpot.y, 0);
        //spawns the asteroid at given location
        Instantiate(asteroidPrefab[asteroidOfChoice],startSpot,this.transform.rotation);
    }
    //respawns enemy ships
    public void EnemyRespawn()
    {
        //determines the random spot within a circle with a designer given radius
        randomSpot = Random.insideUnitCircle * enemySpawnRadius;
        //sets the starting position somewhere within whatever the designer sets units from the original while keeping the same z axis as the player and cannont spawn within origin
        startSpot.Set(player1.transform.position.x + randomSpot.x, player1.transform.position.y + randomSpot.y, 0);
        //spawns the Enemy ship at given location
        Instantiate(enemyPrefab[enemyShipOfChoice],startSpot, Quaternion.RotateTowards(enemyPrefab[1].transform.rotation, Quaternion.Euler(0, 0, 0),360.0f));
    }
}
