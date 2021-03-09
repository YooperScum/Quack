using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    [SerializeField] BoolVar isPaused;
    [SerializeField] GameObject follow;

    private float xRot;
    private float yRot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused.Value == false)
        {
            transform.position = new Vector3(follow.transform.position.x, this.transform.position.y, follow.transform.position.z);

            xRot += Input.GetAxis("CameraY");
            yRot += Input.GetAxis("CameraX");

            xRot = Mathf.Clamp(xRot, -45f, 45f);

            transform.rotation = Quaternion.Euler(xRot, yRot, 0.0f);
        }
    }
}
