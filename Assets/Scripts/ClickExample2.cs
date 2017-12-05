using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClickExample2 : MonoBehaviour {

    public Button Continuar;
    public Button Reiniciar;
    public Button MenuPrincipal;

    void Start()
    {
        Button btnContinuar = Continuar.GetComponent<Button>();
        btnContinuar.onClick.AddListener(TaskContinue);
        Button btnReiniciar = Reiniciar.GetComponent<Button>();
        btnReiniciar.onClick.AddListener(TaskReset);
        Button btnMenuPrincipal = MenuPrincipal.GetComponent<Button>();
        btnMenuPrincipal.onClick.AddListener(TaskMenu);
    }

    void TaskContinue()
    {
        Debug.Log("Continue game");
        //Continuar.gameObject.SetActive(false);
        Reiniciar.gameObject.SetActive(false);
        MenuPrincipal.gameObject.SetActive(false);
    }
    void TaskReset()
    {
        Debug.Log("Reset game");
        SceneManager.LoadScene("Level");
    }
    void TaskMenu()
    {
        Debug.Log("Menu game");
        SceneManager.LoadScene("Menu");
    }
}
