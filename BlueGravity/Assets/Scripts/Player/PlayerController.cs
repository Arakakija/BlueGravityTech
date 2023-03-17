using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;

    public bool isGrounded;

    public bool CanInteract;
    
    [field: SerializeField] public PlayerUI PlayerUI { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Shop"))
        {
            CanInteract = true;
            PlayerUI.ShowInteractButton(CanInteract);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Shop"))
        {
            CanInteract = false;
            PlayerUI.ShowInteractButton(CanInteract);
        }
    }
}
