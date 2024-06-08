using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public float _spawnCd = 2.5f;
    public GameObject _enemyPref;

    private float _spawnTimer;


    void Update()
    {
        _spawnTimer += Time.deltaTime;
        if ( _spawnTimer >= _spawnCd )
        {
            _spawnTimer = 0;
            Vector3 spawnPos = new Vector3(Random.Range(-8f,8f), 5.5f, 0);
            Instantiate(_enemyPref, spawnPos, Quaternion.Euler(0, 0, 90));
        }
    }

    
}
