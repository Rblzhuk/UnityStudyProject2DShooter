using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour,IEntity
{
    private PlayerMovement _movementComponent;
    public Entity _playerValues;

    private void Start()
    {
        _playerValues = new Entity(PlayerValuesSheet.Health,PlayerValuesSheet.Speed);

        _movementComponent = GetComponent<PlayerMovement>();
        _movementComponent.enabled = true;
    }
}
