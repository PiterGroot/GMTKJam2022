using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldMine : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private float amount = 10;
    private bool canMine = true;
    private void Start()
    {
        anim = transform.GetChild(0).gameObject.GetComponent<Animator>();
        RandomInvoke();
    }
    private void RandomInvoke()
    {
        anim.SetTrigger("Mine");
        if (canMine)
        {
            Invoke("MineGold", Random.Range(4, 8));
        }
    }
    private void MineGold()
    {
        if (FindObjectOfType<WaveSystem>().isInWave)
        {
            FindObjectOfType<Wallet>().AddMoney(amount);
        }
        else
        {
            anim.SetTrigger("Down");
        }
        RandomInvoke();
    }
}
