using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneTransition : MonoBehaviour
{
    [Header("Buttons")]
    [Tooltip("Assign the SceneLoadButton.")]
    [SerializeField] public Button SceneLoadButton; // Spider Logo Button

    [Tooltip("Assign the startgamebutton.")]
    [SerializeField] private Button startgamebutton;

    [Tooltip("Assign the Quitbutton.")]
    [SerializeField] private Button Quitbutton;

    [Tooltip("Assign the optionsButton.")]
    [SerializeField] private Button optionsButton;

    [Tooltip("Assign the OptionsBackButton.")]
    [SerializeField] private Button OptionsBackButton;

    [Header("GameObjects")]
    [SerializeField] private GameObject MainPanel;
    [SerializeField] private GameObject OptionsPanel;
    [SerializeField] private GameObject ControlsPanel;

    private bool PanelActive = false;

    private void Start()
    {
        MainPanel.SetActive(!PanelActive);  //True.
        OptionsPanel.SetActive(PanelActive);  //False.
        ControlsPanel.SetActive(PanelActive);  //False.
    }
    public void OnButtonClick()
    {
        NextScene();
    }
    void NextScene()
    {
        SceneManager.LoadScene("Menu");  //Loading the scene.
    }

    public void StartGame()
    {
        SceneManager.LoadScene(2);  //Glitch_Scene
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void optionspanel()
    {
        OptionsPanel.SetActive(!PanelActive);  //True.
        MainPanel.SetActive(PanelActive);  //False.
    }

    public void Gobackoptions()
    {
        OptionsPanel.SetActive(PanelActive);  //False.
        MainPanel.SetActive(!PanelActive);  //True.
    }

    public void OpenControlsPanel()
    {
        ControlsPanel.SetActive(!PanelActive);  //True.
        MainPanel.SetActive(PanelActive);  //False.
    }

    public void GobackControls()
    {
        ControlsPanel.SetActive(PanelActive);  //False.
        MainPanel.SetActive(!PanelActive);  //True.
    }

    private void Update()
    {
        //Check for Escape button click
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (OptionsPanel)
            {
                Gobackoptions();
            }
            if (ControlsPanel)
            {
                GobackControls();
            }
        }
    }
}



