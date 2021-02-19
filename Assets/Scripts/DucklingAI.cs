using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DucklingAI : MonoBehaviour
{

    public GameObject targetDuckling;
    private Vector3 targetPosition;
    private bool isFound = false;
    public int steps = 1;

    private AudioSource sound;


    private float speed = 10.0f;

    public TVar<int> ducksCounter;

    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    void Update()
    {


    }
    void FixedUpdate()
    {
        if (isFound)
        {
            transform.LookAt(targetDuckling.transform);
            targetPosition = new Vector3(targetDuckling.transform.position.x, transform.position.y, targetDuckling.transform.position.z);
            float targetRad = targetDuckling.GetComponent<CapsuleCollider>().radius;
            float targetDistance = Vector3.Distance(targetPosition, transform.position);
            float length = targetDistance - (9.0f * targetRad);
            transform.Translate(transform.forward * length, Space.World);
        }
    }

    void OnCollisionEnter(Collision collisionInfo)
    {

        if (!isFound)
        {
            if (collisionInfo.collider.name == "Player")
            {
                print("Detected collision between " + gameObject.name + " and " + collisionInfo.collider.name);
                if (collisionInfo.gameObject.GetComponent<DuckMovement>().ducklingStack.Count == 0)
                {
                    targetDuckling = collisionInfo.gameObject;
                }
                else
                {
                    targetDuckling = collisionInfo.gameObject.GetComponent<DuckMovement>().ducklingStack.Peek();
                }
                isFound = true;
                collisionInfo.gameObject.GetComponent<DuckMovement>().ducklingStack.Push(gameObject);

                sound.Stop();
                ducksCounter.Value = ducksCounter.Value + 1;
            }
        }
    }

}
