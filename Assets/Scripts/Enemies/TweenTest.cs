using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenTest : MonoBehaviour
{

    public Transform target;
    public float duration;


    void Start()
    {
        target.DOMoveX(1f, duration);
    }


}
