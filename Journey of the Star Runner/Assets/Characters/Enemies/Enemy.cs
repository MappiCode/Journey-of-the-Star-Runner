using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected Transform player;

    protected Rigidbody2D rb;

    // Default-Values
    public int health = 50;
    public float speed = 0.2f;

    public GameObject[] drops = { };
    public float dropPropability = 0.5f;

    private GameManager gm;

    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gm = FindObjectOfType<GameManager>();
        gm.enemiesSpawned++;
    }

    void FixedUpdate()
    {
        // Movement
        Vector2 direction = new Vector2(player.position.x - rb.position.x, player.position.y - rb.position.y);
        direction.Normalize();
        rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * direction);
    }

    /// <summary>
    /// Lets the enemy take damage
    /// </summary>
    /// <param name="damageValue">The amount of damage to apply</param>
    public void TakeDamage(int damageValue)
    {
        // Call a custom TakeDamage function that is implemented in the specific enemy-type
        gameObject.SendMessage("TakeDamageCustom");
        
        health -= damageValue;

        if (health <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Destroys the Enemy
    /// </summary>
    void Die()
    {
        DropLoot();
        gm.enemiesKilled++;
        Destroy(gameObject);
    }

    /// <summary>
    /// Instantiates a random GamoObject from the drops Array
    /// </summary>
    void DropLoot()
    {
        if (dropPropability > Random.Range(0.0f, 1.0f))
        {
            GameObject droppedItem = drops[Random.Range(0, drops.Length)];
            Instantiate(droppedItem, gameObject.transform.position + Vector3.down * 0.02f, Quaternion.identity);
        }
    }
}
