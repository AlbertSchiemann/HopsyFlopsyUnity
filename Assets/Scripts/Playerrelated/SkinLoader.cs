using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinLoader : MonoBehaviour
{
    //public static GameObject skinToLoad;
    [SerializeField] private GameObject defaultSkin;
    public GameObject currentSkin;

    private void Awake()
    {
        ChangeSkin(defaultSkin);
    }

    public void ChangeSkin(GameObject gameObject)
    {
        if (!(currentSkin == null)) { Destroy(currentSkin); }
        currentSkin = Instantiate(gameObject, transform);
    }


    public void AnimationTrigger ()
    {

        currentSkin.GetComponent<Animator>().SetTrigger("jump");
    }

}
