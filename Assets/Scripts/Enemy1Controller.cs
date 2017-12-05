using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy1Controller : MonoBehaviour {

    public Enemy1Behavior _pawn;
    Vector2 _direction = new Vector2(1,0);

    private bool _isKnockBack=false;
    private float _time = 0;
    public float timeKnockBack;

    // Use this for initialization
    void Start()
    {
        _pawn = this.GetComponent<Enemy1Behavior>();
    }

    // Update is called once per frame
    void Update()
    {
       
        _time += 0.01f; 
            
        if (_time >= timeKnockBack)
        {
            _direction = GetRandomDirection();
            _time = 0;
        }
        Move();
    }

    void Move()
    {
        _pawn.Move(_direction);
    }

    void KnockBack(float force)
    {
        if(_pawn.IsCollisionWall && _isKnockBack)
        {
            _time = 0;
            _isKnockBack = true;
        }      
    }

    Vector2 GetRandomDirection()
    {
        Vector2 aux;
        int randomNumber = GetRandomNumber();

        if(randomNumber == 0)
        {
            aux = SetAux(1, 0);
            
        }
        else if(randomNumber == 1)
        {
            aux = SetAux(-1, 0);
            
        }
        else if(randomNumber == 2)
        {
            aux = SetAux(0, 1);
            
        }
        else
        {
            aux = SetAux(0, -1);
        }


        Debug.Log(aux);
        return aux;

    }

    int GetRandomNumber()
    {
        System.Random random = new System.Random();
        return random.Next(0, 3);
    }

    Vector2 SetAux(int i, int j)
    {
        return new Vector2(i, j);
    }
}
