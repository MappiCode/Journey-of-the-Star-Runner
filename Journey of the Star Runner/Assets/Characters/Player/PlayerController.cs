using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Enums.Direction moveDirection;
    public Enums.Direction fireDirection;

    public float moveSpeed = 1f;
    public float minMoveValue = 0.2f;
    public float collisionOffsetNorth = 0.05f;
    public ContactFilter2D movementFilter;

    public Vector2 movementInput;
    public Vector2 fireInput;

    Rigidbody2D rb;
    Animator animator;

    public Inventory inventory;

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        inventory = GetComponent<Inventory>();
    }

    private void FixedUpdate()
    {
        // If movementInput is not 0, try to move
        if(movementInput != Vector2.zero)
        {
            bool success = TryMove(movementInput);

            if (!success)
            {
                success = TryMove(new Vector2(movementInput.x, 0));
            }
            if (!success)
            {
                success = TryMove(new Vector2(0, movementInput.y));
            }
            animator.SetBool("isMoving", success);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        animator.SetFloat("MovementX", movementInput.x);
        animator.SetFloat("MovementY", movementInput.y);

        // Setting animator parameters according to whether the player is shooting
        if (fireInput != Vector2.zero)
        {
            animator.SetBool("isFiring", true);
            animator.SetFloat("FireX", fireInput.x);
            animator.SetFloat("FireY", fireInput.y);
        }
        else
        {
            animator.SetBool("isFiring", false);
            animator.SetFloat("FireX", 0);
            animator.SetFloat("FireY", 0);
        }
 
        int[] backwardsDirections = {((int)moveDirection + 3) % 8, ((int)moveDirection + 4) % 8, ((int)moveDirection + 5) % 8};
        
        // if Movement and FiringDirection are Oposite, set animation Speed of the walkanimation to -1, to run it backwards
        if(backwardsDirections.Contains((int)fireDirection))
        {
            animator.SetFloat("SpeedMultiplier", -1f);
        }
        else
        {
            animator.SetFloat("SpeedMultiplier", 1f);
        }

    }

    /// <summary>
    /// Makes the player move, when there is nothing in the players path to collide with 
    /// </summary>
    /// <param name="direction"> The direction as Vector2 to try to move to</param>
    /// <returns> true = player moved, false = player can't move</returns>
    private bool TryMove(Vector2 direction)
    {
        //TODO: Make the check about controllerInput (minMoveValue) external for genereal purposes
        if (direction.x > minMoveValue || direction.x < -minMoveValue || direction.y > minMoveValue || direction.y < -minMoveValue)
        {
            float collisionOffset;
            if (moveDirection == Enums.Direction.up)
                collisionOffset = collisionOffsetNorth;
            else
                if (moveDirection == Enums.Direction.upleft || moveDirection == Enums.Direction.upright)
                    collisionOffset = collisionOffsetNorth * Mathf.Sqrt(2);
            else
                collisionOffset = 0;
            // Check for potential collisions
            int count = rb.Cast(
                direction,          // X and Y values between -1 and 1 that represent the dircetion from the body to look for collisions
                movementFilter,     // The Settings that determine where a collision can occur on such as layers to collide with
                castCollisions,     // List of collisions to store the found collisions into after the Cast is finished
                moveSpeed * Time.fixedDeltaTime + collisionOffset);     // The amount to cast equal to the movement plus an offset

            if (count == 0)
            {
                rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * direction);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            // Can't move if there is no direction to move in
            return false;
        }
    }


    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
        Enums.SetActionDirection(ref moveDirection, movementInput);
    }

    void OnLook(InputValue fireValue)
    {
        fireInput = fireValue.Get<Vector2>();
        Enums.SetActionDirection(ref fireDirection, fireInput);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            FindObjectOfType<GameManager>().PlayerDied();
        }
    }

}
