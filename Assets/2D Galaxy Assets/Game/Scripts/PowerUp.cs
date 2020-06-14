using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    [SerializeField]
    private float _speed = 3.0f;

    [SerializeField]
    private int _powerUpId; // 0 = tripleShot ; 1 = speedboost; 2 = shield

    // Update is called once per frame
    void Update () {
        transform.Translate (Vector3.down * Time.deltaTime * _speed);

        if (transform.position.y <= -5.24f) {
            Destroy (this.gameObject);
        }
    }

    private void OnTriggerEnter2D (Collider2D other) {

        if (other.tag == "Player") {
            Player player = other.GetComponent<Player> ();

            if (player != null) {

                if (_powerUpId == 0) {
                    // enable tripler shoot
                    player.setsCourutineForTripleShotOn ();
                } else if (_powerUpId == 1) {
                    // enable speed boost
                    player.setsCourutineForSpeedBoostOn ();
                } else if (_powerUpId == 2) {
                    Debug.Log("choco");
                    player.ShieldOn();
                }

            }

            Destroy (this.gameObject);
        }
    }
}