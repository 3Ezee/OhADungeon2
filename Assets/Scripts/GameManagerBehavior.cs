using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerBehavior : MonoBehaviour {

    public GameObject map1;
    public GameObject map2;
    public GameObject map3;
    public Transform posMap1;
    public Transform posMap2;
    public Transform posMap3;
    public Transform WinMap2;
    public PlayerOneBehavior _player;
    public Camera _cam;
    private int ActualLevel=1;
    public BossBehavior _boss;
    public Image winImage;
    public Button mainMenu;   

    private void Update()
    {

        if (!_player.gameObject.activeSelf)
        {
            _player.gameObject.SetActive(true);
            _player.ResetPlayer();
            _player.transform.localScale = new Vector3(1, 1, 1);
            if (ActualLevel == 1)
            {
                _player.transform.position = posMap1.position; 
            }
            else if(ActualLevel == 2)
            {
                _player.transform.position = posMap2.position;
            }
            else if(ActualLevel == 3)
            {
                _player.transform.position = posMap3.position;
            }
        }
        if (_boss.IsDie)
        {
            Win();
        }
    }

    private void Win()
    {
        winImage.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            if (ActualLevel == 1)
            {
                map1.SetActive(false);
                map2.SetActive(true);
                _player.transform.position = posMap2.position;
                this.transform.position = WinMap2.position;
                _player.life = _player.InitLife;
                ActualLevel = 2;
            }
            else if(ActualLevel == 2)
            {
                map2.SetActive(false);
                map3.SetActive(true);
                _player.transform.position = posMap3.position;
                _player.HaveKey = false;
                _player.life = _player.InitLife;
                ActualLevel = 3;
            }
            
    }
}
