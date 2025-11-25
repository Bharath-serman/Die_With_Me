using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
using UnityEngine.Audio;
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

    [Header("FadeAnimator")]
    public Animator FadeAnimator;
    public PlayableDirector CutscenePlayer;

    [Header("GameObjects")]
    [SerializeField] private GameObject MainPanel;
    [SerializeField] private GameObject OptionsPanel;
    [SerializeField] private GameObject ControlsPanel;

    [Header("ParticleSystems")]
    [SerializeField] private ParticleSystem DialogueEffect;
    [SerializeField] private ParticleSystem MenuBackGroundEffect;

    [Header("Audios")]
    public AudioSource source;
    public AudioSource TimelineSource;

    private bool PanelActive = false;

    private void Start()
    {
        CutscenePlayer.stopped += OnTimelineFinished;
        MenuBackGroundEffect.gameObject.SetActive(!PanelActive);  //True.
        MenuBackGroundEffect.Play();
        MainPanel.SetActive(!PanelActive);  //True.
        OptionsPanel.SetActive(PanelActive);  //False.
        ControlsPanel.SetActive(PanelActive);  //False.
        DialogueEffect.gameObject.SetActive(PanelActive);  //False.
        source.Play(); //Plays the Audio.
        TimelineSource.Stop();  //Stops playing at start.
    }

    void OnTimelineFinished(PlayableDirector director)
    {
        SceneManager.LoadScene(2);
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
        MenuBackGroundEffect.gameObject.SetActive(PanelActive);
        source.Stop(); //Stop playing the MainMenu audio.
        TimelineSource.Play();  //Plays the Timeline Audio.
        FadeAnimator.Play("StartButtonFadeAnimation");

        //Timeline Logic goes here...
        CutscenePlayer.Play();
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



