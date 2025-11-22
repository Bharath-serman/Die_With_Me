using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MainMenuCanvas : MonoBehaviour
{
    public GameObject MainPanelz;
    public GameObject OptionsPanelz;
    public GameObject ControlsPanelz;
    private bool isPaused = false;
    public CinemachineBrain brain;

    [Header("Cameras")]
    public Camera UICamera;
    public Camera MainCamera;

    [Header("Grave_Panels")]
    [Tooltip("The Objects that are overlapping with MainMenu canvas")]
    public GameObject[] PanelsToHide;
    public Canvas infoCanvas;

    private void Start()
    {
        MainPanelz.SetActive(false);  
        OptionsPanelz.SetActive(false);
        ControlsPanelz.SetActive(false);
        UICamera.enabled = false;
        MainCamera.enabled = true;
    }

    private void Update()
    {
        if (ErisFadePanel.isplaying)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused; 

            if (isPaused)
                PauseGame();
            else
                ResumeGame();
        }
    }

    private void PauseGame()
    {
        foreach(GameObject go in PanelsToHide)
        {
            go.SetActive(false);
        }
        infoCanvas.enabled = false;
        UICamera.enabled = true;
        MainCamera.enabled = false;
        MainPanelz.SetActive(true);   
        OptionsPanelz.SetActive(false);
        ControlsPanelz.SetActive(false);
        Time.timeScale = 0f;          // Pause game
        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true;
        brain.enabled = false;
    }

    private void ResumeGame()
    {
        foreach(GameObject go in PanelsToHide)
        {
            go.SetActive(true);
        }
        infoCanvas.enabled = true;
        UICamera.enabled = false;
        MainCamera.enabled = true;
        MainPanelz.SetActive(false);  
        OptionsPanelz.SetActive(false);
        ControlsPanelz.SetActive(false);
        Time.timeScale = 1f;          // Resume game
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        brain.enabled = true;
    }

    public void OpenOptions()
    {
        MainPanelz.SetActive(false);
        OptionsPanelz.SetActive(true);
    }

    public void OpenControls()
    {
        MainPanelz.SetActive(false);
        ControlsPanelz.SetActive(true);
    }

    public void BackOptions()
    {
        OptionsPanelz.SetActive(false);
        MainPanelz.SetActive(true);
    }

    public void BackControls()
    {
        ControlsPanelz.SetActive(false);
        MainPanelz.SetActive(true);
    }

    public void Exits()
    {
        Application.Quit();
    }
}
