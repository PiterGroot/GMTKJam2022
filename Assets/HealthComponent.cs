using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{
    public UnityEvent onDie = new UnityEvent();
    [SerializeField]private float currentHealth;
    [SerializeField] private float maxHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void AddHealth(float amount)
    {
        currentHealth += amount;
    }
    public void RemoveHealth(float amount)
    {
        currentHealth -= amount;
        if(currentHealth < 0)
        {
            onDie?.Invoke();
        }
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
