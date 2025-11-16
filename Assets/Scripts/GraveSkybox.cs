using UnityEngine;

public class GraveSkybox : MonoBehaviour
{
    public Material UpdateSkybox;
    public Material existingskybox;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RenderSettings.skybox = UpdateSkybox;
            DynamicGI.UpdateEnvironment();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        RenderSettings.skybox = existingskybox;
        DynamicGI.UpdateEnvironment();
    }
}
