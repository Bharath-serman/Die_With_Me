using UnityEngine;
using TMPro;
using System.Collections;

public class VisualNovel : MonoBehaviour
{
    [TextArea] public string[] DialogueLines;
    public string[] SpeakerNames;
    public TMP_Text Text_Area;
    public TMP_Text SpeakerText;
    public AudioClip[] audios;
    public AudioSource source;

    public float typingSpeed = 0.03f;  
    private int index = 0;
    private bool isTyping = false;

    void Start()
    {
        ShowLine();
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
            ShowLine();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void ShowLine()
    {
        if (SpeakerNames != null && index < SpeakerNames.Length)
            SpeakerText.text = SpeakerNames[index];

        if (audios != null && index < audios.Length && audios[index] != null)
        {
            source.clip = audios[index];
            source.Play();
        }

        StopAllCoroutines();
        StartCoroutine(TypeText(DialogueLines[index]));
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
}

/*
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class VisualNovel : MonoBehaviour
{
    [TextArea] public string[] DialogueLines;
    public string[] SpeakerNames;

    public TMP_Text Text_Area;
    public TMP_Text SpeakerText;
    public AudioClip[] audios;
    public AudioSource source;

    public Image backgroundPanel;             
    public Sprite[] backgroundImages;         

    public float typingSpeed = 0.03f;
    public float fadeDuration = 1f;           

    private int index = 0;
    private bool isTyping = false;

    void Start()
    {
        ShowLine();
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
            if (index == 3) StartCoroutine(ChangeBackground(1));
            if (index == 6) StartCoroutine(ChangeBackground(2));

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
}
*/