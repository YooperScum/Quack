using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTracker : MonoBehaviour
{
    [SerializeField] DuckMovement duck;
    private void OnCollisionEnter(Collision collision)
    {
        duck.inWater = true;
    }
}
