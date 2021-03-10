using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMovement : MonoBehaviour
{
    [SerializeField] Animator animator;

    public float speed = 15f;
    public float turnSmoothTime = 0.1f;

    private float turnSmoothVelocity;

    public bool inWater = false;

    private Transform cam;
    private Rigidbody body;
    private Vector3 direction;
    private bool isMoving = false;

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
        if (body.velocity.magnitude > 0.001f)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        animator.SetBool("InWater", inWater);
        animator.SetBool("IsMoving", isMoving);

        Vector3 moveDir = Vector3.zero;
        float yVelocity = body.velocity.y;

        if (direction.magnitude >= 0.1f)
        {
            // Rotation
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Movemement
            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward * speed;
        }

        body.velocity = new Vector3(moveDir.x, yVelocity, moveDir.z);
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

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(gameObject.transform.position, (gameObject.transform.position - (Vector3.up * 2)));
    }
}
