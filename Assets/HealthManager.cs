using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


// Just a simple health manager to show how you can controll the HealthBar UI
public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public PointManager PM;
    

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage, Vector2 origin)
    {
        currentHealth -= damage;

        GetComponent<Rigidbody2D>().AddForce((GetComponent<Rigidbody2D>().position - origin).normalized * 100f, ForceMode2D.Force);

        if (currentHealth <= 0)
        {
            PM.scoreCount++;
            Destroy(gameObject);
           
        }

        healthBar.SetCurrentHealth(currentHealth);
    }
}