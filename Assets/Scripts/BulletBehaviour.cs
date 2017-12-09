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
                print("Torreta destruida");
            } else if (other.tag == "Player") {
                print("llamar hit player");
                other.gameObject.GetComponent<PlayerBehaviour>().hit();
            }

            Destroy(this.gameObject);
        }
    }
}
