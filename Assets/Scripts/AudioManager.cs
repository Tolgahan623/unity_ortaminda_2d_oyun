using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    /*public GameObject sfxOff;
    public GameObject sfxOn;*/

    void Awake()
    {
        if(instance == null)
        instance = this;

        else{
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);

        
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        
    }

    void Start(){
       /* isMuted = PlayerPrefs.GetInt("Muted") == 1;
        AudioListener.pause = isMuted;

        if(isMuted){
            sfxOn.SetActive(false);
            sfxOff.SetActive(true);
        }

        else{
            sfxOff.SetActive(false);
            sfxOn.SetActive(true);
        }*/
        
        Play("Theme");
    }

    public void Play(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        return;

        s.source.Play();
    }

    private bool isMuted;

    /*public void isMutedPressed(){
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
        PlayerPrefs.SetInt("Muted" , isMuted ? 1 : 0);

        if(isMuted){
            sfxOn.SetActive(false);
            sfxOff.SetActive(true);
        }

        else{
            sfxOff.SetActive(false);
            sfxOn.SetActive(true);
        }
    }*/
}
