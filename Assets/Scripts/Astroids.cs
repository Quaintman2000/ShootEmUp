using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroids : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManger.instance.enemiesList.Add(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        GameManger.instance.enemiesList.Remove(this.gameObject);
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
