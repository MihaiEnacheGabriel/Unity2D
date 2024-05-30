using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour
{
    public Slider volumeSlider;
    public GameObject objMusic;
    private AudioSource AudioSource=null;
    private float musicVolume=1f;
    
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();

    }
    private void Load()
    {
        musicVolume=PlayerPrefs.GetFloat("musicVolume");
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }

    void Start()
    {
        objMusic = GameObject.FindGameObjectWithTag("Audio");
        AudioSource = objMusic.GetComponent<AudioSource>();
        if (AudioSource != null)
        {
            Load();
            AudioSource.volume = musicVolume;
            volumeSlider.value = musicVolume;
        }
    }
    public void Back()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
