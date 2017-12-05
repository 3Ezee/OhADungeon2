using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMoreAttackSpeedBehavior : PickeableBehavior
{

    public float value;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerOneBehavior>().AttackSpeed += value;
            _source.PlayOneShot(soundClip, 1f);
            DeactivatedItem();  
            _isTaken = true;
        }
    }
}
