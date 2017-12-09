using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBehaviour : MonoBehaviour {
    private bool hasBeenDetected = false;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player" && !hasBeenDetected) {
            _highlight();
            other.gameObject.GetComponent<PlayerBehaviour>().baseFound();
            hasBeenDetected = true;
        }
    }

    private void _highlight() {
        this.GetComponent<Renderer>().materials[1].SetColor("_EmissionColor", Color.green);
        this.GetComponent<Light>().enabled = true;
    }

    private void _disablehHighlight() {
        this.GetComponent<Renderer>().materials[1].SetColor("_EmissionColor", Color.red);
        this.GetComponent<Light>().enabled = false;
    }

    public void reset () {
        _disablehHighlight();
        hasBeenDetected = false;
    }
}
