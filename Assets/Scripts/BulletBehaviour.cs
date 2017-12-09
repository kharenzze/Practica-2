﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {

    public float speed = 4;

    private Vector3 direction;

    public void serDirection (Vector3 dir) {
        direction = dir;
    }

    private void FixedUpdate() {
        transform.position = transform.position + direction * speed;
    }

    private void OnTriggerEnter(Collider other) {

        if (other.tag != tag) {
            if (tag == "Turret") {
                print("Torreta destruida");
            } else if (other.tag == "Player") {
                print("llamar hit player");
                other.gameObject.GetComponent<Player>().hit();
            }

            Destroy(this.gameObject);
        }
    }
}
