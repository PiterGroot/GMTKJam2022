using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldMine : MonoBehaviour
{
    [SerializeField] private float amount = 10;
    private bool canMine = true;
    private void Start()
    {
        RandomInvoke();
    }
    private void RandomInvoke()
    {
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
        RandomInvoke();
    }
}
