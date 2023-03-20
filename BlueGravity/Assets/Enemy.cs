using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int gold = 1000;
    public Transform playerTransform;
    
    public float speed = 5f;

    public bool StartChase;
    

    // Update is called once per frame
    void Update()
    {
        if (!StartChase) return;
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }
    
}
