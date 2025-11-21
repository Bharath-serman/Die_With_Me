using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Video;
using System.Collections.Generic;

public class VisualNovel : MonoBehaviour
{
    [TextArea] public string[] DialogueLines;
     public string[] SpeakerNames;

    public TMP_Text Text_Area;
    public TMP_Text SpeakerText;
    public AudioClip[] audios;
    public AudioSource source;
    public VideoPlayer IntroPlayer;

    public Image backgroundPanel;             
    public Sprite[] backgroundImages;         

    public float typingSpeed = 0.03f;
    public float fadeDuration = 1f;           

    private int index = 0;
    private bool isTyping = false;

    public GameObject Eris;  //The Main Character.
    public CanvasGroup ErisCanvasGroup;

    private int currentbackgroundindex = 0;

    public List<GameObject> Ridlist;

    void Start()
    {
        ShowLine();
        Eris.SetActive(false);
    }

    public void NextLine()
    {
        if (isTyping)
        {
            StopAllCoroutines();
            Text_Area.text = DialogueLines[index];
            isTyping = false;
            return;
        }

        if (index < DialogueLines.Length - 1)
        {
            index++;
            if (index == 23)
            {
                currentbackgroundindex = 1;
                StartCoroutine(ChangeBackground(1));
            }

            if(index == 4)
            {
                Eris.SetActive(true);
                StartCoroutine(FadeinEris());
            }

            if(index == 19)
            {
                Eris.SetActive(false);
                StartCoroutine(Flicker(2f, 4));
            }

            if(index == 31)
            {
                foreach(GameObject go in Ridlist)
                {
                    go.SetActive(false);
                }

                IntroPlayer.Play();
                IntroPlayer.isLooping = false;
            }

            if(index >= 23 && index <= 30)
            {
                Text_Area.color = Color.red;
                DialogueLines[index] = DialogueLines[index].ToUpper();
            }
            else
            {
                Text_Area.color = Color.white;
            }

            ShowLine();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void ShowLine()
    {
        Text_Area.text = "";
        StartCoroutine(TypeText(DialogueLines[index]));

        if (SpeakerNames != null && index < SpeakerNames.Length)
            SpeakerText.text = SpeakerNames[index];

        if (audios != null && index < audios.Length && audios[index] != null)
        {
            source.clip = audios[index];
            source.Play();
        }
    }

    IEnumerator TypeText(string line)
    {
        isTyping = true;
        Text_Area.text = "";

        foreach (char letter in line.ToCharArray())
        {
            Text_Area.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }
    IEnumerator ChangeBackground(int imageIndex)
    {
        float alpha = 1;
        while (alpha > 0)
        {
            alpha -= Time.deltaTime / fadeDuration;
            backgroundPanel.color = new Color(1, 1, 1, alpha);
            yield return null;
        }

        backgroundPanel.sprite = backgroundImages[imageIndex];
        alpha = 0;
        while (alpha < 1)
        {
            alpha += Time.deltaTime / fadeDuration;
            backgroundPanel.color = new Color(1, 1, 1, alpha);
            yield return null;
        }
    }

    IEnumerator FadeinEris()
    {
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            ErisCanvasGroup.alpha = Mathf.Lerp(0, 1, elapsed / fadeDuration);
            yield return null;
        }
        ErisCanvasGroup.alpha = 1;
    }

    IEnumerator Flicker(float flickerduration , int repeatcount = 2)
    {
        for(int i = 0; i < repeatcount; i++)
        {
            backgroundPanel.color = Color.black;  //Black color
            backgroundPanel.sprite = null;

            yield return new WaitForSeconds(flickerduration);

            backgroundPanel.sprite = backgroundImages[currentbackgroundindex];
            backgroundPanel.color = new Color(1, 1, 1, 1);  //White color.

            yield return new WaitForSeconds(flickerduration);
        }
    }
}
