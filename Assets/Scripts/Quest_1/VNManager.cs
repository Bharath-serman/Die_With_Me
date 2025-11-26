using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

public class VNManager : MonoBehaviour
{

    public GameObject Player;
    public GameObject[] All_Canvases;
    public GameObject[] VN_Canvas;
    public AudioSource BackgroundSource;

    //VisualNovelScript
    public VisualNovel novel;

    public void startVN()
    {
        if(Player != null)
        {
            Player.SetActive(false);
            var movement = Player.GetComponent<ThirdPersonController>();
            if(movement != null)
            {
                movement.enabled = false;
            }
        }

        //Iterate through all canvases.
        foreach(var canvases in All_Canvases)
        {
            canvases.SetActive(false);
        }

        //Enable the VN Canvas.
        foreach(var vcanvas in VN_Canvas)
        {
            vcanvas.SetActive(true);
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if(novel != null)
        {
            novel.StartVN();
            BackgroundSource.Play();
        }
    }

}
