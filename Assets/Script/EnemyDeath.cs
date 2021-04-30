using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();  
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Death();
        }
    }
    private void Death()
    {
        anim.SetBool("IsDead", true);
    }
}
