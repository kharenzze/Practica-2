using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {

    public float speed = 4;

    private Vector3 direction;

    public void setDirection (Vector3 dir) {
        direction = dir;
    }

    private void FixedUpdate() {
        transform.position = transform.position + direction * speed;
    }

    private void OnTriggerEnter(Collider other) {
        print("collision");

        if (other.tag != tag) {
            if (other.tag == "Turret") {
                Destroy(other.gameObject);
            } else if (other.tag == "Player") {
                other.gameObject.GetComponent<PlayerBehaviour>().hit(direction);
            }

            Destroy(this.gameObject);
        }
    }
}
