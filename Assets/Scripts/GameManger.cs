using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject player1;
    public GameObject asteroidPrefab;

   

    public static GameManger instance;

    public int lives = 3;
    public int score = 0;

    public bool isPaused = false;

    public List<GameObject> enemiesList = new List<GameObject>();
    public GameObject[] ememyPrefab;

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
        Respawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            //if (player1 == null)
            //{
            //    Respawn();
            //}

            Instantiate(asteroidPrefab);
        }
    }

    public void Respawn()
    {
        player1 = Instantiate(playerPrefab);
    }
}
