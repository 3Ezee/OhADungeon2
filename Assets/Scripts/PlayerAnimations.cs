using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour {

    protected Animator _anim;
    protected PlayerOneBehavior _pawn;

    private bool _up=false;
    private bool _down = false;
    private bool _left = false;
    private bool _right = false;

    void Start()
    {
        _anim = this.GetComponent<Animator>();
        _pawn = this.GetComponent<PlayerOneBehavior>();
    }

    private void Update()
    {
        if (!_pawn.IsDie)
        {
            WalkAnimation();
            AttackAnimation();
            _anim.SetFloat("SpeedY", Mathf.Abs(_pawn.Direction.y));
            _anim.SetFloat("SpeedX", Mathf.Abs(_pawn.Direction.x));
        }
        else
        {
            _anim.Play("DieAnimation");
        }

    }

    private void WalkAnimation()
    {
        if(_pawn.Direction.x != 0)
        {
            if(_pawn.Direction.x < 0)
            {
                CheckDirection(3);
                _anim.Play("PlayerOneAnimationWalkLeft");
            }
            else
            {
                CheckDirection(4);
                _anim.Play("PlayerOneAnimationWalkRight");
            }
            
        }
        else if (_pawn.Direction.y != 0)
        {
            if (_pawn.Direction.y < 0)
            {
                CheckDirection(2);
                _anim.Play("PlayerOneAnimationWalkDown");
            }
            else
            {
                CheckDirection(1);
                _anim.Play("PlayerOneAnimationWalkUp");
            }
        }
    }

    private void AttackAnimation()
    {
        if (_pawn.IsAttacking)
        {
            if (_up)
            {
                _anim.Play("PlayerOneAnimationAttackUp");
            }
            else if(_right)
            {
                _anim.Play("PlayerOneAnimationAttackRight");
            }
            else if (_left)
            {
                _anim.Play("PlayerOneAnimationAttackLeft");
            }
            else if(_down)
            {
                _anim.Play("PlayerOneAnimationAttackDown");
            }
            else
            {
                _anim.Play("PlayerOneAnimationAttackDown");
            }
            _pawn.IsAttacking = false;
        }
    }

    void CheckDirection(int i)
    {
        if(i == 1)
        {
            _up = true;
            _down = false;
            _left = false;
            _right = false;
        }
        else if (i == 2)
        {
            _up = false;
            _down = true;
            _left = false;
            _right = false;
        }
        else if (i == 3)
        {
            _up = false;
            _down = false;
            _left = true;
            _right = false;
        }
        else if (i == 4)
        {
            _up = false;
            _down = false;
            _left = false;
            _right = true;
        }
    }
}
