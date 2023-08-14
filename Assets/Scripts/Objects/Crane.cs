using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane : MonoBehaviour
{
    [SerializeField] private GameObject cranePrefab;
    // [SerializeField] private AudioClip[] _craneclip;         // cranesound

    public void CraneAnimation()
    {
        // SoundManager.Instance.PlaySound(Crane);
                    // Start of crane animation
        Invoke("Delay", 1.35f);
        Invoke("TurnOff", 3f);
        
        // cranePrefab.GetComponent<Animator>().SetBool("moving", true);

    }

    private void Delay()
    {
        cranePrefab.GetComponent<Animator>().enabled = true;
    }
    private void TurnOff()
    {
        cranePrefab.GetComponent<Animator>().enabled = false;
    }
}

