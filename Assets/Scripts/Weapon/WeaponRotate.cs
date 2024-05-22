using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponRotate : MonoBehaviour
{
    [SerializeField ] [Min(0.1f)] private float _playerOffset;

    private Transform playerTransform;
    private Transform weaponTransform;
    private Transform modelTransform;
    private BoxCollider2D modelCollider;

    void Start()
    {
        weaponTransform = transform;
        playerTransform = weaponTransform.parent.transform;
        modelTransform = GetComponentInChildren<Transform>();
        modelCollider = modelTransform.GetComponent<BoxCollider2D>();
        SetStartPosition();
        SetModelPositionOffset();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RotateWeapon();
    }

    private void RotateWeapon()
    {
        Vector3 mouseWorldPosition = GetMouseWorldPosition();
        //от игрока к курсору
        Vector3 cursorVector = (mouseWorldPosition - playerTransform.position).normalized;

        RotateAroundPlayer(cursorVector);
    }

    private void RotateAroundPlayer(Vector3 cursorVector)
    {
        Vector3 weaponVector = (weaponTransform.position - playerTransform.position).normalized;
        Vector3 newPosition = playerTransform.position + weaponVector * _playerOffset;
        weaponTransform.position = newPosition;

        float angle = Mathf.Atan2(cursorVector.y, cursorVector.x) - Mathf.Atan2(weaponVector.y, weaponVector.x);
        angle *= Mathf.Rad2Deg;
        weaponTransform.RotateAround(playerTransform.position, Vector3.forward, angle);
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector2 mousePosition = Input.mousePosition;
        return Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.transform.position.z));
    }

    private void SetStartPosition()
    {
        Vector3 newPosition = playerTransform.position;
        newPosition.y += _playerOffset;
        weaponTransform.position = newPosition;
        weaponTransform.rotation = Quaternion.Euler(new Vector3());
    }

    private void SetModelPositionOffset()
    {

    }

    private void OnDrawGizmos()
    {
        if (playerTransform)//проверка только для того, что бы не выдавала ошибку при незапущенной игре
        {
            Gizmos.DrawLine(playerTransform.position, GetMouseWorldPosition());
        }
    }
}
