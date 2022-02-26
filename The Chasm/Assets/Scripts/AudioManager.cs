using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource[] Effects;

    public float musicVolume;
    public float effectsVolume;
    

    //public static AudioManager instance;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            musicVolume = PlayerPrefs.GetFloat("MusicVolume");
            musicSource.volume = musicVolume;
        }
        else
        {
            musicSource.volume = musicVolume;
        }

        foreach (AudioSource sound in Effects)
        {
            if (PlayerPrefs.HasKey("EffectsVolume"))
            {
                effectsVolume = PlayerPrefs.GetFloat("EffectsVolume");
                sound.volume = effectsVolume;
            }
            else
            {
                sound.volume = 0.5f;
            }
        }

    }

    public void ChangeMusicSettings(float value)
    {
        musicSource.volume = value;
        Debug.Log("Music volume: " + musicSource.volume);
    }

    public void ChangeEffectsSettings(float value)
    {
        foreach (AudioSource sound in Effects)
        {
         sound.volume = value;
        }
    }



}
