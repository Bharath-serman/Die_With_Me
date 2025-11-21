using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public GameObject QuestPanel;
    private bool isOpen = false;

    [Header("The QuestPanel Texts")]
    public TMP_Text titletext;
    public TMP_Text descriptiontext;

    [Header("The Quest Showing Texts")]
    public TMP_Text Outsidetitletext;
    public TMP_Text Outsidedescriptiontext;
    public Image Outsidebackgroundimage;
    public int currentdescriptionindex = 0;

    private void Start()
    {
        QuestPanel.SetActive(false);
    }

    private void Update()
    {

        if (ErisFadePanel.isplaying)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            openquestpanel();
        }
    }

    public void openquestpanel()
    {
        isOpen = !isOpen;

        QuestPanel.SetActive(isOpen);

        if (isOpen)
        {
            Time.timeScale = 0;
            titletext.text = quest.title;
            descriptiontext.text = quest.description[currentdescriptionindex];
            Outsidetitletext.gameObject.SetActive(false);
            Outsidedescriptiontext.gameObject.SetActive(false);
            Outsidebackgroundimage.gameObject.SetActive(false);
        }
        else
        {
            Time.timeScale = 1;
            Outsidetitletext.gameObject.SetActive(true);
            Outsidedescriptiontext.gameObject.SetActive(true);
            Outsidebackgroundimage.gameObject.SetActive(true);
        }
    }
}
