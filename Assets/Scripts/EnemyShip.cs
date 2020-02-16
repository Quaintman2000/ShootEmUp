using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public Transform tf;
    public float speed = 1.0f;
    public float rotaionSpeed=1.0f;
    public Transform playerTransform;


    public float movementDirectionRad;
    public float movementDirectionDeg;
    public Quaternion directionFromSelf;
    // Start is called before the first frame update
    void Start()
    {
        GameManger.instance.enemiesList.Add(this.gameObject);
        tf = GetComponent<Transform>();
        playerTransform = GameManger.instance.player1.GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        playerTransform = GameManger.instance.player1.GetComponent<Transform>();
        //adjust rotation every update for heat seeking behavior
        tf.rotation= Quaternion.RotateTowards(tf.rotation, Quaternion.Euler(0, 0, Mathf.Atan2(playerTransform.position.y - tf.position.y, playerTransform.position.x - tf.position.x) * (180 / Mathf.PI)-90), rotaionSpeed * Time.deltaTime);
        Debug.Log(Mathf.Atan2(playerTransform.position.y - tf.position.y, playerTransform.position.x - tf.position.x) * (180 / Mathf.PI)-90);
        Debug.DrawLine(tf.position, playerTransform.position,Color.red);
         //moves the ship in given direction.
         tf.position = tf.position + tf.up * speed * Time.deltaTime;
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
    private void OnDestroy()
    {
        //removes them from the list when they die
        GameManger.instance.enemiesList.Remove(this.gameObject);
    }
}
