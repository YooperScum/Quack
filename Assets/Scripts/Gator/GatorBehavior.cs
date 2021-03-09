using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatorBehavior : MonoBehaviour
{
    [SerializeField] List<Transform> patrolPoints = null;
    public GameObject patrolTarget = null;
    public GameObject duckTarget = null;
    public float speed = 5f;
    public float pursuitRange = 30f;
    public float turnRate = 10f;

    public float attentionSpan = 3f;
    public float attentionTimer;

    private bool duckSeen = false;

    void Update()
    {
        if (duckSeen && duckTarget != null)
        {
            TargetTracking(1);

            if (duckTarget.GetComponent<DuckMovement>().inWater)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(duckTarget.transform.position.x, 10, duckTarget.transform.position.z), 0.1f);
            }

            DuckCheck();
        }

        if (duckTarget == null && patrolTarget != null)
        {
            TargetTracking(2);
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, patrolTarget.transform.position, 0.1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.gameObject.GetComponent<DuckMovement>())
            { 
                duckTarget = other.gameObject;
                duckSeen = true;
                attentionTimer = attentionSpan;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && other.gameObject.GetComponent<DuckMovement>())
        {
            if (other.gameObject.GetComponent<DuckMovement>().inWater)
            {
                duckTarget = other.gameObject;
                duckSeen = true;
                attentionTimer = attentionSpan;
            }
        }
    }

    private void DuckCheck()
    {
        if (duckTarget.GetComponent<DuckMovement>().inWater == false || (duckTarget.transform.position - gameObject.transform.position).magnitude > pursuitRange)
        {
            attentionTimer -= Time.deltaTime;
            if (attentionTimer <= 0)
            {
                Debug.Log("Target Lost");
                duckTarget = null;
                duckSeen = false;
            }
        }
    }

    private void TargetTracking(int target)
    {
        Quaternion targetRotation = Quaternion.identity;

        switch (target)
        {
            case 1:
                targetRotation = Quaternion.LookRotation(duckTarget.transform.position - gameObject.transform.position);
                break;
            case 2:
                targetRotation = Quaternion.LookRotation(patrolTarget.transform.position - gameObject.transform.position);
                break;
        }

        gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, targetRotation, speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawWireSphere(gameObject.transform.position, pursuitRange);
    }
}
