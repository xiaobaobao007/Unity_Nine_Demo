using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdManger : MonoBehaviour
{
    private Animator _animator;
    private int x;
    private int y;
    private int type;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetInfo(int x, int y, int type)
    {
        this.x = x;
        this.y = y;
        this.type = type;
    }

    private void OnMouseUp()
    {
        GameManager.BirdClick(this);
    }

    public void ShakeStart()
    {
        _animator.SetBool("Shake", true);
    }

    public void ShakeStop()
    {
        _animator.SetBool("Shake", false);
    }

    public void Delete()
    {
        gameObject.SetActive(false);
    }
}