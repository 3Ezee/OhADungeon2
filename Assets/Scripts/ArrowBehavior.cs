using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehavior : MonoBehaviour {

    public float speed;
    public float timeAlive;
    protected int _damage;
    protected float _time = 0;

    void Update()
    {
        _time += Time.deltaTime;
        if (_time >= timeAlive)
        {
            GameObject.Destroy(this.gameObject);
        }
        else
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.gameObject.tag == "Player" && collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EntityBehavior>().ReceiveDamage(_damage,new Vector2(1,0));
            GameObject.Destroy(this.gameObject);
        }
        if (this.gameObject.tag == "Enemy" && collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<EntityBehavior>().ReceiveDamage(_damage, -this.transform.right);
            GameObject.Destroy(this.gameObject);
        }
        if(collision.gameObject.tag== "Wall")
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    public int Damage
    {
        set { _damage = value; }
    }
}