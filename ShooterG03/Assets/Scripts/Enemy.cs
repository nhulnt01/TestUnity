using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float _moveSpeed = 0.4f;
    public float _shootCD = 3.5f;
    public GameObject _enemyBulletPref;

    private Rigidbody2D _rb;
    private float _shootTimer;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _shootTimer += Time.deltaTime;
        if(_shootTimer >= _shootCD)
        {
            _shootTimer = 0;
            Instantiate(_enemyBulletPref, transform.position, Quaternion.identity);
        }
    }
    void FixedUpdate()
    {
        Vector3 newPos = transform.position + Vector3.down * _moveSpeed * Time.deltaTime;
        _rb.MovePosition(newPos);
    }
    
}
