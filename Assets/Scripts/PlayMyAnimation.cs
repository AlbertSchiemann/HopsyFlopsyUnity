using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMyAnimation : MonoBehaviour
{
    [SerializeField] private Animator myAnimationController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myAnimationController.SetBool("play_crane_animation", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myAnimationController.SetBool("play_crane_animation", false);
        }
    }
}
