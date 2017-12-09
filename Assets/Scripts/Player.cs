using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float acceleration = 1;
    public float turnAcceleration = 1;

    private void FixedUpdate() {
        Rigidbody rb = GetComponent<Rigidbody>();

        float forwardMovementRate = Input.GetAxis("Vertical");
        rb.AddForce(transform.forward * forwardMovementRate * acceleration);

        float rotationMovementRate = Input.GetAxis("Horizontal");
        rb.AddTorque(Vector3.up * rotationMovementRate * turnAcceleration);

    }

}
