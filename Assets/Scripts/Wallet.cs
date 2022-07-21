using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wallet : MonoBehaviour
{
    public bool GODMODE;
    private float currentMoney;
    [SerializeField] private float godModeMoney = 100;
    [SerializeField] private Text moneyText;

    private void Awake()
    {
        if (GODMODE) AddMoney(godModeMoney);
    }
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
    public float GetMoney()
    {
        return currentMoney;
    }
    private void UpdateUI()
    {
        moneyText.text = currentMoney.ToString();
    }
}
