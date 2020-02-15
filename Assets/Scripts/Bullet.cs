using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform tf;

    public float bulletSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        tf.position += tf.up * bulletSpeed * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D otherObject)
    {
        Debug.Log("The GameObject of the other object is named: " + otherObject.gameObject.name);
        // if player runs into the enemy ships, it dies                
            Destroy(otherObject.gameObject);
            Destroy(this.gameObject);                
    }
}
