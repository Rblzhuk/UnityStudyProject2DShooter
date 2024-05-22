using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string Idle = nameof(Idle);
    private const string WalkUp = nameof(WalkUp);
    private const string WalkDown = nameof(WalkDown);
    private const string WalkRight = nameof(WalkRight);
    private const string WalkLeft = nameof(WalkLeft);

    private Player player;
    private Rigidbody2D rigidbody2d;
    private Animator animator;

    private float _vertInput;
    private float _horInput;


    private void Start()
    {
        player = GetComponent<Player>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _vertInput = Input.GetAxisRaw("Vertical");
        _horInput = Input.GetAxisRaw("Horizontal");

        float verdDirection = _vertInput * player._playerValues.Speed * Time.fixedDeltaTime;
        float horDirection = _horInput * player._playerValues.Speed * Time.fixedDeltaTime;

        rigidbody2d.velocity = new Vector2(horDirection, verdDirection);
        Animate(_horInput,_vertInput);
    }

    private void Animate(float horInput, float vertInput)
    {
        if (horInput == 0 && vertInput == 0)
        {
            animator.SetTrigger(Idle);
        }
        else
        {
            if (horInput == 0)
            {
                animator.SetTrigger((vertInput > 0 ? WalkUp : WalkDown));
            }
            else
            {
                animator.SetTrigger((horInput > 0 ? WalkRight : WalkLeft));
            }
        }
    }
}
