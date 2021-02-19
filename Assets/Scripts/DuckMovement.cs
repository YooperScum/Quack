using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMovement : MonoBehaviour
{
    public float speed = 15f;
    public float turnSmoothTime = 0.1f;

    private float trunSmoothVelocity;

    private Transform cam;
    private Rigidbody body;
    private Vector3 direction;

    public Stack<GameObject> ducklingStack = new Stack<GameObject>();

    void Start()
    {
        cam = Camera.main.transform;
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        direction = new Vector3(horizontal, 0.0f, vertical).normalized;
    }

    private void FixedUpdate()
    {
        Vector3 moveDir = Vector3.zero;
        float yVelocity = body.velocity.y;

        if (direction.magnitude >= 0.1f)
        {
            // Rotation
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref trunSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Movemement
            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward * speed;
        }

        body.velocity = new Vector3(moveDir.x, yVelocity, moveDir.z);


    }
}
