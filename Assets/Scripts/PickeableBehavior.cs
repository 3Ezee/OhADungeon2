using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickeableBehavior : MonoBehaviour {

    public AudioClip soundClip;
    protected AudioSource _source;
    protected bool _isTaken;
    protected float _time;
    public float time;

    private void Start()
    {
        _source = this.gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_isTaken)
        {
            _time += Time.deltaTime;
        }
        if (_time > time)
        {
            this.gameObject.SetActive(false);
        }
    }

    protected void DeactivatedItem()
    {
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
}