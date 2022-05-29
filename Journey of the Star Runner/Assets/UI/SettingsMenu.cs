using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    private void Start()
    {
        Slider[] slider = FindObjectsOfType<Slider>();

        float[] values = new float[slider.Length];

        audioMixer.GetFloat("VolumeEffects", out values[0]);
        audioMixer.GetFloat("VolumeMusic", out values[1]);
        audioMixer.GetFloat("VolumeMaster", out values[2]);
        
        for(int i = 0; i < slider.Length; i++)
        {
            slider[i].value = values[i];
        }
    }

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
