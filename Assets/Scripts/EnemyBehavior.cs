using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : EntityBehavior {

    protected Transform _posPlayer;
    public float rangeDetect;
    protected Animator _anim;
    protected Vector3 _trans;

    protected void Start()
    {
        DetectPlayer();
        _anim = this.gameObject.GetComponent<Animator>();
        _trans = this.transform.position;
    }

    public override void ResetEntity()
    {
        base.ResetEntity();
       _anim.Play("Entry");
    }

    protected void DetectPlayer()
    {
        _posPlayer = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    public bool PlayerDetected()
    {
        if (_posPlayer!= null && Vector2.Distance(transform.position, _posPlayer.position) < rangeDetect)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    protected override void Die()
    {
        base.Die();
        _anim.Play("DieAnimation");
    }

    public Transform PlayerPos
    {
        get { return _posPlayer; }
    }

    protected override void OnCollisionExit2D(Collision2D collision)
    {
        base.OnCollisionExit2D(collision);
        if (this.gameObject.tag == "Enemy" && collision.gameObject.tag == "Player")
        {
            _rb.velocity = new Vector2(0, 0);
        }
    }

    public Vector3 MyTransform
    {
        get { return _trans; }
    }
}
