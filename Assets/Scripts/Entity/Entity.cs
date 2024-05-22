using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity
{
    public Entity(int health,float speed){
        _health = health;
        _speed = speed;
    }

    private int _health;
    private float _speed;

    public int Health
    {
        get { return _health; }
        set
        {
            if (value < 0)
            {
                value = 0;
            }
            if (_health != value)
            {
                _health = value;
            }
        }
    }
    public float Speed
    {
        get { return _speed; }
        set {
            if (_speed != value)
            {
                _speed = value;
            }
        }
    }

    protected void TakeDamage(int damage)
    {
        Health -= Math.Abs(damage);
    }
}
