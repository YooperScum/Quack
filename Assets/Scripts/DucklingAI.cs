using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DucklingAI : MonoBehaviour
{
    [SerializeField] Animator animator;

    public GameObject targetDuckling;
    private Vector3 targetPosition;
    private bool isFound = false;
    public int steps = 1;

    private AudioSource sound;
    private Rigidbody rb;

    private bool isMoving = false;
    private bool inWater = false;
    private float speed = 10.0f;

    public TVar<int> ducksCounter;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sound = GetComponent<AudioSource>();
    }

    void Update()
    {


    }
    void FixedUpdate()
    {
        animator.SetBool("InWater", inWater);
        animator.SetBool("IsMoving", isMoving);

        if (isFound)
        {
            transform.LookAt(targetDuckling.transform);
            targetPosition = new Vector3(targetDuckling.transform.position.x, transform.position.y, targetDuckling.transform.position.z);
            float targetRad = targetDuckling.GetComponent<CapsuleCollider>().radius;
            float targetDistance = Vector3.Distance(targetPosition, transform.position);
            float length = targetDistance - (9.0f * targetRad);
            transform.Translate(transform.forward * length, Space.World);

            if (length > 0.001f)
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }
        }

        WaterCheck();
    }

    private void WaterCheck()
    {
        Ray ray = new Ray(gameObject.transform.position, -Vector3.up);
        RaycastHit hit;
        //Raycast to determine if in water and changes inWater bool if so
        if (Physics.Raycast(ray, out hit, 3, 1 << 4))
        {
            inWater = true;
        }
        else
        {
            inWater = false;
        }
    }

    void OnCollisionEnter(Collision collisionInfo)
    {

        if (!isFound)
        {
            if (collisionInfo.collider.name == "Player")
            {
                rb.constraints = RigidbodyConstraints.FreezeRotation;
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

                sound.mute = true;
                ducksCounter.Value = ducksCounter.Value + 1;
            }
        }
    }

}
