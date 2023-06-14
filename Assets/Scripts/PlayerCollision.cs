using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public float Delay = 1.0f; // Delay till scene reloads
    public UI_LevelScript levelScript;

    public float RayRange = 1;

    [HideInInspector] public Vector3 forwardRay = new Vector3(0, 1, 0);
    [HideInInspector] public Vector3 backwardRay = new Vector3(0, -1, 0);
    [HideInInspector] public Vector3 rightRay = new Vector3(-1, 0, 0);
    [HideInInspector] public Vector3 leftRay = new Vector3(1, 0, 0);

    public Ray rayCastForw;
    public Ray rayCastBackw;
    public Ray rayCastRight;
    public Ray rayCastLeft;

    public bool noMoveForward;
    public bool noMoveBackward;
    public bool noMoveRight;
    public bool noMoveLeft;

    [SerializeField] private AudioClip[] _failClip;
    void FixedUpdate()
    {
        CollisionCheck();
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

    public void CollisionCheck()
    {
        if(Physics.Raycast(rayCastForw, out RaycastHit hitF, RayRange))
        {
            if (hitF.collider.tag == "Obstacle")
            {
                noMoveForward = true;
            }
            Debug.DrawRay(transform.position, transform.TransformDirection(forwardRay * RayRange));
        }
        else
        {
            noMoveForward = false;
        }

        if(Physics.Raycast(rayCastBackw, out RaycastHit hitB, RayRange))
        {
            if (hitB.collider.tag == "Obstacle")
            {
                noMoveBackward = true;
            }
            Debug.DrawRay(transform.position, transform.TransformDirection(backwardRay * RayRange));
        }
        else
        {
            noMoveBackward = false;
        }

        if(Physics.Raycast(rayCastRight, out RaycastHit hitR, RayRange))
        {
            if (hitR.collider.tag == "Obstacle")
            {
                noMoveRight = true;
            }
            Debug.DrawRay(transform.position, transform.TransformDirection(rightRay * RayRange));
        }
        else
        {
            noMoveRight = false;
        }

        if(Physics.Raycast(rayCastLeft, out RaycastHit hitL, RayRange))
        {
            if (hitL.collider.tag == "Obstacle")
            {
                noMoveLeft = true;
            }
            Debug.DrawRay(transform.position, transform.TransformDirection(leftRay * RayRange));
        } 
        else
        {
            noMoveLeft = false;
        }  
    }
}
