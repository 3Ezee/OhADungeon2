using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsBehavior : MonoBehaviour {

    public PlayerOneBehavior p;
    public List<EnemyBehavior> enemies;
    public Camera cam;
    public Transform positionCamera;
    public GameObject blackScreen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ActivateEnemies();
            DeactivateBlackScreen();
            PositionPlayer();
            PositionCamera();
        }
            
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DeactivateEnemies();
            ActivateBlackScreen();
        }
    }

    private void DeactivateBlackScreen()
    {
        blackScreen.SetActive(false);
    }

    private void ActivateBlackScreen()
    {
        blackScreen.SetActive(true);
    }

    private void ActivateEnemies()
    {
        foreach (EnemyBehavior enemy in enemies)
        {
            enemy.gameObject.SetActive(true);
            enemy.ResetEntity();

            enemy.transform.position = enemy.MyTransform;
 
        }
    }

    private void DeactivateEnemies()
    {
        foreach (EnemyBehavior enemy in enemies)
        {
            enemy.gameObject.SetActive(false);
        }
    }

    private void PositionPlayer()
    {

    }

    private void PositionCamera()
    {
        cam.transform.position = new Vector3(positionCamera.position.x, positionCamera.position.y, -10);
    }
}
