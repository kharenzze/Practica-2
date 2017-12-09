using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    public GameObject target;
    public float minHeight = 4f;
    public float heightFactor = 1.5f;

    private float height;
    private Rigidbody targetRigidBody;

    private void Start() {
        targetRigidBody = target.GetComponent<Rigidbody>();
    }

    private void LateUpdate() {
        Vector3 targetPos = target.transform.position;
        transform.position = targetPos + Vector3.up * height;
        height = minHeight * ( 1 + targetRigidBody.velocity.magnitude / heightFactor);
    }
}
