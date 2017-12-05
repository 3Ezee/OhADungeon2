using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Behavior : EnemyBehavior {

    public void Move(Vector2 direction)
    {
        if (direction != Vector2.zero)
            this.transform.right = direction;
        _anim.SetFloat("SpeedX", Mathf.Abs(_rb.velocity.x));
        _rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
    }


}
