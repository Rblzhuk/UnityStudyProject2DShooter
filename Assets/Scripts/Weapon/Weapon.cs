using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    protected Weapon(int damage, float attackSpeed, float knockback, float range)
    {
        _damage = damage;
        _atackSpeed = attackSpeed;
        _knockback = knockback;
        _range = range;
    }

    private int _damage;
    private float _atackSpeed;
    private float _knockback;
    private float _range;

    public int Damage { get => _damage; set => _damage = value; }
    public float AtackSpeed { get => _atackSpeed; set => _atackSpeed = value; }
    public float Knockback { get => _knockback; set => _knockback = value; }
    public float Range { get => _range; set => _range = value; }

    protected void Attack() { }

}
