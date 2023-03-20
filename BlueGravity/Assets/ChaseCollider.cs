using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseCollider : MonoBehaviour
{
    public Enemy Enemy;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Enemy.playerTransform = col.gameObject.transform;
            Enemy.StartChase = true;
        }
            
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player") Enemy.StartChase = false;
    }
}
