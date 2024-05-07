using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EscDDalKak : MonoBehaviour
{
    [SerializeField] private GameObject ui;
    private void Awake()
    {
        ui.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                ui.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                ui.SetActive(true);
            }
        }
    }
    public void Continue()
    {
        Time.timeScale = 1;
        ui.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }

}
