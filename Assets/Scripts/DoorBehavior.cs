using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour {

    public AudioClip openDoor;
    protected AudioSource _source;
    private bool _isOpen;
    private float _time;
    private void Start()
    {
        _source = this.gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_isOpen)
        {
            _time += Time.deltaTime; ;
        }
        if (_time > 0.05)
        {
            this.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<PlayerOneBehavior>().HaveKey)
            {
                _source.PlayOneShot(openDoor, 1f);
                _isOpen = true;
            }
        }
    }
}
