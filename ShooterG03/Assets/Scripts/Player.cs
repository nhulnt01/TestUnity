using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float _moveSpeed = 5;
    public GameObject _playerBullet;
    public GameObject _hitEffect;
    public GameObject _destroyEffect;
    public UIManager _uiManager;
    public int _score;

    public float min_x, max_x;
    public float min_y, max_y;

    private Rigidbody2D _rb;
    private int _hp = 3;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _uiManager = FindObjectOfType<UIManager>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 spawnPos = transform.position + Vector3.up * 0.5f;
            Instantiate(_playerBullet, spawnPos, Quaternion.Euler(0, 0, 180));
        }
        _uiManager.SetScore(_score);
    }

    void FixedUpdate()
    {
        float horInput = Input.GetAxisRaw("Horizontal");
        float verInput = Input.GetAxisRaw("Vertical");

        Vector3 moveInput = new Vector3(horInput, verInput, 0);

        Vector3 newPos = transform.position + moveInput * Time.deltaTime * _moveSpeed;

        //limited the position
        newPos.x = Mathf.Clamp(newPos.x, min_x, max_x);
        newPos.y = Mathf.Clamp(newPos.y, min_y, max_y);

        _rb.MovePosition(newPos);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy") { 
            Destroy(collision.gameObject);
            ReceiveDmg();         
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            ReceiveDmg();
        }
        if (collision.tag == "EnemyBullet")
        {
            if (_hp > 1)
            {
                Instantiate(_hitEffect, collision.transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(_destroyEffect, collision.transform.position, Quaternion.identity);
            }
            
            Destroy(collision.gameObject);
            ReceiveDmg();
        }
    }
    private void ReceiveDmg()
    {
        _hp--;
        _uiManager.SetHp(_hp);
        if (_hp == 0)
        {
                Destroy(gameObject);
            _uiManager.ShowLoseScreen(_score);
        }
        // show score
    }
}
