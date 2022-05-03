using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1f;
    public int damage = 30;
    public Rigidbody2D rb;
    Animator animator;

    string[] ignoredColliderNames = {"Player", "Coin(Clone)"};

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Coroutine for destroying the bullet and giving it a hit animation
    /// </summary>
    /// <param name="hitCollider"> The Collider2D the bullet hit </param>
    /// <returns></returns>
    IEnumerator DestroyBulletCo(Collider2D hitCollider)
    {
        animator.SetBool("isHit", true);
        if (hitCollider.name == "CollisionObjects" && transform.rotation == Quaternion.Euler(0, 0, 90))
            yield return new WaitForSeconds(0.05f);
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D hitCollider)
    {
        Enemy enemy = hitCollider.GetComponent<Enemy>();
        
        if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        if (!ignoredColliderNames.Contains(hitCollider.name))
            StartCoroutine(DestroyBulletCo(hitCollider));
    }
}
