using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wallet : MonoBehaviour
{
    private float currentMoney;
    [SerializeField] private Text moneyText;
    public void AddMoney(float amount)
    {
        currentMoney += amount;
        UpdateUI();
    }
    public void RemoveMoney(float amount)
    {
        currentMoney -= amount;
        if (currentMoney < 0) currentMoney = 0;
        UpdateUI();
    }

    private void UpdateUI()
    {
        moneyText.text = currentMoney.ToString();
    }
}
