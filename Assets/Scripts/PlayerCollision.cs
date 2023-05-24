using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public float Delay = 1.0f; // Delay till scene reloads
    public UI_LevelScript levelScript;

    [SerializeField] private AudioClip[] _failClip;
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy von Player getroffen!");
        }

        if(other.gameObject.tag == "DeathZoneFreeFall")
        {
            Debug.Log("Free Fall Death");
            Invoke("Sceneload", Delay);
            SoundManager.Instance.PlaySound(_failClip);
        }
    }

    void Sceneload()
    {
        // restart the game if the player collides with the enemy
        levelScript.OpenLoose();  
          }
}
