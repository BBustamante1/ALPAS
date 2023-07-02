using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{

	public static MusicManager instance;

	[SerializeField]private AudioMixerGroup musicMixerGroup;
	private bool fromStory = false;
	[NonReorderable] public Sound[] music;

	void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

		foreach (Sound s in music)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;
			s.source.outputAudioMixerGroup = musicMixerGroup;
		}
	}

    private void OnEnable()
    {
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
		if (scene.buildIndex == 1 && fromStory)
		{
			fromStory = false;
			Stop();
		}
		if (scene.buildIndex > 3)
		{
			fromStory = true;
			Stop();
			Play("pianoBGMUSIC");
		}
		if (scene.name == "MainMenu" || scene.name == "ScannerScene")
        {
			Play("menuBGMUSIC");
		}
	}	

    public void Play(string sound)
	{
		Sound s = Array.Find(music, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}
		if (!s.source.isPlaying) s.source.Play();
	}

    public void Stop()
    {
		for (int i = 0; i < music.Length; i++)
		{
			if (music[i] != null)
			{
				music[i].source.Stop();
			}
		}
	}

	public void ChangeEffectsVolume(float value)
    {
		AudioListener.volume = value;
    }

	public void UpdateMusicMixerVolume()
	{
		musicMixerGroup.audioMixer.SetFloat("Music Volume", Mathf.Log10(AudioOptionsManager.musicVolume) * 20);
	}
}
