using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.VFX;

public class BaseCollectibleScript : MonoBehaviour
{
    Vector3 objectRotation;
    float newUpdateRate = 0.05f;
    int currencyValue = 1;

    [SerializeField] private AudioClip[] _eatClip;
    [SerializeField] private ParticleSystem _eatEffect;

    void Start()
    {
        ++C_Currency.CurrencyTotal;
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
            PlayParticle();
            SoundManager.Instance.PlaySound(_eatClip);
            GameObject currencyManager = GameObject.Find("Playing");
            currencyManager.GetComponent<C_Currency>().AddCurrency(currencyValue);
            Destroy(this.gameObject); 
        }
    }

    private void PlayParticle()
    {
        _eatEffect.Play();
    }
}

