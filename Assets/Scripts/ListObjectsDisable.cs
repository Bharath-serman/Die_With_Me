using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListObjectsDisable : MonoBehaviour
{
    [Header("Inputs")]
    [Tooltip("List of GameObjects that need to be disabled!")]
    public List<GameObject> DisableObjects;
    private bool activestatus = false;
    public LiftTeleport liftteleport;

    private void Start()
    {
        DisableGameObjects();
        liftteleport.onliftfinished += EnableGameObjects;
    }

    public void DisableGameObjects()
    {
           //Iterate through every GameObjects.
                foreach(GameObject obj in DisableObjects)
                {
                    obj.SetActive(activestatus);  //False.
                }
        }

    public void EnableGameObjects()
    {
        foreach(GameObject obj in DisableObjects)
        {
            obj.SetActive(!activestatus);  //True.
        }
    }
}
