using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float _moveSpeed = 10;
    private float _lifeTime = 5;
    private float _lifeTimer;
    private Player _player;

    public GameObject _destroyEffect;
    

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }
    private void Update()
    {
        _lifeTimer += Time.deltaTime;
        if(_lifeTimer >= _lifeTime )
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        transform.position += Vector3.up * _moveSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Instantiate(_destroyEffect, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            _player._score++;
        }
        if (collision.tag == "Meteorite")
        {
            Instantiate(_destroyEffect, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
        if (collision.tag == "EnemyBullet")
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
