using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrencyDisplayScript : MonoBehaviour
{
    [SerializeField] TMP_Text CurrencyText;
    public static int CurrencyAmount;
    public static int CurrencyTotal = 4;
    void Start()
    {
        CurrencyAmount = 0;
        CurrencyText.text = CurrencyAmount.ToString() + " / " + CurrencyTotal;
    }

    public void AddCurrency(int amount)
    {
        CurrencyAmount += amount;
        CurrencyText.text = CurrencyAmount.ToString() + " / " + CurrencyTotal;
        if (CurrencyAmount == CurrencyTotal)  { UI_LevelScript.WinCurrencyText = true; }
    }

    public void RemoveCurrency(int amount)
    {
        CurrencyAmount -= amount;
        CurrencyText.text = CurrencyAmount.ToString() + " / " + CurrencyTotal;
    }
}
