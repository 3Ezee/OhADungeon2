using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1ControllerB : MonoBehaviour {


    public Enemy1Behavior _pawn;
    public Vector2 _direction = new Vector2(1, 0);

    private float _time = 0;
    public float timeChangeDirection;

    private bool _stop = false;

    // Use this for initialization
    void Start()
    {
        _pawn = this.GetComponent<Enemy1Behavior>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!_pawn.IsDie && _pawn.PlayerDetected())
        {
            _time += Time.deltaTime;

            if (_time >= timeChangeDirection)
            {
                _direction = -_direction;
                _time = 0;
                _stop = false;
            }
            Move();
        }
    }

    void Move()
    {
        if(!_stop)
            _pawn.Move(_direction);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            //_stop = true;
        }
    }
}

