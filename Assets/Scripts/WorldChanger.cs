using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldChanger : MonoBehaviour
{
    public Material newskybox;
    public Color newalight = Color.black;
    [Tooltip("Add the objects that needs to be disabled after entering the tunnel")]
    public List<GameObject> needtodisable = new List<GameObject>();
    [Tooltip("Add the objects that needs to be enabled after entering the tunnel")]
    public List<GameObject> needtoenable = new List<GameObject>();
    public GameObject graveobject;
    private bool actives = false;

    private void Start()
    {
        graveobject.SetActive(actives);  //false.
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
        }
    }
}
