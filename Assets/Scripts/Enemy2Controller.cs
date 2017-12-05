using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Controller : MonoBehaviour {

    public Enemy2Behavior _pawn;

    // Use this for initialization
    void Start()
    { 
        _pawn = this.GetComponent<Enemy2Behavior>();
    }

    void Update()
    {
        if (!_pawn.IsDie && _pawn.PlayerDetected())
        {
            _pawn.Move();
        }
        else if(!_pawn.IsDie && !_pawn.PlayerDetected())
        {
            _pawn.NoMove();
        }
    }
}
