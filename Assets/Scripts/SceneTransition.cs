using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneTransition : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] public Button SceneLoadButton; // Spider Logo Button
    [SerializeField] private Button startgamebutton;
    [SerializeField] private Button Quitbutton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button OptionsBackButton;
    [Header("GameObjects")]
    [SerializeField] private GameObject MainPanel;
    [SerializeField] private GameObject OptionsPanel;

    private bool PanelActive = false;

    private void Start()
    {
        MainPanel.SetActive(!PanelActive);  //True.
        OptionsPanel.SetActive(PanelActive);  //False.
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

    private void Update()
    {
        //Check for Escape button click
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Gobackoptions();
        }
    }
}



