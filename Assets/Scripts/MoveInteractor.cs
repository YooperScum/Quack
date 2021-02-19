using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInteractor : MonoBehaviour
{

    Vector3 moveDirection;
    float horizontal;
    float vertical;
    Rigidbody rb;
    [SerializeField]
    float moveSpeed;

    public Stack<GameObject> ducklingStack = new Stack<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = Vector3.zero;
        // get vertical and horizontal movement input (controller and WASD/ Arrow Keys)
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        Vector3 correctedVertical = vertical * Camera.main.transform.forward;
        Vector3 correctedHorizontal = horizontal * Camera.main.transform.right;

        Vector3 combinedInput = correctedHorizontal + correctedVertical;
        moveDirection = new Vector3((combinedInput).normalized.x, 0, (combinedInput).normalized.z);
    }

    private void FixedUpdate()
    {
        rb.velocity = (moveDirection * moveSpeed);
    }
}
