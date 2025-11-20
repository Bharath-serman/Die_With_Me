using UnityEngine;
using UnityEngine.UI;

public class GraveSkybox : MonoBehaviour
{
    public Material UpdateSkybox;
    public Material existingskybox;
    [Header("Grave Panels")]
    public GameObject GravePanels;
    private bool PanelActive = true;

    private void Awake()
    {
        if (PanelActive)
        {
            GravePanels.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RenderSettings.skybox = UpdateSkybox;
            DynamicGI.UpdateEnvironment();
            GravePanels.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        RenderSettings.skybox = existingskybox;
        DynamicGI.UpdateEnvironment();
        GravePanels.SetActive(false);
    }
}
