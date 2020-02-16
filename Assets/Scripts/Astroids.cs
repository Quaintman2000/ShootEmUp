using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroids : MonoBehaviour
{
    public Transform tf;
    public Vector3 playerLastKnownSpot;
    public Transform playerTransform;
    public float speed;
    public AudioSource boom;
    // Start is called before the first frame update
    void Start()
    {
        GameManger.instance.enemiesList.Add(this.gameObject);
        tf = GetComponent<Transform>();
        playerTransform = GameManger.instance.player1.GetComponent<Transform>();
        playerLastKnownSpot = playerTransform.position;
        boom = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        tf.position += (playerLastKnownSpot - tf.position) * speed * Time.deltaTime;
    }
    private void OnDestroy()
    {
       //removes them from the list when they die
        GameManger.instance.enemiesList.Remove(this.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D otherObject)
    {
        Debug.Log("The GameObject of the other object is named: " + otherObject.gameObject.name);
        // if player runs into the enemy asteroid, it dies
        if (otherObject.gameObject == GameManger.instance.player1)
        {
            Destroy(otherObject.gameObject);
            Destroy(this.gameObject);
        }

    }
}
