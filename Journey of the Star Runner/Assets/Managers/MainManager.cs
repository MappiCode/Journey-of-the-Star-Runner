using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MainManager : MonoBehaviour
{
    public static MainManager instance;

    public Inventory inventory;
    public InGameUI ui;
    public AudioMixer audioMixer;

    public string activeSceneName;
    public string lastSceneName;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        inventory = GetComponent<Inventory>();

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AudioCutoff(bool cutoff)
    {
        if (cutoff)
        {
            audioMixer.SetFloat("MusicHighpassCutoffFreq", 220f);
            audioMixer.SetFloat("MusicLowpassCutoffFreq", 3000f);
            return;
        }
        if (!cutoff)
        {
            audioMixer.SetFloat("MusicHighpassCutoffFreq", 10f);
            audioMixer.SetFloat("MusicLowpassCutoffFreq", 22000f);
        }
    }
}
