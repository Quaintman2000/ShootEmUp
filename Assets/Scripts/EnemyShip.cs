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
        //tf.position = tf.position + Vector3.right * speed * Time.deltaTime;
       // tf.postion += Vector3.MoveTowards(tf.postion,)
    }

    private void OnCollisionEnter2D(Collision2D otherObject)
    {
        Debug.Log("The GameObject of the other object is named: " + otherObject.gameObject.name);
        // if player runs into the enemy ships, it dies
        if (otherObject.gameObject == GameManger.instance.player1)
        {
            Destroy(otherObject.gameObject);
            Destroy(this.gameObject);
        }

    }
}
