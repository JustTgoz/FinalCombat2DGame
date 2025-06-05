using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    public Transform attackOrigin;
    public float attackX = 1f;
    public float attackY = 1f;
    public LayerMask enemyMask;
    private Vector2 center = new Vector2(0, 0);
    private Vector2 size;
    private float angle = 0f;


    public float cooldownTime = .5f;
    private float cooldownTimer = 0f;

    public int attackDamage = 25;

    public Animator animator;

    private void Update()
    {
        if (cooldownTimer <= 0)
        {
            if (Input.GetKey(KeyCode.C))
            {
                // Example of playing attack animation
                animator.SetTrigger("Melee");

                size = new Vector2(attackX, attackY);

                Collider2D[] enemiesInRange = Physics2D.OverlapBoxAll(attackOrigin.position, size, angle,  enemyMask);
                foreach (var enemy in enemiesInRange)
                {
                    enemy.GetComponent<HealthManager>().TakeDamage(attackDamage, transform.position);
                }

                cooldownTimer = cooldownTime;
            }
        }
        else
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(attackOrigin.position, new Vector3(attackX, attackY, 0));
    }
}