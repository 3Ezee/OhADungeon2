using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Behavior : EnemyBehavior {

    public void Move()
    {
        float step = speed * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(transform.position, PlayerPos.position, step);

        attackSpawner.rotation = Quaternion.Slerp(attackSpawner.rotation,
        Quaternion.LookRotation(PlayerPos.position - attackSpawner.position), 100 * Time.deltaTime);
        _anim.SetBool("isMove", true);


    }
    public void NoMove()
    {
        _anim.SetBool("isMove", false);

    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            _isCollisionWall = true;
        }
        if (this.gameObject.tag == "Enemy" && collision.gameObject.tag == "Player")
        {
            Debug.Log(attackSpawner.forward);
            collision.gameObject.GetComponent<EntityBehavior>().ReceiveDamage(damage, -attackSpawner.forward);
        }
    }
}
