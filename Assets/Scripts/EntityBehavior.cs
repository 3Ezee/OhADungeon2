using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBehavior : MonoBehaviour {

    public int life;
    public float speed;
    public int damage;
    public float valueKnockBack;
    public float timeHurt;
    public float timeDie;

    public bool _isDie;
    protected Rigidbody2D _rb;

    protected bool _isCollisionWall=false;
    protected bool _isHurt = false;

    protected float _time;
    protected float _timeHurt;
    protected float _timeDie;

    public AudioClip hitSound;
    public AudioClip dieSound;

    protected AudioSource _source;

    public Transform attackSpawner;

    //init 
    protected int initLife;
    protected Rigidbody2D initRb;

    protected void Awake()
    {
        _rb = this.GetComponent<Rigidbody2D>();
        _source = this.gameObject.GetComponent<AudioSource>();
        initLife = life;
        initRb = _rb;
    }

    public virtual void ResetEntity()
    {
        life = initLife;
        _isDie = false;
        _isHurt = false;
        _timeDie = 0;
        //this.transform.localScale = new Vector3(1, 1, 1);
        _rb.gameObject.SetActive(true);
    }

    private void Update()
    {
        _time += Time.deltaTime;
        _timeHurt += Time.deltaTime;
        if(_timeHurt >= timeHurt)
        {
            _isHurt = false;
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1F, 1F, 1F, 1F);
        }
        if (_isDie)
            _timeDie += Time.deltaTime;
        
        if (_timeDie>= timeDie)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void ReceiveDamage(int damage, Vector2 direction)
    {
        life -= damage;
        _isHurt = true;
        KnockBack(direction);

        if (life <= 0)
        {
            Die();
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.8F, 0.6F, 0.6F, 1F);
            _source.PlayOneShot(hitSound, 1f);
        }       
    }

    protected virtual void Die()
    {

        if (!_isDie)
        {
            _rb.velocity = new Vector2(0, 0);
            _isDie = true;
            _source.PlayOneShot(dieSound, 1f);
        }
    }

    protected void KnockBack(Vector2 direction)
    {
        _rb.AddForce(-direction * valueKnockBack, ForceMode2D.Impulse);
        _timeHurt = 0;
    }

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    public bool IsDie
    {
        get { return _isDie; }
        set { _isDie = value; }
    }

    public int InitLife
    {
        get { return initLife; }
        
    }

    public bool IsCollisionWall
    {
        get { return _isCollisionWall; }
        set { _isCollisionWall = value; }
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            _isCollisionWall = true;
        }
        if (this.gameObject.tag == "Enemy" && collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<EntityBehavior>().ReceiveDamage(damage, -this.transform.right);
        }
    }
    protected virtual void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            _isCollisionWall = false;
        }
    }
}
