using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClickExample : MonoBehaviour
{
    //Esto es un comentario
    public Button Empezar;
    public Button ComoJugar;
    public Button Salir;

    public Image imgComoJugar;
    public bool _isOpen=false;

    void Start()
    {
        Button btnEmpezar = Empezar.GetComponent<Button>();
        btnEmpezar.onClick.AddListener(TaskStart);
        Button btnComoJugar = ComoJugar.GetComponent<Button>();
        btnComoJugar.onClick.AddListener(TaskHowPlay);
        Button btnSalir = Salir.GetComponent<Button>();
        btnSalir.onClick.AddListener(TaskQuit);
    }

    void TaskStart()
    {
        SceneManager.LoadScene("Level");
    }

    void TaskHowPlay()
    {
        if (!_isOpen)
        {
            imgComoJugar.gameObject.SetActive(true);
            _isOpen = true;
        }
        else
        {
            imgComoJugar.gameObject.SetActive(false);
            _isOpen = false;
        }
            
    }

    void TaskQuit()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }
}