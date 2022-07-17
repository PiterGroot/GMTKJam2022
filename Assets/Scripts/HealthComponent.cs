using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{
    private GameManager gameManager;
    public UnityEvent onDie = new UnityEvent();
    [SerializeField]private float currentHealth;
    [SerializeField] private float maxHealth;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        currentHealth = maxHealth;
    }

    public void AddHealth(float amount)
    {
        currentHealth += amount;
    }
    public void RemoveHealth(float amount, bool melee = false)
    {
        GameObject bleedEffect = Instantiate(gameManager.bleedParticleEffect, transform.position, Quaternion.identity);
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            if (melee) FindObjectOfType<Wallet>().AddMoney(10);
            else FindObjectOfType<Wallet>().AddMoney(1);
            FindObjectOfType<WaveSystem>().enemies.Remove(gameObject);
            onDie?.Invoke();
        }
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
