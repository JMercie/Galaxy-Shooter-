using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    // Start is called before the first frame update

    [SerializeField]
    private float _speed = 10.0f;

    public int lives = 3;

    [SerializeField]
    private GameObject _playerExplosion;

    [SerializeField]
    private GameObject _laser;

    [SerializeField]
    private GameObject _tripleLaser;

    [SerializeField]
    private GameObject _shield;

    public float fireDelta = 0.2F;
    private float _nextFire = 0.2F;
    private float _myTime = 0.0F;

    public bool canTripleshot = false;
    public bool haveSpeedBoost = false;

    public bool shieldsUp = false;
    void Start () {
        transform.position = new Vector3 (0, 0, 0);
    }

    // Update is called once per frame
    void Update () {

        playerMovement ();

        // control the shooting cooldown
        _myTime += Time.deltaTime;

        if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0) && _myTime > _nextFire) {
            shoot ();
        }
    }

    private void shoot () {

        if (canTripleshot) {
            Instantiate (_tripleLaser, transform.position, transform.rotation);
        } else {
            Instantiate (_laser, transform.position + new Vector3 (0, 1.28f, 0), transform.rotation);
        }
        // cooldown
        _nextFire = _myTime + fireDelta;
        _nextFire = _nextFire - _myTime;
        _myTime = 0.0F;

    }

    private void playerMovement () {

        // user input for movement

        if (haveSpeedBoost) {
            _speed = 13.2f;
        } else {
            _speed = 10.0f;
        }

        float translation = Input.GetAxis ("Vertical") * _speed;
        float rotation = Input.GetAxis ("Horizontal") * _speed;

        // Make it move 15 meters per second instead of 15 meters per frame...
        translation *= Time.deltaTime * 5;
        rotation *= Time.deltaTime * 5;

        transform.Translate (new Vector3 (1, 0, 0) * _speed * rotation * Time.deltaTime);
        transform.Translate (new Vector3 (0, 1, 0) * _speed * translation * Time.deltaTime);

        //keep it of the top and bottom borders 
        if (transform.position.y > 4.04f) {
            transform.position = new Vector3 (transform.position.x, 4.04f, 0);
        } else if (transform.position.y < -4.2f) {
            transform.position = new Vector3 (transform.position.x, -4.2f, 0);
        }

        // keep it out of the right and left borders
        if (transform.position.x > 8.17f) {
            transform.position = new Vector3 (8.17f, transform.position.y, 0);
        } else if (transform.position.x < -8.17f) {
            transform.position = new Vector3 (-8.17f, transform.position.y, 0);
        }

    }

    public void Damage () {

        if (shieldsUp)
        {
            _shield.SetActive(false);
            shieldsUp = false;
            return;
        }
        lives--; 
        
        if (lives < 1)
        {
            GameObject.Instantiate(_playerExplosion, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    // triple shoot cd
    public void setsCourutineForTripleShotOn () {
        canTripleshot = true;
        StartCoroutine (TripleShotPowerDownCoroutine ());
    }

    public IEnumerator TripleShotPowerDownCoroutine () {

        yield return new WaitForSeconds (7.0f);

        canTripleshot = false;
    }

    // speed boost cd
    public void setsCourutineForSpeedBoostOn () {
        haveSpeedBoost = true;
        StartCoroutine (SpeedBoostDownCoroutine ());
    }

    public IEnumerator SpeedBoostDownCoroutine () {

        yield return new WaitForSeconds (7.0f);

        haveSpeedBoost = false;
    }

    //enable shields
    public void ShieldOn()
    {
        shieldsUp = true;
        _shield.SetActive(true);
    }

}