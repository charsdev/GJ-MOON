using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;

public class Settings : MonoBehaviour {

    private Resolution[] resolutions;
    [SerializeField] private TMP_Dropdown resolutionsDropdown;
    

    private void Start()
    {
        updateResolutionDropdown();
    }

	private void updateResolutionDropdown()
	{
		resolutions = Screen.resolutions;
        resolutionsDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " ";
            options.Add(option);

            if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionsDropdown.AddOptions(options);
        resolutionsDropdown.value = currentResolutionIndex;
        resolutionsDropdown.RefreshShownValue();
	}
    
	
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen, resolution.refreshRate);
    }
    
    
    public void SetMusicVolume(float volume)
    {
        AudioManager.audioInstance.audioMixer.SetFloat("volume", volume);
    }
    
    public void SetSFXVolume(float volume)
    {
        AudioManager.audioInstance.sfxAudioMixer.SetFloat("volume", volume);
    }

    public void SetFullScreen (bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}