using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealFlask : MonoBehaviour
{
    public int points;
    private Rigidbody2D _rigidbody;
    private GameObject _player;
    private PlayerController _playerController;
    Animator _animator;
    private float _destroyTimer = 10;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.AddForce(new Vector2(0, 500));
        _player = GameObject.Find("player");
        _playerController = _player.GetComponent<PlayerController>();
        _animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        _destroyTimer -= Time.deltaTime;
        if (_destroyTimer < 4) 
        {
            _animator.SetTrigger("destr");
            

        }
        if (_destroyTimer < 0)
        {
            Destroy(this.gameObject);
        }
       
    }

    private void OnMouseDown()
    {
        _playerController.HP = +points;
        Destroy(this.gameObject);

    }
}
