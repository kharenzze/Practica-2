using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour {

    public GameObject pylon;
    public GameObject target;
    public GameObject bulletTemplate;
    public float shootRange;
    public float shootRate;

    private float lastShot = 0;

    private void Update() {
        pylon.transform.LookAt(target.transform);
        Vector3 dir2Target = target.transform.position - transform.position;
        if (isInRange(dir2Target.magnitude) && canShoot()) {
            shoot(dir2Target);
        }
    }

    private void shoot (Vector3 dir) {
        lastShot = Time.time;
        GameObject bullet = Instantiate(bulletTemplate);
        bullet.tag = this.tag;
        bullet.transform.position = transform.position;
        bullet.GetComponent<BulletBehaviour>().setDirection(dir.normalized);
    }

    private bool canShoot() {
        return Time.time >= lastShot + shootRate;
    }

    private bool isInRange(float distance) {
        return distance < shootRange;
    }

}
