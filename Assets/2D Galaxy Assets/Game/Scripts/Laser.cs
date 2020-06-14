using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    protected float _laserSpeed = 10.0f;
    void Start()
    {
    
    }

    protected virtual void Update()
    {
        transform.Translate(Vector3.up * _laserSpeed * Time.deltaTime);

        //if hit the top of the screen or hits an enemy. Destroy the laser
        if (transform.position.y >= 5.61f)
        {
            Destroy(this.gameObject);
        }

    }

    
}
