using UnityEngine.Audio;
using UnityEngine;
using System;
public class AudioManager : MonoBehaviour
{

    public sound[] sounds;

  //  public static AudioManager inslance;

    void Awake()
    {
        foreach(sound s in sounds)

        {
           s.source= gameObject.AddComponent<AudioSource>();
            s.source.clip = s.Clip;

            s.source.volume = s.volum;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
     }
    private void Start()
    {
        Play("gamesound");
    }

    public void Play(string name)
    {
        sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Play();
    } 

}
