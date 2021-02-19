using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{

    [SerializeField]
    private float _Speed = 5f;

    private Rigidbody _RB;

    // Start is called before the first frame update
    void Start()
    {
        _RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        _RB.AddForce(movement * _Speed);
    }
}
