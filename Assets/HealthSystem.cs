using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite dedheart;
    public float currentHealth = 3;
    
    public void RemoveHealth(int amount)
    {
        currentHealth -= amount;
        if (currentHealth == 2)
        {
            hearts[2].sprite = dedheart;
        }
        if (currentHealth == 1)
        {
            hearts[1].sprite = dedheart;
        }
        if (currentHealth <= 0)
        {
            hearts[0].sprite = dedheart;
            //die
            Invoke("Death", 1f);
        }
    }
    private void Death()
    {
        //die
        SceneManager.LoadScene("Lose");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RemoveHealth(1);
        }
    }
}
