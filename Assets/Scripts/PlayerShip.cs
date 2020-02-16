using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    private Transform tf;

    public float speed = 1.0f;
    public float turnSpeed = 1.0f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    public AudioSource boomSound;

    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //basic controls
        if (Input.GetKey(KeyCode.UpArrow))
        {
            tf.position += tf.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            tf.position += -tf.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            tf.Rotate(0, 0, -turnSpeed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            tf.Rotate(0, 0, turnSpeed);
        }
        //shoots a bullet
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shoot();
        }

    }
    private void shoot()
    {
        //spawns the bullet prefab at the position of the firepoint and the direction the firpoint is facing.
        Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
        boomSound.Play();
    }
 
   
    private void OnDestroy()
    {
        //If the player dies, they lose a life and respawns
        GameManger.instance.lives -= 1;
        if (GameManger.instance.lives > 0)
        {
            GameManger.instance.Respawn();
        }
        else
            Debug.Log("Game Over");
        //destroys other objects when player dies
        Destroy(GameManger.instance.enemiesList[0]);
        Destroy(GameManger.instance.enemiesList[1]);
        Destroy(GameManger.instance.enemiesList[2]);
        //clears the list
        GameManger.instance.enemiesList.Clear();
    }
}
