using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrencyDisplayScript : MonoBehaviour
{
    [SerializeField] TMP_Text CurrencyText;
    public static int CurrencyAmount;
    void Start()
    {
        CurrencyAmount = 10;
        CurrencyText.text = CurrencyAmount.ToString();
    }

    public void AddCurrency(int amount)
    {
        CurrencyAmount += amount;
        CurrencyText.text = CurrencyAmount.ToString();
    }

    public void RemoveCurrency(int amount)
    {
        CurrencyAmount -= amount;
        CurrencyText.text = CurrencyAmount.ToString();
    }
}
