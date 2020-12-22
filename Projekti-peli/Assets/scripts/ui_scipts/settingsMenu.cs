using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class settingsMenu : MonoBehaviour
{

    Resolution[] resolutions;

    //public TMP_Dropdown resolutionDropdown;

    public AudioMixer audioMixer;
    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown qualityDropdown;
    public TMP_Dropdown textureDropdown;
    public TMP_Dropdown aaDropdown;
    public Slider volumeSlider;
    float currentVolume;

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();


        int curResInd = 0; // current resolution index? (yeah, probably)
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                curResInd = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = curResInd;
        resolutionDropdown.RefreshShownValue();
    }


    // audio stuff
    public void setVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        currentVolume = volume;
    }

    // graphics stuff

    public void setfullScreen(bool isFullScreen) // is fullscreen?
    {
        Screen.fullScreen = isFullScreen;
    }

    public void setResolution(int resolutionIndex) // set resolution
    {
        Resolution res = resolutions[resolutionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

    public void SetTextureQuality(int textureIndex) // set texture quality
    {
        QualitySettings.masterTextureLimit = textureIndex;
        qualityDropdown.value = 5;
    }

    public void SetAntiAliasing(int aaIndex) // set anti aliasing
    {
        QualitySettings.antiAliasing = aaIndex;
        qualityDropdown.value = 5;
    }

    public void SetQuality(int qualityIndex) // quality presets
    {
        if (qualityIndex != 6)
            QualitySettings.SetQualityLevel(qualityIndex);
        switch (qualityIndex)
        {
            case 0: // quality level - Ultra Performance
                textureDropdown.value = 3;
                aaDropdown.value = 0;
                break;
            case 1: // quality level - Performance
                textureDropdown.value = 2;
                aaDropdown.value = 0;
                break;
            case 2: // quality level - Balanced
                textureDropdown.value = 1;
                aaDropdown.value = 0;
                break;
            case 3: // quality level - Quality
                textureDropdown.value = 0;
                aaDropdown.value = 1;
                break;
            case 4: // quality level - Ultra Quality
                textureDropdown.value = 0;
                aaDropdown.value = 2;
                break;
        }
    }

    // setiing saving and loading stuff

    public void SaveSettings() // saving
    {
        PlayerPrefs.SetInt("QualitySettingPreference",
                   qualityDropdown.value);
        PlayerPrefs.SetInt("ResolutionPreference",
                   resolutionDropdown.value);
        PlayerPrefs.SetInt("TextureQualityPreference",
                   textureDropdown.value);
        PlayerPrefs.SetInt("AntiAliasingPreference",
                   aaDropdown.value);
        PlayerPrefs.SetInt("FullscreenPreference",
                   Convert.ToInt32(Screen.fullScreen));
        PlayerPrefs.SetFloat("VolumePreference",
                   currentVolume);
    }

    public void LoadSettings(int currentResolutionIndex) // loading
    {
        if (PlayerPrefs.HasKey("QualitySettingPreference"))
            qualityDropdown.value =
                         PlayerPrefs.GetInt("QualitySettingPreference");
        else
            qualityDropdown.value = 3;
        if (PlayerPrefs.HasKey("ResolutionPreference"))
            resolutionDropdown.value =
                         PlayerPrefs.GetInt("ResolutionPreference");
        else
            resolutionDropdown.value = currentResolutionIndex;
        if (PlayerPrefs.HasKey("TextureQualityPreference"))
            textureDropdown.value =
                         PlayerPrefs.GetInt("TextureQualityPreference");
        else
            textureDropdown.value = 0;
        if (PlayerPrefs.HasKey("AntiAliasingPreference"))
            aaDropdown.value =
                         PlayerPrefs.GetInt("AntiAliasingPreference");
        else
            aaDropdown.value = 1;
        if (PlayerPrefs.HasKey("FullscreenPreference"))
            Screen.fullScreen =
            Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));
        else
            Screen.fullScreen = true;
        if (PlayerPrefs.HasKey("VolumePreference"))
            volumeSlider.value =
                        PlayerPrefs.GetFloat("VolumePreference");
        else
            volumeSlider.value =
                        PlayerPrefs.GetFloat("VolumePreference");
    }
}

