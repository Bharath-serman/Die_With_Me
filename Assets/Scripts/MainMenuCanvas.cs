using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MainMenuCanvas : MonoBehaviour
{
    public GameObject MainPanelz;
    public GameObject OptionsPanelz;
    public GameObject ControlsPanelz;
    public GameObject SaveAndLoadPanel;
    private bool isPaused = false;
    public CinemachineBrain brain;
    public GameObject ContinueButton;

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
        SaveAndLoadPanel.SetActive(false);
        UICamera.enabled = false;
        MainCamera.enabled = true;

        bool anySave = false;

        for (int i = 1; i <= 8; i++)
        {
            if (SaveSystem.SaveExists(i))
            {
                anySave = true;
                break;
            }
        }

        ContinueButton.SetActive(anySave);
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

    public void ContinueGame()
    {
        for (int i = 1; i <= 8; i++)
        {
            if (SaveSystem.SaveExists(i))
            {
                GameManager.Instance.Load(i);
                break;
            }
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
        SaveAndLoadPanel.SetActive(false);
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
        SaveAndLoadPanel.SetActive(false);
        Time.timeScale = 1f;          // Resume game
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        brain.enabled = true;
    }

    public void OpenSaveAndLoadPanel()
    {
        MainPanelz.SetActive(false);
        SaveAndLoadPanel.SetActive(true);
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

    public void BackSaveAndLoad()
    {
        SaveAndLoadPanel.SetActive(false);
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
