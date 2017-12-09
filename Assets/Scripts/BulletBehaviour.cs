using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {

    public float speed = 4;

    private Vector3 direction;
    private static readonly float expireTime = 3;
    private float creationTime = 0;

    private void Start() {
        creationTime = Time.time;
    }

    public void setDirection (Vector3 dir) {
        direction = dir;
    }

    private void FixedUpdate() {
        transform.position = transform.position + direction * speed;
        checkExpiration();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag != tag) {
            if (other.tag == "Turret") {
                Destroy(other.gameObject);
            } else if (other.tag == "Player") {
                other.gameObject.GetComponent<PlayerBehaviour>().hit(direction);
            }

            Destroy(this.gameObject);
        }
    }

    private void checkExpiration() {
        if (Time.time > creationTime + expireTime ) {
            Destroy(gameObject);
        }
    }
}
