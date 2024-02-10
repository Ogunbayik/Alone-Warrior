using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] private int maxHealth;

    private int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            HealthReduction(10);
        else if (Input.GetKeyDown(KeyCode.E))
            HealthIncrease(10);
    }

    private void HealthIncrease(int health)
    {
        if (currentHealth < maxHealth)
            currentHealth += health;
        else
            currentHealth = maxHealth;
    }

    private void HealthReduction(int health)
    {
        if (currentHealth > 0)
            currentHealth -= health;
        else
            Debug.Log("Player is Dead");
    }

}
