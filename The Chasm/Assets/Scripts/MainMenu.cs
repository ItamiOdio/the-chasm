using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public AudioManager manager;

    public GameObject menu;
    public GameObject settings;
    public GameObject info;

    public Button saveSettingsBtn;
    public Button settingsButton;
    public Button infoButton;

    public Image  newGameSelector;
    public Image  loadGameSelector;
    public Image  settingsSelector;
    public Image  quitGameSelector;
    public Image saveAudio1;
    public Image saveAudio2;
    public Image cancelAudio1;
    public Image cancelAudio2;

    public Slider musicSlider;
    public Slider effectsSlider;

    // Start is called before the first frame update
    void Start()
    {
        newGameSelector.enabled = false;
        loadGameSelector.enabled = false;
        settingsSelector.enabled = false;
        quitGameSelector.enabled = false;

        musicSlider.onValueChanged.AddListener(delegate { SetMusicVolume(); });
        musicSlider.value = manager.musicVolume;

        effectsSlider.onValueChanged.AddListener(delegate { SetEffectsVolume(); });
        effectsSlider.value = manager.effectsVolume;

    }

    private void OnEnable()
    {
        PlayerStats.points = 0;
        PlayerStats.hp = 5;
    }

    public void OpenSettings()

    {
        menu.SetActive(false);
        settings.SetActive(true);
        saveAudio1.enabled = false;
        saveAudio2.enabled = false;
        cancelAudio1.enabled = false;
        cancelAudio2.enabled = false;
        saveSettingsBtn.Select();
    }


    public void CloseSettings()

    {
        menu.SetActive(true);
        settings.SetActive(false);
        settingsButton.Select();
        
    }

    public void CloseInfo()

    {
        menu.SetActive(true);
        info.SetActive(false);
        infoButton.Select();

    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
        PlayerPrefs.SetFloat("EffectsVolume", effectsSlider.value);
    }

    public void SetMusicVolume()
    {
        manager.ChangeMusicSettings(musicSlider.value);
    }

    public void SetEffectsVolume()
    {
        Debug.Log("Effects volume: " + effectsSlider.value);
        manager.ChangeEffectsSettings(effectsSlider.value);
    }


    // QUIT

    public void QuitGame()
    {
        Application.Quit();
    }
}
