﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {
    public BossBehavior _pawn;
    // Use this for initialization
    void Start () {
        _pawn = this.GetComponent<BossBehavior>();
    }
	
	// Update is called once per frame
	void Update () {
        _pawn.Move(_pawn.transform.up);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            _pawn.transform.up = -_pawn.transform.up;
        }
    }


}