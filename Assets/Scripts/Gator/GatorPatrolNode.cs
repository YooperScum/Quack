using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatorPatrolNode : MonoBehaviour
{
    [SerializeField] GameObject nextNode = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<GatorBehavior>())
        {
            other.GetComponent<GatorBehavior>().patrolTarget = nextNode;
        }
    }
}
