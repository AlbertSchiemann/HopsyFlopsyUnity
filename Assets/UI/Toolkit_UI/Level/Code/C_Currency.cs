using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class C_Currency : MonoBehaviour
{
    Label txtCurrency; 
    static int CurrencyAmount = 0;
    public static int CurrencyTotal = 4; // bessser wenn man automatisch durchzählen lassen könnte in der hierachy
    void OnEnable()
    {
        VisualElement rootSettings = GetComponent<UIDocument>().rootVisualElement;
        txtCurrency = rootSettings.Q<Label>("txt_currency");
        txtCurrency.text = CurrencyAmount.ToString() + " / " + CurrencyTotal.ToString();
    }

    public void AddCurrency(int amount)
    {
        CurrencyAmount += amount;
        txtCurrency.text = CurrencyAmount.ToString() + " / " + CurrencyTotal.ToString(); 
        if (CurrencyAmount == CurrencyTotal) { C_Win.allCollected = true; }
    }

    public void RemoveCurrency(int amount)
    {
        CurrencyAmount -= amount;
        txtCurrency.text = CurrencyAmount.ToString() + " / " + CurrencyTotal.ToString();
    }
}
