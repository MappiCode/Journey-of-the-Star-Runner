using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolumeMaster(float volume)
    {
        audioMixer.SetFloat("VolumeMaster", volume);
    }
    public void SetVolumeMusic(float volume)
    {
        audioMixer.SetFloat("VolumeMusic", volume);
    }
    public void SetVolumeEffects(float volume)
    {
        audioMixer.SetFloat("VolumeEffects", volume);
    }
}
