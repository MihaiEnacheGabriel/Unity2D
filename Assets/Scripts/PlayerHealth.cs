using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float health = 0f;
    public GameOver logical;
    [SerializeField] private float maxHealth = 100f;
    void Start()
    {
        health = maxHealth;
       
    }

    public void UpdateHealth(float mod)
    {
        health += mod;
        logical.TakeDamage(health);
        if (health > maxHealth)
            health = maxHealth;
        else if(health <= 0f)
        {
            health = 0f;
            logical.gameOver();
            Debug.Log("Player Respawn");
        }
    }
}
