using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    public float acceleration = 1;
    public float turnAcceleration = 1;
    public GameObject bullet;
    public Rigidbody rb;
    public float shootRate;

    private int lifes = 3;
    private int discoveredBases = 0;
    private static readonly int totalBases = 4;
    private static readonly int maxLifes = 3;
    private float lastShot = 0;

    private void FixedUpdate() {
        float forwardMovementRate = Input.GetAxis("Vertical");
        rb.AddForce(transform.forward * forwardMovementRate * acceleration);

        float rotationMovementRate = Input.GetAxis("Horizontal");
        rb.AddTorque(Vector3.up * rotationMovementRate * turnAcceleration);

        if (Input.GetKey(KeyCode.Space) && canShoot()) {
            shoot();
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            resetPosition();
        }
    }

    private void shoot() {
        lastShot = Time.time;
        GameObject newBullet = Instantiate(bullet);
        newBullet.tag = this.tag;
        newBullet.transform.position = transform.position;
        newBullet.GetComponent<BulletBehaviour>().setDirection(transform.forward);
    }

    public void hit(Vector3 dir) {
        lifes--;
        rb.AddExplosionForce(500, transform.position - (dir.normalized * 0.1f), 1f);
        if (lifes == 0) {
            print("You lose");
            restart();
        }
    }

    public void baseFound() {
        discoveredBases++;
        lifes = maxLifes;
        if (discoveredBases == totalBases) {
            print("Congratulations! You've found all bases");
        }
    }

    private void resetPosition() {
        transform.position = Vector3.zero;
    }

    private void restart() {
        lifes = maxLifes;
        discoveredBases = 0;
        resetBases();
        resetPosition();
    }

    private bool canShoot() {
        return Time.time >= lastShot + shootRate;
    }

    private void resetBases() {
        GameObject[] bases = GameObject.FindGameObjectsWithTag("Base");
        foreach (GameObject b in bases) {
            print("rere");
            b.GetComponent<BaseBehaviour>().reset();
        }
    }
}
