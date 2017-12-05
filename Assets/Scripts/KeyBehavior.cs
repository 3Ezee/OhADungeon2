using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehavior : PickeableBehavior {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerOneBehavior>().HaveKey = true;
            _source.PlayOneShot(soundClip, 1f);
            DeactivatedItem();
            _isTaken = true;
         
        }
    }
}


