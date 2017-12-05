using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : EnemyBehavior{

    public void Move(Vector2 direction)
    {
        _rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
    }
}
