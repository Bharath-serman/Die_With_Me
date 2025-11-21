using UnityEngine;

public class Blink : MonoBehaviour
{
    private bool IsPlay = false;

    public GameObject LoadingLogo;

    void Start()
    {

        if(LoadingLogo != null)
        {
            LoadingLogo.SetActive(false);
        }
    }

    public void playBlink()
    {

        if(LoadingLogo != null)
        {
            LoadingLogo.SetActive(true);
        }
    }
}
