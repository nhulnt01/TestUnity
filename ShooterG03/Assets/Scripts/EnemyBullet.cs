using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float _moveSpeed = 9;
    private float _lifeTime = 5;
    private float _lifeTimer;

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
        transform.position += Vector3.down * _moveSpeed * Time.deltaTime;
    }

}
