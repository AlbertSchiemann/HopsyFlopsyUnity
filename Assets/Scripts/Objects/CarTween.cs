using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;



public class CarTween : MonoBehaviour
{
    public static float generalHeigth = -8.5f;

    //CarSelect0
    private Vector3 StartingPosition    = new(34f,generalHeigth,63f);
    private Vector3 CornerPosition      = new(0f,0f,37f);
    private Vector3 OutOfWorldPosition  = new(43f,0f,0f);

    private Vector3 StartingRotation    = new(0f,0f,90f);
    private Vector3 CornerRotation      = new(0f,90f,90f);

    //CarSelect1
    private Vector3 StartingPosition1    = new(-14f,generalHeigth,100f);
    private Vector3 CornerPosition1      = new(43f,0f,0f);
    private Vector3 OutOfWorldPosition1  = new(0f,0f,-37f);

    private Vector3 StartingRotation1    = new(0f,90f,90f);
    private Vector3 CornerRotation1      = new(0f,180f,90f);

    //CarSelect2
    private Vector3 StartingPosition2    = new( 77f,generalHeigth,103f);
    private Vector3 OutOfWorldPosition2  = new(-14f,generalHeigth,103f);

    private Vector3 StartingRotation2    = new(0f,-90f,90f);

    private float TweenTime = 6f;
    public float IndividualCarDelay = 0f;


    public int CarSelect;

    

    private void FirstItteration ()
    {
        switch (CarSelect)
        {
            case 0: 
            {
                transform.DOMove(StartingPosition, 0f).SetDelay(0f + IndividualCarDelay);
                transform.DORotate(StartingRotation, 0f).SetDelay(0f + IndividualCarDelay);

                transform.DOMove(CornerPosition, 3f).SetDelay(0f + IndividualCarDelay).SetEase(Ease.InOutSine);
                transform.DORotate(CornerRotation, .1f).SetDelay(2.9f + IndividualCarDelay);

                transform.DOMove(OutOfWorldPosition, 3f).SetDelay(3f + IndividualCarDelay).SetEase(Ease.InOutSine);

                Invoke("Repeat", TweenTime + IndividualCarDelay);

            } break;

            case 1: 
            {
                transform.DOMove(StartingPosition1, 0f).SetDelay(0f + IndividualCarDelay);
                transform.DORotate(StartingRotation1, 0f).SetDelay(0f + IndividualCarDelay);

                transform.DOMove(CornerPosition1, 3f).SetDelay(0f + IndividualCarDelay).SetEase(Ease.InOutSine);
                transform.DORotate(CornerRotation1, .1f).SetDelay(2.9f + IndividualCarDelay);

                transform.DOMove(OutOfWorldPosition1, 3f).SetDelay(3f + IndividualCarDelay).SetEase(Ease.InOutSine);

                Invoke("Repeat", TweenTime + IndividualCarDelay);

            } break;

            case 2: 
            {
                transform.DOMove(StartingPosition2, 0f).SetDelay(0f + IndividualCarDelay);
                transform.DORotate(StartingRotation2, 0f).SetDelay(0f + IndividualCarDelay);

                transform.DOMove(OutOfWorldPosition2, 6f).SetDelay(0f + IndividualCarDelay).SetEase(Ease.InOutSine);

                Invoke("Repeat", TweenTime + IndividualCarDelay);

            } break;
        }
    }
    

    void Start()
    {
        CornerPosition = CornerPosition + StartingPosition;
        OutOfWorldPosition = OutOfWorldPosition + CornerPosition;
        CornerPosition1 = CornerPosition1 + StartingPosition1;
        OutOfWorldPosition1 = OutOfWorldPosition1 + CornerPosition1;

        FirstItteration();
    }
    private void Repeat()
    {
        switch (CarSelect)
        {
            case 0: 
            {
                transform.DOMove(StartingPosition, 0f);
                transform.DORotate(StartingRotation, 0f);

                transform.DOMove(CornerPosition, 3f).SetDelay(0f).SetEase(Ease.InOutSine);
                transform.DORotate(CornerRotation, .1f).SetDelay(2.9f);

                transform.DOMove(OutOfWorldPosition, 3f).SetDelay(3f).SetEase(Ease.InOutSine);

                Invoke("Repeat", TweenTime);

            } break;

            case 1: 
            {
                transform.DOMove(StartingPosition1, 0f);
                transform.DORotate(StartingRotation1, 0f);

                transform.DOMove(CornerPosition1, 3f).SetDelay(0f).SetEase(Ease.InOutSine);
                transform.DORotate(CornerRotation1, .1f).SetDelay(2.9f);

                transform.DOMove(OutOfWorldPosition1, 3f).SetDelay(3f).SetEase(Ease.InOutSine);

                Invoke("Repeat", TweenTime);

            } break;

            case 2: 
            {
                transform.DOMove(StartingPosition2, 0f);
                transform.DORotate(StartingRotation2, 0f);

                transform.DOMove(OutOfWorldPosition2, 6f).SetDelay(0f).SetEase(Ease.InOutSine);

                Invoke("Repeat", TweenTime);

            } break;
        }
    }
}
