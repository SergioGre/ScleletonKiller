using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator _animator;
    SpriteRenderer _sprite;

    public int killPoint;

    public Transform atacPos;
    public LayerMask enemy;
    float range = 1.62f;
    int dmg = 5;
    public int HP;
    public int MaxHP = 10;
    public int combopoint;


    public bool Dead = false;

    void Start()
    {
        _animator = GetComponent<Animator>();
        atacPos.position = new Vector2(1.5f, atacPos.position.y);
        _sprite = GetComponent<SpriteRenderer>();
        HP = MaxHP;

    }


    void Update()
    {

        InputCntr();

        if (HP <= 0)
        {
            Death();
        }
    }

    public void AttacRight()
    {
     
            if (!_sprite.flipX)
            {
                if (combopoint >= 5)
                {
                    _animator.SetTrigger("SuperAttac");
                    combopoint = 0;
                }
                else
                {
                    _animator.SetTrigger("Attac");
                   
                }
            }

            else
            {
                _sprite.flipX = false;
                atacPos.position = new Vector2(1.5f, atacPos.position.y);
                AttacRight();
            }
    }

    public void AttacLift()
    {
        
            if (_sprite.flipX)
            {
                if (combopoint >= 5)
                {
                    _animator.SetTrigger("SuperAttac");
                    combopoint = 0;
                }
                else
                {
                    _animator.SetTrigger("Attac");
                }
            }

            else
            {
                _sprite.flipX = true;
                atacPos.position = new Vector2(-1.5f, atacPos.position.y);
                AttacLift();
            }
    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(atacPos.position, range);
    }
    public void OnAttac()
    {

        Collider2D[] enemies = Physics2D.OverlapCircleAll(atacPos.position, range, enemy);
        for (int j = 0; j < enemies.Length; j++)
        {
            enemies[j].GetComponent<EnemyScript>().TakeDamage(dmg);
        }
    }
    public void OnSuperAttac()
    {

        Collider2D[] enemies = Physics2D.OverlapCircleAll(atacPos.position, range + 1, enemy);
        for (int j = 0; j < enemies.Length; j++)
        {
            enemies[j].GetComponent<EnemyScript>().TakeDamage(dmg + 5);

        }
    }

    public void TakeDamage(int dmg)
    {
        HP -= dmg;
        combopoint = 0;
    }

    void Death()
    {
        Dead = true;
    }
    void InputCntr()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
           
            AttacRight();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
           
            AttacLift();
        }
    }

}
