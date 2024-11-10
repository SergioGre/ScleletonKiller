using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    float activTimerLeft;
    float startTimerMin = 2;
    float activTimerRight;
    float startTimerMax = 7;
    public GameObject enemyPref;

    PlayerController player;
    

    void Start()
    {
        player = FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
    }

    
    void Update()
    {
        if (player.Dead == false)
        {
            Hard();
            Timer();
            if (activTimerLeft <= 0)
            {
                LeftSpawn();
            }
            if (activTimerRight <= 0)
            {
                RightSpawn();
            }
        }
    }

    void Timer()
    {
        activTimerLeft -= Time.deltaTime;
        activTimerRight -= Time.deltaTime;
    }    

    void RightSpawn()
    {
        GameObject Enemy = Instantiate(enemyPref);
        Enemy.transform.position = new Vector2(11, -1);
        activTimerRight = Random.Range(startTimerMin, startTimerMax);

    }
    void LeftSpawn()
    {
        GameObject Enemy = Instantiate(enemyPref);
        Enemy.transform.position = new Vector2(-11, -1);
        activTimerLeft = Random.Range(startTimerMin, startTimerMax);

    }

    void Hard()
    {
        if(player.killPoint > 5 && player.killPoint < 10)
        {
            startTimerMin = 2;
            startTimerMax = 6;
        }
        if (player.killPoint > 10 && player.killPoint < 20)
        {
            startTimerMin = 1;
            startTimerMax = 4;
        }
        if (player.killPoint > 20 && player.killPoint < 30)
        {
            startTimerMin = 1;
            startTimerMax = 2;
        }
    }
}
