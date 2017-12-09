using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float acceleration = 1;
    public float turnAcceleration = 1;
    public GameObject bullet;
    public Rigidbody rb;

    private int lifes = 4;
    private int discoveredBases = 0;

    private void FixedUpdate() {
        Rigidbody rb = GetComponent<Rigidbody>();

        float forwardMovementRate = Input.GetAxis("Vertical");
        rb.AddForce(transform.forward * forwardMovementRate * acceleration);

        float rotationMovementRate = Input.GetAxis("Horizontal");
        rb.AddTorque(Vector3.up * rotationMovementRate * turnAcceleration);

        if (Input.GetKey(KeyCode.Space)) {
            shoot();
        }
    }

    private void shoot() {
        GameObject newBullet =  Instantiate(bullet);
        newBullet.tag = this.tag;
        newBullet.transform.position = transform.position;
        newBullet.GetComponent<BulletBehaviour>().serDirection(transform.forward);
    }

    public void hit() {

    }

}
