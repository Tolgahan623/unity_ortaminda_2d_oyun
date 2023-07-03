using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] Slider soundSlider;
    /*[SerializeField] AudioMixer masterMixer;*/

    /*void Start(){
        SetVolume(PlayerPrefs.GetFloat("SavedVolume" , 100f));
    }

    public void SetVolume(float soundValue){
        if(soundValue < 1f){
            soundValue = .001f;
            
        }

        RefreshSlider(soundValue);
        PlayerPrefs.SetFloat("SavedVolume" , soundValue);
        masterMixer.SetFloat("MasterVolume" , Mathf.Log10(soundValue / 100) * 20f);
    }

    public void SetVolumeFromSlider(){
        SetVolume(soundSlider.value);
    }

    public void RefreshSlider(float soundValue){
        soundSlider.value = soundValue;
    }*/

    void Start(){
        PlayerPrefs.GetFloat("Volume" , 1f);
        Load();
    }

    public void ChangeVolume(){
        AudioListener.volume = soundSlider.value;
        Save();
    }

    void Load(){
        soundSlider.value = PlayerPrefs.GetFloat("Volume");
    }

    void Save(){
        PlayerPrefs.SetFloat("Volume" , soundSlider.value);
    }

    public void RefreshSlider(float soundValue){
        soundSlider.value = soundValue;
    }

    public void Back(){
        SceneManager.LoadScene("MainMenu");
    }
}
