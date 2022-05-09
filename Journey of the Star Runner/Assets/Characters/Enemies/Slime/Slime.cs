using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    Animator animator;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        animator = GetComponent<Animator>();
    }

    IEnumerator AnimateDamageCo()
    {
        animator.SetBool("isHit", true);
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("isHit", false);
    }

    void TakeDamageCustom()
    {
        StartCoroutine(AnimateDamageCo());
    }

   
}
