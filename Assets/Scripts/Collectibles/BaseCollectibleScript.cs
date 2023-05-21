using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollectibleScript : MonoBehaviour
{
    Vector3 objectRotation;
    float newUpdateRate = 0.05f;
    int currencyValue = 1;

    [SerializeField] private AudioClip[] _eatClip;

    void Start()
    {
        InvokeRepeating("SlowUpdate", 0.0f, newUpdateRate);
    }
    void SlowUpdate()
    {
        objectRotation = new Vector3(0, 5, 0) + transform.eulerAngles;
        transform.eulerAngles = objectRotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            SoundManager.Instance.PlaySound(_eatClip);
            GameObject currencyManager = GameObject.Find("CurrencyDisplay");
            currencyManager.GetComponent<CurrencyDisplayScript>().AddCurrency(currencyValue);
            Destroy(this.gameObject); 
        }
    }
}
