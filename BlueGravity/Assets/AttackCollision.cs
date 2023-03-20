using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            PlayerController.Instance.GainGold(col.gameObject.GetComponent<Enemy>().gold);
            col.gameObject.SetActive(false);
        }
    }
}
