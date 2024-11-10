using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    public Text HpText;
    public Slider HpBar;
    PlayerController _player;
    public Text killPointInterface;
    public CanvasGroup gameOver;
    void Start()
    {
        _player = FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
        HpBar.maxValue = _player.MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        HpText.text = _player.HP + "/" + _player.MaxHP;
        HpBar.value = _player.HP;
        killPointInterface.text = _player.killPoint.ToString();
        GameOver();
    }

    void GameOver()
    {
        if (_player.Dead && gameOver.alpha == 0)
        {
            StartCoroutine(TheEnd());
        }
    }
    IEnumerator TheEnd()
    {
        yield return new WaitForSeconds(0.2f);
        gameOver.alpha = 0.3f;
        yield return new WaitForSeconds(0.2f);
         gameOver.alpha = 0.5f;
        yield return new WaitForSeconds(0.2f);
        gameOver.alpha = 0.7f;
        yield return new WaitForSeconds(0.2f);
        gameOver.alpha = 0.9f;
        yield return new WaitForSeconds(0.2f);
        gameOver.alpha = 1;
        
    }
}
