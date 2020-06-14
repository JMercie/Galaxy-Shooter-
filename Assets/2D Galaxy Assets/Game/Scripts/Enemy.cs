using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2.0f;

    [SerializeField]
    private GameObject _explosion;

    void Start () {
      
    }

    // Update is called once per frame
    void Update () {

        transform.Translate (Vector3.down * Time.deltaTime * _speed);

        if (transform.position.y < -6.5f) {
            float _ramdonX = UnityEngine.Random.Range(-7.79f, 7.79f);
            transform.position = new Vector3 (_ramdonX, 6.37f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }

            // instanciate the explosion
            GameObject.Instantiate(_explosion, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);

            Destroy(this.gameObject);

        }
        else if (other.tag == "Proyectile")
        {
            if (other.transform.parent != null)
            {
                Destroy(other.transform.parent.gameObject);
            }
            Destroy(other.gameObject);

            // instanciate the explosion
            GameObject.Instantiate(_explosion, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);

            Destroy(this.gameObject);

            

        }
            
    }
        
}
