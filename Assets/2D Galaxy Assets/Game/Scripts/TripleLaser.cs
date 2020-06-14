using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleLaser : Laser {
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        base.Update ();
        if (transform.position.y >= 5.61f) {
            Destroy (this.gameObject);
        }
    }

}