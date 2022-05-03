using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Quaternion firingRotation;

    public float fireDelay = 0.1f;
    bool isFireHeld = false;
    bool isShooting = false;

    Vector2 fireInput;
    PlayerController _playerController;
    PlayerControlls _playerControlls;
    private Coroutine fireCoroutine;

    private void Start()
    {
        _playerController = GetComponent<PlayerController>();

        _playerControlls = new PlayerControlls();
        _playerControlls.Controlls.Enable();
        _playerControlls.Controlls.Fire.performed += Fire_performed;
        _playerControlls.Controlls.Fire.canceled += Fire_canceled;
    }

    IEnumerator FireHoldCo()
    {
        while (isFireHeld)
        {
            isShooting = true;

            Instantiate(bulletPrefab, firePoint.position, firingRotation);
            yield return new WaitForSeconds(fireDelay);

            isShooting = false;
        }

    }

    private void Fire_performed(InputAction.CallbackContext obj)
    {
        isFireHeld = true;
        if (!isShooting)
            fireCoroutine = StartCoroutine(FireHoldCo());
    }
    private void Fire_canceled(InputAction.CallbackContext obj)
    {
        if (isFireHeld)
        {
            isFireHeld = false;
            // Anything to do upon cancelling the firing
        }
    }

    void OnLook(InputValue fireValue)
    {
        fireInput = fireValue.Get<Vector2>();
        firingRotation = Quaternion.FromToRotation(Vector2.right, fireInput);

        // Move FirePoint according to firing direction
        switch (_playerController.fireDirection)
        {
            case Enums.Direction.down:
                SetFirePointPositionRelToPlayer(-0.02f, -0.04f);
                break;
            case Enums.Direction.downright:
                SetFirePointPositionRelToPlayer(0.04f, -0.05f);
                break;
            case Enums.Direction.right:
                SetFirePointPositionRelToPlayer(0.075f, -0.01f);
                break;
            case Enums.Direction.upright:
                SetFirePointPositionRelToPlayer(0.07f, 0.03f);
                break;
            case Enums.Direction.up:
                SetFirePointPositionRelToPlayer(0.02f, 0.09f);
                break;
            case Enums.Direction.upleft:
                SetFirePointPositionRelToPlayer(-0.05f, 0.04f);
                break;
            case Enums.Direction.left:
                SetFirePointPositionRelToPlayer(-0.07f, -0.01f);
                break;
            case Enums.Direction.downleft:
                SetFirePointPositionRelToPlayer(-0.07f, -0.04f);
                break;
        }
    }

    void SetFirePointPositionRelToPlayer(float xOffset, float yOffset)
    {
        Vector3 playerPosition = firePoint.parent.position;
        firePoint.transform.SetPositionAndRotation(new Vector3(playerPosition.x + xOffset, playerPosition.y + yOffset, playerPosition.z), firePoint.parent.rotation);
    }


}
