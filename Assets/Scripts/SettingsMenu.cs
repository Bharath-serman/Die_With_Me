using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    //Audio Mixer
    public AudioMixer MainMenuMixer;

    public void SetVolume(float volume)
    {
        MainMenuMixer.SetFloat("volume.", volume);
    }

    public void setQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }
}
