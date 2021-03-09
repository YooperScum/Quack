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
            if (gameObject == other.GetComponent<GatorBehavior>().patrolTarget)
            {
                Debug.Log("Yes");
                other.gameObject.GetComponent<GatorBehavior>().patrolTarget = nextNode;
            }
        }
    }
}
