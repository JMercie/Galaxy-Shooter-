using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyShip;

    [SerializeField]
    private GameObject[] _powerUps;


    private GameManager _gameManager;

    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        setsCourutineForSpawn(); 
    }

    public void setsCourutineForSpawn()
    {
        StartCoroutine(enemySpawnCoroutine());
        StartCoroutine(powerUpSpawnCoroutine());
    }

    public IEnumerator enemySpawnCoroutine()
    { 
        while (_gameManager.gameOver == false)
        {
            Instantiate(_enemyShip, new Vector3(Random.Range(-7.79f, 7.79f), 6.37f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
        
    }
    public IEnumerator powerUpSpawnCoroutine()
    {
        while (_gameManager.gameOver == false)
        {
            Instantiate(_powerUps[Random.Range(0, 3)], new Vector3(Random.Range(-7.79f, 7.79f), 6.37f, 0), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(5.0f, 25.0f));

        }

    }
}
