using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;
    public AudioMixer audioMixer;
    public AudioMixer sfxAudioMixer;
    public AudioSource audioSource;
    public static AudioManager audioInstance;
    public Slider musicSlider;
    public Slider sfxSlider;
    private float musicValue = 0.0f;
    private float sfxValue = 0.0f;
    
    private void Awake()
    {
        if (audioInstance == null)
        {
            audioInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        foreach (Sounds sound in sounds)
        {
            sound.source = audioSource;
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }

    private void Start()
    {

        PlayMenuTheme();
    }
    
    public void PlayMenuTheme()
    {
        StopMusic("MainTheme");
        PlayMusic("Menu"); 
    }
    
    public void PlayMainTheme()
    {
        musicValue = musicSlider.value;
        sfxValue = sfxSlider.value;
        StopMusic("Menu");
        PlayMusic("MainTheme"); 
    }
    public void PlayMusic(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }
        s.source.clip = s.clip;
        s.source.Play();
    }
    
    public void StopMusic(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }
        s.source.clip = null;
    }

    public void GetSliderValues(Slider music, Slider sfx)
    {
        music.value = musicValue;
        sfx.value = sfxValue;
    }
    
    public void SetSliderValues(Slider music, Slider sfx)
    {
        musicValue = music.value;
        sfxValue = sfx.value;
        
        musicSlider.value = musicValue;
        sfxSlider.value = sfxValue;
    }

    public void SetMainMenuSliders(Slider music, Slider sfx)
    {
        musicSlider = music;
        sfxSlider = sfx;
        
        musicSlider.value = musicValue;
        sfxSlider.value = sfxValue;
    }
}