using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Behavior : Enemy1Behavior{
    public float attackSpeed;
    //private float _time;

    public GameObject pArrow;

    /*private void Update()
    {
        _time += Time.deltaTime;
    }*/

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
        }
    }
}
