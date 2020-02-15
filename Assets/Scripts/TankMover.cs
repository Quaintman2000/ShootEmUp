using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : MonoBehaviour
{
    private Transform tf;

    public float speed = 1.0f;
    public float turnSpeed = 1.0f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shoot();
        }

    }
    private void shoot()
    {
        Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
    }
 
   
    private void OnDestroy()
    {
        //If the player dies, they lose a life
        GameManger.instance.lives -= 1;
        if (GameManger.instance.lives > 0)
        {
            GameManger.instance.Respawn();
        }
        else
            Debug.Log("Game Over");
    }
}
