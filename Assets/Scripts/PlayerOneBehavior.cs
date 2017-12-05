using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneBehavior : EntityBehavior{

    public float attackSpeed;
    public bool _havekey;
    
    public GameObject pArrow;

    //animations
    private Vector2 _direction;
    private bool _isAttacking;

    public void ResetPlayer()
    {
        _isDie = false;
        _isHurt = false;
        life = initLife;
        _timeDie = 0;
    }
    
    public void Attack()
    {
        if (_time > attackSpeed)
        {
            GameObject arrow = GameObject.Instantiate(pArrow);
            arrow.transform.position = attackSpawner.transform.position;
            arrow.gameObject.tag = this.gameObject.tag;
            arrow.transform.right = attackSpawner.transform.right;
            arrow.GetComponent<ArrowBehavior>().Damage = damage;
            _time = 0;
            _isAttacking = true;
        }
    }

    public void Move(Vector2 direction)
    {
        if (!_isHurt)
        {
            _direction = direction;
            _rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
        }
        
    }

    public bool HaveKey
    {
        get { return _havekey; }
        set { _havekey = value; }
    }

    public float AttackSpeed
    {
        get { return attackSpeed; }
        set { attackSpeed = value; }
    }

    public Vector2 Direction
    {
        get { return _direction; }
    }

    public bool IsAttacking
    {
        get { return _isAttacking; }
        set { _isAttacking = value; }
    }
}
