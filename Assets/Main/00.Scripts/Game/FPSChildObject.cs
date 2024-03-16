using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSChildObject : MonoBehaviour
{
    [SerializeField]
    HitType hitType;

    public HitType GetHitType()
    {
        return hitType;
    }
}
