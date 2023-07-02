using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    private bool musicManager = false;
    [SerializeField] private AudioSource musicSource, effectsSource;

    private void Awake()
    {
        musicSource.Stop();
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (musicManager)
        {
           if(!effectsSource.isPlaying)
            {
                musicSource.Play();
                musicManager = false;
            }
        }
    }

    public void PlaySound(AudioClip clip)
    {
        if (!effectsSource.isPlaying)
        {
            if (!musicSource.isPlaying)
            {
                effectsSource.PlayOneShot(clip);
                musicManager = true;
            }
            else
            {
                musicSource.Pause();
            }
        }
    }
}
