using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOneController : MonoBehaviour {

    public PlayerOneBehavior _pawn;
    Vector2 _direction;

    public Button Continuar;
    public Button Reiniciar;
    public Button MenuPrincipal;
    private bool _isOpen = false;

    // Use this for initialization
    void Start()
    {
        _pawn = this.GetComponent<PlayerOneBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_pawn.IsDie)
        {
            Move();
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!_isOpen)
            {
                Debug.Log("Pause game");
                //Continuar.gameObject.SetActive(true);
                Reiniciar.gameObject.SetActive(true);
                MenuPrincipal.gameObject.SetActive(true);
                _isOpen = true;
            }
            else
            {
                Debug.Log("Continue game");
                //Continuar.gameObject.SetActive(false);
                Reiniciar.gameObject.SetActive(false);
                MenuPrincipal.gameObject.SetActive(false);
                _isOpen = false;
            }
        }
    }

    void Move()
    {
        _direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _pawn.Move(_direction);
    }
    void Attack()
    {
        if(Input.GetButtonDown("Fire1"))
            _pawn.Attack();
    }

}
