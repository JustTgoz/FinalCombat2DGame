using UnityEngine;
using System.Collections;

// Just a simple health manager to show how you can controll the HealthBar UI
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject gameOverUI;
    public Animator animator; 

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage, Vector2 origin)
    {
        currentHealth -= damage;
        animator.SetTrigger("Damage");

        GetComponent<Rigidbody2D>().AddForce((GetComponent<Rigidbody2D>().position - origin).normalized * 50f, ForceMode2D.Force);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);

            gameOverUI.SetActive(true);
        }

        healthBar.SetCurrentHealth(currentHealth);

    }
}