using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public Transform tf;
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //adjust rotation every update for heat seeking behavior
        //
        tf.position = tf.position + Vector3.right * speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collider2D otherObject)
    {

    }
}
