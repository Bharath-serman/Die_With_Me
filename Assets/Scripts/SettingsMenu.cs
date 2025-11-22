using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer mixer;

    public void setVolume(float volume)
    {
        mixer.SetFloat("volume." , volume);

    }

    public void setQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }
}
