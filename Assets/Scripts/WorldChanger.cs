using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldChanger : MonoBehaviour
{
    public Material newskybox;
    public Color newalight = Color.black;

    [Header("Lists")]
    [Tooltip("Add the objects that needs to be disabled after entering the tunnel")]
    public List<GameObject> needtodisable = new List<GameObject>();

    [Tooltip("Add the objects that needs to be enabled after entering the tunnel")]
    public List<GameObject> needtoenable = new List<GameObject>();

    [Tooltip("Assign the objects that need to be disabled from the start")]
    public List<GameObject> GraveObject = new List<GameObject>();

    private bool actives = false;

    public QuestGiver giver;
    private Quest quest;

    private void Start()
    {
        foreach(GameObject obj in GraveObject)
        {
            obj.SetActive(false);
        }
        quest = giver.quest;

    }

    public void disableobjects()
    {
        foreach(GameObject obj in needtodisable)
        {
            obj.SetActive(actives);  //False.
        }
    }

    public void enableobjects()
    {
        foreach(GameObject objs in needtoenable)
        {
            objs.SetActive(!actives);  //True.
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RenderSettings.skybox = newskybox;
            RenderSettings.ambientLight = newalight;

            DynamicGI.UpdateEnvironment();  //Refreshes the scene.
            disableobjects();
            enableobjects();
            giver.currentdescriptionindex = 1;
            giver.descriptiontext.text = quest.description[giver.currentdescriptionindex];
            giver.descriptiontext.color = Color.red;
        }
    }
}
