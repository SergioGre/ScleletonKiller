using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int dmg = 2;
    public int HP = 10;
    Animator animator;
    SpriteRenderer _sprite;
    Transform _transform;
    GameObject player;
    public float speed;
    PlayerController playerController;
   
    public GameObject loot;
    
    void Start()
    {
        player = GameObject.Find("player");
        animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        _transform = GetComponent<Transform>();
        playerController = player.GetComponent<PlayerController>();
        
    }

    
    void Update()
    {
        if (!playerController.Dead)
        {
            Check();
            Going();
            Attac();
        }
    }

    public void Check()
    {
        if (HP < 1)
        {
            animator.SetTrigger("Dead");
            
        }
    }

    public void TakeDamage(int dmg)
    {
        StartCoroutine(Damage());
        HP -= dmg;
        ++playerController.combopoint;
        if (transform.position.x > player.transform.position.x)
        {
            _transform.position = new Vector2(_transform.position.x + 2f, transform.position.y);
        }
        else
        {
            _transform.position = new Vector2(_transform.position.x - 2f, transform.position.y);
        }
    }
    public void ImDead()
    {
        playerController.killPoint += 1;
        Loot();
        Destroy(this.gameObject);
    }
    IEnumerator Damage()
    {
       
        _sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        _sprite.color = Color.white;
    }    

    void Going()
    {
        if(transform.position.x < player.transform.position.x)
        {
            _sprite.flipX = true;
            _transform.position = Vector2.MoveTowards(_transform.position, new Vector2(player.transform.position.x - 1.5f, player.transform.position.y), speed * Time.deltaTime);
        }
        else
        {
            _transform.position = Vector2.MoveTowards(_transform.position, new Vector2(player.transform.position.x + 1.5f, player.transform.position.y), speed * Time.deltaTime);
        }
        
    }    
    void Attac()
    {
        if ((transform.position.x >= player.transform.position.x - 1.5 && transform.position.x <player.transform.position.x) || (transform.position.x <= player.transform.position.x + 1.5 && transform.position.x > player.transform.position.x))
        {
            animator.SetTrigger("Attac");
        }
    }
    public void ImAttac()
    {
        playerController.TakeDamage(dmg);
        
    }

    void Loot()
    {
        int rnd;
        rnd = Random.Range(0, 10);
        if (rnd > 8)
        {
            GameObject healFlask = Instantiate(loot);
            healFlask.transform.position = this.transform.position;
        }
    }
}
