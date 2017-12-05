using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Controller : MonoBehaviour {

    public Enemy3Behavior _pawn;

    // Use this for initialization
    void Start()
    {
        _pawn = this.GetComponent<Enemy3Behavior>();
    }

    void Update()
    {
        if (_pawn.PlayerDetected() && !_pawn.IsDie)
        {
            Attack();
        }
    }

    protected void Attack()
    {
        _pawn.Attack();
    }
}
