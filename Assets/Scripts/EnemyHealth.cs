using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    bool isDead = false;
    private CapsuleCollider capsuleCollider;
    private Score score;


    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return;
        isDead = true;
        GetComponent<Animator>().SetTrigger("die");
        capsuleCollider = GetComponent<CapsuleCollider>();
        
        if (capsuleCollider != null && capsuleCollider.enabled)
        {
            capsuleCollider.enabled = !capsuleCollider.enabled;
        }
        score = GameObject.FindGameObjectWithTag("Player").GetComponent<Score>();
        score.AddOne();

    }
}
