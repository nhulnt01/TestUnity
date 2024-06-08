using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteController : MonoBehaviour
{
    // Start is called before the first frame update
    public float _speed = 0.3f;
    private Rigidbody2D _rb;

    private float _spawnTimer;


    // Update is called once per frame
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector3 newPos = transform.position + Vector3.down * _speed * Time.deltaTime;
        _rb.MovePosition(newPos);
    }
}
